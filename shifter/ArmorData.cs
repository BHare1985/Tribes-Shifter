function CopyItemData(%max, %armor1, %armor2)
{
	for (%i = 0; %i < %max; %i++)
	{
		%itemname = getItemData(%i);
		$ItemMax[%armor2, %itemname] = $ItemMax[%armor1, %itemname];
	}
}

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
	}

	for (%k=0; $armorId[%k] != ""; %k++)
	{
		%armor = $armorId[%k];
		$ItemMax[%armor, "ValkyrieModule"] = 1;
		$ItemMax[%armor, "HellFireModule"] = 1;
		$ItemMax[%armor, "DetPackModule"] = 1;
		$ItemMax[%armor, "BomberModule"] = 1;
		$ItemMax[%armor, "PickUpModule"] = 1;
		$ItemMax[%armor, "WraithModule"] = 1;
		$ItemMax[%armor, "StealthModule"] = 1;
		$ItemMax[%armor, "InterceptorModule"] = 1;
		$ItemMax[%armor, "GodHammerModule"] = 1;
		$ItemMax[%armor, "PhoenixM"] = 1;
		$ItemMax[%armor, "BooM"] = 1;
		$ItemMax[%armor, "NapM"] = 1;
		$ItemMax[%armor, "Hider"] = 1;
		$ItemMax[%armor, "GasM"] = 1;
		$ItemMax[%armor, "EmpM"] = 1;
		$ItemMax[%armor, "SpyPod"] = 1;
		$ItemMax[%armor, "TargetingLaser"] = 1;
		$ItemMax[%armor, "RepairKit"] = 1;
		$ItemMax[%armor, "flag"] = 1;

		if(%armor != jarmor && %armor != parmor )
		{
			$ItemMax[%armor,	AmmoPack] = 1;
			$ItemMax[%armor,	RepairPack] = 1;
			$ItemMax[%armor,	MotionSensorPack] = 1;
			$ItemMax[%armor,	SensorJammerPack] = 1;
			$ItemMax[%armor,	EnergyRifle] = 1;
			$ItemMax[%armor,	PulseSensorPack] = 1;
			$ItemMax[%armor,	EnergyPack] = 1;
			$ItemMax[%armor,	CameraPack] = 1;
			$ItemMax[%armor,	ShieldPack] = 1;
			$ItemMax[%armor,	StealthShieldPack] = 1;
			$ItemMax[%armor,	Disclauncher] = 1;
			$ItemMax[%armor,	DeployableSensorJammerPack] = 1;
			$ItemMax[%armor,	Blaster] = 1;
		}
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
	$ItemMax[aarmor, 	ArbitorBeaconPack] = 1;
	$ItemMax[aarmor, 	EMPBeaconPack] = 1;
	$ItemMax[aarmor, 	ShieldBeaconPack] = 1;
	$ItemMax[aarmor,	Beacon] = 3;
	$ItemMax[aarmor,	BulletAmmo] = 150;
	$ItemMax[aarmor,	ConCun] = 1;
	$ItemMax[aarmor,	DeployableAmmoPack] = 1;
	$ItemMax[aarmor,	DeployableElf] = 1;
	$ItemMax[aarmor,	DeployableInvPack] = 1;
	$ItemMax[aarmor,	DiscAmmo] = 25;
	$ItemMax[aarmor,	ForceFieldPack] = 1;
	$ItemMax[aarmor,	GravGun] = 1;
	$ItemMax[aarmor,	Grenade] = 5;
	$ItemMax[aarmor,	GrenadeAmmo] = 15;
	$ItemMax[aarmor,	HoloPack] = 1;
	$ItemMax[aarmor,	HyperB] = 1;
	$ItemMax[aarmor,	IonGun] = 1;
	$ItemMax[aarmor,	LargeForceFieldPack] = 1;
	$ItemMax[aarmor,	LargeShockForceFieldPack] = 1;
	$ItemMax[aarmor,	LightningPack] = 1;
	$ItemMax[aarmor,	MineAmmo] = 3;
	$ItemMax[aarmor,	PlasmaAmmo] = 40;
	$ItemMax[aarmor,	RailAmmo] = 10;
	$ItemMax[aarmor,	RegenerationPack] = 1;
	$ItemMax[aarmor,	TranqAmmo] = 20;
	$ItemMax[aarmor,	TurretPack] = 1;
	$ItemMax[aarmor,	Volter] = 1;
	$ItemMax[aarmor,	ShockPack] = 1;
	$ItemMax[aarmor,	ShockFloorPack] = 1;
	$ItemMax[aarmor,	SilencerAmmo] = 25;
	$ItemMax[aarmor,	AutoRocketAmmo] = 12;	
	$ItemMax[aarmor,	LaserRifle] = 1;
	$ItemMax[aarmor,	FlightPack] = 0;
	$ItemMax[aarmor,	Disclauncher] = 0;
	$ItemMax[aarmor,	CloakingDevice] = 0;
	CopyItemData(%max, aarmor, afemale);


//====================================================== Goliath
	$ItemMax[barmor,	AirAmmoPad] = 1;
	$ItemMax[barmor,	Beacon] = 6;
	$ItemMax[barmor,	CoolLauncher]=1;
	$ItemMax[barmor,	DeployableAmmoPack] = 1;
	$ItemMax[barmor,	DeployableComPack] = 1;
	$ItemMax[barmor,	DeployableInvPack] = 1;
	$ItemMax[barmor,	Flamer] = 1;
	$ItemMax[barmor,	ForceFieldPack] = 1;
	$ItemMax[barmor,	Grenade] = 8;
	$ItemMax[barmor,	GrenadeAmmo] = 25;
	$ItemMax[barmor,	GrenadeLauncher] = 1;
	$ItemMax[barmor,	HoloPack] = 1;
	$ItemMax[barmor,	MineAmmo] = 6;
	$ItemMax[barmor,	Mortar] = 1;
	$ItemMax[barmor,	MortarAmmo] = 8;
	$ItemMax[barmor,	PlasmaAmmo] = 70;
	$ItemMax[barmor,	PlasmaGun] = 1;
	$ItemMax[barmor,	RailAmmo] = 10;
	$ItemMax[barmor,	RocketAmmo] = 10;
	$ItemMax[barmor,	RocketLauncher] = 1;
	$ItemMax[barmor,	RocketPack] = 1;
	$ItemMax[barmor,	SuicidePack] = 1;
	$ItemMax[barmor,	SMRPack] = 1;
	$ItemMax[barmor,	AutoRocketAmmo] = 12;
	$ItemMax[barmor,	SilencerAmmo] = 25;
	$ItemMax[barmor,	DiscAmmo] = 25;
	$ItemMax[barmor,	TargetPack] = 1;
	$ItemMax[barmor,	Blaster] = 0;
	CopyItemData(%max, barmor, bfemale);

	//====================================================== Engineer
	$ItemMax[earmor, 	ArbitorBeaconPack] = 1;
	$ItemMax[earmor, 	EMPBeaconPack] = 1;
	$ItemMax[earmor, 	PowerGeneratorPack] = 1;
	$ItemMax[earmor, 	ShieldBeaconPack] = 1;
	$ItemMax[earmor,	AccelPPack] = 1;
	$ItemMax[earmor,	AirAmmoPad] = 1;
	$ItemMax[earmor,	AirBase] = 1;
	$ItemMax[earmor,	AutoRocketAmmo] = 10;
	$ItemMax[earmor,	Beacon] = 3;
	$ItemMax[earmor,	BlastFloorPack] = 1;
	$ItemMax[earmor,	BlastWallPack] = 1;
	$ItemMax[earmor,	BulletAmmo] = 150;
	$ItemMax[earmor,	Chaingun] = 1;
	$ItemMax[earmor,	CoolLauncher] = 1;
	$ItemMax[earmor,	DeployableAmmoPack] = 1;
	$ItemMax[earmor,	DeployableComPack] = 1;
	$ItemMax[earmor,	DeployableElf] = 1;
	$ItemMax[earmor,	DeployableInvPack] = 1;
	$ItemMax[earmor,	DiscAmmo] = 20;
	$ItemMax[earmor,	disit] = 1;
	$ItemMax[earmor,	EmplacementPack] = 1;
	$ItemMax[earmor,	Equalizer] = 1;	
	$ItemMax[earmor,	Fixit] = 1;
	$ItemMax[earmor,	ForceFieldPack] = 1;
	$ItemMax[earmor,	ShockFloorPack] = 1;
	$ItemMax[earmor,	GravGun] = 1;
	$ItemMax[earmor,	Grenade] = 6;
	$ItemMax[earmor,	GrenadeAmmo] = 20;
	$ItemMax[earmor,	GrenadeLauncher] = 1;
	$ItemMax[earmor,	Hackit] = 1;
	$ItemMax[earmor,	HoloPack] = 1;
	$ItemMax[earmor,	Laptop] = 1;
	$ItemMax[earmor,	LargeForceFieldPack] = 1;
	$ItemMax[earmor,	LargeShockForceFieldPack] = 1;
	$ItemMax[earmor,	LaserPack] = 1;
	$ItemMax[earmor,	LaunchPack] = 1;
	$ItemMax[earmor,	MineAmmo] = 3;
	$ItemMax[earmor,	PlantPack] = 1;	
	$ItemMax[earmor,	PlasmaAmmo] = 40;
	$ItemMax[earmor,	PlasmaGun] = 1;	
	$ItemMax[earmor,	PlasmaTurretPack] = 1;
	$ItemMax[earmor,	PlatformPack] = 1;
	$ItemMax[earmor,	RailAmmo] = 10;
	$ItemMax[earmor,	Railgun] = 1;
	$ItemMax[earmor,	RocketAmmo] = 5;
	$ItemMax[earmor,	RocketLauncher] = 1;
	$ItemMax[earmor,	RocketPack] = 1;
	$ItemMax[earmor,	ShockPack] = 1;
	$ItemMax[earmor,	TargetPack] = 1;
	$ItemMax[earmor,	TeleportPack] = 1;
	$ItemMax[earmor,	TranqAmmo] = 20;
	$ItemMax[earmor,	TreePack] = 1;
	$ItemMax[earmor,	TurretPack] = 1;
	$ItemMax[earmor,	VulcanAmmo] = 200;
	$ItemMax[earmor,	EngineerTurretPack] = 1;
	$ItemMax[earmor, 	BarragePack] = 1;
	$ItemMax[earmor, 	JammerBeaconPack] = 1;
	$ItemMax[earmor,	SilencerAmmo] = 25;
	CopyItemData(%max, earmor, efemale);

	//====================================================== Assassin
	$ItemMax[larmor, 	ArbitorBeaconPack] = 1;
	$ItemMax[larmor,	Beacon] = 5;
	$ItemMax[larmor,	BoomAmmo] = 10;
	$ItemMax[larmor,	BoomStick] = 1;
	$ItemMax[larmor,	DiscAmmo] = 20;
	$ItemMax[larmor,	ForceFieldPack] = 1;
	$ItemMax[larmor,	Grenade] = 3;
	$ItemMax[larmor,	GrenadeAmmo] = 15;
	$ItemMax[larmor,	GrenadeLauncher] = 1;
	$ItemMax[larmor,	HoloPack] = 1;
	$ItemMax[larmor,	LaserRifle] = 1;
	$ItemMax[larmor,	MineAmmo] = 3;
	$ItemMax[larmor,	PlasmaAmmo] = 30;
	$ItemMax[larmor,	PlasmaGun] = 1;
	$ItemMax[larmor,	RailAmmo] = 10;
	$ItemMax[larmor,	Railgun] = 1;
	$ItemMax[larmor,	SniperAmmo] = 25;
	$ItemMax[larmor,	SniperRifle] = 1;
	$ItemMax[larmor,	TranqAmmo] = 20;
	$ItemMax[larmor,	TranqGun] = 1;
	$ItemMax[larmor,	TreePack] = 1;
	$ItemMax[larmor,	Silencer] = 1;
	$ItemMax[larmor,	SilencerAmmo] = 20;
	$ItemMax[larmor,	ShieldPack] = 1;
	$ItemMax[larmor,	StealthShieldPack] = 1;
	CopyItemData(%max, larmor, lfemale);

	//====================================================== Mercinary
	$ItemMax[marmor,	Grenade] = 6;
	$ItemMax[marmor,	Beacon] = 4;//3;
	$ItemMax[marmor,	BoomAmmo] = 15;
	$ItemMax[marmor,	BoomStick] = 1;
	$ItemMax[marmor,	BulletAmmo] = 150;
	$ItemMax[marmor,	Chaingun] = 1;
	$ItemMax[marmor,	DeployableAmmoPack] = 1;
	$ItemMax[marmor,	DeployableInvPack] = 1;
	$ItemMax[marmor,	DiscAmmo] = 30;
	$ItemMax[marmor,	Equalizer] = 1;	
	$ItemMax[marmor,	ForceFieldPack] = 1;
	$ItemMax[marmor,	GrenadeAmmo] = 30;
	$ItemMax[marmor,	GrenadeLauncher] = 1;
	$ItemMax[marmor,	HoloPack] = 1;
	$ItemMax[marmor,	HyperB] = 1;
	$ItemMax[marmor,	MineAmmo] = 3;
	$ItemMax[marmor,	MortarAmmo] = 10;
	$ItemMax[marmor,	PlasmaAmmo] = 40;
	$ItemMax[marmor,	PlasmaGun] = 1;	
	$ItemMax[marmor,	RailAmmo] = 10;	
	$ItemMax[marmor,	RocketAmmo] = 10;
	$ItemMax[marmor,	RocketLauncher] = 1;
	$ItemMax[marmor,	TranqAmmo] = 20;
	$ItemMax[marmor,	TurretPack] = 1;
	$ItemMax[marmor,	Vulcan] = 1;
	$ItemMax[marmor,	VulcanAmmo] = 400;
	$ItemMax[marmor,	Silencer] = 1;
	$ItemMax[marmor,	SilencerAmmo] = 30;
	$ItemMax[marmor, 	BarragePack] = 1;
	$ItemMax[marmor, 	Booster1Pack] = 1;
	$ItemMax[marmor, 	Booster2Pack] = 1;
	$ItemMax[marmor,	AutoRocketAmmo] = 15;
	$ItemMax[marmor,	RocketPack] = 1;
	CopyItemData(%max, marmor, mfemale);

	//====================================================== Scout
	$ItemMax[sarmor,	Beacon] = 3;
	$ItemMax[sarmor,	BoomAmmo] = 10;
	$ItemMax[sarmor,	BoomStick] = 1;
	$ItemMax[sarmor,	BulletAmmo] = 50;
	$ItemMax[sarmor,	Chaingun] = 1;
	$ItemMax[sarmor,	DiscAmmo] = 15;
	$ItemMax[sarmor,	FlightPack] = 1;
	$ItemMax[sarmor,	ForceFieldPack] = 1;
	$ItemMax[sarmor,	Grenade] = 5;
	$ItemMax[sarmor,	GrenadeAmmo] = 15;
	$ItemMax[sarmor,	GrenadeLauncher] = 1;
	$ItemMax[sarmor,	HoloPack] = 1;
	$ItemMax[sarmor,	HyperB] = 1;
	$ItemMax[sarmor,	Laptop] = 1;
	$ItemMax[sarmor,	LaserRifle] = 1;
	$ItemMax[sarmor,	MechPack] = 1;
	$ItemMax[sarmor,	MineAmmo] = 3;
	$ItemMax[sarmor,	PlasmaAmmo] = 30;
	$ItemMax[sarmor,	PlasmaGun] = 1;
	$ItemMax[sarmor,	RailAmmo] = 10;
	$ItemMax[sarmor,	TranqAmmo] = 15;
	$ItemMax[sarmor,	SilencerAmmo] = 25;
	CopyItemData(%max, sarmor, sfemale);
	CopyItemData(%max, sarmor, stimarmor);
	CopyItemData(%max, sarmor, stimfemale);

	//====================================================== Chemeleon
	$ItemMax[spyarmor,	Beacon] = 3;
	$ItemMax[spyarmor,	BoomAmmo] = 10;
	$ItemMax[spyarmor,	BoomStick] = 1;
	$ItemMax[spyarmor,	BulletAmmo] = 75;
	$ItemMax[spyarmor,	Chaingun] = 1;
	$ItemMax[spyarmor,	CloakingDevice] = 1;
	$ItemMax[spyarmor,	DiscAmmo] = 20;
	$ItemMax[spyarmor,	Equalizer] = 1;
	$ItemMax[spyarmor,	FlightPack] = 1;
	$ItemMax[spyarmor,	ForceFieldPack] = 1;
	$ItemMax[spyarmor,	Grenade] = 3;
	$ItemMax[spyarmor,	GrenadeAmmo] = 20;
	$ItemMax[spyarmor,	GrenadeLauncher] = 1;
	$ItemMax[spyarmor,	HoloPack] = 1;
	$ItemMax[spyarmor,	Laptop] = 1;
	$ItemMax[spyarmor,	LaserPack] = 1;
	$ItemMax[spyarmor,	LaserRifle] = 1;
	$ItemMax[spyarmor,	MineAmmo] = 3;
	$ItemMax[spyarmor,	PlasmaAmmo] = 30;
	$ItemMax[spyarmor,	PlasmaGun] = 1;
	$ItemMax[spyarmor,	RailAmmo] = 10;
	$ItemMax[spyarmor,	Silencer] = 1;
	$ItemMax[spyarmor,	SilencerAmmo] = 25;
	$ItemMax[spyarmor,	TranqAmmo] = 25;
	$ItemMax[spyarmor,	TranqGun] = 1;
	CopyItemData(%max, spyarmor, spyfemale);

//========================================================= Dreadnaught
	$ItemMax[darmor,	AirAmmoPad] = 1;
	$ItemMax[darmor,	AutoRocketAmmo] = 20;
	$ItemMax[darmor,	Beacon] = 3;
	$ItemMax[darmor,	BulletAmmo] = 150;
	$ItemMax[darmor,	Chaingun] = 1;
	$ItemMax[darmor,	ConCun] = 1;
	$ItemMax[darmor,	DeployableAmmoPack] = 1;
	$ItemMax[darmor,	DeployableComPack] = 1;
	$ItemMax[darmor,	DeployableInvPack] = 1;
	$ItemMax[darmor,	DiscAmmo] = 25;
	$ItemMax[darmor,	Equalizer] = 1;
	$ItemMax[darmor,	ForceFieldPack] = 1;
	$ItemMax[darmor,	Grenade] = 3;
	$ItemMax[darmor,	GrenadeAmmo] = 25;
	$ItemMax[darmor,	GrenadeLauncher] = 1;
	$ItemMax[darmor,	HoloPack] = 1;
	$ItemMax[darmor,	MineAmmo] = 5;
	$ItemMax[darmor,	Mortar] = 1;
	$ItemMax[darmor,	MortarAmmo] = 10;
	$ItemMax[darmor,	PlasmaAmmo] = 50;
	$ItemMax[darmor,	PlasmaGun] = 1;
	$ItemMax[darmor,	PlasmaTurretPack] = 1;
	$ItemMax[darmor,	RailAmmo] = 10;
	$ItemMax[darmor,	RocketAmmo] = 15;
	$ItemMax[darmor,	RocketLauncher] = 1;
	$ItemMax[darmor,	SMRPack] = 1;
	$ItemMax[darmor,	TranqAmmo] = 20;
	$ItemMax[darmor,	TurretPack] = 1;
	$ItemMax[darmor,	Vulcan] = 1;
	$ItemMax[darmor,	VulcanAmmo] = 400;
	$ItemMax[darmor, 	BarragePack] = 1;
	$ItemMax[darmor, 	ShockFloorPack] = 1;
	$ItemMax[darmor,	SilencerAmmo] = 25;
	CopyItemData(%max, darmor, harmor);

	//====================================================== Juggernaught
	$ItemMax[jarmor,	AutoRocketAmmo] = 20;
	$ItemMax[jarmor,	Beacon] = 5;
	$ItemMax[jarmor,	LasCannon] = 1;
	$ItemMax[jarmor,	Mfgl] = 1;
	$ItemMax[jarmor,	MfglAmmo] = 4;
	$ItemMax[jarmor,	Mortar] = 1;
	$ItemMax[jarmor,	MortarAmmo] = 25;
	$ItemMax[jarmor,	RocketAmmo] = 25;
	$ItemMax[jarmor,	RocketLauncher] = 1;
	$ItemMax[jarmor,	SMRPack2] = 1;
	$ItemMax[jarmor, 	PlasmaCannon] = 1;
	$ItemMax[jarmor,	Hammer1Pack] = 1;
	$ItemMax[jarmor,	Hammer2Pack] = 1;
	$ItemMax[jarmor,	HammerAmmo] = 150;

	//====================================================== Cursed
	$ItemMax[parmor,	Penis] = 1;
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
PlayerData parmor
{
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
	mass = 50.0;
	groundTraction = 13.0;
	maxEnergy = 160;
	drag = 15.0;
	density = 1.2;
	minDamageSpeed = 25;
	damageScale = 0.005;
	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2;

	animData[0] = { "root", none, 1, true, true, true, false, 0 }; animData[1] = { "run", none, 1, true, false, true, false, 3 }; animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 };

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

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.4;
	maxJetForwardVelocity = 7;
	minJetEnergy = 1;
	jetForce = 390;
	jetEnergyDrain = 1.5;

	maxDamage = 2.0;

	maxForwardSpeed = 5.0;
	maxBackwardSpeed = 4.0;
	maxSideSpeed = 4.0;

	groundForce = 35 * 22.0;
	groundTraction = 4.5;

	mass = 18.5;
	maxEnergy = 150;

	drag = 3.0;
	density = 2.5;
//   horzVelClamp = 3;
	canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetHeavy; rFootSounds = { SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSnow, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft };  lFootSounds = { SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSnow, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft }; footPrints = { 4, 5 };

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
	shapeFile = "larmor";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;

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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetLight; rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };  lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };

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
	shapeFile = "marmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	canCrouch = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 1.0;
	maxDamage = 1.3; //badfem 1.2
	maxForwardSpeed = 10.0; //9.0;  //fem 10.0
	maxBackwardSpeed = 8.0; //7.0; //fem 8.0
	maxSideSpeed = 8.0; //7.0; //fem 8.0
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
	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetLight; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };  lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };

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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetHeavy;

	rFootSounds = { SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSnow, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft }; 
	lFootSounds = { SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSnow, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft };

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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetLight;

	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };

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

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 1.0;

	canCrouch = false;
	maxDamage = 1.3;
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
	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; jetSound = SoundJetLight; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };  lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; footPrints = { 2, 3 };

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
	shapeFile = "larmor";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 1.0; //0.9; //fem 1.0
	maxJetForwardVelocity = 25; //22; //fem 25
	minJetEnergy = 1;
	jetForce = 245;
	jetEnergyDrain = 0.8;

	maxDamage = 0.80;
	maxForwardSpeed = 13;// 12; //fem 13
	maxBackwardSpeed = 13;//12; //fem 13
	maxSideSpeed = 13; // 12; //fem 13
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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetLight; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };  lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };

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
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	maxJetSideForceFactor = 1.2;
	maxJetForwardVelocity = 35;
	minJetEnergy = 1;
	jetForce = 375;
	jetEnergyDrain = 0.8;
	maxDamage = 0.8;
	maxForwardSpeed = 18;
	maxBackwardSpeed = 18;
	maxSideSpeed = 18;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 120;
	drag = 0.7;
	density = 2.2;
	minDamageSpeed = 25;
	damageScale = 0.005;
	jumpImpulse = 155;
	jumpSurfaceMinDot = 0.2;
	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetLight; lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 

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

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;

	maxJetSideForceFactor = 1.3;
	maxJetForwardVelocity = 35; //26; //fem 35
	minJetEnergy = 1;
	jetForce = 375; //350; //fem 375
	jetEnergyDrain = 0.8;

	maxDamage = 0.80; //badfem 0.75
	maxForwardSpeed = 18;
	maxBackwardSpeed = 18;
	maxSideSpeed = 18;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 120; //badfem 110
	drag = 0.7; //0.8; //fem 0.7
	density = 2.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

	jumpImpulse = 145;
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetLight; lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 

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
	maxBackwardSpeed = 8.5; //7.5; //fem 8.5
	maxSideSpeed = 8.5; //7.5; //fem 8.5
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;
	maxEnergy = 110;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 25;
	damageScale = 0.005;
	jumpImpulse = 125; //110; //fem 125
	jumpSurfaceMinDot = 0.2;


	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetLight; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };  lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };

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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetLight; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };  lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };

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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };

	jetSound = SoundJetHeavy;

	rFootSounds = { SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSnow, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft }; 
	lFootSounds = { SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSnow, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft };

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

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

	canCrouch = true;
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 25;
	minJetEnergy = 1;
	jetForce = 245;
	jetEnergyDrain = 0.8;

	maxDamage = 0.8;
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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };

	jetSound = SoundJetLight;

	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };

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
// light armor data: *Chemeleon
//------------------------------------------------------------------


