
$Vmodule[1] = "Napalm";
$Vmodule[2] = "HellFire";
$Vmodule[3] = "DetPack";
$Vmodule[4] = "Bomber";
$Vmodule[5] = "PickUp";
$Vmodule[6] = "Mine Net";
$Vmodule[7] = "Stealth";
$Vmodule[8] = "Wraith";
$Vmodule[9] = "Interceptor";
$Vmodule[10] = "GodHammer";
$VModule[12] = "Valkyrie";

function LoadModule(%client,%this,%modNum,%ammo,%shield)
{
	Client::sendMessage(%client,0,$VModule[%modNum]@" Module Loaded.");
	playSound(SoundMortaReload,GameBase::getPosition(%this));
	Player::setItemCount(%client,$VModule[%modNum]@"Module",0);
	%this.module = %modNum;
	%this.ammo = %ammo;
	%this.shieldStrength = %shield;
	%this.refire = 1;
	schedule ("" @ %this @ ".refire = 0;", 2.0);
}

//===================================================================================================================
//											Flyer Data
//===================================================================================================================
FlierData Scout{ explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "flyer"; shieldShapeName = "shield_medium"; mass = 9.0; drag = 1.0; density = 1.2; maxBank = 1.2; maxPitch = 100.0; maxSpeed = 70; minSpeed = -15; lift = 1.10; maxAlt = 1550; maxVertical = 12; maxDamage = 0.8; damageLevel = {1.0, 1.0}; maxEnergy = 100; accel = 1.2; groundDamageScale = 1.0; reloadDelay = 0.2; repairRate = 0.1; damageSound = SoundFlierCrash; ramDamage = 1.5; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 22; }; // projectileType = "Undefined";  projectileType = "Undefined";
FlierData LAPC { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "hover_apc_sml"; shieldShapeName = "shield_large"; mass = 22.0; drag = 1.2; density = 1.2; maxBank = 0.8; maxPitch = 100.0; maxSpeed = 65; minSpeed = -5; lift = 0.75; maxAlt = 1550; maxVertical = 9; maxDamage = 1.9; damageLevel = {1.0, 1.0}; destroyDamage = 1.5; maxEnergy = 100; accel = 0.7; groundDamageScale = 0.50; repairRate = 0; ramDamage = 1.5; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; reloadDelay = 4.0; damageSound = SoundTankCrash; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 23; }; //projectileType = Undefined;
FlierData HAPC { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "hover_apc"; shieldShapeName = "shield_large"; mass = 25.0; drag = 1.6; density = 1.2; maxBank = 0.7; maxPitch = 100.0; maxSpeed = 60; minSpeed = -15; lift = 0.35; maxAlt = 1550; maxVertical = 6; maxDamage = 2.2; damageLevel = {1.0, 1.0}; maxEnergy = 100; accel = 0.40; groundDamageScale = 0.125; reloadDelay = 4.0; repairRate = 0; ramDamage = 1.5; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; fireSound = SoundFireFlierRocket; reloadDelay = 3.0; damageSound = SoundTankCrash; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 23; }; //projectileType = Undefined;

//===================================================================================================================
//											Scout
//===================================================================================================================

