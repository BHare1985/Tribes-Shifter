exec("comchat.cs");
exec("shban.cs");

if($Shifter::noSwearing)
	exec("SHBadwordlist.cs");

exec("remote.cs");

exec("spawn.cs");

exec("game_dmsg.cs");

exec("damage.cs");

if (getNumTeams() == 2)
{	
	dbecho ("There are only 2 team init Fair Teams");
	exec("fairteams.cs");
}

if ($Shifter::ObjScore == "")
	$Shifter::ObjScore = "True";
if ($Shifter::PlrScore = "")
	$Shifter::PlrScore = "True";

if ($Shifter::ObjScore == "False" && $Shifter::PlrScore == "False")
{
	$ScoreOn = "False";
}


//================================================== Globals

if ($Shifter::TeamDamage != false)
	$Server::TeamDamageScale = 1;

$MODInfo = $Server::MODInfo;

$fa_armor = "";
$fa_pack = "";
$pskin = $Shifter::PersonalSkin;
$SensorNetworkEnabled = true;
$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$modmgtModName = "SHAntiTK";
$modmgtModVers = "1.30";
$SHBanListMarker = "true";

if ($SpawnFav != "False") $SpawnFav = True;
if (!$SHAntiTeamKillProximity) $SHAntiTeamKillProximity = 50;

if($SHAntiTeamKillWarnKills == "")
	$SHAntiTeamKillWarnKills = 1;
if($SHAntiTeamKillBanTime == "")
	$SHAntiTeamKillBanTime = 600;
if($SHAntiTeamKillMaxKills == "")
	$SHAntiTeamKillMaxKills = 2;
if($SHAntiTeamKillProximity == "")
    $SHAntiTeamKillProximity = 50;


//================================================== End Globals

$DefaultTeamEnergy = "Infinite";

$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 1;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 7500;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     	//Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    	//Define Max Length of the area
$TurretBoxMaxWidth =  50;    	//Define Max Width of the area
$TurretBoxMaxHeight = 10;    	//Define Max Height of the area

$TurretBoxMinLength = 10;	//Define Min Length from another turret
$TurretBoxMinWidth =  10;	//Define Min Width from another turret
$TurretBoxMinHeight = 10;    	//Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType   = 1 << 1;
$SimInteriorObjectType  = 1 << 2;
$SimPlayerObjectType    = 1 << 7;

$MineObjectType		= 1 << 26;	
$MoveableObjectType	= 1 << 22;
$VehicleObjectType	= 1 << 29;  
$StaticObjectType	= 1 << 23;	   
$ItemObjectType		= 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;
$AutoRespawn = 0;

//===============================================================================================================
function Game::playerSpawned(%pl, %clientId, %armor)
{
	dbecho ("============================ Spawning Player");
	dbecho ("PL - " @ %pl @ "");
	dbecho ("CL - " @ %clientId @ "");
	dbecho ("ST - " @ %clientId.spawntype @ "");
	
	%clientId.JustSpawned = true;
	schedule (%clientId @ ".JustSpawned = False;",1.5);

	if(%clientId.custom)
	{
	       	Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	}
	
	%clientId.spawntime = getsimtime();
	//%power = IsPowerDown(gamebase::getteam(%clientId));
	//echo ("POWER = " @ %power);

	//=================================================================== Custom Spawn Settings
	//== Spawn Notifications Added By Ascain.
	
	//if ($Shifter::PowerCheck != "False" && !%power)
	//{
	//	dbecho ("SPAWN - Power down - standard");
	//	standardSpawnList(%clientId);
	//	schedule ("bottomprint( " @ %clientId @ ", \"<jc><f2>You have spawned in standard armor, YOUR POWER IS DOWN!!!\", 10);" ,3);
	//	
	//	if (Game::playerSetSpawned(%pl, %clientId, %armor))
	//		return true;
	//	return false;
	//}else
	if (%clientId.spawntype == "standard")
	{
		dbecho ("SPAWN - Normal Standard");
		standardSpawnList(%clientId);
		bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10);
		
		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "random")
	{
		dbecho ("SPAWN - Random");
		randomSpawnList(%clientId);
		bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10);
		
		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if (%clientId.spawntype == "favs")
	{
		dbecho ("SPAWN - Favs");
		if (%clientId.favsettings) { bottomprint(%clientId, "<jc><f2>You have spawned with your last bought favorites.", 10);}
		else { bottomprint(%clientId, "<jc><f2>You must select your favorites first before you can be spawned with them.", 10);}
		
		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	else if ($Shifter::SaveOn && %clientId.SavedInfo && %clientId.spawntype == "saved")
	{
		dbecho ("SPAWN - Player Saved");
		savedSpawnList(%clientId);
		%clientId.spawntype = %clientId.spawntypetwo;
		
		if (Game::playerSetSpawned(%pl, %clientId, %armor))
			return true;
		return false;
	}
	dbecho ("SPAWN - Ooops No Spawn!?!");
} 

