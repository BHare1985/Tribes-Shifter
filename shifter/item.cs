//----------------------------------------------------------------------------
$ItemFavoritesKey = "shifter1";  // Change this if you add new items
$ItemPopTime = 30;
$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$ArmorType[Male, LightArmor] = larmor;		$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Male, MediumArmor] = marmor;		$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Male, HeavyArmor] = harmor;		$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Male, ScoutArmor] = sarmor;		$ArmorType[Female, ScoutArmor] = sfemale;
$ArmorType[Male, BursterArmor] = barmor;	$ArmorType[Female, BursterArmor] = bfemale;
$ArmorType[Male, EngArmor] = earmor;		$ArmorType[Female, EngArmor] = efemale;
$ArmorType[Male, DragArmor] = darmor;		$ArmorType[Female, DragArmor] = darmor;
$ArmorType[Male, SpArmor] = spyarmor;		$ArmorType[Female, SpArmor] = spyfemale;
$ArmorType[Male, AlArmor] = aarmor;		$ArmorType[Female, AlArmor] = afemale;
$ArmorType[Male, Juggernaught] = jarmor;	$ArmorType[Female, Juggernaught] = jarmor;

$ArmorName[sarmor] = ScoutArmor;
$ArmorName[sfemale] = ScoutArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[barmor] = BursterArmor;
$ArmorName[bfemale] = BursterArmor;
$ArmorName[spyarmor] = SpArmor;
$ArmorName[spyfemale] = SpArmor;
$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;
$ArmorName[aarmor] = AlArmor;
$ArmorName[afemale] = AlArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[darmor] = DragArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[jarmor] = Juggernaught;

// Amount to remove when selling or dropping ammo

$SellAmmo[AutoRocketAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[BoomAmmo] = 5;
$SellAmmo[Boost] = 5;
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[DetBug] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MfglAmmo] = 1;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[Plastique] = 5;
$SellAmmo[RailAmmo] = 25;
$SellAmmo[HammerAmmo] = 50;
$SellAmmo[RocketAmmo] = 3;
$SellAmmo[SilencerAmmo] = 25;
$SellAmmo[SniperAmmo] = 25;
$SellAmmo[TranqAmmo] = 2;
$SellAmmo[VulcanAmmo] = 100;

// Max Amount of ammo the Ammo Pack can carry

$AmmoPackMax[Beacon] = 3;
$AmmoPackMax[BoomAmmo] = 15;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[Grenade] = 5;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MfglAmmo] = 0;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[RailAmmo] = 5;
$AmmoPackMax[RocketAmmo] = 10;
$AmmoPackMax[SniperAmmo] = 15;
$AmmoPackMax[SilencerAmmo] = 15;
$AmmoPackMax[TranqAmmo] = 20;
$AmmoPackMax[VulcanAmmo] = 400;

$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = BoomAmmo;
$AmmoPackItems[9] = RocketAmmo;
$AmmoPackItems[10] = RailAmmo;
$AmmoPackItems[11] = VulcanAmmo;
$AmmoPackItems[12] = TranqAmmo;
$AmmoPackItems[13] = Plastique;
$AmmoPackItems[14] = SniperAmmo;
$AmmoPackItems[15] = SilencerAmmo;

DamageSkinData objectDamageSkins
{
	bmpName[0] = "dobj1_object";
	bmpName[1] = "dobj2_object";
	bmpName[2] = "dobj3_object";
	bmpName[3] = "dobj4_object";
	bmpName[4] = "dobj5_object";
	bmpName[5] = "dobj6_object";
	bmpName[6] = "dobj7_object";
	bmpName[7] = "dobj8_object";
	bmpName[8] = "dobj9_object";
	bmpName[9] = "dobj10_object";
};

$Use[Blaster] = True;
$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = False;
$AutoUse[PlasmaGun] = False;
$AutoUse[Mortar] = False;
$AutoUse[Mortar0] = False;
$AutoUse[Mortar1] = False;
$AutoUse[Mortar2] = False;
$AutoUse[GrenadeLauncher] = False;
$AutoUse[LaserRifle] = False;
$AutoUse[EnergyRifle] = False;
$AutoUse[TargetingLaser] = False;
$AutoUse[Fixit] = False;
$AutoUse[ChargeGun] = False;
$AutoUse[CloakGun] = False;
$AutoUse[RocketLauncher] = False;
$AutoUse[BoomStick] = False;
$AutoUse[SniperRifle] = False;
$AutoUse[ConCun] = False;
$AutoUse[Railgun] = False;
$AutoUse[Mfgl] = False;
$AutoUse[Vulcan] = False;
$AutoUse[Silencer] = False;
$AutoUse[IonGun] = False;
$AutoUse[TranqGun] = False;
$AutoUse[HyperB] = False;
$AutoUse[Volter] = False;

//==================================================================== Limit on number of special Items you can buy
//==================================================== Dynamic Limits
if ($Shifter::DetPackLimit == "")
{
	$Shifter::DetPackLimit = "15";
}
if ($Shifter::NukeLimit == "")
{
	$Shifter::NukeLimit = "15";
}


$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;

//==================================================== Standard Limits.
$TeamItemMax[AccelPPack] = 5;
$TeamItemMax[AirAmmoPad] = 4;
$TeamItemMax[airbase] = 3;
$TeamItemMax[ArbitorBeaconPack] = 1;
$TeamItemMax[Beacon] = 100;
$TeamItemMax[BlastFloorPack] = 6;
$TeamItemMax[BlastWallPack] = 6;
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableComPack] = 5;
$TeamItemMax[DeployableElf] = 5;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[DeployableSensorJammerPack] = 15;
$TeamItemMax[DeployableTeleport] = 4;
$TeamItemMax[EMPBeaconPack] = 2;
$TeamItemMax[ShieldBeaconPack] = 4;
$TeamItemMax[EmplacementPack] = 2;
$TeamItemMax[EngBeacons] = 10;
$TeamItemMax[ForceFieldPack] = 10;
$TeamItemMax[HAPCVehicle] = 3;
$TeamItemMax[hologram] = 10;
$TeamItemMax[JetVehicle] = 5;
$TeamItemMax[LAPCVehicle] = 3;
$TeamItemMax[LargeForceFieldPack] = 6;
$TeamItemMax[LargeShockForceFieldPack] = 3;
$TeamItemMax[LaserPack] = 4;
$TeamItemMax[LaunchPack] = 10;
$TeamItemMax[Mfgl] = 1;
$TeamItemMax[mineammo] = 140;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[MechPack] = 15;
$TeamItemMax[OriginalReplicatingMine] = 30;
$TeamItemMax[PlantPack] = 3;
$TeamItemMax[PlasmaTurretPack] = 4;
$TeamItemMax[PlatformPack] = 25;
$TeamItemMax[ProxMine] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[ReplicatingMine] = 30;
$TeamItemMax[RocketPack] = 4;
$TeamItemMax[SatchelPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[ShockPack] = 4;
$TeamItemMax[TargetPack] = 2;
$TeamItemMax[TeleportPack] = 4;
$TeamItemMax[TeleBeacons] = 10;
$TeamItemMax[TreePack] = 10;
$TeamItemMax[TurretPack] = 5;
$TeamItemMax[WraithVehicle] = 2;
$TeamItemMax[PowerGeneratorPack] = 1;
$TeamItemMax[BarragePack] = 3;
$TeamItemMax[JammerBeaconPack] = 2;
$TeamItemMax[ShockFloorPack] = 4;
$TeamItemMax[FlamerTurretPack] = 3;
//=========================================================================== Missile Limits

if ($Shifter::Missile_EMP){$TeamItemMax[EmpM] 		= $Shifter::Missile_EMP;}else{$TeamItemMax[EmpM] = 25; }
if ($Shifter::Missile_GAS){$TeamItemMax[GasM] 		= $Shifter::Missile_GAS;}else{$TeamItemMax[GasM] = 25; }
if ($Shifter::Missile_PHE){$TeamItemMax[PhoenixM] 	= $Shifter::Missile_PHE;}else{$TeamItemMax[PhoenixM] = 35; }
if ($Shifter::Missile_NAP){$TeamItemMax[NapM] 		= $Shifter::Missile_NAP;}else{$TeamItemMax[NapM] = 15; }
if ($Shifter::Missile_BOM){$TeamItemMax[BooM] 		= $Shifter::Missile_BOM;}else{$TeamItemMax[BooM] = 15; }
if ($Shifter::Missile_SPY){$TeamItemMax[SpyPod] 	= $Shifter::Missile_SPY;}else{$TeamItemMax[SpyPod] = 100; }

//=========================================================================== Weapons And Ammo
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[Mortar0] = MortarAmmo;
$WeaponAmmo[Mortar1] = MortarAmmo;
$WeaponAmmo[Mortar2] = MortarAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[GravGun] = "";
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[Railgun] = RailAmmo;
$WeaponAmmo[ConCun] = "";
$WeaponAmmo[IonGun] = "";
$WeaponAmmo[Flamer] = "";
$WeaponAmmo[Volter] = "";
$WeaponAmmo[Silencer] = SilencerAmmo;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$WeaponAmmo[Mfgl] = MfglAmmo;
$WeaponAmmo[TranqGun] = TranqAmmo;
$WeaponAmmo[SMRPack] = AutoRocketAmmo;
$WeaponAmmo[SMRPack2] = AutoRocketAmmo;
$WeaponAmmo[BoomStick] = BoomAmmo;
$WeaponAmmo[Hammer1Pack] = HammerAmmo;
$WeaponAmmo[Hammer2Pack] = HammerAmmo;
$WeaponAmmo[Booster1Pack] = "";
$WeaponAmmo[Booster2Pack] = "";

//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
	{
		%station.Energy += %cost;
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") { 
		$TeamEnergy[%team] += %cost;
 		%client.teamEnergy += %cost;
	}
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	$SpawnFav = "True";
	if (isPlayerBusy(%client))
		return;

   	%time = getIntegerTime(true) >> 4;
   	if(%time <= %client.lastBuyFavTime)
   	   	return;

   	%client.lastBuyFavTime = %time;

	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead) { return; }

	//echo ("Buy Faves");

	for (%i = 0; %i <= 19; %i++)
	{
		%client.fav[%i] = "";
		$spawnBuyList[%i, %client] = "";
	}

	if ($SpawnFav && %client.spawntype == "favs" || %client.spawntype == "saved")
	{
		%client.favsettings = "True";
		%client.spawntype = "favs";

		if (%favItem0)  {%client.fav0 = %favItem0;	  $spawnBuyList[0, %client] = getItemData(%favItem0); }
		if (%favItem1)  {%client.fav1 = %favItem1;	  $spawnBuyList[1, %client] = getItemData(%favItem1); }
	   	if (%favItem2)  {%client.fav2 = %favItem2;	  $spawnBuyList[2, %client] = getItemData(%favItem2); }
	   	if (%favItem3)  {%client.fav3 = %favItem3;	  $spawnBuyList[3, %client] = getItemData(%favItem3); }
	   	if (%favItem4)  {%client.fav4 = %favItem4;	  $spawnBuyList[4, %client] = getItemData(%favItem4); }
	   	if (%favItem5)  {%client.fav5 = %favItem5;	  $spawnBuyList[5, %client] = getItemData(%favItem5); }
	   	if (%favItem6)  {%client.fav6 = %favItem6;	  $spawnBuyList[6, %client] = getItemData(%favItem6); }
	   	if (%favItem7)  {%client.fav7 = %favItem7;	  $spawnBuyList[7, %client] = getItemData(%favItem7); }
	   	if (%favItem8)  {%client.fav8 = %favItem8;	  $spawnBuyList[8, %client] = getItemData(%favItem8); }
	   	if (%favItem9)  {%client.fav9 = %favItem9;	  $spawnBuyList[9, %client] = getItemData(%favItem9); }
	   	if (%favItem10) {%client.fav10 = %favItem10;	  $spawnBuyList[10, %client] = getItemData(%favItem10);}
	   	if (%favItem11) {%client.fav11 = %favItem11;	  $spawnBuyList[11, %client] = getItemData(%favItem11);}
	   	if (%favItem12) {%client.fav12 = %favItem12;	  $spawnBuyList[12, %client] = getItemData(%favItem12);}
	   	if (%favItem13) {%client.fav13 = %favItem13;	  $spawnBuyList[13, %client] = getItemData(%favItem13);}
	   	if (%favItem14) {%client.fav14 = %favItem14;	  $spawnBuyList[14, %client] = getItemData(%favItem14);}
	   	if (%favItem15) {%client.fav15 = %favItem15;	  $spawnBuyList[15, %client] = getItemData(%favItem15);}
	   	if (%favItem16) {%client.fav16 = %favItem16;	  $spawnBuyList[16, %client] = getItemData(%favItem16);}
	   	if (%favItem17) {%client.fav17 = %favItem17;	  $spawnBuyList[17, %client] = getItemData(%favItem17);}
	   	if (%favItem18) {%client.fav18 = %favItem18;	  $spawnBuyList[18, %client] = getItemData(%favItem18);}
	   	if (%favItem19) {%client.fav19 = %favItem19;	  $spawnBuyList[19, %client] = getItemData(%favItem19);}
   	}


	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" )
	{
		%stationName = GameBase::getDataName(%station); 
		
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
			%energy = %station.Energy;
		else 
			%energy = $TeamEnergy[Client::getTeam(%client)];
		
		
		if(%energy == "Infinite" || %energy > 0)
		{
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			
			for (%i = 1; %i < %max; %i++)
			{
				%item = getItemData(%i);
				if (Client::isItemShoppingOn(%client,%item))
				{
					%count = Player::getItemCount(%client,%item);
					if(%count)
					{
						if(%item.className != Armor)
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			
			for (%i = 0; %i < 20; %i++)
			{ 
				if(%favItem[%i] != "")
				{
					%item = getItemData(%favItem[%i]);
					
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor))
					{
						if(!buyItem(%client,%item))  
							%error = 1;
						else
							%bought++;
					}
				}
		  	}
		  	
			if(%bought)
			{
				if(%error) 
					Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else 
					Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}

function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}

//==========================================================================================================Check Max Drop from Bitchin1.3
function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	
	if (%numweapon > $MaxWeapons[%armor])
	{
		%weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	
	%max = getNumItems();
	for (%i = 1; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		
		if(%maxnum != "" && %item.className != Armor)
		{
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum)
			{
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0)
			{
		    		Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			} 
		}
	}
}

//======================================================================================================= Armor Change Drop from Bitchin1.3
function armorChange(%client) 
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "")
	{
		%sPos = GameBase::getPosition(%player.Station);
		%pPos = GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);
		%newPosX = (getWord(%vec,0) * 1) + %posX;
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
	}
}

