
function StaticShape::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}

function StaticShape::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function StaticShape::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}

function StaticShape::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);

	//GreyFlcn
	if (getObjectType(%this.lastDamageObject) != "Player") {}
	else
	StaticShape::objectiveDestroyed(%this);
	//GreyFlcn, fine take this shit out.  Even though it's on every other beta, or mod
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
	if(%this > 3000)
	{
			$dlist = string::greplace($dlist, %this, "");
			//echo("Killing Wall:" @ %this);
			//echo($dlist);
	}
}


function StaticShape::onCollision(%this,%obj)
{
//	%data = GameBase::getDataName(%obj);
//	if(%data.shapefile == "rocket")
//	{
//		if (%obj.missilegone != 1){%obj.missilegone = 1;}
//		else{return;}	
//		GameBase::setDamageLevel(%obj, 10);
//		return;
//	}	
//	if ($debug) echo (" THIS =  " @ %this @ " DATA " @ GameBase::getDataName(%this).shapefile);
//	if ($debug) echo (" OBJS =  " @ %obj @ " DATA " @ GameBase::getDataName(%obj).shapefile );
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
   			
   	if (%object != "0" && %object != -1)
   	{
   		if (gamebase::getownerclient(%object) != "-1")
   			%this.lastDamageObject = client::getownedobject(gamebase::getownerclient(%object));
		else   	
   			%this.lastDamageObject = %object;
   	}
   	
   	%this.lastDamageTeam = GameBase::getTeam(%this.lastDamageObject);
	
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{	
		%name = GameBase::getDataName(%this);
		if((%name.className == Generator || %name.className == Station) && %type != $CrushDamageType)
		{
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);

			if((!$Server::TourneyMode && %dValue > %disable - 0.05) && !%this.base)
			{
				if(%damageLevel > %disable - 0.05)
					return;
				else
					%dValue = %disable - 0.05;
			}
		}
	}
	else
	{
		if (%this.base)
		{
			%shape = (GameBase::getDataName(%this)).shapeFile;
			%name = GameBase::getDataName(%this);
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);

			if ((%type == $NukeDamageType) && (%shape == "inventory_sta" || %shape == "vehi_pur_poles" || %shape == "radar" || %shape == "vehi_pur_pnl" || %shape == "generator_p" || %shape == "cmdpnl"))
			{
				%value = %value * 0.125;
			}		
			else if ((%type != $NukeDamageType) && (%shape == "inventory_sta" || %shape == "vehi_pur_poles" || %shape == "radar" || %shape == "vehi_pur_pnl" || %shape == "generator_p" || %shape == "cmdpnl"))
			{
				if(%damageLevel > %name.maxDamage - 0.05)
					return;
				else
					%dValue = %name.maxDamage - 0.05;		
				GameBase::setDamageLevel(%this,%dValue);
				return;
			}
			else if ((%type != $NukeDamageType) && (%shape != "inventory_sta" || %shape != "vehi_pur_poles" || %shape != "radar" || %shape != "vehi_pur_pnl" || %shape != "generator_p" || %shape != "cmdpnl"))
			{
				return;
			}

			if (%type == $NukeDamageType)
			{
				if (%damageLevel >= %name.maxDamage)
				{
					if (%this)deleteobject (%this);
					if (%this.part)	deleteobject(%this.part);
					return;
				}
				else if(%damageLevel < %name.maxDamage)
				{
				}
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	if(%type == $GravDamageType)return;
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	
	if (%this.shieldStrength)
	{
		if (%type == $HBlasterDamageType)
			%value = %value * 1.5;
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		if (%type == $ShrapnelDamageType)
			%strength *= 0.5;
		else
			if (%type == $MortarDamageType)
				%strength *= 0.25;
			else if (%type == $BlasterDamageType)
				%strength *= 2.0;
			
		%absorb = %energy * %strength;

		if (%value < %absorb)
		{
			GameBase::setEnergy(%this,%energy - (%value / %strength));
			%centerPos = getBoxCenter(%this);
			%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
			%centerPosX = getWord(%centerPos,0);
			%centerPosY = getWord(%centerPos,1);
			%centerPosZ = getWord(%centerPos,2);

			%pointX = getWord(%pos,0);
			%pointY = getWord(%pos,1);
			%pointZ = getWord(%pos,2);

			%newVecX = %centerPosX - %pointX;
			%newVecY = %centerPosY - %pointY;
			%newVecZ = %centerPosZ - %pointZ;
			%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
			%zOffset = 0;

			if(GameBase::getDataName(%this) == PulseSensor)
				%zOffset = (%pointZ-%centerPosZ) * 0.5;
			
			GameBase::activateShield(%this,%sphereVec,%zOffset);
		}
		else
		{
			GameBase::setEnergy(%this,0);
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	}
	else
	{
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
{
	%radius = GameBase::getRadius(%this);
	if(%radius)
	{
		%radius *= %radiusRatio;
		%damageValue = %radius * %damageRatio;
		%force = %radius * %forceRatio;
		
		if(%radius > %rMax)
			%radius = %rMax;
		else if(%radius < %rMin)
			%radius = %rMin;
		
		if(%damageValue > %dMax)
			%damageValue = %dMax; 
		else if(%damageValue < %dMin)
			%damageValue = %dMin;
		
		if(%force > %fMax)
			%force = %fMax; 
		else if(%force < %fMin)
			%force = %fMin;

		GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius,	%damageValue,%force,%this);
	}
}

StaticShapeData FlagStand
{
	description = "Flag Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};

function FlagStand::onDamage(){}

//========================================================================= Power Devices
StaticShapeData Generator 	{ description = "Generator"; shapeFile = "generator"; className = "Generator"; sfxAmbient = SoundGeneratorPower; debrisId = flashDebrisLarge; explosionId = flashExpLarge; maxDamage = 2.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; };
StaticShapeData SolarBig 	{ description = "SolarBig"; shapeFile = "solar"; className = "Generator"; sfxAmbient = SoundGeneratorPower; debrisId = flashDebrisLarge; explosionId = flashExpLarge; maxDamage = 5.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; };
StaticShapeData SolarPanel 	{ description = "Solar Panel"; shapeFile = "solar_med"; className = "Generator"; debrisId = flashDebrisMedium; maxDamage = 1.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpLarge; };
function SolarPanel::onCollision(%this,%obj)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%disable = GameBase::getDisabledDamage(%this);
	if(getObjectType(%obj) == "Player" && %damagelevel >= %disable && GameBase::getTeam(%this) == GameBase::getTeam(%obj))
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

		%client = Player::getClient(%obj);
		Client::sendMessage(%client,1,"Unit is not powered or disabled.");
	}
}
StaticShapeData PortGenerator 	{ description = "Portable Generator"; shapeFile = "generator_p"; className = "Generator"; debrisId = flashDebrisSmall; sfxAmbient = SoundGeneratorPower; maxDamage = 1.6; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; visibleToSensor = true; mapFilter = 4; };
function PortGenerator::onCollision(%this,%obj)
{	%damageLevel = GameBase::getDamageLevel(%this);
	%disable = GameBase::getDisabledDamage(%this);
	if(getObjectType(%obj) == "Player" && %damagelevel >= %disable && GameBase::getTeam(%this) == GameBase::getTeam(%obj))
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

		%client = Player::getClient(%obj);
		Client::sendMessage(%client,1,"Unit is not powered or disabled.");
	}
}
//========================================================================= Generator Functions
function Generator::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

function Generator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
	if ($debug) echo ("Generator::onDestroyed - Start");
	StaticShape::objectiveDestroyed(%this);
	//dbecho ("Generator::onDestroyed - Finish");	
	//DumpObjectTree(); echo ("Gen Up Adding to Tree...");
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	if(%this > 3000)
	{
			$dlist = string::greplace($dlist, %this, "");
			//echo("Killing PortGen:" @ %this);
			//echo($dlist);
	}
}

