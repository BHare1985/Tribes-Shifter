//===============================
// Mine Data
//===============================
// Anti-Personel Mine- Scout, Goliath, Mercinary
// Proximity Mine		- Engineer
// SubSpace Mine		- Chemeleon
// Mock-Repair Kit	- Assassin
// Flag Mine			- Assassin
// ShockWave			- Arbitor
// Replicator			- Engineer
//=============================================================== Anti-Personel Mine

function Mine::Triggered(%this, %object)
{
	%type = getObjectType(%object);
	%tdata = GameBase::getDataName(%this);
	%odata = GameBase::getDataName(%object);
	%active = GameBase::isActive(%this);
	%nme = ( GameBase::getTeam(%object) != GameBase::getTeam(%this) );
   if( %nme && %active && (%type == "Player" || %type == "Moveable" || %type == "Flier" || %tdata == %odata) ) 
		return true;
	else
		return false;
}

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
	if ( mine::triggered(%this, %object) )
		GameBase::setDamageLevel(%this, 10);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("mineset",SimSet);
		
		if(containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) > 1) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		
		if(%set) deleteobject(%set); //
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

	if(0.3333 < %this.damage+%value) 
		GameBase::setDamageLevel(%this, 0.6);
	else 
		%this.damage += %value;
}

//========================================================== Proximity Detection Mine

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
	if( mine::triggered(%this, %object) )
	{		
		%proxteam = GameBase::getTeam(%this);
		if (%proxteam.prxMineActive == "" || !%proxteam.prxMineActive)		
		{
			%proxteam.prxMineActive = 1;
			TeamMessages(1, %proxteam, "Incoming Enemies.~waccess_denied.wav");
			schedule(%proxteam @ ".prxMineActive = 0;", 10);
		}
	}		
}


function ProxMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("proxmineset",SimSet);

		if(%set) deleteobject(%set); //
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

//==================================================================== SubSpace-Cloak Mine

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
		if(containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) > 1) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		if(%set) deleteobject(%set);
	}
	else 
        schedule("SubspaceMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function SubspaceMine::onCollision(%this,%object)
{
	if( mine::triggered(%this, %object) )
		GameBase::setDamageLevel(%this, 10);
}



//====================================================================== Mock Repair Pack

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
	GameBase::setActive(%this,true);
	%this.damage = 0;
	HoloMine::deployCheck(%this);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}

function HoloMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);

	//&& GameBase::isActive(%this)

	if( mine::triggered(%this, %object) )
		GameBase::setDamageLevel(%this, 10);
	else
	{
		%armor = Player::getArmor(%object);
		%pack = Player::getMountedItem(%object,$BackpackSlot);
		if (%type == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%object) && (%armor == "larmor" || %armor == "lfemale") && %pack == -1)
		{
			%client = GameBase::getOwnerClient(%object);
			player::setitemcount(%object, RepairPack, 1);
			player::mountItem(%object, RepairPack, $BackpackSlot);
			Client::sendMessage(%client,0,"You received a RepairPack backpack~wDryfire1.wav");
			deleteobject(%this);
		}
	}
}


function HoloMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		%set = newObject("holomineset",SimSet);
		if(containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) > 1) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		if(%set) deleteobject(%set); //
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

//=================================================================== ShockWave Mine

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
	triggerRadius = 2.0;
	maxDamage = 2.0;
};

function ShockMine::onAdd(%this)
{
	GameBase::setActive(%this,true);
	%data = GameBase::getDataName(%this);
	ShockMine::deployCheck(%this);
	schedule("GameBase::startFadeOut(" @ %this @ ");",8.0,%this);
}
function ShockMine::onCollision(%this,%obj)
{
	if( mine::triggered(%this, %obj) )
		GameBase::setDamageLevel(%this, 10);
}

function ShockMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function ShockMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		%set = newObject("shockmineset",SimSet);
		if(containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) > 1)
			GameBase::setDamageLevel(%this, ShockMine.maxDamage);
		if(%set) deleteobject(%set);
	}
	else 
		schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ShockMine::Detonate(%this)
{
	GameBase::setDamageLevel(%this, ShockMine.maxDamage);
}

//============================================================= Replicator

