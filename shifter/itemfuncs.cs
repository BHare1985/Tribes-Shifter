
//============================ Functions For Beacons and Other Ammos and Items ===============================
//
// Holds functions for varrious items in the game, including cloaking and stim, as well as varrious beacons 
// and other stuff. All are special functions specific to a given item.
//
//=========================================================== Det.Bug

//========================= Checkhackable Returns TRUE if NOT in the list.
function checkHackable(%name, %shape)
{

	//echo ("SHAPE " @ %shape);
	if(%shape == "Generator" ||
	%shape == "generator_p" ||
	%shape == "solar_med" ||
	%shape == "inventory_sta" ||
	%shape == "camera" ||
	%shape == "hellfiregun" ||
	%shape == "indoorgun" ||
	%shape == "mortar_turret" ||
	%shape == "ammounit" || 
	%shape == "sensor_pulse_med" ||
	%shape == "station_cmdpnl" ||
	%shape == "missileturret" ||
	%shape == "cmdpnl" ||
	%shape == "radar" ||
	%shape == "turret" ||
	%shape == "chainturret" ||
	%shape == "vehi_pur_pnl" ||
	%shape == "MagCargo" ||
	%shape == "vehi_pur_poles")
	{
		return 0;
	}
	else 
		return 1;
}

function isPlayerBusy(%client)
{
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	
	if ($debug) echo  ("Hacking");
	
	if(%time > 0)
	{
		if($hacking[%client] == "true")
		{
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time -1 @ "','" @ %client @ "');", 1);
			return;
		}
	}
	else if ((%time < 0 || %time == 0) && $hacking[%client] == "true")
	{
		if ($debug) echo ("PT - " @ %pteam @ "");
		if ($debug) echo ("TT - " @ %team @ "");
		if ($debug) echo ("HK - " @ $hacking[%client] @ "");
		if ($debug) echo ("TG - " @ %target @ "");
		if ($debug) echo ("Tm - " @ %time @ "");

		if($hacking[%client] == "true")
		{
			if(%team == %pTeam)
			{
				if ($debug) echo ("infecting");
				%target.infected = "true";

				playSound(TargetingMissile,GameBase::getPosition(%target));

				Client::sendMessage(%client,1,"Your " @ %name @ " is now protected by viral infection, from hacking.");
				return;
			}
			else
			{
			
				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);	
					if (%rnd > 50)
					{
						playSound(TargetingMissile,GameBase::getPosition(%target));
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						Player::blowUp(%this);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						playSound(TargetingMissile,GameBase::getPosition(%target));
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						//echo ("hackerror");
						return;
					}
				}
				
				if(%name == "False" && %shape == "MagCargo")
				{
				    	Client::sendMessage(%client,1,"You disarm the DetPack.");
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						if(%target)deleteobject(%target);
				}
				else
				{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					
					//if($Shifter::HackedTime > 0)
					//{
					//	schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
					//}

					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}
				}	
			}
		}
	}
}

//==================================================================================== Deployables Functions
function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$VehicleObjectType | $StaticObjectType | $SimPlayerObjectType,%pos,1,1,1,1); //1,1,2,0 | $ItemObjectType
	%n = Group::objectCount(%set);	
	
	if(!%num)
	{
		if(%set)deleteobject(%set);
		return 1;
	}

	%datab = GameBase::getDataName(Group::getObject(%set,0));
	%obj = (getObjectType(Group::getObject(%set,0)));
	if(%set)deleteobject(%set);
	if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform"  || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "LargeEmplacementPlatform")
	{
		return 1;
	}
	else if(%num == 1 && %obj == "Player")
	{
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,1,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,1,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,1,"Unable to deploy - Item in the way");
	
	return 0;
}

//======================================= Check For Objects In a Deployables way.
function CheckForObjects(%pos, %l, %w, %h)
{
	%Set = newObject("cfoset",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	if (%l && %w && %h)
	{
		containerBoxFillSet(%Set, %Mask, %Pos, %l, %w, %h,0);
	}
	else
	{
		containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);	
	}

	%num = Group::objectCount(%Set);

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (%obj != "-1")
		{
			if (getObjectType(%obj) == "Player")
			{
			}
			else
			{
				if(%set)deleteobject(%set);
				return False;
			}
		}
	}
	if(%set)deleteobject(%set);
	return True;
}

function VehicleCheck(%client, %pos)
{
  	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$VehicleObjectType,%pos,9,9,10,0);
	%n = Group::objectCount(%set);	
		
	if(!%n)
	{
		if(%set)deleteobject(%set);
		return 1;
	}

	if(%n > 0)
		Client::sendMessage(%client,1,"Unable to deploy - Vehicle in the way");
	
	return 0;
}

