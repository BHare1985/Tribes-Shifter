ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	dbecho ("Use Pack  = " @ %item );

	dbecho (Player::getMountedItem(%player,$BackpackSlot));
	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::trigger(%player,$BackpackSlot);
	}
	//echo ("Done Pack " @ %item);
}

//======================================================================== More Like A Front Pack

ItemImageData PenisImage
{
	shapeFile  = "cactus1";

	mountPoint = 2;
	mountOffset = { 0, 0.1, -0.2 };
	mountRotation = { -1.572, 0, 0 };

	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;

	//projectileType = Undefined;
	accuFire = false;

	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxFire = SoundFlyerActive;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Penis
{
	heading = "bWeapons";
	description = "Penis";
	className = "Weapon";
	shapeFile  = "cactus1";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PenisImage;
	price = 0;
	showWeaponBar = true;
};
function Penis::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("Pee",%trans,%player,%vel);
}
function Penis::onDrop(%player,%item)
{
	Client::sendMessage(%client,0,"The curse of the penis can not be removed so easily.");
	return;
}
 
//======================================================================== Deployable Invo

ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
   	heading = "fStations";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
//	//validateShape = true;
//	validatematerials = true;
};


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function DeployableInvPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Invo Station",True,False,True,False,False,True,4,True,0,False, "DeployableInvStation", "DeployableInvPack");
}


//======================================================================== Deployable Ammo Station
ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   	heading = "fStations";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableAmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function DeployableAmmoPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Ammo Station",True,False,True,False,True,True,4,True,0,False, "DeployableAmmoStation", "DeployableAmmoPack");
}

//======================================================================== Deployable Command Center
ItemImageData DeployableComPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 4.5;
	firstPerson = false;
};

ItemData DeployableComPack
{
	description = "Command Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   	heading = "fStations";
	shadowDetailMask = 4	;
	imageType = DeployableComPackImage;
	mass = 4.0;
	elasticity = 0.2;
	price = $RemoteComEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableComPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function DeployableComPack::onDeploy(%player,%item,%pos)
{
	if (DeployableComPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableComPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Remote Command Station",True,False,True,False,True,True,4,True,0,False, "DeployableComStation", "DeployableComPack");
}

//======================================================================== Energy Pack
ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
	
//	//validateShape = true;
//	validateMaterials = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//======================================================================== Repair Pack

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
    	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	
//	//validateShape = true;
//	validateMaterials = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun)
		{
			Player::unmountItem(%player,$WeaponSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//======================================================================== Shield Pack

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 4;
	maxEnergy = 9;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	
	//validateShape = true;
	//validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	%armor = Player::getArmor(%clientId);

	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.022;
	%player.shieldon = true;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
	%player.shieldon = false;
}

//======================================================================== Sensor Jammer
ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "Sensor Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	
	//validateShape = true;
//	validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//======================================================================== Cloaking Device

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 9;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "Cloaking Device";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 600;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player);
	if(%radius < 0)
		%radius = 0;
	%radius += 2;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldOpen,0);
 	%player.cloaked = 1;
 	Cloaker(%player);
	GameBase::startFadeOut(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	Player::trigger(%player,$BackpackSlot,true);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player);
	if(%radius < 0)
		%radius = 0;
	%radius -= 2;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldClose,0);
 	%player.cloaked = 0;
	Player::trigger(%player,$BackpackSlot,false);
 	Cloaker(%player);
	GameBase::startFadeIn(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
}

//======================================================================== Stealth Shield

ItemImageData StealthShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 6;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData StealthShieldPack
{
	description = "StealthShield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = StealthShieldPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StealthShieldPackImage::onActivate(%player,%imageSlot)
{
	if (%player == "-1" || !%player)return;
	%clientId = Player::getClient(%player);
	%armor = Player::getArmor(%clientId);
	
	Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
	%player.shieldStrength = 0.012;
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);

}

function StealthShieldPackImage::onDeactivate(%player,%imageSlot)
{
	if (%player == "-1" || !%player)return;
	Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
	%player.stealthshieldon = false;
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
}

//======================================================================== Regeneration Pack

ItemImageData RegenerationPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
};