function Game::playerSetSpawned(%pl, %clientId, %armor)
{
	//======================================================================================== Buy Actual Items
	dbecho ("Buying Inventory");

	%clientId.spawn = 1;
	%max = getNumItems();

	for(%i = 0; (%item = $spawnBuyList[%i, %clientId]) != ""; %i++)
	{
		buyItem(%clientId,%item);
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
		dbecho ("Buying = " @ %item);
	}
	for (%i = 0; %i < 6; %i++)
	{
		buyItem(%clientId,"Beacon");
		buyItem(%clientId,"Grenade");
		buyItem(%clientId,"MineAmmo");
	}

	%clientId.spawn = "";

	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);
		%armor = Player::getArmor(%clientId);

		if (%armor == "jarmor") //================================================== Check Juggernaught   
		{
			Player::mountItem(%clientId, Mortar, $WeaponSlot);
		}
		%clientId.spawnWeapon="";
	}

	if ($Shifter::PublicNotice != "")
	{
		%clientId.spawnnum++;
		if (%clientId.spawnnum > 1)
		{
			dbecho ("*** Server Public Announce");
			bottomprint (%clientId, "<jc>" @ $Shifter::PublicNotice @ "",4);
			%clientId.spawnnum = 0;
		}
		dbecho ("*** Server Public Announce - END");
	}
      	return true;
}


//===============================================================================================================

function Game::playerSpawn(%clientId, %respawn)
{
   	if(!$ghosting)
      		return false;

	dbecho ("ST1" @ %clientId.spawntype @ "");

	if (!$Shifter::SpawnType || $Shifter::SpawnType != "random" || $Shifter::SpawnType != "standard")
	{
		$Shifter::SpawnType = "random";
	}	
	
	if (%clientId.spawntype != "favs" && %clientId.spawntype != "random" && %clientId.spawntype != "standard" && %clientId.spawntype != "saved")
	{
		%clientId.spawntype = $Shifter::SpawnType;
		dbecho ("ST2" @ %clientId.spawntype @ "");
	}

	Client::clearItemShopping(%clientId);
   	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);

  	if(!%respawn) //================================================================================== Server Welcome Message On First Spawn
  	{
		if ($Shifter::WelcomeDelay > 0) bottomprint(%clientId, $Shifter::WelcomeMsg, $Shifter::WelcomeDelay);
   
   		//if ($Shifter::Saveon)
   		//{
   			//LoadCharacter(%clientId);
			//}
   	}
	if(%spawnMarker)
	{
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	 	%clientId.observermode = "";

	   	if(%spawnMarker == -1){%spawnPos = "0 0 300";%spawnRot = "0 0 0";}
	   	else{%spawnPos = GameBase::getPosition(%spawnMarker);%spawnRot = GameBase::getRotation(%spawnMarker);}

	   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
	   		%armor = "larmor";
	   	else
	   		%armor = "lfemale";

	   	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   	dbecho("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   	
	   	if(%pl != -1)
	   	{
	   	   	GameBase::setTeam(%pl, Client::getTeam(%clientId));
	   	   	Client::setOwnedObject(%clientId, %pl);
	   	   	
	   	   	dbecho ("Game::playerSpawned 1");
	   	   	if (!Game::playerSpawned(%pl, %clientId, %armor, %respawn))
	   	   	{
	   	   		dbecho ("Spawn Failed");
	   	   		Client::sendMessage(%clientId,0,"Sorry Respawn Failed - Try again later ");
	   	   		return false;
	   	   	}

	   	   	if($matchStarted)
	   	      		Client::setControlObject(%clientId, %pl);
	   	   	else
	   	   	{
	   	   	   	%clientId.observerMode = "pregame";
	   	   	   	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	   	   	   	Observer::setOrbitObject(%clientId, %pl, 5, 5, 5);
	   	   	}
	   	}
      		return true;
	}
	else
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      		return false;
	}
}

function Time::getMinutes(%simTime){return floor(%simTime / 60);}
function Time::getSeconds(%simTime){return %simTime % 60;}

function Game::pickRandomSpawn(%team)
{

	%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
	%count = Group::objectCount(%group);

	if(!%count)
		return -1;

	%spawnIdx = floor(getRandom() * (%count - 0.1));
	%value = %count;

	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("spawnset",SimSet);
		%obj = Group::getObject(%group, %i);

		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
		{
			if(%set)deleteobject(%set);
			return %obj;		
		}

		if(%i == %count - 1)
		{
			%i = -1;
			%value = %spawnIdx;
		}
		if(%set)deleteobject(%set);
	}
	return false;
}

function Game::pickStartSpawn(%team)
{
	%group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
	%count = Group::objectCount(%group);
	if(!%count)
		return -1;

	%spawnIdx = $lastTeamSpawn[%team] + 1;

	if(%spawnIdx >= %count)
		%spawnIdx = 0;
	$lastTeamSpawn[%team] = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
	if(%respawn)
		return Game::pickRandomSpawn(%team);
	else
	{
		%spawn = Game::pickStartSpawn(%team);
		if(%spawn == -1)
			return Game::pickRandomSpawn(%team);
		return %spawn;
	}
}

function Game::pickObserverSpawn(%client)
{
	%group = nameToID("MissionGroup\\ObserverDropPoints");
	%count = Group::objectCount(%group);

	if(%group == -1 || !%count)
		%group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
	%count = Group::objectCount(%group);

	if(%group == -1 || !%count)
		%group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");

	%count = Group::objectCount(%group);

	if(%group == -1 || !%count)
		return -1;

	%spawnIdx = %client.lastObserverSpawn + 1;

	if(%spawnIdx >= %count)
		%spawnIdx = 0;

	%client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
	messageAll(0, "Match starts in " @ %time @ " seconds.");
	UpdateClientTimes(%time);
}

function Game::startMatch()																						// game.cs
{
	$matchStarted = true;
	$missionStartTime = getSimTime();
	
	messageAll(0, "Match started.");
	Game::resetScores();	
	if($server::tourneymode && !$ceasefire) initMT();
	echo("\"M\"" @ $missionName @ "\"" @ ($Server::timeLimit * 60) + $missionStartTime - getSimTime() @ "\"");

	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		if($TeamEnergy[%i] != "Infinite")
		schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

	dbecho ("Match Observer");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
		{
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		}
		Game::refreshClientScore(%cl);
	}
	dbecho ("Match Observer Done");

	Game::checkTimeLimit();
}


