//======================================================================== Base Blaster

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.250;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt1;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
  	heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
  	shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
//	//validateShape = true;
//	validateMaterials = true;
};

//======================================================================== Chain Gun

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.001;
	spinUpTime = 0.2;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet1;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Equalizer";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
  	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
	
//	//validateShape = true;
//	validateMaterials = true;
};

//======================================================================== Plasma Gun

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = "PlasmaAmmo";
	//projectileType = "Undefined";
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
//	//validateShape = true;
//	validateMaterials = true;
};


function PlasmaGunImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);

	 %playerId = Player::getClient(%player);
	 if(%Ammo) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     	 %vel = Item::getVelocity(%player);

		if (!%playerId.Plasma || %playerId.Plasma == 0)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			Projectile::spawnProjectile("PlasmaBolt2",%trans,%player,%vel);
		}
		else if (%playerId.Plasma == 1)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			Projectile::spawnProjectile("PlasmaBoltRapid",%trans,%player,%vel);
			Projectile::spawnProjectile("PlasmaBoltRapid2",%trans,%player,%vel);
		}
		else if (%playerId.Plasma == 2)
		{
			%pRot = GameBase::getRotation(%player);
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			%vel = EmplacementPack::rotVector( "15 0 -15", %pRot);
			Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
			
			%vel = EmplacementPack::rotVector( "-15 0 -15", %pRot);
			Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
			
			%vel = EmplacementPack::rotVector( "0 2 15", %pRot);
			Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "0 1 0", %pRot);
			Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
		}
		else if (%playerId.Plasma == 3)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			%fired = (Projectile::spawnProjectile("PlasmaBolt2",%trans,%player,%vel));
			schedule ("DeployFrags(" @ %fired @ ", 3," @  %playerId @ ");",0.5,%fired);
			schedule ("DeployFrags(" @ %fired @ ", 5," @  %playerId @ ");",1.0,%fired);
			schedule ("DeployFrags(" @ %fired @ ", 8," @  %playerId @ ");",1.5,%fired);
		}
	}	//=== End standard plasma fire.
}
ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
	
//	//validateShape = true;
//	validateMaterials = true;
};	

//======================================================================== Grenade Launcher
ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0;
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
  	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
//	//validateShape = true;
//	validateMaterials = true;
};


//======================================================================== Mortar
ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
  	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	//projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function MortarImage::onFire(%player, %slot) 
{
   %client = GameBase::getOwnerClient(%player);
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	%playerId = Player::getClient(%player);

	if (%client.lastmdm && %Ammo == 1)
	{
		MDMDetonate2(%client);
		return;
	}
	else if(%client.lastmdm && %ammo > 1)
	{
		%client.firemortar = %client.lastmdm;
		%client.lastmdm = "False";
	}
	else if(%Ammo || %client.firemortar) 
	{
		%fired.deployer = %player;
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		if (!%playerId.Mortar || %playerId.Mortar == 0)
		{
			%fired = Projectile::spawnProjectile("MortarShell1",%trans,%player,%vel);
       	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
		}
		else if (%playerId.Mortar == 1)
		{
			%fired = Projectile::spawnProjectile("EMPMortar",%trans,%player,%vel);
       	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
		}
		else if (%playerId.Mortar == 2)
		{
			%fired = Projectile::spawnProjectile("BomberShell",%trans,%player,%vel);
			%fired.deployer = %client;
       	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
		}
		else if (%playerId.Mortar == 3)
		{
			if (%client.firemortar)
				MDMDetonate(%client);
			else if(%Ammo > 1)
			{
				%client.firemortar = (Projectile::spawnProjectile("DelayMortarShell",%trans,%player,%vel));
				schedule("MDMDetonate(" @ %client @");",10,%client.firemortar);
				Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
			else if(%Ammo == 1)
			{
				%client.lastmdm = (Projectile::spawnProjectile("DelayMortarShell",%trans,%player,%vel));
				schedule("MDMDetonate2(" @ %client @");",10,%client.lastmdm);
			}
		}		
	}
}

function MDMDetonate(%client)
{
 %obj = newObject("","Mine","MDMBlast");
 GameBase::throw(%obj,%client,0,false);		
 addToSet("MissionCleanup", %obj);
 %padd = "0 0 0.5";
 %pos = Vector::add(GameBase::getPosition(%client.firemortar), %padd);
 GameBase::setPosition(%obj, %pos);
 if(%client.firemortar)deleteobject(%client.firemortar);
 %client.firemortar = "False";
}

function MDMDetonate2(%client)
{
 %obj = newObject("","Mine","MDMBlast");
 GameBase::throw(%obj,%client,0,false);		
 addToSet("MissionCleanup", %obj);
 %padd = "0 0 0.5";
 %pos = Vector::add(GameBase::getPosition(%client.lastmdm), %padd);
 GameBase::setPosition(%obj, %pos);
 if(%client.lastmdm)deleteobject(%client.lastmdm);
 %client.lastmdm = "False";
 Player::decItemCount(%client,$WeaponAmmo[Mortar],1);
}

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
	
//	//validateShape = true;
//	validateMaterials = true;
};