ItemData RegenerationPack
{
	description = "Regeneration Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RegenerationPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RegenerationPack::OnMount(%player,%item)
{	
	Player::trigger(%player,$BackpackSlot,true);
}
 
function Regeneration::onUnmount(%player,%item)
{	
}

function RegenerationPackImage::onActivate(%player,%imageSlot) 
{
	%player.regen = true;
	schedule("checkRegeneration(" @ %player @ ");",0.1,%player); 
}

function RegenerationPackImage::onDeactivate(%player,%item)
{	
	%player.regen = false;
}

function checkRegeneration(%player)
{	
	if (%player.regen == false)
		return;
	if (Player::isDead(%player))
		return;
	if(Player::getMountedItem(%player,$BackpackSlot) != "RegenerationPack")
		return;
	
	%dlev = GameBase::getDamageLevel(%player);
	%armor = Player::getArmor(%player); 
	if (%armor == "aarmor" || %armor == "afemale")
		GameBase::setDamageLevel(%player, %dlev-0.037);
	else
		GameBase::setDamageLevel(%player, %dlev+0.275);
	schedule("checkRegeneration(" @ %player @ ");",1,%player); 
}

function RegenerationPack::onUse(%player,%item) 
{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
}

//================================================== Teleport Pack
ItemImageData LightningPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LightningPack
{
	description = "Teleport Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LightningPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LightningPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		%client = GameBase::getOwnerClient(%player);
		%disk = %client.teledisk;
		%beacon = %client.telebeacon;
		%ppos = gamebase::getposition(%player);
		%distance = Vector::getDistance(%ppos, %client.telepoint);
		if (%client.telepoint && %distance > 351 && !%disk.check)
			bottomprint(%client, "<jc><f2>Too far from TeleBeacon. Can not Teleport. 350m Range.", 3);	
		else if(%client.telepoint && GameBase::isAtRest(%beacon) && !%disk.check)
		{
			%spawnMarker = %client.telepoint;
			%xPos = getWord(%spawnMarker, 0);
			%yPos = getword(%spawnMarker, 1);
			%zPos = getWord(%spawnMarker, 2);
			%o = %xPos @ "  " @ %yPos @ "  " @ %zPos;
			%Set = newObject("LightningSet",SimSet); 
			containerBoxFillSet(%Set,$SimPlayerObjectType,%spawnMarker, 2,2,1,1);
			%num = Group::objectCount(%Set);	
			for(%i = 0; %i < %num; %i++)
			{
				%obj = Group::getObject(%Set, %i);
				if(GameBase::getTeam(%obj) != GameBase::getTeam(%player) && getObjectType(%obj) == "Player")
				{
					playSound(soundShieldHit,%spawnMarker);
					%cl = GameBase::getOwnerClient(%obj);
					%name = Client::getName(%cl);
					Player::setAnimation(%obj,34);
					Player::kill(%obj);
					MessageAll(0, %name @ " was caught in a Teleport malfunction.");
				}
			}
			if(%set)deleteobject(%set);

		   topprint(%client, "<jc><f2>Telepoint Location Susccessful. " @ %client.telepoint @ ".", 2);
			if (Player::getMountedItem(%client,$FlagSlot)== "flag")
			{
				%rnd = floor(getRandom() * 100);
				if (%rnd > 50)
				{
					%flag = (Player::getMountedItem(%client, $FlagSlot));
					Player::dropItem(%client, %flag);
					bottomprint(%client, "<jc><f2>Teleport malfunction, the flag was dropped...", 2);	
				}
			}
			GameBase::SetPosition(%player, %o);
			//%client.telepoint = "False";
			//deleteobject(%client.telebeacon);
			//%client.telebeacon = "False";
			%client.teledisk = "False";
		}
		else if (!%client.telepoint && !%client.telebeacon && !%disk.check)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%pos = gamebase::getposition(%player);
			%vel = Item::getVelocity(%player);
			playSound(SoundBeaconUse,%pos);
			%obj = (Projectile::spawnProjectile("TeleShell",%trans,%player,%vel));
			%client.teledisk = %obj;
			%obj.check = 1;
			checkForTele(%obj, %client, %pos);
		}
		else
			bottomprint(%client, "<jc><f2>TeleDisk is active.  Must wait for TeleDisk to regenerate.", 3);	
	}
}	