function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "")
	{
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	if(%client.spawn == "")
	{
		%energy = $TeamEnergy[%team];
    		%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
		{
			%energy = %station.Energy;

		}
		if(%energy != "Infinite")
		{
			if (%item.price * %delta > %energy)	
				%delta = %energy / %item.price; 
			if(%delta < 1 )
			{
				if(%noMessage == "")
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}
	if(%item.className == Weapon)
	{
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");
		
		%count = Player::getItemClassCount(%client,"Weapon");
		if (%count >= $MaxWeapons[%armor])
		{
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}
	else if(%item == RepairPatch)
	{
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0)
			return 1;
		return 0;
   	}
   	else if($TeamItemMax[%item] != "")
   	{
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item])
		{
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	if(%item.className != Armor && %item.className != Vehicle)
	{
	   	%count = Player::getItemCount(%client,%item);
	   	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
	   	if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function isPlayerBusy(%client)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	%team = GameBase::GetTeam(%client);

	if (%armor == "parmor")
		return;

	if ((Client::isItemShoppingOn(%client,%item) || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle))
	{
		%time = getIntegerTime(true) >> 4;
		//echo ("buying item " @ %item @ " - " @ %time);
		if (($TeamItemCount[%team @ %item] > $TeamItemMax[%item] || $TeamItemCount[%team @ %item] == $TeamItemMax[%item]) && $TeamItemCount[%team @ %item] != "")
		{
		        Client::sendMessage(%client,1,"Could not purchace " @ %item.description @ ", Limit Of " @ $TeamItemMax[%item] @ ".");
			bottomprint(%client, "<jc><f2>Could not purchace " @ %item.description @ ", Limit Of " @ $TeamItemMax[%item] @ ".", 5);		
			dbecho ("Could not purchase " @ %item);
			return;
		}

		//=================================================== Assign armor by requested type & gender 

		if (%item.className == Armor)
		{
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
			{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);

				if(checkResources(%player,%item,1))
				{
					Player::setItemCount(%client, SMRPack2,0);
					Player::setItemCount(%client, PlasmaCannon,0);
					Player::setItemCount(%client, LasCannon,0);
					Player::setItemCount(%client, Hammer2Pack,0);
					Player::setItemCount(%client, Hammer1Pack,0);

					%client.heatup = "0";
					%client.heatlock = "0";
					%client.plasmacharge = "0";
					%client.charging = "0";
					%client.lascharge = "0";

					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);					
					checkMax(%client,%buyarmor);
					armorChange(%client);
     					
     					Player::setItemCount(%client, $ArmorName[%armor], 0);  
     					Player::setItemCount(%client, %item, 1);

					if (%buyarmor == "marmor" || %buyarmor == "mfemale")
					{
						Player::setItemCount	(%client, Booster1Pack,1);
						Player::setItemCount	(%client, Booster2Pack,1);
						schedule ("Player::mountItem( " @ %client @ ", Booster1Pack,4);",0.3);
						schedule ("Player::mountItem( " @ %client @ ", Booster2Pack,5);",0.3);
					}
					else if (%buyarmor != "marmor" || %buyarmor != "mfemale")
					{
						Player::unMountItem(%client,4);
						Player::unMountItem(%client,5);
					}



					if (%buyarmor == "jarmor") //================================================== Check Juggernaught   
					{
						checkMax(%client,%armor);
						//========================================================= Set Weapons
						Player::setItemCount(%client, Juggernaught, 1);
						Player::setItemCount(%client, RocketLauncher, 1);
						Player::setItemCount(%client, Mortar,1);
						Player::setItemCount(%client, RocketAmmo,25);
						Player::setItemCount(%client, SMRPack2,1);
						Player::setItemCount(%client, AutoRocketAmmo,25);
						Player::setItemCount(%client, MortarAmmo,20);

						//========================================================= Mount Items
						Player::mountItem(%client, RocketLauncher, $WeaponSlot);
						Player::mountItem(%client, SMRPack2, $BackPackSlot);
					}
					else
					{
						Player::unMountItem(%client,4);
						Player::unMountItem(%client,5);
					}

					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
					
					if ($Shifter::ItemLimit && %client.invo)
					{
						setupShoppingList(%client,%client.invo,%client.ListType);
					}	
					return 1;
				}
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		//================================================================================ Finish Buy
		else if (%item.className == VModule)
		{
			teamEnergyBuySell(%player,%item.price);
			Player::setItemCount(%client,NapalmModule, 0);
			Player::setItemCount(%client,HellFireModule, 0);
			Player::setItemCount(%client,DetPackModule, 0);
			Player::setItemCount(%client,BomberModule, 0);
			Player::setItemCount(%client,PickUpModule, 0);
			Player::setItemCount(%client,MineNetModule, 0);
			Player::setItemCount(%client,StealthModule, 0);
			Player::setItemCount(%client,WraithModule, 0);
			Player::setItemCount(%client,InterceptorModule, 0);
			Player::setItemCount(%client,GodHammerModule, 0);
			Player::setItemCount(%client,ValkyrieModule, 0);
			
			teamEnergyBuySell(%player,%item.price * -1);
			Player::incItemCount(%client,%item);
			return 1;			
		}
		else if (%item.className == Backpack)
		{
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1)
			{
				if(%pack == ammopack)
				{
					checkMax(%client,%armor);
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   

			%ammoItem = %item.imageType.ammoType;
			
			if(%ammoItem != "")
			{
				%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
				if(%delta)
				{
					teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
					Player::incItemCount(%client,%ammoitem,%delta);
				}
			}
			
			if (checkResources(%player,%item,1))
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1)
			{
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon)
		{
			if(checkResources(%player,%item,1))
			{

				//====================== AutoBuy Containment Pack
				if(%item == Mfgl && Player::getItemCount(%client,"FgcPack") == 0)
				{
					buyItem(%client,"FgcPack");
					Client::sendMessage(%client,0,"Bought Tactical Nuke - Auto buying Containment Pack");
				}

				if (%armor == jarmor)
				{
					if(%item == "SMRPack2")
					{
						Player::setItemCount(%client, Hammer1Pack,0);
						Player::setItemCount(%client, Hammer2Pack,0);
						Player::setItemCount(%client, HammerAmmo,0);
					}
					if(%item == "Mfgl")
					{
						Player::setItemCount(%client, LasCannon,0);
						Player::setItemCount(%client, PlasmaCannon,0);
						Player::setItemCount(%client, Hammer1Pack,0);
						Player::setItemCount(%client, Hammer2Pack,0);
					}
					if(%item == "PlasmaCannon")
					{
						Player::setItemCount(%client, Mfgl,0);
						Player::setItemCount(%client, MfglAmmo,0);
						Player::setItemCount(%client, LasCannon,0);
						Player::setItemCount(%client, Hammer1Pack,0);
						Player::setItemCount(%client, Hammer2Pack,0);
					}		
					if(%item == "LasCannon")
					{
						//echo ("Las Cannon");
						Player::setItemCount(%client, Mfgl,0);
						Player::setItemCount(%client, MfglAmmo,0);
						Player::setItemCount(%client, PlasmaCannon,0);
						Player::setItemCount(%client, Hammer1Pack,0);
						Player::setItemCount(%client, Hammer2Pack,0);
					}
					if(%item == "Hammer1Pack")
					{
						Player::setItemCount(%client, Mfgl,0);
						Player::setItemCount(%client, SMRPack2,0);
						Player::setItemCount(%client, MfglAmmo,0);
						Player::setItemCount(%client, PlasmaCannon,0);
						Player::setItemCount(%client, LasCannon,0);
						Player::setItemCount(%client, Hammer2Pack,1);
						Player::mountItem(%client, Hammer1Pack, 4);
						Player::mountItem(%client, Hammer2Pack, 5);
					}
				}

				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				
				%ammoItem = %item.imageType.ammoType;
				dbecho ("Ammo Item " @ %ammoItem);
				
				if ($TeamItemMax[%ammoItem] && $TeamItemMax[%ammoItem] != 0)
				{
					if ($TeamItemCount[GameBase::getTeam(%client) @ %ammoItem] < $TeamItemMax[%ammoItem])
					{
						if(%ammoItem != "")
						{
							%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
							if(%delta)
							{
								teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
								Player::incItemCount(%client,%ammoitem,%delta);
							}
						}
						return 1;				
					}
					else
					{
						Client::sendMessage(%client,1,"Could Not Purchace Ammo. Limit Exceeded");
					}
				}
				else
				{
					if(%ammoItem != "")
					{
						%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
						if(%delta)
						{
							teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
							Player::incItemCount(%client,%ammoitem,%delta);
						}
					}
					return 1;					
				}

			}
		}
	 	else if(%item.className == Vehicle)
	 	{
			%shouldBuy = VehicleStation::checkBuying(%client,%item);
			if(%shouldBuy == 1) {
				teamEnergyBuySell(%player,(%item.price * -1));
				return 1;
			}			
 			else if(%shouldBuy == 2)
				return 1;
		}
		else 
		{
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta)
			{
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
 	}
	return 0;
}

function remoteBuyItem(%client,%type)
{
	//echo ("Buying " @ %item);
	%player = client::getownedobject(%client);	
	%armor = Player::getArmor(%client);
	%team = GameBase::GetTeam(%client);

	if (%armor == "parmor")
		return;

	if (!%player.Station){bottomprint(%client, " You must be at an Inventory station to buy items.");return;}

	%item = getItemData(%type);
	if(buyItem(%client,%item))
	{	if(armor != "earmor" && armor != "efemale")
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else 
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
	//echo ("Done Buying");
}

function remoteSellItem(%client,%type)
{
	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);

	if (%armor == "parmor")
		return;
	if (%item.className == "flag")
		return;
		
	if (Client::isItemShoppingOn(%client,%item))
	{
		if(Player::getItemCount(%client,%item) && %item.className != Armor)
		{
			%numsell = 1;
		
			if(%item.className == Ammo || %item.className == HandAmmo)
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}
			else if (%item == ammopack)
			{
				checkMax(%client,%armor);
			}
			else if($TeamItemMax[%item] != "")
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == FgcPack)
			{ 
				if(Player::getItemCount(%client,"Mfgl") > 0)
				{
					Client::sendMessage(%client,1,"Sold Containment - Auto Selling Tactical Nuke");
					Player::setItemCount(%client, MFGLAmmo,0);
					Player::setItemCount(%client, MFGL,0);
				}
			}

			if (%armor == "jarmor")
			{
				if(%item == "Hammer1Pack")
				{
					Player::setItemCount(%client, Hammer2Pack,0);
				}			
				if(%item == "Mortar" || %item == "RocketLauncher")
				{
					Client::sendMessage(%client,1,"Juggernaught Can Not Sell These Items.");
					return;
				}
			}
			
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
	remoteDropItem(%client,%type);
}

function remoteUseItem(%player,%type)
{
	%item = getItemData(%type);
	%player.throwStrength = 1;
	if($debug) echo("Use item :" @ %type @ " " @ %item);	
 	%client = player::getclient(%player);
 	%armor = Player::getArmor(%client);
 
 	if (%armor == "parmor")
		return;

	%item1 = Player::getMountedItem(%player,4);
	%item2 = Player::getMountedItem(%player,5);	
	//echo("Type: " @ %type @ " - Item: " @ %item @ " - Item1: " @ %item1 @ " - Item2 " @ %item2);
	if (%item == "Hammer1Pack" || %item == "Hammer2Pack")
	{
		%item = "Backpack";
		%item1 = "Hammer1Pack";
		%item2 = "Hammer2Pack";
	}	
	//echo("____________Type: " @ %type @ " - Item: " @ %item @ " - Item1: " @ %item1 @ " - Item2 " @ %item2);
	if (%item1 == "Hammer1Pack" && %item2 == "Hammer2Pack" && %item == "Backpack")
	{
		%Ammo = Player::getItemCount(%player, $WeaponAmmo[Hammer1Pack]);
		if (%ammo)
		{
			%client = player::getclient(%player);
			Player::trigger(%player,4,true);	Player::trigger(%player,5,true);
			Player::trigger(%player,4,false);	Player::trigger(%player,5,false); 
			playSound(SoundPlasmaTurretFire, GameBase::getPosition(%player));
			schedule("playSound(SoundFlyerDismount, GameBase::getPosition("@%player@"));", 0.25, %player);
			godhammer::heatup(player::getclient(%player));
		}
		else
		{
			Client::sendMessage(player::getclient(%player),1,"No God Hammer Ammo!~waccess_denied.wav");
		}
		return;
	}
	if (%item == Backpack) 
	{
		%item = Player::getMountedItem(%player,$BackpackSlot);
	}
	else if (%item == Weapon)
	{
		%item = Player::getMountedItem(%player,$WeaponSlot);
		//Player::useItem(%player,%item);
		//return;
	}
	Player::useItem(%player,%item);

}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 
 	if (%armor == "parmor")
		return;

	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime())
	{
		if(GameBase::getControlClient(%player) != -1) 
		{
	  		//echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo)
			{
				if (%strength < 0)
					%strength = 0;
				else if (%strength > 100)
					%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
			}
		}
	}
}

function showitemnumbers()
{
	for (%k=0; getItemData(%k) != ""; %k++)
	{
		echo ("Item Nunber " @ %k @ " = " @ getItemData(%k) @ " = " @ getItemData(%k).description);
	}
}

function remoteDropItem(%client,%type)
{
	%player = Client::getOwnedObject(%client);
	%client.throwStrength = 1;
	%item = getItemData(%type);
	%armor = Player::getArmor(%client);
 	if (%armor == "earmor" || %armor == "efemale")
	{
		if (%item == Backpack) 
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			//schedule("Player::dropItem(" @ %client @ "," @ %item @ ");", 0.01);
			Player::dropItem(%client,%item);
		}
		else if (%item == Weapon) 
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) 
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) 
			{
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else 
		Player::dropItem(%client,%item);
			//schedule("Player::dropItem(" @ %client @ "," @ %item @ ");", 0.01);
	}
	else if (%armor == "parmor") {}
	else if((Client::getOwnedObject(%client)).driver != 1) 
	{
		if (%armor == "jarmor")
		{
			if(%item == "Mortar" || %item == "RocketLauncher" || %item == "PlasmaCannon" || %item == "LasCannon" || %item == "Mfgl" )
			{
				Client::sendMessage(%client,1,"Juggernaught Can Not Drop These Items.");
				return;
			}
			else if (%item == Weapon)
			{
				%item = Player::getMountedItem(%client,$WeaponSlot);
				Client::sendMessage(%client,1,"Juggernaught Can Not Drop These Items.");
				return;
			}
			else if (%item != Backpack) 
			{
				Player::dropItem(%client,%item);
			}			
		}	
		else if (%item == Backpack) 
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
	   else if (%item == Weapon) 
	   {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item == mortar0 || %item == mortar1 || %item == mortar2)
			{
				%item = "mortar";
				Player::unmountItem(%client,$WeaponSlot);
			}
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) 
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) 
			{
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else 
			Player::dropItem(%client,%item);
	}
}

function remoteDeployItem(%client,%type)
{
	if($debug) echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

function Item::BuildWeaponArray()
{
	$WeaponAmmt = 29;
	$WeaponList[0] = "Blaster";
	$WeaponList[1] = "Chaingun";
	$WeaponList[2] = "PlasmaGun";
	$WeaponList[3] = "GrenadeLauncher";
	$WeaponList[4] = "Mortar";
	$WeaponList[5] = "Mortar0";
	$WeaponList[6] = "Mortar1";
	$WeaponList[7] = "Mortar2";
	$WeaponList[8] = "Disclauncher";
	$WeaponList[9] = "LaserRifle";
	$WeaponList[10] = "EnergyRifle";
	$WeaponList[11] = "HyperB";
	$WeaponList[12] = "RocketLauncher";
	$WeaponList[13] = "SniperRifle";
	$WeaponList[14] = "BoomStick";
	$WeaponList[15] = "TranqGun";
	$WeaponList[16] = "Silencer";
	$WeaponList[17]= "ConCun";
	$WeaponList[18] = "RailGun";
	$WeaponList[19] = "Vulcan";
	$WeaponList[20] = "Mfgl";
	$WeaponList[21] = "Flamer";
	$WeaponList[22] = "IonGun";
	$WeaponList[23] = "Volter";
	$WeaponList[24] = "FixIt";
	$WeaponList[25] = "GravGun";
	$WeaponList[26] = "HackIt";
	$WeaponList[27] = "DisIt";
	$WeaponList[28] = "LasCannon";
	$WeaponList[29] = "PlasmaCannon";

	$WeaponAmmt = 26;
	$WeaponList[0] = "Blaster";
	$WeaponList[1] = "Chaingun";
	$WeaponList[2] = "PlasmaGun";
	$WeaponList[3] = "GrenadeLauncher";
	$WeaponList[4] = "Mortar";
	$WeaponList[5] = "Disclauncher";
	$WeaponList[6] = "LaserRifle";
	$WeaponList[7] = "EnergyRifle";
	$WeaponList[8] = "HyperB";
	$WeaponList[9] = "RocketLauncher";
	$WeaponList[10] = "SniperRifle";
	$WeaponList[11] = "BoomStick";
	$WeaponList[12] = "TranqGun";
	$WeaponList[13] = "Silencer";
	$WeaponList[14] = "ConCun";
	$WeaponList[15] = "RailGun";
	$WeaponList[16] = "Vulcan";
	$WeaponList[17] = "Mfgl";
	$WeaponList[18] = "Flamer";
	$WeaponList[19] = "IonGun";
	$WeaponList[20] = "Volter";
	$WeaponList[21] = "FixIt";
	$WeaponList[22] = "GravGun";
	$WeaponList[23] = "HackIt";
	$WeaponList[24] = "DisIt";
	$WeaponList[25] = "LasCannon";
	$WeaponList[26] = "PlasmaCannon";

	for (%i=0; %i <= $WeaponAmmt; %i++) //=== Build Next Array
	{
		%next = $WeaponList[%i+1];
		%curr = $WeaponList[%i];
		
		if (%i < $WeaponAmmt)
		{
			$NextWeapon[%curr] = %next;
		}
		else if (%i == $WeaponAmmt)
		{
			$NextWeapon[%curr] = $WeaponList[0];
		}
	}
	
	for (%i = $WeaponAmmt; %i >= 0; %i--)
	{
		%curr = $WeaponList[%i];
		%prev = $WeaponList[%i-1];
		
		if (%i == 0)
		{
			$PrevWeapon[%curr] = $WeaponList[$WeaponAmmt];
		}
		else if (%i > 0)
		{
			$PrevWeapon[%curr] = %prev;
		}
	}
}

Item::BuildWeaponArray();

function ShowWeaponArray()
{
	//echo ("*** Next Weaopn List");
	for (%i=0; %i <= $WeaponAmmt; %i++)
	{
		%weapon = $WeaponList[%i];
		%next = $NextWeapon[%weapon];
		
		echo ("Next Weapon For " @ %weapon @ " = " @ %next);
	}
	
	echo ("*** Previous Weaopn List");
	for (%i=0; %i <= $WeaponAmmt; %i++)
	{
		%weapon = $WeaponList[%i];
		%next = $PrevWeapon[%weapon];
		
		echo ("Prev Weapon For " @ %weapon @ " = " @ %next);
	}
	
}

function remoteNextWeapon(%client)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 
 	if (%armor == "parmor")
		return;

	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead) 
	{
		return;
	}

	%item = Player::getMountedItem(%client,$WeaponSlot);
	if(%item == mortar0 || %item == mortar1 || %item == mortar2)
	{
		for (%weapon = $NextWeapon[mortar]; %weapon != %item; %weapon = $NextWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				%cur = Player::getMountedItem(%client,$WeaponSlot);
				if (%cur == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
	else if (%item == -1 || $NextWeapon[%item] == "")
	{
		selectValidWeapon(%client);
	}
	else
	{
		for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				if (%weapon == mortar)
					break;
			}
		}
	}
}