function Scout::OnFire(%this)
{	
	if (%this.refire) return;
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	%module = %this.module;
	%pos = gamebase::getposition(%this);
	%rot = gamebase::getrotation(%this);
	if (!%module || %this.ammo == 0)
	{	if (Player::getItemCount(%player, HellFireModule))
		{
			LoadModule(%client,%this,2,15,0.002);
		}
		else if (Player::getItemCount(%player, DetPackModule))
		{
			LoadModule(%client,%this,3,1,0.0);
		}
		else if (Player::getItemCount(%player, PickUpModule))
		{
			LoadModule(%client,%this,5,3,0.008);
		}
		else if (Player::getItemCount(%player, WraithModule))
		{
			LoadModule(%client,%this,8,3,0.006);
			GameBase::startFadeout(%this);
			GameBase::startFadeout(%player);
			%rate = Player::getSensorSupression(%player) + 100;
			Player::setSensorSupression(%player,%rate);
			Player::setSensorSupression(%client,%rate);
			Player::setSensorSupression(%this,%rate);
		}		
		else if (Player::getItemCount(%player, ValkyrieModule))
		{
			LoadModule(%client,%this,12,15,0.002);
		}
		else if (Player::getItemCount(%player, InterceptorModule))
		{
			LoadModule(%client,%this,9,150,0.002);
		}		
		else
		{
			schedule ("" @ %this @ ".ammoout = 0;", 2.2);
			if (!%this.ammoout)
			{
				Client::sendMessage(%client,1,"Can not fire out of ammo or no module loaded. ~wError_Message.wav");
			}
			%this.ammoout = 1;
			%this.module = 0;
			%this.ammo = 0;	
			%this.shieldStrength = 0.010;
		}
	}
	else if (%module == "2") //== HellFire Bombs
	{
		%slide = -2;
		for(%i = 1; %i < 4; %i++)
		{
			%dir = Vector::getfromrot(%rot);
			%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos;
			%r = %slide @ " 0 0";
			%vel1 = "0 0 0";
			%vel2 = EmplacementPack::rotVector(%r, %rot);
			%vel = Vector::add(%vel1, %vel2);
			%obj = Projectile::spawnProjectile(Frag,%trans1,%this,%vel); %obj.deployer = %client;
			%slide += 2;
		}
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 3.0);
	}
	else if (%module == "3") //== DetPack
	{
		for (%i = 0; %i < 8; %i++)
		{
			%frag = "Frag" @ (floor(getRandom()*3)+1); %obj = newObject("","Mine", %frag); %obj.deployer = %client; if ((floor(getRandom()*4)+1) > 2) { %dir = -130; GameBase::throw(%obj,%client,%dir,false); } else { %dir = -70; GameBase::throw(%obj,%client,%dir,false); }
			addToSet("MissionCleanup", %obj);
		}
		%client.missilekill = 1;
		schedule(%client @ ".missilekill = 0;",5);
		Aoe::deployShape(%this, 35, $NukeDamageType, 5, %client, 0.55);	                
		GameBase::applyRadiusDamage($NukeDamageType, %pos, 6, 5.80, 50, %player);
	
		%this.refire = 1;
		%this.ammo -= 1;
		schedule (%this @ ".refire = 0;", 2.0);
	}
	else if (%module == "5") //== PickUp
	{
		%obj = newObject("","Mine","PickUpPack");		
		addToSet("MissionCleanup", %obj);		
		%k = Vector::getFromRot(%rot, -2);
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " -2.0";
		%pos = Vector::add(%pos, %padd);
		gamebase::setposition(%obj, %pos);		
		%this.refire = 1;%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
	}
	else if (%module == "8") //== Wraith Module
	{
		bottomprint (%client, "Cloaking Activated Automatically", 5);
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 120.0);
	}
	else if (%module == "9") //== Interceptor Module
	{
		%dir = (Vector::getfromrot(%rot));
		%y1 = Vector::getFromRot(%rot, 17);
		%pos1 = Vector::add(%pos, %y1);
		%trans =  %rot @" "@ %dir @" "@ %dir @" "@ %pos1;
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile(InterceptorAmmo, %trans ,%player,%vel);
		Projectile::spawnProjectile(InterceptorAmmo, %trans ,%player,%vel);
		playSound(SoundFireBlaster,%pos);
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 0.1);
		%this.ammo -= 1;
	}
	else if (%module == "12") //-- Valkyrie Module
	{
		%vel = item::getvelocity(%this);		
		%dir = Vector::getfromrot(%rot);
		%fastdir = Vector::getfromrot(%rot, 8.0);
		%pos0 = Vector::add(%pos, %fastdir);
		%padding = "0 0 1";
		%pos1 = Vector::add(%pos0, %padding);

		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		%fired = Projectile::spawnProjectile(FlierRocket, %trans1,%player,%vel);
		playSound(SoundFireFlierRocket,%pos);
		%this.refire = 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
		%this.ammo -= 1;
	}
}



//===================================================================================================================
//											LAPC
//===================================================================================================================

