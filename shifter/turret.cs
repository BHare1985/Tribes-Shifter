// TURRET DYNAMIC DATA
//=============================================================================================================================
TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 100;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};
																						 
//=============================================================================================================================
TurretData ELFTurret	   
{			 
	maxDamage = 1.35;
	maxEnergy = 90;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge1;
	reloadDelay = 0;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = NoCrashGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

//=============================================================================================================================
TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 150;
	gunRange = 300;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	targetableFovRatio = 1.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
	}
	else
	{
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{

   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      	return "True";
   else
      	return "False";
}

//====================================================================================================
TurretData MortarTurret
{
	maxDamage = 1.25;
	maxEnergy = 200;
	minGunEnergy = 22;
	maxGunEnergy = 30;
	reloadDelay = 3.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = MortarTurretShell1;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};
//===================================================================================================
TurretData DeployableMortar
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = "MortarTurretShell1";
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 45;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 3.0;
	speed = 3.0;
	speedModifier = 1.5;
	range = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;

	explosionId = flashExpMedium;
	description = "Remote Mortar Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this)
{ 
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Mortar Turret");
	}
}

function DeployableMortar::deploy(%this)
{ 

	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMortar::onEndSequence(%this,%thread)
{ 
	GameBase::setActive(%this,true);
}

function DeployableMortar::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--;
}


//function DeployableMortar::onFire(%a, %b, %c, %d)
//{
//echo ("Mortar Turret");
//}

// Override base class just in case.
function DeployableMortar::onPower(%this,%power,%generator) {}
function DeployableMortar::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}	

 
function Sin(%theta) 
{

 	 return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}
 
function Cos(%theta) 
{

	 return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}
 
																						 
//========================================================================================================
TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";

};


//====================================================================================================== Ion Turret
TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = IonBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 55; // 30
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Ion Turret";
	damageSkinData = "objectDamageSkins";
	//validateShape = true;
	//validateMaterials = true;
};

function DeployableTurret::onAdd(%this)
{

	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableTurret::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {
}
function DeployableTurret::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//==================================================================================================== Plasma

TurretData DeployablePlasma
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FusionBolt;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Remote Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onAdd(%this)
{

	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plasma Turret");
	}
}

function DeployablePlasma::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasma::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function DeployablePlasma::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretPack"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//====================================================================================================== Laser Turret
TurretData DeployableLaser
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TurretLaser;
	maxDamage = 0.75;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaser::onAdd(%this)
{

	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Laser Turret");
	}
}

function DeployableLaser::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaser::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function DeployableLaser::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
}

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {
}
function DeployableLaser::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//========================================================================================================= Laser Mine
TurretData DeployableLaserM
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TurretLaser;
	maxDamage = 0.75;
	maxEnergy = 55;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 150.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = flase;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Point Defense Laser Mine";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaserM::onAdd(%this)
{
		DeployableLaserM::deploy(%this);
		GameBase::setEnergy(%this, 55);

	GameBase::setRechargeRate(%this,0.0);
	%this.shieldStrength = 0;
}

function DeployableLaserM::onCollision(%this,%object)
{
//	%type = getObjectType(%object);
//	%data = GameBase::getDataName(%this);
//	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
//			GameBase::isActive(%this)
//			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
//			) 
//		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DeployableLaserM::deploy(%this)
{
	schedule("deleteobject(" @ %this @ ");",$Shifter::LaserMineLive,%this);
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaserM::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableLaserM::onDestroyed(%this)
{
	GameBase::setDamageLevel(%this, %data.maxDamage);
	Turret::onDestroyed(%this);
}

function DeployableLaserM::onPower(%this,%power,%generator) {}

function DeployableLaserM::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,3);
	GameBase::setActive(%this,true);
}	


//===================================================================================================== EMP Turret
TurretData DeployableShock
{
	maxDamage = 1.5;
	maxEnergy = 110;
	minGunEnergy = 15;
	maxGunEnergy = 20;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 30;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield_medium";
	speed = 5.0;
	speedModifier = 1.50;
	projectileType = EMPShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "EMP Turret";

};

function DeployableShock::onAdd(%this)
{

	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,6);
	//%this.shieldStrength = 0;
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote EMP Turret");
	}
}

function DeployableShock::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployableShock::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function DeployableShock::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--;
}