function Game::pickPlayerSpawn(%clientId, %respawn){return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);}

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
	{
		dbecho ("AutoRespawn 1");
		Game::playerSpawn(%client, "true");
		dbecho ("AutoRespawn 2");
	}
}

function onServerGhostAlwaysDone(){}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);
	if(!%clientID.isadmin) Shifter::Autoadmin(%clientId);
	if(!%clientID.noban) CheckNoBans(%clientId);
	if($builder == "scrim")
	{
		%clientID.observerMode = "observerFly";
		%clientid.notready = "true";
		%clientID.notreadyCount = "";
		GameBase::setTeam(%clientId, -1);
		Shifter::Autoadmin(%clientId);
		SHCheckTransportAddress(%clientid);
		CheckNoBans(%clientId);
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		%camSpawn = Game::pickObserverSpawn(%clientId);
		Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
		GameBase::getRotation(%camSpawn), true, true);
		bottomprint(%clientid, "<F1><jc>::::MIXED SCRIM::::",10);
		return;
	}
   if($Server::TourneyMode && ($Shifter::Tag0 != "" && $Shifter::Tag1 != "") && !$ceasefire)
   {
   	%clName = Client::getName(%clientId);
   	dbecho($Shifter::tag0 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag0 @ %clientId));
   	dbecho($Shifter::tag1 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag1 @ %clientId));
   	if(String::findSubStr(%clName,$Shifter::Tag0) != -1)
		{
			%clientID.observerMode = "pregame";
			%clientid.notready = "true";
			%clientID.notreadyCount = "";
			GameBase::setTeam(%clientId, 0);
		}
		else if(String::findSubStr(%clName,$Shifter::Tag1) != -1)
		{
			%clientID.observerMode = "pregame";
			%clientid.notready = "true";
			%clientID.notreadyCount = "";
			GameBase::setTeam(%clientId, 1);
		}
      else
		{
			%clientID.observerMode = "pregame";
			%clientid.notready = "true";
			%clientID.notreadyCount = "";
			GameBase::setTeam(%clientId, -1);
		}
   }
   else if($Server::TourneyMode && !$ceasefire)
   {
		%clientID.observerMode = "pregame";
		%clientid.notready = "true";
		%clientID.notreadyCount = "";
		if(Client::getteam(%clientID) == -1)
			processMenuInitialPickTeam(%clientID, -1);
		%clientId.justConnected = "";
   }
   else
   {
     	if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
     	{
       	%clientId.observerMode = "observerOrbit";
       	%clientId.guiLock = "";
	 		Observer::jump(%clientId);
         	return;
     	}
     	%numTeams = getNumTeams();
     	%curTeam = Client::getTeam(%clientId);
   	if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
	   		Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%camSpawn = Game::pickObserverSpawn(%clientId);
	Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	GameBase::getRotation(%camSpawn), true, true);

	if(Client::getTeam(%clientId) == -1)
	{
		%clientId.observerMode = "pickingTeam";
		
		if($Server::TourneyMode)// && ($matchStarted || $matchStarting))
		{
			%clientId.observerMode = "observerFly";
			return;
		}
		else if($Server::TourneyMode)
		{
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nYour team will be assigned.\nTeam damage is " @ %td, 0);
		}
	
		if(!$Server::TourneyMode)
		{
		Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%clientId, "0Observe", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}
		%clientId.justConnected = "";
		
	}
	else 
	{
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);

		if(%clientId.justConnected)
		{
			Shifter::Autoadmin(%clientId);
			SHCheckTransportAddress(%clientid);
			CheckNoBans(%clientId);
			LoadCharacter(%clientId);
			//=========================================================== Player - Personal Skin Menu
			if ($Shifter::PersonalSkin)
			{
				Client::buildMenu(%clientId, "Choose Your Skin Setting:", "usecustom");
				Client::addMenuItem(%clientId, "0 Use Personal Skin", 0);
				Client::addMenuItem(%clientId, "1 Use Team Default", 1);
			}

			bottomprint(%clientId, $Server::JoinMOTD, 0);	      
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined")
		{
			centerprint(%clientId, "");
			%clientId.observerMode = "";
			Game::playerSpawn(%clientId, false);
		}   
		else
		{
			Game::playerSpawn(%clientId, false);
		}
	}

	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuuseCustom(%clientId, %skin)
{
	if(%skin == 0){%clientId.custom = True;}
	if(%skin == 1){%clientId.custom = False;}
	if(%team != -2)
	{
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;

		%clientId.teamEnergy = 0;
		Client::setControlObject(%clientId, -1);
		Game::playerSpawn(%clientId, false);
	}
}

function processMenuInitialPickTeam(%clientId, %team)
{
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
   }
   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if(%team != -2)
   {
      GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
   if($Server::TourneyMode && !$CountdownStarted)
   {
      if(%team != -2)
      {
         bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
         %clientId.notready = true;
         %clientId.notreadyCount = "";
      }
      else
      {
         bottomprint(%clientId, "", 0);
         %clientId.notready = "";
         %clientId.notreadyCount = "";
      }
   }
}