//===========================================
function CountObjects(%set,%name,%num) 
{
	%count = 0;

	if (%name)
	{
		for(%i=0;%i<%num;%i++)
		{
			%obj=Group::getObject(%set,%i);
			if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
				%count++;
		}
	}
	else if (!%name)
	{
		for(%i=0;%i<%num;%i++)
		{
			%obj=Group::getObject(%set,%i);
			%object = getObjectType(%obj);
			%shape = GameBase::getDataName(%obj).shapeFile;
			if(%object == "Turret" || %shape == "flag")
				%count++;
		}
	}
	return %count;

}
//===========================================
function ixApplyKickback(%player, %strength, %lift) 
{
	if((!%lift) && (%lift != 0))
		%lift = 0;

	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (ixSin(%rad));
	%y = ixCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%dir = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}

function ixDotProd(%vec, %scalar) 
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function ixSin(%theta) 
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta) 
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

//---------------------------------------------------------------------------------
// Deployable Box
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     	//Number of remote turrets allowed in the area
$TurretBoxMaxLength = 55;    	//Define Max Length of the area
$TurretBoxMaxWidth =  55;    	//Define Max Width of the area
$TurretBoxMaxHeight = 55;    	//Define Max Height of the area

$TurretBoxMinLength = 25;	//Define Min Length from another turret
$TurretBoxMinWidth =  25;	//Define Min Width from another turret
$TurretBoxMinHeight = 15;    	//Define Min Height from another turret

//=============================================================================================== Deployable Functions
// %player  = Player Id doing the deploy
// %item    = Item being deployed
// %type    = Type of item - Turret, StaticShape, Beacon - etc
// %name    = Name of item - Ion Turret
// %angle   = Check angel (to mount on walls, etc.) (True/False/Player) Checks angel - Does Not Check - Uses Players Rotation Reguardless
// %freq    = Check Frequency (True/False) = Too Many Other Turrets
// %prox    = Check Proximity (True/False) = Too Many Of SAME Type Of Item
// %noinside= Checks to see if deployment is IN a building. 0 = No check - >0 is number of meters up to check.
// %area    = Check Area (for objects in the way) (True/False)
// %surface = Check Surface Type  (True/False)
// %range   = Max deploy distance from player (number best between 3 and 5) meters from player.
// %limit   = Check limit (True/False)
// %flag    = Give Flag Defence Bonus 0 = None and higher for score ammount.
// %kill    = Count for kills (for turrets)
// %deploy  = The item to be deployed (actualy item data name)
// %count   = What item to count

