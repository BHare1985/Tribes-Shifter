//=========================================================================== Deployable InvoStation
StaticShapeData DeployableInvStation
{
	description = "Remote Inv Unit";
	shapeFile = "invent_remote";
	className = "DeployableStation";
	maxDamage = 0.25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundInventoryStationPower };			
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisMedium;
	damageSkinData = "objectDamageSkins";
   	explosionId = flashExpSmall;
   	//validateShape = true;
	//validateMaterials = true;
};


function DeployableInvStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Inv Station");
	%this.Energy = $RemoteInvEnergy;
}

function DeployableInvStation::onActivate(%this)
{
	if(%this.deployed == 1) 
	{
		GameBase::playSequence(%this,1,"use");
 		InventoryStation::onResupply(%this,"RemoteInvList");
	}
	else
		GameBase::setActive(%this,false);
}


//====================================================================== Deployable Station Functions
function DeployableStation::onActivate(%this)
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


function DeployableStation::onEndSequence(%this,%thread)
{
	if(!%thread)
	{
		%this.deployed = 1;
		GameBase::playSequence(%this,2,"power");
	}
}

function DeployableStation::deploy(%this)
{
	GameBase::playSequence(%this,0,"deploy");
}

function DeployableStation::onDeactivate(%this)
{
	GameBase::stopSequence(%this,1);
}

function DeployableStation::onEnabled(%this)
{
	GameBase::playSequence(%this,2,"power");
}

function DeployableStation::onDisabled(%this)
{
	GameBase::stopSequence(%this,2);
	GameBase::stopSequence(%this,1);
	Station::checkTarget(%this);
	Station::weaponCheck(%this);
}

function DeployableStation::onDestroyed(%this)
{
	DeployableStation::onDisabled(%this);
	%stationName = GameBase::getDataName(%this);

	if(%stationName == DeployableInvStation) 
   {
		$dlist = string::greplace($dlist, %this, "");
		//echo("Killing Invo:" @ %this);
		//echo($dlist);
		$TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--;
	}
	else if( %stationName == DeployableAmmoStation) 
	{
		$dlist = string::greplace($dlist, %this, "");
		//echo("Killing Ammo:" @ %this);
		//echo($dlist);		
		$TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--;
	}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 0.1, 200, 100);
	
	Station::weaponCheck(%this);
}

function DeployableStation::onCollision(%this, %object)
{

	if (getObjectType(%object) != "Player" || Player::isAIControlled(%object) || Player::isDead(%object) || isPlayerBusy(%object))
		return;
	//{
	%obj = getObjectType(%object);
		if (Player::isAIControlled(%object))
			return;
		if (Player::isDead(%object))
			return;

		if (isPlayerBusy(%object) == 0)
		{
			%client = Player::getClient(%object);
			%armor = Player::getArmor(%object);

			if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1 || (%armor == "spyarmor" || %armor == "spyfemale") )
			{
				if (GameBase::getDamageState(%this) == "Enabled")
				{
					%data = GameBase::getDataName(%this);     
					if (%data.description == "Missile Control Station")
					{
						if(GameBase::getDamageState(%this.comstation) == "Enabled")
						{       
							schedule("CoolStationCheck(" @ %this @ ", " @ %object @ ");",0.5,%this);
							return;
						}
						else
						{       
							Client::sendMessage(%client,0,"Turret is damaged.~waccess_denied.wav");
						}      
						return;
					} 

						if(%this.enterTime == "") 
							%this.enterTime = getSimTime();
						GameBase::setActive(%this,true);
				}
				else 
					Client::sendMessage(%client,0,"Unit is disabled");
			}
			else if(Station::getTarget(%this) == %object)
			{
				%curTime = getSimTime();
				if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
				{
					%object.stationDeniedStamp = %curTime;
					Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
				}
			}
		}
	//}
}
