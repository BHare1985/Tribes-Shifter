$ImpactDamageType      = -1;
$LandingDamageType     =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;	//=== Poison Effect
$PlasmaDamageType      =  3;	//=== On Fire Damage
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$SniperDamageType      = 14;	//=== Drop Weapon-Flag Damage
$FlashDamageType       = 15;	//=== EMP Damage
$GravDamageType	     = 20;
$ShellDamageType       = 21;
$CloakDamageType       = 22;
$NukeDamageType        = 23;
$FlameDamageTpye       = 24;	
$LRifleDamageType		  = 25;
$RifleDamageType  	  = 26;
$EqualizerDamageType   = 27;
$OverDoseDamageTpye    = 28;
$IDamageType	        = 29;
$TargetingDamageType	  = 30;
$BoomStickDamageType	  = 31;
$HBlasterDamageType	  = 32;
$MDMDamageType	  		  = 33;




//Globals
$hacking[%client] = "false";
$Viral = "false";
$isInfected[0] = "false";
$origTeam[0] = "-1";
$minHacked = "-1";
$maxHacked = "-1";
$minInfected = "-1";
$minInfected = "-1";

if ($Shifter::HackTime == "")
	$Shifter::HackTime = "5";

if ($Shifter::HackedTime == "")
	$Shifter::HackedTime = "90";

if ($Shifter::HackLock == "")
	$Shifter::HackedLock = "0";

if ($Shifter::AllowHacking == "")
	$Shifter::AllowHacking = True;

if (!$Shifter::LaserMineLive || $Shifter::LaserMineLive == "")
	$Shifter::LaserMineLive = 2;

//================================================================================================
//						    Bullet Class Ammos
//================================================================================================


//======================================================================== Interceptor Ammo 
BulletData InterceptorAmmo
{
	bulletShapeName    = "tumult_small.dts";
	explosionTag       = debrisExpsmall;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.5;
	mass               = 1.0;
	elasticity         = 0.45;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.7;
	damageType         = $IDamageType;

	explosionRadius    = 1.25;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 250;
	liveTime           = 0.2;
	projSpecialTime    = 0.05;

	aimDeflection      = 0.002;
	muzzleVelocity     = 100.0;
	totalTime          = 1.0;
	inheritedVelocityScale = 2.0;
	isVisible          = False;

	tracerPercentage   = 1.0;
	tracerLength       = 75;
};



//======================================================================== ChainGun
BulletData ChaingunBullet1
{
	bulletShapeName    = "tumult_small.dts";
	explosionTag       = debrisExpsmall;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.5;
	mass               = 1.0;
	elasticity         = 0.45;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.37;
	damageType         = $EqualizerDamageType;

	explosionRadius    = 2.5;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 150;
	liveTime           = 1.5;
	projSpecialTime    = 0.05;

	aimDeflection      = 0.005;
	muzzleVelocity     = 200.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 2.0;
	isVisible          = False;

	tracerPercentage   = 1.0;
	tracerLength       = 45;
};

//======================================================================== Sniper Bullet
BulletData SniperBullet1
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	mass               = 0.05;
	collisionRadius    = 0.0;
	bulletHoleIndex    = 0;
	damageClass        = 0;
	damageValue        = 0.79;
	damageType         = $SniperDamageType;
	aimDeflection      = 0.0;
	muzzleVelocity     = 3500.0;
	totalTime          = 1;
	inheritedVelocityScale = 0.0;
	isVisible          = false;
	tracerPercentage   = 100.0;
	tracerLength       = 25;
};


//======================================================================== Silencer - Magnum
//Contributed by Czar :), and edited
BulletData SilencerBullet
{
	//bulletShapeName    = "plasmabolt.dts";
	bulletShapeName    = "bullet.dts";
	explosionTag       = debrisExpsmall;
	expRandCycle       = 0;
	mass               = 200.0;
	bulletHoleIndex    = 0;
	damageClass        = 0;
	damageValue        = 1.02;
	damageType         = $BulletDamageType;
	muzzleVelocity     = 700.0;
	aimDeflection      = 0.0;
	totalTime          = 0.09;
	inheritedVelocityScale = 0.9;
	isVisible          = True;
	kickBackStrength = 900.0; 
	tracerPercentage   = 99.0;
	tracerLength       = 46;
	explosionRadius    = 0.03;
	collisionRadius    = 0.03;
};

//======================================================================== Tranq Dart
BulletData TranqDart
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.20;
	damageType         = $EnergyDamageType;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = True;
	tracerPercentage   = 100.0;
	tracerLength       = 30;
};

//======================================================================== Vulcan Bullet
BulletData VulcanBullet
{
	bulletShapeName    = "breath.dts"; //bullet
	explosionTag       = quietbulletExp0;
	expRandCycle       = 3;
	mass               = 0.06;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.04;
	damageType         = $BulletDamageType;
	aimDeflection      = 0.007;
	muzzleVelocity     = 900.0;
	totalTime          = 0.95;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	tracerPercentage   = 3.0;
	tracerLength       = 3;
};

//======================================================================== BoomStickBlast
BulletData BoomStickBlast
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.10;
	damageType         = $BoomStickDamageType;
	aimDeflection      = 0.029;
	muzzleVelocity     = 200.0;
	totalTime          = 1;
	inheritedVelocityScale = 0.3;
	isVisible          = False;
	tracerPercentage   = 2.0;
	tracerLength       = 10;
	soundId = SoundJetLight;
};

//======================================================================== Jet Bullet
BulletData JetBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.10;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 100.0;
   tracerLength       = 30;
};

//======================================================================== Fusion Bolt
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//======================================================================== MiniFusionBolt
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Blaster Bolt
BulletData BlasterBolt1
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.200;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Hyper Bolt
BulletData HyperBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = hblasterExp;

   damageClass        = 0;
   damageValue        = 0.05;
   damageType         = $HBlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 1.0;
   liveTime           = 0.13;

   lightRange         = 3.0;
   lightColor         = { 0.3, 1.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Jet Bolt
BulletData JetBolt
{
    bulletShapeName    = "bullet.dts";
    explosionTag       = bulletExp0;
    expRandCycle       = 3;
    mass               = 0.05;
    bulletHoleIndex    = 0;
   
    damageClass        = 0;       // 0 impact, 1, radius
    damageValue        = 0.04;
    damageType         = $BulletDamageType;
  
    aimDeflection      = 0.002;
    muzzleVelocity     = 900.0;
    totalTime          = 2;
    inheritedVelocityScale = 2.0;
    isVisible          = False;
   
    tracerPercentage   = 2.0;
    tracerLength       = 160;
};

//======================================================================== Plasma Bolt
BulletData PlasmaBolt					//=== Standard
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = plasmaExp;

	damageClass        = 1;
	damageValue        = 0.45;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 3.0;

	muzzleVelocity     = 65.0;
	totalTime          = 1.0;
	liveTime           = 0.35;
	lightRange         = 3.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	soundId = SoundJetLight;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 3.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaBolt2					//=== With Trial
{
	bulletShapeName  = "plasmabolt.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;

	damageClass      = 1;
	damageValue      = 0.65;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 6.0;
	kickBackStrength = 0;
	
	muzzleVelocity   = 60.0;
	terminalVelocity = 60.0;
	acceleration     = 60.0;
	totalTime        = 1.7;
	liveTime         = 0.7;
	lightRange       = 1.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

//======================================================================== Plasma Bolt Multi
BulletData PlasmaBoltMulti
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = plasmaExp;

	damageClass        = 1;
	damageValue        = 0.32;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 1.5;

	muzzleVelocity     = 225.0;
	totalTime          = 1.25;
	liveTime           = 0.175;
	lightRange         = 2.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	soundId = SoundJetLight;
};


//======================================================================== Plasma Bolt Rapid
BulletData PlasmaBoltRapid
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = plasmaExp;

	damageClass        = 1;
	damageValue        = 0.42;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 2.0;

	muzzleVelocity     = 180.0;
	totalTime          = 2.0;
	liveTime           = 0.1;
	lightRange         = 3.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid2
BulletData PlasmaBoltRapid2
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = plasmaExp;

	damageClass        = 1;
	damageValue        = 0.35;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 2.0;

	muzzleVelocity     = 120.0;
	totalTime          = 2.0;
	liveTime           = 1.3;
	lightRange         = 3.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	soundId = SoundJetLight;
};