function deployable(%player,%item,%type,%name,%angle,%freq,%prox,%noinside,%area,%surface,%range,%limit,%flag, %kill, %deploy, %count)
{
	if($builder == "true")
	{
		%angle   = false;
		%freq    = False;
		%prox    = False;
		%noinside= 0;
		%area    = false;
		%surface = false;
		%range   = 1000;
		%limit   = false;
		%flag    = false;
		%kill    = false;
		if(%type == "Turret" || %type == "Sensor")
			return;
	}

	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);
	%playerpos = GameBase::getPosition(%player);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);

	if($TeamItemCount[%playerteam @ %count] < $TeamItemMax[%count])
	{
		if (GameBase::getLOSInfo(%player,%range))
		{
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);
			%pos = $los::position;

		if(%type == "StaticShape")
		{
			if(!VehicleCheck(%client, %pos))
				return 0;
		}

			if (%surface)
			{
				if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform" || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "LargeEmplacementPlatform")
				{}
				else
				{
					Client::sendMessage(%client,1,"Can only deploy on terrain or buildings...");
					return;
				}
			}

			if (%prox)
			{
				%set = newObject("proxset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,%pos,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,%deploy,%num);
				if(%set)deleteobject(%set);
				if($MaxNumTurretsInBox > %num){}
				else
				{
					Client::sendMessage(%client,1,"Frequency Overload - Too close to other " @ %deploy @ "s.");
					return;
				}
				%set = newObject("minimumset",SimSet);
				%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, %pos, 2.5,2.5,2.5, 0);
				%num = CountObjects(%set,"",%num);
				if(%set)deleteobject(%set);
				if(%num)
				{
					Client::sendMessage(%client,1,"Frequency Overload - Too close to other remote turrets");
					return;
				}
			}

			if (%noinside)
			{
				%padd = "0 0 10";%poss = Vector::add(%pos, %padd);
				for (%b=1; %b < %noinside; %b++)
				{
					%padd = "0 0 " @ %b;
					%poss = Vector::add(%pos, %padd);
					if(!GameBase::testPosition(%player, %poss))
						%nope = 1;
				}
				if (%nope == 1)
				{
					Client::sendMessage(%client,0,"You can not deploy " @ %name @ ", space to enclosed.");
					return; 
				}
			}
			if (%freq)
			{
				%set = newObject("freqset",SimSet);%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, %pos, $TurretBoxMaxLength/2,$TurretBoxMaxWidth/2,$TurretBoxMaxHeight/2, 0);
				%num = CountObjects(%set,"",%num);
				if(%set)deleteobject(%set);
				if(%num > 0)
				{
					Client::sendMessage(%client,1,"Other objects in the way.");
					return;
				}				
			}

			if (%angle == "True")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					if (Vector::dot($los::normal,"0 0 1") > 0.6)
						%rot = "0 0 " @ %zRot;
					else if(Vector::dot($los::normal,"0 0 -1") > 0.6)
						%rot = "3.14159 0 " @ %zRot;
					else
						%rot = Vector::getRotation($los::normal);
				}
				else
				{
					Client::sendMessage(%client,1,"Can only deploy on flat surfaces");
					return 0;
				}
			}
			else if (%angle == "Player")
				%rot = GameBase::getRotation(%player);
			else if(%angle == "Flat")
				%rot = "-1.54564 0.02591 -3.09105";
			else if (!%angle || %angle == "False")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
					%rot = "0 0 " @ %zRot;
				else if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					%rot = "3.14159 0 " @ %zRot;
				else
					%rot = Vector::getRotation($los::normal);
			}

			if (%area)
			{
				if(!checkDeployArea(%client,%pos))
					return 0;
			}

			if(%type == "Turret" && $noOTurrets && !(%name == "Camera" || %name == "SatchelPack"))
			{
				if(%playerteam == 1)
					%nmeteam = 0;
				else
					%nmeteam = 1;
				%flagpos[0]	= ($teamFlag[0]).originalPosition;
				%flagpos[1] = ($teamFlag[1]).originalPosition;
				%flagrange = Vector::getDistance(%flagpos[0], %flagpos[1]);
				if(%flagrange < 500)
					%otrange = 0.45 * %flagrange;
				else
					%otrange = 200;
				%plRange = Vector::getDistance(%playerpos, %flagpos[%nmeteam]);
				if(%plRange < %otrange)
				{
					Client::sendMessage(%client,1,"No Offence Turreting!");
					return;
				}
				echo(%name);
				echo(%datab);
			}

			%turret = newObject(%name,%type, %deploy,true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,%playerteam);
			GameBase::setPosition(%turret,%pos);
			GameBase::setRotation(%turret,%rot);
			Client::sendMessage(%client,0,"" @ %name @ " deployed");
			GameBase::startFadeIn(%turret);
			playSound(SoundPickupBackpack,%pos);
			if(!$builder)
				$TeamItemCount[%playerteam @ "" @ %count @ ""]++;
			else
			{
				schedule("Player::setItemCount("@ %player @", "@ %item @", 1);", 0.1);
				schedule("Player::mountItem("@ %player @", "@ %item @", $BackPackSlot);", 0.2);
			}
			//echo("MSG: ",%client," deployed a " @ %name);

			if (%type == "Turret")
				Gamebase::setMapName(%turret, %name @ " # " @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			else
				Gamebase::setMapName(%turret, %name);

			if (%flagdist < %flag && %flag != 0)
			{
				%client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
				Game::refreshClientScore(%client);
			}

			if ($Shifter::TurretKill && %kill)
			{
				Client::setOwnedObject(%client, %turret);
				Client::setOwnedObject(%client, %player);
			}

			deploy::record(%turret, %count, %playerteam, %pos, %rot);
			return %turret;
		}
		else 
			Client::sendMessage(%client,1,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "'s.");
	return false;
}

