
//======================================================================================================================
$TeamItemMax[CoolLauncher] = 2;
$TeamItemMax[Aoe] = 10;
$TeamItemCountAOE = 10;
//======================================================================================================================

RocketData snike
{
	bulletShapeName = "breath.dts";
	explosionTag = fakeExp;
	collisionRadius = 1.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.01;
	damageType = $FireDamageType;
	explosionRadius = 20;
	kickBackStrength = 0.0;
	muzzleVelocity = 1.0;
	terminalVelocity = 1.0;
	acceleration = 0.5;
	totalTime = 0.01;
	liveTime = 0.01;
	lightRange = 0.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
};

RocketData Faker
{
	bulletShapeName = "breath.dts";
	explosionTag = fakeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0;
	damageType = $ExplosionDamageType;
	explosionRadius = 0;
	kickBackStrength = 0.0;
	muzzleVelocity = 650.0;
	terminalVelocity = 800.0;
	acceleration = 5.0;
	totalTime = 0.1;
	liveTime = 0.1;
	lightRange = 0.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
};
function Faker::onAdd(%this)
{
	%t = $Faky;
	%markerPos = $Faky2;
	$Faky = "";
	$Faky2 = "";
	
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%client = GameBase::getControlClient(%t);
	if (GameBase::getLOSInfo(%t, 5, %rot))
	{
		Client::sendMessage(%client,0,"Unable to fire - Object in the way~wC_BuySell.wav");
		return;
	}
	%f = Vector::getFromRot(%rot, 3.5, 2.5);
	%vehicle = newObject("",flier,%t.load,true);
	Gamebase::setMapName(%vehicle,"Missile");
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	
	//Player::setMountObject(%client, %vehicle, 1);
	
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	%t.load = "";
	GameBase::playSound(%vehicle,bigExplosion1,0);
	doneposs(%client);

	%client.driver= 1;
	%client.vehicle = %vehicle;
	%vehicle.clLastMount = %client;
	 
	%pl = Client::getOwnedObject(%client);
 	
 	Client::setOwnedObject(%client, %vehicle);
	Client::setOwnedObject(%client, %pl);
	
	Client::setControlObject(%client, %vehicle);
}

function F1aker::onAdd(%this)
{
	%t = $F1aky;
	%markerPos = $F1aky2;
	$F1aky = "";
	$F1aky2 = "";
	%trans = GameBase::getTransform(%this);
	%rot = getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " " @ getWord(%trans, 5);
	%f = Vector::getFromRot(%rot, 3.5, 2);
	%vehicle = newObject("",flier,ShortCoolProj,true);
	Gamebase::setMapName(%vehicle,"Missile");
	addToSet("MissionCleanup", %vehicle);
	%client = GameBase::getControlClient(%t);
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::startFadeIn(%vehicle);
	GameBase::setPosition(%vehicle,Vector::add(%markerPos, %f));
	GameBase::setRotation(%vehicle,%rot);
	GameBase::playSound(%vehicle,bigExplosion1,0);
	doneposs(%client);
	Client::setControlObject(%client, %vehicle);
}

function doneposs(%cl) 
{  
	if(%cl.possessing)
	{  
		Client::setControlObject(%cl, %cl);  
		Client::setControlObject(%cl.poss, %cl.poss); 
		MessageAllExcept(%cl.poss, 0, Client::getName(%cl.poss) @ " is no longer possessed by " @ Client::getName(%cl) @ ".~wteleport2.wav");  
		Client::sendMessage(%cl.poss,1,"Your soul has been freed of " @ Client::getName(%cl)@".~wteleport2.wav"); 
		%cl.possessing = false;  
		(%cl.poss).possessed = false; 
		(%cl.poss).possby = "";
		%cl.poss = ""; 
	}
	if(%cl.possessed)
	{
		Client::setControlObject(%cl.possby, %cl.possby);   
		Client::setControlObject(%cl, %cl); 
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " is no longer possessed by " @ Client::getName(%cl.possby) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"Your soul has been freed of " @ Client::getName(%cl.possby)@".~wteleport2.wav");
		%cl.possessed = false;  
		(%cl.possby).possessing = false; 
		(%cl.possby).poss = "";   %cl.possby = ""; 
	} 
}


//========================================================================== Turret Data
 
TurretData DeployableCoolMortar
{
	projectileType = snike;
	className = "Turret";
	shapeFile = "missileturret";
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
	reloadDelay = 2.0;
	speed = 2.0;
	speedModifier = 1.5;
	range = 0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	explosionId = LargeShockwave;
	description = "Missile Control Station";
	damageSkinData = "objectDamageSkins";
};

function DeployableCoolMortar::onAdd(%this)
{
	schedule("DeployableCoolMortar::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,7);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Missile Control Station");
	}
}

