//================================================================== Comm Station
StaticShapeData CommandStation
{
   	description = "Command Station";
	shapeFile = "cmdpnl";
	className = "Station";
	//visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateCommandStation };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseCommandStation };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	castLOS = true;
	triggerRadius = 1.5;
   	explosionId = flashExpLarge;
};

function CommandStation::OnActivate(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				%this.target = %client;
				%player.CommandTag = 1;
				Client::setGuiMode(%client,2);
				Client::sendMessage(%client,0,"Command Access On");
			}
			schedule("CommandStation::onActivate(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{
		Client::sendMessage(%this.target,0,"Command Access Off");
		%this.target.CommandTag = 0;
	}
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
}


StaticShapeData DeployableComStation
{
   description = "Remote Command Station";
	shapeFile = "cmdpnl";
	className = "DeployableStation";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateCommandStation };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseCommandStation };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	castLOS = true;
	supression = false;
	supressable = false;
   explosionId = flashExpLarge;
};

function DeployableComStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Com Station");
	%this.Energy = 3000;
}

function DeployableComStation::OnActivate(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				%this.target = %client;
				%player.CommandTag = 1;
				Client::setGuiMode(%client,2);
				Client::sendMessage(%client,0,"Command Access On");
			}
			schedule("DeployableComStation::onActivate(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{
		Client::sendMessage(%this.target,0,"Command Access Off");
		%this.target.CommandTag = 0;
	}
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";

}