function checkForTele(%this, %client, %pos)
{	
	if(%this.check)
	{	
		%pos = gamebase::getposition(%this);
		schedule("checkForTele(\"" @ %this @ "\", \"" @ %client @ "\", \"" @ %pos @ "\");", 0.4, %client);
	}
	else
	{	
		%player = Client::getOwnedObject(%client);
		if(%player)
		{
			%armor = Player::getArmor(%client);
			%pPos = GameBase::getPosition(%client);
			%dist = Vector::getDistance(%ppos, %pos);
			if (%armor == "aarmor" || %armor == "afemale")
			{
				%obj = newObject("","Mine","Telebeacon");
			 	addToSet("MissionCleanup", %obj);	
			 	%obj.deployer = %client;
			 	%client.telebeacon = %obj;
				GameBase::throw(%obj,%client,0,false);//5 * %client.throwStrength
				if(%dist > 7) GameBase::setPosition(%obj,%pos);
				%client.throwTime = getSimTime() + 0.5;
				GameBase::setTeam(%obj,GameBase::getTeam(%client));
			}
		}
	}
}

//============================================================ Flight Pack

ItemImageData FlightPackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = -2;
 	maxEnergy = -6;
	firstPerson = false;
};

ItemData FlightPack
{
	description = "Flight Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FlightPackImage;
	price = 350;
	hudIcon = "FlightPack";
	showWeaponBar = true;
	hiliteOnActive = true;
	//validateShape = true;
//	validateMaterials = true;
};

function FlightPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FlightPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FlightPack::onUnmount(%player,%item)
{
//	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
//		Player::unmountItem(%player,$WeaponSlot);
}


//======================================================================== Auto Rocket Launcher

ItemData AutoRocketAmmo
{
	description = "Auto Rockets";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 30;
};

ItemImageData SMRPackImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.3 };
	mountRotation = { 0, 180, 0 };
	weaponType = 2;
	ammoType = AutoRocketAmmo;
	//projectileType = Undefined;
	accuFire = true;
	reloadTime = 0.9;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxReload = SoundMortarReload;
};

ItemData SMRPack
{
	description = "Rocket Launcher Pack";
	shapeFile = "mortargun";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SMRPackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SMRPackImage::onActivate(%player,%slot)
{
	Player::trigger(%player,%slot,false);
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SMRPack]);
	 if(%AmmoCount) 
	 {
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player,$WeaponAmmo[SMRPack],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		 if(GameBase::getLOSInfo(%player,950)) 
		 {
			%object = getObjectType($los::object);
			%targetId = GameBase::getOwnerClient($los::object);
			%tarmor = Player::getArmor($los::object);

			if(%object == "Player" && (%tarmor != "spyarmor" && %tarmor != "spyfemale"))
			{			 
				%name = Client::getName(%targetId);
				Tracker(%client,%targetId);
				Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
				Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
			 }
			else if(%object == "Flier")
			{			 
				%pilot = ($los::object).clLastMount;
				%name = GameBase::getDataName($los::object);
				if(%pilot.driver) Tracker(%client,%pilot);
				Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
				Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
				schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
			}
			 else
			 {
				 Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			 }
	 	}
		else
		{
			Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
		}
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Auto Rocket Launcher");
	Player::trigger(%player,%slot,false);
}

function SMRPackImage::onDeactivate(%player,%slot)
{
	Player::trigger(%player,%slot,false);

}

//==================================== Auto Rocket Launcher For Juggernaught

ItemImageData SMRPack2Image
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.2, -0.8, 0.4 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 2;
	ammoType = AutoRocketAmmo;
	//projectileType = "Undefined";
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxReload = SoundMortarReload;
};

