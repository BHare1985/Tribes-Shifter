

//==================================================================================================== Penis Explosion

MineData PenisBlast
{
	className = "Mine";
	description = "Penis";
	shapeFile = "breath";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 5.0;
	damageValue = 0.001;
	damageType = $FlashDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function PenisBlast::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//==================================================================================================== Bot Explosion

MineData BotBlast
{
	className = "Mine";
	description = "Bot Brain";
	shapeFile = "breath";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 5.0;
	damageValue = 0.001;
	damageType = $FlashDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function BotBlast::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//==================================================================================================== CloakBlast

MineData CloakBlast
{
	className = "Mine";
	description = "CloakBlast";
	shapeFile = "breath";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.1;
	damageType = $CloakDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function CloakBlast::onAdd(%this)
{
    schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}


//==================================================================================================== EMP Blast

MineData EMPBlast
{
	className = "Mine";
	description = "CloakBlast";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.1;
	damageType = $FlashDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function EMPBlast::onAdd(%this)
{    schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//==================================================================================================== Havoc Blast
MineData HavocBlast
{
	className = "Mine";
	description = "HavocBlast";
	shapeFile = "breath";
	explosionId = ShockwaveThree;
	explosionRadius = 20.0;
	damageValue = 2.0;
	damageType = $NukeDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HavocBlast::onAdd(%this)
{
	if ($debug) echo ("Blammo");
    		schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
	//%pl = %this.fired;
   //schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
	
	//%pos1 = gamebase::getposition(%this);
	//%vel = "0 0 0";
	
	//%padd = "0 0 1.5";
	//%pos = Vector::add(%pos1, %padd);
	//%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	//schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %pl @ "\", \"" @ %vel @ "\");",0.1);
}
//greyflcn
//====================================================================== MDM Blast
MineData MDMBlast
{
	className = "Mine";
	description = "HavocBlast";
	shapeFile = "breath";
	shadowDetailMask = 4;
	explosionId = ShockwaveThree;
	explosionRadius = 20.0;
	damageValue = 2.0;
	damageType = $MDMDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData oldMDMBlast
{
	className = "Mine";
	description = "MDMBlast";
	shapeFile = "breath";
	shadowDetailMask = 4;
	explosionId = ShockwaveThree;
	explosionRadius = 20.0;
	damageValue = 3.0;
	damageType = $PlasmaDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 8.0;
	shadowDetailMask = 0;
	destroyDamage = 8.0;
	damageLevel = {1.0, 1.0};
};

function MDMBlast::onAdd(%this)
{	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//greyflcn
//================================================= MDM Blast
MineData MDMBlast2
{
	className = "Mine";
	description = "MDMBlast2";
	shapeFile = "breath";
	shadowDetailMask = 0;
	//explosionId = ShockwaveThree;
	explosionRadius = 8.0;
	damageValue = 0.1;
	damageType = $FlashDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 8.0;
	shadowDetailMask = 0;
	destroyDamage = 8.0;
	damageLevel = {1.0, 1.0};
};

function MDMBlast2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//======================================================================== Cloaking Blast

RocketData cloakingBlast
{   
   bulletShapeName = "rocket.dts";
   explosionTag    = shockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $CloakDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 0.01;

   muzzleVelocity   = 2.0;
   terminalVelocity = 2.0;
   acceleration     = 2.0;

   totalTime        = 0.01;
   liveTime         = 0.01;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;   
};

function cloakingBlast::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	GameBase::startFadeOut(%target);
	schedule("GameBase::startFadeIn(" @ %target @ ");", 90);
}
