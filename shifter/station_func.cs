//===================================================================== Base Station Functions
function Station::onActivate(%this)
{
	%obj = Station::getTarget(%this);
	
	if (%obj != -1)
	{
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
	}
	else
	{
		GameBase::setActive(%this,false);
	}
}

function Station::onDeactivate(%this)
{
		GameBase::stopSequence(%this,2);
		GameBase::setSequenceDirection(%this,1,0);
}

function Station::onEndSequence(%this,%thread)
{

	%this.inuse = "";
		
	if ($debug) echo ("Station End Seq.");
	
 	if (%thread == 1 && GameBase::isActive(%this)) 
 	{
		GameBase::playSequence(%this,2,"use");
		return true;
	}

	if ($debug) echo ("Station End Seq. 1");
	
	%client = %this.target;
	
	if(%client == "") 
	{
		%player = Station::getTarget(%this);
		%client = Player::getClient(%player);
	}
	
	if(%client != "") 
	{
		if(Client::getGuiMode(%client) != 1)
			Client::setGuiMode(%client,1);
		
		%team = Client::getTeam(%client);
		if($TeamEnergy[%team] != "Infinite")
		{
			if(%this.clTeamEnergy != %client.TeamEnergy)
			{
				if(%client.teamEnergy < 0)
					Client::sendMessage(%client,0,"Your total mission purchases have come to " @ (%client.teamEnergy * -1) @ ".");
				else
					Client::sendMessage(%client,0,"You have increased the Team Energy by " @ %client.teamEnergy @ ".");
			}
			
			if((%client.teamEnergy -%client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0))
			{
				TeamMessages(0, %team, "Teammate " @ Client::getName(%client) @ " has spent " @ (%client.teamEnergy *-1) @ " of the TeamEnergy"); 
				%client.EnergyWarning = %client.teamEnergy;
			}
			if($TeamEnergy[%team] < $WarnEnergyLow)  
				TeamMessages(0, %team, "TeamEnergy Low: " @ $TeamEnergy[%team]); 
		}
	}

	if ($debug) echo ("Station End Seq. 2");

	if(%this.target != "")
	{
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime())
		VehiclePad::checkSeq(%this.vehiclePad, %this);
	
	%this.clTeamEnergy = "";

	if ($debug) echo ("Station End Seq. 3");

	return false;
}

function Station::onPower(%this,%power,%generator)
{
	if (%power || $builder == true)
	{
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
	}
	else
	{
		GameBase::stopSequence(%this,0);
		GameBase::pauseSequence(%this,1);
		GameBase::pauseSequence(%this,2);
		Station::checkTarget(%this);
	}
}

function Station::onEnabled(%this)
{
	if (GameBase::isPowered(%this) || $builder == true)
	{		
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
	}
}

function Station::checkTarget(%this)
{
	if(%this.target)
	{
		if ($debug) echo ("Stations Target = " @ %this.target);
		Client::setGuiMode(%this.target,1);
		GameBase::setActive(%this,false);
	}
	else
	{
		if ($debug) echo ("Station Has No Target.");
	}
}

function Station::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::pauseSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
	Station::weaponCheck(%this);
}

function Station::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
	Station::weaponCheck(%this);
}

function Station::getTarget(%this)
{
	if(GameBase::getLOSInfo(%this,1.5,"0 0 3.14"))
	{
	  	%obj = getObjectType($los::object);
	  	if (%obj == "Player")
	  	{
				return $los::object;
		}
	}
	return -1;
}	

function Station::onCollision(%this, %object)
{
	if (getObjectType(%object) == "Flier")
	{	
		%data = GameBase::getDataName(%object);
		HopOut(%object);
		GameBase::setDamageLevel(%object, 10.0);
		return;	
	}
	if (getObjectType(%object) != "Player" || Player::isAIControlled(%object) || Player::isDead(%object) || isPlayerBusy(%object))
		return;

	%client = Player::getClient(%object);
	//========================================== Spy Can Use Any Invo
	%armor = Player::getArmor(%object);
	if(%armor == parmor) {Client::sendMessage(%client,1,"You won't rid yourself of the penis this easily...");return;}

	if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1 || ((%armor == "spyarmor" || %armor == "spyfemale") && %object.infected != "true") )
	{
		%armor = Player::getArmor(%object);
		if (%armor == "earmor" || %armor == "efemale")
		{
			if(GameBase::getDamageLevel(%this)) 
			{
				GameBase::repairDamage(%this,0.10);
				GameBase::playSound(%this,ForceFieldOpen,0);
	     	}
		}

		if (GameBase::getDamageState(%this) == "Enabled" && (GameBase::isPowered(%this) || %this.poweron == "True"))
		{
			if (!%this.isuse)
			{
				%this.inuse = %this.target;
				if(%this.enterTime == "")
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
			}
			else
				Client::sendMessage(%client,1,"Unit is in use... Please wait.");
		}
		else 
			Client::sendMessage(%client,1,"Unit is not powered or disabled.");

	}
	else if(Station::getTarget(%this) == %object)
	{
		%curTime = getSimTime();
		if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
		{
			Client::clearItemShopping(%client);
			Station::onDeactivate(%this);
			Station::onEndSequence(%this,1);
			if(Client::getGuiMode(%client) != 1)
				Client::setGuiMode(%client,1);
			%object.stationDeniedStamp = %curTime;
			Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
		}
	}
}