//================================================================================================ Deploy Shape
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,7)) {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					//if(checkDeployArea(%client,$los::position)) 
					//{
						%sensor = newObject("","Sensor",%shape,true);
 	        	  	 		addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					//}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}
//================================================================================================= Check Item Max
function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) )
		{
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	

//============================================================================== Return All Items To Zero After Mission
function recountitem(%itemname)
{
	if ($debug) echo ("Reiniting - " @ %itemname @ "");
	for(%i = -1; %i < 5 ; %i++)
		$TeamItemCount[%i @ %itemname] = 0;
}
//==============================================================
function Mission::reinitData()
{
	recountitem("AccelPPack");
	recountitem("AirAmmoPad");
	recountitem("AirBase");
	recountitem("AOE");
	recountitem("ArbitorBeaconPack");
	recountitem("BarragePack");
	recountitem("Beacon");
	recountitem("BlastFloorPack");
	recountitem("BlastWallPack");
	recountitem("BooM");
	recountitem("CameraPack");
	recountitem("CoolLauncher");
	recountitem("DeployableAmmoPack");
	recountitem("DeployableComPack");
	recountitem("DeployableElf");
	recountitem("DeployableInvPack");
	recountitem("DeployableSensorJammerPack");
	recountitem("DeployableTeleport");
	recountitem("EMPBeaconPack");
	recountitem("EmplacementPack");
	recountitem("EmpM");
	recountitem("EngBeacons");
	recountitem("FlamerTurretPack");
	recountitem("ForceFieldPack");
	recountitem("GasM");
	recountitem("HAPCVehicle");
	recountitem("hologram");
	recountitem("JammerBeaconPack");
	recountitem("JetVehicle");
	recountitem("LAPCVehicle");
	recountitem("LargeForceFieldPack");
	recountitem("LargeShockForceFieldPack");
	recountitem("LaserPack");
	recountitem("LaunchPack");
	recountitem("MechPack");
	recountitem("MFGLAmmo");
	recountitem("mineammo");
	recountitem("MotionSensorPack");
	recountitem("NapM");
	recountitem("PhoenixM");
	recountitem("PlantPack");
	recountitem("PlasmaTurretPack");
	recountitem("PlatformPack");
	recountitem("PowerGeneratorPack");
	recountitem("proxLaserT");
	recountitem("PulseSensorPack");
	recountitem("RocketPack");
	recountitem("SatchelPack");
	recountitem("ScoutVehicle");
	recountitem("ShieldBeaconPack");
	recountitem("ShockFloorPack");
	recountitem("ShockPack");
	recountitem("SpyPod");
	recountitem("SuicidePack");
	recountitem("TargetPack");
	recountitem("TeleportPack");
	recountitem("TeleBeacons");
	recountitem("TreePack");
	recountitem("TurretPack");
	recountitem("WraithVehicle");

	for(%i = 0; %i < 8; %i++) //====== For Guided Missiles
	{
		$TeamItemCountAOE[%i] = 0;
	}

	for(%ClientId = Client::getFirst(); %ClientId != -1; %ClientId = Client::getNext(%ClientId))
	{
		%ClientId.boosted = 0;
		%ClientId.boostercool = 0;
		%ClientId.boostpop = 0;
		%ClientId.plasfired = 0;
		%ClientId.lasfired = 0;
		%clientID.BadWordsSpoken = 0;
		%clientID.scoreKills = 0;
		%clientID.scoreDeaths = 0;
		%clientID.FlagCaps = 0;		
		%clientID.ratio = 0;
		%clientID.score = 0;
		%clientID.ismuted = False;
		%clientID.telepoint = False;
		%clientID.heatup = s0;
		%clientID.heatlock = 0;
		%clientID.plasmacharge = 0;
		%clientID.charging = 0;
		%clientID.lascharge = 0;
		%clientID.boosted = 0;
		%clientID.stimTime = 0;
		%clientID.empTime = 0;
		%clientID.poisonTime = 0;
		%clientID.blindTime = 0;
		%clientID.burnTime = 0;
		%clientID.shieldTime = 0;
		%clientID.cloakTime = 0;
		%clientID.ovd = 0;
	}

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 

	//======================= Kill All Mission Varialbles (Global) That are not needed...
}

function telebeacon(%clientId)
{
	%armor = Player::getArmor(%clientId);
	
	if (%armor == "aarmor" || %armor == "afemale")
	{
		%obj = newObject("","Mine","Telebeacon");
	 	addToSet("MissionCleanup", %obj);
	 	%obj.deployer = %clientId;
	 	%clientId.telebeacon = %obj;
		GameBase::throw(%obj,%clientId,15 * %clientId.throwStrength,false);
		%clientId.throwTime = getSimTime() + 0.5;
		GameBase::setTeam (%obj,GameBase::getTeam (%clientId));
		
		$TeamItemCount[GameBase::getTeam(%clientId) @ "TeleBeacons"]++;
	}
}

//============================================================= Scout Stim
function ScoutStim(%clientId, %player, %item)
{
	%armor = Player::getArmor(%player);

	if (%armor == "sfemale" || %armor == "sarmor" || %armor == "stimarmor" || %armor == "stimfemale")
	{}
	else
	{
		GameBase::applyDamage(%player, $EnergyDamageType,3,1.0,1.0,1.0,%player);
		remoteKill(%clientId);
		%clientId.stimTime = 0;
		%clientId.ovd = 0;
		messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
		return;
	}

	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	
	if (%clientId.stimTime > 0)
	{
		Client::sendMessage(%clientId,0,"Already Stimmed!");
		//%clientId.stimTime = %clientId.stimTime + 2;
	}
	else
	{
		if (%armor == "sarmor")
			Player::setArmor(%player,stimarmor);
		else if (%armor == "sfemale")
			Player::setArmor(%player,stimfemale);
		//if(Player::getMountedItem(%player,$WeaponSlot) == laserRifle) GameBase::setEnergy(%player, 20);
		Player::decItemCount(%player, %item);
		Client::sendMessage(%clientId,0,"You used a Stim Pack!");
		%clientId.stimTime = 10;
		CheckStim(%clientId, %player);		
	}
}

function OverDoseStim (%clientId, %player)
{
		if  (Player::isDead(%player))
			return;
		
		Client::sendMessage(%clientId,0,"You took a little too much.");
		messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
		%clientId.stimTime=0;
		GameBase::applyDamage(%player, $EnergyDamageType, 3, 1.0,1.0, 1.0, %player);
		remoteKill(%clientId);
}

function CheckStim(%clientId, %player)
{
	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	if($debug) echo ("S- " @ %ClientId.ovd @ "");
	if  (Player::isDead(%player))
		return;

	if(%clientId.stimTime > 0)
	{
		Player::trigger(%client,$BackpackSlot,false);

		%clientId.stimTime -= 2; 
		
		%drrate = GameBase::getDamageLevel(%player) - 0.035; //==== Damage Rate When Stimmed
		%clientId.damagelevel = %drrate;
		GameBase::setDamageLevel(%player,%drrate);
		
		if ($Debug) echo("DR " @ %drrate @ "");
		if ($Debug) echo("ID " @ %clientId @ "");
		if ($Debug) echo("PL " @ %player @ "");
		
		%clientId.ovd = %clientId.ovd + floor(getRandom() * 10);
	        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Increased By " @ %clientId.ovd @ "%.", 2);
		%rnd = floor(getRandom() * 100);

		if (%rnd > (150 - %clientId.ovd))
		{
			%clientId.ovd = 0;
			OverDoseStim(%clientId, %player);
			Player::setDamageFlash(%player,0.95); 
			return;
		}
		
		
		if  (!Player::isDead(%player)) 
		{  
			Player::setDamageFlash(%player,0.35);  
			GameBase::setDamageLevel(%player, %drrate);
			
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
				%clientId.scoreDeaths++;
      				%clientId.score--;
				Game::refreshClientScore(%clientId);
				%clientId.stimTime = 0;
				return;
			}

		}
		else
		{
			%clientId.stimTime = 0;
		}
		schedule("CheckStim(" @ %clientId @ ", " @ %player @ ");",2,%player);
   	}
	else
	{
		Client::sendMessage(%clientId,0,"Stim Effect Wears Off.");
		%armor = Player::getArmor(%player);
		if(!%clientId.damagelevel) %clientId.damagelevel = 50;
		
		if (%armor == "stimarmor")
		{
			Player::setArmor(%player,sarmor);
			GameBase::setDamageLevel(%player,%clientId.damagelevel);
		}
		else if (%armor == "stimfemale")
		{
			Player::setArmor(%player,sfemale);
			GameBase::setDamageLevel(%player,%clientId.damagelevel);
		}
	}					
}

