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
	//validateShape = true;
//	validateMaterials = true;
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
	//validateShape = true;
//	validateMaterials = true;
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
	//validateShape = true;
//	validateMaterials = true;
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
			deleteobject(%set);
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
				deleteobject(%set);
				//if(0 == %num) {
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%team = GameBase::getTeam(%player);
							%pos = $los::position;
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
							deploy::record(%fField, "TreePack", %team, %pos, %rot);
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
				deleteobject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%team = GameBase::getTeam(%player);
							%pos = $los::position;
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
							deploy::record(%fField, "PlantPack", %team, %pos, %rot);
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
	//validateShape = true;
//	validateMaterials = true;
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
					Client::sendMessage(%client,0,%item.description @ " deployed");
					%team = GameBase::getTeam(%player);
					%pos = $los::position;
					TeleportPack::specialdeploy(%team, %pos);
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

function TeleportPack::specialdeploy(%team, %pos)
{
		%sensor = newObject("Teleport Pad","StaticShape",DeployableTeleport,true);

		CreateteleportSimSet();
		addToSet("MissionCleanup/Teleports", %sensor);
		addToSet("MissionCleanup", %sensor);

		GameBase::setTeam(%sensor,%team);
		%poss = Vector::add(%pos,"0 0 1");
		GameBase::setPosition(%sensor,%poss);
		Gamebase::setMapName(%sensor,"Teleport Pad");
		%sensor.disabled = false;
		playSound(SoundPickupBackpack,%pos);

		%beam = newObject("","StaticShape",ElectricalBeam,true);
		addToSet("MissionCleanup", %beam);
		GameBase::setTeam(%beam,%team);
		GameBase::setPosition(%beam,%poss);

		deploy::record(%sensor, "TeleportPack", %team, %pos, "0 0 0");
		%sensor.beam1 = %beam;
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

			deleteobject(%set);
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