function processMenuPickTeam(%clientId, %team, %adminClient) // admin.cs 
{
   if (%adminClient==2048) $AdminName = "the Administrator";
   else $AdminName = Client::getName(%adminClient);

  	checkPlayerCash(%clientId);
   if(%team != -1 && %team == Client::getTeam(%clientId))
      return;

   if(%clientId.observerMode == "justJoined")
   {
      %clientId.observerMode = "";
      centerprint(%clientId, "");
   }

   if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
   {
      if(Observer::enterObserverMode(%clientId))
      {
       //TS
       echo("\"A\"" @ %clientId @ "\"" @ %team @ "\"");
       
         %clientId.notready = "";
         if(%adminClient == "") 
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ $AdminName @ ".");
			Game::resetScores(%clientId);
		   Game::refreshClientScore(%clientId);
      }
      return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ $AdminName @ ".");

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   
   //TS
   echo("\"A\"" @ %clientId @ "\"" @ %team @ "\"");

   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

   	Game::playerSpawn(%clientId, false);
	
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;
   if($Server::TourneyMode && !$CountdownStarted)
   {
      centerprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
}

function Game::ForceTourneyMatchStart()
{
	%playerCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
			%playerCount++;
	}

	if(%playerCount == 0)
		return;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")   
			processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
	}
	Server::Countdown(15);
}

function Game::CheckTourneyMatchStart()
{

	if($CountdownStarted || $matchStarted)
		return;

	// loop through all the clients and see if any are still notready
	%playerCount = 0;
	%notReadyCount = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")
		{
			%notReady[%notReadyCount] = %cl;
			%notReadyCount++;
		}   
		else if(%cl.observerMode == "pregame")
		{
			if(%cl.notready)
			{
				%notReady[%notReadyCount] = %cl;
				%notReadyCount++;
			}
			else
				%playerCount++;
		}
	}
	
	if(%notReadyCount)
	{
		if(%notReadyCount == 1)
			MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
		else if(%notReadyCount < 4)
		{
			for(%i = 0; %i < %notReadyCount - 2; %i++)
				%str = Client::getName(%notReady[%i]) @ ", " @ %str;

			%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
		
			MessageAll(0, %str);
		}
		return;
	}

	if(%playerCount != 0)
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
		Server::Countdown(15);
	}
}

function Game::checkTimeLimit()
{

	$timeLimitReached = false;
	if(!$Server::timeLimit)
	{
		schedule("Game::checkTimeLimit();", 60);
		return;
	}

	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	$matchtrack::timecheck++;
	if($matchtrack::timecheck > 28)
	{
		$matchtrack::time = floor((%curTimeLeft * 0.0166) + 1);
		recordMT();
		echo("MatchTrack Recorded.");
		$matchtrack::timecheck = 0;
	}

	if((%curTimeLeft >= 119 && %curTimeLeft <= 120) && $matchStarted && $Shifter::TwoMinute != "False")
	{
		schedule("messageAll(1,\"2 Minute Warning!~waccess_denied.wav\");", 0.01);
		schedule("messageAll(1,\"2 Minute Warning!~waccess_denied.wav\");",0.5);
		schedule("messageAll(1,\"2 Minute Warning!~waccess_denied.wav\");",1.0);
	}

	if(%curTimeLeft <= 0 && $matchStarted)
	{
		echo("GAME: Timelimit reached.");
		$timeLimitReached = true;
		Server::nextMission();
	}
	else
	{
		schedule("Game::checkTimeLimit();", 2);
		UpdateClientTimes(%curTimeLeft);
	}
}
//======================================================================== Reset Client Scores Back To Zero
function Game::resetScores(%client)
{
	dbecho("*** Resetting Client Scores");
	if(%client == "")
	{
	   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   	{
			dbecho ("*** Begin Scores For " @ %cl);
	
	   		%cl.scoreKills = 0;
   	   		%cl.scoreDeaths = 0;
			%cl.ratio = 0;
      			%cl.score = 0;
			%cl.FlagCaps = 0;			
			if (%cl.TKCount > 0)
				%cl.TKCount = %cl.TKCount;
			else
				%cl.TKCount = 0;
		}
		dbecho ("Reset Scores Finished");
	}
	else
	{
		if ($Shifter::Saveon)
		{
			SaveCharacter(%client);
		}
		else
		{
			dbecho ("*** Resetting Scores For " @ %client);
			if (%client.TKCount > 0)
				%client.TKCount = %cl.TKCount;
			else
				%client.TKCount = 0;

			%client.BadWordsSpoken = 0;
			%client.scoreKills = 0;
			%client.scoreDeaths = 0;
			%client.FlagCaps = 0;		
			%client.ratio = 0;
			%client.score = 0;
			%client.ismuted = False;
			%client.telepoint = False;
			%client.heatup = s0;
			%client.heatlock = 0;
			%client.plasmacharge = 0;
			%client.charging = 0;
			%client.lascharge = 0;
			%client.boosted = 0;
			%client.stimTime = 0;
			%client.empTime = 0;
			%client.poisonTime = 0;
			%client.blindTime = 0;
			%client.burnTime = 0;
			%client.shieldTime = 0;
			%client.cloakTime = 0;
			%client.ovd = 0;
			schedule("%client.NRGTDOff = 0;", 1.0, %client);
		}
	}
}

function remoteSetArmor(%player, %armorType)
{
}