//===================================================================================================== Start Shielding

function Renegades_startShield(%clientId, %player)
{
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0);
	%armor = Player::getArmor(%player);

	if (%armor == "jarmor")
		%player.shieldStrength = 0.017;
	else
		%player.shieldStrength = 0.009;

	if(%clientId.shieldTime == 0)
	{
		%clientId.shieldTime = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
		%clientId.shieldTime = 20;
}


function checkPlayerShield(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if(%clientId.shieldTime > 0)
	{
		%clientId.shieldTime -= 2;  

		if  ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale" || %armor == "jarmor"))
		{
			if  (Player::isDead(%player))
			{
			}
		}
		else
		{
			%clientId.shieldTime = 0;
		}
		

		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);	
	}			

		
}

//=================================================================================================== Start Cloaking

function Renegades_startCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,0,"Cloaking On");
	GameBase::playSound(%player,ForceFieldOpen,0);
	//GameBase::startFadeout(%player);
	%player.cloaked = 1;
	%rate = Player::getSensorSupression(%player);
	if(%rate < 0)
		%rate = 0;
	%rate += 3;
	Player::setSensorSupression(%player,%rate);
	
	if(%clientId.cloakTime == 0)
	{
		%clientId.cloakTime = 20;
		cloaker(%player);
		checkPlayerCloak(%clientId, %player);
	}
	else
		%clientId.cloakTime = 20;
}

