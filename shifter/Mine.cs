//===============================
// Mine Data
//===============================
// Anti-Personel Mine		- Scout, Goliath
// Proximity Mine		- Engineer
// SubSpace Mine		- Chemeleon
// Mock-Repair Kit		- Assassin
// Speed Boost			- Mercinary
// Flag Mine			- Assassin
// ShockWave			- Arbitor
// Replicator			- Engineer
//============================================================================================ Anti-Personel Mine

MineData AntipersonelMine
{
	className = "Mine";
   	description = "Antipersonel Mine";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("mineset",SimSet);
		
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		
		deleteObject(%set); //
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//============================================================================================ Proximity Detection Mine

MineData ProxMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	//shapeFile = "mine";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 20;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ProxMine::onAdd(%this)
{
	%this.damage = 0;
	ProxMine::deployCheck(%this);
}

function ProxMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);

	if ((%type == "Player" || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
	{		
	
		if ($ScreamerDelay == "" || $ScreamerDelay == 0)
		{
			$proxteam = GameBase::getTeam(%this);
			$ScreamerDelay = "1";
			TeamMessages(1, $proxteam, "Incomming Enemies. ~wusepack.wav~wusepack.wav~wusepack.wav~wusepack.wav~wusepack.wav");
			schedule("$ScreamerDelay = 0;", 10);
			//echo ("Alerting Team");
		}

	}		
}

function ProxMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("proxmineset",SimSet);

		deleteObject(%set); //
	}
	else 
		schedule("ProxMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ProxMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function ProxMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== SubSpace-Cloak Mine

MineData SubspaceMine
{
	className = "Mine";
        description = "Subspace Mine";
        shapeFile = "sensor_small";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 15.0;
        damageValue = 0.85;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function SubspaceMine::onAdd(%this)
{
	//echo("SubSpace Mine Added");

	%this.damage = 0;
        SubspaceMine::deployCheck(%this);
}

function SubspaceMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::startFadeOut(%this);
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);

		%set = newObject("subspset",SimSet);

		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
        schedule("SubspaceMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function SubspaceMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        
        if (!(GameBase::getTeam(%object) == GameBase::getTeam(%this)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
        GameBase::setDamageLevel(%this, %data.maxDamage);
}



//==================================================================================================== Mock Repair Pack

MineData HoloMine
{
	className = "Mine";
   description = "Hologram";
   shapeFile = "armorPack";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 15.0; //250
	damageValue = 0.75; //0
	damageType = $MineDamageType;
	kickBackStrength = 350; //500
	triggerRadius = 2.5; //250
	maxDamage = 2.00;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HoloMine::onAdd(%this)
{
	//echo("Holo Mine Added");

	%this.damage = 0;
	HoloMine::deployCheck(%this);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);

}

function HoloMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HoloMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
	 	GameBase::setActive(%this,true);
		%set = newObject("holomineset",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function HoloMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


//==================================================================================================== Speed Boost
// Super Speed boost

MineData Booster
{
	className = "Mine";
   description = "Speed Booster";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 300; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Booster::onAdd(%this)
{
	%this.damage = 0;
	Booster::deployCheck(%this);
}

function Booster::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == Boost || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Booster::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("boosterset",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		//deleteObject(%set);
	}
	else 
		schedule("Booster::deployCheck(" @ %this @ ");", 3, %this);
}	

function Booster::onDestroyed(%this)
{
	//$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

function Boosert::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== Flag Mine - Decoy

MineData Hologram
{
	className = "Mine";
	description = "Flag";
	shapeFile = "flag";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 5.0; //250
	damageValue = 0.75; //0
	damageType = $MineDamageType;
	kickBackStrength = 150; //500
	triggerRadius = 2.5; //250 //2.5
	maxDamage = 3.00;//0
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };

};

function Hologram::onAdd(%this)
{
	%this.damage = 0;
	Hologram::deployCheck(%this);
}

function Hologram::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        if (!(GameBase::getTeam(%object) == GameBase::getTeam(%this)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("hologramset",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}	

function Hologram::onDestroyed(%this)
{
}

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $ShrapnelDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== ShockWave Mine

MineData ShockMine
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "ShockWave Mine";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $MortarDamageType;
	kickBackStrength = 500;
	triggerRadius = 1.0;
	maxDamage = 2.0;
};

function ShockMine::onAdd(%this)
{
	
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut(" @ %this @ ");",8.0,%this);

}
function ShockMine::onCollision(%this,%obj)
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

function ShockMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function ShockMine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//==================================================================================================== Replicator

MineData ReplicatorMine
{
	className = "Mine";
	description = "Replicating Mine";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ReplicatorMine::onAdd(%this)
{
	%this.damage = 0.0;
	ReplicatorMine::deployCheck(%this);
}

function ReplicatorMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	
	if (((%type == "Player")  || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) //JR 1/31/99
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ReplicatorMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	{
		%team = GameBase::getTeam(%this);
		//echo(%team @ " in deploy check");

		$TeamItemCount[%team @ "replicatingmine"]++;
		
		if(%this.generation == 0)
			$TeamItemCount[%team @ "originalreplicatingmine"]++;
 	
	 	GameBase::setActive(%this,true);
		
		%set = newObject("replicatorset",SimSet);
		
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[%team @ "replicatingmine"] > $TeamItemMax[replicatingmine])
		{
			%this.generation = 5;
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("ReplicatorMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ReplicatorMine::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	//echo(%team @ " in on Destroyed");

	$TeamItemCount[%team @ "replicatingmine"]--;

	if(%this.generation < 4)
		replicateMines(%this, %this.generation+1);
}

function ReplicatorMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.3;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function replicateMines(%this, %generation)
{
	%team = GameBase::getTeam(%this);
	//echo("Creating generation " @ %generation @ " for team " @ %team);

	%obj = newObject("","Mine","ReplicatorMine");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);

	%obj = newObject("","Mine","ReplicatorMine");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);
}


//================================================================================================= Telebeacon Mine

MineData Telebeacon
{
	className = "Mine";
        description = "Telebeacon";
        shapeFile = "sensor_small";
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

function Telebeacon::onAdd(%this)
{
	if ($debug) echo("Telebeacon Mine Added");
	%this.damage = 0;
        Telebeacon::deployCheck(%this);
}

function Telebeacon::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::setActive(%this,true);
		%clientId = %this.deployer;
		%pos = GameBase::getPosition(%this);
		%clientId.telepoint = %pos;
		bottomprint(%clientId, "<jc><f2>Your TeleBeacon Is Now Active, Use Pack To Teleport!", 3);
	}
	else 
        	schedule("Telebeacon::deployCheck(" @ %this @ ");", 3, %this);
}	

function Telebeacon::onCollision(%this,%object)
{
	return;
}

function Telebeacon::onDestroyed(%this)
{
	%clientId = %this.deployer;
	bottomprint(%clientId, "<jc><f2>Your TeleBeacon Has Been Destroyed!!!", 3);
	%clientId.telepoint = "false";
	$TeamItemCount[GameBase::getTeam(%this) @ "TeleBeacons"]--;
}

function Teleceacon::onDeactivate(%this)
{
	Telebeacon::onDestroyed(%this);
}


//================================================================================================ Suicide Pack 2 On Deploy

MineData PickUpPack
{
	mass = 999.3;
	drag = 999.0;
	density = 999.0;
	elasticity = 0.0;
	friction = 999.0;
	className = "Handgrenade";
	description = "ShockWave Mine";
	shapeFile = "MagCargo";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $MortarDamageType;
	kickBackStrength = 100;
	triggerRadius = 1.0;
	maxDamage = 2.0;
};

function PickUpPack::onAdd(%this)
{
	PickUpPack::deployCheck(%this);
	schedule ("deleteobject( " @ %this @ ");",120);
}

function PickUpPack::onCollision(%this,%player)
{
	if(getObjectType(%player) != "Player") {return;}
	if(Player::isDead(%player)) {return;}

    	%client = Player::getClient(%player);
    	%plTeam = GameBase::getTeam(%player);
	%ppTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	
	if (%player != -1)
	{
		%cnt = Station::itemsToResupply(%player);
		//echo ("Ammount " @ %cnt);
		
		if(getSimTime() - %this.enterTime > 11)
			%cnt = 0;
			
		if (%cnt != 0)
		{
			return;
		}
	}
	GameBase::setActive(%this,false);
	%this.enterTime="";
}

function PickUpPack::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
	 	GameBase::setActive(%this,true);
		Gamebase::setMapName(%this, "Pick Up Pack");
		%this.ammount = 5000;	
		//echo ("Active");
	}
	else
	{
		schedule("PickUpPack::deployCheck(" @ %this @ ");", 3, %this);
	}
}

TurretData MineNet
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = HoverMine;
	maxDamage = 0.22;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 100.0;
	speedModifier = 100.5;
	range = 28;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "MineNet";
};
function MineNet::onAdd(%this)
{
 	schedule ("GameBase::setActive(" @ %this @ ",true);", 0.5);
	schedule ("MineNet::DeployNet(" @ %this @ ");", 0.7, %this);
}

function MineNet::DeployNet(%this)
{
	%pos = gamebase::getposition(%this);
	%rot = gamebase::getrotation(%this);

	if (%this.deploy)
		return;
	%this.deploy = 1;
	
	%rot = getword (%rot, 0) @ " " @ (getword(%rot, 1)) @ " " @ (getword(%rot, 2) / 4);
	
	%y0 = Vector::getFromRot(%rot, 0);
	%y1 = Vector::getFromRot(%rot, 10);
	%y2 = Vector::getFromRot(%rot, 20);
	%y3 = Vector::getFromRot(%rot, -10);
	%y4 = Vector::getFromRot(%rot, -20);

	schedule ("MineNet::PopMine (\"" @ %this @ "\",\"" @  %pos @ "\", \"" @ %rot @ "\");",0.1);	


	for (%x = 0; %x < 5; %x++)
	{
		%k = %y[%x];
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " -14.0";
		%pos1 = Vector::add(gamebase::getposition(%this), %padd);
		schedule ("MineNet::PopMine (\"" @ %this @ "\",\"" @  %pos1 @ "\", \"" @ %rot @ "\");",0.22);	
	}
	for (%x = 0; %x < 5; %x++)
	{
		%k = %y[%x];
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " -7.0";
		%pos1 = Vector::add(gamebase::getposition(%this), %padd);
		schedule ("MineNet::PopMine (\"" @ %this @ "\",\"" @  %pos1 @ "\", \"" @ %rot @ "\");",0.26);	
	}
	for (%x = 0; %x < 5; %x++)
	{
		%k = %y[%x];
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " 0";
		%pos1 = Vector::add(gamebase::getposition(%this), %padd);
		schedule ("MineNet::PopMine (\"" @ %this @ "\",\"" @  %pos1 @ "\", \"" @ %rot @ "\");",0.35);	
	}
	for (%x = 0; %x < 5; %x++)
	{
		%k = %y[%x];
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " 7.0";
		%pos1 = Vector::add(gamebase::getposition(%this), %padd);
		schedule ("MineNet::PopMine (\"" @ %this @ "\",\"" @  %pos1 @ "\", \"" @ %rot @ "\");",0.45);	
	}
	for (%x = 0; %x < 5; %x++)
	{
		%k = %y[%x];
		%padd = getword (%k, 0) @ " " @ getword (%k, 1) @ " 14.0";
		%pos1 = Vector::add(gamebase::getposition(%this), %padd);
		schedule ("MineNet::PopMine (\"" @ %this @ "\",\"" @  %pos1 @ "\", \"" @ %rot @ "\");",0.65);	
	}
}

function MineNet::PopMine(%this, %pos, %rot)
{
	if (!CheckForObjects(%pos, 5,5,5))
	{
		if ($debug) echo ("Obstructed");
		return;
	}
	else
	{
		%obj = newObject("NetMine","Turret", "MineNetKnot",true);
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		GameBase::setPosition(%obj,%pos);
		addToSet("MissionCleanup", %obj);
		//echo ("Team " @ GameBase::getTeam(%obj));
	}
}

TurretData MineNetKnot
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = HoverMine;
	maxDamage = 0.22;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 100.0;
	speedModifier = 100.5;
	range = 28;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "MineNet";
};


function MineNetKnot::onFire(%this) 
{
}

function MineNetKnot::onAdd(%this)
{
	GameBase::startFadeIn(%this);
	schedule("MineNetKnot::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.0;
	%time = 120 + (getrandom() * 10);
	schedule("MineNetKnot::Remove(" @ %this @ ");",120);
	%this.active = 1;
}

function MineNetKnot::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function MineNetKnot::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function MineNetKnot::onDestroyed(%this) { Turret::onDestroyed(%this); }
function MineNetKnot::onPower(%this,%power,%generator) {}
function MineNetKnot::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); }	

