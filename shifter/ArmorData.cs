

function BuildItemList()
{
	$armorId[0] = "aarmor";		// -- Arbitor
	$armorId[1] = "afemale";
	$armorId[2] = "barmor";		// -- Goliath
	$armorId[3] = "bfemale"; 
	$armorId[4] = "darmor";		// -- Dreadnaught
	$armorId[5] = "dmarmor";	// -- Death Match
	$armorId[6] = "dmfemale";
	$armorId[7] = "earmor";		// -- Engineer
	$armorId[8] = "efemale";
	$armorId[9] = "harmor";		// -- Heavy
	$armorId[10] = "jarmor";	// -- Juggernaught
	$armorId[11] = "larmor";	// -- Assassin
	$armorId[12] = "lfemale";
	$armorId[13] = "marmor";	// -- Merc.
	$armorId[14] = "mfemale";
	$armorId[15] = "parmor";	// -- PArmor
	$armorId[16] = "sarmor";	// -- Scout
	$armorId[17] = "sfemale";
	$armorId[18] = "spyarmor";	// -- Chemeleon
	$armorId[19] = "spyfemale";
	$armorId[20] = "stimarmor";	// -- Stim-Scout
	$armorId[21] = "stimfemale";
	$armorId[22] = "";

	%max = getNumItems();
	
	for (%i = 0; %i < %max; %i++)
	{
		%itemname = getItemData(%i);
		for (%k=0; $armorId[%k] != ""; %k++)
		{
			%armor = $armorId[%k];
			$ItemMax[%armor, %itemname] = 0;
		}
		
		$ItemMax[%armor, "flag"] = 1;
	}

	$MaxWeapons[aarmor] = 4;
	$MaxWeapons[afemale] = 4;
	$MaxWeapons[barmor] = 4;
	$MaxWeapons[bfemale] = 4;
	$MaxWeapons[darmor] = 4;
	$MaxWeapons[earmor] = 4;
	$MaxWeapons[efemale] = 4;
	$MaxWeapons[harmor] = 5;
	$MaxWeapons[jarmor] = 3;
	$MaxWeapons[larmor] = 3;
	$MaxWeapons[lfemale] = 3;
	$MaxWeapons[marmor] = 5;
	$MaxWeapons[mfemale] = 5;
	$MaxWeapons[parmor] = 1;
	$MaxWeapons[sarmor] = 2;
	$MaxWeapons[sfemale] = 2;
	$MaxWeapons[spyarmor] = 3;
	$MaxWeapons[spyfemale] = 3;
	$MaxWeapons[stimarmor] = 2;
	$MaxWeapons[stimfemale] = 2;

	//====================================================== Arbitor
	$ItemMax[aarmor, 	ArbitorBeaconPack] = 1;			$ItemMax[afemale,	EMPBeaconPack] = 1;
	$ItemMax[aarmor, 	EMPBeaconPack] = 1;			$ItemMax[afemale,	ShieldBeaconPack] = 1;
	$ItemMax[aarmor, 	ShieldBeaconPack] = 1;			$ItemMax[afemale,	AmmoPack] = 1;
	$ItemMax[aarmor,	AmmoPack] = 1;				$ItemMax[afemale,	ArbitorBeaconPack] = 1;
	$ItemMax[aarmor,	Beacon] = 3;				$ItemMax[afemale,	Beacon] = 3;
	$ItemMax[aarmor,	Blaster] = 1;				$ItemMax[afemale,	Blaster] = 1;
	$ItemMax[aarmor,	BulletAmmo] = 150;			$ItemMax[afemale,	BulletAmmo] = 150;
	$ItemMax[aarmor,	CameraPack] = 1;			$ItemMax[afemale,	CameraPack] = 1;
	$ItemMax[aarmor,	CloakingDevice] = 1;			$ItemMax[afemale,	CloakingDevice] = 1;
	$ItemMax[aarmor,	ConCun] = 1;				$ItemMax[afemale,	ConCun] = 1;
	$ItemMax[aarmor,	DeployableAmmoPack] = 1;		$ItemMax[afemale,	DeployableAmmoPack] = 1;
	$ItemMax[aarmor,	DeployableElf] = 1;			$ItemMax[afemale,	DeployableElf] = 1;
	$ItemMax[aarmor,	DeployableInvPack] = 1;			$ItemMax[afemale,	DeployableInvPack] = 1;
	$ItemMax[aarmor,	DiscAmmo] = 15;				$ItemMax[afemale,	DiscAmmo] = 15;
	$ItemMax[aarmor,	EnergyPack] = 1;			$ItemMax[afemale,	EnergyPack] = 1;
	$ItemMax[aarmor,	ForceFieldPack] = 1;			$ItemMax[afemale,	ForceFieldPack] = 1;
	$ItemMax[aarmor,	GravGun] = 1;				$ItemMax[afemale,	GravGun] = 1;
	$ItemMax[aarmor,	Grenade] = 5;				$ItemMax[afemale,	Grenade] = 5;
	$ItemMax[aarmor,	GrenadeAmmo] = 10;			$ItemMax[afemale,	GrenadeAmmo] = 10;
	$ItemMax[aarmor,	HoloPack] = 1;				$ItemMax[afemale,	HoloPack] = 1;
	$ItemMax[aarmor,	HyperB] = 1;				$ItemMax[afemale,	HyperB] = 1;
	$ItemMax[aarmor,	IonGun] = 1;				$ItemMax[afemale,	IonGun] = 1;
	$ItemMax[aarmor,	LargeForceFieldPack] = 1;		$ItemMax[afemale,	LargeForceFieldPack] = 1;
	$ItemMax[aarmor,	LightningPack] = 1;			$ItemMax[afemale,	LightningPack] = 1;
	$ItemMax[aarmor,	MineAmmo] = 3;				$ItemMax[afemale,	MineAmmo] = 3;
	$ItemMax[aarmor,	MotionSensorPack] = 1;			$ItemMax[afemale,	MotionSensorPack] = 1;
	$ItemMax[aarmor,	Volter] = 1;				$ItemMax[afemale,	Volter] = 1;
	$ItemMax[aarmor,	PlasmaAmmo] = 40;			$ItemMax[afemale,	PlasmaAmmo] = 40;
	$ItemMax[aarmor,	PulseSensorPack] = 1;			$ItemMax[afemale,	PulseSensorPack] = 1;
	$ItemMax[aarmor,	RailAmmo] = 10;				$ItemMax[afemale,	RailAmmo] = 10;
	$ItemMax[aarmor,	RegenerationPack] = 1;			$ItemMax[afemale,	RegenerationPack] = 1;
	$ItemMax[aarmor,	RepairKit] = 1;				$ItemMax[afemale,	RepairKit] = 1;
	$ItemMax[aarmor,	RepairPack] = 1;			$ItemMax[afemale,	RepairPack] = 1;
	$ItemMax[aarmor,	ShieldPack] = 1;			$ItemMax[afemale,	ShieldPack] = 1;
	$ItemMax[aarmor,	StealthShieldPack] = 1;			$ItemMax[afemale,	StealthShieldPack] = 1;
	$ItemMax[aarmor,	TargetingLaser] = 1;			$ItemMax[afemale,	TargetingLaser] = 1;
	$ItemMax[aarmor,	TranqAmmo] = 20;			$ItemMax[afemale,	TranqAmmo] = 20;
	$ItemMax[aarmor,	TurretPack] = 1;			$ItemMax[afemale,	TurretPack] = 1;
	//====================================================== Goliath
	$ItemMax[barmor,	AirAmmoPad] = 1;			$ItemMax[bfemale,	AirAmmoPad] = 1;
	$ItemMax[barmor,	AmmoPack] = 1;				$ItemMax[bfemale,	AmmoPack] = 1;
	$ItemMax[barmor,	Beacon] = 4;				$ItemMax[bfemale,	Beacon] = 4;
	$ItemMax[barmor,	CameraPack] = 1;		 	$ItemMax[bfemale,	CameraPack] = 1;
	$ItemMax[barmor,	DeployableAmmoPack] = 1;	 	$ItemMax[bfemale,	DeployableAmmoPack] = 1;
	$ItemMax[barmor,	DeployableElf] = 1;		 	$ItemMax[bfemale,	DeployableElf] = 1;
	$ItemMax[barmor,	DeployableInvPack] = 1;		 	$ItemMax[bfemale,	DeployableInvPack] = 1;
	$ItemMax[barmor,	DiscAmmo] = 30;			 	$ItemMax[bfemale,	DiscAmmo] = 30;
	$ItemMax[barmor,	Disclauncher] = 1;		 	$ItemMax[bfemale,	Disclauncher] = 1;
	$ItemMax[barmor,	EnergyPack] = 1;		 	$ItemMax[bfemale,	EnergyPack] = 1;
	$ItemMax[barmor,	Flamer] = 1;			 	$ItemMax[bfemale,	Flamer] = 1;
	$ItemMax[barmor,	ForceFieldPack] = 1;		 	$ItemMax[bfemale,	ForceFieldPack] = 1;
	$ItemMax[barmor,	Grenade] = 6;			 	$ItemMax[bfemale,	Grenade] = 6;
	$ItemMax[barmor,	GrenadeAmmo] = 20;		 	$ItemMax[bfemale,	GrenadeAmmo] = 20;
	$ItemMax[barmor,	GrenadeLauncher] = 1;		 	$ItemMax[bfemale,	GrenadeLauncher] = 1;
	$ItemMax[barmor,	HoloPack] = 1;			 	$ItemMax[bfemale,	HoloPack] = 1;
	$ItemMax[barmor,	MineAmmo] = 6;			 	$ItemMax[bfemale,	MineAmmo] = 6;
	$ItemMax[barmor,	Mortar] = 1;			 	$ItemMax[bfemale,	Mortar] = 1;
	$ItemMax[barmor,	MortarAmmo] = 5;		 	$ItemMax[bfemale,	MortarAmmo] = 5;
	$ItemMax[barmor,	MotionSensorPack] = 1;		 	$ItemMax[bfemale,	MotionSensorPack] = 1;
	$ItemMax[barmor,	PlasmaAmmo] = 50;		 	$ItemMax[bfemale,	PlasmaAmmo] = 50;
	$ItemMax[barmor,	PlasmaGun] = 1;			 	$ItemMax[bfemale,	PlasmaGun] = 1;
	$ItemMax[barmor,	PulseSensorPack] = 1;		 	$ItemMax[bfemale,	PulseSensorPack] = 1;
	$ItemMax[barmor,	RailAmmo] = 10;			 	$ItemMax[bfemale,	RailAmmo] = 10;
	$ItemMax[barmor,	RepairKit] = 1;			 	$ItemMax[bfemale,	RepairKit] = 1;
	$ItemMax[barmor,	RepairPack] = 1;		 	$ItemMax[bfemale,	RepairPack] = 1;
	$ItemMax[barmor,	RocketAmmo] = 12;		 	$ItemMax[bfemale,	RocketAmmo] = 12;
	$ItemMax[barmor,	RocketLauncher] = 1;		 	$ItemMax[bfemale,	RocketLauncher] = 1;
	$ItemMax[barmor,	RocketPack] = 1;		 	$ItemMax[bfemale,	RocketPack] = 1;
	$ItemMax[barmor,	SensorJammerPack] = 1;		 	$ItemMax[bfemale,	SensorJammerPack] = 1;
	$ItemMax[barmor,	ShieldPack] = 1;		 	$ItemMax[bfemale,	ShieldPack] = 1;
	$ItemMax[barmor,	StealthShieldPack] = 1;		 	$ItemMax[bfemale,	StealthShieldPack] = 1;
	$ItemMax[barmor,	SuicidePack] = 1;		 	$ItemMax[bfemale,	SuicidePack] = 1;
	$ItemMax[barmor,	TargetingLaser] = 1;		 	$ItemMax[bfemale,	TargetingLaser] = 1;
	$ItemMax[barmor,	TranqAmmo] = 20; 			$ItemMax[bfemale,	TranqAmmo] = 20;

	//====================================================== Dreadnaught
	$ItemMax[darmor,	AirAmmoPad] = 1;
	$ItemMax[darmor,	AmmoPack] = 1;
	$ItemMax[darmor,	AutoRocketAmmo] = 15;
	$ItemMax[darmor,	AutoRocketAmmo] = 20;
	$ItemMax[darmor,	Beacon] = 3;
	$ItemMax[darmor,	Blaster] = 1;
	$ItemMax[darmor,	BulletAmmo] = 150;
	$ItemMax[darmor,	CameraPack] = 1;
	$ItemMax[darmor,	Chaingun] = 1;
	$ItemMax[darmor,	ConCun] = 1;
	$ItemMax[darmor,	DeployableAmmoPack] = 1;
	$ItemMax[darmor,	DeployableComPack] = 1;
	$ItemMax[darmor,	DeployableInvPack] = 1;
	$ItemMax[darmor,	DiscAmmo] = 15;
	$ItemMax[darmor,	Disclauncher] = 1;
	$ItemMax[darmor,	EnergyPack] = 1;
	$ItemMax[darmor,	EnergyRifle] = 1;
	$ItemMax[darmor,	Equalizer] = 1;
	$ItemMax[darmor,	FgcPack] = 1;
	$ItemMax[darmor,	ForceFieldPack] = 1;
	$ItemMax[darmor,	Grenade] = 3;
	$ItemMax[darmor,	GrenadeAmmo] = 15;
	$ItemMax[darmor,	GrenadeLauncher] = 1;
	$ItemMax[darmor,	HoloPack] = 1;
	$ItemMax[darmor,	Mfgl] = 1;
	$ItemMax[darmor,	MfglAmmo] = 1;
	$ItemMax[darmor,	MineAmmo] = 5;
	$ItemMax[darmor,	Mortar] = 1;
	$ItemMax[darmor,	MortarAmmo] = 10;
	$ItemMax[darmor,	MotionSensorPack] = 1;
	$ItemMax[darmor,	PlasmaAmmo] = 50;
	$ItemMax[darmor,	PlasmaGun] = 1;
	$ItemMax[darmor,	PlasmaTurretPack] = 1;
	$ItemMax[darmor,	PulseSensorPack] = 1;
	$ItemMax[darmor,	RailAmmo] = 10;
	$ItemMax[darmor,	RepairKit] = 1;
	$ItemMax[darmor,	RepairPack] = 1;
	$ItemMax[darmor,	RocketAmmo] = 15;
	$ItemMax[darmor,	RocketLauncher] = 1;
	$ItemMax[darmor,	ShieldPack] = 1;
	$ItemMax[darmor,	SMRPack] = 1;
	$ItemMax[darmor,	StealthShieldPack] = 1;
	$ItemMax[darmor,	TargetingLaser] = 1;
	$ItemMax[darmor,	TranqAmmo] = 20;
	$ItemMax[darmor,	TurretPack] = 1;
	$ItemMax[darmor,	Vulcan] = 1;
	$ItemMax[darmor,	VulcanAmmo] = 400;
	$ItemMax[darmor, 	BarragePack] = 1;
	$ItemMax[darmor, 	ShockFloorPack] = 1;

	//====================================================== Death Match
	$ItemMax[dmarmor,	Equalizer] = 1;
	$ItemMax[dmfemale,	Equalizer] = 1;

	//====================================================== Engineer
	$ItemMax[earmor, 	ArbitorBeaconPack] = 1;		$ItemMax[efemale,	ArbitorBeaconPack] = 1;
	$ItemMax[earmor, 	EMPBeaconPack] = 1;		$ItemMax[efemale,	EMPBeaconPack] = 1;
	$ItemMax[earmor, 	PowerGeneratorPack] = 1;	$ItemMax[efemale,	PowerGeneratorPack] = 1;
	$ItemMax[earmor, 	ShieldBeaconPack] = 1;		$ItemMax[efemale,	ShieldBeaconPack] = 1;
	$ItemMax[earmor,	AccelPPack] = 1;		$ItemMax[efemale,	AccelPPack] = 1;
	$ItemMax[earmor,	AirAmmoPad] = 1;		$ItemMax[efemale,	AirAmmoPad] = 1;
	$ItemMax[earmor,	AirBase] = 1;			$ItemMax[efemale,	AirBase] = 1;
	$ItemMax[earmor,	AmmoPack] = 1;			$ItemMax[efemale,	AmmoPack] = 1;
	$ItemMax[earmor,	AutoRocketAmmo] = 10;		$ItemMax[efemale,	AutoRocketAmmo] = 10;
	$ItemMax[earmor,	Beacon] = 3;			$ItemMax[efemale,	Beacon]= 3;
	$ItemMax[earmor,	Blaster] = 1;			$ItemMax[efemale,	Blaster] = 1;
	$ItemMax[earmor,	BlastFloorPack] = 1;		$ItemMax[efemale,	BlastFloorPack] = 1;
	$ItemMax[earmor,	BlastWallPack] = 1;		$ItemMax[efemale,	BlastWallPack] = 1;
	$ItemMax[earmor,	BulletAmmo] = 150;		$ItemMax[efemale,	BulletAmmo] = 150;
	$ItemMax[earmor,	CameraPack] = 1;		$ItemMax[efemale,	CameraPack] = 1;
	$ItemMax[earmor,	Chaingun] = 1;			$ItemMax[efemale,	Chaingun] = 1;
	$ItemMax[earmor,	DeployableAmmoPack] = 1;	$ItemMax[efemale,	DeployableAmmoPack] = 1;
	$ItemMax[earmor,	DeployableComPack] = 1;		$ItemMax[efemale,	DeployableComPack] = 1;
	$ItemMax[earmor,	DeployableElf] = 1;		$ItemMax[efemale,	DeployableElf] = 1;
	$ItemMax[earmor,	DeployableInvPack] = 1;		$ItemMax[efemale,	DeployableInvPack] = 1;
	$ItemMax[earmor,	DeployableSensorJammerPack] = 1;$ItemMax[efemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[earmor,	DiscAmmo] = 15;			$ItemMax[efemale,	DiscAmmo] = 15;
	$ItemMax[earmor,	Disclauncher] = 1;		$ItemMax[efemale,	Disclauncher] = 1;
	$ItemMax[earmor,	disit] = 1;			$ItemMax[efemale,	disit]=1;
	$ItemMax[earmor,	EmplacementPack] = 1;		$ItemMax[efemale,	EmplacementPack] = 1;
	$ItemMax[earmor,	EnergyPack] = 1;		$ItemMax[efemale,	EnergyPack] = 1;
	$ItemMax[earmor,	EnergyRifle] = 1;		$ItemMax[efemale,	EnergyRifle] = 1;
	$ItemMax[earmor,	Equalizer] = 1;			$ItemMax[efemale,	Equalizer] = 1;
	$ItemMax[earmor,	Fixit] = 1;			$ItemMax[efemale,	Fixit]=1;
	$ItemMax[earmor,	ForceFieldPack] = 1;		$ItemMax[efemale,	ForceFieldPack] = 1;
	$ItemMax[earmor,	ShockFloorPack] = 1;		$ItemMax[efemale,	ShockFloorPack] = 1;
	$ItemMax[earmor,	GravGun] = 1;			$ItemMax[efemale,	GravGun] = 1;
	$ItemMax[earmor,	Grenade] = 6;			$ItemMax[efemale,	Grenade] = 6;
	$ItemMax[earmor,	GrenadeAmmo] = 10;		$ItemMax[efemale,	GrenadeAmmo] = 10;
	$ItemMax[earmor,	GrenadeLauncher] = 1;		$ItemMax[efemale,	GrenadeLauncher] = 1;
	$ItemMax[earmor,	Hackit] = 1;			$ItemMax[efemale,	Hackit]= 1;
	$ItemMax[earmor,	HoloPack] = 1;			$ItemMax[efemale,	HoloPack] = 1;
	$ItemMax[earmor,	Laptop] = 1;			$ItemMax[efemale,	Laptop]= 1;
	$ItemMax[earmor,	LargeForceFieldPack] = 1;	$ItemMax[efemale,	LargeForceFieldPack] = 1;
	$ItemMax[earmor,	LargeShockForceFieldPack] = 1;	$ItemMax[efemale,	LargeShockForceFieldPack] = 1;
	$ItemMax[earmor,	LaserPack] = 1;			$ItemMax[efemale,	LaserPack] = 1;
	$ItemMax[earmor,	LaunchPack] = 1;		$ItemMax[efemale,	LaunchPack] = 1;
	$ItemMax[earmor,	MineAmmo] = 3;			$ItemMax[efemale,	MineAmmo] = 3;
	$ItemMax[earmor,	MotionSensorPack] = 1;		$ItemMax[efemale,	MotionSensorPack] = 1;
	$ItemMax[earmor,	PlantPack] = 1;			$ItemMax[efemale,	PlantPack] = 1;
	$ItemMax[earmor,	PlasmaAmmo] = 40;		$ItemMax[efemale,	PlasmaAmmo] = 35;
	$ItemMax[earmor,	PlasmaGun] = 1;			$ItemMax[efemale,	PlasmaGun] = 1;
	$ItemMax[earmor,	PlasmaTurretPack] = 1;		$ItemMax[efemale,	PlasmaTurretPack] = 1;
	$ItemMax[earmor,	PlatformPack] = 1;		$ItemMax[efemale,	PlatformPack] = 1;
	$ItemMax[earmor,	PulseSensorPack] = 1;		$ItemMax[efemale,	PulseSensorPack] = 1;
	$ItemMax[earmor,	RailAmmo] = 10;			$ItemMax[efemale,	RailAmmo] = 10;
	$ItemMax[earmor,	Railgun] = 1;			$ItemMax[efemale,	Railgun] = 1;
	$ItemMax[earmor,	RepairKit] = 1;			$ItemMax[efemale,	RepairKit] = 1;
	$ItemMax[earmor,	RepairPack] = 1;		$ItemMax[efemale,	RepairPack] = 1;
	$ItemMax[earmor,	RocketAmmo] = 5;		$ItemMax[efemale,	RocketAmmo] = 5;
	$ItemMax[earmor,	RocketLauncher] = 1;		$ItemMax[efemale,	RocketLauncher] = 1;
	$ItemMax[earmor,	RocketPack] = 1;		$ItemMax[efemale,	RocketPack] = 1;
	$ItemMax[earmor,	SensorJammerPack] = 1;		$ItemMax[efemale,	SensorJammerPack] = 1;
	$ItemMax[earmor,	ShieldPack] = 1;		$ItemMax[efemale,	ShieldPack] = 1;
	$ItemMax[earmor,	ShockPack] = 1;			$ItemMax[efemale,	ShockPack] = 1;
	$ItemMax[earmor,	StealthShieldPack] = 1;		$ItemMax[efemale,	StealthShieldPack] = 1;
	$ItemMax[earmor,	TargetingLaser] = 1;		$ItemMax[efemale,	TargetingLaser] = 1;
	$ItemMax[earmor,	TargetPack] = 1;		$ItemMax[efemale,	TargetPack] = 1;
	$ItemMax[earmor,	TeleportPack] = 1;		$ItemMax[efemale,	TeleportPack] = 1;
	$ItemMax[earmor,	TranqAmmo] = 20;		$ItemMax[efemale,	TranqAmmo] = 20;
	$ItemMax[earmor,	TreePack] = 1;			$ItemMax[efemale,	TreePack] = 1;
	$ItemMax[earmor,	TurretPack] = 1;		$ItemMax[efemale,	TurretPack] = 1;
	$ItemMax[earmor,	VulcanAmmo] = 200;		$ItemMax[efemale,	VulcanAmmo] = 200;
	$ItemMax[earmor,	EngineerTurretPack] = 1;	$ItemMax[efemale,	EngineerTurretPack] = 1;
	$ItemMax[earmor, 	BarragePack] = 1;		$ItemMax[efemale, 	BarragePack] = 1;
	$ItemMax[earmor, 	JammerBeaconPack] = 1;		$ItemMax[efemale, 	JammerBeaconPack] = 1;

	$ItemMax[earmor,	NapalmModule] = 1;		     $ItemMax[efemale,	NapalmModule] = 1;
	$ItemMax[earmor,	HellFireModule] = 1;		     $ItemMax[efemale,	HellFireModule] = 1;
	$ItemMax[earmor,	DetPackModule] = 1;		     $ItemMax[efemale,	DetPackModule] = 1;
	$ItemMax[earmor,	BomberModule] = 1;		     $ItemMax[efemale,	BomberModule] = 1;
	$ItemMax[earmor,	PickUpModule] = 1;		     $ItemMax[efemale,	PickUpModule] = 1;
	$ItemMax[earmor,	MineNetModule] = 1;		     $ItemMax[efemale,	MineNetModule] = 1;
	$ItemMax[earmor,	WraithModule] = 1;		     $ItemMax[efemale,	WraithModule] = 1;
	$ItemMax[earmor,	StealthModule] = 1;		     $ItemMax[efemale,	StealthModule] = 1;
	$ItemMax[earmor,	InterceptorModule] = 1;		     $ItemMax[efemale,	InterceptorModule] = 1;
	$ItemMax[earmor,	GodHammerModule] = 1;		     $ItemMax[efemale,	GodHammerModule] = 1;
	//====================================================== Standard Heavy
	$ItemMax[harmor,	AmmoPack] = 1;
	$ItemMax[harmor,	Beacon] = 5;
	$ItemMax[harmor,	Blaster] = 1;
	$ItemMax[harmor,	BulletAmmo] = 150;
	$ItemMax[harmor,	Chaingun] = 1;
	$ItemMax[harmor,	DeployableAmmoPack] = 1;
	$ItemMax[harmor,	DeployableComPack] = 1;
	$ItemMax[harmor,	DeployableInvPack] = 1;
	$ItemMax[harmor,	DiscAmmo] = 15;
	$ItemMax[harmor,	Disclauncher] = 1;
	$ItemMax[harmor,	EnergyPack] = 1;
	$ItemMax[harmor,	EnergyRifle] = 1;
	$ItemMax[harmor,	Equalizer] = 1; 
	$ItemMax[harmor,	ForceFieldPack] = 1;
	$ItemMax[harmor,	ShockFloorPack] = 1;
	$ItemMax[harmor,	Grenade] = 1;
	$ItemMax[harmor,	GrenadeAmmo] = 15;
	$ItemMax[harmor,	GrenadeLauncher] = 1;
	$ItemMax[harmor,	HoloPack] = 1;
	$ItemMax[harmor,	Mfgl] = 1;
	$ItemMax[harmor,	MfglAmmo] = 4;
	$ItemMax[harmor,	MineAmmo] = 3;
	$ItemMax[harmor,	Mortar] = 1;
	$ItemMax[harmor,	MortarAmmo] = 10;
	$ItemMax[harmor,	MotionSensorPack] = 1;
	$ItemMax[harmor,	Volter] = 1;
	$ItemMax[harmor,	PlasmaAmmo] = 50;
	$ItemMax[harmor,	PlasmaGun] = 1;
	$ItemMax[harmor,	PulseSensorPack] = 1;
	$ItemMax[harmor,	RailAmmo] = 10;
	$ItemMax[harmor,	RegenerationPack] = 1;
	$ItemMax[harmor,	RepairKit] = 1;
	$ItemMax[harmor,	RepairPack] = 1;
	$ItemMax[harmor,	RocketAmmo] = 15;
	$ItemMax[harmor,	SensorJammerPack] = 1;
	$ItemMax[harmor,	ShieldPack] = 1;
	$ItemMax[harmor,	StealthShieldPack] = 1;
	$ItemMax[harmor,	TargetingLaser] = 1;
	$ItemMax[harmor,	TranqAmmo] = 20;
	$ItemMax[harmor,	TurretPack] = 1;
	$ItemMax[harmor,	Vulcan] = 1;
	$ItemMax[harmor,	VulcanAmmo] = 400;

	//====================================================== Juggernaught
	$ItemMax[jarmor,	AutoRocketAmmo] = 20;
	$ItemMax[jarmor,	Beacon] = 5;
	$ItemMax[jarmor,	LasCannon] = 1;
	$ItemMax[jarmor,	Mfgl] = 1;
	$ItemMax[jarmor,	MfglAmmo] = 4;
	$ItemMax[jarmor,	Mortar] = 1;
	$ItemMax[jarmor,	MortarAmmo] = 25;
	$ItemMax[jarmor,	RepairKit] = 1;
	$ItemMax[jarmor,	RocketAmmo] = 25;
	$ItemMax[jarmor,	RocketLauncher] = 1;
	$ItemMax[jarmor,	SMRPack2] = 1;
	$ItemMax[jarmor, 	PlasmaCannon] = 1;
	$ItemMax[jarmor,	TargetingLaser] = 1;
	$ItemMax[jarmor,	Hammer1Pack] = 1;
	$ItemMax[jarmor,	Hammer2Pack] = 1;
	$ItemMax[jarmor,	HammerAmmo] = 150;
	
	//====================================================== Assassin
	$ItemMax[larmor, 	ArbitorBeaconPack] = 1;			$ItemMax[lfemale,	ArbitorBeaconPack] = 1;
	$ItemMax[larmor,	AmmoPack] = 1;				$ItemMax[lfemale,	AmmoPack] = 1;
	$ItemMax[larmor,	Beacon] = 5;				$ItemMax[lfemale,	Beacon] = 5;
	$ItemMax[larmor,	Blaster] = 1;				$ItemMax[lfemale,	Blaster] = 1;
	$ItemMax[larmor,	BoomAmmo] = 10;				$ItemMax[lfemale,	BoomAmmo] = 10;
	$ItemMax[larmor,	BoomStick] = 1;				$ItemMax[lfemale,	BoomStick] = 1;
	$ItemMax[larmor,	BulletAmmo] = 75;			$ItemMax[lfemale,	BulletAmmo] = 75;
	$ItemMax[larmor,	CameraPack] = 1;			$ItemMax[lfemale,	CameraPack] = 1;
	$ItemMax[larmor,	Chaingun] = 1;				$ItemMax[lfemale,	Chaingun] = 1;
	$ItemMax[larmor,	DiscAmmo] = 15;				$ItemMax[lfemale,	DiscAmmo] = 15;
	$ItemMax[larmor,	Disclauncher] = 1;			$ItemMax[lfemale,	Disclauncher] = 1;
	$ItemMax[larmor,	EnergyPack] = 1;			$ItemMax[lfemale,	EnergyPack] = 1;
	$ItemMax[larmor,	EnergyRifle] = 1;			$ItemMax[lfemale,	EnergyRifle] = 1;
	$ItemMax[larmor,	ForceFieldPack] = 1;			$ItemMax[lfemale,	ForceFieldPack] = 1;
	$ItemMax[larmor,	Grenade] = 3;				$ItemMax[lfemale,	Grenade] = 3;
	$ItemMax[larmor,	GrenadeAmmo] = 10;			$ItemMax[lfemale,	GrenadeAmmo] = 10;
	$ItemMax[larmor,	GrenadeLauncher] = 1;			$ItemMax[lfemale,	GrenadeLauncher] = 1;
	$ItemMax[larmor,	HoloPack] = 1;				$ItemMax[lfemale,	HoloPack] = 1;
	$ItemMax[larmor,	LaserRifle] = 1;			$ItemMax[lfemale,	LaserRifle] = 1;
	$ItemMax[larmor,	MineAmmo] = 3;				$ItemMax[lfemale,	MineAmmo] = 3;
	$ItemMax[larmor,	MotionSensorPack] = 1;			$ItemMax[lfemale,	MotionSensorPack] = 1;
	$ItemMax[larmor,	OpticPack] = 1;				$ItemMax[lfemale,	OpticPack] = 1;
	$ItemMax[larmor,	PlasmaAmmo] = 30;			$ItemMax[lfemale,	PlasmaAmmo] = 30;
	$ItemMax[larmor,	PlasmaGun] = 1;				$ItemMax[lfemale,	PlasmaGun] = 1;
	$ItemMax[larmor,	PulseSensorPack] = 1;			$ItemMax[lfemale,	PulseSensorPack] = 1;
	$ItemMax[larmor,	RailAmmo] = 10;				$ItemMax[lfemale,	RailAmmo] = 10;
	$ItemMax[larmor,	Railgun] = 1;				$ItemMax[lfemale,	Railgun] = 1;
	$ItemMax[larmor,	RepairKit] = 1;				$ItemMax[lfemale,	RepairKit] = 1;
	$ItemMax[larmor,	RepairPack] = 1;			$ItemMax[lfemale,	RepairPack] = 1;
	$ItemMax[larmor,	SensorJammerPack] = 1;			$ItemMax[lfemale,	SensorJammerPack] = 1;
	$ItemMax[larmor,	ShieldPack] = 1;			$ItemMax[lfemale,	ShieldPack] = 1;
	$ItemMax[larmor,	SniperAmmo] = 25;			$ItemMax[lfemale,	SniperAmmo] = 25;
	$ItemMax[larmor,	SniperRifle] = 1;			$ItemMax[lfemale,	SniperRifle] = 1;
	$ItemMax[larmor,	StealthShieldPack] = 1;			$ItemMax[lfemale,	StealthShieldPack] = 1;
	$ItemMax[larmor,	TargetingLaser] = 1;			$ItemMax[lfemale,	TargetingLaser] = 1;
	$ItemMax[larmor,	TranqAmmo] = 20;			$ItemMax[lfemale,	TranqAmmo] = 20;
	$ItemMax[larmor,	TranqGun] = 1;				$ItemMax[lfemale,	TranqGun] = 1;
	$ItemMax[larmor,	TreePack] = 1;				$ItemMax[lfemale,	TreePack] = 1;
	
	$ItemMax[larmor,	NapalmModule] = 1;		     $ItemMax[lfemale,	NapalmModule] = 1;
	$ItemMax[larmor,	HellFireModule] = 1;		     $ItemMax[lfemale,	HellFireModule] = 1;
	$ItemMax[larmor,	DetPackModule] = 1;		     $ItemMax[lfemale,	DetPackModule] = 1;
	$ItemMax[larmor,	BomberModule] = 1;		     $ItemMax[lfemale,	BomberModule] = 1;
	$ItemMax[larmor,	PickUpModule] = 1;		     $ItemMax[lfemale,	PickUpModule] = 1;
	$ItemMax[larmor,	MineNetModule] = 1;		     $ItemMax[lfemale,	MineNetModule] = 1;
	$ItemMax[larmor,	WraithModule] = 1;		     $ItemMax[lfemale,	WraithModule] = 1;
	$ItemMax[larmor,	StealthModule] = 1;		     $ItemMax[lfemale,	StealthModule] = 1;
	$ItemMax[larmor,	InterceptorModule] = 1;		     $ItemMax[lfemale,	InterceptorModule] = 1;
	$ItemMax[larmor,	GodHammerModule] = 1;		     $ItemMax[lfemale,	GodHammerModule] = 1;
	
	//====================================================== Mercinary
	$ItemMax[marmor,	AmmoPack] = 1;				$ItemMax[mfemale,	AmmoPack] = 1;
	$ItemMax[marmor,	Beacon] = 3;				$ItemMax[mfemale,	Beacon] = 3;
	$ItemMax[marmor,	Blaster] = 1;				$ItemMax[mfemale,	Blaster] = 1;
	$ItemMax[marmor,	BoomAmmo] = 15;				$ItemMax[mfemale,	BoomAmmo] = 15;
	$ItemMax[marmor,	BoomStick] = 1;				$ItemMax[mfemale,	BoomStick] = 1;
	$ItemMax[marmor,	BulletAmmo] = 100;			$ItemMax[mfemale,	BulletAmmo] = 100;
	$ItemMax[marmor,	Chaingun] = 1;				$ItemMax[mfemale,	Chaingun] = 1;
	$ItemMax[marmor,	DeployableAmmoPack] = 1;		$ItemMax[mfemale,	DeployableAmmoPack] = 1;
	$ItemMax[marmor,	DeployableInvPack] = 1;			$ItemMax[mfemale,	DeployableInvPack] = 1;
	$ItemMax[marmor,	DeployableSensorJammerPack] = 1;	$ItemMax[mfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[marmor,	DiscAmmo] = 15;				$ItemMax[mfemale,	DiscAmmo] = 15;
	$ItemMax[marmor,	Disclauncher] = 1;			$ItemMax[mfemale,	Disclauncher] = 1;
	$ItemMax[marmor,	EnergyPack] = 1;			$ItemMax[mfemale,	EnergyPack] = 1;
	$ItemMax[marmor,	EnergyRifle] = 1;			$ItemMax[mfemale,	EnergyRifle] = 1;
	$ItemMax[marmor,	Equalizer] = 1;				$ItemMax[mfemale,	Equalizer] = 1;
	$ItemMax[marmor,	ForceFieldPack] = 1;			$ItemMax[mfemale,	ForceFieldPack] = 1;
	$ItemMax[marmor,	Grenade] = 6;				$ItemMax[mfemale,	Grenade] = 6;
	$ItemMax[marmor,	GrenadeAmmo] = 10;			$ItemMax[mfemale,	GrenadeAmmo] = 10;
	$ItemMax[marmor,	GrenadeLauncher] = 1;			$ItemMax[mfemale,	GrenadeLauncher] = 1;
	$ItemMax[marmor,	HoloPack] = 1;				$ItemMax[mfemale,	HoloPack] = 1;
	$ItemMax[marmor,	HyperB] = 1;				$ItemMax[mfemale,	HyperB] = 1;
	$ItemMax[marmor,	MineAmmo] = 3;				$ItemMax[mfemale,	IonGun] = 1;
	$ItemMax[marmor,	MortarAmmo] = 10;			$ItemMax[mfemale,	MineAmmo] = 3;
	$ItemMax[marmor,	MotionSensorPack] = 1;			$ItemMax[mfemale,	MotionSensorPack] = 1;
	$ItemMax[marmor,	PlasmaAmmo] = 40;			$ItemMax[mfemale,	PlasmaAmmo] = 35;
	$ItemMax[marmor,	PlasmaGun] = 1;				$ItemMax[mfemale,	PlasmaGun] = 1;
	$ItemMax[marmor,	PulseSensorPack] = 1;			$ItemMax[mfemale,	PulseSensorPack] = 1;
	$ItemMax[marmor,	RailAmmo] = 10;				$ItemMax[mfemale,	RailAmmo] = 10;
	$ItemMax[marmor,	RepairKit] = 1;				$ItemMax[mfemale,	RepairKit] = 1;
	$ItemMax[marmor,	RepairPack] = 1;			$ItemMax[mfemale,	RepairPack] = 1;
	$ItemMax[marmor,	RocketAmmo] = 5;			$ItemMax[mfemale,	RocketAmmo] = 5;
	$ItemMax[marmor,	RocketLauncher] = 1;			$ItemMax[mfemale,	RocketLauncher] = 1;
	$ItemMax[marmor,	SensorJammerPack] = 1;			$ItemMax[mfemale,	SensorJammerPack] = 1;
	$ItemMax[marmor,	ShieldPack] = 1;			$ItemMax[mfemale,	ShieldPack] = 1;
	$ItemMax[marmor,	StealthShieldPack] = 1;			$ItemMax[mfemale,	StealthShieldPack] = 1;
	$ItemMax[marmor,	TargetingLaser] = 1;			$ItemMax[mfemale,	TargetingLaser] = 1;
	$ItemMax[marmor,	TranqAmmo] = 20;			$ItemMax[mfemale,	TranqAmmo] = 20;
	$ItemMax[marmor,	TurretPack] = 1;			$ItemMax[mfemale,	TurretPack] = 1;
	$ItemMax[marmor,	Vulcan] = 1;				$ItemMax[mfemale,	Vulcan] = 1;
	$ItemMax[marmor,	VulcanAmmo] = 300;			$ItemMax[mfemale,	VulcanAmmo] = 300;
	$ItemMax[marmor,	Silencer] = 1;			     	$ItemMax[mfemale,	Silencer] = 1;
	$ItemMax[marmor,	SilencerAmmo] = 25;		     	$ItemMax[mfemale,	SilencerAmmo] = 25;
	$ItemMax[marmor, 	BarragePack] = 1;			$ItemMax[mfemale, 	BarragePack] = 1;
	$ItemMax[marmor, 	Booster1Pack] = 1;			$ItemMax[mfemale, 	Booster1Pack] = 1;
	$ItemMax[marmor, 	Booster2Pack] = 1;			$ItemMax[mfemale, 	Booster2Pack] = 1;
	
	$ItemMax[marmor,	NapalmModule] = 1;		     	$ItemMax[mfemale,	NapalmModule] = 1;
	$ItemMax[marmor,	HellFireModule] = 1;		     	$ItemMax[mfemale,	HellFireModule] = 1;
	$ItemMax[marmor,	DetPackModule] = 1;		     	$ItemMax[mfemale,	DetPackModule] = 1;
	$ItemMax[marmor,	BomberModule] = 1;		     	$ItemMax[mfemale,	BomberModule] = 1;
	$ItemMax[marmor,	PickUpModule] = 1;		     	$ItemMax[mfemale,	PickUpModule] = 1;
	$ItemMax[marmor,	MineNetModule] = 1;		     	$ItemMax[mfemale,	MineNetModule] = 1;
	$ItemMax[marmor,	WraithModule] = 1;		     	$ItemMax[mfemale,	WraithModule] = 1;
	$ItemMax[marmor,	StealthModule] = 1;		     	$ItemMax[mfemale,	StealthModule] = 1;
	$ItemMax[marmor,	InterceptorModule] = 1;		     	$ItemMax[mfemale,	InterceptorModule] = 1;
	$ItemMax[marmor,	GodHammerModule] = 1;		     	$ItemMax[mfemale,	GodHammerModule] = 1;
	//====================================================== Cursed
	$ItemMax[parmor,	Penis] = 1;

	//====================================================== Scout
	$ItemMax[sarmor,	AmmoPack] = 1;			     $ItemMax[sfemale,	AmmoPack] = 1;
	$ItemMax[sarmor,	Beacon] = 3;			     $ItemMax[sfemale,	Beacon] = 3;
	$ItemMax[sarmor,	Blaster] = 1;			     $ItemMax[sfemale,	Blaster] = 1;
	$ItemMax[sarmor,	BoomAmmo] = 10;			     $ItemMax[sfemale,	BoomAmmo] = 10;
	$ItemMax[sarmor,	BoomStick] = 1;			     $ItemMax[sfemale,	BoomStick] = 1;
	$ItemMax[sarmor,	BulletAmmo] = 50;		     $ItemMax[sfemale,	BulletAmmo] = 50;
	$ItemMax[sarmor,	CameraPack] = 1;		     $ItemMax[sfemale,	CameraPack] = 1;
	$ItemMax[sarmor,	Chaingun] = 1;			     $ItemMax[sfemale,	Chaingun] = 1;
	$ItemMax[sarmor,	DiscAmmo] = 15;			     $ItemMax[sfemale,	DiscAmmo] = 15;
	$ItemMax[sarmor,	Disclauncher] = 1;		     $ItemMax[sfemale,	Disclauncher] = 1;
	$ItemMax[sarmor,	EnergyPack] = 1;		     $ItemMax[sfemale,	EnergyPack] = 1;
	$ItemMax[sarmor,	EnergyRifle] = 1;		     $ItemMax[sfemale,	EnergyRifle] = 1;
	$ItemMax[sarmor,	Flamer] = 1;			     $ItemMax[sfemale,	Flamer] = 1;
	$ItemMax[sarmor,	FlightPack] = 1;		     $ItemMax[sfemale,	FlightPack] = 1;
	$ItemMax[sarmor,	ForceFieldPack] = 1;		     $ItemMax[sfemale,	ForceFieldPack] = 1;
	$ItemMax[sarmor,	Grenade] = 5;			     $ItemMax[sfemale,	Grenade] = 5;
	$ItemMax[sarmor,	GrenadeAmmo] = 10;		     $ItemMax[sfemale,	GrenadeAmmo] = 10;
	$ItemMax[sarmor,	GrenadeLauncher] = 1;		     $ItemMax[sfemale,	GrenadeLauncher] = 1;
	$ItemMax[sarmor,	HoloPack] = 1;			     $ItemMax[sfemale,	HoloPack] = 1;
	$ItemMax[sarmor,	HyperB] = 1;			     $ItemMax[sfemale,	HyperB] = 1;
	$ItemMax[sarmor,	Laptop] = 1;			     $ItemMax[sfemale,	Laptop] = 1;
	$ItemMax[sarmor,	LaserRifle] = 1;		     $ItemMax[sfemale,	LaserRifle] = 1;
	$ItemMax[sarmor,	MechPack] = 1;			     $ItemMax[sfemale,	MechPack] = 1;
	$ItemMax[sarmor,	MineAmmo] = 3;			     $ItemMax[sfemale,	MineAmmo] = 3;
	$ItemMax[sarmor,	MotionSensorPack] = 1;		     $ItemMax[sfemale,	MotionSensorPack] = 1;
	$ItemMax[sarmor,	PlasmaAmmo] = 30;		     $ItemMax[sfemale,	PlasmaAmmo] = 30;
	$ItemMax[sarmor,	PlasmaGun] = 1;			     $ItemMax[sfemale,	PlasmaGun] = 1;
	$ItemMax[sarmor,	PulseSensorPack] = 1;		     $ItemMax[sfemale,	PulseSensorPack] = 1;
	$ItemMax[sarmor,	RailAmmo] = 10;			     $ItemMax[sfemale,	RailAmmo] = 10;
	$ItemMax[sarmor,	RepairKit] = 1;			     $ItemMax[sfemale,	RepairKit] = 1;
	$ItemMax[sarmor,	RepairPack] = 1;		     $ItemMax[sfemale,	RepairPack] = 1;
	$ItemMax[sarmor,	SensorJammerPack] = 1;		     $ItemMax[sfemale,	SensorJammerPack] = 1;
	$ItemMax[sarmor,	ShieldPack] = 1;		     $ItemMax[sfemale,	ShieldPack] = 1;
	$ItemMax[sarmor,	StealthShieldPack] = 1;		     $ItemMax[sfemale,	StealthShieldPack] = 1;
	$ItemMax[sarmor,	TargetingLaser] = 1;		     $ItemMax[sfemale,	TargetingLaser] = 1;
	$ItemMax[sarmor,	TranqAmmo] = 20;		     $ItemMax[sfemale,	TranqAmmo] = 20;
	
	$ItemMax[sarmor,	NapalmModule] = 1;		     $ItemMax[sfemale,	NapalmModule] = 1;
	$ItemMax[sarmor,	HellFireModule] = 1;		     $ItemMax[sfemale,	HellFireModule] = 1;
	$ItemMax[sarmor,	DetPackModule] = 1;		     $ItemMax[sfemale,	DetPackModule] = 1;
	$ItemMax[sarmor,	BomberModule] = 1;		     $ItemMax[sfemale,	BomberModule] = 1;
	$ItemMax[sarmor,	PickUpModule] = 1;		     $ItemMax[sfemale,	PickUpModule] = 1;
	$ItemMax[sarmor,	MineNetModule] = 1;		     $ItemMax[sfemale,	MineNetModule] = 1;
	$ItemMax[sarmor,	WraithModule] = 1;		     $ItemMax[sfemale,	WraithModule] = 1;
	$ItemMax[sarmor,	StealthModule] = 1;		     $ItemMax[sfemale,	StealthModule] = 1;
	$ItemMax[sarmor,	InterceptorModule] = 1;		     $ItemMax[sfemale,	InterceptorModule] = 1;
	$ItemMax[sarmor,	GodHammerModule] = 1;		     $ItemMax[sfemale,	GodHammerModule] = 1;

	//====================================================== Stim Scout
	$ItemMax[stimarmor,	AmmoPack] = 1;			      $ItemMax[stimfemale,	AmmoPack] = 1;
	$ItemMax[stimarmor,	Beacon] = 3;			      $ItemMax[stimfemale,	Beacon] = 3;
	$ItemMax[stimarmor,	Blaster] = 1;			      $ItemMax[stimfemale,	Blaster] = 1;
	$ItemMax[stimarmor,	BoomAmmo] = 10;			      $ItemMax[stimfemale,	BoomAmmo] = 10;
	$ItemMax[stimarmor,	BoomStick] = 1;			      $ItemMax[stimfemale,	BoomStick] = 1;
	$ItemMax[stimarmor,	BulletAmmo] = 50;		      $ItemMax[stimfemale,	BulletAmmo] = 50;
	$ItemMax[stimarmor,	CameraPack] = 1;		      $ItemMax[stimfemale,	CameraPack] = 1;
	$ItemMax[stimarmor,	Chaingun] = 1;			      $ItemMax[stimfemale,	Chaingun] = 1;
	$ItemMax[stimarmor,	DiscAmmo] = 15;			      $ItemMax[stimfemale,	DiscAmmo] = 15;
	$ItemMax[stimarmor,	Disclauncher] = 1;		      $ItemMax[stimfemale,	Disclauncher] = 1;
	$ItemMax[stimarmor,	EnergyPack] = 1;		      $ItemMax[stimfemale,	EnergyPack] = 1;
	$ItemMax[stimarmor,	EnergyRifle] = 1;		      $ItemMax[stimfemale,	EnergyRifle] = 1;
	$ItemMax[stimarmor,	Flamer] = 1;			      $ItemMax[stimfemale,	Flamer] = 1;
	$ItemMax[stimarmor,	FlightPack] = 1;		      $ItemMax[stimfemale,	FlightPack] = 1;
	$ItemMax[stimarmor,	ForceFieldPack] = 1;		      $ItemMax[stimfemale,	ForceFieldPack] = 1;
	$ItemMax[stimarmor,	Grenade] = 5;			      $ItemMax[stimfemale,	Grenade] = 5;
	$ItemMax[stimarmor,	GrenadeAmmo] = 10;		      $ItemMax[stimfemale,	GrenadeAmmo] = 10;
	$ItemMax[stimarmor,	GrenadeLauncher] = 1;		      $ItemMax[stimfemale,	GrenadeLauncher] = 1;
	$ItemMax[stimarmor,	HoloPack] = 1;			      $ItemMax[stimfemale,	HoloPack] = 1;
	$ItemMax[stimarmor,	HyperB] = 1;			      $ItemMax[stimfemale,	HyperB] = 1;
	$ItemMax[stimarmor,	Laptop] = 1;			      $ItemMax[stimfemale,	Laptop] = 1;
	$ItemMax[stimarmor,	LaserRifle] = 1;		      $ItemMax[stimfemale,	LaserRifle] = 1;
	$ItemMax[stimarmor,	MechPack] = 1;			      $ItemMax[stimfemale,	MechPack] = 1;
	$ItemMax[stimarmor,	MineAmmo] = 3;			      $ItemMax[stimfemale,	MineAmmo] = 3;
	$ItemMax[stimarmor,	MotionSensorPack] = 1;		      $ItemMax[stimfemale,	MotionSensorPack] = 1;
	$ItemMax[stimarmor,	PlasmaAmmo] = 30;		      $ItemMax[stimfemale,	PlasmaAmmo] = 30;
	$ItemMax[stimarmor,	PlasmaGun] = 1;			      $ItemMax[stimfemale,	PlasmaGun] = 1;
	$ItemMax[stimarmor,	PulseSensorPack] = 1;		      $ItemMax[stimfemale,	PulseSensorPack] = 1;
	$ItemMax[stimarmor,	RailAmmo] = 10;			      $ItemMax[stimfemale,	RailAmmo] = 10;
	$ItemMax[stimarmor,	RepairKit] = 1;			      $ItemMax[stimfemale,	RepairKit] = 1;
	$ItemMax[stimarmor,	RepairPack] = 1;		      $ItemMax[stimfemale,	RepairPack] = 1;
	$ItemMax[stimarmor,	SensorJammerPack] = 1;		      $ItemMax[stimfemale,	SensorJammerPack] = 1;
	$ItemMax[stimarmor,	ShieldPack] = 1;		      $ItemMax[stimfemale,	ShieldPack] = 1;
	$ItemMax[stimarmor,	StealthShieldPack] = 1;		      $ItemMax[stimfemale,	StealthShieldPack] = 1;
	$ItemMax[stimarmor,	TargetingLaser] = 1;		      $ItemMax[stimfemale,	TargetingLaser] = 1;
	$ItemMax[stimarmor,	TranqAmmo] = 20;		      $ItemMax[stimfemale,	TranqAmmo] = 20;

	//====================================================== Chemeleon
	$ItemMax[spyarmor,	AmmoPack] = 1;			     $ItemMax[spyfemale,	AmmoPack] = 1;
	$ItemMax[spyarmor,	Beacon] = 3;			     $ItemMax[spyfemale,	Beacon] = 3;
	$ItemMax[spyarmor,	Blaster] = 1;			     $ItemMax[spyfemale,	Blaster] = 1;
	$ItemMax[spyarmor,	BoomAmmo] = 10;			     $ItemMax[spyfemale,	BoomAmmo] = 10;
	$ItemMax[spyarmor,	BoomStick] = 1;			     $ItemMax[spyfemale,	BoomStick] = 1;
	$ItemMax[spyarmor,	BulletAmmo] = 75;		     $ItemMax[spyfemale,	BulletAmmo] = 75;
	$ItemMax[spyarmor,	CameraPack] = 1;		     $ItemMax[spyfemale,	CameraPack] = 1;
	$ItemMax[spyarmor,	Chaingun] = 1;			     $ItemMax[spyfemale,	Chaingun] = 1;
	$ItemMax[spyarmor,	CloakingDevice] = 1;		     $ItemMax[spyfemale,	CloakingDevice] = 1;
	$ItemMax[spyarmor,	DeployableSensorJammerPack] = 1;     $ItemMax[spyfemale,	DeployableSensorJammerPack] = 1;
	$ItemMax[spyarmor,	DiscAmmo] = 15;			     $ItemMax[spyfemale,	DiscAmmo] = 15;
	$ItemMax[spyarmor,	Disclauncher] = 1;		     $ItemMax[spyfemale,	Disclauncher] = 1;
	$ItemMax[spyarmor,	EnergyPack] = 1;		     $ItemMax[spyfemale,	EnergyPack] = 1;
	$ItemMax[spyarmor,	EnergyRifle] = 1;		     $ItemMax[spyfemale,	EnergyRifle] = 1;
	$ItemMax[spyarmor,	Equalizer] = 1;			     $ItemMax[spyfemale,	Equalizer] = 1;
	$ItemMax[spyarmor,	FlightPack] = 1;		     $ItemMax[spyfemale,	FlightPack] = 1;
	$ItemMax[spyarmor,	ForceFieldPack] = 1;		     $ItemMax[spyfemale,	ForceFieldPack] = 1;
	$ItemMax[spyarmor,	Grenade] = 3;			     $ItemMax[spyfemale,	Grenade] = 3;
	$ItemMax[spyarmor,	GrenadeAmmo] = 10;		     $ItemMax[spyfemale,	GrenadeAmmo] = 10;
	$ItemMax[spyarmor,	GrenadeLauncher] = 1;		     $ItemMax[spyfemale,	GrenadeLauncher] = 1;
	$ItemMax[spyarmor,	HoloPack] = 1;			     $ItemMax[spyfemale,	HoloPack] = 1;
	$ItemMax[spyarmor,	Laptop] = 1;			     $ItemMax[spyfemale,	Laptop] = 1;
	$ItemMax[spyarmor,	LaserPack] = 1;			     $ItemMax[spyfemale,	LaserPack] = 1;
	$ItemMax[spyarmor,	LaserRifle] = 1;		     $ItemMax[spyfemale,	LaserRifle] = 1;
	$ItemMax[spyarmor,	MineAmmo] = 3;			     $ItemMax[spyfemale,	MineAmmo] = 3;
	$ItemMax[spyarmor,	MotionSensorPack] = 1;		     $ItemMax[spyfemale,	MotionSensorPack] = 1;
	$ItemMax[spyarmor,	PlasmaAmmo] = 30;		     $ItemMax[spyfemale,	PlasmaAmmo] = 30;
	$ItemMax[spyarmor,	PlasmaGun] = 1;			     $ItemMax[spyfemale,	PlasmaGun] = 1;
	$ItemMax[spyarmor,	PulseSensorPack] = 1;		     $ItemMax[spyfemale,	PulseSensorPack] = 1;
	$ItemMax[spyarmor,	RailAmmo] = 10;			     $ItemMax[spyfemale,	RailAmmo] = 10;
	$ItemMax[spyarmor,	RepairKit] = 1;			     $ItemMax[spyfemale,	RepairKit] = 1;
	$ItemMax[spyarmor,	RepairPack] = 1;		     $ItemMax[spyfemale,	RepairPack] = 1;
	$ItemMax[spyarmor,	SensorJammerPack] = 1;		     $ItemMax[spyfemale,	SensorJammerPack] = 1;
	$ItemMax[spyarmor,	ShieldPack] = 1;		     $ItemMax[spyfemale,	ShieldPack] = 1;
	$ItemMax[spyarmor,	Silencer] = 1;			     $ItemMax[spyfemale,	Silencer] = 1;
	$ItemMax[spyarmor,	SilencerAmmo] = 25;		     $ItemMax[spyfemale,	SilencerAmmo] = 25;
	$ItemMax[spyarmor,	StealthShieldPack] = 1;		     $ItemMax[spyfemale,	StealthShieldPack] = 1;
	$ItemMax[spyarmor,	TargetingLaser] = 1;		     $ItemMax[spyfemale,	TargetingLaser] = 1;
	$ItemMax[spyarmor,	TranqAmmo] = 20;		     $ItemMax[spyfemale,	TranqAmmo] = 20;
	$ItemMax[spyarmor,	TranqGun] = 1;			     $ItemMax[spyfemale,	TranqGun] = 1;
	
	$ItemMax[spyarmor,	NapalmModule] = 1;		     $ItemMax[spyfemale,	NapalmModule] = 1;
	$ItemMax[spyarmor,	HellFireModule] = 1;		     $ItemMax[spyfemale,	HellFireModule] = 1;
	$ItemMax[spyarmor,	DetPackModule] = 1;		     $ItemMax[spyfemale,	DetPackModule] = 1;
	$ItemMax[spyarmor,	BomberModule] = 1;		     $ItemMax[spyfemale,	BomberModule] = 1;
	$ItemMax[spyarmor,	PickUpModule] = 1;		     $ItemMax[spyfemale,	PickUpModule] = 1;
	$ItemMax[spyarmor,	MineNetModule] = 1;		     $ItemMax[spyfemale,	MineNetModule] = 1;
	$ItemMax[spyarmor,	WraithModule] = 1;		     $ItemMax[spyfemale,	WraithModule] = 1;
	$ItemMax[spyarmor,	StealthModule] = 1;		     $ItemMax[spyfemale,	StealthModule] = 1;
	$ItemMax[spyarmor,	InterceptorModule] = 1;		     $ItemMax[spyfemale,	InterceptorModule] = 1;
	$ItemMax[spyarmor,	GodHammerModule] = 1;		     $ItemMax[spyfemale,	GodHammerModule] = 1;

}

function InitArmorMax()
{	
	for (%j=1;$armorId[%j] != "" ; %j++)
	{
		%armor = $armorId[%j];
		
		for (%i=0; !getWord($ItemBlock,%i); %i++)
		{
			%item = getWord($ItemBlock,%i);
			%ammount = getWord($armorList[%j],%i);			
			$ItemMax[%armor,%item] = %ammount;		
		}
		if ($debug) echo ("*** Initializing Armor Data " @ %armor @ "***");
	}
}


function Armordatalist(%armorId)
{
	for (%j=1;$armorId[%j] != "" ; %j++)
	{
		%armor = $armorId[%j];
		for (%i=0; !getWord($ItemBlock,%i); %i++)
		{
			for (%k=0; getItemData(%k) != ""; %k++)
			{
				if (getItemData(%k) == getWord($ItemBlock,%i))
				{
					%armorlist = (%armorlist @ " " @ $ItemMax[%armor, getItemData(%k)]);
				}
			}
		}
		%armorlist = "";
	}
}

//InitArmorMax();

//------------------------------------------------------------------
// Armour Data Fields
//------------------------------------------------------------------

DamageSkinData armorDamageSkins
{
   bmpName[0] = "dskin1_armor";
   bmpName[1] = "dskin2_armor";
   bmpName[2] = "dskin3_armor";
   bmpName[3] = "dskin4_armor";
   bmpName[4] = "dskin5_armor";
   bmpName[5] = "dskin6_armor";
   bmpName[6] = "dskin7_armor";
   bmpName[7] = "dskin8_armor";
   bmpName[8] = "dskin9_armor";
   bmpName[9] = "dskin10_armor";
};


//----------------------------------------------------------------------------
// Light Armor *Penis Cursed Armor
//----------------------------------------------------------------------------
PlayerData parmor {
 
className = "Armor";
shapeFile = "larmor";
damageSkinData = "armorDamageskins";
debrisId = playerDebris;
flameShapeName = "lflame";
shieldShapeName = "shield";
shadowDetailMask = 1;
visibleToSensor = True;
mapFilter = 1;
mapIcon = "M_player";
canCrouch = true;
maxJetSideForceFactor = 1;
maxJetForwardVelocity = 1;
minJetEnergy = 1;
jetForce = 1;
jetEnergyDrain = 3.8;
maxDamage = 10000;
maxForwardSpeed = 25;
maxBackwardSpeed = 0;
maxSideSpeed = 25;
groundForce = 40 * 9.0;
mass = 500.0;
groundTraction = 13.0;
maxEnergy = 160;
drag = 15.0;
density = 1.2;
minDamageSpeed = 25;
damageScale = 0.005;
jumpImpulse = 75;
jumpSurfaceMinDot = 0.2;

animData[0] = { "root", none, 1, true, true, true, false, 0 };
animData[1] = { "run", none, 1, true, false, true, false, 3 };
animData[2] = { "runback", none, 1, true, false, true, false, 3 };
animData[3] = { "side left", none, 1, true, false, true, false, 3 };
animData[4] = { "side left", none, -1, true, false, true, false, 3 };
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
animData[14] = { "fall", none, 1, true, true, true, false, 3 };
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
animData[19] = { "jet", none, 1, true, true, true, false, 3 };
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
animData[21] = { "throw", none, 1, true, false, false, false, 3 };
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
animData[50] = { "wave", none, 1, true, false, false, true, 1 };
 
 jetSound = SoundJetLight;
 rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
 lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
 footPrints = { 0, 1 };
 boxWidth = 0.5;
 boxDepth = 0.5;
 boxNormalHeight = 2.3;
 boxCrouchHeight = 1.8;
 boxNormalHeadPercentage = 0.83;
 boxNormalTorsoPercentage = 0.53;
 boxCrouchHeadPercentage = 0.6666;
 boxCrouchTorsoPercentage = 0.3333;
 boxHeadRightPercentage = 1;
 boxHeadFrontPercentage = 1;
 };

//------------------------------------------------------------------
// Heavy Armor data: Juggernaught.
//------------------------------------------------------------------

PlayerData jarmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.4;
	maxJetForwardVelocity = 7;
	minJetEnergy = 1;
	jetForce = 390;
	jetEnergyDrain = 1.5;

	maxDamage = 2.0;

	maxForwardSpeed = 4.8;
	maxBackwardSpeed = 4.6;
	maxSideSpeed = 4.0;

	groundForce = 35 * 22.0;
	groundTraction = 4.5;

	mass = 20.0;
	maxEnergy = 150;
	
	drag = 3.0;
	density = 2.5;
	canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};


//==============================================
// Assassin Armour
//==============================================

PlayerData larmor
{
	className = "Armor";
	shapeFile = "larmor"; //larmor
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 22;
	minJetEnergy = 1;
	jetForce = 236;
	jetEnergyDrain = 0.8;

	maxDamage = 0.66;
	maxForwardSpeed = 11;
	maxBackwardSpeed = 10;
	maxSideSpeed = 10;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium Armor data: Mercenary
//------------------------------------------------------------------

PlayerData marmor
{
   className = "Armor";
   shapeFile = "marmor"; //marmor
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

	maxDamage = 1.3;
   maxForwardSpeed = 9.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	
	maxEnergy = 90;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
   animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Heavy Armor data: Dreadnaught
//------------------------------------------------------------------

PlayerData harmor
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "hflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 1;
   jetForce = 390;
   jetEnergyDrain = 1.1;

	maxDamage = 1.32;
	
   maxForwardSpeed = 6.0;
   maxBackwardSpeed = 5.0;
	
   maxSideSpeed = 4.0;
   groundForce = 35 * 18.0;
   groundTraction = 4.5;
   mass = 18.0;
	
	maxEnergy = 140;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 150;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

//------------------------------------------------------------------
// Light female data:  *Assassin
//------------------------------------------------------------------

PlayerData lfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium female data: Mercenary
//------------------------------------------------------------------

PlayerData mfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

   canCrouch = false;
	maxDamage = 1.2;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 90;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// light armor data: Scout
//------------------------------------------------------------------


PlayerData sarmor
{
   className = "Armor";
   shapeFile = "larmor"; //larmor
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.9;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 245;
   jetEnergyDrain = 0.8;

	maxDamage = 0.80;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 12;
   maxSideSpeed = 12;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 95;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


//------------------------------------------------------------------
// Light female data: Stim Female
//------------------------------------------------------------------

PlayerData stimfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 1.2;
   maxJetForwardVelocity = 35;
   minJetEnergy = 1;
   jetForce = 375;
   jetEnergyDrain = 0.8;

   maxDamage = 0.75;
   maxForwardSpeed = 18;
   maxBackwardSpeed = 18;
   maxSideSpeed = 18;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 110;
   drag = 0.7;
   density = 2.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 155;
   jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// light armor data: Stim Male	
//------------------------------------------------------------------


PlayerData stimarmor
{
	className = "Armor";
	shapeFile = "larmor"; //larmor
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 1.3;
	maxJetForwardVelocity = 26;
	minJetEnergy = 1;
	jetForce = 350;
	jetEnergyDrain = 0.8;

	maxDamage = 0.80;
	maxForwardSpeed = 18;
	maxBackwardSpeed = 18;
	maxSideSpeed = 18;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 120;
	drag = 0.8;
	density = 2.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 145;
	jumpSurfaceMinDot = 0.2;

	// animation data:
	// animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
	// movement animations:
	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


	// celebration animations:
	animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	// taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };

	jetSound = SoundJetLight;
	rFootSounds = 
	{
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRHard,
	SoundLFootRSnow,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft,
	SoundLFootRSoft
	}; 
	lFootSounds =
	{
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLHard,
	SoundLFootLSnow,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft,
	SoundLFootLSoft
	};

	footPrints = { 0, 1 };

	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;

	boxNormalHeadPercentage  = 0.83;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.6666;
	boxCrouchTorsoPercentage = 0.3333;

	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium Armor data: Goliath
//------------------------------------------------------------------

PlayerData barmor
{
	className = "Armor";
	shapeFile = "marmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	canCrouch = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.9;
	maxJetForwardVelocity = 18;
	minJetEnergy = 1;
	jetForce = 320;
	jetEnergyDrain = 1.0;

	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;

	maxEnergy = 100;
	drag = 0.9;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 110;
	jumpSurfaceMinDot = 0.2;

	// animation data:
	// animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

	// movement animations:
	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	// celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	// taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };

	jetSound = SoundJetLight;

	rFootSounds = 
	{
	SoundMFootRSoft,
	SoundMFootRHard,
	SoundMFootRSoft,
	SoundMFootRHard,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRHard,
	SoundMFootRSnow,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft,
	SoundMFootRSoft
	}; 
	lFootSounds =
	{
	SoundMFootLSoft,
	SoundMFootLHard,
	SoundMFootLSoft,
	SoundMFootLHard,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLHard,
	SoundMFootLSnow,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft,
	SoundMFootLSoft
	};

	footPrints = { 2, 3 };

	boxWidth = 0.7;
	boxDepth = 0.7;
	boxNormalHeight = 2.4;

	boxNormalHeadPercentage  = 0.83;
	boxNormalTorsoPercentage = 0.49;

	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Heavy Armor data: Dreadnaught
//------------------------------------------------------------------

PlayerData darmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 12;
	minJetEnergy = 1;
	jetForce = 385;
	jetEnergyDrain = 1.1;

	maxDamage = 1.70;

	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 6.0;
	maxSideSpeed = 6.0;

	groundForce = 35 * 19.0;
	groundTraction = 50;
	mass = 19.0;

	maxEnergy = 140;
	drag = 0.9;
	density = 2.5;
	canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

	jumpImpulse = 150;
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };

	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

	// death animations:
	animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
	animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

	// signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

	// celebraton animations:
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

	// taunt anmations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

	// poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };

	jetSound = SoundJetHeavy;

	rFootSounds = 
	{
	SoundHFootRSoft,
	SoundHFootRHard,
	SoundHFootRSoft,
	SoundHFootRHard,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRHard,
	SoundHFootRSnow,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft,
	SoundHFootRSoft
	}; 
	lFootSounds =
	{
	SoundHFootLSoft,
	SoundHFootLHard,
	SoundHFootLSoft,
	SoundHFootLHard,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLHard,
	SoundHFootLSnow,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft,
	SoundHFootLSoft
	};

	footPrints = { 4, 5 };

	boxWidth = 0.8;
	boxDepth = 0.8;
	boxNormalHeight = 2.6;

	boxNormalHeadPercentage  = 0.70;
	boxNormalTorsoPercentage = 0.45;

	boxHeadLeftPercentage  = 0.48;
	boxHeadRightPercentage = 0.70;
	boxHeadBackPercentage  = 0.48;
	boxHeadFrontPercentage = 0.60;
};

//------------------------------------------------------------------
// Light female data: Scout
//------------------------------------------------------------------

PlayerData sfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 25;
   minJetEnergy = 1;
   jetForce = 245;
   jetEnergyDrain = 0.8;

	maxDamage = 0.75;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 13;
   maxSideSpeed = 13;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 95;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium female data: Goliath
//------------------------------------------------------------------

PlayerData bfemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 19;
	minJetEnergy = 1;
	jetForce = 320;
	jetEnergyDrain = 1.0;

	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;

	maxEnergy = 100;
	mass = 13.0;
	drag = 0.9;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 110;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// light armor data: *Chemeleon
//------------------------------------------------------------------


PlayerData spyarmor
{
   className = "Armor";
   shapeFile = "larmor"; //larmor
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
	
	//validateShape = true;

   visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 270;
   jetEnergyDrain = 0.8;

	maxDamage = 0.76;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 11;
   maxSideSpeed = 11;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 80;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Light female data:  *Chemeleon
//------------------------------------------------------------------

PlayerData spyfemale
{
	className = "Armor";
	shapeFile = "lfemale";
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 22;
	minJetEnergy = 1;
	jetForce = 260;
	jetEnergyDrain = 0.8;

	maxDamage = 0.76;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 80;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Medium Armor data: engineer
//------------------------------------------------------------------

PlayerData earmor
{
	className = "Armor";
	shapeFile = "marmor"; //marmor
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;

	//validateShape = true;

	canCrouch = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 1.0;

	maxDamage = 1.0;
	maxForwardSpeed = 9.0;
	maxBackwardSpeed = 7.5;
	maxSideSpeed = 7.5;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;


	maxEnergy = 110;
	drag = 1.0;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 110;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Medium female data: Engineer
//------------------------------------------------------------------

PlayerData efemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;

	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 1.0;

	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 9.0;
	maxBackwardSpeed = 8.5;
	maxSideSpeed = 8.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;

	maxEnergy = 110;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Medium Armor data: Arbitor
//------------------------------------------------------------------

PlayerData aarmor
{
   className = "Armor";
   shapeFile = "marmor"; //marmor
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
	
	//validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 1.0;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 325;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 9.0;
   maxSideSpeed = 9.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.4;
	
	
	maxEnergy = 140;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadFrontPercentage = 1;
};
//------------------------------------------------------------------
// Medium female data: Arbitor
//------------------------------------------------------------------

PlayerData afemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	//validateShape = true;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 1.2;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 0.9;

	canCrouch = false;
	maxDamage = 0.9;
	maxForwardSpeed = 11.0;
	maxBackwardSpeed = 10.0;
	maxSideSpeed = 9.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.5;

	maxEnergy = 140;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