//======================================================================== Disc Launcher
ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	//projectileType = DiscShell1;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	//sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
//	//validateShape = true;
//	validateMaterials = true;
};

function DiscLauncherImage::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	if(Player::getItemCount(%player, $WeaponAmmo[DiscLauncher])) 
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if (!%client.disc || %client.disc == 0)
		{
			Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
			playSound(SoundFireDisc,GameBase::getPosition(%player));
			Projectile::spawnProjectile("DiscShell1",%trans,%player,%vel);
		}
		else if (%client.disc == 1)
		{
			Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
			playSound(SoundFireDisc,GameBase::getPosition(%player));
			Projectile::spawnProjectile("DiscShell2",%trans,%player,%vel);
		}			
	}
}

//======================================================================== Laser Rifle
ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = SniperLaser1;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
	
	//validateShape = true;
//	validateMaterials = true;
};

//======================================================================== ELF GUN
ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = lightningCharge1;
	minEnergy = 3;
	maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
	description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = EnergyRifleImage;
	showWeaponBar = true;
	price = 500;
//	//validateShape = true;
//	validateMaterials = true;
};

//======================================================================== Repair Gun
ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;
	projectileType = RepairBolt1;
	minEnergy  = 3;
	maxEnergy = 10;

	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	price = 125;
	showInventory = true;
	//validateShape = true;
//	validateMaterials = true;
};

function RepairGun::onMount(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if (%armor != "earmor" && %armor != "efemale")
		Player::trigger(%player,$BackpackSlot,true);

}

function RepairGun::onUnmount(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);

	if (%armor != "earmor" && %armor != "efemale")	
		Player::trigger(%player,$BackpackSlot,false);

}


//======================================================================== HyperBlaster


ItemImageData HyperBImage
{
   	shapeFile  = "plasma";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = HyperBolt;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperB
{
	heading = "bWeapons";
	description = "Hyper Blaster";
	className = "Weapon";
	shapeFile  = "plasma";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HyperBImage;
	price = 285;
	showWeaponBar = true;
};

//======================================================================== Rocket Launcher
ItemData RocketAmmo 
{
	description = "RocketAmmo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = RocketAmmo;
	//projectileType = "Undefined";
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	//sfxFire = SoundMissileTurretFire;
	sfxReload = SoundMortarReload;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
};
	
function RocketImage::onFire(%player, %slot) 
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	%armor = Player::getArmor(%player);
	%client = GameBase::getOwnerClient(%player);

	if(%Ammo) 
	{
		%pos = GameBase::getPosition(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
	
		if (!%client.rocket || %client.rocket == 0)	//== Standard Stinger Rocket
		{
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			playSound(SoundMissileTurretFire,%pos);
			Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel);
		}
		else if(%client.rocket == 1)			//== Stinger w/ locking.
		{	
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			if(GameBase::getLOSInfo(%player,500)) 
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
					playSound(SoundMissileTurretFire,%pos);
				}
				else if(%object == "Flier")
				{			 
					%pilot = ($los::object).clLastMount;
					%name = GameBase::getDataName($los::object);
					if(%pilot.driver) Tracker(%client,%pilot);
					Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
					Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
					playSound(SoundMissileTurretFire,%pos);
				}
				else
				{
					Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
					playSound(SoundMissileTurretFire,%pos);
				}
			}
			else
			{
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				playSound(SoundMissileTurretFire,%pos);
			}		
		}
		else if (%client.rocket == 2)			//== Heat-Seeker Rocket
		{	
			if (!%client.target || %client.target == "-1" || %client.target == %player)
			{	
				%fired = (Projectile::spawnProjectile("LockJaw",%trans,%player,%vel));
				%client.lj = %fired;
				schedule ("deleteobject(" @ %fired @ "); %client.lj = false;",0.05,%client.lj);
				Player::trigger(%player,$WeaponSlot,false);
			}
			else if (%client.target != "-1")
			{	$targeting = %player;
				%targetId = GameBase::getOwnerClient(%client.target);
				%name = Client::getName(%targetId);
				LockJawFire(%player, %client.target);
			}
		}
		else if (%client.rocket == 3)
		{
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			playSound(SoundMissileTurretFire,%pos);
			%obj1 = (Projectile::spawnProjectile("GodHammerMortar",%trans,%player,%vel));
			%obj1.deployer = %client;
		}
	}
	else
		Client::sendMessage(%client, 0,"You have no Ammo for the Rocket Launcher");
}

ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 375;
	showWeaponBar = true;
};