//======================================================================== Booster Fire
RocketData Booster
{
	bulletShapeName  = "plasmaex.dts";
   	explosionTag  = boosterExp;
	collisionRadius  = 0.0;
	collideWithOwner = False;

	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 0.0;
	kickBackStrength = 0.0;
	
	muzzleVelocity   = 5.0;
	terminalVelocity = 5.0;
	acceleration     = 5.0;
	totalTime        = 0.55;
	liveTime         = 0.55;
	lightRange       = 3.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 0;
	trailString = "plasmaex.dts";
	smokeDist   = 5.0;
	soundId = NoCrashJetHeavy;
};

//======================================================================== Flamer Bolt
RocketData FlamerBolt
{
	bulletShapeName  = "plasmabolt.dts";
   	explosionTag       = flamerExp;  //plasmaexp
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.26;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 0;
	
	muzzleVelocity   = 30.0;
	terminalVelocity = 30.0;
	acceleration     = 30.0;
	totalTime        = 1.0;
	liveTime         = 1.0;
	lightRange       = 1.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmaex.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

//======================================================================== Flamer Turret Bolt
RocketData FlamerTurretBolt
{
	bulletShapeName  = "plasmaex.dts";
   //	explosionTag       = flamerExp;//plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.1;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 0;
	
	muzzleVelocity   = 30.0;
	terminalVelocity = 30.0;
	acceleration     = 30.0;
	totalTime        = 0.71;
	liveTime         = 0.69;
	lightRange       = 3.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmaex.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

//======================================================================== HellFire Bullets
BulletData HellFireBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = plasmaExp;

	damageClass        = 1;
	damageValue        = 0.10;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 5.0;

	aimDeflection      = 0.007;
	muzzleVelocity     = 155.0;
	totalTime          = 2.0;
	liveTime           = 2.0;
	lightRange         = 3.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	rotationPeriod = 1;

	soundId = SoundJetLight;
};

//========================================================================
//						    Missile Class Ammos
//========================================================================

SeekingMissileData BarrageBolt
{
	bulletShapeName  = "tracer.dts";
	explosionTag     = flashExpMedium;
	collisionRadius  = 0.0;
	mass             = 1.5;

	damageClass      = 1;
	damageValue      = 0.25;
	damageType       = $MissileDamageType;

	explosionRadius  = 4.0;
	kickBackStrength = 10.0;
	muzzleVelocity   = 50.0;
	terminalVelocity = 210.0;
	acceleration     = 400.0;
	totalTime        = 20.0;
	liveTime         = 21.0;
	seekingTurningRadius = 1;
	nonSeekingTurningRadius = 1.1;
	proximityDist 	 = 1.9;
	smokeDist 	 = 0.5;
	lightRange       = 1.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
function BarrageBolt::verifyTarget(%target, %this) { return "True"; }


//========================================================== Sniper Round
RocketData SniperRound1
{
	bulletShapeName  = "bullet.dts";
	explosionTag     = bulletExp0;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 0;
	damageValue      = 0.79;
	damageType       = $SniperDamageType;
	explosionRadius  = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity   = 3500.0;
	terminalVelocity = 3500.0;
	acceleration     = 500.0;
	totalTime        = 10.0;
	liveTime         = 11.0;
	lightRange       = 10.0;
	lightColor       = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

//============================================================ Disc Shell
RocketData DiscShell2
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;
   damageValue      = 0.51;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 200.0;

   muzzleVelocity   = 175.0;
   terminalVelocity = 4000.0;
   acceleration     = 30.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

RocketData DiscShell1
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;
   damageValue      = 0.6;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 200.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};



//========================================================= Flier Rocket
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
	collideWithOwner   = False;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $MissileDamageType;

   explosionRadius  = 12.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 90.0;
   terminalVelocity = 130.0;
   acceleration     = 15.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//======================================================================== Turret Missile
SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;
   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   soundId = SoundJetHeavy;
};

function TurretMissile::OnAdd(%this)
{
	echo(GameBase::getTeam(%object));
}

function SeekingMissile::updateTargetPercentage(%target)
{
	return rocketDodge(%target);
}

function TurretMissile::updateTargetPercentage(%target)
{
	return rocketDodge(%target);
}

function rocketDodge(%target)
{
	%armor = Player::getArmor(%target);
	if(%armor == "spyarmor" || %armor == "spyfemale")
		%tp = 0;
	else if(Player::getSensorSupression(%target) > 0)
		%tp = 0;
	else
		%tp = GameBase::virtual(%target, "getHeatFactor");
	return %tp;
}

//======================================================================== Shock Blast
RocketData Shock
{
   bulletShapeName  = "shield.dts";
   explosionTag     = ShockwaveFour;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.15;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
   trailType   = 2;
   trailString = "shield.dts";
   smokeDist   = 1.8;
   soundId = SoundJetHeavy;
};

//======================================================================== Turret Shock

RocketData TurretShock
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;
   damageValue      = 0.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 450.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//======================================================================== Rail Round

RocketData RailRound
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;
   damageValue      = 0.80;
   damageType       = $BulletDamageType;

   explosionRadius  = 0.3;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;

   trailType   = 1;         
   trailLength = 3000;
   trailWidth  = 0.6;
  
   soundId = SoundJetHeavy;
};


//======================================================================== Mini-Locking Missle 
SeekingMissileData MiniMissileTracker 
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.5;
	damageType = $MissileDamageType;
	explosionRadius = 10.0;
	kickBackStrength = 100.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 1000.0;
	acceleration = 200.0;
	totalTime = 15.0;
	liveTime = 15.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 3.6;
	nonSeekingTurningRadius = 3.6;
	proximityDist = 0.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	smokeDist = 4.5;
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
function MiniMissileTracker::updateTargetPercentage(%target)
{
	return 0;
}
//======================================================================== Mini-Locking Missle 
SeekingMissileData MalFunc
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.4;
	damageType = $MissileDamageType;
	explosionRadius = 5.0;
	kickBackStrength = 300.0;
	muzzleVelocity = 45.0;
	terminalVelocity = 175.0;
	acceleration = 75.0;
	totalTime = 15.0;
	liveTime = 15.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 3.6;
	nonSeekingTurningRadius = 3.6;
	proximityDist = 0.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	smokeDist = 65.5;
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
function MalFunc::updateTargetPercentage(%target)
{
	return rocketDodge(%target);
}
//======================================================================== Locking Missle 
SeekingMissileData StingerMissileTracker 
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.6;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 220.0;
	muzzleVelocity = 45.0;
	terminalVelocity = 60.0;
	acceleration = 15.0;
	totalTime = 4.0;
	liveTime = 21.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 1.0;
	nonSeekingTurningRadius = 1.1;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	trailType = 2;
	trailString = "plasmatrail.dts";
	//smokeDist = 2.5;
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
function StingerMissileTracker::updateTargetPercentage(%target)
{
	return rocketDodge(%target);
}


//======================================================================== Locking Missle 
SeekingMissileData JuggStingerMissileTracker 
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.8;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 220.0;
	muzzleVelocity = 45.0;
	terminalVelocity = 60.0;
	acceleration = 15.0;
	totalTime = 4.0;
	liveTime = 21.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 5.0;
	nonSeekingTurningRadius = 6.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	trailType = 2;
	trailString = "plasmatrail.dts";
	//smokeDist = 2.5;
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

//======================================================================== Stinger Missile
RocketData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.50;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 12.5;
   kickBackStrength = 100.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;
   trailType   = 2;
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;
   soundId = SoundJetHeavy;
};

