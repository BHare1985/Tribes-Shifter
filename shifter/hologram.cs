//====================================================================================
//== These Functions Are For Deployable Clones & Very Simple Bots...
//====================================================================================
//
// Clones are very simple Bots... 
//

function Hologram(%clientId)
{
	%spawnMarker = GameBase::getPosition(%clientID);
	%xPos = getWord(GameBase::getPosition(%clientID), 0) + 2;
	%yPos = getword(GameBase::getPosition(%clientID), 1) + 2;
	%zPos = getWord(GameBase::getPosition(%clientID), 2) + 2;
	%rPos = GameBase::getRotation(%clientID);
	
	%HologramPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	%HologramName = Client::getName(%clientId) @ " ";
	
	Ai::spawn(%HologramName, Player::getArmor(%clientId), %HologramPos, %rPos);
	
	%aiid = AI::getId(%HologramName);

	$Hologram[%HologramName] = true;
	$Hologram[%HologramName, Deployer] = %clientId;
	$Hologram[%aiId, Deployer] = %clientId;

	%clientId.holo = %aiid;
	
	%type = Player::getMountedItem(%clientID,0);
	if (%type)
	{
		Player::setItemCount(%aiid, %type, 1);
		Player::mountItem(%aiid, %type, 0);
	}
	else
	{
	        Player::setItemCount(%aiId, blaster, 1);
		Player::mountItem(%aiid, blaster, 0);
	}

	%aiid.ownerteam = GameBase::getTeam(%clientId);
	gamebase::setteam(%aiid,GameBase::getTeam(%clientId)); 

	Hologram::RandomMove(%HologramName, 100);
	return ( %newName );
}

function AI::onDroneKilled(%aiName)
{
	if ($Hologram[%aiName])
	{
		$Hologram[%aiName] = false;
		%aiId = AI::getId(%aiName);
		%team = %aiId.ownerteam;
		
		%clientId.holo = "";
		%aiId[ClientNum] = "";
		
		$TeamItemCount[%team @ "hologram"]--;
		$TeamItemCount[%team @ "HoloPack"]--;
		return;
	}
}

function  Hologram::RandomMove(%aiName, %distance) 
{
	if(!$Hologram[%aiName])
	{
		return;
	}

	%aiId = AI::getId(%aiName);
	Hologram::Think(%aiId);
	schedule("hologram::randommove(\"" @ %aiName @ "\"," @ %distance @");", 5 );
}

function Hologram::Think(%aiId)
{
	%client = $Hologram[%aiId, Deployer];
	%player = Client::GetOwnedObject(%client);
	%aiName = Client::getname(%aiId);	
	%aiTeam = Client::getTeam(%aiId);
	%aiplayer = Client::getOwnedObject(%aiId);
	
	%aiPos = gamebase::getposition(%aiId);
	%clPos = gamebase::getposition(%client);	
	%distance = Vector::getDistance(%aiPos, %clPos);	

	if ($debug) echo ("%aiId" @ %aiId);
	if ($debug) echo ("%client" @ %client);
	if ($debug) echo ("%player" @ %player);
	if ($debug) echo ("%aiName" @ %aiName);
	if ($debug) echo ("%aiPos" @ %aiPos);
	if ($debug) echo ("%clPos" @ %clPos);
	if ($debug) echo ("%distance" @ %distance);

	if (!%player)
		return;


	// ==== Determin Distances and Movement To Owner
	%comm_x = getWord(%clPos, 0);
	%comm_y = getWord(%clPos, 1);
	%comm_z = getWord(%clPos, 2);
	if((floor(getRandom()*4)) >= "2"){%new_x = %comm_x - floor(getRandom()*10);}
	else{%new_x = %comm_x + floor(getRandom()*10);}
	if((floor(getRandom()*4)) >= "2"){%new_y = %comm_y - floor(getRandom()*10);}
	else {%new_y = %comm_y + floor(getRandom()*10);}
	%newPos = %new_x  @ " " @ %new_y @ " 0";
	
	// ==== Got Flag?
	%hasFlag = Player::getItemCount(%aiplayer, Flag);

	if (%hasFlag != 0)                                    //If bot has the enemy's flag, get it to our flag
 	{
 		AI::DirectiveRemove(%aiName, 1);
		%pos = ($teamFlag[%aiTeam]).originalPosition;
		%xPos = getWord(%pos, 0);
		%yPos = getword(%pos, 1);
		%zPos = getWord(%pos, 2);
		%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
		AI::DirectiveWaypoint( %aiName, %flagPos, 1);
		echo(%aiName @ " tries to get the enemy's flag to our flag stand.");
		return;
 	}
	else if (%distance > 100)
	{
		if ($debug) echo ("100+ Distance");

		if ($HoloGram::BotJetting[%aiId] < 1)
		{
			%rnd = floor(getRandom() * 10);
			if (%rnd >5)
			{
				$HoloGram::AbortAIJet[%aiId] = 0;
				AI::JetSimulation(%aiId,0);
			}
		}
		else if($HoloGram::BotJetting[%aiId] == 1)
		{
			schedule ("$HoloGram::AbortAIJet[" @ %aiId @ "] = 0;",5);
		}
		
		AI::DirectiveWaypoint(%aiName, %newPos, 1);
		return;
	}
	else if (%distance > 50)
	{
		if ($debug) echo ("50+ Distance");
		$HoloGram::AbortAIJet[%aiId] = 1;
		AI::Jump(%aiId);
		AI::DirectiveWaypoint(%aiName, %newPos, 1);
		return;
	}
	else if (%distance > 25)
	{
		if ($debug) echo ("25+ Distance");
		$HoloGram::AbortAIJet[%aiId] = 1;
		AI::DirectiveWaypoint(%aiName, %newPos, 1);
		return;
	}
	else if (%distance < 25)
	{
		if ($debug) echo ("-25 Distance");
		$HoloGram::AbortAIJet[%aiId] = 1;
 		AI::DirectiveRemove(%aiName, 1);
		AI::DirectiveTargetLaser(%aiName, %client, 1);
		return;
	}
}