function Generator::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
}

function Generator::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

function Generator::onCollision(%this,%obj)
{	%damageLevel = GameBase::getDamageLevel(%this);
	%disable = GameBase::getDisabledDamage(%this);
	if(getObjectType(%obj) == "Player" && %damagelevel >= %disable && GameBase::getTeam(%this) == GameBase::getTeam(%obj))
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

		%client = Player::getClient(%obj);
		Client::sendMessage(%client,1,"Unit is not powered or disabled.");
	}
}


//========================================================================= Switches
StaticShapeData TowerSwitch 	{ description = "Tower Control Switch"; className = "towerSwitch"; shapeFile = "tower"; showInventory = "false"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; };

//========================================================================= Misc Antenna & Panels
StaticShapeData ArrayAntenna 		{ shapeFile = "anten_lava"; debrisId = flashDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Array Antenna"; };
StaticShapeData BluePanel 		{ shapeFile = "panel_blue"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData CargoBarrel 		{ shapeFile = "liqcyl"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Cargo Barrel"; };
StaticShapeData CargoCrate 		{ shapeFile = "magcargo"; debrisId = flashDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Cargo Crate"; };
StaticShapeData DisplayPanelOne 	{ shapeFile = "display_one"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData DisplayPanelThree 	{ shapeFile = "display_three"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData DisplayPanelTwo 	{ shapeFile = "display_two"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData ForceBeacon 		{ shapeFile = "force"; debrisId = defaultDebrisSmall; maxDamage = 0.9; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Force Beacon"; };
StaticShapeData HOnePanel 		{ shapeFile = "dsply_h1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData HTwoPanel 		{ shapeFile = "dsply_h2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData LargeAntenna 		{ shapeFile = "anten_lrg"; debrisId = defaultDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Large Antenna"; };
StaticShapeData MediumAntenna 		{ shapeFile = "anten_med"; debrisId = flashDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Medium Antenna"; };
StaticShapeData RodAntenna 		{ shapeFile = "anten_rod"; debrisId = defaultDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Rod Antenna"; };
StaticShapeData SetPanel 		{ shapeFile = "panel_set"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData SmallAntenna 		{ shapeFile = "anten_small"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Small Antenna"; };
StaticShapeData SOnePanel 		{ shapeFile = "dsply_s1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData SquarePanel 		{ shapeFile = "teleport_square"; debrisId = flashDebrisSmall; maxDamage = 0.3; damageSkinData = "objectDamageSkins"; explosionId = flashExpMedium; description = "Panel"; };
StaticShapeData STwoPanel 		{ shapeFile = "dsply_s2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VerticalPanel 		{ shapeFile = "teleport_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VerticalPanelB 		{ shapeFile = "panel_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VOnePanel 		{ shapeFile = "dsply_v1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData VTwoPanel 		{ shapeFile = "dsply_v2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };
StaticShapeData YellowPanel 		{ shapeFile = "panel_yellow"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; };

//========================================================================= Force Field Walls (Non-Movable)
StaticShapeData ForceField 	{ shapeFile = "forcefield"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField1 	{ shapeFile = "ForceField_3x4"; debrisId = defaultDebrisSmall; maxDamage = 36.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField2 	{ shapeFile = "ForceField_4x17"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField3 	{ shapeFile = "ForceField_4x8"; debrisId = defaultDebrisSmall; maxDamage = 36.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField4 	{ shapeFile = "ForceField_5x5"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData ForceField5 	{ shapeFile = "ForceField_4x14"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Force Field"; };
StaticShapeData PlasmaWall 	{ shapeFile = "plasmawall"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "PlasmaWall"; };

//========================================================================= Misc Not In Base
StaticShapeData Enerpad 	{ shapeFile = "enerpad"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Telepad"; };
StaticShapeData Mainpad 	{ shapeFile = "mainpad"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "MainPad"; };
StaticShapeData TribesLogo 	{ shapeFile = "logo"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "logo"; };
StaticShapeData Bridge 		{ shapeFile = "bridge"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "Bridge"; };
StaticShapeData GunTuret 	{ shapeFile = "GunTuret"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "gunturet"; };
StaticShapeData SatBig 		{ shapeFile = "sat_big"; debrisId = defaultDebrisSmall; maxDamage = 10000.0; isTranslucent = true; description = "SatBig"; };

//========================================================================= Beams
StaticShapeData ElectricalBeam 		{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData ElectricalBeamBig 	{ shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
StaticShapeData PoweredElectricalBeam 	{ shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; };
function PoweredElectricalBeam::onPower(%this, %power, %generator)
{
	if(%power)
		GameBase::startFadeIn(%this);
	else
		GameBase::startFadeOut(%this);
}

//========================================================================= Enviromental
StaticShapeData Cactus1 { shapeFile = "cactus1"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; };
StaticShapeData Cactus2 { shapeFile = "cactus2"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; };
StaticShapeData Cactus3 { shapeFile = "cactus3"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; };
StaticShapeData PlantOne { shapeFile = "plant1"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Plant"; };
StaticShapeData PlantTwo { shapeFile = "plant2"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Plant"; };
StaticShapeData SteamOnGrass { shapeFile = "steamvent_grass"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; };
StaticShapeData SteamOnGrass2 { shapeFile = "steamvent2_grass"; maxDamage = 999.0; isTranslucent = "True"; };
StaticShapeData SteamOnMud { shapeFile = "steamvent_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; };
StaticShapeData SteamOnMud2 { shapeFile = "steamvent2_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; };
StaticShapeData TreeShape { shapeFile = "tree1"; maxDamage = 10.0; isTranslucent = "True"; description = "Tree"; };
StaticShapeData TreeShapeTwo { shapeFile = "tree2"; maxDamage = 10.0; isTranslucent = "True"; description = "Tree"; };

function ff::Open(%this, %delay)
{
	if(%this.originalpos == "")	
	{
		%this.originalpos = GameBase::getPosition(%this);
		%this.isactive = false;
	}
	if(%this.isactive == false)
	{
		GameBase::startfadeout(%this);
		%this.isactive = true;
		schedule("ff::Open("@ %this @");",%delay);
		%pos = %this.originalpos;
		%newpos = Vector::add(%pos, "0 0 5000" );
		GameBase::playSound(%this,ForceFieldOpen,0);
		gamebase::setposition(%this, %newpos);
	}
	else
	{
		%this.isactive = false;
		GameBase::setPosition(%this, %this.originalpos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@ %this @",ForceFieldClose,0);",0.35,%this);
	}
}

function HopOut(%obj)
{
	if(%obj.driver)
		Vehicle::dismount(%obj.vehicle,"0 0 0");
	else
	{
		%height = 8;
		%velocity = 100;
		%zVec = 100;
		%pos = GameBase::getPosition(%obj);
		%posX = getWord(%pos,0);
		%posY	= getWord(%pos,1);
		%posZ	= getWord(%pos,2);
		%client = Player::getClient(%obj);
		(%obj.vehicle).Seat[%obj.vehicleSlot-2] = "";
		%obj.vehicleSlot = "";
		%obj.vehicle = "";
		Player::setMountObject(%obj, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%obj),2);
		GameBase::setRotation(%obj, "0 0 " @ %rotZ);
		GameBase::setPosition(%obj,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
		%client.inflyer = 0;
		Player::applyImpulse(%obj,%jumpDir);
	}
}

function bumpUp(%obj)
{
	%opos = GameBase::getPosition(%obj);
	%newpos = Vector::add(%opos, "0 0 10");
	gamebase::setposition(%obj, %newpos);
}

//============================================================================ Small Force Field
// Deployable Forcefield 

StaticShapeData DeployableForceField { shapeFile = "forcefield_3x4"; debrisId = defaultDebrisSmall; maxDamage = 5.50; visibleToSensor = true; isTranslucent = true; description = "Small Force Field"; };
function DeployableForceField::onCollision(%this,%obj)
{
	if(getobjecttype(%obj) == "Flier")
		BumpUp(%obj); //HopOut(%obj); //GameBase::setDamageLevel(%obj.vehicle, 10);
	else if(GameBase::getDataName(%obj).shapefile == "rocket")
		GameBase::setDamageLevel(%obj, 10);
	else if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
		{}
	else if (GameBase::getTeam(%obj) == Gamebase::getTeam(%this) || (Player::getArmor(%obj) == "spyarmor" || Player::getArmor(%obj) == "spyfemale") )
		ff::Open(%this, 1);
}

function DeployableForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
}

//============================================================================ Large Force Field
StaticShapeData LargeForceField { shapeFile = "forcefield"; debrisId = defaultDebrisLarge; maxDamage = 8.00; visibleToSensor = true; isTranslucent = true; description = "Large Force Field"; };
function LargeForceField::onCollision(%this,%obj)
{
	if(getobjecttype(%obj) == "Flier")
		BumpUp(%obj); //HopOut(%obj); //GameBase::setDamageLevel(%obj.vehicle, 10);
	else if(GameBase::getDataName(%obj).shapefile == "rocket")
		GameBase::setDamageLevel(%obj, 10);
	else if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
		{}
	else if (GameBase::getTeam(%obj) == Gamebase::getTeam(%this) || (Player::getArmor(%obj) == "spyarmor" || Player::getArmor(%obj) == "spyfemale") )
		ff::Open(%this, 2.75);
}

function LargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;	
}

//============================================================================ Large Shock ForceField
StaticShapeData LargeShockForceField { shapeFile = "forcefield"; debrisId = defaultDebrisLarge; maxDamage = 8.00; visibleToSensor = true; isTranslucent = true; description = "Large Shock Force Field"; };
function LargeShockForceField::onCollision(%this,%obj)
{
	if(getobjecttype(%obj) == "Flier")
		BumpUp(%obj); //HopOut(%obj); //GameBase::setDamageLevel(%obj.vehicle, 10);
	else if(GameBase::getDataName(%obj).shapefile == "rocket")
		GameBase::setDamageLevel(%obj, 10);
	else if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
		{}
	else if (GameBase::getTeam(%obj) == Gamebase::getTeam(%this)) // || (Player::getArmor(%obj) == "spyarmor" || Player::getArmor(%obj) == "spyfemale") 
		ff::Open(%this, 2.75);
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		GameBase::applyDamage(%obj,$FlashDamageType,0.30,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
	}
}

function LargeShockForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeShockForceFieldPack"]--;	
}

//============================================================================ Shock Floor ForceField
// Created by Mark Williamson for his customized Shifter servers
// contact mark@webpit.com (Customized by Emo1313 to Open by Teammates)
//	Wow that was buggy, all nice and clean now

StaticShapeData ShockFloor
{
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisLarge;
	maxDamage = 12.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Shock Floor";
};

function ShockFloor::onCollision(%this,%obj)
{
	if(getobjecttype(%obj) == "Flier")
		BumpUp(%obj); //GameBase::setDamageLevel(%obj.vehicle, 10);
	else if(GameBase::getDataName(%obj).shapefile == "rocket")
		GameBase::setDamageLevel(%obj, 10);
	else if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
		{}
	else if (GameBase::getTeam(%obj) == Gamebase::getTeam(%this))// || (Player::getArmor(%obj) == "spyarmor" || Player::getArmor(%obj) == "spyfemale") 
		ff::Open(%this, 2.75);
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		GameBase::applyDamage(%obj,$FlashDamageType,0.30,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);
	}
}

function ShockFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockFloorPack"]--;	
}

//============================================================================ Blast Wall
StaticShapeData BlastWall { shapeFile = "newdoor5"; maxDamage = 12.0; debrisId = defaultDebrisLarge; explosionId = debrisExpLarge; description = "BlastWall"; damageSkinData = "objectDamageSkins"; visibleToSensor = true; };
function BlastWall::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;	
}

function BlastWall::onCollision(%this,%obj)
{
	if(getobjecttype(%obj) == "Flier")
		BumpUp(%obj); //GameBase::setDamageLevel(%obj, 10);
}

//============================================================================ Blast Floor
StaticShapeData BlastFloor { shapeFile = "elevator_8x8"; maxDamage = 12.0; debrisId = defaultDebrisLarge; explosionId = debrisExpLarge; description = "BlastWall"; damageSkinData = "objectDamageSkins"; };
function BlastFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastFloorPack"]--;	
}

function BlastWall2::onCollision(%this,%obj)
{
}

function BlastFloor::onCollision(%this,%obj)
{
	if(getobjecttype(%obj) == "Flier")
		BumpUp(%obj);
}

//============================================================================ Blast Wall2
StaticShapeData BlastWall2 { shapeFile = "teleport_vertical"; maxDamage = 10.0; debrisId = defaultDebrisLarge; explosionId = debrisExpLarge; description = "BlastWall"; };
function BlastWall2::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;
}

//============================================================================ Deployable Platform
StaticShapeData DeployablePlatform { shapeFile = "elevator_4x4"; debrisId = defaultDebrisSmall; maxDamage = 6.00; visibleToSensor = false; isTranslucent = true; description = "Deployable Platform"; damageSkinData = "objectDamageSkins"; };
function DeployablePlatform::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
	
}

//============================================================================ Tree 1

StaticShapeData DeployableTree { shapeFile = "tree1"; debrisId = defaultDebrisSmall; maxDamage = 20.0; visibleToSensor = false; isTranslucent = true; description = "Deployable Tree"; };
StaticShapeData DeployableTree2 { shapeFile = "tree2"; debrisId = defaultDebrisSmall; maxDamage = 20.0; visibleToSensor = false; isTranslucent = true; description = "Deployable Tree"; };
function DeployableTree::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}
function DeployableTree2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

//============================================================================ Cactus 2

StaticShapeData DeployableCactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
   	description = "Cactus";
};

function DeployableCactus2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlantPack"]--;
	
}

function DeployableCactus2::onCollision(%this,%obj)
{
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }	
	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);


	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(GameBase::getDamageLevel(%obj)) 
	{
		GameBase::repairDamage(%obj,0.3);
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}

//============================================================================ HoloGram 1

StaticShapeData Hologram1
{
	shapeFile = "larmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.75;
   	description = "Hologram";
};

function Hologram1::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}

//============================================================================ HoloGram 2
StaticShapeData Hologram2
{
	shapeFile = "marmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.10;
   	description = "Hologram";
};

function Hologram2::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}

//============================================================================ HoloGram 3
StaticShapeData Hologram3
{
	shapeFile = "harmor";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
   	description = "Hologram";
};

function Hologram1::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}
    
//=-=-=-=-=- Teleporter =-=-=-=-
StaticShapeData DeployableTeleport
{
    	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 1.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    	explosionId = mortarExp;
    	debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};
				
function RemoveBeam(%b)
{
	if(%b)deleteobject(%b);
}				
														 
function DeployableTeleport::onDestroyed(%this)
{
	schedule("RemoveBeam("@%this.beam1@");",1);

	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
		{
			GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			return;
		}
	}
}

function DeployableTeleport::onCollision(%this,%obj)
{
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }	
	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(%teleTeam != %playerTeam)
	{
		if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
			Client::SendMessage(%c,0,"Phased through enemy teleporter");
		else
		{ 
			Client::SendMessage(%c,0,"Wrong Team"); 
			return;
		}
	}

	if(%this.disabled == true)
	{
	        Client::SendMessage(%c,0,"Teleport Pad is recharging");
	        return;
	}

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if ($Debug) echo ("Group Set Teleporter = " @ Group::getObject(%teleset, %i));
		if(GameBase::getTeam(%o) == %playerteam && %o != %this)
		{
			%armor = Player::getArmor(%obj);
			//if(%armor == "harmor" || %armor == "darmor") // || %armor == "jarmor"
			//{
			///	   Client::SendMessage(%c,0,"Armor too Heavy to Teleport.");
			//		return;
			//}
			//else
			//{
				GameBase::playSound(%obj,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
				GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;
			//}
		}
		else if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
		{
			if(GameBase::getTeam(%o) != %playerteam && %o != %this)
			{
				Client::SendMessage(%c,0,"Transporting To Enemy Telepad!");
				GameBase::playSound(%o,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
		           	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;								
			}		
		}
	}
	Client::SendMessage(%c,0,"No other pad to teleport to.");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

//================================================ Air Bases ====================================================

StaticShapeData AirAmmoBasePad //=================================================================== Air Ammo Pad
{
        shapeFile = "elevator6x6thin";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        //visibleToSensor = true;
        mapFilter = 4;
        description = "AirAmmoBasePad";
};

//================================================================================================== Air Base
StaticShapeData LargeAirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 36.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};

StaticShapeData LargeEmplacementPlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 36.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = false;
        mapFilter = 4;
        description = "Emplacement";
};
//============================================== Personal Movers 

StaticShapeData AccelPadPack
{
	className = "AccelPadPack";
	damageSkinData = "objectDamageSkins";
	shapeFile = "elevator_6x6_octagon";
	maxDamage = 3.33333;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = debrisExpLarge;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = false;
};

function AccelPadPack::Destruct(%this)
{
	AccelPadPack::doDamage(%this);
}

function AccelPadPack::doDamage(%this) {}

function AccelPadPack::onDestroyed(%this)
{
	AccelPadPack::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AccelPPack"]--;
}

function AccelPadPack::onCollision(%this,%obj)
{
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }
	if(getObjectType(%obj) != "Player") {return;}
	if(Player::isDead(%obj)) {return;}
	%c = Player::getClient(%obj);
	%pteam = GameBase::getTeam(%obj);
	%oteam = GameBase::getTeam(%this);
	%diffZ=getWord(GameBase::getPosition(%obj),2)-getWord(GameBase::getPosition(%this),2);

	if(!%obj.accelpad || %obj.accelpad == 0)
	{
		%obj.accelpad = %this;
		%obj.accelmulti = 1;
	}
	else if(%this != %obj.accelpad)
	{
		if(%obj.accelmulti < 2)
			%obj.accelmulti++;
		else
			return;
		echo("Accel multi = " @ %obj.accelmulti);
	}

	//if(%pteam==%oteam)
	//{
		if(%obj.deployStandby != 1)
		{
			if(%diffZ>0.950)
			{
				%obj.deployStandby=1;
				%msg="<f1>Accelerator Pad : <f0>Face the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.";
				remoteEval(%c, "BP", %msg, 0);
				AccelPadPack::CheckPlayer(%this,%obj);
			}
		}
		else if(%diffZ<0.950)
		{
			remoteEval(%c, "CP", "", 0);
			%obj.deployStandby=0;
		}
	//}
	//return;
}

function AccelPadPack::CheckPlayer(%this,%obj)
{
	%opos = GameBase::getPosition(%obj);
	%tpos = GameBase::getPosition(%this);
	%diffZ=getWord(%opos,2)-getWord(%tpos,2)-0.92;

	%deploy=0;
	%recall=1;

	if(%diffZ>0.5) %deploy=1;
	if(%diffZ<0) %deploy=-1;
	
	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%client);
	
	if(%deploy>0)
	{
		%armor=GameBase::getDataName(%obj);
		%mass=%armor.mass;
		%rot=GameBase::getRotation(%obj);
		%len=50;
		%zlen=50;

			if (%armor == "barmor" || %armor == "bfemale" || %armor == "aarmor" || %armor == "afemale" || %armor == "earmor" || %armor == "efemale" || %armor == "marmor" || %armor == "mfemale")
	 		{
				%len = 40;
				%zlen = 35; 
	 		}
			else if (%armor == "darmor" || %armor == "jarmor" || %armor == "parmor")
 			{
				%len = 30;
				%zlen = 30;
	 		}

		playSound(debrisMediumExplosion,%tpos);
		playSound(bigExplosion2,%tpos);//debrisSmallExplosion

		%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
		Player::applyImpulse(%obj,%vec);
		schedule(%obj@".deployStandby=0;",0.1);
		schedule(%obj@".accelpad=0;",0.1);
		schedule(%obj@".accelmulti=0;",0.1);
		%recall=0;
	}
	else if(%deploy<0)
	{
		%recall=0;
		%obj.deployStandby=0;
		%obj.accelpad=0;
		%obj.accelmulti=0;
	}
	if(%recall)
	{
		schedule("AccelPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
	}
	else
	{
		remoteEval(%client, "CP", "", 0);
	}
}

//============================================================================================= Launch Pad

StaticShapeData DeployableLaunch
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.50;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Launch Pad";
};

function DeployableLaunch::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LaunchPack"]--;
}

function DeployableLaunch::onCollision(%this,%obj) 
{
	%c = Player::getClient(%obj);
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }	

	GameBase::playSound(%this, SoundFireMortar, 0);
	Client::SendMessage(%c, 0, "SPROING!");
	%velocity = 200;
	%zVec = 600;
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
}

// FireBolt Fountain
StaticShapeData FireBolt	{ damageSkinData = "objectDamageSkins"; shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function FireBolt::onAdd(%this) { schedule ("FireBolt::Pop(" @ %this @ ");",3); }
function FireBolt::Pop(%this)   { %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired = Projectile::spawnProjectile(FireBoltProj, %trans ,%this,"0 0 0"); %random = floor(getRandom() * 3)+1; schedule ("FireBolt::Pop(" @ %this @ ");",%random,%this); }
RocketData FireBoltProj		{ bulletShapeName  = "plasmabolt.dts"; explosionTag = plasmaExp; collisionRadius  = 0.0; mass = 0.0; damageClass = 0; damageValue = 0.15; damageType = $PlasmaDamageType; explosionRadius = 1.0; kickBackStrength = 0; muzzleVelocity   = 5.0; terminalVelocity = 5.0; acceleration = 5.0; totalTime = 1.5; liveTime = 1.5; lightRange = 1.0; lightColor = { 1, 1, 0 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "plasmabolt.dts"; smokeDist   = 5.0; soundId = SoundJetHeavy; };
function FireBolt::onDamage(%this) {}

// Electric Fountain
StaticShapeData elecbolt	{ damageSkinData = "objectDamageSkins"; shapeFile = "fusionbolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function elecbolt::onAdd(%this) { schedule ("elecbolt::Pop(" @ %this @ ");",3); }
function elecbolt::Pop(%this) 	{ %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired1 = Projectile::spawnProjectile(elecboltProj, %trans ,%this,"0 0 0"); schedule ("elecbolt::Pop(" @ %this @ ");",5,%this); }
RocketData elecboltProj		{ bulletShapeName  = "fusionbolt.dts"; explosionTag = energyExp; collisionRadius  = 0.0; mass = 0.0; damageClass = 0; damageValue = 0.15; damageType = $ElectricityDamageType; explosionRadius = 1.0; kickBackStrength = 0; muzzleVelocity   = 2.5; terminalVelocity = 2.5; acceleration = 2.5; totalTime = 4; liveTime = 4; lightRange = 4.0; lightColor = { 0, 0, 2 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "shockwave.dts"; smokeDist   = 5.0; soundId = SoundJetHeavy; };
function elecbolt::onDamage(%this) {}

// Electric Fountain 2
StaticShapeData electbolt2		{ damageSkinData = "objectDamageSkins"; shapeFile = "fusionbolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function electbolt2::onAdd(%this) 	{ schedule ("electbolt2::Pop(" @ %this @ ");",3); }
function electbolt2::Pop(%this) 	{ %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired1 = Projectile::spawnProjectile(electbolt2Proj, %trans ,%this,"0 0 0"); schedule ("electbolt2::Pop(" @ %this @ ");",5,%this); }
RocketData electbolt2Proj		{ bulletShapeName  = "fusionbolt.dts"; explosionTag = LargeShockwave; collisionRadius  = 0.0; mass = 0.0; damageClass = 0; damageValue = 0.05; damageType = $ElectricityDamageType; explosionRadius = 15.0; kickBackStrength = 0; muzzleVelocity   = 2.5; terminalVelocity = 25; acceleration = 3; totalTime = 8; liveTime = 8; lightRange = 4.0; lightColor = { 0, 0, 2 }; inheritedVelocityScale = 0.0; trailType = 2; trailString = "shockwave_large.dts"; smokeDist   = 15.0; soundId = SoundJetHeavy; };
function electbolt2::onDamage(%this) 	{}

// Electric Fountain 3
StaticShapeData electbolt3		{ damageSkinData = "objectDamageSkins"; shapeFile = "fusionbolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function electbolt3::onAdd(%this) 	{ schedule ("electbolt3::Pop(" @ %this @ ");",3); }
function electbolt3::Pop(%this) 	{ %pos = Gamebase::getposition(%this); %trans = "0 0 0 0 0 0.9 0 0 0 " @ %pos; %fired1 = Projectile::spawnProjectile(electbolt3Proj, %trans ,%this,"0 0 0"); schedule ("electbolt3::Pop(" @ %this @ ");",5,%this); }
GrenadeData electbolt3Proj 		{ bulletShapeName    = "shield_medium.dts"; explosionTag       = ShockwaveTwo; collideWithOwner   = False; ownerGraceMS       = 400; collisionRadius    = 1.0; mass               = 50.0; elasticity         = 0.01; damageClass        = 1;damageValue        = 12.00; damageType         = $NukeDamageType; explosionRadius    = 35.0; kickBackStrength   = 250.0; maxLevelFlightDist = 0; totalTime          = 500.0; liveTime           = 5.0; projSpecialTime    = 0.1; inheritedVelocityScale = 1.5; smokeName          = "shield_large.dts"; soundId = explosion4; };
function electbolt3::onDamage(%this) 	{}



// Meteor
StaticShapeData MeteorGun2 		{ className = "MeteorGun2"; damageSkinData = "objectDamageSkins"; shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function MeteorGun2::onAdd(%this)	{ schedule ("MeteorGun2::Pop(" @ %this @ ");",3); }
function MeteorGun2::onDamage(%this) {}

function MeteorGun2::Pop(%this) 	
{
	%pos = Gamebase::getposition(%this);

	for(%i = 1; %i < 10; %i++)
	{
		%a = getRandom();%b = getRandom();%c = getRandom();%trans = "0 0 0 " @ -%a @ " " @ -%b @ " -0.9 0 0 0 " @ %pos;Projectile::spawnProjectile(MeteorGun2Proj1, %trans ,%this,"1 1 1");
	}
	%random = floor(getRandom() * 5)+5;
	schedule ("MeteorGun2::Pop(" @ %this @ ");",%random,%this);
}

RocketData MeteorGun2Proj1
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0;
	mass = 2.0; 
	damageClass = 1;
    	damageValue = 0.55; 
	damageType = $ElectricityDamageType; 
	explosionRadius = 10; 
	kickBackStrength = 1.0; 
	muzzleVelocity = 500.0; 
	terminalVelocity = 500.0;
	acceleration = 250.0; 
	totalTime = 10.5; 
	liveTime = 10.3; 
	lightRange = 5.0; 
	lightColor = { 0.0, 0.7, 3.5 }; 
	inheritedVelocityScale = 0.2; 
	trailType = 1;
	trailLength = 1500; 
	trailWidth = 2.1; 
	soundId = SoundJetHeavy;
};

// Volter Fountain
StaticShapeData VoltBolt { damageSkinData = "objectDamageSkins";  shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0;  lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function VoltBolt::onAdd(%this) {  schedule ("VoltBolt::Pop(" @ %this @ ");",3); }
function VoltBolt::onDamage(%this){}
function VoltBolt::Pop(%this) { %pos = Gamebase::getposition(%this); %up = getRandom(); %trans = "0 0 0 0 0 " @ %up @ " 0 0 0 " @ %pos; %fired = Projectile::spawnProjectile(VoltBoltProj, %trans ,%this,"0 0 0"); %random = floor(getRandom() * 3)+1; schedule ("VoltBolt::Pop(" @ %this @ ");",5,%this); }
GrenadeData VoltBoltProj { explosionTag = plasmaExp; collideWithOwner = True; ownerGraceMS = 50; collisionRadius = 10.0; mass = 5.0; elasticity = 0.1; damageClass = 1; damageValue = 0.30; damageType = $ElectricityDamageType; explosionRadius = 5.0; kickBackStrength = 0.1; maxLevelFlightDist = 75; totalTime = 4.0; liveTime = 0.02; projSpecialTime = 0.01; lightRange = 10.0; lightColor = { 1, 1, 0 };  inheritedVelocityScale = 1.5; smokeName = "plasmatrail.dts"; soundId = SoundJetLight; };

// Meteor
StaticShapeData MeteorGun 		{ className = "MeteorGun"; damageSkinData = "objectDamageSkins"; shapeFile = "plasmabolt"; maxDamage = 10000; maxEnergy = 200; mapFilter = 2; visibleToSensor = false; explosionId = debrisExpLarge; debrisId = flashDebrisLarge; lightRadius = 12.0; lightType = 1; lightColor = {1.0,0.0,0.2}; side = "single"; isTranslucent = false; };
function MeteorGun::onAdd(%this) 	{ schedule ("MeteorGun::Pop(" @ %this @ ");",3); }
function MeteorGun::Pop(%this) 		{ %pos = Gamebase::getposition(%this); %up = getRandom(); %trans = "0 0 0 0 0 " @ -%up @ " 0 0 0 " @ %pos; %fired  = Projectile::spawnProjectile(MeteorGunProj1, %trans ,%this,"1 1 1"); %random = floor(getRandom() * 5)+5; schedule ("MeteorGun::Pop(" @ %this @ ");",%random,%this); }
GrenadeData MeteorGunProj1 		{ bulletShapeName    = "plasmaex.dts"; explosionTag       = ShockwaveTwo; collideWithOwner   = False; ownerGraceMS       = 400; collisionRadius    = 1.0; mass               = 50.0; elasticity         = 0.01; damageClass        = 1;damageValue        = 12.00; damageType         = $NukeDamageType; explosionRadius    = 35.0; kickBackStrength   = 250.0; maxLevelFlightDist = 0; totalTime          = 500.0; liveTime           = 5.0; projSpecialTime    = 0.1; inheritedVelocityScale = 1.5; smokeName          = "plasmatrail.dts"; soundId = explosion4; };
function MeteorGun::onDamage(%this) {}

//Uranium's custom static shape registers
//these antenna declorations won't affect regular antennas since they're redeclared
//with new names

StaticShapeData SuperSmallAntenna { shapeFile = "anten_small"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Small Antenna"; };
StaticShapeData SuperMediumAntenna { shapeFile = "anten_med"; debrisId = flashDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Medium Antenna"; };
StaticShapeData SuperLargeAntenna { shapeFile = "anten_lrg"; debrisId = defaultDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Large Antenna"; };

function SuperSmallAntenna::onDamage() {}
function SuperMediumAntenna::onDamage() {}
function SuperLargeAntenna::onDamage() {}

StaticShapeData platform_4x4 		{ shapeFile = "elevator_4x4"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_4x4::onDamage() { }
StaticShapeData platform_4x5 		{ shapeFile = "elevator_4x5"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_4x5::onDamage() { }
StaticShapeData platform_5x5 		{ shapeFile = "elevator_5x5"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_5x5::onDamage() { }
StaticShapeData platform_6x4 		{ shapeFile = "elevator6x4"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_6x4::onDamage() { }
StaticShapeData platform_6x4thin 	{ shapeFile = "elevator6x4thin"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_6x4thin::onDamage() { }
StaticShapeData platform_6x5 		{ shapeFile = "elevator_6x5"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_6x5::onDamage() { }
StaticShapeData platform_6x6thin 	{ shapeFile = "elevator6x6thin"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_6x6thin::onDamage() { }
StaticShapeData platform_6x6		{ shapeFile = "elevator_6x6"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_6x6::onDamage() { }
StaticShapeData platform_6x6octa 	{ shapeFile = "elevator_6x6_octagon"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_6x6_octagon::onDamage() { }
StaticShapeData platform_8x4 		{ shapeFile = "elevator_8x4"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_8x4::onDamage() { }
StaticShapeData platform_8x6 		{ shapeFile = "elevator_8x6"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_8x6::onDamage() { }
StaticShapeData platform_8x8 		{ shapeFile = "elevator_8x8"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_8x8::onDamage() { }
StaticShapeData platform_9x9 		{ shapeFile = "elevator_9x9"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_9x9::onDamage() { }
StaticShapeData platform_16x16Octa 	{ shapeFile = "elevator16x16_octo"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_16x16octa::onDamage() { }
StaticShapeData ShockwaveM 		{ shapeFile = "shockwave_large"; maxDamage = 10000.0; description = "Shockwave"; disableCollision = false; isTranslucent = False; }; function ShockwaveM::onDamage() { }

//Uranium's custom static shape registers
StaticShapeData Fire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = false; isTranslucent = true;  };
function Fire::onDamage(){}
StaticShapeData Twiggy{shapeFile = "mrtwig"; maxDamage = 10000.0; description = "Twig"; }; 
function Twiggy::onDamage(){}
//slow flares
ItemData SlowSmallOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowMedOrange 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowLargeOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 16; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowSmallRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 0, 0 }; };
ItemData SlowMedRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 0, 0 }; }; 
ItemData SlowLargeRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 0, 0 }; }; 
ItemData SlowSmallBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 0, 0, 1 }; }; 
ItemData SlowMedBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 0, 0, 1 }; }; 
ItemData SlowLargeBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 0, 0, 1 }; };
ItemData SlowSmallYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowMedYellow 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowLargeYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowSmallGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowMedGreen 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowLargeGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowSmallWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 1, 1 }; };
ItemData SlowMedWhite 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 1, 1 }; };
ItemData SlowLargeWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 1, 1 }; };
//fast flares
ItemData FastSmallOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastMedOrange 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastLargeOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 16; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastSmallRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 0, 0 }; };
ItemData FastMedRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 0, 0 }; }; 
ItemData FastLargeRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 0, 0 }; }; 
ItemData FastSmallBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 0, 0, 1 }; }; 
ItemData FastMedBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 0, 0, 1 }; }; 
ItemData FastLargeBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 0, 0, 1 }; };
ItemData FastSmallYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastMedYellow 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastLargeYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastSmallGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastMedGreen 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastLargeGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastSmallWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 1, 1 }; };
ItemData FastMedWhite 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 1, 1 }; };
ItemData FastLargeWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 1, 1 }; };