function LAPC::OnFire(%this)
{
	if (%this.refire) return;
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	%module = %this.module;
	%pos = gamebase::getposition(%this);
	%rot = gamebase::getrotation(%this);
	if (!%module || %this.ammo == 0)
	{	
		if (Player::getItemCount(%player, StealthModule))
		{
			LoadModule(%client,%this,7,3,0.008);
		}
		else if (Player::getItemCount(%player, GodHammerModule))
		{
			LoadModule(%client,%this,10,15,0.003);
		}
		else if (Player::getItemCount(%player, BomberModule))
		{
			LoadModule(%client,%this,4,4,0.003);
		}
		else if (Player::getItemCount(%player, PickUpModule))
		{
			LoadModule(%client,%this,5,3,0.008);
		}		
		else
		{
			schedule ("" @ %this @ ".ammoout = 0;", 2.2);
			if (!%this.ammoout)
			{
				Client::sendMessage(%client,1,"Can not fire out of ammo or no module loaded. ~wError_Message.wav");
			}
			%this.ammoout = 1;
			%this.module = 0;
			%this.ammo = 0;
			%this.shieldStrength = 0.010;
		}
	}
	else if (%module == "7" && %this.ammo) //== Stealth Module
	{
		if (%this.stealth == 1)
			%this.stealth = 0;
		else if (%this.stealth == 0)
		{
			%this.stealth = 1;
			%this.ammo -= 1;
			%rate = Player::getSensorSupression(%player) + 100;
			Player::setSensorSupression(%player,%rate);
			Player::setSensorSupression(%client,%rate);
			Player::setSensorSupression(%this,%rate);
			Player::setSensorSupression(%player,100);
			Player::setSensorSupression(%this,100);
			bottomprint (%client, "Stealth Activated For 120 Seconds", 5);
			schedule ("StealthOff(" @ %this @ ");", 120);

			%this.refire = 1;
			schedule ("" @ %this @ ".refire = 0;", 100.0);
		}
	}
	else if (%module == "4" && %this.ammo) //== Bomber
	{
		%rot = gamebase::getrotation(%this);
		%dir = (Vector::getfromrot(%rot));
		%dir = Vector::add(%dir, "0 0 0");
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(ModuleBomb, %trans ,%player,%vel);
		%fired.deployer = %client;
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
	}
	else if (%module == "10" && %this.ammo) //== GodHammer Module
	{
		%slide = -15;
		for(%i = 1; %i < 8; %i++)
		{
			%dir = Vector::getfromrot(%rot);
			%fastdir = Vector::getfromrot(%rot, 7.0);
			%pos0 = Vector::add(%pos, %fastdir);
			%padding = "0 0 3";
			%pos1 = Vector::add(%pos0, %padding);

			%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
			%r = %slide @ " 0 0";
			%vel1 = item::getvelocity(%this);
			%vel2 = EmplacementPack::rotVector(%r, %rot);
			%vel = Vector::add(%vel1, %vel2);
			%obj = Projectile::spawnProjectile("GodHammer",%trans1,%player,%vel);
			%slide += 5;
		}
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 0.6);
	}
	else if (%module == "5" && %this.ammo) //== PickUp
	{
		%obj = newObject("","Mine","PickUpPack");		
		addToSet("MissionCleanup", %obj);		
		%k = Vector::getFromRot(%rot, -2);
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " -2.0";
		%pos = Vector::add(%pos, %padd);
		gamebase::setposition(%obj, %pos);		
		%this.refire = 1;%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
	}
}