function remotePrevWeapon(%client)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 
 	if (%armor == "parmor")
		return;

	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead) 
	{
		return;
	}

	%item = Player::getMountedItem(%client,$WeaponSlot);
	if(%item == mortar0 || %item == mortar1 || %item == mortar2)
	{
		for (%weapon = $PrevWeapon[mortar]; %weapon != %item; %weapon = $PrevWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				%cur = Player::getMountedItem(%client,$WeaponSlot);
				if (%cur == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
	else if (%item == -1 || $PrevWeapon[%item] == "")
		selectValidWeapon(%client);
	else
	{
		for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				%cur = Player::getMountedItem(%client,$WeaponSlot);
				if (%cur == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				if(%weapon == mortar)
					break;
			}
		}
	}
}

function selectValidWeapon(%client)
{
	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead) 
	{
		return;
	}
	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item]; %weapon != %item;%weapon = $NextWeapon[%weapon])
	{
		if (isSelectableWeapon(%client,%weapon))
		{
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead) 
	{
		return;
	}
	if (Player::getItemCount(%client,%weapon))
	{
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	else if(Player::getItemCount(%client,mortar) && (%weapon == mortar || %weapon == mortar0 || %weapon == mortar1 || %weapon == mortar2))
	{
		if(Player::getItemCount(%client,mortarammo) > 0)
		return true;
	}
	return false;
}

//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	
	if($ItemMax[%armor, %item])
	{		  
		%client = Player::getClient(%player);
		
		if (%item.className == Backpack)
		{
			if (Player::getMountedItem(%player,$BackpackSlot) == -1)
			{
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
		 		return 1;
			}
		}
		else if (%item.className == VModule)
		{
		    if (!Player::getItemCount(%player, NapalmModule) && !Player::getItemCount(%player, HellFireModule) && 
			!Player::getItemCount(%player, BomberModule) && 
			!Player::getItemCount(%player, WraithModule) && !Player::getItemCount(%player, InterceptorModule) &&
			!Player::getItemCount(%player, StealthModule) && !Player::getitemCount(%player, GodHammerModule) &&
			!Player::getItemCount(%player, MineNetModule) && !Player::getItemCount(%player, PickUpModule) && !Player::getItemCount(%player, ValkyrieModule))
			{
		 		Player::incItemCount(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item,description @ ".");
		 		return 1;
			}
		}		
  		else 
  		{
			if (%item.className == Weapon)
			{
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}
			
			%extraAmmo = 0 ;
			
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "")
				%extraAmmo = $AmmoPackMax[%item];
				
			%count = Player::getItemCount(%player,%item);
			if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
				
			if (%delta > 0)
			{
				Player::incItemCount(%player,%item,%delta);
				if (%count == 0 && $AutoUse[%item])
					Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
				return %delta;
			}
		}
   	}
   	else
		return 0;
}


//----------------------------------------------------------------------------
// Default Item object methods

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if (%sound != "")  
		playSound(%sound,GameBase::getPosition(%this));
	else
	{
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
	if (Item::isRotating(%this)) 
	{
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else
	{ 
		if(%this)deleteObject(%this);
	}
}

function Item::onAdd(%this)
{
}

function Item::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
}

function Item::onUse(%player,%item)
{
	//if($debug) echo("Item used: ",%player," ",%item);
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
	GameBase::startFadeOut(%item);
	schedule("deleteObject(" @ %item @ ");",2.5, %item);
}

function Item::onDrop(%player,%item)
{
	//if($debug) echo ("ITEM = " @ %item);
	if($matchStarted)
	{
		if(%item.className != Armor)
		{
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);			
 	 	 	addToSet("MissionCleanup", %obj);

			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else
			{
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}

//----------------------------------------------------------------------------
// Flags
//----------------------------------------------------------------------------

function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
	mapIcon = "M_camera";
	
	validateShape = true;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemData RaceFlag
{
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

	ItemData ScoutArmor
	{
	   	heading = "aArmor";
		description = "Scout";
		className = "Armor";
		price = 175;
	};
	
	ItemData SpArmor
	{
	   	heading = "aArmor";
		description = "Chemeleon";
		className = "Armor";
		price = 175;
	};
	
	ItemData LightArmor
	{
	   	heading = "aArmor";
		description = "Assassin";
		className = "Armor";
		price = 175;
	};
	
	ItemData MediumArmor
	{
	   	heading = "aArmor";
		description = "Mercenary";
		className = "Armor";
		price = 250;
	};
	
	ItemData BursterArmor
	{
	   	heading = "aArmor";
		description = "Goliath";
		className = "Armor";
		price = 250;
	};

	
	ItemData EngArmor
	{
	   	heading = "aArmor";
		description = "Engineer";
		className = "Armor";
		price = 250;
	};
	
	ItemData AlArmor
	{
	   	heading = "aArmor";
		description = "Arbitor";
		className = "Armor";
		price = 250;
	};
	
	ItemData DragArmor
	{
	   	heading = "aArmor";
		description = "DreadNaught";
		className = "Armor";
		price = 400;
	};
	
	ItemData Juggernaught
	{
	   	heading = "aArmor";
		description = "Juggernaught";
		className = "Armor";
		price = 3500;
	};


//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 600;
};

ItemData WraithVehicle
{
	description = "Wraith";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 600;
};

ItemData JetVehicle
{
	description = "Interceptor";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 600;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 875;
};



//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onUse(%player,%item)
{
	%ammo = %item.imageType.ammoType;
	
	if (%ammo == "")
	{
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else
	{
		if (Player::getItemCount(%player,%ammo) > 0) 
			Player::mountItem(%player,%item,$WeaponSlot);
		else
		{
			Client::sendMessage(Player::getClient(%player),0,
			strcat(%item.description," has no ammo"));
		}
	}
}


//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}



//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta)
		{
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0)
		{
			%obj = newObject("","Item",%item,%delta,false);
      			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

		      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	

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
	
	//validateShape = true;
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
	
	//validateShape = true;
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
	//validateShape = true;
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
		MDMDetonate2(%player);
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
				MDMDetonate(%player);
			else if(%Ammo > 1)
			{
				%client.firemortar = (Projectile::spawnProjectile("DelayMortarShell",%trans,%player,%vel));
				schedule("MDMDetonate(" @ %player @");",10,%client.firemortar);
				Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
			else if(%Ammo == 1)
			{
				%client.lastmdm = (Projectile::spawnProjectile("DelayMortarShell",%trans,%player,%vel));
				schedule("MDMDetonate2(" @ %player @");",10,%client.lastmdm);
			}
		}		
	}
}

function MDMDetonate(%player)
{
 %client = GameBase::getOwnerClient(%player);
 %obj = newObject("","Mine","MDMBlast");
 %obj2 = newObject("","Mine","MDMBlast2");
 GameBase::throw(%obj,%client,0,false);		
 GameBase::throw(%obj2,%client,0,false);
 addToSet("MissionCleanup", %obj);
 addToSet("MissionCleanup", %obj2);
 %padd = "0 0 0.5";
 %pos = Vector::add(GameBase::getPosition(%client.firemortar), %padd);
 GameBase::setPosition(%obj, %pos);
 GameBase::setPosition(%obj2, %pos);
 if(%client.firemortar)deleteObject(%client.firemortar);
 %client.firemortar = "False";
}

function MDMDetonate2(%player)
{
 %client = GameBase::getOwnerClient(%player);
 %obj = newObject("","Mine","MDMBlast");
 %obj2 = newObject("","Mine","MDMBlast2");
 GameBase::throw(%obj,%client,0,false);		
 GameBase::throw(%obj2,%client,0,false);
 addToSet("MissionCleanup", %obj);
 addToSet("MissionCleanup", %obj2);
 %padd = "0 0 0.5";
 %pos = Vector::add(GameBase::getPosition(%client.lastmdm), %padd);
 GameBase::setPosition(%obj, %pos);
 GameBase::setPosition(%obj2, %pos);
 if(%client.lastmdm)deleteObject(%client.lastmdm);
 %client.lastmdm = "False";
 Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
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
	
	//validateShape = true;
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
	
	validateShape = true;
	validateMaterials = true;
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
	{	%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
	
		if (!%client.rocket || %client.rocket == 0)	//== Standard Stinger Rocket
		{	if(%armor != "jarmor")
			{	Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
				schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel);
			}
			else
			{	Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
				schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
				Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel);
			}			
		}
		else if (%client.rocket == 1 && %armor != "jarmor")			//== Stinger w/ locking.
		{	
			%client = GameBase::getOwnerClient(%player);
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);

			if(GameBase::getLOSInfo(%player,500)) 
			{
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%object == "Player") // || %object == "Flier"
				{			 
						%name = Client::getName(%targetId);
						Tracker(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
						schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
				}
				else
				{
					Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
					schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
				}
			}
			else
			{
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
			}		
		}
		else if (%client.rocket == 1)			//== Stinger w/ locking.
		{	
			%client = GameBase::getOwnerClient(%player);
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);

			if(GameBase::getLOSInfo(%player,500)) 
			{
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%object == "Player") // || %object == "Flier"
				{			 
						%name = Client::getName(%targetId);
						Tracker(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("JuggStingerMissileTracker",%trans,%player,%vel,$los::object);
						schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));",0.01);
				}
				else
				{
					Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel,%player);
					schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));",0.01);
				}
			}
			else
			{
				Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel,%player);
				schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
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
				LockjawWarn(%targetId);
				LockJawFire(%player, %client.target);
			}
		}
		else if (%client.rocket == 3)
		{
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));", 0.01);
			%obj1 = (Projectile::spawnProjectile("GodHammerMortar",%trans,%player,%vel));
			%obj1.deployer = %client;
		}
	}
	else
	{ Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Rocket Launcher");
	}
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
	
	validateShape = true;
	validateMaterials = true;
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
	
	validateShape = true;
	validateMaterials = true;
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
    	minEnergy = 45;
	maxEnergy = 55;
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
	
	validateShape = true;
	validateMaterials = true;
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
	fireTime = 0.001;
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
	
	//validateShape = true;
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
};

function MfglImage::onFire(%player, %slot) 
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Mfgl]);
	%armor = Player::getArmor(%player);
	if((Player::getMountedItem(%player,$BackpackSlot) == FgcPack) || (%armor == "jarmor"))
	{
		if(%AmmoCount)
		{
			ixApplyKickback(%player, 500, 70);
			$TeamItemCount[GameBase::getTeam(%player) @ "MFGLAmmo"]++;	 
			Player::decItemCount(%player,$WeaponAmmo[Mfgl],1);

			%client = GameBase::getOwnerClient(%player);
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
		$TeamItemCount[GameBase::getTeam(%player) @ "MFGLAmmo"]++;
		Client::sendMessage(Player::getClient(%player), 1,"Firing A Tactical Nuke With Out A Containment Pack Can Be Dangerous.");
		GameBase::applyRadiusDamage($NukeDamageType, getBoxCenter(%player), 3, 15, 500, %player);
		return;
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
	reloadTime = 0.1;
	fireTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	minEnergy = 6;
	maxEnergy = 6;
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
   	shapeFile  = "GrenadeL";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.2;
	fireTime = 0.2;
	minEnergy = 10;
	maxEnergy = 20;
	projectileType = IonGunBolt;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};


ItemData IonGun
{
    	heading = "bWeapons";
	description = "Ion Rifle";
	className = "Weapon";
    	shapeFile  = "GrenadeL";
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
	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
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

//========================================================================================================= 
//                                                 Back Packs
//========================================================================================================= 

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
	deployable(%player,%item,"StaticShape","Invo Station",True,False,True,False,True,True,4,True,0,False, "DeployableInvStation", "DeployableInvPack");
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
	
	validateShape = true;
	validateMaterials = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
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
	
	validateShape = true;
	validateMaterials = true;
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
	
	validateShape = true;
	validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	%armor = Player::getArmor(%clientId);
	
	if (%armor == "stimarmor" || %armor == "stimfemale")
	{
		Client::sendMessage(Player::getClient(%player),0,"Shield On");
		%player.shieldStrength = 0.0153;
		%player.shieldon = true;
		return;
	}

	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.018;
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
	
	validateShape = true;
	validateMaterials = true;
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

//======================================================================== Cloacking Device

ItemImageData CloakingDeviceImage
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
	
	validateShape = true;
	validateMaterials = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if ((%armor != "aarmor") && (%armor != "afemale"))
	{
		GameBase::startFadeout(%player);
		Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
		%rate = Player::getSensorSupression(%player) + 5;
		Player::setSensorSupression(%player,%rate);
	}
	else
	{
		%obj = newObject("","Mine","CloakBlast");
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 3.5";
		%pos = Vector::add(GameBase::getPosition(%player), %padd);
		GameBase::setPosition(%obj, %pos);	
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{

	%armor = Player::getArmor(%player);

	 if ((%armor != "aarmor") && (%armor != "afemale"))
	 {
		GameBase::startFadein(%player);
		Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,%rate);
		Player::trigger(%player,$BackpackSlot,false);
	 }
	 else
		Player::trigger(%player,%imageslot,false);

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
	
	validateShape = true;
	validateMaterials = true;
};

function StealthShieldPackImage::onActivate(%player,%imageSlot)
{
	if (%player == "-1" || !%player)return;
	%clientId = Player::getClient(%player);
	%armor = Player::getArmor(%clientId);
	
	if (%armor == "stimarmor" || %armor == "stimfemale")
	{
		Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
		%player.shieldStrength = 0.0102;
		%player.stealthshieldon = true;
		%rate = Player::getSensorSupression(%player) + 20;
		Player::setSensorSupression(%player,%rate);
		return;
	}

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
	minEnergy = 8;
	maxEnergy = 14;
	sfxFire = SoundRepairItem;
	projectileType = DrainBolt;
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
	
	validateShape = true;
	validateMaterials = true;
};

function RegenerationPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Regen)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RegenerationPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,Regen,$WeaponSlot);
	}
}

function RegenerationPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Regen)
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
	
	validateShape = true;
	validateMaterials = true;
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
			%client.telepoint = "False";
			deleteobject(%client.telebeacon);
			%client.telebeacon = "False";
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

//function FlightPack::onUnmount(%player,%item)
//{
//	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
//		Player::unmountItem(%player,$WeaponSlot);
//}


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

			 if(%object == "Player") // || %object == "Flier"
			 {			 
				%name = Client::getName(%targetId);
				Tracker(%client,%targetId);
				Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
				Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
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
	Player::trigger(%player,%slot,false);
}

function SMRPack2Image::onActivate(%player, %slot) 
{
	Player::trigger(%player,%slot,true);
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

			 if(%object == "Player") // || %object == "Flier"
			 {			 
					%name = Client::getName(%targetId);
					Tracker(%client,%targetId);
					Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
					Projectile::spawnProjectile("JuggStingerMissileTracker",%trans,%player,%vel,$los::object);
			 }
			 else
			 {
				 Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel,%player);
			 }
	 	}
		else
		{
			Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel,%player);
		}
	}
	else
	Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Auto Rocket Launcher");
		Player::trigger(%player,%slot,false);
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
		deleteObject(%set);		
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
	mass = 5.0;
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
	mass = 3.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
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
//	deleteObject(%item);
//}

