//====================================
// Grenades
//====================================

// Standard	- Merc
// Tranq	- Arbitor
// Emp		- Engineer
// Concussion	- Scout
// Plastique	- Chemeleon
// Mortar	- Dreadnaught
// FireBomb	- Goliath
// OldGren - DM armor

//==================================================================================================== Standard Grenade

MineData Handgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;

	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}


//==================================================================================================== TranqGrenade

MineData Tranqgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 0.55;

	damageType = $EnergyDamageType;

	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Tranqgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Tranqgrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Tranqgrenade::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//==================================================================================================== EMP Grenade

MineData EMPgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.4;
	damageType = $FlashDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function EMPgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function EMPgrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $FlashDamageType)
		%value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}


//==================================================================================================== Concussion Grenade

MineData Concussion
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 15.0;
	damageValue = 0.50;
	damageType = $PlasmaDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Concussion::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Concussion::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Concussion::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


// Concussion
MineData Concussion2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 35.0;
	damageValue = 0.55;
	damageType = $PlasmaDamageType; // burn the victim
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Concussion2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Concussion2::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Concussion2::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//==================================================================================================== Plastique

MineData Nukebomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Plastique";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 10.0;
	damageValue = 4.0;
	damageType = $MortarDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Nukebomb::onAdd(%this)
{	
	%obj = %this;
	%data = GameBase::getDataName(%this);
}

function Nukebomb::onCollision(%this,%obj)
{
    	if(getObjectType(%obj) != "Player")
	{
        	return;
	}

    	if(Player::isDead(%obj))
	{
        	return;
	}

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	
	%armor = Player::getArmor(%obj);
	if (%armor == "earmor" || %armor == "efemale")
	{
		if(floor(getRandom() * 10) > 6)
		{	
			Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
			return;
		}
		if(%this) deleteobject(%this);
		Client::sendMessage(%c,1,"You disarm the Plastique Explosive.");
	}  
}

function Nukebomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Nukebomb::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


//==================================================================================================== Mortar Grenade

MineData Mortarbomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = mortarExp;

	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 1.5;
	maxDamage = 2.0;
};

function Mortarbomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

function Mortarbomb::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	if (%type == "Player")
	{	
		%data = GameBase::getDataName(%this);
		schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
	}
}

//==================================================================================================== Fire Bomb Grenade

MineData Firebomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 35.0;
	damageValue = 0.1;
	damageType = $ElectricityDamageType;
	kickBackStrength = 650;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Firebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//==================================================================================================== Mortar Grenade

MineData Detbomb
{
	mass = 0.3;
	drag = 1.0;
	density = 4.0;
	elasticity = 0.25;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
   	shapeFile = "mine";
	shadowDetailMask = 0;
	explosionId = flashExpLarge;
	explosionRadius = 3.0;
	damageValue = 0.5;
	damageType = $EnergyDamageType;
	kickBackStrength = 700;
	triggerRadius = 2.0;
	maxDamage = 8.0;
};

function Detbomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",10.0,%this);
}

function Detbomb::onDestroyed(%this)
{
	%position = GameBase::getPosition(%this);
	%posX = getWord(%position,0);
	%posY = getWord(%position,1);
	%posZ = getWord(%position,2);
	%newposition = (%posX @ " " @ %posY @ " " @ (%posZ + 0.5));
	gamebase::setposition(%this, %newposition);
}

function Detbomb::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	%thisClient = %this.deployer;
	%objClient = Player::getClient(%object);
	%thisTeam = GameBase::getTeam(%thisClient);
	%objTeam = GameBase::getTeam(%object);
   if ((%type == "Player" && (%objTeam != %thisTeam || %objClient == %thisClient)) || (%type == "Turret" && %objTeam != %thisTeam))
	{	
		%data = GameBase::getDataName(%this);
		schedule("Mine::Detonate(" @ %this @ ");",0.01,%this);
	}
}