//========================================================================================================== SetUp Players Stats On Connect
function Game::onPlayerConnected(%playerId)
{
	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.TKCount = 0;
	%playerId.FlagCaps = 0;
	%playerId.justConnected = true;
	%playerId.favsettings = "False";
	%playerId.Plastic = 15;
	%playerId.boosted = 0;
	%playerId.telepoint = 0;
	%playerId.hackattempt = 0;
	%playerId.booster = 0;
	%playerId.boostercool = 0;
	%playerId.boostpop = 0;
	%playerId.heatup = s0;
	%playerId.heatlock = 0;
	%playerId.plasmacharge = 0;
	%playerId.charging = 0;
	%playerId.lascharge = 0;
	%playerId.stimTime = 0;
	%playerId.empTime = 0;
	%playerId.poisonTime = 0;
	%playerId.blindTime = 0;
	%playerId.burnTime = 0;
	%playerId.shieldTime = 0;
	%playerId.cloakTime = 0;
	%playerId.ovd = 0;
	%playerId.NRGTDOff = 0;
	%playerId.telepoint = 0;

	for (%i = 0; %i <= 21; %i++)
	{
		%playerId.fav[%i] = "";
		$spawnBuyList[%i, %playerId] = "";	
	}

	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);
}


function Game::assignClientTeam(%clientId)																		// game.cs
{
	if($teamplay)
	{
		%name = Client::getName(%clientId);
		%numTeams = getNumTeams();
		%numPlayers = getNumClients();

		for(%i = 0; %i < %numTeams; %i = %i + 1)
			%numTeamPlayers[%i] = 0;

		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%pl = getClientByIndex(%i);

			if(%pl != %clientId)
			{
				%team = Client::getTeam(%pl);
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
			}
		}

		%leastPlayers = %numTeamPlayers[0];
		%leastTeam = 0;

		for(%i = 1; %i < %numTeams; %i++)
		{
			if((%numTeamPlayers[%i] < %leastPlayers) || (%numTeamPlayers[%i] == %leastPlayers && $teamScore[%i] < $teamScore[%leastTeam]))
			{
					%leastTeam = %i;
					%leastPlayers = %numTeamPlayers;
			}
		}

		GameBase::setTeam(%clientId, %leastTeam);
		//echo("**** Player " @ %clientId @ " set to team " @ gamebase::getteam(%clientId));
		echo("\"A\"" @ %clientId @ "\"" @ %leastTeam @ "\"");
	}
	else
	{
		GameBase::setTeam(%clientId, 0);
		//echo ("Client Team Set To " @ gamebase::getteam(%clientId));
	}	
}

function Game::setRandomTeam()
{
	bottomprintall ("<jc>Randomly Assigning Teams - Occurs Every " @ $Shifter::TeamJuggle @ " Missions.");
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	dbecho ("*********************** BEGINING TEAM ASSIGNMENT");
	
	if (!%numPlayers)
	{
		dbecho ("ADMINMSG **** No Players In Game Not Assigning Teams");
		return;
	}

	echo ("**** Numbers Of Players " @ %numPlayers);
	
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		%player[%i] = %pl;
		gamebase::setteam(%pl, -1);
		dbecho ("**** Clearing Player Teams " @ %pl);
	}

	%assigned = 0;
	
	for(%k = 0; AllOnTeam() || (%assigned < %numplayers); %k++)
	{
		if (%k > 2000)
		{	
			dbecho ("**** Could Not Assign All Players In Given Time - Breaking Loop.");	
			break;
		}
		
		%rnd = floor(getRandom() * (%numPlayers) );
		%playerId = %player[%rnd];
		
		if (gamebase::getteam(%playerId) == -1 && (%playerId.observerMode != "observerOrbit" && %playerId.observerMode != "observerFly"))
		{
			Game::assignClientTeam(%playerId);
			%name = Client::getName(%playerId);
			echo ("**** Player <" @ %playerId @ "> " @ %name @ "  Assigned To Team " @ gamebase::getteam(%playerId));
			echo ("**** Observermode " @ %playerId.observermode);
			%assigned++;
		}
	}
	dbecho ("***********************");
	dbecho ("**** Players Assigned To Teams = " @ %assigned @ " out of " @ %numplayers);
	dbecho ("*********************** DONE WITH TEAM ASSIGNMENT");
}

function AllOnTeam()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if (gamebase::getteam(%pl) == "-1"){return true;}
	}
	echo ("**** All Players Have Been Assigned");
	return false;
}

function Game::clientKilled(%playerId, %killerId)
{
	dbecho ("Game::clientKilled (" @ %playerId @ " - " @ %killerId @ ").");
}

function Client::leaveGame(%clientId)
{}

//========================================================================================================================================
//========================================================================================================================================
//                                   ...Player Kills Or Dies - Anti-TK Stuff - Kill Scoring Etc...
//========================================================================================================================================
//========================================================================================================================================