function SuicidePack::onDeploy(%player,%item,%pos)
{
	SuicidePack::deployShape(%player,%item);
}

function SuicidePack::deployShape(%player,%item)
{
	Player::unmountItem(%player,$BackpackSlot);
	Player::decItemCount(%player,%item);
	%obj = newObject("","Mine","Suicidebomb2");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	%obj.deployer = %client;
	GameBase::throw(%obj,%client,5 * %client.throwStrength,false);
	Client::sendMessage(%client,1,"Det Pack will destruct in 20 seconds");
	$TeamItemCount[GameBase::getTeam(%player) @ "SuicidePack"]++;
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
	
	validateShape = true;
	validateMaterials = true;
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

//==========================================================================
// Remote Turets
//==========================================================================
																			
ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Ion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
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

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function TurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Ion Turret",True,False,True,False,True,True,4,True,35, True, "DeployableTurret", "TurretPack");
}

//============================================================= Laser Turret

ItemImageData LaserPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LaserPack
{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	
	validateShape = true;
	validateMaterials = true;
};

function LaserPack::onUse(%player,%item)
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

function LaserPack::onDeploy(%player,%item,%pos)
{
	if (LaserPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function LaserPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Laser Turret",False,False,False,False,True,True,5,True,55, True, "DeployableLaser", "LaserPack");
}

//==================================================== Deployable ELF Turret

ItemImageData DeployableElfImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DeployableElf
{
	description = "Deployable Elf Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
    	heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 700;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableElf::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableElf::onDeploy(%player,%item,%pos)
{
	if (DeployableElf::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableElf::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Deployable Elf Turret",False,False,False,False,True,True,5,True,20, True, "DeployableElfTurret", "DeployableElf");
}

//=============================================================== Emp Turret

ItemImageData ShockPackImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ShockPack
{
	description = "EMP Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = ShockPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShockPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ShockPack::onDeploy(%player,%item,%pos)
{
	if (ShockPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShockPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","EMP Turret",False,False,False,False,False,True,5,True,15, True, "DeployableShock", "ShockPack");
}

//===========================================================  Mortar Turret

ItemImageData TargetPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData TargetPack
{
	description = "Mortar Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = TargetPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TargetPack::onUse(%player,%item)
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

function TargetPack::onDeploy(%player,%item,%pos)
{
	if (TargetPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TargetPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Mortar Turret",True,False,15,10,True,True,4,True,25, True, "DeployableMortar", "TargetPack");
}

//================================================= Deployable Plasma Turret

ItemImageData PlasmaTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasmaTurretPack
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "dDeployables";
	imageType = PlasmaTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaTurretPack::onUse(%player,%item)
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


function PlasmaTurretPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaTurretPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function PlasmaTurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","RMT Plasma Turret",True,False,True,False,True,True,4,True,25, True, "DeployablePlasma", "PlasmaTurretPack");
}

//=============================================================Rocket Turret
						
ItemImageData RocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RocketPack
{
	description = "Rocket Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "dDeployables";
	imageType = RocketPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item)
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

function RocketPack::onDeploy(%player,%item,%pos)
{
	if (RocketPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function RocketPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","RMT Rocket Turret",True,False,True,10,True,True,4,True,100, True, "DeployableRocket", "RocketPack");
}

//==========================================================================
// 						Other Deployables
//==========================================================================
//====================================================Deployable Force Field
ItemImageData ForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldPack
{
	description = "Small Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "eDefensive";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
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

function ForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Small Force Field",True,False,False,False,False,False,4,True,0, False, "DeployableForceField", "ForceFieldPack");
}


//=================================================================================================== Large Force Field

ItemImageData LargeForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldPack
{
	description = "Large Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "eDefensive";
	imageType = LargeForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LargeForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}



function LargeForceFieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Large Force Field",True,False,False,False,False,False,4,True,0, False, "LargeForceField", "LargeForceFieldPack");
}

//=================================================================================================== Blastwall

ItemImageData BlastWallPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    	mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BlastWallPack
{
	description = "Blast Wall";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "eDefensive";
	imageType = BlastWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastWallPack::onUse(%player,%item)
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

function BlastWallPack::onDeploy(%player,%item,%pos)
{
	if (BlastWallPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BlastWallPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Blast Wall",True,False,False,False,False,False,4,True,0, False, "BlastWall", "BlastWallPack");
}

//=================================================================================================== HoloGram

ItemImageData HoloPackImage
{
	shapeFile = "larmor";
	mountPoint = 2;
    	mountOffset = { 5, -5, 0 };
	mass = 1.0;
	firstPerson = true;
};

ItemData HoloPack
{
	description = "Hologram";
	shapeFile = "larmor";
	className = "Backpack";
	heading = "eDefensive";
	imageType = HoloPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 900;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HoloPack::onUse(%player,%item)
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
function HoloPack::onDeploy(%player,%item,%pos) 

{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"])
	{
		hologram(%client);
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
	}
	else
	{
		Client::sendMessage(%client,0,"Hologram generator overloaded.  Try again later");
	}
}

function HoloPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
		    	%set = newObject("holoset",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
			%num = CountObjects(%set,"Hologram",%num);
			deleteObject(%set);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				if(checkDeployArea(%client,$los::position))
				{
					%rot = GameBase::getRotation(%player);
					%rnd = floor(getRandom() * 10);
					if(%rnd > 6)
					   %fField = newObject("","StaticShape",Hologram1,true);
					else
					if((%rnd > 2) && (%rnd < 7))				
					   %fField = newObject("","StaticShape",Hologram2,true);
					else
					   %fField = newObject("","StaticShape",Hologram3,true);

					addToSet("MissionCleanup", %fField);
					GameBase::setTeam(%fField,GameBase::getTeam(%player));
					GameBase::setPosition(%fField,$los::position);
					GameBase::setRotation(%fField,%rot);
					Client::sendMessage(%client,0,"Hologram Deployed");
					GameBase::startFadeIn(%fField);
					playSound(SoundPickupBackpack,$los::position);
					playSound(ForceFieldOpen,$los::position);					
					$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
					return true;
				}
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//=================================================================================================== Mechanical Tree

ItemImageData TreePackImage
{
	shapeFile = "tree1";
	mountPoint = 2;
   	mountOffset = { 0, 0.15, -1 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Mechanical Tree";
	shapeFile = "AmmoPack";
	className = "Backpack";
   	heading = "eDefensive";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TreePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TreePack::onDeploy(%player,%item,%pos)
{
	if (TreePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain")
			{
		    		%set = newObject("treeset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableTree",%num);
				deleteObject(%set);
				//if(0 == %num) {
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
							%rnd = floor(getRandom() * 10);
							if(%rnd > 5)
								// do tree one
							   %fField = newObject("","StaticShape",DeployableTree,true);
							else
								//tree 2
       						   %fField = newObject("","StaticShape",DeployableTree2,true);
							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Mechanical Tree");
							Client::sendMessage(%client,0,"Mechanical Tree Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//=================================================================================================== Healing Plant

ItemImageData PlantPackImage
{
	//shapeFile = "AmmoPack";
	shapeFile = "cactus2";
	mountPoint = 2;
   mountOffset = { 0, -0.5, -0.3 };

//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlantPack
{
	description = "Healing Plant";
	shapeFile = "AmmoPack";
	className = "Backpack";
   	heading = "eDefensive";
	imageType = PlantPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlantPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlantPack::onDeploy(%player,%item,%pos)
{
	if (PlantPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlantPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
		    		%set = newObject("plantset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableCactus",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player);
							%rnd = floor(getRandom() * 10);
							if(%rnd > 5)
								%fField = newObject("","StaticShape",DeployableCactus1,true);
							else  
								%fField = newObject("","StaticShape",DeployableCactus2,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Healing Plant");
							Client::sendMessage(%client,0,"Healing Plant Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "PlantPack"]++;
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//=================================================================================================== Platform

ItemImageData PlatformPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlatformPack
{
	description = "Deployable Platform";
	shapeFile = "AmmoPack";
	className = "Backpack";
   	heading = "eDefensive";
	imageType = PlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlatformPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlatformPack::onDeploy(%player,%item,%pos)
{
	if (PlatformPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function PlatformPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","DeployablePlatform","Player",False,False,False,False,False,7,True,0, False, "DeployablePlatform", "PlatformPack");
}

//==================================================================================================== Teleport Pad

ItemImageData TeleportPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
    	heading = "sPersonnel Movers";
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportPack::onUse(%player,%item)
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

function TeleportPack::onDeploy(%player,%item,%pos)
{
	if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
	}
}

function CreateteleportSimSet()
{
    	%teleset = nameToID("MissionCleanup/Teleports");
	if(%teleset == -1)
	{
		newObject("Teleports",SimSet);
		addToSet("MissionCleanup","Teleports");
	}
}

function TeleportPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
	
	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				if(checkDeployArea(%client,$los::position))
				{
					%pos = $los::position;
					%padd = "0 0 0.3";
                			%poss = Vector::add(%pos, %padd);
					
					if(GameBase::testPosition(%player, %poss)) { } else { Client::sendMessage(%client,0,"Can not deploy inside other objects."); return; }

					%sensor = newObject("Teleport Pad","StaticShape",%shape,true);

					CreateteleportSimSet();
					addToSet("MissionCleanup/Teleports", %sensor);
					addToSet("MissionCleanup", %sensor);

					GameBase::setTeam(%sensor,GameBase::getTeam(%player));
					%pos = Vector::add($los::position,"0 0 1");
					GameBase::setPosition(%sensor,%pos);
					Gamebase::setMapName(%sensor,%name);
					Client::sendMessage(%client,0,%item.description @ " deployed");
					%sensor.disabled = false;
					playSound(SoundPickupBackpack,$los::position);

					%beam = newObject("","StaticShape",ElectricalBeam,true);
					addToSet("MissionCleanup", %beam);
					GameBase::setTeam(%beam,GameBase::getTeam(%player));
					GameBase::setPosition(%beam,%pos);

					%sensor.beam1 = %beam;
					return true;
				}
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

//==================================================================================================== Interceptor Pack

ItemImageData MechPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
    	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MechPack
{
	description = "Interceptor Pack";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   	heading = "sPersonnel Movers";
	imageType = MechPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MechPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MechPack::onDeploy(%player,%item,%pos)
{
	if (MechPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MechPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	
	if($TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"] < $TeamItemMax[ScoutVehicle] || $TeamItemCount[GameBase::getTeam(%player) @ "Mechpack"] < $TeamItemMax[Mechpack])
	{			
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
			%set = newObject("mechset",SimSet);

			deleteObject(%set);
			%pos = $los::position;
				%padd = "0 0 10";
				%poss = Vector::add(%pos, %padd);
				for (%b=1; %b < 5; %b++)
				{
					%padd = "0 0 " @ %b;
					%poss = Vector::add(%pos, %padd);
					if(!GameBase::testPosition(%player, %poss))
						%nope = 1;
				}
				if (%nope == 1)
				{
					Client::sendMessage(%client,0,"You can not deploy Interceptor Pack, space too enclosed.");
					return; 
				}
				else	if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player);
						%fField = newObject("",flier,Scout,true);
						//%fField.module = 9;
						//%fField.ammo = 150;
						Player::setItemCount(%client, InterceptorModule, 1);
						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField,GameBase::getTeam(%player));
						GameBase::setPosition(%fField,$los::position);
						GameBase::setRotation(%fField,%rot);
						Client::sendMessage(%client,0,"Scout Deployed");
						GameBase::startFadeIn(%fField);
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++;
						//$TeamItemCount[GameBase::getTeam(%player) @ "Mechpack"]++;
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function MechPack::onDestroyed(%this)
{
  	$TeamItemCount[GameBase::getTeam(%this) @ "ScoutVehicle"]--;
}

//==================================================================================================== Stealth HPC Pack

ItemImageData DetPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
    	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DetPack
{
	description = "Stealth HPC Pack";
	shapeFile = "ammounit_remote";
	className = "Backpack";
    	heading = "sPersonnel Movers";
	imageType = DetPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DetPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DetPack::onDeploy(%player,%item,%pos)
{
	if (DetPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DetPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] < $TeamItemMax[HAPCVehicle])
	{
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player);
						%fField = newObject("",flier,HAPC,true);
						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField,GameBase::getTeam(%player));
						GameBase::setPosition(%fField,$los::position);
						GameBase::setRotation(%fField,%rot);
						Gamebase::setMapName(%fField,"HPC Pack");
						Client::sendMessage(%client,0,"Deployed StealthHPC");
						GameBase::startFadeIn(%fField);
						playSound(SoundPickupBackpack,$los::position);
						//playSound(ForceFieldOpen,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++;
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");

			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//======================================================================== Repair Kit

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = "gMiscellany";
	shadowDetailMask = 4;
	price = 35;
	
	validateShape = true;
	validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	dbecho ("Repair Kit!");
	
	Player::decItemCount(%player,%item);
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);

	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	
	if (%clientId.poisonTime)
	{
		%clientId.poisonTime = 0;
	        bottomprint(%clientId, "<jc><f2>Poison cured.", 5);	
	}

	if (%armor == "sarmor" || %armor == "sfemale"  || %armor == "stimarmor" || %armor == "stimfemale")
	{		
		if (%clientId.ovd > 15)
		{	
			%overd = %clientId.ovd;
			
			dbecho ("OD- " @ %clientId.ovd @ "");
			dbecho ("O1- " @ %overd @ "");
			%repair = (25 + floor(getRandom() * 25));
			%clientId.ovd = %clientId.ovd - %repair;
			if (%clientId.ovd < 0)
			{
				%clientId.ovd = 0;
			        bottomprint(%clientId, "<jc><f2>Over Dose Down to " @ %clientId.ovd @ "%.", 5);	
			}

			dbecho ("AD- " @ %clientId.ovd @ "");
		        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Decreased from " @ %overd @ " to " @ %clientId.ovd @ "%.", 5);	
	        }
		GameBase::repairDamage(%player,0.1);
	}
	
	else if(%armor == "larmor" || %armor == "lfemale")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "earmor" || %armor == "efemale")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "spyarmor" || %armor == "spyfemale")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "aarmor" || %armor == "afemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "harmor")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "barmor" || %armor == "bfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "darmor")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "jarmor")
	{
		GameBase::repairDamage(%player,0.5);
		if (%clientId.heatup > 50)
		{
			%clientId.heatup = %clientId.heatup - 20;
		}
	}
	else
	{
		GameBase::repairDamage(%player,0.1);
	}
}


//======================================================================== Mines

ItemData MineAmmo
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = "gMiscellany";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted && %player.throwTime < getSimTime())
	{
		%client = Player::getClient(%player);
		%clTeam = GameBase::getTeam (%client);
		%armor = Player::getArmor(%player);
		%plTeam = GameBase::getTeam(%player);
		%proxmax = $TeamItemCount[%plTeam @ "ProxMine"];
		if($server::deathmatch)
			%obj = newObject("","Mine", "DmMine");
		else if (%armor == "larmor" || %armor == "lfemale")
			%obj = newObject("","Mine", "Hologram");
		else if (%armor == "aarmor" || %armor == "afemale")
			%obj = newObject("","Mine", "ShockMine");
		else if (%armor == "spyarmor" || %armor == "spyfemale")
			%obj = newObject("","Mine", "SubspaceMine");
		else if(%armor == "earmor" || %armor == "efemale")
		{
			if (%client.EngMine == "0" && %proxmax < 9)
			{
				%obj = newObject("","Mine", "ProxMine");
				$TeamItemCount[%plTeam @ "ProxMine"]++;
			}
			else if (%client.EngMine == "1")
				%obj = newObject("","Mine", "SubspaceMine");
			else if (%client.EngMine == "2")
			{	if(Player::getMountedItem(%client,$BackpackSlot) != "ammopack")
					LaserMine(%client, %player, %item, 15);
				else
					LaserMine(%client, %player, %item, 20);
			}
			else if (%client.EngMine == "3")
				%obj = newObject("","Mine", "antipersonelMine");
			else if (%client.EngMine == "4")
				%obj = newObject("","Mine", "ReplicatorMine");
		}
		else if (%armor == "darmor" || %armor == "harmor")
		{
			if (%client.dmines == 0 || !%client.dmines)
			{
				if(Player::getMountedItem(%player, $BackpackSlot) != "ammopack")
					LaserMine(%client, %player, %item, 15);
				else
					LaserMine(%client, %player, %item, 20);	
			}
			else if (%client.dmines == 1)
				%obj = newObject("","Mine", "antipersonelMine"); 
		}
		else if (%armor == "sarmor" || %armor == "sfemale" || %armor == "marmor" || %armor == "mfemale" || %armor == "barmor" || %armor == "bfemale")
			%obj = newObject("","Mine", "antipersonelMine"); 
		//==== Finish Mine Deploy
		if(%obj)
		{
			Player::decItemCount(%player,%item);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%client,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,%clTeam);
		}
	}
}


//==================================================================================================== Laser Mine

function LaserMine(%client, %player, %bec, %nrg)
{	%item = "LaserMine";
	//%client = Player::getClient(%player);
		%energy = GameBase::getEnergy(%player);
		%energy = (%energy - %nrg);
		if(%nrg == 25 && %energy < 25)
		{
		bottomprint(%client, "<jc>You're out of energy, can not Deploy LaserMine.",3);
		GameBase::setEnergy(%player,%energy);	
		return;
		}
		else if (%energy < 15)
		{
		bottomprint(%client, "<jc>You're out of energy, can not Deploy LaserMine.",3);
		return;
		}
		else
		if (GameBase::getLOSInfo(%player,6)) 
		{
			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
			else 
			{
				if (Vector::dot($los::normal,"0 0 -1") > 0.2)
					%rot = "3.14159 0 " @ %zRot;
				else 
					%rot = Vector::getRotation($los::normal);
			}
			if(checkDeployArea(%client,$los::position))
			{
				%turret = newObject("Camera","Turret",DeployableLaserM,true);
				addToSet("MissionCleanup", %turret);
				GameBase::setTeam(%turret,GameBase::getTeam(%player));
				GameBase::setRotation(%turret,%rot);
				GameBase::setPosition(%turret,$los::position);
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%turret) @ "LaserMine"]++;
				if($debug) echo("MSG: ",%client," deployed a Laser Mine.");
				Player::decItemCount(%player,%bec);
				GameBase::setEnergy(%player,%energy);				
				return true;
			}
		}
		else
			bottomprint(%client, "<jc>Deploy position out of range", 3);		
		return false;
	}

//==================================================================================================== Grenades

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
	
	//validateShape = true;
	//validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted && %player.throwTime < getSimTime())
	{
		%client = Player::getClient(%player);
		Player::decItemCount(%player,%item);
		%armor = Player::getArmor(%player);
		if (%armor == "marmor" || %armor == "mfemale" || $server::deathmatch)
			%obj = newObject("","Mine","Handgrenade");
		else if (%armor == "spyarmor" || %armor == "spyfemale")
		{
			%obj = newObject("","Mine","Nukebomb");
			%timer = %client.plastic;	
			Client::sendMessage(%client,1, "Plastique Explosive will explode in " @ %timer @ " seconds"); 
			schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", %timer);
		}
		else if(%armor == "earmor" || %armor == "efemale")
			%obj = newObject("","Mine","EMPgrenade");
		else if (%armor == "larmor" || %armor == "lfemale")
			%obj = newObject("","Mine","HoloMine");
		else if (%armor == "sarmor" || %armor == "sfemale"  || %armor == "stimarmor" || %armor == "stimfemale")
			%obj = newObject("","Mine","Firebomb");
		else if (%armor == "aarmor" || %armor == "afemale")
			%obj = newObject("","Mine","Tranqgrenade");
		else if (%armor == "barmor" || %armor == "bfemale")
			%obj = newObject("","Mine","Concussion");
		else if (%armor == "darmor" || %armor == "harmor")
			%obj = newObject("","Mine","Mortarbomb");
		//======================= End class select
		if(%obj)
		{
	 	 	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%client,15 * %client.throwStrength,false);			
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam(%client));
		}
	}
}


function Grenade::Plastic_Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
//==================================================================================================== Beacons

ItemData Beacon
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = "gMiscellany";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	
	validateShape = true;
	validateMaterials = true;
};

function checkForStar(%this, %rot, %pos)
{	
	if(%this.check)
	{	
		%pos = gamebase::getposition(%this);
		%rot = GameBase::getRotation(%this);
		schedule("checkForStar(\"" @ %this @ "\", \"" @ %rot @ "\", \"" @ %pos @ "\");", 0.1);
	}
	else if($matchstarted)
	{	
		//%obj = newObject("","Mine","StarMine");
		%obj = newObject("","turret","StarTurret");
	 	addToSet("MissionCleanup", %obj);	
	 	%obj.deployer = 2048;
		GameBase::setPosition(%obj,%pos);
		GameBase::setRotation(%obj,%rot);
	}
}

function Beacon::onUse(%player,%item)
{
	%armor = Player::getArmor(%player);
	%clientID = Player::getClient(%player);

	if(!$matchStarted)
		return;

	if (%armor == "larmor" || %armor == "lfemale")
	{
		if(%player.throwTime < getSimTime())
		{
			if (!%clientId.AssBcn || %clientId.AssBcn == 0)
			{
				if(!%player.Station)
				{
					%trans = GameBase::getMuzzleTransform(%player);
					%vel = Item::getVelocity(%player);
					playSound(SoundThrowItem,GameBase::getPosition(%player));
					%obj = Projectile::spawnProjectile("StarShell",%trans,%player,%vel);
					//%obj.check = 1;
					//%pos = gamebase::getposition(%player);
					//%rot = getWord(%trans, 0) @ "  " @ getword(%trans, 1) @ "  " @ getword(%trans, 2);
					//checkForStar(%obj, %rot, %pos);
					Player::decItemCount(%player,%item);
				}
				else
				{	
					GameBase::setActive(%player.station,false);
					Client::sendMessage(%clientID,0,"Resupply Stopped - Firing");
				}
			}
			else if (%clientId.AssBcn == 1)
			{
				%obj = newObject("","Mine","Detbomb");
 		 	 	addToSet("MissionCleanup", %obj);
				%obj.deployer = %clientId;
				GameBase::throw(%obj,%player,5,false);
				%player.throwTime = getSimTime() + 0.5;
				GameBase::setTeam(%obj,GameBase::getTeam(%clientID));
				Player::decItemCount(%player,%item);
			}
		}
	}
	
	else if(%armor == "earmor" || %armor == "efemale")
	{
	     if($TeamItemCount[GameBase::getTeam(%player) @ EngBeacons] < $TeamItemMax[EngBeacons])
		{
			if (!%clientId.EngBeacon || %clientId.EngBeacon == 0)
			{
				if (EngBeacon(%clientId, %player, %item))		// Standard Beacon
				{
					//$TeamItemCount[GameBase::getTeam(%player) @ "EngBeacons"]++;
					Client::sendMessage(%clientId,0,"Engineer Beacon Set");
					Player::decItemCount(%player,%item);
				}
				else return false;
			}
			if (%clientId.EngBeacon == 1)
			{
				if (EngCamera(%clientId, %player, %item))		//=== Eng. Camera
				{
					$TeamItemCount[GameBase::getTeam(%player) @ "EngBeacons"]++;				
					Client::sendMessage(%clientId,0,"Engineer Beacon Set");
				}
				else return false;
			}
	
			if (%clientId.EngBeacon == 3)
			{
				if($matchStarted)
				{
					if(%player.throwTime < getSimTime())
					{
						%obj = newObject("","Item",RepairKit,1,false,false);
						addToSet("MissionCleanup", %obj);
						%client = Player::getClient(%player);
						GameBase::throw(%obj,%clientID,25,false);
						%player.throwTime = getSimTime() + 0.5;
						GameBase::setTeam(%obj, GameBase::getTeam(%player));
						Client::sendMessage(%clientId,0,"MediKit Dropped");
						Player::decItemCount(%player,%item);
					}
					else return false;
				}
			}
		}
		else
			Client::sendMessage(%clientId,0,"Deployable Item limit reached");
			
	}
	else if (%armor == "sarmor" || %armor == "sfemale" || %armor == "stimarmor" || %armor == "stimfemale")
		ScoutStim(%clientId, %player, %item);								//=== Scout Sensor

	else if (%armor == "spyarmor" || %armor == "spyfemale")
	{
		if(!%clientId.ChemBeacon || %clientId.ChemBeacon == 0)
			DeploySatchel(%clientId, %player, %item);
		else if(%clientId.ChemBeacon == 1)
		{
			if (EngBeacon(%clientId, %player, %item))		// Standard Beacon
			{
					//$TeamItemCount[GameBase::getTeam(%player) @ "beacon"]++;
					Client::sendMessage(%clientId,0,"Targeting Beacon Set");
					Player::decItemCount(%player,%item);
			}
			else return false;
		}
	}
	else if (%armor == "jarmor")
	{
		if (player::getitemcount(%clientId, LasCannon) == 1)
		{
			if (%clientId.lasfired == 1 && %clientId.lascharge != 15)
			{
				Client::sendMessage(Player::getClient(%player),1,"Laser Refractor Cooling.~wfailpack.wav"); 
				return;
			}
			if (%clientId.charging == 1)
			{
				return;
			}
			else if (%clientId.charging = "" || !%clientId.charging)
			{
				LasCannoner::Charge(%clientId, 10);
				%clientId.charging = 1;
				Player::decItemCount(%player,%item);
			}		
		}
		else if (player::getitemcount(%clientId, PlasmaCannon) == 1)
		{
			if (%clientId.plasfired == 1 && %clientId.plasmacharge != 15)
			{
				Client::sendMessage(Player::getClient(%player),1,"Plasma Core Cooling.~wfailpack.wav"); 
				return;
			}
			if (%clientId.charging == 1)
			{
				return;
			}
			else if (%clientId.charging = "" || !%clientId.charging)
			{
				PlasmaCannoner::Charge(%clientId, 8);
				%clientId.charging = 1;
				Player::decItemCount(%player,%item);
			}				
		}
		else if (player::getitemcount(%clientId, Hammer1Pack) == 1)
		{

			%heat = %clientId.heatup;
			
			if (%clientId.heatup > 0)
			{
				%clientId.heatup = %clientId.heatup - 15;
				bottomprint(%clientId, "GodHammer Cannon Plasma Core Cooling Active! " @ %heat @ " %.");
				Player::decItemCount(%player,%item);
			}
			else
			{
				bottomprint(%clientId, "GodHammer Cannon Plasma Core Cooling - No Heat Build Up! " @ %heat @ " %.");	
			}	
		}
		else 
		{
			Client::sendMessage(%clientId,1,"** You Have No Heavy Weapon To Charge... ~waccess_denied.wav");
		}
		
	}

	else if (%armor == "marmor" || %armor == "mfemale")
	{
		if($matchStarted)
		{
			if(%player.throwTime < getSimTime())
			{	
				if (%clientId.boosted == 1)
				{
					Client::sendMessage(Player::getClient(%player),1,"Booster Cooling."); 
				}
				else
				{
					Player::trigger(%player,4,true);
					Player::trigger(%player,5,true);
					
					%ClientId.boosted = 1;
					%ClientId.boostercool = 1;
					%ClientId.boostpop = 0;
					
					if (%clientId.booster == 0 || !%clientId.booster) // Normal Boost
					{
						%mass=%armor.mass;
						%rot=GameBase::getRotation(%player);
						%len=50;
						%zlen=25;					
						%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
						Player::applyImpulse(%player,%vec);
						playSound(debrisMediumExplosion,gamebase::getposition(%player));
						Client::sendMessage(Player::getClient(%player),0,"You use a Speed Booster."); 
						Player::decItemCount(%player, %item);
						schedule ("" @ %ClientId @ ".boosted = \"False\";",2);
						schedule ("" @ %ClientId @ ".boostpop = \"0\";",4);
						schedule ("" @ %ClientId @ ".boostercool = \"False\";",4);
					}
					else // Directional / Advanced Boost = MethodX
					{
						%mass=%armor.mass;
						%len=50;
						%trans=GameBase::getMuzzleTransform(%player);
						%normvec=GetWord(%trans, 3) @ " " @ GetWord(%trans, 4) @ " " @ GetWord(%trans, 5);
						%rot=Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );
						%vec=Vector::getFromRot(%rot, %len*%mass, 0);
						Player::applyImpulse(%player,%vec);
						playSound(debrisMediumExplosion,gamebase::getposition(%player));
						Client::sendMessage(Player::getClient(%player),0,"You use a Speed Booster."); 
						Player::decItemCount(%player, %item);
						schedule ("" @ %ClientId @ ".boosted = \"False\";",2);
						schedule ("" @ %ClientId @ ".boostercool = \"False\";",6);
						schedule ("" @ %ClientId @ ".boostpop = \"0\";",6);
					}
					schedule ("Player::trigger(" @ %player @ ",4,false);",1,%player);
					schedule ("Player::trigger(" @ %player @ ",5,false);",1,%player);
				}
			}
		}
	}

	else if (%armor == "aarmor" || %armor == "afemale")
	{    
		Renegades_startCloak(%clientId, %player);
		%clientId.empTime = 0;
		Player::decItemCount(%player,%item);
	}

	else if (%armor == "barmor" || %armor == "bfemale")
	{
		if($matchStarted)
		{
			if(!%clientId.GolBeacon || %clientId.GolBeacon == 0)
			{
				if(%player.throwTime < getSimTime() )
				{
					%obj = newObject("","Mine","Concussion2");
					addToSet("MissionCleanup", %obj);
					%client = Player::getClient(%player);
					GameBase::throw(%obj,%client,20 * %client.throwStrength,false);
					%player.throwTime = getSimTime() + 0.15;
					Player::decItemCount(%player,%item);
				}
			}
			else if(%clientId.GolBeacon == 1)
			{
				if (EngBeacon(%clientId, %player, %item))		// Standard Beacon
				{
						//$TeamItemCount[GameBase::getTeam(%player) @ "beacon"]++;
						Client::sendMessage(%clientId,0,"Targeting Beacon Set");
						Player::decItemCount(%player,%item);
				}
				else return false;
			}
		}
	}	

	else if (%armor == "darmor" || %armor == "harmor")
	{
		Renegades_startShield(%clientId, %player); 
		Player::decItemCount(%player,%item);
	}
}

	
function DeploySatchel(%clientId, %player, %bec)
{
	if (deployable(%player,%bec,"Turret","SatchelPack",False,False,False,False,False,False,5,True,0, True, "DeployableSatchel", "SatchelPack"))
		Player::decItemCount(%player,%bec);
}

//==================================================================================================
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
/// Rewritten By Emo1313 - Per placement


ItemImageData AirAmmoPadPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};
ItemData AirAmmoPad
{
        description = "Air Ammo Pad";
        shapefile = "ammopack";
        classname = "Backpack";
        heading =  "mAir Deployables";
        imageType = AirAmmoPadPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.1;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function AirAmmoPad::onUse(%player,%item)
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

function AirAmmoPad::onDeploy(%player,%item,%pos)
{
        if (AirAmmoPad::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function AirAmmoPad::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
		if (!CheckForObjects(GameBase::getPosition(%player),15,15,10))
		{
			Client::sendMessage(%client,1,"Objects In The Way, Can not deploy.");
			return;
		}
		
                %playerPos = GameBase::getPosition(%player);
                %flag = $teamFlag[GameBase::getTeam(%player)];
                %flagpos = gamebase::getPosition(%flag);
                if(Vector::getDistance(%flagpos, %playerpos) > 10)
                {
			%camera = newObject("Spy Station","Staticshape",AirAmmoBasePad,true);
			addToSet("MissionCleanup", %camera);
			%rot = GameBase::getRotation(%player);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,GameBase::getPosition(%player));
			Gamebase::setMapName(%camera,"Spy Station" @  Client::getName(%client));
			Client::sendMessage(%client,0,"Air Ammo Station deployed");
			%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
			addToSet("MissionCleanup", %inv);
			GameBase::setTeam(%inv,GameBase::getTeam(%player));
			GameBase::setRotation(%inv,%rot);
			GameBase::setPosition(%inv,GameBase::getPosition(%player));
			Gamebase::setMapName(%inv,"Air Ammo Pad " @  Client::getName(%client));
			playSound(SoundPickupBackpack,$los::position);
			dbecho("MSG: ",%client," deployed an Air Ammo Pad ");
			return true;
                }
                else
                        Client::sendMessage(%client,0,"You are too close to your flag.");
                        return false;
        }

}

ItemImageData airbasePackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData airbase
{
	description = "AirBase";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading =  "mAir Deployables";
	imageType = airbasePackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function airbase::onUse(%player,%item)
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

function airbase::onDeploy(%player,%item,%pos)
{
        if (airbase::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function CreateAirBaseSet(%client)
{
    	%teleset = nameToID("MissionCleanup/AirBase" @ %client);
	if(%teleset == -1)
	{
		newObject("AirBase" @ %client,SimSet);
		addToSet("MissionCleanup","AirBase" @ %client);
		gamebase::setteam(%teleset, gamebase::getteam(%client));
	}
}

function airbase::deployshape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        
        %client = Player::getClient(%player);
	%playerPos = GameBase::getPosition(%player);
	%deploypos = Vector::add(GameBase::getPosition(%player), "-0 -0 50.50");

	%number = $TeamItemCount[GameBase::getTeam(%player) @ "airbase"];

	if (!CheckForObjects(%deploypos,45,45,25))
	{
		Client::sendMessage(%client,1,"Objects In The Way, Can not deploy.");
		return false;
	}
	
	CreateAirBaseSet(%client);

	//================== Airbase platforms
	%name1 = "Sensor" @ Client::getName(%client) @ "" @ %number;
	%name2 = "StationGenerator" @ Client::getName(%client) @ "" @ %number;
	%name3 = "CommandStation" @ Client::getName(%client) @ "" @ %number;
	%name4 = "InventoryStation" @ Client::getName(%client) @ "" @ %number;
	%name5 = "VehiclePad" @ Client::getName(%client) @ "" @ %number;
	%name6 = "VehicleStation" @ Client::getName(%client) @ "" @ %number;
	
	%plat1 = "Platform1";
	%plat2 = "Platform2";
	%plat3 = "Platform3";
	%plat4 = "Platform4";


	//=== Bottom Platforms
	instant StaticShape %plat2
	{
		dataBlock = "LargeAirBasePlatform";
		name = %plat2;
		position = Vector::add(GameBase::getPosition(%player), "6.75 -0 50.00");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
		destroyable = "True";
		deleteOnDestroy = "True";
		VehiclePad = %name5;
		team = GameBase::getTeam(%player);
	};

	instant StaticShape %plat3
	{
		dataBlock = "LargeAirBasePlatform";
		name = %plat3;
		position = Vector::add(GameBase::getPosition(%player), "-6.75 -5.0 50.00");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
		destroyable = "True";
		deleteOnDestroy = "True";
		VehiclePad = %name5;
		team = GameBase::getTeam(%player);
	};
	
	//=== Top platforms
	instant StaticShape %plat1
	{
		dataBlock = "LargeAirBasePlatform";
		name = %plat1;
		position = Vector::add(GameBase::getPosition(%player), "-6.75 -9.5 58.00");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
		destroyable = "True";
		deleteOnDestroy = "True";
		VehiclePad = %name5;
		team = GameBase::getTeam(%player);
	};

	instant StaticShape %plat4
	{
		dataBlock = "LargeAirBasePlatform";
		name = %plat4;
		position = Vector::add(GameBase::getPosition(%player), "6.75 -4.5 58.00");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
		destroyable = "True";
		deleteOnDestroy = "True";
		VehiclePad = %name5;
		team = GameBase::getTeam(%player);
	};

	//=================== Airbase Radar
	instant Sensor %name1
	{
		dataBlock = "PulseSensor";
		name = %name1;
		position = Vector::add(GameBase::getPosition(%player), "-0 -6.0 58.50");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
		destroyable = "True";
		deleteOnDestroy = "False";
		team = GameBase::getTeam(%player);
	};
	instant StaticShape %name5
	{
		dataBlock = "VehiclePad";
		name = %name5;
		position = Vector::add(GameBase::getPosition(%player), "8 -4 59.2");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
		destroyable = "True";
		deleteOnDestroy = "False";
		team = GameBase::getTeam(%player);
	};

	instant StaticShape %name6
	{
		dataBlock = "VehicleStation";
		name = %name6;
		position = Vector::add(GameBase::getPosition(%player), "-8 -9 58.50");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
		destroyable = "True";
		deleteOnDestroy = "False";
		VehiclePad = %name5;
		team = GameBase::getTeam(%player);
	};
	//=================== Air base Gen
	instant StaticShape %name2
	{
		dataBlock = "PortGenerator";
		name = %name2;
		position = Vector::add(GameBase::getPosition(%player), "-0 -3.0 50.40");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
		destroyable = "True";
		deleteOnDestroy = "False";
		team = GameBase::getTeam(%player);
	};

	//=================== Command Station
	instant StaticShape %name3
	{
		dataBlock = "CommandStation";
		name = %name3;
		position = Vector::add(GameBase::getPosition(%player), "-7 -5 50.40");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
		destroyable = "True";
		deleteOnDestroy = "False";
		team = GameBase::getTeam(%player);
	};

	//=================== Invo Station
	instant StaticShape %name4
	{
		dataBlock = "InventoryStation";
		name = %name4;
		position = Vector::add(GameBase::getPosition(%player), "5 0 50.40");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
		destroyable = "True";
		deleteOnDestroy = "False";
		team = GameBase::getTeam(%player);
	};


	addToSet("MissionCleanup/AirBase" @ %client,%name1);
	addToSet("MissionCleanup/AirBase" @ %client,%name2);
	addToSet("MissionCleanup/AirBase" @ %client,%name3);
	addToSet("MissionCleanup/AirBase" @ %client,%name4);
	addToSet("MissionCleanup/AirBase" @ %client,%name5);
	addToSet("MissionCleanup/AirBase" @ %client,%name6);
	addToSet("MissionCleanup/AirBase" @ %client,%plat1);
	addToSet("MissionCleanup/AirBase" @ %client,%plat2);
	addToSet("MissionCleanup/AirBase" @ %client,%plat3);
	addToSet("MissionCleanup/AirBase" @ %client,%plat4);

	addToSet("MissionCleanup",%name1);
	addToSet("MissionCleanup",%name2);
	addToSet("MissionCleanup",%name3);
	addToSet("MissionCleanup",%name4);
	addToSet("MissionCleanup",%name5);
	addToSet("MissionCleanup",%name6);
	addToSet("MissionCleanup",%plat1);
	addToSet("MissionCleanup",%plat2);
	addToSet("MissionCleanup",%plat3);
	addToSet("MissionCleanup",%plat4);

	%n1 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %name1));
	%n2 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %name2));
	%n3 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %name3));
	%n4 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %name4));
	%n5 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %name5));
	%n6 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %name6));
	%n6.vehiclePad = %n5;
	%n7 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %plat1));
	%n8 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %plat2));
	%n9 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %plat3));
	%n10 = (nametoId("MissionCleanup/AirBase" @ %client @ "/" @ %plat4));
	//%n11 = (nametoId("MissionCleanup/RepairPack1"));

	%n1.base = "true";
	%n2.base = "true";
	%n3.base = "true";
	%n4.base = "true";
	%n5.base = "true";
	%n6.base = "true";
	%n7.base = "true";
	%n8.base = "true";
	%n9.base = "true";
	%n10.base = "true";

	gamebase::setteam(%n1, gamebase::getteam(%client));
	gamebase::setteam(%n2, gamebase::getteam(%client));
	gamebase::setteam(%n3, gamebase::getteam(%client));
	gamebase::setteam(%n4, gamebase::getteam(%client));
	gamebase::setteam(%n5, gamebase::getteam(%client));
	gamebase::setteam(%n6, gamebase::getteam(%client));

	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "airbase"]++;
	Client::sendMessage(%client,1,"Air Base Deployed.");
	return true;
}