// Override base class just in case.
function DeployableShock::onPower(%this,%power,%generator) {
}
function DeployableShock::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================ Satchel
TurretData DeployableSatchel
{
	className = "Turret";
	shapeFile = "grenammo";
	//projectileType = "Undefined";
	maxDamage = 0.01;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 0.0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	//fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	//explosionId = rocketExp;
	description = "Satchel Charge";
	damageSkinData = "objectDamageSkins";
};
function DeployableSatchel::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this)!=GameBase::getTeam(%object)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DeployableSatchel::onFire(%this)
{
	GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 20, 5.2, 305, %this);
}

function DeployableSatchel::onAdd(%this)
{
	schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this);
}

function DeployableSatchel::deploy(%this)
{

	//GameBase::playSequence(%this,1,"deploy");	
	DeployableSatchel::onEndSequence(%this);
}

function DeployableSatchel::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
		GameBase::setMapName (%this, "Satchel Charge");
}

function DeployableSatchel::onControl(%this)
{
	GameBase::applyRadiusDamage($DebrisDamageType, getBoxCenter(%this), 20, 5.2, 305, %this);
}

function DeployableSatchel::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	GameBase::applyRadiusDamage($DebrisDamageType, getBoxCenter(%this), 20, 5.2, 305, %this);

	//CalcRadiusDamage(%this,$DebrisDamageType,30,0.2,25,20,20,1.5,0.5,200,100);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}

function DeployableSatchel::onPower(%this,%power,%generator) {
}

function DeployableSatchel::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,0);
	GameBase::setActive(%this,true);
}	

//================================================================================================ Deployable Elf Turret
TurretData DeployableELFTurret
{			 
	className = "Turret";
	shapeFile = "chainturret";
	projectileType = turretCharge1;
	maxDamage = 1.35;
	maxEnergy = 90;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 45;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	speed = 15.0;
	speedModifier = 1.5;
	reloadDelay = 0;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = NoCrashGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

	    isSustained     = true;
	    firingTimeMS    = 750;
 	    energyRate      = 30.0;
};

function DeployableELFTurret::onAdd(%this)
{

	schedule("DeployableELFTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.01;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "ELF Turret");
}

function DeployableELFTurret::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function DeployableELFTurret::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function DeployableELFTurret::onDestroyed(%this)
{

  	Gamebase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableELF"]--;    
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

function DeployableELFTurret::onPower(%this,%power,%generator) {
}

function DeployableELFTurret::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}	

// =====================================================================================    End new Elf Turret Code

TurretData BarrageTurret
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = BarrageBolt;
	maxDamage = 1.5;
	maxEnergy = 350;
	minGunEnergy = 300;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 5;
	speedModifier = 4.1;
	range = 325;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1.5;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield_medium";
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	explosionId = flashExpMedium;
	description = "Anti-Aircraft Turret";
};

function BarrageTurret::onAdd(%this)
{	//czar weird shit
	schedule("BarrageTurret::deploy(" @ %this @ ");",now,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Anti-Aircraft Battery");
	}
}

function BarrageTurret::deploy(%this)
{

	GameBase::playSequence(%this,1,"deploy");
}

function BarrageTurret::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function BarrageTurret::onDestroyed(%this)
{

	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BarragePack"]--;
}

function BarrageTurret::onPower(%this,%power,%generator) {
}

function BarrageTurret::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.02;
}

function BarrageTurret::verifyTarget(%this,%target) // Don't shoot if they're not in a vehicle. :) Dewy.
{
	if (GameBase::virtual(%target, "getMountObject") >= 1)
	{
		%this.shieldStrength = 0.05;
		return "True";
	}
	else
	{
		%this.shieldStrength = 0.02;
		return "False";
	}
}



//======================================================================================================= Rocket 

TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 4.0;
	speedModifier = 1.5;
	range = 125;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "RMT Rocket Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableRocket::verifyTarget(%this,%target)
{
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
		return "True";
	else
		return "False";
}


function DeployableRocket::onAdd(%this)
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "RMT Rocket Turret");
	}
}

function DeployableRocket::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

