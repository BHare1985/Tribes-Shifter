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
$GravDamageType	       = 20;
$ShellDamageType       = 21;
$CloakDamageType       = 22;
$NukeDamageType        = 23;
$FlameDamageTpye       = 24;	
$KamikazeDamageType    = 25;
$AntiMatterDamageType  = 26;
$EqualizerDamageType   = 27;
$OverDoseDamageTpye    = 28;
$IDamageType	       = 29;
$TargetingDamageTpye	= 30;
$BoomStickDamageType	= 31;
$HBlasterDamageType	= 32;



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

//=======================================================================================================================
//						    Bullet Class Ammos
//=======================================================================================================================


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
	damageValue        = 0.5;
	damageType         = $IDamageType;

	explosionRadius    = 1.25;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 250;
	totalTime          = 30.0;    // special meaning for grenades...
	liveTime           = 0.3;
	projSpecialTime    = 0.05;

	aimDeflection      = 0.002;
	muzzleVelocity     = 100.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 2.0;
	isVisible          = False;

	tracerPercentage   = 1.0;
	tracerLength       = 75;
};



//======================================================================== ChainGun
BulletData ChaingunBullet
{
	bulletShapeName    = "tumult_small.dts";
	explosionTag       = debrisExpsmall;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.5;
	mass               = 1.0;
	elasticity         = 0.45;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $EqualizerDamageType;

	explosionRadius    = 2.5;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 150;
	totalTime          = 30.0;    // special meaning for grenades...
	liveTime           = 1.5;
	projSpecialTime    = 0.05;

	aimDeflection      = 0.003;
	muzzleVelocity     = 200.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 2.0;
	isVisible          = False;

	tracerPercentage   = 1.0;
	tracerLength       = 45;
};

//======================================================================== Sniper Bullet
BulletData SniperBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	mass               = 0.05;
	collisionRadius    = 0.0;
	bulletHoleIndex    = 0;
	damageClass        = 0;
	damageValue        = 0.70;
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
BulletData SilencerBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;
	damageValue        = 0.26;
	damageType         = $BulletDamageType;
	muzzleVelocity     = 625.0;
	aimDeflection      = 0.002;
	totalTime          = 0.30;
	inheritedVelocityScale = 1.0;
	isVisible          = True;

	tracerPercentage   = 100.0;
	tracerLength       = 30;
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
	muzzleVelocity     = 625.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = True;
	tracerPercentage   = 100.0;
	tracerLength       = 30;
};

//======================================================================== Vulcan Bullet
BulletData VulcanBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.06;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.03;
	damageType         = $BulletDamageType;
	aimDeflection      = 0.007;
	muzzleVelocity     = 900.0;
	totalTime          = 2;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	tracerPercentage   = 2.0;
	tracerLength       = 60;
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
	damageValue        = 0.08;
	damageType         = $BoomStickDamageType;
	aimDeflection      = 0.029;
	muzzleVelocity     = 200.0;
	totalTime          = 1;
	inheritedVelocityScale = 0.3;
	isVisible          = False;
	tracerPercentage   = 2.0;
	tracerLength       = 30;
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
   damageValue        = 0.25;
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
BulletData BlasterBolt
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
BulletData PlasmaBolt
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = plasmaExp;

	damageClass        = 1;
	damageValue        = 0.45;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 6.0;

	muzzleVelocity     = 55.0;
	totalTime          = 3.0;
	liveTime           = 2.0;
	lightRange         = 3.0;
	lightColor         = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible          = True;

	soundId = SoundJetLight;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaBolt2
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
	
	muzzleVelocity   = 65.0;
	terminalVelocity = 65.0;
	acceleration     = 65.0;
	totalTime        = 2.0;
	liveTime         = 2.0;
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
	damageValue        = 0.165;
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
	damageValue        = 0.25;
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
	damageValue        = 0.15;
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
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	collideWithOwner   = False;

	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 0.0;
	kickBackStrength = 0;
	
	muzzleVelocity   = 5.0;
	terminalVelocity = 5.0;
	acceleration     = 5.0;
	totalTime        = 0.55;
	liveTime         = 0.55;
	lightRange       = 3.0;
	lightColor       = { 1, 1, 0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmaex.dts";
	smokeDist   = 5.0;
	soundId = SoundJetHeavy;
};