//=============================================================== Juggernaught Stinger Missile
RocketData JuggStingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.55;
   damageType       = $ExplosionDamageType;

	explosionRadius  = 15.0;
	kickBackStrength = 80.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;
	trailType   = 1;
	trailLength = 30;
	trailWidth  = 1.45;
   soundId = SoundJetHeavy;
};

//======================================================================== GodHammer Missile
RocketData GodHammer
{
	bulletShapeName = "rocket.dts";
	explosionTag    = GH1Exp;//rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.45;
	damageType       = $ExplosionDamageType;
	explosionRadius  = 8;
	kickBackStrength = 80;
	muzzleVelocity   = 50.0;
	terminalVelocity = 750.0;
	acceleration     = 150.0;
	totalTime        = 4.5;
	liveTime         = 9.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.75;
	trailType   = 1;
	trailLength = 5;
	trailWidth  = 0.45;
	//soundId = SoundJetHeavy;
	rotationPeriod = 0.5;
};

RocketData GodHammerQuiet
{
	bulletShapeName = "rocket.dts";
	explosionTag    = GH2Exp;//rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.45;
	damageType       = $ExplosionDamageType;
	explosionRadius  = 8;
	kickBackStrength = 80;
	muzzleVelocity   = 50.0;
	terminalVelocity = 750.0;
	acceleration     = 150.0;
	totalTime        = 4.5;
	liveTime         = 9.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.75;
	trailType   = 1;
	trailLength = 5;
	trailWidth  = 0.45;
	//soundId = SoundJetHeavy;
	rotationPeriod = 0.5;
};

//======================================================================== DeadRocket
GrenadeData DeadRocket
{
	bulletShapeName    = "rocket.dts";
	explosionTag       = shockwave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 400.0;
	elasticity         = 0.01;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.25;
	damageType         = $ImpactDamageType;

	explosionRadius    = 15.0;
	kickBackStrength   = -10.0;
	maxLevelFlightDist = 75;
	totalTime          = 30.0;
	liveTime           = 2.0;
	projSpecialTime    = 0.01;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0;
	smokeName        = "rsmoke.dts";

};

//======================================================================== GodHammer Wire Guided Missle
GrenadeData GodHammerMortar
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 650;
   collisionRadius    = 2.5;
   mass               = 200.0;
   elasticity         = 0.55;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 75;
   totalTime          = 2.0;
   liveTime           = 2.0;
   projSpecialTime    = 2.0;
   inheritedVelocityScale = 0.1;
};


function GodHammerMortar::OnAdd(%this) { schedule("GodHammerMortar::Release(" @ %this @ ");", 0.5); }
function GodHammerMortar::Release(%this)
{
	%client = %this.deployer;
	%player = Client::GetOwnedObject(%client);
	%rot = gamebase::getrotation(%player);
	%dir = (Vector::getfromrot(%player));
	%vel = item::getvelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);	
	%t0 = getword (%trans, 0); %t1 = getword (%trans, 1); %t2 = getword (%trans, 2); %t3 = getword (%trans, 3); %t4 = getword (%trans, 4); %t5 = getword (%trans, 5); %t6 = getword (%trans, 6); %t7 = getword (%trans, 7); %t8 = getword (%trans, 8);
	%trans = %t0 @ " " @ %t1 @ " " @ %t2 @ " " @ %t3 @ " " @ %t4 @ " " @ %t5 @ " " @ %t6 @ " " @ %t7 @ " " @ %t8 @ " " @ gamebase::getposition(%this);
	playSound(SoundMissileTurretFire,GameBase::getPosition(%this));	
	%fired = Projectile::spawnProjectile(GodHammer, %trans ,%player,%vel);
	%fired.deployer = %client;
	%fired.spawn = %this.spawn + 1;
	%fired.pos = gamebase::getposition(%fired);
	%this.distance = Vector::getDistance(%this.pos, %fired.pos);
	
	if (%fired.spawn < 50 && %this.distance > 8)
	{
		schedule("GodHammerMortar::Release(" @ %fired @ ");", 0.25);
	}
	if(%this) deleteobject(%this);
}


//========================================================================  Ion Bolt
RocketData IonBolt
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0;
	mass = 2.0; 
	damageClass = 1;
   damageValue = 0.25; 
	damageType = $ElectricityDamageType; 
	explosionRadius = 4; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 
	terminalVelocity = 2000.0;
	acceleration = 500.0; 
	totalTime = 0.5; 
	liveTime = 0.3; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.2; 
	trailType = 1;
	trailLength = 250; 
	trailWidth = 0.9; 
	soundId = SoundJetHeavy;
};

RocketData IonGunBolt
{ 
	bulletShapeName = "fusionbolt.dts";//"enbolt.dts";
		explosionTag = IonGunExp;//turretExp; 
	collisionRadius = 0.0;
	mass = 2.0; 

	damageClass = 1;
   damageValue = 0.23; 
	damageType = $ElectricityDamageType; 
	explosionRadius = 4.0; 
	kickBackStrength = 0; 
	muzzleVelocity   = 200.0;
	terminalVelocity = 200.0;
	acceleration     = 0.0;
	totalTime        = 1.7;
	liveTime         = 0.7;
	lightRange = 1.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.0;
	trailType = 1;
	trailLength = 50; 
	trailWidth = 0.9; 
	soundId = SoundJetHeavy;
};



//======================================================================== GodHammer Pod
MineData FlyerLockingPod
{
	className = "Mine";
        description = "GodHammerPod";
        shapeFile = "rocket";
        shadowDetailMask = 4;
        explosionId = ShockwaveFour;
        explosionRadius = 5.0;
        damageValue = 0.15;
	damageType = $MineDamageType;
	kickBackStrength = 450;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function FlyerLockingPod::OnAdd(%this)
{
	schedule("FlyerLockingPod::Release(" @ %this @ ");", 1.0);
}

function FlyerLockingPod::Release(%this)
{
	%client = %this.fired;
	%player = Client::GetOwnedObject(%client);
	%target = %this.target;
	%rot = gamebase::getrotation(%this);
	%dir = (Vector::getfromrot(%rot));
	%vel = item::getvelocity(%this);
	%trans = %rot @ " " @ %dir @ " " @ %dir @ " " @ gamebase::getposition(%this);
	%fired = Projectile::spawnProjectile(FlyerLockingMissile,%trans,%player,%vel,%target);
	%fired.deployer = %client;
	if(%this)deleteobject(%this);
}

//======================================================================== Turret Missile
SeekingMissileData FlyerLockingMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;
   damageValue      = 1.1;
   damageType       = $MissileDamageType;
   explosionRadius  = 5.5;
   kickBackStrength = 5.0;
   muzzleVelocity    = 100.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 15.0;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   soundId = SoundJetHeavy;
};

//=======================================================================================================================
//						    Grenade Class Ammos
//=======================================================================================================================

//======================================================================== Grenade Shell
GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//======================================================================== Mortar Shell
GrenadeData MortarShell1
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 345;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//======================================================================== Delay Mortar Shell
GrenadeData DelayMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = ShockwaveThree;
   collideWithOwner   = True;
   ownerGraceMS       = 650;
   collisionRadius    = 2.5;
   mass               = 200.0;
   elasticity         = 0.55;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MDMDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 475; //425; //475
   totalTime          = 30.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.09;

   inheritedVelocityScale = 0.1;
   smokeName              = "mortartrail.dts";
};

//======================================================================== Mortar Turret Shell
GrenadeData MortarTurretShell1
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 35.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 600;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};


//======================================================================== EMP Mortar Shell
GrenadeData EMPMortar
{
	bulletShapeName    = "mortar.dts";
	explosionTag       = LargeShockwave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.03;
	mass               = 12.0;
	elasticity         = 0.08;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.30;
	damageType         = $FlashDamageType;

	explosionRadius    = 30.0;
	kickBackStrength   = -550.0;
	maxLevelFlightDist = 275;
	totalTime          = 30.0;
	liveTime           = 2.0;
	projSpecialTime    = 0.01;
	lightRange       = 10.0;
	lightColor       = { 1.0, 0.7, 1.5 };
	inheritedVelocityScale = 0.5;
	smokeName        = "rsmoke.dts";

};