function DeployableCoolMortar::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function DeployableCoolMortar::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}
 
function DeployableCoolMortar::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	%inv = %this.comstation;
	%data = GameBase::getDataName(%inv);
	GameBase::setDamageLevel(%inv, %data.maxDamage);
	$TeamItemCount[GameBase::getTeam(%this) @ "CoolLauncher"]--;
}

function DeployableCoolMortar::onPower(%this,%power,%generator)
{

}
 
function DeployableCoolMortar::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,7);
	GameBase::setActive(%this,true);
}

//========================================================================== Static Shape

StaticShapeData DeployableCoolStation
{
	description = "Missile Control Station";
	shapeFile = "cmdpnl";
	className = "DeployableStation";
	visibleToSensor = true;
	sequenceSound[0] = {"activate", SoundActivateCommandStation };
	sequenceSound[1] = {"power", SoundCommandStationPower };
	sequenceSound[2] = {"use", SoundUseCommandStation };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	castLOS = true;
	supression = false;
	supressable = false;
	explosionId = flashExpLarge;
};
 
function DeployableCoolStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "")
		GameBase::setMapName (%this, "Missile Control Station");
	%this.Energy = 3000;
}

function DeployableCoolStation::onDestroyed(%this)
{
	%turret = %this.comstation;
	%data = GameBase::getDataName(%turret);
	GameBase::setDamageLevel(%turret, %data.maxDamage);
	$TeamItemCount[GameBase::getTeam(%player) @ "CoolLauncher"]--;
}

function DeployableCoolStation::OnActivate(%this)
{
}

StaticShapeData Dep1oyableCoolStation
{
	description = "Missile Control Station";
	shapeFile = "cmdpnl";
	className = "DeployableStation";
	visibleToSensor = true;
	sequenceSound[0] = {"activate", SoundActivateCommandStation };
	sequenceSound[1] = {"power", SoundCommandStationPower };
	sequenceSound[2] = {"use", SoundUseCommandStation };
	maxDamage = 3.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	castLOS = true;
	supression = false;
	supressable = false;
	explosionId = flashExpLarge;
};

function Dep1oyableCoolStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Missile Control Station");
		%this.Energy = 3000;
}

function Dep1oyableCoolStation::onDestroyed(%this)
{
	%turret = %this.comstation;
	%data = GameBase::getDataName(%turret);
	GameBase::setDamageLevel(%turret, %data.maxDamage);
}

function Dep1oyableCoolStation::OnActivate(%this)
{
}

function CoolStationCheck(%this, %player)
{
	%client = Player::getClient(%player);
	%c = Player::getMountedItem(%player, $BackpackSlot);
	
	if ((%this.comstation).load == "")
	{
		if (%c.heading == "uGuided Missiles")
		{
			%vm = $vm[%c];
			//greygrey
			%team = GameBase::getTeam(%player);
			$TeamItemCount[%team @ %c]++;
			(%this.comstation).load = %vm;
			if($Server::TourneyMode == true)
				messageteam(1, getTeamName(%team) @ " used "@ %vm.description @" #" @ $TeamItemCount[%team @ %c], -1);
			messageteam(1, Client::getName(%client) @ " used "@ %vm.description @" #" @ $TeamItemCount[%team @ %c], %team);
			Player::setItemCount(%player, %c, 0);
			Client::sendMessage(%client,0,"Turret has been loaded with a " @ %vm.description @ ".");
			playSound(SoundMortaReload,GameBase::getPosition(%this));
		}
		else
		{
			if(Client::getControlObject(%client) == %player)
			{
				Client::sendMessage(%client,0,"Turret is not loaded.~waccess_denied.wav");
			}
		}
	}
	else
	{
		bottomprint(%client, "<jc>Press JUMP to fire.", 3);
		%player.CommandTag = 1;
		Client::takeControl(%client, %this.comstation);
	}
}

//============================================================================== These Are the actual projectiles

FlierData GasProj 
{
	description = "Toxin Missile";
	explosionId = puffEx;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 9.0;
	drag = 1.5;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 85;
	minSpeed = 30;
	lift = 0;
	maxAlt = 2300;
	maxVertical = 10;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 4.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.4;
	ramDamageType = $MissileDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundWindDisgust;
	moveSound = SoundWindDisgust;
	visibleDriver = true;
	driverPose = 22;
};

FlierData EmpProj
{
	description = "EMP Missile";
	explosionId = ShockwaveTwo;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 9.0;
	drag = 1.5;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 85;
	minSpeed = 55;
	lift = 0;
	maxAlt = 2300;
	maxVertical = 10;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 4.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.35;
	ramDamageType = $FlashDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundWindDisgust;
	moveSound = SoundWindDisgust;
	visibleDriver = true;
	driverPose = 22;
};