//=================================================================================================== Launch Pad

ItemImageData LaunchPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = {0, -0.03, 0};
	mass = 2.5;
	firstPerson = false;
};

 ItemData LaunchPack 
 {
 	description = "Launch Pad";
 	shapeFile = "AmmoPack";
 	className = "Backpack";
	heading = "sPersonnel Movers";
 	imageType = LaunchPackImage;
 	shadowDetailMask = 4;
 	mass = 1.0;
 	elasticity = 0.2;
 	price = 500;
 	hudIcon = "deployable";
 	showWeaponBar = true;
 	hiliteOnActive = true;
 };

 function LaunchPack::onUse(%player,%item)
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
 
 function LaunchPack::onDeploy(%player,%item,%pos)
 {
 	if (LaunchPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
 }
	
	
function LaunchPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	 {
		 if (GameBase::getLOSInfo(%player,3))
		 {
			 %obj = getObjectType($los::object);
			 if (%obj == "SimTerrain" || %obj == "InteriorShape")
			 {
				%set = newObject("launchset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableCactus",%num);
				deleteObject(%set);
				 if (Vector::dot($los::normal,"0 0 1") > 0.7)
				 {
					 if(checkDeployArea(%client,$los::position))
					 { 
						%rot = GameBase::getRotation(%player);
						%phase = newObject("","StaticShape",DeployableLaunch,true);
						addToSet("MissionCleanup", %phase);
						GameBase::setTeam(%phase,GameBase::getTeam(%player));
						GameBase::setPosition(%phase,$los::position);
						GameBase::setRotation(%phase,%rot);
						Gamebase::setMapName(%phase,"Launchboard");
						Client::sendMessage(%client,0,"Launchboard Deployed");
						GameBase::startFadeIn(%phase);
						playSound(SoundPickupBackpack,$los::position);
						playSound(ForceFieldOpen,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "LaunchPack"]++;
						return true;						
					 }
				 }
				 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			 }
			 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		 }
		 else Client::sendMessage(%client,0,"Deploy position out of range");
	 }
	 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	 return false;
 }