function DeployableRocket::onPower(%this,%power,%generator){}
function DeployableRocket::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//========================================================================
TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	//projectileType = RepairBolt2;
	maxDamage = 0.75;
	maxEnergy = 75;
	minGunEnergy = 3;
	maxGunEnergy = 10;
	reloadDelay = 0.2;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Camera";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Camera");
	}
}

function CameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function CameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function CameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
	$TeamItemCount[GameBase::getTeam(%this) @ "EngBeacons"]--;  	
}	
function CameraTurret::onPower(%this,%power,%generator) {
}
function CameraTurret::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================== Arbitor code
// ============================== Thanks to Czar and Grey for their help debugging this code.
//===================  It truly took all three of us to get that crap straigtend out, lol
TurretData ArbitorBeacon
{
	className = "Turret";
	shapeFile = "plasammo";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = debrisExpSmall;
	description = "Arbitor Beacon";
	damageSkinData = "objectDamageSkins";
};

function ArbitorBeacon::onAdd(%this)
{
	schedule("ArbitorBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.check = 1;
}

function ArbitorBeacon::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function ArbitorBeacon::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function ArbitorBeacon::onDisabled(%this){}
function ArbitorBeacon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBeaconPack"]--;
}

function ArbitorBeacon::onPower(%this,%power,%generator) {}
function ArbitorBeacon::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	%this.check = 1;
   ArbitorBeacon::checkArbitorBeacon(%this);
}

function ArbitorBeacon::checkArbitorBeacon(%this)
{
	if(!%this.check)
		return;

	%Set = newObject("arbbset",SimSet);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);
	
	//======================================== Check Items In Box
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%datab = GameBase::getDataName(%obj);
		%objn = (getObjectType(%obj));

		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this || %datab == "ArbitorBeacon"){}
		else if (!%this.cloaked)
		{
			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1;
			schedule ("GameBase::startFadeIn(" @ %obj @ ");",6);
			schedule (%obj @ ".cloaked = 0;",6);
		}

//-------  What Grey Would use   ------
//
//		if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) || %obj == %this || %datab == "ArbitorBeacon"){}
//		else if (!%this.cloaked)
//		{
//			Player::setDetectParameters(%player, 1000, 3000);
//			schedule ("Player::setDetectParameters("@ %player @", 0.027, 0);",6);
//		}

	}
	if(%set)deleteobject(%set);

	schedule("ArbitorBeacon::checkArbitorBeacon(" @ %this @ ");", 6.0, %this); //then recheck in 6 seconds
}

//============================================================================================= EMP Beacon

TurretData EMPBeacon
{

	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "EMP Beacon";
	damageSkinData = "objectDamageSkins";
};

function EMPBeacon::onAdd(%this)
{

	schedule("EMPBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "EMP Box");
	}
}

function EMPBeacon::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function EMPBeacon::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function EMPBeacon::onDisabled(%this) { Turret::onDisabled(%this); }
function EMPBeacon::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "EMPBeaconPack"]--; }
function EMPBeacon::onPower(%this,%power,%generator) {}
function EMPBeacon::onEnabled(%this) { schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 0.1, %this); }	

function EMPBeacon::checkEMPBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("empset",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //$StaticObjectType
	
	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);
	
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (getObjectType(%obj) == "Player" && (Player::getArmor(%obj) == "spyarmor" || Player::getArmor(%obj) == "spyfemale"))  //Player::getMountedItem(%obj,$BackpackSlot) == FlightPack || 
		{ //nothing
		}
		else if(%obj != %this && GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			GameBase::applyDamage(%obj,$FlashDamageType, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);		
			schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		}
	}
	if(%set)deleteobject(%set);
	schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 10.0, %this); //then recheck in 10 seconds
}

//============================================================================================= Shield Beacon
TurretData ShieldBeacon
{
	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Shield Beacon";
	damageSkinData = "objectDamageSkins";
};