FlierData BooProj
{
	description = "Havoc Missile";
	explosionId = SockExp;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 9.0;
	drag = 1.2;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 90;
	minSpeed = 45;
	lift = 0;
	maxAlt = 2300;
	maxVertical = 10;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 100.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 1.2;
	ramDamageType = $MissileDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundWindDgust;
	moveSound = SoundWindDgust;
	visibleDriver = true;
	driverPose = 22;
};

FlierData CoolProj
{
	description = "Phoenix Missile";
	explosionId = SockExp;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 9.0;
	drag = 1.2;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 90;
	minSpeed = 45;
	lift = 0;
	maxAlt = 2300;
	maxVertical = 10;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 100.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 1.2;
	ramDamageType = $MissileDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundWindDgust;
	moveSound = SoundWindDgust;
	visibleDriver = true;
	driverPose = 22;
};

FlierData ShortCoolProj
{
	description = "Phoenix Missile";
	explosionId = SockExp;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "shield_medium";
	projectile = "Undefined";	
	mass = 9.0;
	drag = 1.2;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 90;
	minSpeed = 45;
	lift = 0;
	maxAlt = 2300;
	maxVertical = 10;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 100.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 1.2;
	ramDamageType = $MissileDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundWindDgust;
	moveSound = SoundWindDgust;
	visibleDriver = true;
	driverPose = 22;
};

FlierData SpyPodProj
{
	description = "SpyPod Missile";
	explosionId = ShockwaveThree;
	className = "Vehicle";
	shapeFile = "discb";
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 9.0;
	drag = 2.5;
	density = 1.2;
	maxBank = 50;
	maxPitch = 500;
	maxSpeed = 20;
	minSpeed = -20;
	lift = 0;
	maxAlt = 2000;
	maxVertical = 20;
	destroyDamage = 0.1;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 3.0;
	groundDamageScale = 10.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.45;
	ramDamageType = $MissileDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundGeneratorPower;
	moveSound = SoundGeneratorPower;
	visibleDriver = true;
	driverPose = 22;
};

FlierData NapProj
{
	description = "Napalm Missile";
	explosionId = napExp;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 9.0;
	drag = 1.5;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 70;
	minSpeed = 45;
	lift = 0;
	maxAlt = 2300;
	maxVertical = 20;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 4.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.45;
	ramDamageType = $MissileDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundWindDisgust;
	moveSound = SoundWindDisgust;
	visibleDriver = true;
	driverPose = 22;
};
function ShortCoolProj::onAdd(%this){	%this.smoking = "1";%this.driver = 1;} //Vehicle::SetSmoke(%this);
function NapProj::onAdd(%this){		%this.smoking = "1";%this.driver = 1;} //Vehicle::SetSmoke(%this);
function CoolProj::onAdd(%this){	%this.smoking = "1";%this.driver = 1;} //Vehicle::SetSmoke(%this);
function BooProj::onAdd(%this){		%this.smoking = "1";%this.driver = 1;} //Vehicle::SetSmoke(%this);
function EmpProj::onAdd(%this){		%this.smoking = "1";%this.driver = 1;} //Vehicle::SetSmoke(%this);
function GasProj::onAdd(%this){		%this.smoking = "1";%this.driver = 1;} //Vehicle::SetSmoke(%this);

function NapProj::onFire(%this)
{
	if (GameBase::setDamageLevel(%this, 10))
		if ($debug) echo ("BOOM");	
}
function ShortCoolProj::onFire(%this)
{
	if (GameBase::setDamageLevel(%this, 10))
		if ($debug) echo ("BOOM");
}
function CoolProj::onFire(%this)
{
	if (GameBase::setDamageLevel(%this, 10))
		if ($debug) echo ("BOOM");
}
function BooProj::onFire(%this)
{
	if (GameBase::setDamageLevel(%this, 10))
		if ($debug) echo ("BOOM");
}
function EmpProj::onFire(%this)
{
	if (GameBase::setDamageLevel(%this, 10))
		if ($debug) echo ("BOOM");
}
function GasProj::onFire(%this)
{
	if (GameBase::setDamageLevel(%this, 10))
		if ($debug) echo ("BOOM");
}
function SpyPodProj::onFire(%this)
{
	if (GameBase::setDamageLevel(%this, 10))
		if ($debug) echo ("BOOM");
}