//===================================================================================================================
//											HAPC
//===================================================================================================================
function HAPC::OnFire(%this)
{ 
	if (%this.refire) return;
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	%module = %this.module;
	%modulename = $VModule[%module];
	%pos = gamebase::getposition(%this);
	%rot = gamebase::getrotation(%this);

	if (!%module || %this.ammo == 0)
	{
		if (Player::getItemCount(%player, StealthModule))
			LoadModule(%client,%this,7,4,0.008);
		else if (Player::getItemCount(%player, GodHammerModule))
			LoadModule(%client,%this,10,25,0.003);
		else if (Player::getItemCount(%player, BomberModule))
			LoadModule(%client,%this,4,6,0.003);
		else if (Player::getItemCount(%player, PickUpModule))
			LoadModule(%client,%this,5,3,0.008);
		else
		{
			schedule ("" @ %this @ ".ammoout = 0;", 2.2);
			if (!%this.ammoout)
			{
				Client::sendMessage(%client,1,"Can not fire out of ammo or no module loaded. ~wError_Message.wav");
			}
			%this.ammoout = 1;
			%this.module = 0;
			%this.ammo = 0;
			%this.shieldStrength = 0.010;
			return;
		}
	}
	if (%module == "7") //== Stealth Module
	{
		if (%this.stealth == 1)
		{
			%this.stealth = 0;
		}
		else if (%this.stealth == 0)
		{
			%this.stealth = 1;
			%this.ammo -= 1;
			Player::setSensorSupression(%player,100);
			Player::setSensorSupression(%this,100);
			bottomprint (%client, "Stealth Activated For 120 Seconds", 5);
			schedule ("StealthOff(" @ %this @ ");", 120);
			%this.refire = 1;
			schedule ("" @ %this @ ".refire = 0;", 100.0);
		}
	}
	else if (%module == "4") //== Bomber
	{
		%rot = gamebase::getrotation(%this);
		%dir = (Vector::getfromrot(%rot));
		%dir = Vector::add(%dir, "0 0 0");
		%trans =  %rot @ " " @ %dir @ " 0 0 0 " @ gamebase::getposition(%this);
		%fired = Projectile::spawnProjectile(ModuleBomb, %trans ,%player,%vel);
		%fired.deployer = %client;
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
	}
	else if (%module == "10") //== GodHammer Module
	{
		%slide = -15;
		for(%i = 1; %i < 8; %i++)
		{
			%dir = Vector::getfromrot(%rot);
			%fastdir = Vector::getfromrot(%rot, 7.0);
			%pos0 = Vector::add(%pos, %fastdir);
			%padding = 0 @ " " @ " 0 " @ "4";
			%pos1 = Vector::add(%pos0, %padding);

			%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
			%r = %slide @ " 0 0";
			%vel1 = item::getvelocity(%this);
			%vel2 = EmplacementPack::rotVector(%r, %rot);
			%vel = Vector::add(%vel1, %vel2);
			%obj = Projectile::spawnProjectile("GodHammer",%trans1,%player,%vel);
			%slide += 5;
		}
		%this.refire = 1;
		%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 0.6);
	}
	else if (%module == "5" && %this.ammo) //== PickUp
	{
		%obj = newObject("","Mine","PickUpPack");		
		addToSet("MissionCleanup", %obj);		
		%k = Vector::getFromRot(%rot, -2);
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " -2.5";
		%pos = Vector::add(%pos, %padd);
		gamebase::setposition(%obj, %pos);		
		%this.refire = 1;%this.ammo -= 1;
		schedule ("" @ %this @ ".refire = 0;", 2.0);
	}
}

function StealthOff(%this)
{ 
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	Player::setSensorSupression(%player,0);
	Player::setSensorSupression(%this,0);
	%this.stealth = 0;
	bottomprint (%client, "Stealth Is DeActivated.", 5);
}

//===================================================================================================================
//													Other Funcs
//===================================================================================================================

function Vehicle::onAdd(%this)
{ 
	%vname = GameBase::getDataName(%this);
	echo ("VN  " @ %vname);

	%this.isalive = true;

	if (%vname == "Scout")
	{
		%this.shieldStrength = 0.010;
		GameBase::setRechargeRate (%this, 25);
		GameBase::setMapName (%this, "Scout Vehicle");
	}
	if (%vname == "Jet")
	{
		%this.shieldStrength = 0.010;
		GameBase::setRechargeRate (%this, 25);
		GameBase::setMapName (%this, "Interceptor Vehicle");
	}
	if (%vname == "LAPC")
	{
		%this.shieldStrength = 0.013;
		GameBase::setRechargeRate (%this, 22);
		GameBase::setMapName (%this, "LAPC Vehicle");
	}
	if (%vname == "HAPC")
	{
		%this.shieldStrength = 0.018;
		GameBase::setRechargeRate (%this, 25);
		GameBase::setMapName (%this, "HAPC Vehicle");
	}
	else
	{
		%this.shieldStrength = 0.010;
		GameBase::setRechargeRate (%this, 25);
		GameBase::setMapName (%this, "Vehicle");
	}
}