function MineNetKnot::onCollision(%this,%object)
{
	if (gamebase::getteam(%this) != gamebase::getteam(%object))
	{
		%pos = gamebase::getposition(%this);
		%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
		GameBase::applyRadiusDamage($MineDamageType, %pos, 12, 1.0, 1.0, %this);
	}
}
function MineNetKnot::verifyTarget(%this,%target) 
{
	
	%tpos = gamebase::getposition(%this);
	%ppos = gamebase::getposition(%target);
	
	%dist = Vector::getDistance(%tpos, %ppos);
	
	if (%dist < 27)
	{
		schedule("MineNetKnot::Remove(" @ %this @ ");",0.7);
		return "True";
	}
}

function MineNetKnot::Remove(%this)
{
	if (%this.active == 1)
	{
		%this.active = 0;
		deleteobject(%this);
	}
	else
		return;
}

SeekingMissileData HoverMine
{
  	bulletShapeName = "sensor_small.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.6;
	damageType = $MineDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 20.0;
	muzzleVelocity = 10.0;
	terminalVelocity = 515.0;
	acceleration = 100.0;
	totalTime = 21.0;
	liveTime = 55.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	seekingTurningRadius = 1.0;
	nonSeekingTurningRadius = 1.1;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	
	trailType   = 1;
	trailLength = 10;
	trailWidth  = 0.10;
	
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;   
};

//============================================================================================ Anti-Personel Mine

MineData AntipersonelLightMine
{
	className = "Mine";
   	description = "Antipersonel Light Mine";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 5.0;
	damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 50;
	triggerRadius = 1.5;
	maxDamage = 0.25;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function AntipersonelLightMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelLightMine::deployCheck(%this);
}

function AntipersonelLightMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelLightMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelLightMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
	}
	else 
		schedule("AntipersonelLightMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelLightMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelLightMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}