function Aoe::deployShape(%object, %radius, %type, %dur, %cl, %dam) 
{
 	%pl = Client::getOwnedObject(%cl);
	if($TeamItemCountAOE[GameBase::getTeam(%object)] < $TeamItemMax[Aoe]) 
	{
		%camera = newObject("Camera","Turret",DeployableAoe,true);
		addToSet("MissionCleanup", %camera); 
		GameBase::setPosition(%camera,GameBase::getPosition(%object)); 
		GameBase::setTeam(%camera,GameBase::getTeam(%object)); 
		Gamebase::setMapName(%camera,"Dumb Thing");  
		%data = GameBase::getDataName(%camera);
		$TeamItemCountAOE[GameBase::getTeam(%object)]++; 
		schedule("GameBase::setDamageLevel("@%camera@", "@%data.maxDamage@");",%dur,%camera);
		schedule("$TeamItemCountAOE[" @ GameBase::getTeam(%object) @ "]--;",%dur-1,%camera); 
		schedule("AOE::check(\"" @ getBoxCenter(%object) @ "\","@%radius@"," @ %type @ "," @ %camera @ "," @ %cl @ "," @ %dam @ ");",0.5,%camera);
		return true;
	}
}

function AOE::check(%pos, %radius, %type, %object, %cl, %dam) 
{
	%pl = Client::getOwnedObject(%cl);
	%radiusA = %radius;

	//echo ("AOE = " @ %object);
	
	if (%type == $PlasmaDamageType)
	{
		DeployFrags(%object, 4, %pl);
		%radiusA = %radius / 3;
	}
	else if (%type == $EnergyDamageType)
	{
		%radiusA = 0;
	}

	else if (%type == $NukeDamageType)
	{	
		%object.fired++;
		if (%object.fired > 1)
		{
			%object.fired = "";
			return;
		}
		%vel = "0 0 0";

		%padd = "0 0 1";%pos = Vector::add(%pos, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %pl @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 0 2";%pos = Vector::add(%pos, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %pl @ "\", \"" @ %vel @ "\");",0.4);

		%padd = "0 0 0.2";%pos = Vector::add(%pos, %padd);
		%obj = newObject("","Mine","NRing1");addToSet("MissionCleanup", %obj);GameBase::throw(%object,%pl,0,false);
		gamebase::setposition(%obj, %pos);

		%padd = "0 0 1.5";%pos = Vector::add(%pos, %padd);
		%obj = newObject("","Mine","NRing1");addToSet("MissionCleanup", %obj);GameBase::throw(%object,%pl,0,false);
		gamebase::setposition(%obj, %pos);

		%padd = "0 0 3";%pos = Vector::add(%pos, %padd);
		%obj = newObject("","Mine","NRing1");addToSet("MissionCleanup", %obj);GameBase::throw(%object,%pl,0,false);
		gamebase::setposition(%obj, %pos);

	}


	if (%radiusA > 0)
	{
		%Set = newObject("aoeset",SimSet);
		%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;
		containerBoxFillSet(%Set, %Mask, %Pos, %radiusA, %radiusA, %radiusA, 0);
		%num = Group::objectCount(%Set);
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);
			GameBase::applyDamage(%obj, %type, %dam, GameBase::getPosition(%obj), "0 0 0", "0 0 0", %pl);		
		}
		if(%set)deleteobject(%set);
	}

	GameBase::applyRadiusDamage(%type, %pos, %radius, 0.01, 2, %object);
	%radius = %radius - (%radius * 0.10);
	%dam = %dam - (%dam * 0.10);

	schedule("AOE::check(\"" @ %pos @ "\"," @ %radius @ "," @ %type @ "," @ %object @ "," @ %cl @ "," @ %dam @ ");",1,%object);
	if ($debug) echo ("Apply Radial Damage");
}


TurretData DeployableAoe
{ 
	maxDamage = 100.0; 
	maxEnergy = 150; 
	minGunEnergy = 50; 
	maxGunEnergy = 5; 
	range = 10;  
	visibleToSensor = false; 
	dopplerVelocity = 0;
	castLOS = true; 
	supression = true;
	mapFilter = 2; 
	className = "ELF Turret";
	shapeFile = "breath"; 
	shieldShapeName = "shield"; 
	speed = 5.0;
	speedModifier = 1.5;
	reloadDelay = 0.3; 
	description = "";
	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn; 
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained     = true;  
	firingTimeMS    = 750;  
	energyRate      = 30.0;
}; 

function DeployableAoe::onAdd(%this)
{  
	schedule("DeployableAoe::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0;
}

function DeployableAoe::deploy(%this)
{ 
	GameBase::playSequence(%this,1,"deploy");
	GameBase::setActive(%this,true);
} 

function DeployableAoe::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableAoe::onDestroyed(%this)
{  
	GameBase::setActive(%this,false); 
	Turret::onDestroyed(%this);
	if(%this)deleteobject(%this);
} 

function DeployableAoe::onPower(%this,%power,%generator) {}

function DeployableAoe::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true); 
} 