//=================================================================================================== Accel Pad


ItemImageData AccelPPackImage
{
	shapeFile = "shieldpack";
	mountPoint = 2;
	firstPerson = false;
};

ItemData AccelPPack
{
	description = "Accelerator Pad";
	shapeFile = "elevator_6x6_octagon";
	className = "Backpack";
	heading = "sPersonnel Movers";
	imageType = AccelPPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 950;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AccelPPack::onUse(%player,%item)
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

function AccelPPack::onDeploy(%player,%item,%pos)
{
	if (AccelPPack::deployShape(%player,"AccelPad",AccelPadPack,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"]++;
	}
}

function AccelPPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"] < $TeamItemMax[AccelPPack])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				%this = newObject("AccelPadPack","StaticShape",%shape,true);

				//%teleset = nameToID("MissionCleanup/AccelPadPack");
				//if(%teleset == -1)
				//{
				//	newObject("AccelPadPack",SimSet);
				//	addToSet("MissionCleanup","AccelPadPack");
				//}
				//addToSet("MissionCleanup/AccelPadPack", %this);

				addToSet("MissionCleanup", %this);
				GameBase::setTeam(%this,GameBase::getTeam(%player));
				%pos = Vector::add($los::position,"0 0 -0.25");
				GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
				%Rot=GameBase::getRotation(%player);
				%Rot=Vector::add(%Rot,"0 0 3.14159");
				GameBase::setRotation(%this,%rot);
				GameBase::setPosition(%this,%pos);
				Gamebase::setMapName(%this,"Accel Pad");
				Client::sendMessage(%client,0,%item.description @ " deployed");
				//dbecho("MSG: ",%client," deployed an Accelerator Pad ");
				%this.disabled = 0;
				%this.activated = 0;
				GameBase::startFadeIn(%this);
				playSound(SoundPickupBackpack,$los::position);
				return true;
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

//======================================================================== Engineer Repair Gun - Hacking Option

ItemImageData HackitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "HackBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Hackit
{
	description   = "Engineer Hack-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    	heading = "tEngineer Items";
	shadowDetailMask = 4;
	imageType     = HackitImage;
	price         = 350;
	showWeaponBar = true;
};

//======================================================================== Engineer Repair Gun - Hacking Option

ItemImageData DisItImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "DisaBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DisIt
{
	description   = "Engineer Disassymbler-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    	heading = "tEngineer Items";
	shadowDetailMask = 4;
	imageType     = DisItImage;
	price         = 350;
	showWeaponBar = true;
};


//======================================================================== Regeneration Gun
ItemImageData RegenImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = "DrainBolt";
	minEnergy = 5;
	maxEnergy = 12;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Regen
{
	description   = "Regeneration Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = RegenImage;
	price         = 350;
	showWeaponBar = true;
};


//================================================== Missile Items

ItemImageData CoolLauncherImage 
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = {0, -0.1, -0.06 };
	mountRotation = {0, 0, 0};
	firstPerson = false;
};

ItemData CoolLauncher 
{
	description = "Missile Control Station";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "uGuided Missiles";
	imageType = CoolLauncherImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function CoolLauncher::onUse(%player,%item) 
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


function CoolLauncher::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>The Missile Control Station has no remote control and must be controlled manually to fire.");
}

function CoolLauncher::onDeploy(%player,%item,%pos) 
{
	if (CoolLauncher::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	}
}

function CoolLauncher::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,4)) 
		{
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);			
			
			if (%obj == "SimTerrain" || %obj == "InteriorShape"){}
			else if (%datab == "LargeEmplacementPlatform")
			{}else
			{
				Client::sendMessage(%client,1,"Can only deploy on terrain or buildings...");
				return;
			}
				if (Vector::dot($los::normal,"0 0 1") > 0.94) 
				{
					if(checkDeployArea(%client,$los::position)) 
					{
						%prot = GameBase::getRotation(%player);
						%zRot = getWord(%prot,2);
						if (Vector::dot($los::normal,"0 0 1") > 0.6) 
						{
							%rot = "0 0 " @ %zRot;
						}
						else 
						{
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
							{
								%rot = "3.14159 0 " @ %zRot;
							}
							else 
							{
								%rot = Vector::getRotation($los::normal);
							}
						}
						%rot = GameBase::getRotation(%player);
						%forward = Vector::getFromRot(%rot, 2);
						%pos = Vector::add($los::position, %forward);
						%turret = newObject("remoteTurret","Turret",DeployableCoolMortar,true);
						addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,%pos);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Missile Control Station");
						Client::sendMessage(%client,0,"Missile Control Station deployed");
						%inv = newObject("comunit_remote", "StaticShape", "DeployableCoolStation", true);
						addToSet("MissionCleanup", %inv);
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						%backward = Vector::neg(Vector::getFromRot(%rot, 2.5));
						GameBase::setPosition(%inv,Vector::add(%pos, %backward));
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Missile Control Station");
						%turret.comstation = %inv;
						%turret.load = "CoolProj";
						%inv.comstation = %turret;
						playSound(SoundPickupBackpack,$los::position);
						return true;
					}
				}
				else Client::sendMessage(%client,0,"Can only deploy on very flat surfaces");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//================================================================================== Varrious Missile Data

$vm[PhoenixM] = CoolProj;
$vm[NapM] = NapProj;
$vm[BooM] = BooProj;
$vm[EmpM] = EmpProj;
$vm[GasM] = GasProj;
$vm[SpyPod] = SpyPodProj;

