//================================================================================================================= 
//						ShockWave Missile
//================================================================================================================= 

MineData ShockMissile
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "ShockWave Missile";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $MortarDamageType;
	kickBackStrength = 500;
	triggerRadius = 15.0;
	maxDamage = 2.0;
};

function ShockMissile::onAdd(%this)
{
	if (GameBase::setActive(%this,true))
	{
		//echo ("Created " @ %this @ ".");
	}

	%data = GameBase::getDataName(%this);
}
function ShockMissile::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
        	return;
	}

    	if(Player::isDead(%obj))
	{
        	return;
	}

    	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if (GameBase::getTeam(%this)!= GameBase::getTeam(%obj))
	{
        	GameBase::startFadeIn(%this);
		schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
	}
}

function ShockMissile::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function ShockMissile::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