PlayerData spyarmor
{
	className = "Armor";
	shapeFile = "larmor";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 36;//22;
	minJetEnergy = 1;
	jetForce = 270; //badfem 260
	jetEnergyDrain = 0.8;
	maxDamage = 0.80;
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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; jetSound = SoundJetLight; lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };  animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; footPrints = { 0, 1 };

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
	visibleToSensor = false;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 36;//22;
	minJetEnergy = 1;
	jetForce = 270;
	jetEnergyDrain = 0.8;
	maxDamage = 0.80;
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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; footPrints = { 0, 1 }; jetSound = SoundJetLight; lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };  animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };

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
// Medium Armor data: Engineer
//------------------------------------------------------------------

PlayerData earmor
{
	className = "Armor";
	shapeFile = "marmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
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
	maxBackwardSpeed = 8.5; //7.5; //fem 8.5
	maxSideSpeed = 8.0; //7.5; //fem 8.0
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;
	maxEnergy = 110;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 25;
	damageScale = 0.005;
	jumpImpulse = 125; //110; //fem 125
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; footPrints = { 2, 3 }; jetSound = SoundJetLight; lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 

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

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
	jetSound = SoundJetLight;

	rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
	lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };

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
	shadowDetailMask = 0;
	canCrouch = false;
	visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
	maxJetSideForceFactor = 1.2; //1.0; //fem 1.2
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 0.8; //1.0; //fem 0.8
	maxDamage = 1.0; //badfem 0.9
	maxForwardSpeed = 11.0; //fem 11.0
	maxBackwardSpeed = 9.0;
	maxSideSpeed = 9.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.4; //badfem 3.5
	maxEnergy = 140;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 25;
	damageScale = 0.005;
	jumpImpulse = 125; //110; //fem 125
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	jetSound = SoundJetLight;

	rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
	lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };

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
	shadowDetailMask = 0;
	visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
	maxJetSideForceFactor = 1.2;
	maxJetForwardVelocity = 17;
	minJetEnergy = 1;
	jetForce = 325;
	jetEnergyDrain = 0.8;
	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 11.0;
	maxBackwardSpeed = 10.0;
	maxSideSpeed = 9.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.4;
	maxEnergy = 140;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;
	minDamageSpeed = 25;
	damageScale = 0.005;
	jumpImpulse = 125;
	jumpSurfaceMinDot = 0.2;

	animData[0]  = { "root", none, 1, true, true, true, false, 0 }; animData[1]  = { "run", none, 1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14]  = { "fall", none, 1, true, true, true, false, 3 }; animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[2]  = { "runback", none, 1, true, false, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[3]  = { "side left", none, 1, true, false, true, false, 3 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[4]  = { "side left", none, -1, true, false, true, false, 3 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; jetSound = SoundJetLight;

	rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
	lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };

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