ItemImageData PhoenixMImage 
{
	shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = {0, -0.1, -0.3 };
	mountRotation = {0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

//========================================================================= Emp Damage Missile
ItemData EmpM 
{
	description = "EMP Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EmpM::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}


//========================================================================= Poison Damage Missile
ItemData GasM 
{
	description = "Toxin Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GasM::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================================================================= Pheonix Missile	
ItemData PhoenixM 
{
	description = "Phoenix Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PhoenixM::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================================================================= Napalm, fire damage missile
ItemData NapM 
{
	description = "Napalm Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NapM::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================================================================= Boom/Explosion Missile
ItemData BooM 
{
	description = "HaVoC Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BooM::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 

	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}	
//========================================================================= Boom/Explosion Missile
ItemData SpyPod
{
	description = "SpyPod Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpyPod::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}




//================================================================================================ DetBug
ItemData DetBug
{	
	description = "Det Bug";
	className = "Ammo";
	shapeFile = "armorPatch";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
  	price = 2;
};

//==================================================================================================== Plastique Deploy

ItemData Plastique
{
   description = "Plastique";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Plastique::onUse(%player,%item)
{
	if($matchStarted) 
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Nukebomb");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%client,4 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in " @ %player.Plastic @ " seconds"); 
		}
	}

}

//==================================================================================================== Repair Patch
ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
    	heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
	
	validateShape = true;
	validateMaterials = true;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") 
	{
		if(GameBase::getDamageLevel(%object)) 
		{
			RepairPatch::onUse(%object, %this);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	dbecho ("Use Patch");

	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);
	
	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	

	if (%clientId.poisonTime)
	{
		%clientId.poisonTime =0;
	        bottomprint(%clientId, "<jc><f2>Poison cured.", 5);	
	}

	if (%armor == "sarmor" || %armor == "sfemale"  || %armor == "stimarmor" || %armor == "stimfemale")
	{		
		if (%clientId.ovd > 15)
		{	
			%overd = %clientId.ovd;
			
			dbecho ("OD- " @ %clientId.ovd @ "");
			dbecho ("O1- " @ %overd @ "");
			%repair = (20 + floor(getRandom() * 25));
			%clientId.ovd = %clientId.ovd - %repair;
			if (%clientId.ovd < 0)
			{
				%clientId.ovd = 0;
			        bottomprint(%clientId, "<jc><f2>Over Dose Down to " @ %clientId.ovd @ "%.", 5);	
			}

			dbecho ("AD- " @ %clientId.ovd @ "");
		        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Decreased from " @ %overd @ " to " @ %clientId.ovd @ "%.", 5);	
	        }	        
		GameBase::repairDamage(%player,0.1);
	}
	
	else if(%armor == "larmor" || %armor == "lfemale")
	{
		GameBase::repairDamage(%player,0.1);
	}
	else if(%armor == "earmor" || %armor == "efemale")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "spyarmor" || %armor == "spyfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "aarmor" || %armor == "afemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "harmor")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "barmor" || %armor == "bfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "darmor")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else
	{
		GameBase::repairDamage(%player,0.1);
	}
}

//============================================================================================== Defense Emplacement
$TeamItemMax[EmplacementPack] = 2;
$InvList[EmplacementPack] = 1;
$RemoteInvList[EmplacementPack] = 1;
$CanAlwaysTeamDestroy[EmplacementPack] = 1;

ItemImageData EmplacementPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, 0, -0.5 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData EmplacementPack
{
        description = "Emplacement";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "eDefensive";
        shadowDetailMask = 4;
        imageType = EmplacementPackImage;
        mass = 2.0;
        elasticity = 0.2;
        price = 300;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function EmplacementPack::onUse(%player,%item)
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

function EmplacementPack::rotVector(%vec,%rot)
{
	// this function rotates a vector about the z axis

	%vec_x = getWord(%vec,0);
	%vec_y = getWord(%vec,1);
	%vec_z = getWord(%vec,2);

	// new vector with z axis removed
	%basevec = %vec_x @ "  " @ %vec_y @ "  0";
	
	// change vector to distance and rotation
	%basedis = Vector::getDistance( "0 0 0", %basevec);
	%normvec = Vector::normalize( %basevec );
	%baserot = Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );

	// modify rotation and change back to vector (put z axis offset back)
	%newrot = Vector::add( %baserot, %rot );
	%newvec = Vector::getFromRot( %newrot, %basedis, %vec_z );

	return %newvec;
}


function EmplacementPack::onDeploy(%player,%item,%pos)
{
	if (EmplacementPack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function EmplacementPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        //if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        //{
                if (GameBase::getLOSInfo(%player,6))
                {
                        %obj = getObjectType($los::object);

                        if (!CheckForObjects($los::position))
                        {
                                Client::sendMessage(%client,1,"Objects In The Way, Can not deploy.");
                        	return;
                        }
                        
                        if (%obj == "SimTerrain")
                        {
                                if (Vector::dot($los::normal,"0 0 1") > 0.8)
                                {
					%number = $TeamItemCount[GameBase::getTeam(%player) @ "EmplacementPack"];

					%cname = "Emplacement" @ Client::getName(%client) @ "" @ %number;
					%name1 = "Emplacement1" @ Client::getName(%client) @ "" @ %number;
					%name3 = "Emplacement2" @ Client::getName(%client) @ "" @ %number;
					%name2 = "StationGenerator" @ Client::getName(%client) @ "" @ %number;
					%name4 = "InventoryStation" @ Client::getName(%client) @ "" @ %number;

					%ff1 = "ForceField1" @ Client::getName(%client) @ "" @ %number;
					%ff2 = "ForceField2" @ Client::getName(%client) @ "" @ %number;
					%ff3 = "ForceField3" @ Client::getName(%client) @ "" @ %number;
					%ff4 = "ForceField4" @ Client::getName(%client) @ "" @ %number;
					%ff5 = "ForceField5" @ Client::getName(%client) @ "" @ %number;

					instant SimGroup %cname
					{
						instant StaticShape %name1
						{
							dataBlock = "LargeEmplacementPlatform";
							name = %plat1;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 2 0.4", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "True";
							VehiclePad = %name5;
							team = GameBase::getTeam(%player);
						};

						instant StaticShape %name3
						{
							dataBlock = "LargeEmplacementPlatform";
							name = %plat2;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 2 5.2", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "True";
							VehiclePad = %name5;
							team = GameBase::getTeam(%player);
						};

						instant StaticShape %name4
						{
							dataBlock = "InventoryStation";
							name = %name4;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 3.75 0.9", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "False";
							team = GameBase::getTeam(%player);
						};

						instant StaticShape %name2
						{
							dataBlock = "PortGenerator";
							name = %name2;
							position = Vector::add(GameBase::getPosition(%player), "0 0 -15");
							rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "False";
							team = GameBase::getTeam(%player);
						};
						
						instant StaticShape %ff1
						{
							dataBlock = "ForceField3";
							name = %name2;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 7.15 0.9", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = GameBase::getTeam(%player);
						};

						instant StaticShape %ff2
						{
							dataBlock = "ForceField3";
							name = %name2;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "-5.25 3.5 0.9", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = GameBase::getTeam(%player);
						};						

						instant StaticShape %ff3
						{
							dataBlock = "ForceField3";
							name = %name2;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "5.25 3.5 0.9", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 -1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = GameBase::getTeam(%player);
						};	
						instant StaticShape %ff4
						{
							dataBlock = "ForceField1";
							name = %name2;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "-5.75 -1.40 1", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 -1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = GameBase::getTeam(%player);
						};	
						instant StaticShape %ff5
						{
							dataBlock = "ForceField1";
							name = %name2;
							position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "5.75 -1.40 1", GameBase::getRotation(%player) ) );
							rotation = Vector::add( GameBase::getRotation(%player), "0 0 1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = GameBase::getTeam(%player);
						};	

					};


				addToSet("MissionCleanup",%cname@"/"@%name1);
				addToSet("MissionCleanup",%cname@"/"@%name2);
				addToSet("MissionCleanup",%cname@"/"@%name3);
				addToSet("MissionCleanup",%cname@"/"@%name4);

				%n1 = (nametoId("MissionCleanup/" @ %name1));
				%n2 = (nametoId("MissionCleanup/" @ %name2));
				%n3 = (nametoId("MissionCleanup/" @ %name4));
				%n4 = (nametoId("MissionCleanup/" @ %name3));
				gamebase::setteam(%n1, gamebase::getteam(%client));
				gamebase::setteam(%n2, gamebase::getteam(%client));
				gamebase::setteam(%n3, gamebase::getteam(%client));
				gamebase::setteam(%n4, gamebase::getteam(%client));
				addToSet("MissionCleanup",%cname@"/"@%ff1);%f1 = (nametoId("MissionCleanup/" @ %ff1));gamebase::setteam(%f1, gamebase::getteam(%client));
				addToSet("MissionCleanup",%cname@"/"@%ff2);%f2 = (nametoId("MissionCleanup/" @ %ff2));gamebase::setteam(%f2, gamebase::getteam(%client));
				addToSet("MissionCleanup",%cname@"/"@%ff3);%f3 = (nametoId("MissionCleanup/" @ %ff3));gamebase::setteam(%f3, gamebase::getteam(%client));
				addToSet("MissionCleanup",%cname@"/"@%ff4);%f4 = (nametoId("MissionCleanup/" @ %ff4));gamebase::setteam(%f4, gamebase::getteam(%client));
				addToSet("MissionCleanup",%cname@"/"@%ff5);%f5 = (nametoId("MissionCleanup/" @ %ff5));gamebase::setteam(%f5, gamebase::getteam(%client));

				%n1.base = true;
				%n2.base = true;
				%n3.base = true;
				%n4.base = true;
				%f1.base = true;
				%f2.base = true;
				%f3.base = true;
				%f4.base = true;
				%f5.base = true;

                                $TeamItemCount[GameBase::getTeam(%player) @ "EmplacementPack"]++;
                                %playerpos = GameBase::getPosition(%player);
				%newplayerpos = Vector::add(%playerpos, "0 0 0.2");
				GameBase::setPosition(%player,%newplayerpos);

                                return true;
                                }
                                else
                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain.");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
       // }
       // else
       //          Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
                 return false;
}

//============================================================================================== Large Shock Force Field
ItemImageData LargeShockForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeShockForceFieldPack
{
	description = "Large Shock Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "eDefensive";
	imageType = LargeShockForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeShockForceFieldPack::onUse(%player,%item)
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

function LargeShockForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeShockForceFieldPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}



function LargeShockForceFieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Large Shock Force Field",True,False,False,False,False,False,4,True,0, True, "LargeShockForceField", "LargeShockForceFieldPack");
}


//=========================================================================== Arbitor Beacon
ItemImageData ArbitorBeaconPackImage
{
	shapeFile = "plasammo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ArbitorBeaconPack
{
	description = "Arbitor Device";
	shapeFile = "plasammo";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = ArbitorBeaconPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ArbitorBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Arbitor Beacon Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ArbitorBeaconPack::onDeploy(%player,%item,%pos)
{
	if (ArbitorBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ArbitorBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","ArbitorBeacon",False,False,False,False,False,True,5,True,25,True, "ArbitorBeacon", "ArbitorBeaconPack");
}

//======================================================================================== EMP Beacon
ItemImageData EMPBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData EMPBeaconPack
{
	description = "EMP Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = EMPBeaconPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function EMPBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The EMP Beacon Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function EMPBeaconPack::onDeploy(%player,%item,%pos)
{
	if (EMPBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function EMPBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","EMPBeacon",True,False,True,False,True,False,5,True,25,True, "EMPBeacon", "EMPBeaconPack");
}

//======================================================================================== Shield Beacon
ItemImageData ShieldBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ShieldBeaconPack
{
	description = "Shield Device";
	shapeFile = "bridge";
	className = "Backpack";
   heading = "lArea Effect Items";
	imageType = ShieldBeaconPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ShieldBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		bottomprint(Player::getClient(%player), "<jc><f2>The Shield Beacon Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ShieldBeaconPack::onDeploy(%player,%item,%pos)
{
	if (ShieldBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShieldBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","ShieldBeacon",True,False,True,False,True,False,5,True,25,True, "ShieldBeacon", "ShieldBeaconPack");
}

//======================================================================================== Power Generator
ItemImageData PowerGeneratorPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PowerGeneratorPack
{
	description = "Power Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = PowerGeneratorPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PowerGeneratorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Power Generator Will Power Your Team Equipment.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function PowerGeneratorPack::onDeploy(%player,%item,%pos) { if (PowerGeneratorPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function PowerGeneratorPack::deployShape(%player,%item)
{
	%object = (deployable(%player,"PortGenerator","StaticShape","PortGenerator",True,False,True,False,True,False,5,False,0,False, "PortGenerator", "PowerGeneratorPack"));
	if (%object)
	{
		gamebase::setteam(%object, gamebase::getteam(%player));
		addToSet("MissionCleanup", %object);
		addToSet("MissionGroup/Teams/Team" @ gamebase::getteam(%player), %object);
	}
}

//======================================================================== Las-Cannon
ItemImageData LasCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.2, -0.8, 0.4 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	//projectileType = "UNDEFINED";
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 140;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	mass = 2.5;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LasCannon
{
	description = "LasCannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LasCannonImage;
	price = 2000;
	mass = 2.5;
	showWeaponBar = true;
};

function LasCannonImage::onFire(%player, %slot) 
{
	%clientId = player::getclient(%player);
	if (%clientId.lascharge)
	{
		%clientId.charging = "";
		%lc = %clientId.lascharge;
		%armor = Player::getArmor(%player); %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); %pos = (gamebase::getposition(%player));	 %rot = (gamebase::getrotation(%player)); %dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1,%player);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15,%player);
			schedule ("Projectile::spawnProjectile(LasCannonShock1, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2,%player);		
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1,%player);
			schedule ("Projectile::spawnProjectile(LasCannonShock2, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.15,%player);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.4,%player);
			schedule ("Projectile::spawnProjectile(LasCannonShock3, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.45,%player);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.3,%player);
			schedule ("Projectile::spawnProjectile(LasCannonShock1, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35,%player);		
		}
		
		if (%lc == 15)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35,%player);
			schedule ("Projectile::spawnProjectile(LasCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.375,%player);
			schedule ("Projectile::spawnProjectile(LasCannonShock2, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35,%player);
		}
		schedule ("" @ %ClientId @ ".lasfired = 0;",1.0,%client);
		%ClientId.lasfired = 1;
		%clientId.lascharge = "0";
		return;
	}
	else
	{
		Client::sendMessage(%clientId,1,"** LasCannon Uses Beacons To Charge... ~waccess_denied.wav");
		return;
	}
}

function LasCannoner::Charge(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	%plDead = Player::isDead(%player);
	if(!%plDead) Player::mountItem(%clientId, LasCannon, $WeaponSlot);
	
	if (!%clientId.charging)
		return;
	
	if (%time > 0)
	{
		%time--;
		schedule("LasCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0,%clientId);
		Client::sendMessage(%clientId,1,"** LasCannon Charging Done In " @ %time @ "~wenergypackon.wav");
		%clientId.lascharge++;
		return;
	}
	else
	{
		Client::sendMessage(%clientId,1,"** LasCannon Fully Charged ~wpda_on.wav");
		BottomPrint (%clientId, "You have 15 seconds to fire the LasCannon before overload..." , 5);
		%clientId.lascharge = 15;
		LasCannoner::Detonate(%clientId, 15);
		return;
	}
}

function LasCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	%plDead = Player::isDead(%player);
	if(!%plDead) Player::mountItem(%clientId, LasCannon, $WeaponSlot);
	
	if (%clientId.lascharge != 15)
		return;

	if (%time > 0 && Player::getItemCount(%player, LasCannon))
	{
		%time--;
		schedule("LasCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0,%clientId);
	}
	else //=== Player Detonates On Zero
	{
		%clientId.charging = "";
		%clientId.lascharge = "0";
		//Player::blowUp(%clientId);
			
			%obj = newObject("","Mine","HavocBlast");
			GameBase::throw(%obj,%clientId,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 1.5";
			%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
			GameBase::setPosition(%obj, %pos);
		return;
	}
	if (%time > 0 && %time < 6)
	{
		Client::sendMessage(%clientId,1,"~waccess_denied.wav");
		bottomprint (%clientId, "<jc>** LasCannon OverLoad In " @ %time @ " **");
	}
}


//=============================================
// MegaWeapons Add-On For Shifter
//=============================================

	
//======================================================================== Las-Cannon
ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mass = 2;
	mountPoint = 0;
	mountOffset = { 0.2, -0.8, 0.4 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	//projectileType = "Undefined";
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 140;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	//sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData PlasmaCannon
{
	description = "HeavyPlasmaCannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 2400;
	showWeaponBar = true;
	mass = 2.5;
};

function PlasmaCannonImage::onFire(%player, %slot) 
{
	%clientId = player::getclient(%player);
	if (%clientId.plasmacharge)
	{
		%clientId.charging = "";
		%lc = %clientId.plasmacharge;
		
		%armor = Player::getArmor(%player);
		%client = GameBase::getOwnerClient(%player); 
		%trans = GameBase::getMuzzleTransform(%player); 
		%vel = Item::getVelocity(%player);
		%pos = (gamebase::getposition(%player));
		//%rot = (gamebase::getrotation(%player));
		//%dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1,%player);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1,%player);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.39,%player);		
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15,%player);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.425,%player);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1,%player);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.475,%player);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35,%player);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5,%player);		
		}
		
		if (%lc == 15)
		{
			schedule ("FireHeavyPlasma(\"" @ %trans @ "\", \"" @ %player @ "\");",0.2,%player);
			schedule ("FireHeavyPlasma(\"" @ %trans @ "\", \"" @ %player @ "\");",0.63,%player);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1,%player);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15,%player);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.65,%player);
		}
			//%fired.deployer = %client;

		schedule (%clientId @ ".plasfired = \"False\";",1.0,%client);
		%ClientId.plasfired = 1;
		%clientId.plasmacharge = "0";
	}
	else
	{
		Client::sendMessage(%clientId,1,"** PlasmaCannon Uses Beacons To Charge... ~waccess_denied.wav");
	}
}

function PlasmaCannoner::Charge(%clientId, %time)
{
	%player = client::getcontrolobject(%clientId);
	%plDead = Player::isDead(%player);
	if(!%plDead) Player::mountItem(%player, PlasmaCannon, $WeaponSlot);

	if (!%clientId.charging)
		return;
	
	if (%time > 0)
	{
		%time--;
		schedule("PlasmaCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0,%clientId);
		Client::sendMessage(%clientId,1,"** PlasmaCannon Charging Done In " @ %time @ "~wenergypackon.wav");
		%clientId.plasmacharge++;
		return;
	}
	else
	{
		Client::sendMessage(%clientId,1,"** PlasmaCannon Fully Charged ~wpda_on.wav");
		BottomPrint (%clientId, "You have 15 seconds to fire the PlasmaCannon before overload..." , 5);
		%clientId.plasmacharge = 15;
		PlasmaCannoner::Detonate(%clientId, 15);
		return;
	}
}

function PlasmaCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	%plDead = Player::isDead(%player);
	if(!%plDead) Player::mountItem(%player, PlasmaCannon, $WeaponSlot);
	
	if (%clientId.plasmacharge != 15)
		return;

	if (%time > 0 && Player::getItemCount(%player, PlasmaCannon))
	{
		%time--;
		schedule("PlasmaCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0,%clientId);
	}
	else
	{
		%clientId.charging = "";
		%clientId.plasmacharge = "0";
		//Player::blowUp(%clientId);
			%obj = newObject("","Mine","HavocBlast");
			GameBase::throw(%obj,%clientId,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 1.5";
			%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
			GameBase::setPosition(%obj, %pos);
  		GameBase::applyDamage(%player, $PlasmaDamageType, 5, "0 0 0", "0 0 0", "0 0 0", %clientId);
		return;
	}
	if (%time > 0 && %time < 6)
	{
		Client::sendMessage(%clientId,1,"~waccess_denied.wav");
		bottomprint (%clientId, "<jc>** PlasmaCannon OverLoad In " @ %time @ " **");
	}
}

//=====================================================================================
//======================================================================== PlasmaCannon

RocketData PlasmaCannonBolt
{ 
	bulletShapeName = "plasmaex.dts"; 
	explosionTag = boosterExp; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 1;
    	damageValue = 0.8; 
	damageType = $PlasmaDamageType;
	explosionRadius = 15; 
	kickBackStrength = 0.0; 
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 45.0;
	totalTime = 5.0; 
	liveTime = 5.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.0, 0.05 }; 
	inheritedVelocityScale = 0.0; 
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonBolt2
{ 
	bulletShapeName = "plasmabolt.dts"; 
	explosionTag = plasmaExp; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 1;
    	damageValue = 0.5; 
	damageType = $PlasmaDamageType;
	explosionRadius = 10; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 35.0; 
	terminalVelocity = 45.0;
	acceleration = 35; 
	totalTime = 5.0; 
	liveTime = 5.0; 
	lightRange = 5.0; 
	lightColor = { 2.0, 0.0, 0.0 }; 
	inheritedVelocityScale = 0.0; 
	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 180.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock
{
	bulletShapeName  = "plasmabolt.dts";
	explosionTag     = grenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 140.0;
	//soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock2
{
	bulletShapeName  = "plasmaex.dts";
	explosionTag     = quietGrenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 65.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 160.0;
	//soundId = SoundJetHeavy;
};

function FireHeavyPlasma(%trans, %player)
{
	%this = (Projectile::spawnProjectile(PlasmaCannonShock2, %trans,%player,"0 0 -1"));
	%pos = gamebase::getposition(%this);
	%this.check = 1;
	checkForHP(%this, %player, %pos);
	//echo("FIRE! This: " @ %this);
}

function checkForHP(%this, %player, %pos)
{	
	if(%this.check)
	{	//echo("check");
		%pos = gamebase::getposition(%this);
		schedule("checkForHP(\"" @ %this @ "\", \"" @ %player @ "\", \"" @ %pos @ "\");", 0.2);
	}
	else
	{	//echo("FRAGS AWAY!! - Player: " @ %player @ " - This: " @ %this); 
		%client = Player::getClient(%player);
		%plDead = Player::isDead(%player);
		if(%player && !%plDead)
		{
			for(%i = 0; %i < 10; %i++)
			{
				%frag = "Frag" @ (floor(getRandom()*3)+1);
				%obj = newObject("","Mine", %frag);
				%obj.deployer = %client;
				addToSet("MissionCleanup", %obj);
				if ((floor(getRandom()*4)+1) > 2)
				{
					if ((floor(getRandom()*4)+1) > 3)
						GameBase::throw(%obj,%client,120,false);
					else
						GameBase::throw(%obj,%client,120,true);
				}
				else
				{
					if ((floor(getRandom()*4)+1) > 3)
						GameBase::throw(%obj,%client,-80,false);
					else
						GameBase::throw(%obj,%client,-80,true);
				}
				if(!%plDead) GameBase::setPosition(%obj,%pos);
			}
		}
	}
}

//================================ GodHammerCannon
ItemData HammerAmmo
{
	description = "GodHammerAmmo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData Hammer1PackImage
{ 
	shapeFile = "mortargun";
	mountPoint = 3; 
	mountOffset = { 0.46, 0.1, 2.175 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	projectileType = GodHammer; 
	ammoType = HammerAmmo;	
	accuFire = true; 
	reloadTime = 0.2; 
	fireTime = 0.0;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1.0, 1, 1.0 }; 
}; 

ItemData Hammer1Pack 
{ 
	description = "God Hammer Cannon";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Hammer1PackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = true;
 	className = "Weapon";
}; 

function Hammer1PackImage::onActivate(%player,%imageSlot)
{}
function Hammer1PackImage::onDeactivate(%player,%imageSlot)
{ Player::trigger(%player,$BackpackSlot,false); }

ItemImageData Hammer2PackImage
{ 
	shapeFile = "mortargun"; 
	mountPoint = 3; 
	mountOffset = { -0.27, 0.1, 2.175 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	projectileType = GodHammerQuiet; 
	ammoType = HammerAmmo;	
	accuFire = true; 
	reloadTime = 0.2; 
	fireTime = 0.0; 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 1.0 }; 
}; 

ItemData Hammer2Pack 
{ 
	description = "God Hammer Cannon 2";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Hammer2PackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Weapon";
};

function Hammer2PackImage::onActivate(%player,%imageSlot)
{}
function Hammer2PackImage::onDeactivate(%player,%imageSlot) 
{Player::trigger(%player,$BackpackSlot,false);}

function GodHammer::HeatUp(%clientId)
{
	%clientId.heatup = %clientId.heatup + 5;
	%player = client::getownedobject(%clientId);
	%heat = %clientId.heatup;
	
	if (%heat > 50 && %heat <=65)
	{
		bottomprint(%clientId, "GodHammer Cannon Overheating. " @ %heat @ " %.");
		if (!%clientId.heatlock) GodHammer::HeatCheck (%clientId);return;
	}
	if (%heat > 65 && %heat <= 80)
	{
		bottomprint(%clientId, "GodHammer Cannon Plasma Core OverHeating! " @ %heat @ " %.");	
		GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.10, 2, %clientId); 
  		GameBase::applyDamage(%player, $PlasmaDamageType, 0.10, "0 0 0", "0 0 0", "0 0 0", %clientId);
		if (!%clientId.heatlock) GodHammer::HeatCheck (%clientId);return;
	}
	if (%heat > 80 && %heat <= 99)
	{
		bottomprint(%clientId, "GodHammer Cannon Plasma Core OverHeat Critical!!! " @ %heat @ " %.");	
  		GameBase::applyDamage(%player, $PlasmaDamageType, 0.35, "0 0 0", "0 0 0", "0 0 0", %clientId);
		if (!%clientId.heatlock) GodHammer::HeatCheck (%clientId);return;
	}
	if (%heat > 99)
	{
		bottomprint(%clientId, "GodHammer Cannon Plasma Core OverHeat 100%.");	
		DeployFrags(%player, 10, %clientId);
		GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.02, 2, %clientId); 
		GameBase::applyDamage(%player, $PlasmaDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %clientId);
		%clientId.heatup = 0;
	}
}

function GodHammer::HeatCheck(%clientId, %heat)
{
	%player = client::getownedobject(%clientId);
	
	if (%clientId.heatup > 0)
	{
		%count = (%clientId.heatup / 20.0);
		%clientId.heatlock = 1;
		schedule ("GodHammer::HeatCheck(" @ %clientId @ ");",%count,%clientId);
		schedule ("godhammer::cooldown(" @ %clientId @ ");",%count,%clientId);
	}
	else
	{
		%clientId.heatlock = 0;
		return;
	}
}
function GodHammer::CoolDown(%clientId)
{
	if (%clientId.heatup > 0)
	{
		%clientId.heatup -= 8;
		bottomprint(%clientId, "GodHammer Cannon Plasma Core Cooling " @ %clientId.heatup @ "%.");		
	}
}

//================== Shock Floor
ItemImageData ShockFloorPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData ShockFloorPack
{
	description = "Shock Floor";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "eDefensive";
	imageType = ShockFloorPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShockFloorPack::onUse(%player,%item)
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

function ShockFloorPack::onDeploy(%player,%item,%pos)
{
	if (ShockFloorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShockFloorPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Shock Floor","Flat",False,False,False,False,False,4,True,0, True, "ShockFloor", "ShockFloorPack");
}

//======================================================================== 
// Flyer Module's
//========================================================================

ItemImageData FlyerModuleImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = {0, -0.1, -0.5 };
	mountRotation = {0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData NapalmModule
{
	description = "NapalmModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData HellFireModule
{
	description = "HellFireModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData DetPackModule
{
	description = "DetPack Module";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData BomberModule
{
	description = "BomberModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData PickUpModule
{
	description = "PickUpModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;


	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData MineNetModule
{
	description = "MineNetModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData StealthModule
{
	description = "StealthModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData WraithModule
{
	description = "WraithModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData InterceptorModule
{
	description = "InterceptorModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData GodHammerModule
{
	description = "GodHammerModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
//======================================================================================== Shield Beacon
ItemImageData JammerBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData JammerBeaconPack
{
	description = "Jammer Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = JammerBeaconPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function JammerBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Jammer Beacon Has A 50m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function JammerBeaconPack::onDeploy(%player,%item,%pos)
{
	if (JammerBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function JammerBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","JammerBeacon",True,False,True,False,True,False,5,True,25,True, "JammerBeacon", "JammerBeaconPack");
}

//================================================== Merc Booster Image
ItemImageData Booster1PackImage
{ 
	shapeFile = "mortargun";
	mountPoint = 3; 
	mountOffset = { 0.22, -0.2, 0.35 }; 
	mountRotation = { -1.57, 2.99, 0 }; 
	weaponType = 0; 
	projectileType = Booster;
	minEnergy = 0.1;
	maxEnergy = 0.1;
//	ammoType = BoosterAmmo;	
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.25;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster1Pack 
{ 
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster1PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
}; 

function Booster1PackImage::onActivate(%player,%imageSlot){}
function Booster1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Booster2PackImage
{ 
	shapeFile = "mortargun"; 
	mountPoint = 3; 
	mountOffset = { -0.25, -0.2, 0.35 };
	mountRotation = { -1.57, -2.99, 0 }; 
	weaponType = 0;
	projectileType = Booster; 
	minEnergy = 0.1;
	maxEnergy = 0.1;
//	ammoType = BoosterAmmo;	
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.25; 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster2Pack 
{ 
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster2PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};
function Booster2PackImage::onActivate(%player,%imageSlot){}
function Booster2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData FlamerTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData FlamerTurretPack
{
	description = "Flamer Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = FlamerTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlamerTurretPack::onUse(%player,%item)
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

function FlamerTurretPack::onDeploy(%player,%item,%pos)
{
	if (FlamerTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function FlamerTurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Flamer Turret",False,False,7,False,False,False,4,True,35, True, "FlamerTurret", "FlamerTurretPack");
}

ItemData ValkyrieModule
{
	description = "ValkyrieModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

//----------------------------------------------------------------------------
// DusktoDawn Minefield
//----------------------------------------------------------------------------
ExplosionData fusionmine_exp
{ 
   shapeName = "shockwave.dts";
   soundId   = mineExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
}; 

GrenadeData Fusionmine
{ 
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = fusionmine_exp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1; 
   damageValue        = 0.30;
   damageType         = $LandingDamageType;
   explosionRadius    = 30.0;
   kickBackStrength   = 180.0;
   maxLevelFlightDist = 400;
   totalTime          = 0.05;
   liveTime           = 0.05;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
 
//----------------------------------------------------------------------------
// FleetCommand Teleporter
//----------------------------------------------------------------------------
SoundData FC_sfx
{
   wavFileName = "transporter.wav";
   profile = Profile3dNear;
};

ExplosionData FC_tele_fx
{
      shapeName = "fusionex.dts";
      soundId   = FC_sfx;
      faceCamera = true;
      randomSpin = true;
      hasLight   = true;
      lightRange = 5.0;   
      timeZero = 0.450;
      timeOne  = 0.750;   
      colors[0]  = { 0.25, 0.25, 1.0 };
      colors[1]  = { 0.25, 0.25, 1.0 };
      colors[2]  = { 1.0,  1.0,  1.0 };
      radFactors = { 1.0, 1.0, 1.0 };
};

GrenadeData FC_teleporter
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = FC_tele_fx;
   collideWithOwner   = True;
   ownerGraceMS       = 200;
   collisionRadius    = 0;
   mass               = 0;
   elasticity         = 0;
   damageClass        = 1; 
   damageValue        = 0;
   damageType         = $MortarDamageType;
   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 400;
   totalTime          = 0.05;
   liveTime           = 0.05;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0;
   smokeName              = "chainspk.dts";
};
function Vector::FindRotation(%pos1, %pos2){%point = Vector::Sub(%pos1, %pos2);	%norm = Vector::Normalize(%point);	%rot = Vector::GetRotation(%norm);	%rot = Vector::Add(%rot, "-1.57 3.13999999 0");	return %rot;}
function arcTan(%x){return (%x - ((%x*%x*%x)/3) + ((%x*%x*%x*%x*%x)/5) - ((%x*%x*%x*%x*%x*%x*%x)/7));}

//==Start New mortar Stuffs

ItemImageData MortarImage0
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = "MortarShell1";
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

ItemData Mortar0
{
	description = "Mortar0";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage0;
	price = 375;
	showWeaponBar = true;
	
	//validateShape = true;
};

ItemImageData MortarImage1
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = "EMPMortar";
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

ItemData Mortar1
{
	description = "Mortar1";
	className = "Weapon";
	shapeFile = "mortargun";
	//hudIcon = "mortar";
   //heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage1;
	//price = 375;
	//showWeaponBar = true;
	
	//validateShape = true;
};

ItemImageData MortarImage2
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

ItemData Mortar2
{
	description = "Mortar2";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage2;
	price = 375;
	showWeaponBar = true;
	//validateShape = true;
};

function MortarImage2::onFire(%player, %slot) 
{
   %client = GameBase::getOwnerClient(%player);
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	%playerId = Player::getClient(%player);

	if (%client.lastmdm && %Ammo == 1)
	{
		MDMDetonate2(%player);
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
			//%fired = Projectile::spawnProjectile("MortarShell1",%trans,%player,%vel);
       	//Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			Player::useItem(%player,mortar);
		}
		else if (%playerId.Mortar == 1)
		{
			//%fired = Projectile::spawnProjectile("EMPMortar",%trans,%player,%vel);
       	//Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			Player::useItem(%player,mortar);
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
				MDMDetonate(%player);
			else if(%Ammo > 1)
			{
				%client.firemortar = (Projectile::spawnProjectile("DelayMortarShell",%trans,%player,%vel));
				schedule("MDMDetonate(" @ %player @");",10,%client.firemortar);
				Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
			else if(%Ammo == 1)
			{
				%client.lastmdm = (Projectile::spawnProjectile("DelayMortarShell",%trans,%player,%vel));
				schedule("MDMDetonate2(" @ %player @");",10,%client.lastmdm);
			}
		}		
	}
}

function Mortar0::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,mortar,1))
		{
			Item::playPickupSound(%this);
			if(%this)deleteObject(%this);
		}
	}
}

function Mortar1::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		echo("mortar0 itemdata = " @ %item);
		if (Item::giveItem(%object,mortar,1))
		{
			Item::playPickupSound(%this);
			if(%this)deleteObject(%this);
		}
	}
}

function Mortar2::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		echo("mortar0 itemdata = " @ %item);
		if (Item::giveItem(%object,mortar,1))
		{
			Item::playPickupSound(%this);
			if(%this)deleteObject(%this);
		}
	}
}

//==End New mortar Stuffs