function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if(%clientId.cloakTime > 0)
	{
		%clientId.cloakTime -= 2;  
		
		if  ((!Player::isDead(%player)) &&  (%armor == "aarmor" || %armor == "afemale"))
		{
		
		}
		else
		{
			%clientId.cloakTime = 0;
		}
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		GameBase::playSound(%player,ForceFieldOpen,0);
		Client::sendMessage(%clientId,0,"Cloaking Off");
		//GameBase::startFadeIn(%player);
		%player.cloaked = 0;
		Player::setSensorSupression(%player,0);
	}
}

//============================================================================================ Eng Missile Lock
function EngMissileLock(%clientId, %player, %item)
{
	return;
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
		%set=newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
		deleteobject(%set);
		if(!%num)
		{
			%team = GameBase::getTeam(%player);
			
			%teleset = nameToID("MissionCleanup/MJammer");
			
			if(%teleset == -1)
			{
				newObject("MJammer",SimSet);
				addToSet("MissionCleanup","MJammer");
				%teleset = nameToID("MissionCleanup/MJammer");				
			}
			
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
			if (Vector::dot($los::normal,"0 0 1") > 0.6)
			{
				%rot = "0 0 " @ %zRot;
			}
			else
			{
				if (Vector::dot($los::normal,"0 0 -1") > 0.6)
				{
					%rot = "3.14159 0 " @ %zRot;
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}

			%beacon = newObject("MJammer Jammer", "StaticShape", "BeaconTwo", true);
			addToSet("MissionCleanup/MJammer", %beacon);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%player));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"Missile Jammer");
			Client::sendMessage(%client,0,"MJammer Disruptor deployed");
			playSound(SoundPickupBackpack,$los::position);
			return true;
		}
		else
			Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}

function CheckMissileJammer(%player)
{
	%teleset = nameToID("MissionCleanup/MJammer");
	%pteam = GameBase::getTeam(%player);

	if ($debug) echo ("checking jammer is set "  @ %teleset);
	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		%oteam = GameBase::getTeam(%o);
		%ppos = GameBase::getPosition(%player);
		%opos = GameBase::getPosition(%o);

		if ($Debug) echo ("MissileJammer = ", %o);
		if ($debug) echo ("OTeam " @ %oteam);
		if ($debug) echo ("PPos  " @ %ppos);
		if ($debug) echo ("Opos  " @ %opos);
		if ($debug) echo ("PTeam " @ %pteam);
		
		%dist = Vector::getDistance(%ppos,%opos);  	//== Player To Jammer Distance		
		if ($debug) echo ("Distance " @ %dist);
		
		if (%dist < 125 && %pteam != %oteam)
		{
			if ($Debug) echo ("Jammed");
			%data = GameBase::getDataName(%o);
			if (GameBase::setDamageLevel(%o, %data.maxDamage))
				if ($debug) echo ("BOOM");
			return true;
		}
	}
	return false;
}

//==================================================================================================== Engineer Beacon
function EngBeacon(%clientId, %player, %bec)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,5))
	{
		%team = GameBase::getTeam(%player);
		%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
		addToSet("MissionCleanup", %beacon);
		GameBase::setTeam(%beacon,GameBase::getTeam(%player));
		GameBase::setRotation(%beacon,%rot);
		GameBase::setPosition(%beacon,$los::position);
		Gamebase::setMapName(%beacon,"Target Beacon");
		Beacon::onEnabled(%beacon);
		Client::sendMessage(%client,0,"Beacon deployed");
		playSound(SoundPickupBackpack,$los::position);
		return true;
	}
	else
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}


//==================================================================================================== Engineer Camera

