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
$AmmoPackMax[RepairKit] = 1;
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

$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;

//==================================================== Standard Limits.
$TeamItemMax[AccelPPack] = 5;
$TeamItemMax[AirAmmoPad] = 4;
$TeamItemMax[airbase] = 3;
$TeamItemMax[ArbitorBeaconPack] = 3;
$TeamItemMax[Beacon] = 100;
$TeamItemMax[BlastFloorPack] = 6;
$TeamItemMax[BlastWallPack] = 6;
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableComPack] = 5;
$TeamItemMax[DeployableElf] = 5;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[DeployableSensorJammerPack] = 10;
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
$TeamItemMax[JammerBeaconPack] = 1;
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
	//if (isPlayerBusy(%client))
	//	return;

   //	%time = getIntegerTime(true) >> 4;
   //	if(%time <= %client.lastBuyFavTime)
   //	   	return;

   //	%client.lastBuyFavTime = %time;

	if( !%client.observerMode == "pregame" || %client.dead) { return; }

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

		if (%favItem0)  {%client.fav0 = %favItem0;	  $spawnBuyList[0,  %client] = getItemData(%favItem0); }
		if (%favItem1)  {%client.fav1 = %favItem1;	  $spawnBuyList[1,  %client] = getItemData(%favItem1); }
	   	if (%favItem2)  {%client.fav2 = %favItem2;	  $spawnBuyList[2,  %client] = getItemData(%favItem2); }
	   	if (%favItem3)  {%client.fav3 = %favItem3;	  $spawnBuyList[3,  %client] = getItemData(%favItem3); }
	   	if (%favItem4)  {%client.fav4 = %favItem4;	  $spawnBuyList[4,  %client] = getItemData(%favItem4); }
	   	if (%favItem5)  {%client.fav5 = %favItem5;	  $spawnBuyList[5,  %client] = getItemData(%favItem5); }
	   	if (%favItem6)  {%client.fav6 = %favItem6;	  $spawnBuyList[6,  %client] = getItemData(%favItem6); }
	   	if (%favItem7)  {%client.fav7 = %favItem7;	  $spawnBuyList[7,  %client] = getItemData(%favItem7); }
	   	if (%favItem8)  {%client.fav8 = %favItem8;	  $spawnBuyList[8,  %client] = getItemData(%favItem8); }
	   	if (%favItem9)  {%client.fav9 = %favItem9;	  $spawnBuyList[9,  %client] = getItemData(%favItem9); }
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
	{
		if(armor != "earmor" && armor != "efemale")
 			Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else 
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
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
	if (Player::isDead(%player)) 
		return;

	%item = getItemData(%type);

	%player.throwStrength = 1;
 
 	if (Player::getArmor(%player) == "parmor")
		return;

	%item1 = Player::getMountedItem(%player,4);
	%item2 = Player::getMountedItem(%player,5);	
	if (%item == "Hammer1Pack" || %item == "Hammer2Pack")
	{
		%item = "Backpack";
		%item1 = "Hammer1Pack";
		%item2 = "Hammer2Pack";
	}	
	if (%item1 == "Hammer1Pack" && %item2 == "Hammer2Pack" && %item == "Backpack")
	{
		fireGH(%player);
		return;
	}
	else if (%item == Backpack) 
		%item = Player::getMountedItem(%player,$BackpackSlot);
	else if (%item == Weapon)
		%item = Player::getMountedItem(%player,$WeaponSlot);
	Player::useItem(%player,%item);		
}

function fireGH(%player)
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Hammer1Pack]);
	if(%player.refire != 1)
	{
		if (%ammo)
		{
			%client = GameBase::getOwnerClient(%player);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			%ppos = GameBase::getPosition(%player);
		
			if(GameBase::getLOSInfo(%player,500)) 
			{
				Player::trigger(%player,4,true);	Player::trigger(%player,5,true);
				Player::trigger(%player,4,false);	Player::trigger(%player,5,false);
				playSound(SoundPlasmaTurretFire,%ppos);
				playSound(SoundMissileTurretFire,%ppos);
				%player.refire = 1;
				schedule ("" @ %player @ ".refire = 0;", 0.5);
				godhammer::heatup(%client);
			}
			else
			{
				Player::decItemCount(%player,$WeaponAmmo[Hammer1Pack],2);
				Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel,%player);
				Projectile::spawnProjectile("JuggStingerMissile",%trans,%player,%vel,%player);
				playSound(SoundPlasmaTurretFire,%ppos);
				playSound(SoundMissileTurretFire,%ppos);
				%player.refire = 1;
				schedule ("" @ %player @ ".refire = 0;", 0.5);
				godhammer::heatup(%client);
			}		
		}
		else
			Client::sendMessage(player::getclient(%player),1,"No God Hammer Ammo!~waccess_denied.wav");
	}
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