ItemData SMRPack2
{
	description = "Rocket Launcher Pack";
	shapeFile = "mortargun";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SMRPack2Image;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SMRPack2Image::onDeactivate(%player,%slot)
{
	//Player::trigger(%player,%slot,false);
}

function SMRPack2Image::onActivate(%player, %slot) 
{
	SMRPackImage::onActivate(%player,%slot);
}

//=============================================AA Turret Pack 

ItemImageData BarragePackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData BarragePack
{
	description = "Anti-Aircraft Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "dDeployables";
	imageType = BarragePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BarragePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function BarragePack::onDeploy(%player,%item,%pos)
{
	if (BarragePack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BarragePack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Anti-AirCraft Turret",True,True,True,15,True,True,4,True,1000, True, "BarrageTurret", "BarragePack");
}


//========================================================= Blast Floor Pack

ItemImageData BlastFloorPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    	mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BlastFloorPack
{
	description = "Blast Floor";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "eDefensive";
	imageType = BlastFloorPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastFloorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function BlastFloorPack::onDeploy(%player,%item,%pos)
{
	if (BlastFloorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BlastFloorPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Blast Floor","Player",False,False,False,False,False,7,True,0, False, "BlastFloor", "BlastFloorPack");
}

//=========================================================== Command LapTop
ItemImageData LaptopImage
{
	shapeFile = "AmmoPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	sfxFire = SoundJammerOn;
	minEnergy = 1;
 	maxEnergy = 10;
	firstPerson = false;
};

ItemData Laptop
{
	description = "Command Laptop";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 650;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaptopImage::onActivate(%player, %imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"LapTop On");

	%client = Player::getClient(%player);
	%client.Laptop = "True";

	LapTopImage::check(%player);
}
function LaptopImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"LapTop Off");
	Player::trigger(%player,$BackpackSlot,false);
	%client = Player::getClient(%player);
	
	%client.hacking = "false";
	%client.Laptop = "False";
}

function LapTopImage::check(%player)
{
	%client = Player::getClient(%player);
	if (%client.Laptop == "True")
	{
		%Set = newObject("laptopset",SimSet); 
		%Pos = GameBase::getPosition(%player); 
		%Mask = $SimPlayerObjectType|$StaticObjectType;
		dbecho("Splat - Laptop");
		containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 200,0);
		%num = Group::objectCount(%Set);
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);
			%data = GameBase::getDataName(%obj);
			%ppos = gamebase::getposition(%player);
			%opos = gamebase::getposition(%obj);
			%distance = Vector::getDistance(%ppos, %opos);
			
			if ( %data == "DeployableSensorJammer" && gamebase::getteam(%obj) != gamebase::getteam(%player) )
			{
				bottomprint(%client, "<jc><f2>Enemy Sensor Jammer Detected " @ %distance @ " meters.", 3);
			}
		}
		deleteobject(%set);		
		schedule ("LapTopImage::check(" @ %player @ ");",3);
	}
	else
		return;
}


//============================================================= Suicide Pack
ItemImageData SuicidePackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;

};

ItemData SuicidePack
{
	description = "Suicide DetPack";
	shapeFile = "magcargo";
	className = "Backpack";
   	heading = "cBackpacks";
	imageType = SuicidePackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	//validateShape = true;
//	validateMaterials = true;
};

function SuicidePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

//function SuicidePack::onUnmount(%player,%item)
//{
//	deleteobject(%item);
//}

function SuicidePack::onDeploy(%player,%item,%pos)
{
	SuicidePack::deployShape(%player,%item);
}

function SuicidePack::deployShape(%player,%item)
{
	Player::unmountItem(%player,$BackpackSlot);
	Player::decItemCount(%player,%item);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "SuicidePack"] < $TeamItemMax["SuicidePack"])
	{
		%obj = newObject("","Mine","Suicidebomb2");
		addToSet("MissionCleanup", %obj);
		%client = Player::getClient(%player);
		%obj.deployer = %client;
		GameBase::throw(%obj,%player,5 * %client.throwStrength,false);
		%team = GameBase::getTeam(%player);
		Client::sendMessage(%client,1,"Det Pack will destruct in 20 seconds");
		if(!$builder) $TeamItemCount[%team @ "SuicidePack"]++;
		if($Server::TourneyMode == true)
			messageteam(1, getTeamName(%team) @ " used DetPack #" @ $TeamItemCount[%team @ "SuicidePack"], -1);
		messageteam(1, Client::getName(%client) @ " used DetPack #" @ $TeamItemCount[%team @ "SuicidePack"], %team);
	}
	else
		Client::sendMessage(%client,1,"Item limit reached for Detpacks");
}

//============================================================== Containment
ItemImageData FgcPackImage
{
	shapeFile = "generator_p";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mass = 3.0;
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData FgcPack
{
	description = "Containment Pack";
	shapeFile = "generator_p";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FgcPackImage;
	price = 1150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
	//validateShape = true;
//	validateMaterials = true;
};

function FgcPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FgcPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FgcPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Mfgl)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