//======================================================================== Flamer Bolt
RocketData FlamerBolt
{
	bulletShapeName  = "plasmaex.dts";
   	explosionTag       = plasmaExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 0.20;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 4.0;
	kickBackStrength = 0;
	
	muzzleVelocity   = 30.0;
	terminalVelocity = 30.0;
	acceleration     = 30.0;
	totalTime        = 0.75;
	liveTime         = 0.85;
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

//=======================================================================================================================
//						    Missile Class Ammos
//=======================================================================================================================

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
	soundId = SoundJetHeavy;
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
	soundId = SoundJetHeavy;
};

RocketData LasCannonShock
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
	soundId = SoundJetHeavy;
};

SeekingMissileData BarrageBolt
{
	bulletShapeName  = "tracer.dts";
	explosionTag     = flashExpMedium;
	collisionRadius  = 0.0;
	mass             = 1.5;

	damageClass      = 1;
	damageValue      = 0.15;
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


//======================================================================== Sniper Round
RocketData SniperRound
{
	bulletShapeName  = "bullet.dts";
	explosionTag     = bulletExp0;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 0;
	damageValue      = 0.69;
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

//======================================================================== Disc Shell
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

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

//======================================================================== Flier Rocket
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
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

   damageClass      = 1;       // 0 impact, 1, radius
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

function SeekingMissile::updateTargetPercentage(%target)
{
	return GameBase::virtual(%target, "getHeatFactor");
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
   damageValue      = 0.75;
   damageType       = $BulletDamageType;

   explosionRadius  = 0.1;
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
   return GameBase::virtual(%target, "getHeatFactor");
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
//======================================================================== Stinger Missile
RocketData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
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

//======================================================================== GodHammer Missile
RocketData GodHammer
{
	bulletShapeName = "rocket.dts";
	explosionTag    = rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.45;
	damageType       = $ExplosionDamageType;
	explosionRadius  = 15;
	kickBackStrength = 80;
	muzzleVelocity   = 50.0;
	terminalVelocity = 1000.0;
	acceleration     = 150.0;
	totalTime        = 8.5;
	liveTime         = 18.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.75;
	trailType   = 1;
	trailLength = 35;
	trailWidth  = 0.40;
	soundId = SoundJetHeavy;
	rotationPeriod = 1.5;
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

//======================================================================== GodHammer Pod
MineData GodHammerPod
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

function GodHammerPod::OnAdd(%this)
{
	schedule("GodHammerPod::Release(" @ %this @ ");", 1.0);
}

function GodHammerPod::Release(%this)
{
	%client = %this.deployer;
	%player = Client::GetOwnedObject(%client);

	%rot = gamebase::getrotation(%player);
	%dir = (Vector::getfromrot(%rot));
	%vel = item::getvelocity(%this);
	%trans =  %rot @ " " @ %dir @ " " @ %dir @ " " @ gamebase::getposition(%this);

	%fired = Projectile::spawnProjectile(GodHammer, %trans ,%player,%vel);
	%fired.deployer = %client;
	deleteobject(%this);
}

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
	deleteobject(%this);
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
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//======================================================================== Mortar Shell
GrenadeData MortarShell
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
   maxLevelFlightDist = 275;
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
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 475;
   totalTime          = 30.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.09;

   inheritedVelocityScale = 0.1;
   smokeName              = "mortartrail.dts";
};

//======================================================================== Mortar Turret Shell
GrenadeData MortarTurretShell
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
	explosionTag       = shockwave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 400.0;
	elasticity         = 0.01;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.30;
	damageType         = $FlashDamageType;

	explosionRadius    = 35.0;
	kickBackStrength   = -10.0;
	maxLevelFlightDist = 275;
	totalTime          = 30.0;
	liveTime           = 2.0;
	projSpecialTime    = 0.01;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	smokeName        = "rsmoke.dts";

};

//======================================================================== EMP Shell
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

//======================================================================== Satchel Shell
GrenadeData SatchelShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.6;
   damageType         = $DebrisDamageType;

   explosionRadius    = 25;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//======================================================================== Bomber Shell
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
	schedule("DeployBomblets(" @ %this @ " , 5);",1.0,%this);
}

//======================================================================== Volter Burst
GrenadeData FlameBurst 
{
    	explosionTag = plasmaExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 10.0;
 	mass = 5.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.30;
 	damageType = $ElectricityDamageType;
 	explosionRadius = 5.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 75;
 	totalTime = 4.0;
 	liveTime = 0.02;
 	projSpecialTime = 0.01;
 	lightRange = 10.0;
	lightColor = { 1, 1, 0 }; 
 	inheritedVelocityScale = 1.5;
 	smokeName = "plasmatrail.dts";
 	soundId = SoundJetLight;
 };


//======================================================================== Tactical Nuke Shell

GrenadeData FgcShell
{
	bulletShapeName    = "mortar.dts";
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
	if (GameBase::isAtRest(%this))
	{
		schedule("NuclearExplosion(" @ %this @ ");",3.0,%this);
	}
	else
	{
		schedule("FgcShell::Deploy(" @ %this @ ");",3.0,%this);
	}
}

//=======================================================================================================================
//						    Laser Class Ammos
//=======================================================================================================================

//======================================================================== LasCannon
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

//======================================================================== Sniper Rifle Laser
LaserData sniperLaser
{
   laserBitmapName   = "lightningNew.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//======================================================================== Targeting Laser
TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = $TargetingDamageType;
   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
};

//=======================================================================================================================
//						    Lightining Class Ammos
//=======================================================================================================================


//======================================================================== Lightning Charge

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.10;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//========================================================================  Lightning Charge1
LightningData lightningCharge1
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $FlashDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.10;
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

//========================================================================  Lightning Charge2
LightningData lightningCharge2
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//======================================================================== 

LightningData turretCharge
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

//======================================================================== Grav Charge
LightningData gravCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 100.0;
   coneAngle        = 40.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 1.0;
   segmentDivisions = 2;
   numSegments      = 1;
   beamWidth        = 0.5;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function gravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{

	%playerId = %shooterId;
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
	else
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

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

//=======================================================================================================================
//						    Repair Class Ammos
//=======================================================================================================================

//======================================================================== 
RepairEffectData RepairBolt
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

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
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
		%player.repairRate   = 0.1;
		
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

function RepairBolt::onRelease(%this, %player)
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

function RepairBolt::checkDone(%this, %player)
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
					
					%objectTeam = GameBase::getTeam(%object);								//=== Team Object.
					%playerTeam = GameBase::getTeam(%player); 								//=== Team Player.
					%lastdamage = GameBase::getControlClient(%object.lastDamageObject);	

					if (%objname == "Remote Mortar Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Laser Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Point Defense Laser Mine")		%pntval = $Score::ObjTurretS;
					else if (%objname == "EMP Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "ELF Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
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
					%lastdamage = $lastdamageobj[%object];
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
				//echo ("Infecting");
				
				if (%target.infected == "true")
				{
					Client::sendMessage(%client,0," Your team's " @ %name @ " is already protected from hacking.");	
					return;
				}
				else if(checkHackable(%name, %shape) == 0 || getObjectType(%player.repairTarget) != "Player")
				{
					$hacking[%client] = "true";
					//echo ("Orgin Team = " @ $origTeam[%target]);
					if($origTeam[%target] == "")
					{
						//echo ("No original team set. Marking.");
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
				else
				{
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking[%client] = "true";
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
		%shape = (GameBase::getDataName(%target)).shapeFile;
		
		if (checkHackable(blah, %shape) == "1")
		{
			bottomprint(%Client, "RegenPack does not work on this." ,3);
			Player::trigger(%player,$WeaponSlot,false);			
			return;
		}
		//======================================================================================= USED AGAINST NME
		if (gamebase::Getteam(%player) != gamebase::Getteam(%object) && gamebase::getteam(%object) != "-1")
		{
			%shape = (GameBase::getDataName(%target)).shapeFile;
			
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
						Client::sendMessage(%tc,1, "You are being charged by " @ Client::getName(%client)); 
						Player::trigger(%player, $WeaponSlot, false); 
						return; 
					} 
					
					Client::sendMessage(%client,1, "Powering " @ Client::getName(%tc)); 
					Client::sendMessage(%tc,1, "Receiving power from " @ Client::getName(%client)); 

					%tc.isPowered = true; 
					%player.powerTarget = ""; 
					%target.shieldStrength = 0.025; 
					schedule ("" @ %target @ ".shieldStrength = 0;",240);
					Player::trigger(%player, $WeaponSlot, false); 
					return; 
				}
				else if(%objType == "Flier")
				{
					%player.powerTarget = ""; 
					%target.shieldStrength = 0.025;
					schedule ("" @ %target @ ".shieldStrength = 0;",240);
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
//------------------------------------------------------------------------------------------------------------------------
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
		
	//================================================================================================= AccelPad
	if (String::findSubStr(%name, "Accel Pad") >= 0)
	{
		%item = "AccelPPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Launch Pad
	if (String::findSubStr(%name, "Launchboard") >= 0)
	{
		%item = "LaunchPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}

	//================================================================================================= Teleport Pad
	if (String::findSubStr(%name, "Teleport Pad") >= 0)
	{
		%item = "TeleportPack";
		RemoveBeam(%this.beam1);		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	
	//================================================================================================= Ion Turret
	if (String::findSubStr(%name, "Ion Turret") >= 0)
	{
		%item = "TurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %description);
		return 1;
	}
	//================================================================================================= AATurret
	if (String::findSubStr(%name, "Anti-AirCraft Turret") >= 0)
	{
		%item = "BarragePack";		
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %description);
		return 1;
	}

	//======================================================================================== Command Station
	if (String::findSubStr(%name, "Remote Command Station") >= 0)
	{
		%item = "DeployableComPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	//========================================================================================== Sensor Jammer
	if (String::findSubStr(%name, "Sensor Jammer") >= 0)
	{
		%item = "DeployableSensorJammerPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Pulse Sensor
	if (String::findSubStr(%name, "Remote Pulse Sensor") >= 0)
	{
		%item = "PulseSensorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Motion Sensor
	if (String::findSubStr(%name, "Motion Sensor") >= 0)
	{
		%item = "MotionSensorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Camera 
	if (String::findSubStr(%name, "Camera") >= 0)
	{
		%item = "CameraPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Blast Wall
	if (String::findSubStr(%name, "Blast Wall") >= 0)
	{
		%item = "BlastWallPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Blast Floor
	if (String::findSubStr(%name, "Blast Floor") >= 0)
	{
		%item = "BlastFloorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Small Force Field
	if (String::findSubStr(%name, "Small Force Field") >= 0)
	{
		%item = "ForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Large Force Field
	if (String::findSubStr(%name, "Large Force Field") >= 0)
	{
		%item = "LargeForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Large Shock Force Field
	if (String::findSubStr(%name, "Shock Floor") >= 0)
	{
		%item = "ShockFloorPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Large Shock Force Field
	if (String::findSubStr(%name, "Large Shock Force Field") >= 0)
	{
		%item = "LargeShockForceFieldPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//========================================================================================= Deployable Platform
	if (String::findSubStr(%name, "DeployablePlatform") >= 0)
	{
		%item = "PlatformPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}	
	//==================================================================================== Healing Plant
	if (String::findSubStr(%name, "Healing Plant") >= 0)
	{
		%item = "PlantPack";		
		objectTearup (%this, %item, %client, %player, 0, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Rocket Turret
	if (String::findSubStr(%name, "RMT Rocket Turret") >= 0)
	{
		%item = "RocketPack";		
		objectTearup (%this, %item, %client, %player, 1, 100, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Plasma Turret
	if (String::findSubStr(%name, "RMT Plasma Turret") >= 0)
	{
		%item = "PlasmaTurretPack";		
		objectTearup (%this, %item, %client, %player, 1, 35, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Elf Turret
	if (String::findSubStr(%name, "Deployable Elf Turret") >= 0)
	{
		%item = "DeployableElf";		
		objectTearup (%this, %item, %client, %player, 1, 20, %flagdist, %description);
		return 1;
	}
	//================================================================================================= EMP Turret
	if (String::findSubStr(%name, "EMP Turret") >= 0)
	{
		%item = "ShockPack";		
		objectTearup (%this, %item, %client, %player, 1, 10, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Remote Mortar
	if (String::findSubStr(%name, "RMT Mortar Turret") >= 0)
	{
		%item = "TargetPack";		
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Laser Turret
	if (String::findSubStr(%name, "Laser Turret") >= 0)
	{
		%item = "LaserPack";		
		objectTearup (%this, %item, %client, %player, 1, 55, %flagdist, %description);
		return 1;
	}
	//================================================================================================= Arbitor Beacon
	if (String::findSubStr(%name, "ArbitorBeacon") >= 0)
	{
		%item = "ArbitorBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= EMPBeacon
	if (String::findSubStr(%name, "EMPBeacon") >= 0)
	{
		%item = "EMPBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= JammerBeacon
	if (String::findSubStr(%name, "JammerBeacon") >= 0)
	{
		%item = "JammerBeaconPack";		
		objectTearup (%this, %item, %client, %player, 1, 0, %flagdist, %description);
		return 1;
	}
	//================================================================================================= ShieldBeacon
	if (String::findSubStr(%name, "Shield Device") >= 0)
	{
		%item = "ShieldBeaconPack";		
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
	deleteObject(%this);
	$disassymble[%player] = false;
}

//===============================================================================================================
//													 Lock Jaw
//===============================================================================================================


LightningData LockJaw
{
	bitmapName       = "paintPulse.bmp";

	damageType       = $GravDamageType;
	boltLength       = 700.0;
	coneAngle        = 10.0;
	damagePerSec      = 0.00001;
	energyDrainPerSec = 0;

	boltLength       = 700.0;
	segmentDivisions = 2;
	beamWidth        = 0.05;
	updateTime   = 150;
	skipPercent  = 1.0;
	displaceBias = 0.25;

	lightRange = 3.0;
	lightColor = { 0.15, 0.15, 0.95 };

	soundId = SoundELFFire;
};

function LockJaw::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %player)
{
	%client = Player::getClient(%player);

	if (!%client.target || %client.target == "-1" || %client.target == %player)
		%client.target = %target;

	%name = GameBase::getDataName(%target);
	%team = GameBase::getTeam(%target);
	%pTeam = GameBase::getTeam(%player);
	%pName = Client::getName(%client);
  	%type = getObjectType(%target);

	if ($debug) echo ("Target       " @ %client.target);
	if ($debug) echo ("Target Name  " @ %name);
	if ($debug) echo ("Target Team  " @ %team);
	if ($debug) echo ("Player Team  " @ %pTeam);
	if ($debug) echo ("Player Name  " @ %pName);

	echo ("Type " @ %type);
	
	if (%type == "Player" || %type == "Flier" || %type == "Turret")
	{}
	else
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Lock Failed, No Targetable Object!\", 3);", 0);
		schedule("Client::sendMessage(" @ %client @ ",1,\"Lock Failed, No Targetable Object!~waccess_denied.wav\");",0);
		%client.target = -1;
		return;
	}

	if (!%client.target || %client.target == "-1" || %client.target == %player)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>No Lock, Attempting To Acquire!\", 3);", 0);
		schedule("Client::sendMessage(" @ %client @ ",1,\"No Lock, Attempting To Acquire!~waccess_denied.wav\");",0);
		%client.target = -1;
		Player::trigger(%player,$WeaponSlot,false);
		return;
	}
	if (%client.target != "-1")
	{
		if (gamebase::getteam(%client.target) == gamebase::getteam(%player))
		{
			schedule("bottomprint(" @ %client @ ", \"<jc><f1>Lock Failed, Can Not Target Friendlies!\", 3);", 0);
			schedule("Client::sendMessage(" @ %client @ ",1,\"Lock Failed, Can Not Target Friendlies!~waccess_denied.wav\");",0);
			%client.target = -1;
			return;
		}
		schedule("Client::sendMessage(" @ %client @ ",1,\"** LockJaw Aquired - Active For Next 15 Seconds!!!~wmine_act.wav\");",0);			
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>LockJaw Aquired - Active For Next 15 Seconds! - Fire Now To Launch!\", 3);", 0);
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>LockJaw Lost Lock!\", 3);", 15);
		schedule("" @ %client @ ".target = \"-1\";", 15);
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %player @ "));",0);
		Player::trigger(%player,$WeaponSlot,false);
		LockJaw(%client,%targetId);		
	}
}
function LockJaw::onAcquire(%this, %player, %target){}
function LockJaw(%clientId, %targetId) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " has you in LockJaw!!!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 
function LockJawFire(%player, %target)
{
	if ($debug) echo ("Firing Locker");
	
	%client = Player::getClient(%player);

	Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);	
	
	$targetingmissile = %client.target;
	Projectile::spawnProjectile("MiniMissileTracker",%trans,%player,%vel,%client.target);
	schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));",0);
}

function LockJaw::onRelease(%this, %player)
{
	%client = Player::getClient(%player);
	%object = %player.target;
	
	if ($debug) echo ("Object Target " @ %player.target);
	if ($debug) echo ("Shootr Client " @ %client);
}

//===============================================================================================================
//						Special Functions
//===============================================================================================================
function NuclearExplosion(%this)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	
	if (!%player)
		return;
	
	%pos = gamebase::getposition(%this);
	%Set = newObject("nukeset",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 15, 15, 25, 0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		GameBase::applyDamage(%obj, $NukeDamageType, 1.5, GameBase::getPosition(%obj), "0 0 0", "0 0 0", %player);		
	}
	deleteObject(%set);

	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));	
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);

	%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBaseLight, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0);

	%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBase, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
	
	%obj = newObject("","Mine","NRing1"); 
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,0,false);
 	gamebase::setposition(%obj, %pos);
	
	%padd = "0 0 3.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",1.1);

	%padd = "0 0 4.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);

	%padd = "0 0 8.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);
	
	%padd = "0 0 10.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
	
	%obj = newObject("","Mine","NRing1"); 
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,0,false);
 	gamebase::setposition(%obj, %pos);
 	
	%padd = "0 0 25.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 35.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
	
	%obj = newObject("","Mine","NRing1"); 
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,0,false);
 	gamebase::setposition(%obj, %pos);
	
	%padd = "0 0 45.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
	
	%padd = "15.0 0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "-15.0 0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 15.0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 -15.0 60.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 75.0";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 65";%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);

	deleteObject(%this);	
}

function DeployBomblets(%this, %count) 
{
        %clientId = %this.deployer;
        %player = Client::GetOwnedObject(%clientId);
	
	GameBase::setTeam(%this,GameBase::getTeam(%player));

	if(%count && %this)
	{
		%obj = newObject("","Mine","Bomblet1");
		%obj.deployer = %clientId;
		GameBase::throw(%obj,%player,-20,false);
 		addToSet("MissionCleanup", %obj);
		GameBase::setPosition(%obj, gamebase::getposition(%this));

		%obj = newObject("","Mine","Bomblet2");
		%obj.deployer = %clientId;
		GameBase::throw(%obj,%player,60,true);
	 	addToSet("MissionCleanup", %obj);
		GameBase::setPosition(%obj, gamebase::getposition(%this));

		%obj = newObject("","Mine","Bomblet3");
		%obj.deployer = %clientId;
		GameBase::throw(%obj,%player,50,true);
		addToSet("MissionCleanup", %obj);
		GameBase::setPosition(%obj, gamebase::getposition(%this));

		%count -= 1;
		schedule("DeployBomblets(" @ %this @ ", " @ %count @ ");",0.5,%this);
	}
}