function Player::onKilled(%this)
{
	dbecho("*** Player Killed ***");
	%this.Station = "";

   	$killedflagcarry = "False";
	%killedflag = "false";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	%cl.heatup = 0;
	%cl.heatlock = 0;
	%cl.plasmacharge = 0;
	%cl.charging = 0;
	%cl.lascharge = 0;
	%cl.boosted = 0;
	%cl.stimTime = 0;
	%cl.empTime = 0;
	%cl.poisonTime = 0;
	%cl.blindTime = 0;
	%cl.burnTime = 0;
	%cl.shieldTime = 0;
	%cl.cloakTime = 0;
	%cl.ovd = 0;
	schedule("%cl.NRGTDOff = 0;", 1.0, %cl);
	//schedule(%cl@".telepoint = 0;", 15);

	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
		
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
		
	Player::setDamageFlash(%this,0.75);
	
	for (%i = 0; %i < 8; %i = %i + 1) 
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type == "flag")
			$killedflagcarry = "True";
		if (%type != -1)
		{
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.6") 
				Player::dropItem(%this,%type);
		}
	}

   	if(%cl != -1)
   	{
		if(%this.vehicle != "")
		{
			if(%this.driver != "")
			{
				%this.driver = "";
        	 		Client::setControlObject(Player::getClient(%this), %this);
        	 		Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
	
		%kdpos = GameBase::getPosition(%this);
		%this.TKDeathPos = %kdpos;

		%cl.lastkillpos = %kdpos;
		$killedarmor = Player::getArmor(%this);

		schedule("GameBase::startFadeOut(" @ %this @ ");", 900, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		schedule("deleteobject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
   	}
}

function Client::onKilled(%playerId, %killerId, %damageType, %vertPos, %quadrant)
{
	%score = 0;
	%playerId.lascharge = "";
	%playerId.charging = "";
	
	if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && (%killerId != playerId))
		echo("\"T\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");
	else
		echo("\"K\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");   

	dbecho ("*** Player " @ %playerId);
	dbecho ("*** Killer " @ %killerId);

	%killedflag = $killedflagcarry;	
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);

	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{
		%playerGender = "his";
	}
	else
	{
		%playerGender = "her";
	}
	
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%victimName = Client::getName(%playerId);

	if(!%killerId || %killerId == "-1") //=== No Killer Listed
	{
		messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		%playerId.scoreDeaths++;
		if ($ScoreOn) bottomprint(%playerId,"You have died " @ %playerId.scoreDeaths @ " time(s).",3);	
		return;
	}
	else if(%killerId == %playerId) //=== Suicide Kill
	{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;

		if (%killedflag)
		{
			%playerId.score = (%playerId.score - $Score::FlagDef);
			if ($ScoreOn) bottomprint(%playerId,"You had the Flag. Your score reduced to " @ %playerId.score @ " Due To Suicide.",3);  
		}
		else
		{
			%playerId.score--;
			if ($ScoreOn) bottomprint(%playerId,"Your score reduced to " @ %playerId.score @ " Due To Suicide <-1 Point>.",3);
		}

		Game::refreshClientScore(%playerId);
		return;
	}
	else
	{
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
		
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
		{
			if(%damageType != $MineDamageType) 
			messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else 
			messageAll(0, strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);

			%killerId.scoreDeaths++;
			%killerId.score--;
			Game::refreshClientScore(%killerId);

			if ($Shifter::TeamKillOn == "True" && !$Server::TourneyMode)
			{
				CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant);
			}
			return;

		}
		else
		{
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),%victimName, %killerGender, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);

			if ($Shifter::PlrScore != "False")
			{
				%score = (Scoring::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant));
			
				%killedpos = $lastkillpos;				//== Killed Pos
				%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
				%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag

				if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $LaserDamageType || %damagetype == $BulletDamageType) )
				{
					if(%quadrant == "middle_front") //- Direct Head Shot
					{
						%msg = "HEAD SHOT";
					}
					else if(%quadrant == "middle_back" || %quadrant == "middle_middle") //- Back Of Head Shit
					{
						%msg = "!! EXTREME HEAD SHOT - BONUS 5 POINTS!!";
						%score += 5;
					}
					else
					{
						%msg = "HEAD SHOT";
					}
				}
			
				if (%playerId.JustSpawned)
				{
					%score = floor (%score / 2);
					if($debug) echo ("*** Player Just Spawned - Points Are Halved");
				}
				if (%killerId.missilekill){%score = floor(%score * 0.25);}
			
			}
			
			
		%distance = floor (%killerId.lastkill);
		%killerId.lastkill = "0";

		if (%distance)
		{
			%msg = "" @ %msg @ " Distance = " @ %distance @ " Meters";
      			//Client::sendMessage(%killerId,0,"Kill @ " @ %distance @ ".");
      			//Client::sendMessage(%playerId,0,"Killed @ " @ %distance @ ".");
		}

			%killerId.scoreKills++;					//=== Killer Number Of Kills
            		%playerId.scoreDeaths++;  				//=== Killed Player Deaths
            		%killerId.score = (%killerId.score + %score);		//=== Killer Score
			
			if (%killedflag)
			{
				if ($ScoreOn) bottomprint(%killerId, "Flag Runner Killed! Score +" @ %score @ " = " @ %killerId.score @ " Total Score");
              				messageAll(0, Client::getName(%killerId) @ " gets a bonus for killing the flag runner!!!");
			}
			else
			{
				if ($ScoreOn) bottomprint(%killerId, "Score +" @ %score @ " = " @ %killerId.score @ " Total Score " @ %msg @ ".");
   			}

   			//====================================== Refresh Scores		 
         
			Game::refreshClientScore(%killerId);
         		Game::refreshClientScore(%playerId);
         		return;
		}
	}
}

function CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant)
{
	if(%damagetype != $MineDamageType && %damagetype != $GravDamageType && %damagetype != $CloakDamageType)
	{
		%ppos = %playerid.TKDeathPos;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($teamplay && (Client::getTeam(%killerId) != Client::getTeam(%cl)))
			{
				if(%cl != %playerId && %cl != %killerId)
				{
					%pppos = GameBase::getPosition(%cl);
					%dist = Vector::getDistance(%ppos,%pppos);
					dbecho("***" @ Client::getName(%cl) @ " was " @ %dist @ " from " @ Client::getName(%playerId) @ " Prox = " @ $SHAntiTeamKillProximity);

					if(%dist < $SHAntiTeamKillProximity)
					{
						dbecho("***Player "@ Client::getName(%playerId) @" was close, kill is accidental.");
						Client::sendMessage(%killerId, 0, "You team killed...");
						return;
					}
				}
			}
		}

	        messageAll(1, "***" @ Client::getName(%killerId) @ " TeamKilled***");

  		$killedflagcarry = "False";		 //== Reset
		%playerId.lastkillpos = -1;		 //== Reset
		$killedarmor = -1;			 //== Reset		   		
	   		
		%score = (Scoring::killpoints(%playerId, %killerId, %vertPos,%quadrant));

		if (%playerId.JustSpawned == "false")
		{
			%killerId.scoreDeaths++;						//=== Killer Number Of Kills
			%killerId.score = (%killerId.score - %score);				//=== Killer Score
			if ($Shifter::Debug) echo ("*** Player Team Killed - Deducting Points");
		}
		else
		{
			%score = floor(%score / 2);
			%killerId.scoreDeaths++;						//=== Killer Number Of Kills
			%killerId.score = (%killerId.score - %score);				//=== Killer Score
			if ($Shifter::Debug) echo ("*** Team Kill - But Killed Player Just Spawned - Possible Accident - Points Deducted Halved");
		}
	
		//====================================== Refresh Scores
		Game::refreshClientScore(%killerId);
		Game::refreshClientScore(%playerId);

		%distance = floor(%killerId.lastkill);
		%killerId.lastkill = "0";

		if (%distance)
		{
			%msg = "" @ %msg @ " Distance = " @ %distance @ " Meters";
		}

		if (%killedflag)
		{
			if ($ScoreOn) centerprint(%killerId, "You Team Killed The Flag Runner! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
			messageAll(0, Client::getName(%killerId) @ " TEAM KILLED his own Flag Runner!!!");
		}
		else
		{
			if ($ScoreOn) bottomprint(%killerId, " You Team Killed! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
		}

		$Shifter::LastTker = (Client::getName(%killerId));
		$Shifter::LastTKed = (Client::getName(%playerId));
		$Shifter::LastTKno = (%killerid.TKCount + 1);

		if(%killerid.TKCount == "")
		{
			%killerid.TKCount = 1;
		}
		else
		{
			%killerid.TKCount = %killerid.TKCount + 1;

			//============================================================================== Server Terminates Team Killer

			if (%killerid.TKCount > $Shifter::KillTerm)
			{
				if ($Shifter::KillTerm > "1")
				{
					bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than " @ $Shifter::KillTerm @ " Times.",5);
					schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
				}
				else
				{
					bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than 1 Time.", 5); 
					schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
				}
			}

			if(%killerid.TKCount > $SHAntiTeamKillMaxKills)
			{
				%clientId = %killerId;
				%addr = Client::getTransportAddress(%killerId);
				%name = Client::getName(%clientId);
				
				if ($Server::Admin["noban", %name] && %clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}		
				else if (%clientId.noban)
				{
					echo ("ADMINMSG **** " @ %name @ " hit TK limit but is NoBan");
					return;
				}

				bottomprintall("***" @ Client::getName(%killerId) @ " Was Kicked and Banned For TeamKilling", 5); 

				%ip = Client::getTransportAddress(%killerId);
				BanList::add(%ip, $SHAntiTeamKillBanTime);      //=== Add Player To BanList
				shban(%ip);
				%killer = Client::getOwnedObject(%killerId);
				messageAll(0, Client::getName(%killerId) @ " was kicked and banned for teamkilling");
				KickPlayer(%killerId,"***" @ $Shifter::TeamKillMsg @ "***");
			}
			else
			{
				if(%killerid.TKCount > $SHAntiTeamKillWarnKills)
				{
					centerprint(%killerId, "You have killed " @ %killerId.TKCount @ " teammates. If you continue you will be kicked and banned.", 10);
				}	
			}
		}		
    	}
}

// ======================================================================================= FUBAR's Match Mode
function MatchAssign()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%clName = Client::getName(%pl);
		if ($debug) echo($Shifter::tag0 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag0 @ %pl));
      if ($debug) echo($Shifter::tag1 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag1 @ %pl));
      if(String::findSubStr(%clName,$Shifter::Tag0) != -1)
		{
			//processmenuPickTeam(%pl,0,"");
			GameBase::setTeam(%pl,0);
		}		
		else if(String::findSubStr(%clName,$Shifter::Tag1) != -1)
		{
			//processmenuPickTeam(%pl,1,"");
			GameBase::setTeam(%pl, 1);
		}
		else 
		{
			//GameBase::setTeam(%pl, -1);
			processMenuPickTeam(%pl, -1, "");
		}
	}
	return;
}

function NewMT()
{
	$matchtrack::caps0 = 0;
	$matchtrack::nukes0 = 0;
	$matchtrack::dets0 = 0;
	$MatchTrack::EmpM0	= 0;
	$MatchTrack::GasM0	= 0;
	$MatchTrack::PhoenixM0 	= 0;
	$MatchTrack::NapM0	= 0;
	$MatchTrack::BooM0	= 0;
	$MatchTrack::SpyPod0	= 0;

	$matchtrack::caps1 = 0;
	$matchtrack::nukes1 = 0;
	$matchtrack::dets1 = 0;
	$MatchTrack::EmpM1	= 0;
	$MatchTrack::GasM1	= 0;
	$MatchTrack::PhoenixM1 	= 0;
	$MatchTrack::NapM1	= 0;
	$MatchTrack::BooM1	= 0;
	$MatchTrack::SpyPod1	= 0;
	if($server::timelimit)
		$server::timelimit = 45;

	$matchtrack::time = $server::timelimit;

	$matchtrack::timecheck = 0;
	export("$matchtrack::*", "config\\matchtrack.cs", false);
	$dlist = " ";
	export("$dlist", "config\\dtrack.cs", false);
}