MineData ReplicatorMine
{
	className = "Mine";
	description = "Replicating Mine";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = RepMineExp;//plasmaExp;
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
	if( mine::triggered(%this, %object) )
		GameBase::setDamageLevel(%this, 10);
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
		
		if(containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) > 1 || $TeamItemCount[%team @ "replicatingmine"] > $TeamItemMax[replicatingmine])
		{
			%this.generation = 5;
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		if(%set) deleteobject(%set);
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


//================================================================= Telebeacon Mine

MineData Telebeacon
{
	className = "Mine";
	description = "Telebeacon";
	//shapeFile = "discb";
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
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

function Telebeacon::onAdd(%this)
{
	if ($debug) echo("Telebeacon Mine Added");
	%this.damage = 0;
	GameBase::setActive(%this,true);
   Telebeacon::deployCheck(%this);
}

function Telebeacon::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		%clientId = %this.deployer;
		%pos = GameBase::getPosition(%this);
		%clientId.telepoint = %pos;
		GameBase::setIsTarget(%this,true);
		bottomprint(%clientId, "<jc><f2>Your TeleBeacon Is Now Active, Use Pack To Teleport!", 3);
	}
	else 
		schedule("Telebeacon::deployCheck(" @ %this @ ");", 0.1, %this);
}	

function Telebeacon::onCollision(%this,%object){}

function Telebeacon::onDestroyed(%this)
{
	%client = %this.deployer;
	bottomprint(%client, "<jc><f2>Your TeleBeacon Has Been Destroyed!!!", 3);
	%client.telepoint = "false";
	%client.telebeacon = "false";
	%client.teledisk = "false";
}

function Telebeacon::onDeactivate(%this)
{
	Telebeacon::onDestroyed(%this);
}


//================================================================== Suicide Pack 2 On Deploy

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
	schedule ("deleteobject( " @ %this @ ");",120,%this);
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
		if(getSimTime() - %this.enterTime > 11)
			%cnt = 0;
			
		if (%cnt != 0)
			return;
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
	}
	else
	{
		schedule("PickUpPack::deployCheck(" @ %this @ ");", 3, %this);
	}
}

function PickUpPack::onDestroyed(%this){}
//==================================================== Anti-Personel Mine

MineData AntipersonelLightMine
{
	className = "Mine";
   	description = "Antipersonel Light Mine";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 15.0;
	damageValue = 0.25;
	damageType = $MineDamageType;
	kickBackStrength = 50;
	triggerRadius = 1.5;
	maxDamage = 0.25;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
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
	if ((%type == "Player" || %data == AntipersonelLightMine || %data == Vehicle || %type == "Moveable") &&	GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) 
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

//==================================================================== Flag Mine - Decoy

MineData Hologram
{
	className = "Mine";
	description = "Flag";
	shapeFile = "flag";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 5.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 3.00;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	lightType = 2;
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

function Hologram::onAdd(%this)
{
	%this.damage = 0;
	GameBase::setActive(%this,true);
	Hologram::deployCheck(%this);
}

function Hologram::onCollision(%this,%object)
{
  if( mine::triggered(%this, %object) )
		GameBase::setDamageLevel(%this, 10);
	else
	{
		%armor = Player::getArmor(%object);
		%pack = Player::getMountedItem(%object,$BackpackSlot);
		if ((%armor == "larmor" || %armor == "lfemale") && %pack == -1)
		{
			%client = GameBase::getOwnerClient(%object);
			player::setitemcount(%object, DeployableSensorJammerPack, 1);
			player::mountItem(%object, DeployableSensorJammerPack, $BackpackSlot);
			Client::sendMessage(%client,0,"You received a DeployableSensorJammerPack backpack~wDryfire1.wav");
			deleteobject(%this);
		}
	}
}


function Hologram::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
		%set = newObject("set",SimSet);
		if(containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) > 1)
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		if(%set) deleteobject(%set);
	}
	else 
		schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}	

function Hologram::onDestroyed(%this)
{ %position=GameBase::getPosition(%this);
 %posX = getWord(%position,0);
 %posY = getWord(%position,1);
 %posZ = getWord(%position,2);
 %newposition = (%posX @ " " @ %posY @ " " @ (%posZ + 0.5));
 gamebase::setposition(%this, %newposition);
 $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]++;
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

//dmmine
MineData DmMine
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

function DmMine::onAdd(%this)
{
	%this.damage = 0;
	DmMine::deployCheck(%this);
}

function DmMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == DmMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DmMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("mineset",SimSet);
		
		if(containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) > 1) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		
		if(%set) deleteobject(%set); //
	}
	else 
		schedule("DmMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function DmMine::onDestroyed(%this){}

function DmMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


function Mine::Detonate(%this)
{
	%client = %this.deployer;
	%player = client::getownedobject(%client);

	Client::setOwnedObject(%client, %this);
	Client::setOwnedObject(%client, %player);
	
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}