function Station::weaponCheck(%this)
{
	if(%this.lastPlayer != "")
	{
		%player = %this.lastPlayer;
		%client = Player::getClient(%player);
		%player.Station = "";
		if(Player::getMountedItem(%player,$WeaponSlot) == -1)
		{
			if(%player.lastWeapon != "")
			{
				Player::useItem(%player,%player.lastWeapon);
				%player.lastWeapon = "";
	  		}
		}
		else
			selectValidWeapon(%client);
	 	%this.lastPlayer = "";
  	}
}

function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",Beacon,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",mineammo,1);

	%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);

	%cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,1);
	%cnt = %cnt + AmmoStation::resupply(%player,SMRPack,AutoRocketAmmo,1);
	%cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Silencer,SilencerAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,Vulcan,VulcanAmmo,50);
	%cnt = %cnt + AmmoStation::resupply(%player,TranqGun,TranqAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,SMRPack2,AutoRocketAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,BoomStick,BoomAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Hammer1Pack,HammerAmmo,10);
	return %cnt;
}

//================================================================================ Invo Functions
function resupply(%this)
{
	if (GameBase::isActive(%this)) 
	{
		%player = Station::getTarget(%this);
		if (%player != -1) 
		{
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
				
			%client = Player::getClient(%player);
			
			if (%cnt != 0) 
			{
				updateBuyingList(%client);
				return 1;
			}
			Client::sendMessage(%client,0,"Resupply Complete");
			return 0;
		}
	}
	return 0;
}

function setupShoppingList(%client,%station,%ListType)
{
	Client::clearItemShopping(%client);
	%armor = Player::getarmor(%client);
	%max = getNumItems();
	
	if(%ListType == "InvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			
			if ($Shifter::ItemLimit)
			{
				if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item] && ($ItemMax[%armor,%item] > 0 && $Shifter::ItemLimit))
				{
					Client::setItemShopping(%client, %item);
				}
				else if(%item.className == Armor && !%station.dontSell[%item])  
				{
					Client::setItemShopping(%client, %item);
				}
			}
			else
			{
				if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item])
				{
					Client::setItemShopping(%client, %item);
				}
				else if(%item.className == Armor && !%station.dontSell[%item])  
				{
					Client::setItemShopping(%client, %item);
				}
			}
		}
	}
	if(%ListType == "DepList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			if($DepList[%item] != "" && $DepList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}	
	else if(%ListType == "RemoteInvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			
			if ($Shifter::ItemLimit)
			{			
				if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]  && ($ItemMax[%armor,%item] > 0 && $Shifter::ItemLimit)) 
					Client::setItemShopping(%client, %item);
			}
			else
			{
				if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
					Client::setItemShopping(%client, %item);
			}
	   	}
	}
	else if (%ListType == "VehicleInvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{						
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
	else
		return;
}

function updateBuyingList(%client)
{
   	Client::clearItemBuying(%client);
	%station = (Client::getOwnedObject(%client)).Station;
	%stationName = GameBase::getDataName(%station); 
	
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation)
	{
		%energy = %station.Energy;
   		Client::setInventoryText(%client, "<f1><jc>STATION ENERGY: " @ %energy );
	}
   	else
   	{
		%energy = $TeamEnergy[Client::getTeam(%client)];
		Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ %energy);
	}
	
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
      		if(!%item.showInventory)
      			continue;
      		
		if($ItemMax[%armor, %item] != "0" && Client::isItemShoppingOn(%client,%i))
		{
			%extraAmmo = 0;
			
			if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
				%extraAmmo = $AmmoPackMax[%item];
			
			//================================================================ Player Has Room For More Ammo
			if($ItemMax[%armor, %item] != "" && $ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item))
			{
				//======================================================== Team Has Funds For Items
				if(%energy >= %item.price)
				{	
					//================================================ Can Armor Purache Item ?
					if($ItemMax[%armor,%item] > 0)
					{
						//================================================ Weapon
						if(%item.className == Weapon)
						{
							if(Player::getItemClassCount(%client,"Weapon") < $MaxWeapons[%armor])					
								Client::setItemBuying(%client, %item);
						}
						else
						{
								if($TeamItemMax[%item] != "")
								{						
									if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
										Client::setItemBuying(%client, %item);
								}
								else
									Client::setItemBuying(%client, %item);
						}
					}
				}
		   	}
		}
		else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%i))
		{
			Client::setItemBuying(%client, %item);
		}
		else if(%item.className == Vehicle && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i))
		{
			Client::setItemBuying(%client, %item);
		}
	}
}