function Tracker(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		 %name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " has a Missile Lock!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 

//======================================================================== Projectile - Sniper Rifle
ItemData SniperAmmo
{
	description = "Sniper Bullet";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = SniperAmmo;
	projectileType = SniperRound1;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0.08; //blagh not 0.001

	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData SniperRifle
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 375;
	showWeaponBar = true;
};


//======================================================================== Boom Stick
ItemData BoomAmmo
{
	description = "Boom Shell";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData BoomStickImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	ammoType = BoomAmmo;
	//projectileType = "Undefined";
	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 1.1;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireMortar;
	sfxReload   = SoundMortarReload;
};

ItemData BoomStick
{
	description = "Boom Stick";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = BoomStickImage;
	showWeaponBar = true;
	price = 500;
};


function BoomStickImage::onFire(%player, %slot) 
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[BoomStick]);
	 if(%AmmoCount) 
	 {
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player,$WeaponAmmo[BoomStick],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		for (%i=0; %i < 19; %i++)
		{
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
		}
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

//======================================================================== Poison Dart Gun
ItemData TranqAmmo
{
	description = "Poison Dart";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData TranqGunImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = TranqAmmo;
	projectileType = TranqDart;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};
ItemData TranqGun
{
	description = "Dart Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TranqGunImage;
	price = 475;
	showWeaponBar = true;
};
//======================================================================== Magnum
ItemData SilencerAmmo
{
	description = "Magnum Bullets";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SilencerImage
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = SilencerAmmo;
	projectileType = SilencerBullet;
	accuFire = true;
	reloadTime = 0.39;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Silencer
{
	description = "Magnum";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "targetlaser";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SilencerImage;
	price = 375;
	showWeaponBar = true;
};

//======================================================================== ConCusion Gun - Shockwave Cannon
ItemImageData ConCunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; 
    	minEnergy = 40;
	maxEnergy = 45;
	projectileType = Shock;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	
};
ItemData ConCun
{
	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ConCunImage;
	price = 250;
	showWeaponBar = true;
};


//======================================================================== Rail Gun

ItemData RailAmmo
{
	description = "Railgun Bolt";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RailgunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RailAmmo;
	projectileType = RailRound;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Railgun
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

//======================================================================== Vulcan - AutoCanaon

ItemData VulcanAmmo
{
	description = "Vulcan Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData VulcanImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0.1;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.01;
	ammoType = VulcanAmmo;
	projectileType = VulcanBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan
{
	description = "Vulcan";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 125;
	showWeaponBar = true;
};

//======================================================================== Nuke Launcher and Pack

ItemData MfglAmmo
{
	description = "Nuclear Warhead";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 500;
	mass = 0.25;
};

ItemImageData MfglImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = MfglAmmo;
	//projectileType = Undefined;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 4.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mfgl
{
	description = "Tactical Nuke";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MfglImage;
	price = 3500;
	showWeaponBar = true;
	mass = 0.5;
};

// Bugfix concept by |LGS|Gonzo 5-1-2002
function MfglImage::onFire(%player, %slot) 
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Mfgl]);
	%armor = Player::getArmor(%player);
	//Player::getMountedItem(%player,$BackpackSlot) == FgcPack || %armor == "jarmor" ) && 
	if($TeamItemCount[GameBase::getTeam(%player) @ "MFGLAmmo"] < $TeamItemMax["MFGLAmmo"])
	{
		if(%AmmoCount)
		{
			if(%player.norefire == true)
			{
				client::sendmessage(0, "Nuke reloading.");
				return;
			}
			%player.norefire = true;
			schedule(%player @ ".norefire = false;",4);			

			%team = GameBase::getTeam(%player);
			ixApplyKickback(%player, 500, 70);
	 
			%client = GameBase::getOwnerClient(%player);
			if(!$builder)
			{
				$TeamItemCount[GameBase::getTeam(%player) @ "MFGLAmmo"]++;
				if($Server::TourneyMode == true)
					messageteam(1, getTeamName(%team) @ " used Nuke #" @ $TeamItemCount[%team @ "MFGLAmmo"], -1);
				messageteam(1, Client::getName(%client) @ " used Nuke #" @ $TeamItemCount[%team @ "MFGLAmmo"], %team);
			}
			Player::decItemCount(%player,$WeaponAmmo[Mfgl],1);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			%fired = (Projectile::spawnProjectile("FgcShell",%trans,%player,%vel));%fired.deployer = %player;
			%fired.deployer = %client;
		}
		else
		{
			Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");
		}
	}
	else
	{
		Client::sendMessage(Player::getClient(%player),1,"Item limit reached for Tactical Nuke Shells");
		Player::decItemCount(%player,$WeaponAmmo[Mfgl],1);
		//%team = GameBase::getTeam(%player);
		//$TeamItemCount[GameBase::getTeam(%player) @ "MFGLAmmo"]++;
		//if($Server::TourneyMode == true) messageteam(1, getTeamName(%team) @ " used Nuke #" @ $TeamItemCount[%team @ "MFGLAmmo"], -1);
		//Client::sendMessage(Player::getClient(%player), 1,"Firing A Tactical Nuke With Out A Containment Pack Can Be Dangerous.");
		//GameBase::applyRadiusDamage($NukeDamageType, getBoxCenter(%player), 3, 15, 500, %player);
		//return;
	}
}
function Mfgl::onUse(%player,%item)
{
	%armor = Player::getArmor(%player);
	
	if((Player::getMountedItem(%player,$BackpackSlot) == FgcPack) || (%armor == "jarmor"))
	{
		Weapon::onUse(%player,%item);
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Tactical Nuke!", 2);
	}
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have the Containment Pack to use the Tactical Nuke."); 
}