//================================================================ EMP Shell
GrenadeData EMPShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Shockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 995.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $FlashDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.01;
   smokeName              = "smoke.dts";
};

//============================================================ Bomber Shell
GrenadeData BomberShell
{
	bulletShapeName    = "mortar.dts";
	explosionTag       = grenadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.2;
	mass               = 0.01;
	elasticity         = 0.45;
	damageClass        = 1; 
	damageValue        = 0.4;
	damageType         = $ShrapnelDamageType;
	explosionRadius    = 2;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 150;
	totalTime          = 5.0;
	liveTime           = 5.0;
	projSpecialTime    = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName              = "plasmatrail.dts";
};

function BomberShell::onAdd(%this)
{
	schedule("DeployBomblets(" @ %this @ " , 3);",1.0,%this);
}

//============================================================ Volter Burst
GrenadeData FlameBurst 
{
    	explosionTag = flamerExp;//plasmaExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 0.2;
 	mass = 1.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.30;
 	damageType = $ElectricityDamageType;
 	explosionRadius = 5.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 100;
 	totalTime = 6.0;
 	liveTime = 0.02;
 	projSpecialTime = 0.01;
 	lightRange = 2.0;
	lightColor = { 1, 1, 0 }; 
 	inheritedVelocityScale = 0.5; //1.5;
 	smokeName = "plasmatrail.dts";
 	soundId = SoundJetLight;
 };


//===================================================== Tactical Nuke Shell

GrenadeData FgcShell
{
	bulletShapeName    = "mortar.dts"; //"shockwave_large.dts"; //
	explosionTag       = LargeShockwave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.1;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 2.5;
	damageType         = $ShrapnelDamageType;

	explosionRadius    = 75.0;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 5.0;
	liveTime           = 5.0;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 0.5;
	smokeName              = "plasmatrail.dts";
};

function FgcShell::onAdd(%this)
{
	FgcShell::Deploy(%this);
}

function FgcShell::Deploy(%this)
{
	schedule("NuclearExplosion(" @ %this @ ");",3.0,%this);
}

//========================================================================
//						    Laser Class Ammos
//========================================================================

//======================================================= Sniper Rifle Laser

//if($weaklaser)
//	%lasdam = 0.01;
//else
	%lasdam = 0.02;

if($redlaser)
	%lascolor = "laserPulse.bmp";
else
	%lascolor = "lightningNew.bmp";

if($attachedlaser)
	%lasattach = False;
else
	%lasattach = True;

LaserData sniperLaser1
{
   laserBitmapName   = "blue_blink2.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = %lasdam;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.4;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = %lasattach;
   hitSoundId        = SoundLaserHit;
};

LaserData TurretLaser
{
   laserBitmapName   = %lascolor;
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//==========================

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = $TargetingDamageType;
   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
};

RocketData LasCannonBolt
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = ShockwaveFour; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 0;
    	damageValue = 0.8; 
	damageType = $LaserDamageType;
	explosionRadius = 2; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 
	terminalVelocity = 3000.0;
	acceleration = 500; 
	totalTime = 14.0; 
	liveTime = 14.0; 
	lightRange = 5.0; 
	lightColor = { 0.0, 0.0, 1.5 }; 
	inheritedVelocityScale = 0.0; 
	trailType = 1;
	trailLength = 3000; 
	trailWidth = 2.0; 
	soundId = NoCrashJetHeavy;
};

RocketData LasCannonBolt2
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = ShockwaveFour; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 0;
    	damageValue = 0.5; 
	damageType = $LaserDamageType;
	explosionRadius = 2; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 
	terminalVelocity = 3000.0;
	acceleration = 500; 
	totalTime = 14.0; 
	liveTime = 14.0; 
	lightRange = 5.0; 
	lightColor = { 0.0, 0.0, 1.5 }; 
	inheritedVelocityScale = 0.0; 
	trailType = 1;
	trailLength = 3000; 
	trailWidth = 1.0; 
	soundId = NoCrashJetHeavy;
};

RocketData LasCannonShock1
{
	bulletShapeName  = "shield.dts";
	explosionTag     = ShockwaveFour;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 0;
	damageValue      = 1.0;
	damageType       = $LaserDamageType;
	explosionRadius  = 5.0;
	kickBackStrength = 0;
	muzzleVelocity   = 250.0;
	terminalVelocity = 4000.0;
	acceleration     = 500.0;
	totalTime        = 14.0;
	liveTime         = 14.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.1, 1.5 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "shield.dts";
	smokeDist   = 20.0;
	soundId = NoCrashJetHeavy;
};

RocketData LasCannonShock2 	{ bulletShapeName = "shield_medium.dts"; explosionTag     = ShockwaveFour; collisionRadius  = 0.0; mass             = 0.0; damageClass      = 0; damageValue      = 1.3; damageType       = $LaserDamageType; explosionRadius  = 5.0; kickBackStrength = 0; muzzleVelocity   = 250.0; terminalVelocity = 4000.0; acceleration     = 500.0; totalTime        = 34.0; liveTime         = 34.0; lightRange       = 5.0; lightColor       = { 0.0, 0.1, 1.5 }; inheritedVelocityScale = 0.0; trailType   = 2; trailString = "shield.dts"; smokeDist   = 20.0; soundId = NoCrashJetHeavy; };
RocketData LasCannonShock3 	{ bulletShapeName = "shield_large.dts"; explosionTag     = ShockwaveFour; collisionRadius  = 0.0; mass             = 0.0; damageClass      = 0; damageValue      = 1.3; damageType       = $LaserDamageType; explosionRadius  = 5.0; kickBackStrength = 0; muzzleVelocity   = 250.0; terminalVelocity = 4000.0; acceleration     = 500.0; totalTime        = 34.0; liveTime         = 34.0; lightRange       = 5.0; lightColor       = { 0.0, 0.1, 1.5 }; inheritedVelocityScale = 0.0; trailType   = 2; trailString = "shield_medium.dts"; smokeDist   = 200.0; soundId = NoCrashJetHeavy; };

//============================================================== LasCannon
LaserData GatlingLaser
{
	laserBitmapName   = "lightningNew.bmp";
	hitName           = "shield.dts";
	damageConversion  = 0.10;
	baseDamageType    = $LaserDamageType;
	beamTime          = 2.5;
	lightRange        = 5.0;
	lightColor        = { 0.01, 0.01, 1.25 };
	detachFromShooter = true;
	hitSoundId        = SoundLaserHit;
};

//==========================================================
//						    Lightining Class Ammos
//==========================================================

LightningData lightningCharge1
{
   bitmapName       = "lightningNew.bmp";//"paintPulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 55.0;
   coneAngle        = 10.0; //50.0;
	damagePerSec      = 0.001;
	energyDrainPerSec = 0.001;
   segmentDivisions = 2;
   numSegments      = 3;
   beamWidth        = 0.1;//075;

   updateTime   = 100;
   skipPercent  = 0.9;
   displaceBias = 0.25;

   lightRange = 0.0;
	lightColor = { 0.0, 0.0, 0.0 };

   soundId = SoundELFFire;
};

function lightningCharge1::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(%target == %shooterId)  return;
	%player = Client::getControlObject(%shooterId);
	GameBase::applyDamage(%target, $ElectricityDamageType, 0.00544, %pos, %vec, %mom, %shooterId);
	%energy = GameBase::getEnergy(%target);
	%energy -= 2.24;
	if (%energy < 0)
		%energy = 0;
	else
		GameBase::setEnergy(%player, GameBase::getEnergy(%player) + 1.5);
	GameBase::setEnergy(%target, %energy);
}

LightningData TurretCharge1
{
	//bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 55.0;
   coneAngle        = 10.0; //50.0;
	damagePerSec      = 0.001;
	energyDrainPerSec = 0.001;
   segmentDivisions = 2;
   numSegments      = 3;
   beamWidth        = 0.075;//075;

   updateTime   = 120;
   skipPercent  = 0.9;
   displaceBias = 0.25;

   lightRange = 0.0;
	lightColor = { 0.0, 0.0, 0.0 };

   soundId = SoundELFFire;
};