function EngCamera(%client, %player, %bec)
{
	%item = "CameraPack";
	if (GameBase::getLOSInfo(%player,6))
	{
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot,2);
		if (Vector::dot($los::normal,"0 0 1") > 0.6)
		{
			%rot = "0 0 " @ %zRot;
		}
		else
		{
			if (Vector::dot($los::normal,"0 0 -1") > 0.6)
				%rot = "3.14159 0 " @ %zRot;
			else
				%rot = Vector::getRotation($los::normal);
		}
			%camera = newObject("Camera","Turret",CameraTurret,true);
			addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Camera deployed");
			playSound(SoundPickupBackpack,$los::position);
			if($debug) echo("MSG: ",%client," deployed a Camera");
			Player::decItemCount(%player,%bec);
			//GameBase::startFadeOut(%camera);
			return true;
	}
	else 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");		
	}
	return false;
}


function getflagtoplayer(%playerId, %dist)
{
	%playerteam = GameBase::getTeam(%playerId);
	%playerpos = GameBase::getPosition(%playerId);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	
	%flagdist = Vector::getDistance(%playerpos,%homepos);  	//== Player To Flag Distance		
	if (%flagdist < %dist)
	{
		return %flagdist;
		if ($debug) echo ("Player " @ %player @ " Is With In " @ %dist @ " Of Thier Own Flag . Dist = " @ %flagdist);
	}

}

function itemFuncs::AmmoBoom(%playerId)
{
	%clientId = player::getclient(%playerId);
	%chance = 0;
	%max = getNumItems();
	%armor = Player::getArmor(%playerId);
	%maxcount = 0;
	%k = 0;
	%boom = "BOOM";

	if (%armor == "larmor") 	  {%kval = 200;}
	else if (%armor == "lfemale")	  {%kval = 200;}
	else if (%armor == "marmor")	  {%kval = 800;}
	else if (%armor == "mfemale")	  {%kval = 800;}
	else if (%armor == "earmor") 	  {%kval = 700;}
	else if (%armor == "efemale")	  {%kval = 700;}
	else if (%armor == "spyarmor")    {%kval = 200;}
	else if (%armor == "spyfemale")   {%kval = 200;}
	else if (%armor == "sarmor")	  {%kval = 200;}
	else if (%armor == "sfemale")	  {%kval = 200;}
	else if (%armor == "stimarmor")	  {%kval = 200;}
	else if (%armor == "stimfemale")  {%kval = 200;}
	else if (%armor == "barmor") 	  {%kval = 1100;}
	else if (%armor == "bfemale")	  {%kval = 1100;}
	else if (%armor == "darmor") 	  {%kval = 1000;}
	else if (%armor == "harmor")	  {%kval = 1000;}
	else if (%armor == "aarmor")	  {%kval = 200;}
	else if (%armor == "afemale")	  {%kval = 200;}
	else if (%armor == "parmor")      {%kval = 0;}
	else if (%armor == "jarmor")	  {%kval = 1000;}
	
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%count = Player::getItemCount(%playerId,%i);
		%itemname = getItemData(%i);
		%rnd = (floor (getRandom() * 300)+1);

		if (%itemname == "Grenade") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;}}		
		else if (%itemname == "mineammo") {%mod = (5*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;%k++;}}
		else if (%itemname == "RocketAmmo") {%mod = (4*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "StingerMissile " @ %i;%k++;}}
		else if (%itemname == "BulletAmmo") {%mod = (0.1*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "ChaingunBullet1 " @ %i;%k++;}}
		else if (%itemname == "VulcanAmmo") {%mod = (0.15*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "VulcanBullet " @ %i;%k++;}}
		else if (%itemname == "GrenadeAmmo") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;%k++;}}
		else if (%itemname == "MortarAmmo") { %mod = (12*%count); %chance = %chance + %mod; if (%rnd - %mod < 0) { %boom[%k] = "MortarShell1 " @ %i; %k++; } }
		else if (%itemname == "MfglAmmo") {%mod = (75*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "FgcShell " @ %i;%k++;}}
		else if (%itemname == "AutoRocketAmmo") {%mod = (10*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "StingerMissile " @ %i;%k++;}}
	}

	%rnd = (floor (getRandom() * %kval));
	%dif = (%rnd - %chance);
	%pos = (gamebase::getposition(%playerId));
	
	if (%dif < 0 && getflagtoplayer(%playerId) > 150)
	{
		for (%k = 0; %boom[%k] != ""; %k++)
		{
			%blammo = %boom[%k];
			
			%cnt = getWord(%blammo, 1);
			
			if (getItemData(%cnt) == "MfglAmmo")
				%cnt = Player::getItemCount(%playerId,%cnt) + 1;
			else
				%cnt = floor(Player::getItemCount(%playerId,%cnt) / 3);
			
			%cnt = (floor(getRandom() * %cnt));
			
			
			%blammo = getword(%blammo, 0);
			for (%j=0; %j < %cnt; %j++)
			{
				%dir = (getRandom() @ " " @ getRandom() @ " " @ "-0.65");	
				Projectile::spawnProjectile(%blammo,(%dir @ " " @ %dir @ " -0.1 -0.7 -0.1 " @ %pos),%playerId,"0 0 0");
			}
		}
	}
}