function Vehicle::onCollision (%this, %object)
{ 
	%data = GameBase::getDataName(%this);
	%client = Player::getClient(%object);
	%armor = Player::getArmor(%object);
	%armor = %armor.shapefile;
	%vname = GameBase::getDataName(%this);
	%module = $Vmodule[%this.module];

	Client::sendMessage(%client,0," Loaded With VM - "@ GameBase::getMapName (%this));
	
	if(%object.Station != "" && %client.invo != "")
	{
		Client::sendMessage(%client,0,"You must leave the Inventory Station to pilot the vehicles.~wError_Message.wav");
		%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, (%data.maxDamage + 1.0));
		return;	
	}
	
	if(%data.shapefile == "discb")
	{
		GameBase::setDamageLevel(%this, 10);
		return;
	}

	else if(%data.shapefile == "rocket")
	{	
		GameBase::setDamageLevel(%this, 10);
		return;
	}

	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
			if((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount(%this, %object))
			{
				%weapon = Player::getMountedItem(%object,$WeaponSlot);

				if(%weapon != -1)
				{
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				
				if(%this.module == 8 && %this.ammo)
				{
					GameBase::startFadeout(%this);
					GameBase::startFadeout(%object);
					%client.module = 8;
					%rate = Player::getSensorSupression(%object) + 100;
					Player::setSensorSupression(%object,%rate);
					Player::setSensorSupression(%client,%rate);
					Player::setSensorSupression(%this,%rate);
					%this.ammo -= 1;
				}
				else if(%this.module == 8 && !%this.ammo)
				{
					%this.module = 0;
				}
				
				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);
				
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%client.inflyer = 1;
				%object.driver = 1;
				%object.vehicle = %this;
				%client.driver = 1;
				%this.driver = 1;
				%this.clLastMount = %client;
				%object.newMountTime = getsimtime() + 3;
			}
			else if((%armor == "marmor" || %armor == "mfemale") && Vehicle::canMount(%this, %object) && GameBase::getDataName(%this) != Scout && GameBase::getDataName(%this) != Jet)  
			{
				%weapon = Player::getMountedItem(%object,$WeaponSlot);

				if(%weapon != -1)
				{
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}

				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);
				
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%client.inflyer = 1;
				%object.driver = 1;
				%object.vehicle = %this;
				%client.driver = 1;
				%this.driver = 1;
				%this.clLastMount = %client;				
				%object.newMountTime = getsimtime() + 3;
			}
			else if(GameBase::getDataName(%this) != Scout && GameBase::getDataName(%this) != Jet)  
			{
				%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) 
				{
					if ($debug) echo ("Mount = " @ %mountSlot);
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					%this.passenger[%mountSlot] = %object;
echo("Passenger "@ %object @" hopped in");
					Player::setMountObject(%object, %this, %mountSlot);
					
					%client.inflyer = 1;
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					%object.newMountTime = getsimtime() + 3;
				}
			}
			else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be in a Less Heavy Armor to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{ 
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	
	%count=0;
	
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "")
		{
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1)
	{
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)
	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{ 
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);

	for(%i = 0 ;%i<%num;%i++)
	{
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "")
		{
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{ 
	%armor = Player::getArmor(%passenger);
	%armor = %armor.shapefile;
	if(%armor == "larmor" || %armor == "lfemale")
	{
		%height = 8;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		%height = 8;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor")
	{
		%height = 4;
		%velocity = 140;
		%zVec = 110;
	}
	else
	{	
		%height = 4;
		%velocity = 70;
		%zVec = 70;
	}
	
	%pos = GameBase::getPosition(%passenger);

	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
	{
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   	%passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		%client.inflyer = 0;
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{ 
	%data = GameBase::getDataName(%this);
	%client = gamebase::getcontrolclient(%this);
	%player = Client::getOwnedObject(%client);
	if(%player.refire == true)
		return;
	if(%data.shapefile == "rocket")
	{
		%data = GameBase::getDataName(%o);
		if (GameBase::setDamageLevel(%this, 10))
			if ($debug) echo ("BOOM");
	}

  	
  	Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{ 
	%vel = Item::getVelocity(%this);
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player")
		{
			%pos = GameBase::getPosition(%pl);
			Player::setSensorSupression(%pl,0);

			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0)))
			{
				%pl.lastMount = %this;
				%client = player::getClient(%pl);
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
				Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);



		%velX = getWord(%vel,0);
		%velY = getWord(%vel,1);
		%velZ = getWord(%vel,2);

		if(%velX != 0 && %velY != 0)
		{
			%velocity = 6 * pow((%velX*%velX + %velY*%velY), 0.5);
			%height = 15;
			%zVec = %velZ + 2; //170;

			%jumpDir = Vector::getFromRot(GameBase::getRotation(%this),%velocity,%zVec);
			%jumpDir = Vector::add(%jumpDir, %vel);

			%pos = GameBase::getPosition(%this);

			%posX = getWord(%pos,0);
			%posY	= getWord(%pos,1);
			%posZ	= getWord(%pos,2);
			GameBase::setPosition(%pl,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		}
		else
			%jumpDir = %mom;

				Player::applyImpulse(%pl,%jumpDir);
				Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);

				if(%pl.lastWeapon != "")
				{
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";

					if(GameBase::getDataName(%this) == Wraith)
					{
						GameBase::startFadein(%this);
					}
				}
				%pl.driver = "";
				%client.driver = "";
				%pl.vehicle = "";
				%this.driver = "";
				%cl.inflyer = 0;
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
	if(%this.module == 8)
	{
		GameBase::startFadeIn(%this);
		GameBase::startFadeIn(%pl);
		%rate = Player::getSensorSupression(%pl) - 100;
		Player::setSensorSupression(%pl,%rate);
		Player::setSensorSupression(%client,%rate);
		Player::setSensorSupression(%this,%rate);
	}
}
function Vehicle::onDestroyed (%this,%mom) 
{ 
 	%this.driver = "";
	for(%i = 0; %i < 5; %i++)
	{
		%passenger = %this.passenger[%i];
		%pc = Player::getClient(%passenger);
		%pc.inflyer = "";
		%passenger.vehicle = "";
echo("Passenger "@ %passenger @" bailed out");
		Client::SendMessage(%pc, 0, "KaB00M!");
	}

	%data = GameBase::getDataName(%this);

	if (%this.missilegone == 1 && (%data.shapefile == "rocket" || %data.shapefile == "disc") )
	{
		%this.missilegone = 0;
		return;
	}

 	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
 	
 	%cl = GameBase::getControlClient(%this);
 	%pl = Client::getOwnedObject(%cl);
 
 	Client::setOwnedObject(%cl, %this);
	Client::setOwnedObject(%cl, %pl);
	Client::SendMessage(%cl, 0, "KaB00M!");
	%cl.inflyer = 0;

	if(%cl.module == 8)
	{
		%cl.module = "";
		GameBase::startFadeIn(%pl);
		%rate = Player::getSensorSupression(%pl) - 100;
		Player::setSensorSupression(%pl,%rate);
		Player::setSensorSupression(%cl,%rate);
		Player::setSensorSupression(%this,%rate);		
	}
	
 	if(%pl != -1)
 	{
 		Player::setMountObject(%pl, -1, 0);
 		doneposs(%cl);
 		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "")
		{
			Player::useItem(%pl,%pl.lastWeapon);
			%pl.lastWeapon = "";
		}
		//else
			//selectValidWeapon(%cl);
		%pl.driver = "";
		%cl.driver = "";

 	}
 	for(%i = 0 ;%i < 4 ;%i++) if(%this.Seat[%i] != "")
 	{
		%pl = Client::getOwnedObject(%this.Seat[%i]);
		Player::setMountObject(%pl, -1, 0);
		doneposs(%this.Seat[%i]);
		Client::setControlObject(%this.Seat[%i], %pl);
	}
	
	if(%data.shapefile == "rocket")
	{
		if ($debug) echo ("Proj Name = " @ %data);
		if ($debug) echo ("POP" @ %this);
		if ($debug) echo ("POPPED " @ %this.popped);
		%pos = GameBase::getPosition(%this);

		if (!CheckMissileJammer(%this))
		{

			if (%data == NapProj)
			{
				%cl.missilekill = 1;
				schedule(%cl @ ".missilekill = 0;",20);
	
				Aoe::deployShape(%this, 35, $PlasmaDamageType, 10, %cl, 0.32);
				DeployFrags(%this, 10, %pl);
				GameBase::applyRadiusDamage($PlasmaDamageType, %pos, 25, 0.50, 345, %pl);
			}
			else if (%data == EmpProj)
			{
				%cl.missilekill = 1;
				schedule(%cl @ ".missilekill = 0;",20);
				%obj = newObject("","Mine","EMPBlast");
				GameBase::throw(%obj,%cl,0,false);		
				addToSet("MissionCleanup", %obj);
				%padd = "0 0 3.5";
				%pos = Vector::add(%pos, %padd);
				GameBase::setPosition(%obj, %pos);
	
				%obj = newObject("","Mine","EMPBlast");
				GameBase::throw(%obj,%cl,0,false);		
				addToSet("MissionCleanup", %obj);
				%padd = "0 0 3.5";
				%poss = Vector::add(%pos, %padd);
				GameBase::setPosition(%obj, %poss);					
				Client::setOwnedObject(%cl, %pl);
	
				Aoe::deployShape(%this, 18, $FlashDamageType, 15, %cl, 0.25);
				GameBase::applyRadiusDamage($FlashDamageType, %pos, 20, 0.75, 300, %pl);
			}
			else if (%data == GasProj)
			{
				%cl.missilekill = 1;
				schedule(%cl @ ".missilekill = 0;",20);
				Aoe::deployShape(%this, 35, $EnergyDamageType, 25, %cl, 0.30);
				GameBase::applyRadiusDamage($EnergyDamageType, %pos, 30, 0.55, 175, %pl);
			}
			else if (%data == BooProj)
			{
				%cl.missilekill = 1;
				schedule(%cl @ ".missilekill = 0;",20);
				Aoe::deployShape(%this, 35, $NukeDamageType, 10, %cl, 0.55);	                
				GameBase::applyRadiusDamage($NukeDamageType, %pos, 6, 5.80, 50, %pl);
			}
			else if (%data == ShortCoolProj)
			{
				%cl.missilekill = 1;
				schedule(%cl @ ".missilekill = 0;",20);
				GameBase::applyRadiusDamage($MissileDamageType, %pos, 8, 1.0, 305, %pl);
			}
			else if (%data == SpyPodProj)
			{
				GameBase::applyRadiusDamage($MissileDamageType, %pos, 10, 1.52, 15, %pl);
			}			
			else	
			{
				%cl.missilekill = 1;
				schedule(%cl @ ".missilekill = 0;",20);
				GameBase::applyRadiusDamage($MissileDamageType, %pos, 8, 1.0, 600, %pl);
			}
		}
		else
		{
			bottomprint(%cl, "<jc><f2>You are being JAMMED! Control Lock Failed, War Head Did NOT Detonate, Jammer DESTROYED! ", 2);
		}
	}
	else
	{
		if(%data.shapefile != "camera")
			GameBase::applyDamage(%this,$DebrisDamageType,2.5,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
			calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
	}
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%data1 = GameBase::getDataName(%object);
	%data2 = GameBase::getDataName(%this);

	%value *= $damageScale[GameBase::getDataName(%this), %type];

	%data = GameBase::getDataName(%this);
	if(%data.shapefile == "rocket")
	{
		GameBase::setDamageLevel(%this, 5.0);
		return;
	}

	if (%type == "-1")
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	else
		StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	return 1.0;
}

FlierData tiny
{
explosionId = fakeExp;
debrisId = flashDebrisLarge;
className = "Vehicle";
shapeFile = "bullet";
shieldShapeName = "shield_medium";
mass = 0.001;
drag = 0.0;
density = 0.2;
maxBank = 1.2;
maxPitch = 100.0;
maxSpeed = 60;
minSpeed = 0.01;
lift = 800.10;
maxAlt = 1550;
maxVertical = 12;
maxDamage = 8.8;
damageLevel = {1.0, 1.0};
maxEnergy = 10;
accel = 0.01;
groundDamageScale = 1.0;
reloadDelay = 0.2;
repairRate = 0.1;
damageSound = SoundFlierCrash;
ramDamage = 0.0;
ramDamageType = -1;
mapFilter = 2;
mapIcon = "M_vehicle";
visibleToSensor = true;
shadowDetailMask = 2;
mountSound = SoundFlyerMount;
dismountSound = SoundFlyerDismount;
idleSound = SoundFlyerIdle;
moveSound = SoundFlyerActive;
visibleDriver = false;
driverPose = 22;
};