//======================================================================== Flamer
ItemImageData FlamerImage
{
  	shapeFile  = "GrenadeL";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.15;
	fireTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 3;
	minEnergy = 1;
	maxEnergy = 3;
	projectileType = FlamerBolt;
	accuFire = true;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Flamer
{
    	heading = "bWeapons";
	description = "Flame Thrower";
	className = "Weapon";
    	shapeFile  = "GrenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 385;
	showWeaponBar = true;
};

//======================================================================== Ion Canon

ItemImageData IonGunImage
{
	shapeFile = "grenadeL";//grenadeL";
	mountPoint = 0;
	mountRotation = { 0, 0.785, 0 };
	weaponType = 0; // Single Shot
	minEnergy = 2.5;
	maxEnergy = 7;
	projectileType = IonGunBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};


ItemData IonGun
{
    	heading = "bWeapons";
	description = "Ion Rifle";
	className = "Weapon";
    	shapeFile  = "grenadeL";
	hudIcon = "targetlaser";
	shadowDetailMask = 4;
	imageType = IonGunImage;
	price = 250;
	showWeaponBar = true;
};

//======================================================================== Volter
ItemImageData VolterImage
{
	shapeFile  = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 0.785, 0 };
	weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 0;
	minEnergy = 2.5;
	maxEnergy = 3;
	projectileType = Flameburst;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxFire = SoundFlyerActive;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Volter
{
	heading = "bWeapons";
	description = "Volter";
	className = "Weapon";
	shapeFile  = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = VolterImage;
	price = 385;
	showWeaponBar = true;
};

//======================================================================== Targetting Laser

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
//	//validateShape = true;
//	validateMaterials = true;
};

//======================================================================== Engineer Repair Gun


ItemImageData FixitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = "RepairBolt1";
	minEnergy = 5;
	maxEnergy = 12;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit
{
	description   = "Engineer Repair-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    	heading = "tEngineer Items";
	shadowDetailMask = 4;
	imageType     = FixitImage;
	price         = 350;
	showWeaponBar = true;
};


//======================================================================== Grav Gun
ItemImageData GravGunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = gravCharge;
	minEnergy = 3;
	maxEnergy = 20;
	reloadTime = 0.2;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.15, 0.85, 0.15 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData GravGun
{
	description = "Grav Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GravGunImage;
	showWeaponBar = true;
	price = 900;
};