function ShieldBeacon::onAdd(%this) { schedule("ShieldBeacon::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); if (GameBase::getMapName(%this) == "")  { GameBase::setMapName (%this, "Shield Box"); } }
function ShieldBeacon::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function ShieldBeacon::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function ShieldBeacon::onDisabled(%this) { Turret::onDisabled(%this); }
function ShieldBeacon::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ShieldBeaconPack"]--; }
function ShieldBeacon::onPower(%this,%power,%generator) {}
function ShieldBeacon::onEnabled(%this) { schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 0.1, %this); }	

function ShieldBeacon::checkShieldBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%Set = newObject("shieldset",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$SimInteriorObjectType;
	
	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);
	
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%armor = Player::getArmor(%obj);

		if(%obj != %this && (GameBase::getTeam(%obj) == GameBase::getTeam(%this) || %armor == "spyarmor" || %armor == "spyfemale"))
		{
			if(getObjectType(%obj) == "player")
				%obj.shieldStrength = 0.024;
			else
				%obj.shieldStrength = 0.018;
			schedule ("" @ %obj @ ".shieldStrength = 0.0 ;",15);

		}
	}
	if(%set)deleteobject(%set);
	schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 15.0, %this);
}
//============================================================================================= Jammer Beacon
TurretData JammerBeacon
{
	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Jammer Beacon";
	damageSkinData = "objectDamageSkins";
};

function JammerBeacon::onAdd(%this) {schedule("JammerBeacon::deploy(" @ %this @ ");",1,%this);GameBase::setRechargeRate(%this,5); if (GameBase::getMapName(%this) == "")  { GameBase::setMapName (%this, "Jammer Box"); } }
function JammerBeacon::deploy(%this){GameBase::playSequence(%this,1,"deploy");}
function JammerBeacon::onEndSequence(%this,%thread){GameBase::setActive(%this,true);}
function JammerBeacon::onDisabled(%this) { Turret::onDisabled(%this); %this.broke = "1"; }
function JammerBeacon::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "JammerBeaconPack"]--; }
function JammerBeacon::onPower(%this,%power,%generator) {}
function JammerBeacon::onEnabled(%this) {%this.broke = "0"; schedule("JammerBeacon::checkJammerBeacon(" @ %this @ ");", 0.1, %this); }
function JammerBeacon::checkJammerBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		GameBase::setDamageLevel(%this, 20);

	%Set = newObject("jammerset",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 150, 150, 150,0);
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);

		if ( %data == "DeployableSensorJammer" && gamebase::getteam(%obj) != gamebase::getteam(%this) )
		{
			GameBase::applyDamage(%this, $ImpactDamageType, 0.37,GameBase::getPosition(%obj),"0 0 0","0 0 0",%obj);
			return;
		}
	}
	
	%i = "";
	%obj = "";

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);
		
		if (%data == "CoolProj" || %data == "NapProj" || %data == "BooProj" || %data == "EmpProj" || %data == "GasProj")
		{
			if (gamebase::getteam(%this) != gamebase::getteam(%obj))
			{
				%obj.popped = "1";
				if ($debug) echo ("POPPED " @ %obj.popped);
				
				%rot = gamebase::getrotation(%obj);
				%dir = (Vector::getfromrot(%rot));
				%vel = item::getvelocity(%obj);
				%trans =  %rot @ " " @ %dir @ " " @ %dir @ " " @ gamebase::getposition(%obj);
				%fired = Projectile::spawnProjectile(DeadRocket, %trans ,%obj,%vel);
				GameBase::setDamageLevel(%obj, 1000);
				GameBase::applyDamage(%this, $ImpactDamageType, 0.10,GameBase::getPosition(%obj),"0 0 0","0 0 0",%obj);
			}
		}
	}
	
	if(%set)deleteobject(%set);
	
	if (%this.broke == "0")
	{
		schedule("JammerBeacon::checkJammerBeacon(" @ %this @ ");", 0.1, %this);
	}
	//else
	//{
	//	GameBase::setDamageLevel(%this, 20);
	//}
}

//========================================================================================================================
// 					Standard Turret Functions For Shifter.
//========================================================================================================================

function Turret::onAdd(%this)
{
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Turret");
	}
}

function Turret::onActivate(%this)
{
	GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
		Turret::checkOperator(%this);
}