function RecordMT()
{
	if(!$ceasefire && $server::tourneymode)
	{
		$matchtrack::tag0 = $shifter::tag0;
		$matchtrack::nukes0 = $TeamItemCount[0 @ "MFGLAmmo"];
		$matchtrack::dets0 = $TeamItemCount[0 @ "SuicidePack"];
		$MatchTrack::EmpM0	= $TeamItemCount[0 @ "EmpM"];
		$MatchTrack::GasM0	= $TeamItemCount[0 @ "GasM"];
		$MatchTrack::PhoenixM0 	= $TeamItemCount[0 @ "PhoenixM"];
		$MatchTrack::NapM0	= $TeamItemCount[0 @ "NapM"];
		$MatchTrack::BooM0	= $TeamItemCount[0 @ "BooM"];
		$MatchTrack::SpyPod0	= $TeamItemCount[0 @ "SpyPod"];

		$matchtrack::tag1 = $shifter::tag1;
		$matchtrack::nukes1 = $TeamItemCount[1 @ "MFGLAmmo"];
		$matchtrack::dets1 = $TeamItemCount[1 @ "SuicidePack"];
		$MatchTrack::EmpM1	= $TeamItemCount[1 @ "EmpM"];
		$MatchTrack::GasM1	= $TeamItemCount[1 @ "GasM"];
		$MatchTrack::PhoenixM1 	= $TeamItemCount[1 @ "PhoenixM"];
		$MatchTrack::NapM1	= $TeamItemCount[1 @ "NapM"];
		$MatchTrack::BooM1	= $TeamItemCount[1 @ "BooM"];
		$MatchTrack::SpyPod1	= $TeamItemCount[1 @ "SpyPod"];

		$matchtrack::mission = $missionName;
		$matchtrack::pass = $server::password;
		//$matchtrack::tourneymode = $server::tourneymode;
		export("$matchtrack::*", "config\\matchtrack.cs", false);
		$dlist = string::greplace($dlist, "  ", " ");
		$dlist = string::greplace($dlist, " 0 ", " ");
		export("$dlist", "config\\dtrack.cs", true);
	}
}

function InitMT()
{
	exec("matchtrack.cs");

	$teamscore[0] = $matchtrack::caps0;
	$shifter::tag0 = $matchtrack::tag0;
	$TeamItemCount[0 @ "MFGLAmmo"] = $matchtrack::nukes0;
	$TeamItemCount[0 @ "SuicidePack"] = $matchtrack::dets0;
	$TeamItemCount[0 @ "EmpM"] = $MatchTrack::EmpM0;
	$TeamItemCount[0 @ "GasM"]	= $MatchTrack::GasM0;
	$TeamItemCount[0 @ "PhoenixM"] = $MatchTrack::PhoenixM0;
	$TeamItemCount[0 @ "NapM"]	= $MatchTrack::NapM0;
	$TeamItemCount[0 @ "BooM"]	= $MatchTrack::BooM0;
	$TeamItemCount[0 @ "SpyPod"]	= $MatchTrack::SpyPod0;

	$teamscore[1] = $matchtrack::caps1;
	$shifter::tag1 = $matchtrack::tag1;
	$TeamItemCount[1 @ "MFGLAmmo"] = $matchtrack::nukes1;
	$TeamItemCount[1 @ "SuicidePack"] = $matchtrack::dets1;
	$TeamItemCount[1 @ "EmpM"] = $MatchTrack::EmpM1;
	$TeamItemCount[1 @ "GasM"]	= $MatchTrack::GasM1;
	$TeamItemCount[1 @ "PhoenixM"] = $MatchTrack::PhoenixM1;
	$TeamItemCount[1 @ "NapM"]	= $MatchTrack::NapM1;
	$TeamItemCount[1 @ "BooM"]	= $MatchTrack::BooM1;
	$TeamItemCount[1 @ "SpyPod"]	= $MatchTrack::SpyPod1;
	$Shifter::GlobalTChat = $matchtrack::Global;
	//$server::tourneymode = $matchtrack::tourneymode;
	$matchtrack::timecheck = 0;
	%time = floor($matchtrack::time);
	$Server::timeLimit = %time;
	$Server::password = $matchtrack::pass;
	deploy::init();
}

function CheckStayBase()
{
	if(!$ceasefire || !$matchstarted)
		return;

	%flagpos[0]	= ($teamFlag[0]).originalPosition;
	%flagpos[1] = ($teamFlag[1]).originalPosition;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%ppos = GameBase::getPosition(%cl);
		%team = GameBase::getTeam(%cl);
		%dist = Vector::getDistance(%ppos, %flagpos[%team]);
		if(%dist > 160)
		{
			Player::blowUp(%cl);
			remoteKill(%cl);
			schedule("centerprint(" @ %cl @ ", \"<jc><f0>CeaseFire. Please Stay At Your Bases.\", 5);", 5);
		}
	}
	schedule("CheckStayBase();", 3);
}

function SortTeams()
{
	if($shifter::tag0 != "" && $shifter::tag1 != "")
	{
		$Server::teamName0 = $shifter::tag0;
		$Server::teamName1 = $shifter::tag1;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%clName = Client::getName(%cl);
			if(String::findSubStr(%clName,$Shifter::Tag0) != -1)
				processMenuPickTeam(%cl, 0, %cl);
			else if(String::findSubStr(%clName,$Shifter::Tag1) != -1)
				processMenuPickTeam(%cl, 1, %cl);
		}
	}
}