function remoteDropItem(%client,%type)
{
	%player = Client::getOwnedObject(%client);
	if(%player == -1)
		return;
	%client.throwStrength = 1;
	%item = getItemData(%type);
	%armor = Player::getArmor(%client);
	//echo(%player.dropcount);
	if(!$builder)
	{
		if(( $shifter::dropccheck == false || $shifter::dropccheck == "") && %player.dropcount > 50)
		{
			Client::sendMessage(%client,1,"Station Drop limit exceeded");
			return;
		}
		else if($shifter::dropccheck != "" && %player.dropcount > $shifter::dropccheck)
		{
			Client::sendMessage(%client,1,"Station Drop limit exceeded");
			return;
		}
	}
 	if (%armor == "earmor" || %armor == "efemale")
	{
		if (%item == Backpack) 
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
			if(%player.station == true)%player.dropcount++;
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
		{
			Player::dropItem(%client,%item);
			if(%player.station == true)%player.dropcount++;
		}
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
			if(%player.station == true)%player.dropcount++;
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
		{
			Player::dropItem(%client,%item);
			if(%player.station == true)%player.dropcount++;
		}
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

function Item::BuildWeaponArrayB()
{
	$WeaponAmmt = 26;
	$WeaponListB[0] = "Blaster";
	$WeaponListB[1] = "PlasmaGun";
	$WeaponListB[2] = "Chaingun";
	$WeaponListB[3] = "Disclauncher";
	$WeaponListB[4] = "GrenadeLauncher";
	$WeaponListB[5] = "Mortar";
	$WeaponListB[6] = "LaserRifle";
	$WeaponListB[7] = "RocketLauncher";
	$WeaponListB[8] = "SniperRifle";
	$WeaponListB[9] = "ConCun";
	$WeaponListB[10] = "EnergyRifle";
	$WeaponListB[11] = "RailGun";
	$WeaponListB[12] = "Mfgl";
	$WeaponListB[13] = "Silencer";
	$WeaponListB[14] = "Vulcan";
	$WeaponListB[15] = "IonGun";
	$WeaponListB[16] = "Flamer";
	$WeaponListB[17] = "TranqGun";
	$WeaponListB[18] = "HyperB";
	$WeaponListB[19] = "Volter";
	$WeaponListB[20] = "FixIt";
	$WeaponListB[21] = "HackIt";
	$WeaponListB[22] = "DisIt";
	$WeaponListB[23] = "GravGun";
	$WeaponListB[24] = "LasCannon";
	$WeaponListB[25] = "BoomStick";
	$WeaponListB[26] = "PlasmaCannon";

	for (%i=0; %i <= $WeaponAmmt; %i++) //=== Build Next Array
	{
		%next = $WeaponListB[%i+1];
		%curr = $WeaponListB[%i];
		
		if (%i < $WeaponAmmt)
		{
			$NextWeaponB[%curr] = %next;
		}
		else if (%i == $WeaponAmmt)
		{
			$NextWeaponB[%curr] = $WeaponListB[0];
		}
	}
	
	for (%i = $WeaponAmmt; %i >= 0; %i--)
	{
		%curr = $WeaponListB[%i];
		%prev = $WeaponListB[%i-1];
		
		if (%i == 0)
		{
			$PrevWeaponB[%curr] = $WeaponListB[$WeaponAmmt];
		}
		else if (%i > 0)
		{
			$PrevWeaponB[%curr] = %prev;
		}
	}
}

Item::BuildWeaponArrayB();

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
	if(!%client.weaponorder || %client.weaponorder == "0")
	{
		if(%item == mortar0 || %item == mortar1 || %item == mortar2)
		{
			for (%weapon = $NextWeaponB[mortar]; %weapon != %item; %weapon = $NextWeaponB[%weapon])
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
		else if (%item == -1 || $NextWeaponB[%item] == "")
		{
			selectValidWeaponB(%client);
		}
		else
		{
			for (%weapon = $NextWeaponB[%item]; %weapon != %item; %weapon = $NextWeaponB[%weapon])
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
	else
	{
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
	if(!%client.weaponorder || %client.weaponorder == "0")
	{
		if(%item == mortar0 || %item == mortar1 || %item == mortar2)
		{
			for (%weapon = $PrevWeaponB[mortar]; %weapon != %item; %weapon = $PrevWeaponB[%weapon])
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
			selectValidWeaponB(%client);
		else
		{
			for (%weapon = $PrevWeaponB[%item]; %weapon != %item; %weapon = $PrevWeaponB[%weapon])
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
	else
	{
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

function selectValidWeaponB(%client)
{
	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead) 
	{
		return;
	}
	%item = EnergyRifle;
	for (%weapon = $NextWeaponB[%item]; %weapon != %item;%weapon = $NextWeaponB[%weapon])
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
		if(%this)deleteobject(%this);
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
	schedule("deleteobject(" @ %item @ ");",2.5, %item);
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
	//validateMaterials = true;
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

exec(gundata);
exec(packdata);
exec(deploydata);


//======================================================================== Repair Kit

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = "gMiscellany";
	shadowDetailMask = 4;
	price = 35;
	
	//validateShape = true;
//	validateMaterials = true;
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
		GameBase::repairDamage(%player,0.3);
	else if(%armor == "earmor" || %armor == "efemale")
		GameBase::repairDamage(%player,0.3);
	else if(%armor == "spyarmor" || %armor == "spyfemale")
		GameBase::repairDamage(%player,0.3);
	else if(%armor == "marmor" || %armor == "mfemale")
		GameBase::repairDamage(%player,0.2);
	else if(%armor == "aarmor" || %armor == "afemale")
		GameBase::repairDamage(%player,0.2);
	else if(%armor == "harmor")
		GameBase::repairDamage(%player,0.2);
	else if(%armor == "barmor" || %armor == "bfemale")
		GameBase::repairDamage(%player,0.2);
	else if(%armor == "darmor")
		GameBase::repairDamage(%player,0.3);
	else if(%armor == "jarmor")
	{
		GameBase::repairDamage(%player,0.5);
		if (%clientId.heatup > 50)
			%clientId.heatup = %clientId.heatup - 20;
	}
	else
		GameBase::repairDamage(%player,0.1);
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
				LaserMine(%client, %player, %item, 15);
			else if (%client.EngMine == "3")
				%obj = newObject("","Mine", "antipersonelMine");
			else if (%client.EngMine == "4")
				%obj = newObject("","Mine", "ReplicatorMine");
		}
		else if (%armor == "darmor" || %armor == "harmor")
		{
			if (%client.dmines == 0 || !%client.dmines)
				LaserMine(%client, %player, %item, 15);
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
{
	%item = "LaserMine";
	%energy = GameBase::getEnergy(%player);
	%energy = (%energy - %nrg);
	if (%energy < 15)
	{
		bottomprint(%client, "<jc>You're out of energy, can not Deploy LaserMine.",3);
		return;
	}
	else if (GameBase::getLOSInfo(%player,6)) 
	{
		%obj = getObjectType($los::object);
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot,2);
			
		if (Vector::dot($los::normal,"0 0 1") > 0.2)
			%rot = "0 0 " @ %zRot;
		else 
		{
			if (Vector::dot($los::normal,"0 0 -1") > 0.2)
				%rot = "3.14159 0 " @ %zRot;
			else 
				%rot = Vector::getRotation($los::normal);
		}
		if(checkDeployArea(%client,$los::position))
		{
			
			if(Player::getArmor(%player) != "darmor")
				%turret = newObject("Camera","Turret",DeployableLaserM,true);
			else
				%turret = newObject("Camera","Turret",DeployableLaserM2,true);
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
			schedule("GameBase::setDamageLevel(" @ %obj @ ", 3.0);", %timer, %obj);
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

//==================================================================================================== Beacons

ItemData Beacon
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = "gMiscellany";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	
	//validateShape = true;
//	validateMaterials = true;
};

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
			if (%clientId.EngBeacon == 2)
			{
				if (EngMissileLock(%clientId, %player, %item))		//=== Anti Missile
				{
					$TeamItemCount[GameBase::getTeam(%player) @ "EngBeacons"]++;
					//Client::sendMessage(%clientId,0,"Engineer Beacon Set");
					Player::decItemCount(%player,%item);
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
				schedule("Beacon::onUse("@ %player @","@ %item @");", 1.1);
				//Client::sendMessage(Player::getClient(%player),1,"Laser Refractor Cooling.~wfailpack.wav"); 
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
				schedule("Beacon::onUse("@ %player @","@ %item @");", 1.1);
				//Client::sendMessage(Player::getClient(%player),1,"Plasma Core Cooling.~wfailpack.wav"); 
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
						schedule ("" @ %ClientId @ ".boostercool = \"False\";",4);
						schedule ("" @ %ClientId @ ".boostpop = \"0\";",4);
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
		//%clientId.empTime = 0;
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
					if(!%client.throwStrength)
						%client.throwStrength = 1.0;
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
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function AirAmmoPad::onDeploy(%player,%item,%pos)
{
	if (AirAmmoPad::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
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
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function airbase::onDeploy(%player,%item,%pos)
{
	if (airbase::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function airbase::deployshape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%playerPos = GameBase::getPosition(%player);
	%playerRot = GameBase::getRotation(%player);
	%deploypos = Vector::add(%playerPos, "-0 -0 50.50");
	%team = GameBase::getTeam(%player);
	if (!CheckForObjects(%deploypos,45,45,25))
	{
		Client::sendMessage(%client,1,"Objects In The Way, Can not deploy.");
		return false;
	}

	airbase::specialdeploy(%team, %playerPos, %playerRot, %player);

	playSound(SoundPickupBackpack,%playerPos);
	Client::sendMessage(%client,1,"Air Base Deployed.");
	return true;
}

function airbase::specialdeploy(%team,%playerPos,%playerRot,%player)
{
	if(%player)
		%pname = Client::getName(Player::getClient(%player));
	else
		%pname = "";

	%num = $TeamItemCount[%team @ "airbase"];

	if($server::tourneymode && !$ceasefire)
	{
		$deployab[%num] = "airbase "@ %team @" "@ %playerPos @" "@ %PlayerRot;
		export("$deployab*", "config\\dtrack.cs", true);
		deleteVariables("$deployab*");
		if(string::findsubstr($dlist, "ab" @ %num) == -1)
			$dlist = $dlist @ " ab" @ %num;
	}

	%set = newObject("AirBase"@ %num,SimSet);
	addToSet("MissionCleanup","AirBase"@ %num);

	//================== Airbase platforms
	%name1 = "Sensor" @ %num;
	%name2 = "StationGenerator" @ %num;
	%name3 = "CommandStation" @ %num;
	%name4 = "InventoryStation" @ %num;
	%name5 = "VehiclePad" @ %num;
	%name6 = "VehicleStation" @ %num;
	
	%plat1 = "Platform1";
	%plat2 = "Platform2";
	%plat3 = "Platform3";
	%plat4 = "Platform4";

%platrot = "0 0 1.5714";

		//=== Bottom Platforms
		instant StaticShape %plat2
		{
			dataBlock = "LargeAirBasePlatform";
			name = %plat2@%pname;
			position = Vector::add(%playerpos, "6.75 0.5 50.00");
			rotation = %platrot;
			destroyable = "True";
			deleteOnDestroy = "True";
			VehiclePad = %name5;
			team = %team;
		};

		instant StaticShape %plat3
		{
			dataBlock = "LargeAirBasePlatform";
			name = %plat3@%pname;
			position = Vector::add(%playerpos, "-6.75 -5.0 50.00");
			rotation = %platrot;
			destroyable = "True";
			deleteOnDestroy = "True";
			VehiclePad = %name5;
			team = %team;
		};
		
		//=== Top platforms
		instant StaticShape %plat1
		{
			dataBlock = "LargeAirBasePlatform";
			name = %plat1@%pname;
			position = Vector::add(%playerpos, "-6.75 -9.5 58.00");
			rotation = %platrot;
			destroyable = "True";
			deleteOnDestroy = "True";
			VehiclePad = %name5;
			team = %team;
		};

		instant StaticShape %plat4
		{
			dataBlock = "LargeAirBasePlatform";
			name = "AB Fix thx to LT#56";
			position = Vector::add(%playerpos, "6.75 -4.0 58.00");
			rotation = %platrot;
			destroyable = "True";
			deleteOnDestroy = "True";
			VehiclePad = %name5;
			team = %team;
		};


		//=================== Airbase Radar
		instant Sensor %name1
		{
			dataBlock = "PulseSensor";
			name = %name1@%pname;
			position = Vector::add(%playerpos, "-0 -6.0 58.50");
			rotation = Vector::add(%playerrot, "0 0 0");
			destroyable = "True";
			deleteOnDestroy = "False";
			team = %team;
		};
		instant StaticShape %name5
		{
			dataBlock = "VehiclePad";
			name = %name5@%pname;
			position = Vector::add(%playerpos, "8 -4 59.2");
			rotation = Vector::add(%playerrot, "0 0 4.71339");
			destroyable = "True";
			deleteOnDestroy = "False";
			team = %team;
		};

		instant StaticShape %name6
		{
			dataBlock = "VehicleStation";
			name = %name6@%pname;
			position = Vector::add(%playerpos, "-8 -9 58.50");
			rotation = Vector::add(%playerrot, "0 0 4.71339");
			destroyable = "True";
			deleteOnDestroy = "False";
			VehiclePad = %name5;
			team = %team;
		};
		//=================== Air base Gen
		instant StaticShape %name2
		{
			dataBlock = "PortGenerator";
			name = %name2@%pname;
			position = Vector::add(%playerpos, "-0 -3.0 50.40");
			rotation = Vector::add(%playerrot, "0 0 4.71339");
			destroyable = "True";
			deleteOnDestroy = "False";
			team = %team;
		};

		//=================== Command Station
		instant StaticShape %name3
		{
			dataBlock = "CommandStation";
			name = %name3@%pname;
			position = Vector::add(%playerpos, "-7 -5 50.40");
			rotation = Vector::add(%playerrot, "0 0 4.71339");
			destroyable = "True";
			deleteOnDestroy = "False";
			team = %team;
		};

		//=================== Invo Station
		instant StaticShape %name4
		{	
			dataBlock = "InventoryStation";
			name = %name4@%pname;
			position = Vector::add(%playerpos, "5 0 50.40");
			rotation = Vector::add(%playerrot, "0 0 4.71339");
			destroyable = "True";
			deleteOnDestroy = "False";
			team = %team;
		};


	addToSet(%set, %name1);
	addToSet(%set, %name2);
	addToSet(%set, %name3);
	addToSet(%set, %name4);
	addToSet(%set, %name5);
	addToSet(%set, %name6);
	addToSet(%set, %plat1);
	addToSet(%set, %plat2);
	addToSet(%set, %plat3);
	addToSet(%set, %plat4);

	%set = "MissionCleanup";
	addToSet(%set, %name1);
	addToSet(%set, %name2);
	addToSet(%set, %name3);
	addToSet(%set, %name4);
	addToSet(%set, %name5);
	addToSet(%set, %name6);
	addToSet(%set, %plat1);
	addToSet(%set, %plat2);
	addToSet(%set, %plat3);
	addToSet(%set, %plat4);

	%n1 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %name1);
	%n2 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %name2);
	%n3 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %name3);
	%n4 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %name4);
	%n5 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %name5);
	%n6 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %name6);
	%n6.vehiclePad = %n5;
	%n7 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %plat1);
	%n8 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %plat2);
	%n9 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %plat3);
	%n10 = nametoId("MissionCleanup/AirBase" @ %num @ "/" @ %plat4);

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

	gamebase::setteam(%n1, %team);
	gamebase::setteam(%n2, %team);
	gamebase::setteam(%n3, %team);
	gamebase::setteam(%n4, %team);
	gamebase::setteam(%n5, %team);
	gamebase::setteam(%n6, %team);

	$TeamItemCount[%team @ "airbase"]++;
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
						%team = GameBase::getTeam(%player);
						%pos = $los::position;
						%rot = GameBase::getRotation(%player);
						deploy::record(%phase, "DeployableLaunch", %team, %pos, %rot);
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
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
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
				%team = GameBase::getTeam(%player);
				%pos = $los::position;
				%rot = GameBase::getRotation(%player);
				deploy::record(%this, "AccelPadPack", %team, %pos, %rot);
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
			else if (%datab == "LargeEmplacementPlatform" || %datab == "BlastFloor")
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
	price = 400;
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
	price = 400;
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
	price = 650;
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
	price = 750;
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
	price = 2000;
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
	price = 2000;
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
	
	//validateShape = true;
//	validateMaterials = true;
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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,6))
		{
			%obj = getObjectType($los::object);
			%pos = $los::position;
         if (!CheckForObjects(%pos))
         {
				Client::sendMessage(%client,1,"Objects In The Way, Can not deploy.");
				return;
			}
			if (%obj == "SimTerrain")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.8)
				{
					%playerPos = GameBase::getPosition(%player);
					%playerRot = GameBase::getRotation(%player);
					%team = GameBase::getTeam(%player);
					EmplacementPack::specialdeploy(%team, $los::position, %playerRot, %player);
					%newplayerpos = Vector::add(%playerPos, "0 0 0.85");
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
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


function EmplacementPack::specialdeploy(%team,%playerpos,%playerRot,%player)
{
	if(%player)
		%pname = Client::getName(Player::getClient(%player));
	else
		%pname = "";

	%num = $TeamItemCount[%team @ "EmplacementPack"];

	if($server::tourneymode && !$ceasefire)
	{
		$deployem[%num] = "EmplacementPack "@ %team @" "@ %playerPos @" "@ %PlayerRot;
		export("$deployem*", "config\\dtrack.cs", true);
		deleteVariables("$deployem*");
		if(string::findsubstr($dlist, "em" @ %num) == -1)
			$dlist = $dlist @ " em" @ %num;
	}

	%name1 = "Emplacement1" @ %num;
	%name2 = "StationGenerator" @ %num;
	%name3 = "Emplacement2" @ %num;
	%name4 = "InventoryStation" @ %num;
	%ff1 = "ForceField1" @ %num;
	%ff2 = "ForceField2" @ %num;
	%ff3 = "ForceField3" @ %num;
	%ff4 = "ForceField4" @ %num;
	%ff5 = "ForceField5" @ %num;

	%set = newObject("Emplacement"@ %num,SimSet);
	addToSet("MissionCleanup","Emplacement"@ %num);

						instant StaticShape %name1
						{
							dataBlock = "LargeEmplacementPlatform";
							name = %name1@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "0 2 0.4", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "True";
							VehiclePad = %name5;
							team = %team;
						};

						instant StaticShape %name3
						{
							dataBlock = "LargeEmplacementPlatform";
							name = %name3@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "0 2 5.2", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "True";
							VehiclePad = %name5;
							team = %team;
						};

						instant StaticShape %name4
						{
							dataBlock = "InventoryStation";
							name = %name4@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "0 3.75 0.9", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 0");
							destroyable = "True"@%pname;
							deleteOnDestroy = "False";
							team = %team;
						};

						instant StaticShape %name2
						{
							dataBlock = "PortGenerator";
							name = %name2@%pname;
							position = Vector::add(%playerPos, "0 0 -15");
							rotation = Vector::add(%playerRot, "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "False";
							team = %team;
						};
						
						instant StaticShape %ff1
						{
							dataBlock = "ForceField3";
							name = %ff1@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "0 7.15 0.9", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 0");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = %team;
						};

						instant StaticShape %ff2
						{
							dataBlock = "ForceField3";
							name = %ff2@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "-5.25 3.5 0.9", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = %team;
						};						

						instant StaticShape %ff3
						{
							dataBlock = "ForceField3";
							name = %ff3@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "5.25 3.5 0.9", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 -1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = %team;
						};	
						instant StaticShape %ff4
						{
							dataBlock = "ForceField1";
							name = %ff4@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "-5.75 -1.40 1", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 -1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = %team;
						};	
						instant StaticShape %ff5
						{
							dataBlock = "ForceField1";
							name = %ff5@%pname;
							position = Vector::add(%playerPos, EmplacementPack::rotVector( "5.75 -1.40 1", %playerRot ) );
							rotation = Vector::add( %playerRot, "0 0 1.15");
							destroyable = "True";
							deleteOnDestroy = "True";
							team = %team;
						};	

	addToSet(%set, %name1);
	addToSet(%set, %name2);
	addToSet(%set, %name3);
	addToSet(%set, %name4);
	addToSet(%set, %ff1);
	addToSet(%set, %ff2);
	addToSet(%set, %ff3);
	addToSet(%set, %ff4);
	addToSet(%set, %ff5);

	%set = "MissionCleanup";
	addToSet(%set, %name1);
	addToSet(%set, %name2);
	addToSet(%set, %name3);
	addToSet(%set, %name4);
	addToSet(%set, %ff1);
	addToSet(%set, %ff2);
	addToSet(%set, %ff3);
	addToSet(%set, %ff4);
	addToSet(%set, %ff5);

	%n1 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %name1);
	%n2 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %name2);
	%n3 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %name4);
	%n4 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %name3);
	%f1 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %ff1);
	%f2 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %ff2);
	%f3 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %ff3);
	%f4 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %ff4);
	%f5 = nametoId("MissionCleanup/Emplacement" @ %num @ "/" @ %ff5);

	gamebase::setteam(%n1, %team);
	gamebase::setteam(%n2, %team);
	gamebase::setteam(%n3, %team);
	gamebase::setteam(%n4, %team);
	gamebase::setteam(%f1, %team);
	gamebase::setteam(%f2, %team);
	gamebase::setteam(%f3, %team);
	gamebase::setteam(%f4, %team);
	gamebase::setteam(%f5, %team);

	%n1.base = true;
	%n2.base = true;
	%n3.base = true;
	%n4.base = true;
	%f1.base = true;
	%f2.base = true;
	%f3.base = true;
	%f4.base = true;
	%f5.base = true;

	$TeamItemCount[%team @ "EmplacementPack"]++;
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
		if(%player.outArea != 1)
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
	if(!%plDead && Player::getItemCount(%clientId,LasCannon))
		Player::mountItem(%clientId, LasCannon, $WeaponSlot);
	else
		return;
	
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
	if(!%plDead && Player::getItemCount(%clientId,LasCannon))
		Player::mountItem(%clientId, LasCannon, $WeaponSlot);
	else
		return;
	
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
	mass = 1.1;
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
	if(!%plDead && Player::getItemCount(%clientId,PlasmaCannon))
		Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);
	else
		return;

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
	if(!%plDead && Player::getItemCount(%clientId,PlasmaCannon))
		Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);
	else
		return;
	
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
	soundId = NoCrashJetHeavy;
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
	soundId = NoCrashJetHeavy;
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
	soundId = NoCrashJetHeavy;
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
	soundId = NoCrashJetHeavy;
};