function Turret::checkOperator(%this)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
		Client::setControlObject(%cl, %pl);
	}
	Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{

	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else
	{
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if (GameBase::isPowered(%this))
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

function Turret::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);

	//greyflcn
	//if ($origTeam[%this] == "0" || $origTeam[%this] == "1" || $origTeam[%this] > 1)
	//{
	//	schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", 2);
	//	if ($debug) echo (" THIS =  " @ %this @ " reverted back to its original team " @ $origTeam[%this] @ "." );
	//}
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100); 
	if(%this > 3000)
	{
			$dlist = string::greplace($dlist, %this, "");
			//echo("Killing Turret:" @ %this);
			//echo($dlist);
	}
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	
	if(%type == $GravDamageType)return;
	if (%type == $FlashDamageType)
	{
		%value = (%value * 0.50);
		%energy = (GameBase::getEnergy(%this) - 50);
		GameBase::setEnergy(%this, %energy);
	}
	//else if (%type == $SniperDamageType || %type == $LaserDamageType)
	//{
	//	%value = (%value * 0.60);
	//}
	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);

		if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHolo && %name != DeployableHolo2 && %name != DeployableHolo3 && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableShock)	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
	if (GameBase::getMapName == "Satchel Charge")
	{
		GameBase::applyDamage(%this,$DebrisDamageType,20,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
}

function Turret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

function Turret::onCollision (%this, %object)
{
	%c = Player::getClient(%object);
	%client = Player::getClient(%object);
	%playerTeam = GameBase::getTeam(%object);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%client);
	%player.repairTarget = %this;
	%name = GameBase::getMapName(%this);
	%team = GameBase::getTeam(%this);
	%pTeam = GameBase::getTeam(%object); //added
	%pName = Client::getName(%client); //added
	%tName = getTeamName(%team); //added
	%damageLevel = GameBase::getDamageLevel(%this);
	%disable = GameBase::getDisabledDamage(%this);

	if(getObjectType(%object) == "Player" && %damagelevel >= %disable && %team == %pteam)
	{
		Client::sendMessage(%client,1,"Unit is not powered or disabled.");
	}

	if(%team == %pTeam)
	{
		return;
	}
	
	if($origTeam[%this] == "")
	{
		$origTeam[%this] = %team;
	}		
	
	if (%client.Laptop == "True" && (%armor == "spyarmor" || %armor == "spyfemale" || %armor == "earmor" || %armor == "efemale"))
	{
		if (%client.HackPack == True)
		{
			if ($debug) echo ("Controlling");
			if(getObjectType(%object) != "Player")
			{
				return;
			}
			if(Player::isDead(%object))
			{
				return;
			}
			if(%this.disabled == true)
			{
				Client::SendMessage(%c,0,"Turret is recharging");
				return;
			}
			if(%teleTeam != %playerTeam)
			{
				if( ((Player::getArmor(%object) == "spyarmor") || (Player::getArmor(%object) == "spyfemale")) && (Player::getMountedItem(%object,$BackpackSlot) == Laptop) )
				{
					%name = GameBase::getDataName(%this);

					if(%name == "RocketTurret" || %name == "PlasmaTurret" || %name == "IndoorTurret" || %name == "ELFTurret" || %name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name ==DeployableRail || %name == MortarTurret)
					{
						if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
						{
							Client::getOwnedObject(%client).CommandTag = 1;
							Client::sendMessage(%client,0,"Re-programming turret");
							GameBase::setTeam (%this,GameBase::getTeam (%client));
							schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Shifter::HackedTime);
							schedule("" @ %this @ ".disabled = false;", $Shifter::HackedTime);
							Client::takeControl(%client, %this);
							%this.Disabled = true;
							Client::getOwnedObject(%client).CommandTag = "";
							if(%name == DeployablePlasma || %name ==  DeployableRail ) GameBase::SetPosition(%object,GameBase::GetPosition(%this));
							
							TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
							TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");

							return;
						}
					}
				}
				return;
			}
			if((Player::getArmor(%obj) == "efemale") || (Player::getArmor(%obj) == "earmor"))
			{
				%name = GameBase::getDataName(%this);
				if(%name == DeployableRail)
				{
					if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
					{
						Client::getOwnedObject(%client).CommandTag = 1;
						Client::sendMessage(%client,0,"Manually controlling turret");
						schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Shifter::HackedTime);
						schedule("" @ %this @ ".disabled = false;", $Shifter::HackedTime);
						Client::takeControl(%client, %this);
						GameBase::SetPosition(%object,GameBase::GetPosition(%this));
						%this.Disabled = true;
						Client::getOwnedObject(%client).CommandTag = "";
						return;
					}
				}
			}
		}
		else	//== Hack Pack Allows You To Hack Enemy Stuff! Not Just take control of turrets
		{
			if (%client.hacking == "True")
			{
				return;
			}
			
			if($Shifter::AllowHacking)
			{	
				%target = %this;
				if (%target != %player)
				{
					if(%name == "")
					{
						%name = (GameBase::getDataName(%player.repairTarget)).description;
					}

					%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

					%client.hacking = "true";
					if(!$origTeam[%target])
					{
						$origTeam[%target] = %team;
					}					
				
					hackingturret(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
				}	
			}
			else
			{
				Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
			}
		}
	}
}