function AI::shove(%aiId, %velocity, %zVec, %rotX, %rotY, %rotZ)
{
	%passenger = %aiId;
	%OldrotX = getWord(GameBase::getRotation(%passenger),0);
	%OldrotY = getWord(GameBase::getRotation(%passenger),1);
	%OldrotZ = getWord(GameBase::getRotation(%passenger),2);
	%rotation = (%OldrotX + %rotX) @ " " @ (%OldrotY + %rotY) @ " " @ (%OldrotZ + %rotZ);
	GameBase::setRotation(%passenger, %rotation);
	%jumpDir = Vector::getFromRot(%rotation, %velocity, %zVec);
	Player::applyImpulse(%passenger,%jumpDir);
}


function AI::Jump(%aiId)      //This function makes the AI jump. If %jet=1 then it Calls the Jetpack Routine
{
    	%passenger = %aiId;
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "sfemale" || %armor == "sarmor" || %armor == "stimfemale" || %armor == "stimarmor")
	{
		%height = 2;
		%velocity = 80;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale" || %armor == "aarmor" || %armor == "afemale" || %armor == "barmor" || %armor == "bfemale")
	{
		%height = 2;
		%velocity = 120;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "darmor" || %armor == "jarmor" || %armor == "parmor")
	{
		%height = 2;
		%velocity = 170;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
	{	
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
}

function AI::JetSimulation(%aiId, %phase)         // Makes an AI jet like a real player.
{
	if ($Debug)
		echo ("STATUS AI::JetSimulation = in Phase " @ %phase @ " for bot " @ %aiId @ ". BotJetting is " @ $HoloGram::BotJetting[%aiId]);

	if ($HoloGram::StopAIJet[%aiId])  //To stop a jet, set $HoloGram::StopAIJet to the aiId you want to stop jetting
	{
		if (%phase < 6 )
			%phase = 6;			     //Just skip the climb phases, and start to descend
		$HoloGram::StopAIJet[%aiId] = 0;
	}

	if ($HoloGram::AbortAIJet[%aiId])  //AbortJet is similar to StopJet, only there will be no controlled descend afterwards
	{
		$HoloGram::AbortAIJet[%aiId] = 0;
		return;			     //When Aborting, the function will kill itself immediately.
	}

	$HoloGram::BotJetting[%aiId] = 1;

	%velocity = 20;
	%zVec = 100;
	AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
	%phase = %phase + 1;
	
	if (%phase < 6)
	{
		$HoloGram::BotJettingHeat[%aiId] = 1;
		schedule("AI::JetSimulation(" @ %aiId @ ", " @ %phase @ ");", 0.5);  //First 6 phases: climb
		return;
	}

	$HoloGram::BotJettingHeat[%aiId] = 0;  //The BotJettingHeat is only 1 if we're in climbing phase. This is for rocket turrets.

	if (%phase < 10)
	{
		schedule("AI::JetSimulation(" @ %aiId @ ", " @ %phase @ ");", 1);    //After climbing, do a controlled descend.
		return;
	}

	$HoloGram::BotJetting[%aiId] = -1;

	// if "phase" exceeds 10, then this function will simply stop keeping itself alive.
	return;
}

function AI::JetToHeight(%aiId, %height, %phase)         // Makes an AI jet to a specified height. Here the phase variable is only for INTERNAL use!
{

	$HoloGram::BotJetting[%aiId] = -1;
	$HoloGram::BotJettingHeat[%aiId] = 0;

	%AiPos = GameBase::getPosition(%aiId);
	%zPos = getWord(%AiPos, 2);

	//If we reached our height, stop jetting and abort this function.
	//I tried a new trick here: I stop the jetting sooner if the bot already has a great upward speed.

	if (%phase >=8)
	{
		if ((%zPos+6) >= %height)
		{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
		}
	}

	if (%phase >=6)
	{
		if ((%zPos+5) >= %height)
		{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
		}
	}

	if (%phase >=4)
	{
		if ((%zPos+4) >= %height)
		{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
		}
	}


	$HoloGram::BotJetting[%aiId] = 1;
	$HoloGram::BotJettingHeat[%aiId] = 1;  //These vars make turrets track the jetting bots, and avoid "double-jetting"
	%velocity = 0;
	%zVec = 150;

	AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
	%phase = %phase + 1;

	schedule("AI::JetToHeight(" @ %aiId @ ", " @ %height @ ", " @ %phase @ ");", 0.3); 
	return;
}

