StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";
	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	//visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};

function Beacon::onEnabled(%this) { GameBase::setIsTarget(%this,true); }
function Beacon::onDisabled(%this) { GameBase::setIsTarget(%this,false); }
function Beacon::onDestroyed(%this)
{
   	GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
	$TeamItemCount[GameBase::getTeam(%this) @ "EngBeacons"]--;
}

//==== Beacon Two

StaticShapeData BeaconTwo
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";
	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	//visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};

function BeaconTwo::onEnabled(%this) {
	//GameBase::setIsTarget(%this,true);
}
function BeaconTwo::onDisabled(%this) {
	//GameBase::setIsTarget(%this,false);
}
function BeaconTwo::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "EngBeacons"]--;
}