function deploy::init()
{
	exec("dtrack.cs");
	%check = $dlist;
	for(%n = 0; getword(%check, %n) != -1; %n++) 	
	{
		%num = getword(%check, %n);
		$dtemp[%n] = $deploy[%num];
		$dlist = "";
	}
	echo("went n times" @ %n);
	for(%i = 0; %i < %n; %i++) 
	{
		//%num = getword(%check, %i);
		%msg = $dtemp[%i];
		if(%msg != "")
		{
			%pack = getword(%msg, 0);
			%item = $count[%pack];
			%name = %item.description;
			%class = %item.classname;
			echo("%class:" @ %class);
			%type = "StaticShape";
			if(%class == "Turret")
				%type = %class;
			if(%class == "DeployableSensor")
				%type = "Sensor";
			%team = getword(%msg, 1);
			%pos = getword(%msg, 2) @" "@ getword(%msg, 3) @" "@ getword(%msg, 4); 
			%rot = getword(%msg, 5) @" "@ getword(%msg, 6) @" "@ getword(%msg, 7);

			if(%item == "airbase")
				airbase::specialdeploy(%team, %pos, %rot);
			else if(%item == "EmplacementPack")
				EmplacementPack::specialdeploy(%team, %pos, %rot);
			else if(%item == "TeleportPack")
				TeleportPack::specialdeploy(%team, %pos);
			else
			{
				%turret = newObject(%name,%type,%item,true);
				addToSet("MissionCleanup", %turret);
				GameBase::setTeam(%turret,%team);
				GameBase::setPosition(%turret,%pos);
				GameBase::setRotation(%turret,%rot);
				$TeamItemCount[%team @ "" @ %pack @ ""]++;
				deploy::record(%turret, %pack, %team, %pos, %rot);
			}
		}
	}
	export("$dlist", "config\\dtrack.cs", true);
}

function deploy::record(%this, %pack, %team, %pos, %rot)
{
	if($server::tourneymode && !$ceasefire)
	{
		$deploy[%this] = %pack @" "@ %team @" "@ %pos @" "@ %rot;
		export("$deploy"@ %this @"", "config\\dtrack.cs", true);
		deleteVariables("$deploy"@ %this @"");
		if(string::findsubstr($dlist, %this) == -1)
			$dlist = $dlist @ " " @ %this;
	}
}

$countArbitorBeaconPack = "ArbitorBeacon";
$countBarragePack = "BarrageTurret";
$countBlastFloorPack = "BlastFloor";
$countBlastWallPack = "BlastWall";
$countCameraPack = "CameraTurret";
$countDeployableAmmoPack = "DeployableAmmoStation";
$countDeployableComPack = "DeployableComStation";
$countDeployableElf = "DeployableElfTurret";
$countDeployableInvPack = "DeployableInvStation";
$countDeployableSensorJammerPack = "DeployableSensorJammer";
$countEMPBeaconPack = "EMPBeacon";
$countForceFieldPack = "DeployableForceField";
$countJammerBeaconPack = "JammerBeacon";
$countLargeForceFieldPack = "LargeForceField";
$countLargeShockForceFieldPack = "LargeShockForceField";
$countLaserPack = "DeployableLaser";
$countMotionSensorPack = "DeployableMotionSensor";
$countPlasmaTurretPack = "DeployablePlasma";
$countPlatformPack = "DeployablePlatform";
$countPowerGeneratorPack = "PortGenerator";
$countPulseSensorPack = "DeployablePulseSensor";
$countRocketPack = "DeployableRocket";
$countShieldBeaconPack = "ShieldBeacon";
$countShockFloorPack = "ShockFloor";
$countShockPack = "DeployableShock";
$countTargetPack = "DeployableMortar";
$countTurretPack = "DeployableTurret";

//special deploy
$countTreePack = "DeployableTree";
$countPlantPack = "DeployableCactus1";
$countTeleportPack = "TeleportPack";
$countAccelPadPack = "AccelPadPack";
$countDeployableLaunch = "DeployableLaunch";
$countairbase = "airbase";
$countEmplacementPack = "EmplacementPack";