LightningData turretCharge
{
	//bitmapName       = "lightningNew.bmp";

	damageType       = $gravdamagetype; // $ElectricityDamageType; //
   coneAngle        = 35.0;

//   damagePerSec      = 0.06;
//  energyDrainPerSec = 60.0;
//	damagePerSec      = 0.0;
//	energyDrainPerSec = 0.0;

	boltLength       = 60.0;
	segmentDivisions = 2;
	numSegments    = 3;
	beamWidth        = 0.05;
	//beamWidth        = 0.125;
	updateTime   = 140;
   skipPercent  = 0.001;
   displaceBias = 0.4;

	lightRange = 3.0;
	lightColor = { 0.15, 0.15, 0.95 };

	soundId = SoundELFFire;
};

LightningData turretCharge0
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function TurretCharge1::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(%target == %shooterId)  return;
   GameBase::applyDamage(%target, $ElectricityDamageType, 0.00192, %pos, %vec, %mom, %shooterId);
   %energy = GameBase::getEnergy(%target);
   %energy -= 1.92;
   if(%energy <= 0)
		%energy = 0;
   GameBase::setEnergy(%target, %energy);
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{}


//============================
LightningData gravCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 100.0;
   coneAngle        = 40.0;
   damagePerSec      = 0.001;
   energyDrainPerSec = 0.001;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.5;

   updateTime   = 100;
   skipPercent  = 0.9;
   displaceBias = 0.25;

   lightRange = 0.0;
	lightColor = { 0.0, 0.0, 0.0 };

   soundId = SoundELFFire;
};

function gravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(%target == %shooterId)  return;
	//Pull Beam
	//blatently Ripped from Meltdown mod
	//Please give Dynablade props :P
	%playerId = %shooterId;
	if(%playerId.GravBolt == "2")
	{
		%myPos = GameBase::getPosition(%playerId);
		%yourPos = GameBase::getPosition(%target);
		%myRot = GameBase::getRotation(%playerId);
		%dir = getWord(%myRot, 0) @ " " @ getWord(%myRot, 1) @ " " @ 3.14 + getWord(%myRot, 2);
		//make dir face opposite direction, thus pulls toward 
		%myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
		%yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0"; 
		%dist = Vector::getDistance(%myFlatPos, %yourFlatPos);
		//so Z isn't in distance & doesn't make you go FLYING if you have a huge height difference
		%force = 20; //not too hard and fast
		%height = 10 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //diff in z-values 
		if(%height > 700 || %height < -700)
			return;
		%diffVector = Vector::getFromRot(%dir, -%force, (-%height / %force)); 
		//if(%playerID.tractorMode == 1)
		//%diffVector = Item::getVelocity(%target);
		Item::setVelocity(%playerID, %diffVector); //the actual movement function
	}
	else// if(getObjectType(%target) == "Player")
	{
		if (%playerId.GravBolt == "0")
		{
			%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
			%Zvalue = %Rotation;
			%velocity = -25;
			%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);	
			Player::applyImpulse(%target, %shooterDir);
			%damVal = %timeSlice * %damPerSec;
			%enVal  = %timeSlice * %enDrainPerSec;
			GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
		}
		else if(%playerId.GravBolt == "1")
		{
			%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
			%Zvalue = %Rotation;
			%velocity = 25;
			%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
			%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
			Player::applyImpulse(%obj,%vec);
			Player::applyImpulse(%target, %shooterDir);
			%damVal = %timeSlice * %damPerSec;
			%enVal  = %timeSlice * %enDrainPerSec;
			GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
		}
	}
}

//=========================================================================
//						    Repair Class Ammos
//=========================================================================
RepairEffectData RepairBolt1
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt1::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.1;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
        %player.repairTarget = %target;
		%player.repairRate   = 0.2;
		
		if (getObjectType(%player.repairTarget) == "Player")
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		
		Client::sendMessage(%client,0,"Repairing " @ %name);
		
		$PlayerRepairing[%player] = "True";												//=== Player Is Repairing
		$PlayerRepairTar[%player] = (GameBase::getDamageLevel(%player.repairTarget));   //=== Amount Of Damage Starting

		//echo ("***  Repair Progress Started " @ $PlayerRepairing[%player] @ " Starting Damage Level = " @ $PlayerRepairTar[%player]);
	}
	
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt1::onRelease(%this, %player)
{
	%client = Player::getClient(%player);

	$PlayerRepairing[%player] = "False";
	//echo ("***  Repair Progress Stopped " @ $PlayerRepairing[%player]);
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
        if (%rate < 0)
      		%rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt1::checkDone(%this, %player)
{
	%client = Player::getClient(%player);
	if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FixIt) && %target != -1)
	{
		%object = %player.repairTarget;
		
		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0)
			{
				$PlayerRepairing[%player] = "False";
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				if ($PlayerRepairing[%player] = True)
				{
						%objname = (GameBase::getDataName(%object)).description;
					
					%objectTeam = GameBase::getTeam(%object);		//=== Team Object.
					%playerTeam = GameBase::getTeam(%player); 	//=== Team Player.
					%lastdamage = GameBase::getControlClient(%object.lastDamageObject);	

					if (%objname == "Remote Mortar Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Laser Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Point Defense Laser Mine")		%pntval = $Score::ObjTurretS;
					else if (%objname == "EMP Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "ELF Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Flamer Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Camera")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Large Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Medium Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Motion Sensor")				%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Pulse Sensor")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Sensor Jammer")			%pntval = $Score::ObjSensorS;		
					else if (%objname == "Generator")				%pntval = $Score::ObjGeneratorB;
					else if (%objname == "Solar Panel")				%pntval = $Score::ObjGeneratorS;
					else if (%objname == "Portable Generator")			%pntval = $Score::ObjGeneratorS;		
					else if (%objname == "Ammo Supply Unit")	   		%pntval = $Score::ObjStationA;
					else if (%objname == "Station Supply Unit")			%pntval = $Score::ObjStationS;
					else if (%objname == "Command Station")				%pntval = $Score::ObjStationA;
					else if (%objname == "Remote Ammo Unit")			%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Inv Unit")				%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Command Station")			%pntval = $Score::ObjStationR;
					else if (%objname == "Station Vehicle Unit")			%pntval = $Score::ObjFlier;
					else if (%objname == "Vehicle Pad")				%pntval = $Score::ObjFlier;					

					%bonus = (floor($PlayerRepairTar[%player] * %pntval));
					%score = ($Score::RepairObject + %bonus);
					///greyflcn
					%lastdamage = %object.lastdamageobj;
					%lastdpl = GameBase::getControlClient(%object.lastDamageObject);
					%objname = GameBase::getMapName(%object);
					if(%objname == "") 
						%objname = (GameBase::getDataName(%object)).description;					

					if (%lastdpl == %client)
					{
							if ((%objectteam == %playerteam || %objectteam == "-1") && (%object.lastDamageTeam == %playerTeam))
							{
								if ($ScoreOn) bottomprint(%client, "No points awarded, you were the last damager.");						
							}
							else if (%objectteam != %playerTeam)
							{
								%client.score = (%client.score - %score);
								if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
							}
							else if (%this.lastDamageTeam != %playerTeam)
							{
								%client.score = (%client.score + %score);
								if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
							}
					}
					else
					{
						if (%objectteam != %playerTeam)
						{
							%client.score = (%client.score - %score);
							if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score. You Dumb Ass.");
						}
						else
						{
							%client.score = (%client.score + %score);
							if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
						}
					}
						
					$PlayerRepairing[%player] = "False";
					Game::refreshClientScore(%client);
				}
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//------------------------------------------------------------------------------------------------
// Hack Gun Beam Used this from the RSP - Is now alternate weapon setting for EngRepairGun
//------------------------------------------------------------------------------------------------
RepairEffectData HackBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function HackBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);	
	$hacking[%client] = "false";
	if ($debug) echo ("STOPPED " @ %client);
}

function HackBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);	
	if($Shifter::AllowHacking)
	{
		if (%target != %player)
		{
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player);
			%pName = Client::getName(%client);
			%tName = getTeamName(%team);

			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
	
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

			if(%team == %pTeam)
			{
				if (%target.infected == "true")
				{
					Client::sendMessage(%client,0," Your team's " @ %name @ " is already protected from hacking.");	
					return;
				}
				else if(checkHackable(%name, %shape) == 0 || getObjectType(%player.repairTarget) != "Player")
				{
					$hacking[%client] = "true";
					if($origTeam[%target] == "")
					{
						$origTeam[%target] = %team;
					}

					Client::sendMessage(%client,0,"Infecting " @ %name @ ". Please wait...");
					
					hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
					return;
				}
				return;
			}
		
			if(checkHackable(%name, %shape) == 1 || getObjectType(%player.repairTarget) == "Player")
			{
				if(getObjectType(%player.repairTarget) == "Player")
				{
					Client::sendMessage(%client,0,"You can not hack another player.");
				}
				if(%name == "False" && %shape == "magcargo")
				{
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else
			{
				if(%name == "False" && %shape == "MagCargo")
				{
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking[%client] = "true";
				
				if ($debug) echo ("Orgin Team = " @ $origTeam[%target]);

				if($origTeam[%target] == "")
				{
					if ($debug) echo ("No original team set. Marking.");
					$origTeam[%target] = %team;
				}
				hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
			}
		}	
	}
	else
	{
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}

// Drain Bolt - Same as Repair, But drains, used with regeneration pack and Eng option for Eng Gun
//------------------------------------------------------------------------------------------------------------------------

RepairEffectData DrainBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 25.0;
   segmentDivisions = 2;
   beamWidth        = 0.525;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 1.95 };
};

function DrainBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%shape = ((GameBase::getDataName(%target)).shapeFile);

	if ($debug) echo ("Shape Drained = " @ %shape);
	
	if (%target == %player)
	{	
		%player.drainTarget = -1;
		
		if (GameBase::getDamageLevel(%player) == 0)
		{
			Client::sendMessage(%client,0,"You are not damaged, can not drain!");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
		else
		{
			Client::sendMessage(%client,0,"Must find powered object to drain!");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}	   	
	}
	else
	{
     		%player.drainTarget = %target;

		if (gamebase::Getteam(%player) != gamebase::Getteam(%target) && gamebase::getteam(%target) != "-1")
		{
			//============================================================= Get Name Of Object Or Player Being Drained
			if (getObjectType(%player.drainTarget) == "Player")
			{
				%rclient = Player::getClient(%player.drainTarget);
				%name = Client::getName(%rclient);
			}
			else
			{
				%name = GameBase::getMapName(%target);
				if(%name == "") 
				{
					%name = (GameBase::getDataName(%player.drainTarget)).description;
				}
			}

			//============================================================= Get Damage Level Of Object

			//echo ("Drain Target  " @ %target);
			//echo ("Target Damage " @ (GameBase::getDataName(%target)).maxDamage);

			if (GameBase::getDamageLevel(%player.drainTarget) < (GameBase::getDataName(%target)).maxDamage)
			{
				Client::sendMessage(%client,0,%name @ " being drained!");
				Player::trigger(%player,$WeaponSlot,true);
			}
			else
			{
				Client::sendMessage(%client,0,%name @ " has no energy to drain!!!");
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}

			if (getObjectType(%player.drainTarget) == "Player") 
			{
				Client::sendMessage(%rclient,0,"Being drained by " @ Client::getName(%client));
			}

			Client::sendMessage(%client,0,"Draining " @ %name);

			$PlayerDraining[%player] = "True";						//=== Player Is Repairing
			$PlayerRepairTar[%player] = (GameBase::getDamageLevel(%player.drainTarget));   //=== Amount Of Damage Starting

			if ($Debug) echo ("***  Drain Progress Started " @ $PlayerDraining[%player] @ " Starting Damage Level = " @ $PlayerRepairTar[%player]);
		}
		else if (gamebase::getteam(%player) == gamebase::getteam(%target))
		{
			%player.powerTarget = %target;
			%player.powertime = ($Shifter::HackTime);
		}
	}
}

function DrainBolt::checkDone(%this, %player)
{
	%client = Player::getClient(%player);
	%object = %player.drainTarget;
	%target = %player.drainTarget;
	
	if ($Debug) echo ("*** Checking Drain Progress " @ $PlayerDraining[%player] @ " -> " @ %target);

	if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == Regen) && %target != -1)
	{
		
		//======================================================================================= USED AGAINST NME
		if (gamebase::Getteam(%player) != gamebase::Getteam(%object) && gamebase::getteam(%object) != "-1")
		{
			if (%object == %player)
			{
				if (GameBase::getDamageLevel(%player) >= (GameBase::getDataName(%object)).maxDamage)
				{
					$PlayerDraining[%player] = "False";
					Player::trigger(%player,$WeaponSlot,false);
					return;
				}
			}
			else
			{
				if (GameBase::getDamageLevel(%object) < (GameBase::getDataName(%object)).maxDamage)
				{
					if ($PlayerDraining[%player] = True)
					{
						%damage = (GameBase::getDataName(%object)).maxDamage / 20;
						GameBase::applyDamage(%object,$FlashDamageType, %damage,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
						GameBase::repairDamage(%player,(%damage / 25));
						if ($Debug) echo ("Damage Applied = " @ %damage);
					}
					Player::trigger(%player,$WeaponSlot,true);
				}
			}
		}
		//======================================================================================= USED ON TEAM
		else if (gamebase::getteam(%player) == gamebase::getteam(%object))
		{	
			if(%player.powertime > 0)
			{
				if(%player.powerTarget)
				{		
					%player.powertime--;
					return;
				}
			}
			else if ((%player.powertime < 0 || %player.powertime == 0) && %player.powerTarget)
			{
				%target = %player.powerTarget;
				%objType = getObjectType(%target); 
				%obj = GameBase::getDataName(%target); 
				
				if(%objType == "Player") 
				{
					if(%target == %player) 
					{ 
						Client::sendMessage(%client,0,"Nothing to power in range"); 
						Player::trigger(%player, $WeaponSlot, false); 
						return; 
					}

					%tc = Player::getClient(%target); 

					if(%tc.isPowered) 
					{
						Player::trigger(%player, $WeaponSlot, false); 
						Client::sendMessage(%client,1, "Charging " @ Client::getName(%tc)); 
						Client::sendMessage(%tc,1, "Finished charging from " @ Client::getName(%client)); 
						Player::trigger(%player, $WeaponSlot, false); 
						return; 
					} 
					
					Client::sendMessage(%client,1, "Powering " @ Client::getName(%tc)); 
					Client::sendMessage(%tc,1, "Receiving power from " @ Client::getName(%client)); 

					%tc.isPowered = true; 
					%player.powerTarget = ""; 
					%target.shieldStrength = 0.025; 
					schedule ("" @ %target @ ".shieldStrength = 0;",120);
					Player::trigger(%player, $WeaponSlot, false); 
					return; 
				}
				else if(%objType == "Flier")
				{
					%player.powerTarget = ""; 
					%target.shieldStrength = 0.013; 
					Client::sendMessage(%client,0, "Shielding " @ $VehicleToItem[GameBase::getDataName(%target)].description); 
					Player::trigger(%player, $WeaponSlot, false); 
					return; 
				}
				else if(GameBase::isPowered(%target)) 
				{ 
					if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation") 
					{
						%player.powerTarget = ""; 					
						Client::sendMessage(%client,0, %obj.description @ " is already powered"); 
						Player::trigger(%player, $WeaponSlot, false); 
						return; 
					}
				}
				else 
				{
					if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation") 
					{ 
						%player.powerTarget = "";
						
						Client::sendMessage(%client,0, "Powering " @ %obj.description); 
						GameBase::playSequence(%target,0,"power"); 
						GameBase::playSequence(%target,1);
						
						%target.poweron = "True";
						schedule ("" @ %target @ ".poweron = false;",$Shifter::HackedTime);
						schedule ("GameBase::stopSequence(" @ %target @ ",0);",$Shifter::HackedTime);
						schedule ("GameBase::pauseSequence(" @ %target @ ",1);",$Shifter::HackedTime);
						schedule ("GameBase::pauseSequence(" @ %target @ ",2);",$Shifter::HackedTime);
						schedule ("Station::checkTarget(" @ %target @ ");",$Shifter::HackedTime);

						Player::trigger(%player, $WeaponSlot, false); 
						return; 
					}
				}
				
				if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor" || %obj == "MortarTurret") 
				{ 
					%player.powerTarget = ""; 
					Client::sendMessage(%client,1, "Upgrading Shielding on " @ %obj.description); 
					%target.shieldStrength = 0.03; 
					GameBase::setRechargeRate(%target,10); 
					Player::trigger(%player, $WeaponSlot, false); 
					return; 
				} 
				
				if(%obj == "DeployableInvStation" || %obj == "DeployableAmmoStation")
				{
					if ((%obj == "DeployableInvStation" && %target.Energy < ($RemoteInvEnergy + 2000)) || (%obj == "DeployableAmmoStation" && %target.Energy < ($RemoteAmmoEnergy + 2000)))
					{
						%player.powerTarget = "";
						%target.Energy += 1000;
						%target.Uped++;
						Client::sendMessage(%client,1, "Station Recharged - " @ %obj.description @ ""); 
						Player::trigger(%player, $WeaponSlot, false); 
						return; 
					}
					else 
					{
						Client::sendMessage(%client,1, "" @ %obj.description @ " is fully charged."); 
						Player::trigger(%player, $WeaponSlot, false); 
						return; 
					}
					
					if (%target.Uped = 2)
					{
						Client::sendMessage(%client,1, "" @ %obj.description @ " will overload after another charge..."); 
					}
					else if (%target.Uped = 3)
					{					
						Client::sendMessage(%client,1, "" @ %obj.description @ " will overload in 5 seconds..."); 
						GameBase::applyDamage(%client,$FlashDamageType,0.30,GameBase::getPosition(%client),"0 0 0","0 0 0",%target);
					}
				}
				Client::sendMessage(%client,1, "No Effect On " @ %obj.description @ "."); 
				Player::trigger(%player, $WeaponSlot, false); 
				return; 
			}
		}
	}
}

function DrainBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);

	$PlayerDraining[%player] = "False";
	//echo ("***  Drain Progress Stopped " @ $PlayerDraining[%player]);
	GameBase::repairDamage(%player,0);
	
	%object = %player.drainTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,1,"Done.");
				GameBase::repairDamage(%player,0);
			}
			else
			{
				Client::sendMessage(%client,1,"Done.");
				GameBase::repairDamage(%player,0);
			}
		}
	}
}

// Disasymbler - Alternate To Engineer Repair Gun.
// 
RepairEffectData DisaBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.3;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function DisaBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target != %player)
	{
		%player.repairTarget = %target;
		%name = GameBase::getMapName(%target);
		%team = GameBase::getTeam(%target);
		%pTeam = GameBase::getTeam(%player); //added
		%pName = Client::getName(%client); //added
		%tName = getTeamName(%team); //added
		
		if(%name == "")
		{
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		}

		%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
		
		if(getObjectType(%player.repairTarget) == "Player")
		{
			Client::sendMessage(%client,0,"You can not disassymble another player.");
		}
		else
		{
			Client::sendMessage(%client,0,"Disassymbling " @ %name @ ". Please wait...");
			%disatime = 5;
			$disassymble[%player] = True;
			objectColapsable(%target, %player, %name, %shape, %disatime);
			if ($Debug) echo ("Done.");
		}
	}	
}

function DisaBolt::onRelease(%this, %player)
{
	$disassymble[%player] = false;
}


function removeflagdefpoints(%player)
{
	%client = Player::getClient(%player);
	%client.score = %client.score - $Score::FlagDef;
	if ($ScoreOn) bottomprint(%Client, "Score - " @ $Score::FlagDef @ " = " @ %client.score @ " Total Score, for removing flag defencive." ,3);
	Game::refreshClientScore(%client);
}

