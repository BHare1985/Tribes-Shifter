
//==================================================================================================== Nuclear Explosion
GrenadeData NBase
{
	explosionTag       = LargeShockwave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
	damageValue        = 3.5;
	damageType         = $NukeDamageType;

	explosionRadius    = 35;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};
function NBase::onAdd(%this) { }

GrenadeData NBaseLight
{
	explosionTag       = NukeWave;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
	damageValue        = 0.1;
	damageType         = $NukeDamageType;

	explosionRadius    = 55;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};
function NBaseLight::onAdd(%this) { }

GrenadeData NRing
{
	explosionTag       = LargeShockwave;
	
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
	damageValue        = 2.5;
	damageType         = $NukeDamageType;

	explosionRadius    = 35;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 1.1;
	liveTime           = 0.1;
	projSpecialTime    = 1.9;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};
function NRing::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",0.2,%this); }

MineData NRing1
{
	mass = 1.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0;
	friction = 10.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NukeDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};
function NRing1::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",0.2,%this); }


GrenadeData NBlast
{
	explosionTag       = grenadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;
	
	damageClass        = 1;
	damageValue        = 1.0;
	damageType         = $NukeDamageType;

	explosionRadius    = 25;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};

GrenadeData NCloud
{
	explosionTag       = mortarExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
	damageValue        = 1.0;
	damageType         = $NukeDamageType;

	explosionRadius    = 25;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
	smokeName              = "plasmatrail.dts";

	inheritedVelocityScale = 0.0;
};

//================================================================================================ Suicide Pack 1 (On Kill)

MineData Suicidebomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 100.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.2;
	maxDamage = 2.0;
};

function Suicidebomb::onAdd(%this)
{        
	schedule("NuclearExplosion(" @ %this @ ");",0.5,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

//================================================================================================ Suicide Pack 2 On Deploy

MineData Suicidebomb2
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 100.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Suicidebomb2::onAdd(%this)
{
	schedule("NuclearExplosion(" @ %this @ ");",20,%this);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",20,%this);

}

function Suicidebomb2::onCollision(%this,%obj)
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
		%rnd = floor(getRandom() * 10);
		if(%rnd < 5)
		{	
		    Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
			Mine::Detonate(%this);
			return;
		}
		else
		{	
		    deleteObject(%this);
		    Client::sendMessage(%c,1,"You disarm the DetPack.");
		}
	}
   
}

//==================================================================================================== Napalm Frags

GrenadeData Frag
{
	//bulletShapeName    = "mortar.dts";
   	bulletShapeName    = "plasmabolt.dts";
    	explosionTag = plasmaExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 10.0;
 	mass = 5.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.30;
 	damageType = $PlasmaDamageType;
 	explosionRadius = 15.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 75;
 	totalTime = 4.0;
 	liveTime = 4.0;
 	projSpecialTime = 4.0;
 	lightRange = 10.0;
	lightColor = { 1, 1, 0 }; 
 	inheritedVelocityScale = -1.5;
 	smokeName = "plasmatrail.dts";
 	soundId = SoundJetLight;
};
function Frag::onAdd(%this) {schedule("DeployFrags(" @ %this @ " , 7);",getRandom() + 2.0,%this); }

MineData Frag1
{
   	mass = 5.0;
   	drag = 1.9;
   	density = 2.0;
	elasticity = 0.15;
	friction = 0.5;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 20.0;
	damageValue = 0.65;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 1.5;	
	inheritedVelocityScale = 0.25;

};
function Frag1::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",getRandom() + 1.75,%this); }

MineData Frag2
{
   	mass = 5.0;
   	drag = 1.5;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 20.0;
	damageValue = 0.55;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 1.5;	
	inheritedVelocityScale = 0.35;

};
function Frag2::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",getRandom() + 1.5,%this); }

MineData Frag3
{
   	mass = 5.0;
   	drag = 1.1;
   	density = 2.0;
	elasticity = 0.25;
	friction = 1.5;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 20.0;
	damageValue = 0.45;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 1.5;	
	inheritedVelocityScale = 0.45;

};
function Frag3::onAdd(%this) { schedule("Mine::Detonate(" @ %this @ ");",getRandom() + 1.0,%this); }

function DeployFrags(%this, %count, %player) 
{
	if (!%player)
	{
		%cl = %this.deployer;
		%player = %cl;
	}
	else
	{
        	%cl = Player::getClient(%player);
        }
        if (!%cl)
        	%cl = 2048;

	%pos = gamebase::getposition(%this);
	%team = GameBase::getTeam(%player);

	for (%i = 0; %i < %count; %i++)
	{
		%frag = "Frag" @ (floor(getRandom()*3)+1);
		%obj = newObject("","Mine", %frag);
		%obj.deployer = %cl;
		addToSet("MissionCleanup", %obj);

		if ((floor(getRandom()*4)+1) > 2)
		{
			%dir = 120;
			if ((floor(getRandom()*4)+1) > 3)
				GameBase::throw(%obj,%cl,%dir,false);
			else
				GameBase::throw(%obj,%cl,%dir,true);
		}
		else
		{
			%dir = -80;
			if ((floor(getRandom()*4)+1) > 3)
				GameBase::throw(%obj,%cl,%dir,false);
			else
				GameBase::throw(%obj,%cl,%dir,true);
		}
		GameBase::setPosition(%obj, %pos);
	}
	return;
}
//==================================================================================================== Bomblettes

MineData Bomblet1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Bomblet2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Bomblet3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

//======================================================================== Bomb Module Shell
GrenadeData ModuleBomb
{
   bulletShapeName    = "mineammo.dts";
   explosionTag       = ShockwaveFour;
   collideWithOwner   = true;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 155.0;
   elasticity         = 0.01;

   damageClass        = 1;
   damageValue        = 2.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 40.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 25;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0;
   smokeName              = "rsmoke.dts";
};
