StaticShapeData VehicleStation
{
   	description = "Station Vehicle Unit";
	shapeFile = "vehi_pur_pnl";
	className = "Station";
	//visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 0.5;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   	explosionId = flashExpLarge;
	shieldShapeName = "shield";
	maxEnergy=200;
};

function VehicleStation::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread)) 
		VehicleStation::onBuyingVechicle(%this);
}

function VehicleStation::onBuyingVechicle(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				%client.ListType = "VehicleInvList";
				setupShoppingList(%client,%this,"VehicleInvList");
				updateBuyingList(%client);
				
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				Client::setGuiMode(%client,4);
				Client::sendMessage(%client,0,"Accessing Vehicle Station");
				Client::sendMessage(%client,0,"Station Access On");
				%player.Station = %this;
			 	%numItems = Group::objectCount(GetGroup(%this));
				
				%maxlook = 9999;
				for(%i = 0 ; %i<%numItems ; %i++)
				{ 
					%obj = Group::getObject(GetGroup(%this), %i);
					%name = GameBase::getDataName(%obj); 

					if(%name == "VehiclePad")
					{
					
						%st = GameBase::getPosition(%this);
						%vp = GameBase::getPosition(%obj);
						%dist = Vector::getDistance(%st, %vp);

						echo ("Station Dist " @ %dist);
						
						if (%dist < %maxlook)
						{
							%temp = %obj;
							%maxlook = %dist;
						}
					}
				}			
				%this.vehiclePad = %temp;
				GameBase::setActive(%this.vehiclePad,true);
				%i = %numItems;					

			}
			schedule("VehicleStation::onBuyingVechicle(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{
		%player = Client::getOwnedObject(%this.target);   
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		%player.dropcount = 0;
		Station::onEndSequence(%this);
	}
}

function VehicleStation::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	
	if(GameBase::isPowered(%obj) && GameBase::getDamageState(%obj) == "Enabled")
	{
		%markerPos = GameBase::getPosition(%obj);
  		%set = newObject("vehicleset",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;
		%objInWay = containerBoxFillSet(%set,%mask,%markerPos,6,5,14,1);

		%mask = $StaticObjectType;
  		%Tset = newObject("vehicleTestset",SimSet);
		%dway = containerBoxFillSet(%Tset,%mask,%markerPos,6,5,14,1);
		%objInWay += (%dway - 1);
		if(%Tset)deleteobject(%Tset);

		%station = %player.Station;
		
		if(%objInWay == 1) 
		{
			%object = Group::getObject(%set, 0);	
			%sName = GameBase::getDataName(%object);
			if(%sName.className == Vehicle) 
			{
				if(GameBase::getControlClient(%object) == -1) 
				{
					if(%station.fadeOut == "") 
					{
						if(%item != $VehicleToItem[%sname]) 
						{
							%object.fading = 1;
							%station.fadeOut=1;
							teamEnergyBuySell(%player,$VehicleToItem[%sName].price);
							$TeamItemCount[Client::getTeam(%client) @ ($VehicleToItem[%sName])]--;
							GameBase::startFadeOut(%object);
							schedule("deleteobject(" @ %object @ ");",0.5,%object);
							schedule(%object @ ".fading = \"\";",0.4,%object);
							schedule(%station @ ".fadeOut = \"\";",0.5,%station);
							%objInWay--;
						}
						else
						{ if(%set)deleteobject(%set); }
							return 2;
					}
					else
					{
						Client::SendMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						if(%set)deleteobject(%set);
						return 0;
					}
				}
				else { 
					Client::SendMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					if(%set)deleteobject(%set);
					return 0;
				}
			} 
		}
		if(!%objInWay) 
		{
			if (checkResources(%player,%item,1))
			{
	    			%vehicle = newObject("",flier,$DataBlockName[%item],true);
				Gamebase::setMapName(%vehicle,%item.description);
            			%vehicle.clLastMount = %client;
				addToSet("MissionCleanup", %vehicle);
			  	GameBase::setTeam(%vehicle,Client::getTeam(%client));

				%padd = "0 0 1";
				%pos = Vector::add(%markerPos, %padd);

				if(%object.fading)
				{ 
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %pos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else
				{
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%pos);
					GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
				 	%obj.busy = getSimTime() + 3;
				}
				if(%set)deleteobject(%set);
				$TeamItemCount[Client::getTeam(%client) @ %item]++;
				return 1;
			}
		}
		else
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
			if(%set)deleteobject(%set);
	}	
	else
		Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");
                return 0;
}



function VehicleStation::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.015;				  
		GameBase::setRechargeRate(%this,15);
		GameBase::setActive(%this,true);
	}
	Station::onEnabled(%this);
}

function VehicleStation::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Station::onDisabled(%this);
	GameBase::setActive(%this,false);
}

function VehicleStation::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.015;
		GameBase::setRechargeRate(%this,15);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
	}
	Station::onPower(%this,%power,%generator);
}

function VehicleStation::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

StaticShapeData VehiclePad
{
   description = "Vehicle Pad";
	shapeFile = "vehi_pur_poles";
	className = "Station";
	//visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 0.5;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	maxEnergy = 5000;
   shieldShapeName = "shield_medium";
	mapIcon = "M_station";
   explosionId = flashExpLarge;
	damageSkinData = "objectDamageSkins";
};


function VehiclePad::onActivate(%this)
{
	GameBase::playSequence(%this,1,"use");
}

function VehiclePad::onDeactivate(%this)
{
	GameBase::stopSequence(%this,1);
}

function VehiclePad::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.03;				  
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

function VehiclePad::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
}

function Sensor::onDestroyed(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
   StaticShape::onDestroyed(%this);
}

function VehiclePad::onAdd(%this)
{
}

function VehiclePad::onCollision(%this, %obj)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%disable = GameBase::getDisabledDamage(%this);
	if(getObjectType(%obj) == "Player" && GameBase::getTeam(%this) == GameBase::getTeam(%obj))
	{
		%armor = Player::getArmor(%obj);
		if (%armor == "earmor" || %armor == "efemale")
		{
			if(GameBase::getDamageLevel(%this)) 
			{
				GameBase::repairDamage(%this,0.10);
				GameBase::playSound(%this,ForceFieldOpen,0);
	     	}
		}

		if(%damagelevel >= %disable)
		{
			%client = Player::getClient(%obj);
			Client::sendMessage(%client,1,"Unit is not powered or disabled.");
		}
	}
}

function VehiclePad::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.3;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
	}
	GameBase::setActive(%this,%power);
}

function VehiclePad::checkSeq(%this, %station)
{
	if(%station.target == "")
		GameBase::setActive(%this,false);
}

function VehiclePad::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}