//============================================================ Motion Sensor

ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	//validateShape = true;
//	validateMaterials = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

function MotionSensorPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Sensor","Motion Sensor",False,False,False,False,False,True,5,True,0, False, "DeployableMotionSensor", %item);
}

//================================================================ Ammo Pack

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
  	heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
	//validateShape = true;
//	validateMaterials = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) 
	{
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 15 ; %i = %i +1) 
		{
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);


			if(%pCount > %maxnum)
			{
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			
			if(%i == 0) 		{%item.BulletAmmo = %numPack;}
			else if(%i == 1) 	{%item.PlasmaAmmo = %numPack;}
			else if(%i == 2) 	{%item.DiscAmmo = %numPack;}
			else if(%i == 3) 	{%item.GrenadeAmmo = %numPack;}
			else if(%i == 4) 	{%item.Grenade = %numPack;}
			else if(%i == 5) 	{%item.MortarAmmo = %numPack;}
			else if(%i == 6) 	{%item.RocketAmmo = %numPack;}
			else if(%i == 7) 	{%item.SniperAmmo = %numPack;}
			else if(%i == 8) 	{%item.RailAmmo = %numPack;}
			else if(%i == 9) 	{%item.SilencerAmmo = %numPack;}
			else if(%i == 10)	{%item.VulcanAmmo = %numPack;}
			else if(%i == 11)	{%item.Beacon = %numPack;}
			else if(%i == 12)	{%item.TranqAmmo = %numPack;}
			else if(%i == 13)	{%item.Plastique = %numPack;}
			else if(%i == 14)	{%item.SilencerAmmo = %numPack;}
			//else if(%i == 14)	{%item.SniperAmmo = %numPack;}
			else 			{%item.MineAmmo = %numPack;}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 15 ; %i = %i +1) 
	{
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) 	  {%numAdd = %item.BulletAmmo;}
		else if(%i == 1)  {%numAdd = %item.PlasmaAmmo;}
		else if(%i == 2)  {%numAdd = %item.DiscAmmo;}
		else if(%i == 3)  {%numAdd = %item.GrenadeAmmo;}
		else if(%i == 4)  {%numAdd = %item.Grenade;}
		else if(%i == 5)  {%numAdd = %item.MortarAmmo;}
		else if(%i == 6)  {%numAdd = %item.RocketAmmo;}
		else if(%i == 7)  {%numAdd = %item.SniperAmmo;}
		else if(%i == 8)  {%numAdd = %item.RailAmmo;}
		else if(%i == 9)  {%numAdd = %item.SilencerAmmo;}
		else if(%i == 10) {%numAdd = %item.VulcanAmmo;}
		else if(%i == 11) {%numAdd = %item.Beacon;}
		else if(%i == 12) {%numAdd = %item.TranqAmmo;}
		else if(%i == 13) {%numAdd = %item.Plastique;}
		else if(%i == 14) {%numAdd = %item.SniperAmmo;}
		else {%numAdd = %item.MineAmmo;}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%player);	

	for(%i = 0; %i < 14 ; %i = %i +1)
	{
		%item = $AmmoPackItems[%i];	
		if ($ItemMax[%armor, %item] > 0)
		{
			%maxnum = $AmmoPackMax[%item];
			%maxnum = checkResources(%player,%item,%maxnum); 
		}		
		else 
			%maxnum = 0;

		if(%maxnum)
		{
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

//======================================================================== Pulse Sensor

ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	//validateShape = true;
//	validateMaterials = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (PulseSensorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
function PulseSensorPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Sensor","Pulse Sensor",False,False,False,False,False,True,5,True,0,False,"DeployablePulseSensor", %item);
}

//======================================================================== Sensor Jammer

ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   	heading = "dDeployables";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	//validateShape = true;
//	validateMaterials = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (DeployableSensorJammerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
function DeployableSensorJammerPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Sensor","Sensor Jammer",False,False,False,False,False,False,5,True,0, False, "DeployableSensorJammer", %item);
}


//======================================================================== Camera Pack

ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CameraPack
{
	description = "Camera";
	shapeFile = "camera";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	
	//validateShape = true;
//	validateMaterials = true;
};

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Camera",False,False,False,False,False,False,5,True,0, False, "CameraTurret", %item);
}