function Turret::Reenable(%this)
{
	%this.disabled = false;
}

function hackingturret(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	if(%time > 0)
	{
		Client::sendMessage(%client,0,"Hacking In Progress - Time Remaining " @ %time);
		if(%client.hacking)
		{		
			schedule("hackingturret('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		Client::sendMessage(Player::getClient(%client),0,("Finished In " @ %time @ "."));

		if (%client.Laptop == "True")
		{		
			if(%client.hacking)
			{				
			
				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);	

					if (%rnd > 50)
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						if ($debug) echo (%player);
						Player::blowUp(%this);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						return;
					}
				}
				else
				{

					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);

					if($Shifter::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackedTime);
					}
					else
					{
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackLock);					
					}

					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}

				}
				if ($debug) echo ("Client Hacking Off");
				%client.hacking = "false";
			}
		}
	}
}

function Turret::Jump (%this, %object)
{
	%client = GameBase::getControlClient(%this);
	%name = GameBase::getDataName(%this);
	%player = Client::getOwnedObject(%client);
	if(!%Player.refire)
	{
		%Player.refire = 1;
		schedule(""@ %Player @ ".refire = 0;", 1.0);
	}
	else
		return;
	if(%name == DeployableCoolMortar)
	{
		if(%this.load != "")
		{
			Player::unMountItem(%client,$WeaponSlot);
			
			%trans = GameBase::getMuzzleTransform(%this);
			$Faky = %this;
			$Faky2 = GameBase::getPosition(%this);
			Projectile::spawnProjectile("Faker",%trans,%this,"0 0 0");
		}
		else
		{
			Client::sendMessage(%client,0,"Missile Turret is not loaded.");
		}
	}
	else
	{
		remoteCommandMode(%client);
		remotePlayMode(%client);
	}
}

//====== Flamer Turret
TurretData FlamerTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = FlamerTurretBolt;
	
	maxDamage = 1.75;
	maxEnergy = 150;
	minGunEnergy = 10;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 9.0;
	speedModifier = 1.0;
	range = 55; // 30
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Flame Turret";
	damageSkinData = "objectDamageSkins";
};

function FlamerTurret::onAdd(%this)
{
	schedule("FlamerTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.01;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flamer Turret");
	}
}

function FlamerTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function FlamerTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function FlamerTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlamerTurretPack"]--;
}

// Override base class just in case.
function FlamerTurret::onPower(%this,%power,%generator) {}
function FlamerTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

TurretData DeployableLaserM2
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TurretLaser;
	maxDamage = 0.75;
	maxEnergy = 55;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 150.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = flase;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Point Defense Laser Mine";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaserM2::onAdd(%this)
{
	schedule("DeployableLaserM2::deploy(" @ %this @ ");",1,%this);
	schedule("GameBase::setEnergy(" @ %this @ ", 55);",1,%this);
	GameBase::setEnergy(%this, 0);
	GameBase::setRechargeRate(%this,0.0);
	%this.shieldStrength = 0;
}

function DeployableLaserM2::onCollision(%this,%object)
{
//	%type = getObjectType(%object);
//	%data = GameBase::getDataName(%this);
//	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
//			GameBase::isActive(%this)
//			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
//			) 
//		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DeployableLaserM2::deploy(%this)
{
	schedule("deleteobject(" @ %this @ ");",$Shifter::LaserMineLive,%this);
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaserM2::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableLaserM2::onDestroyed(%this)
{
	GameBase::setDamageLevel(%this, %data.maxDamage);
	Turret::onDestroyed(%this);
}

function DeployableLaserM2::onPower(%this,%power,%generator) {}

function DeployableLaserM2::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,3);
	GameBase::setActive(%this,true);
}	