function FireHeavyPlasma(%trans, %player)
{
	%client = Player::getClient(%player);
	%this = (Projectile::spawnProjectile(PlasmaCannonShock2, %trans,%player,"0 0 -1"));
	%pos = gamebase::getposition(%this);
	%this.check = 1;
	checkForHP(%this, %player, %pos);
}

function checkForHP(%this, %player, %pos)
{	
	if(%this.check)
	{	%pos = gamebase::getposition(%this);
		schedule("checkForHP(\"" @ %this @ "\", \"" @ %player @ "\", \"" @ %pos @ "\");", 0.2);
	}
	else
	{	
		if(%player)
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
						GameBase::throw(%obj,%player,120,false);
					else
						GameBase::throw(%obj,%player,120,true);
				}
				else
				{
					if ((floor(getRandom()*4)+1) > 3)
						GameBase::throw(%obj,%player,-80,false);
					else
						GameBase::throw(%obj,%player,-80,true);
				}
				GameBase::setPosition(%obj,%pos);
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
	mountOffset = { 0.485, -0.1, 2.175 }; //	mountOffset = { 0.46, -0.1, 2.175 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	projectileType = JuggStingerMissile;//GodHammer; 
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
	mountOffset = { -0.32, -0.1, 2.175 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	projectileType = JuggStingerMissile;//GodHammerQuiet; 
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
	
	validateShape = false;
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
	
	validateShape = false;
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
	validateShape = false;
};

function MortarImage2::onFire(%player, %slot) 
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

function Mortar0::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		if (Item::giveItem(%object,mortar,1))
		{
			Item::playPickupSound(%this);
			if(%this)deleteobject(%this);
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
			if(%this)deleteobject(%this);
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
			if(%this)deleteobject(%this);
		}
	}
}

function mortar::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == mortar || %mounted == mortar0 || %mounted == mortar1 || %mounted == mortar2)
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

//==End New mortar Stuffs

ItemImageData ShroomImage
{
	shapeFile = "sat_big";
	mountPoint = 0;
	mountOffset = { -0.7, 0, -2 };
};

ItemData shroom
{
	description = "Shroom";
	shapeFile = "sat_big";
	hudIcon = "mortar";
	shadowDetailMask = 4;
	imageType = ShroomImage;
	price = 1;
};