function objectColapsable(%this, %player, %name, %shape, %disatime)
{	
	%client = Player::getClient(%player);
	%pos = gamebase::GetPosition (%this);
	%description = %name;
	%playerteam = Client::getTeam(%client);				//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%pos,%homepos);

	if (Player::getmounteditem(%player, $BackPackSlot) != "-1")
	{
		bottomprint( %client, "<jl><f1> You can not disassymble the " @ %description @ ", drop your current pack first...", 3);
		return 0;
	}

	if ($disassymble[%player])
	{
		if (%disatime > 0)
		{
			%disatime = %disatime - 1;
			schedule ("objectColapsable ( '" @ %this @ "', '" @ %player @ "', '" @ %name @ "', '" @ %shape @ "', '" @ %disatime @ "'); ",1);
			return 0;
		}
	}
	else
	{
		return 0;
	}
	
	if ($Debug) echo ("Attempting To Dismantle " @ %name);
		
	//==== AccelPad
	if (String::findSubStr(%name, "Accel Pad") >= 0)
	{
		%item = "AccelPPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Launch Pad
	if (String::findSubStr(%name, "Launchboard") >= 0)
	{
		%item = "LaunchPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}

	//==== Teleport Pad
	if (String::findSubStr(%name, "Teleport Pad") >= 0)
	{
		%item = "TeleportPack";
		RemoveBeam(%this.beam1);		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	
	//==== Ion Turret
	if (String::findSubStr(%name, "Ion Turret") >= 0)
	{
		%item = "TurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %description);
		return 1;
	}
	//==== AATurret
	if (String::findSubStr(%name, "Anti-AirCraft Turret") >= 0)
	{
		%item = "BarragePack";		
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %description);
		return 1;
	}

	//==== Command Station
	if (String::findSubStr(%name, "Remote Command Station") >= 0)
	{
		%item = "DeployableComPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	//==== Sensor Jammer
	if (String::findSubStr(%name, "Sensor Jammer") >= 0)
	{
		%item = "DeployableSensorJammerPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Pulse Sensor
	if (String::findSubStr(%name, "Remote Pulse Sensor") >= 0)
	{
		%item = "PulseSensorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Motion Sensor
	if (String::findSubStr(%name, "Motion Sensor") >= 0)
	{
		%item = "MotionSensorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Camera 
	if (String::findSubStr(%name, "Camera") >= 0)
	{
		%item = "CameraPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//==== Blast Wall
	if (String::findSubStr(%name, "Blast Wall") >= 0)
	{
		%item = "BlastWallPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Blast Floor
	if (String::findSubStr(%name, "Blast Floor") >= 0)
	{
		%item = "BlastFloorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Small Force Field
	if (String::findSubStr(%name, "Small Force Field") >= 0)
	{
		%item = "ForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Large Force Field
	if (String::findSubStr(%name, "Large Force Field") >= 0)
	{
		%item = "LargeForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Large Shock Force Field
	if (String::findSubStr(%name, "Shock Floor") >= 0)
	{
		%item = "ShockFloorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Large Shock Force Field
	if (String::findSubStr(%name, "Large Shock Force Field") >= 0)
	{
		%item = "LargeShockForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Deployable Platform
	if (String::findSubStr(%name, "DeployablePlatform") >= 0)
	{
		%item = "PlatformPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	//==== Healing Plant
	if (String::findSubStr(%name, "Healing Plant") >= 0)
	{
		%item = "PlantPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//==== Rocket Turret
	if (String::findSubStr(%name, "RMT Rocket Turret") >= 0)
	{
		%item = "RocketPack";		
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %description);
		return 1;
	}
	//==== Plasma Turret
	if (String::findSubStr(%name, "RMT Plasma Turret") >= 0)
	{
		%item = "PlasmaTurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %description);
		return 1;
	}
	//==== Elf Turret
	if (String::findSubStr(%name, "Deployable Elf Turret") >= 0)
	{
		%item = "DeployableElf";		
		objectTearup (%this, %item, %client, %player, 1, 20, %flagdist, %description);
		return 1;
	}
	//==== EMP Turret
	if (String::findSubStr(%name, "EMP Turret") >= 0)
	{
		%item = "ShockPack";		
		objectTearup (%this, %item, %client, %player, 1, 10, %flagdist, %description);
		return 1;
	}
	//==== Remote Mortar
	if (String::findSubStr(%name, "Mortar Turret") >= 0)
	{
		%item = "TargetPack";		
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %description);
		return 1;
	}
	//==== Laser Turret
	if (String::findSubStr(%name, "Laser Turret") >= 0)
	{
		%item = "LaserPack";		
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %description);
		return 1;
	}
	//==== Arbitor Beacon
	if (String::findSubStr(%name, "ArbitorBeacon") >= 0)
	{
		%item = "ArbitorBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//==== EMPBeacon
	if (String::findSubStr(%name, "EMPBeacon") >= 0)
	{
		%item = "EMPBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//==== JammerBeacon
	if (String::findSubStr(%name, "JammerBeacon") >= 0)
	{
		%item = "JammerBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//==== ShieldBeacon
	if (String::findSubStr(%name, "Shield Device") >= 0)
	{
		%item = "ShieldBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//==== Flamer Turret
	if (String::findSubStr(%name, "Flamer Turret") >= 0)
	{
		%item = "FlamerTurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//==== Port Gen
	if (String::findSubStr(%name, "PortGenerator") >= 0)
	{
		%item = "PowerGeneratorPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}

	Client::sendMessage(%client,0,"Disassymbling " @ %name @ " failed...");
	Player::trigger(%client,$WeaponSlot,false);
	$disassymble[%player] = false;
	return 0;
}

// objectTearup (%this, %item, %client, %player, 1, 1, %flagdist, %description);

function objectTearup (%this, %item, %client, %player, %turret, %flag, %flagdist, %description)
{
	Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
	$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
	
	if (%turret) $totalNumTurrets = $totalNumTurrets - 1;

	Player::setItemcount (%client, %item, 1);
	Player::mountItem(%client,%item,$BackpackSlot);
	bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);

	if (%flag > 0 && %flagdist < %flag) removeflagdefpoints(%player);
	//Item::playPickupSound(%this);
	if(%this)deleteobject(%this);
	$disassymble[%player] = false;
}

//================================================================================================
//													Heat Seeker
//================================================================================================


LightningData LockJaw
{
	//bitmapName       = "";  //paintPulse.bmp

	damageType       = $GravDamageType;
	coneAngle        = 5.0;
	damagePerSec      = 0.001;
	energyDrainPerSec = 0.001;

	boltLength       = 350.0;
	segmentDivisions = 2;
	numSegments    = 1;
	beamWidth        = 0.001;
	updateTime   = 100;
	skipPercent  = 0.9;
	displaceBias = 0.25;

	lightRange = 3.0;
	lightColor = { 0.15, 0.15, 0.95 };

	soundId = SoundELFFire;
};

function LockJaw::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %player)
{
  %client = Player::getClient(%player);
	if ((!%client.target || %client.target == "-1" || %client.target == %player) && %client.lj)
	{
		%client.target = %target; 
		if(%client.lj)deleteobject(%client.lj);
		%client.lj = 0;
		%type = getObjectType(%target);
		%tarmor = Player::getArmor(%target);
		if (gamebase::getteam(%target) == gamebase::getteam(%player))
		{
			bottomprint(%client, "<jc><f1>Lock Failed, Can Not Target Friendlies!", 3);
			Client::sendMessage(%client,1,"Lock Failed, Can Not Target Friendlies!~waccess_denied.wav");
			%client.target = -1;
		}
		else if (%type == "Flier")
		{
			Client::sendMessage(%client,1,"**Lock Aquired - Active For Next 15 Seconds!!!~wmine_act.wav");			
			bottomprint(%client, "<jc><f1>Lock Aquired - Active For Next 15 Seconds! - Fire Now To Launch!", 3);
			playSound(TargetingMissile,GameBase::getPosition(%player));
			Player::trigger(%player,$WeaponSlot,false);
			%pilot = %target.clLastMount;
			//%client.target = %pilot; 
			if(%pilot.driver) LockjawWarn(%client, %pilot);
			schedule("bottomprint(" @ %client @ ", \"<jc><f1>Lost Heat Lock!\", 3);", 15);
			schedule(%client @ ".target = -1;", 15);
			echo(%client.target);
		}
		else if(%type == "Player" && %tarmor != "spyarmor" && %tarmor != "spyfemale")
		{	
			LockjawWarn(%client, %target);
			Client::sendMessage(%client,1,"** HeatLock Aquired - Active For Next 15 Seconds!!!~wmine_act.wav");			
			bottomprint(%client, "<jc><f1>Heat Lock Aquired - Active For Next 15 Seconds! - Fire Now To Launch!", 3);
			playSound(TargetingMissile,GameBase::getPosition(%player));
			Player::trigger(%player,$WeaponSlot,false);
			schedule(%client @ ".target = -1;", 15);
			schedule("bottomprint(" @ %client @ ", \"<jc><f1>Lost Heat Lock!\", 3);", 15);
		}
		else
		{
			bottomprint(%client, "<jc><f1>Lock Failed, No Targetable Object!", 3);
			Client::sendMessage(%client,1,"Lock Failed, No Targetable Object!~waccess_denied.wav");
			%client.target = -1;
		}
	}	
}


function LockJawFire(%player, %target, %rnd)
{

	%client = Player::getClient(%player);

	if (getObjectType(%target) == "Player")
	{
		if(GameBase::virtual(%target, "getHeatFactor") >= 0.5)
		{
			%targetid = Player::getClient(%target);
			LockJawWarn(%client, %targetID);
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);	
			$targetingmissile = %client.target;
			Projectile::spawnProjectile("MiniMissileTracker",%trans,%player,%vel,%target);
			%pos = GameBase::getPosition(%player);
			playSound(SoundMissileTurretFire,%pos);
			playSound(SoundMissileTurretFire,%pos);
		}
	}
	if (getObjectType(%target) == "Flier")
	{
		%targetid = Player::getClient(%target);
		%pilot = %target.clLastMount;
		if(%pilot.driver) LockjawWarn(%client, %pilot);
		Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);	
		$targetingmissile = %client.target;
		Projectile::spawnProjectile("MiniMissileTracker",%trans,%player,%vel,%target);
		%pos = GameBase::getPosition(%player);
		playSound(SoundMissileTurretFire,%pos);
		playSound(SoundMissileTurretFire,%pos);
	}
}

function LockJawWarn(%clientId, %targetId) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " is tracking your heat signature!!~waccess_denied.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~~waccess_denied.wav\");",0.5);//access_denied.wav
	}
} 

//================================================================================================
//						Special Functions
//================================================================================================
function NuclearExplosion(%this)
{
	det(%this.deployer, GameBase::GetPosition(%this));	
	deleteobject(%this);	
}


RocketData TeleShell
{
   bulletShapeName = "discb.dts";

   explosionTag    = TeleExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;
   damageValue      = 0.01;
   damageType       = $GravDamageType;

   explosionRadius  = 0.01;
   kickBackStrength = 0.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;

   soundId = SoundDiscSpin;
   rotationPeriod = 1.5;
};

RocketData StarShell
{
   bulletShapeName = "mine.dts";
   explosionTag    = starExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $EnergyDamageType;

   explosionRadius  = 0.01;
   kickBackStrength = 0.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 2.3;
   liveTime         = 2.7;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;
	rotationPeriod = 0.25;
   soundId = SoundThrowItem;
};
};
