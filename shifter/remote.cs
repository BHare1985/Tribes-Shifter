//=============================================================================================== Remote Game Functions
//== These functions can be called be remote Evals by the logged in clients.
//=====================================================================================================================

function remotePlayMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModePlay);
   }
}

function remoteCommandMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}

function remoteInventoryMode(%clientId)
{
	if(!%clientId.guiLock && !Observer::isObserver(%clientId))
	{
		remoteSCOM(%clientId, -1);
		Client::clearItemShopping(%clientId);
		Client::setGuiMode(%clientId, $GuiModeInventory);
	}
}

function remoteObjectivesMode(%clientId)
{
   	if(!%clientId.guiLock)
   	{
   		if ($debug) echo ("Objectives");
      		remoteSCOM(%clientId, -1);
      		Client::setGuiMode(%clientId, $GuiModeObjectives);
   	}
}

function remoteScoresOn(%clientId)
{
   	if(!%clientId.menuMode)
      		Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{

	Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if($Server::TourneyMode && (!$matchStarted || $matchStarting))
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f0>That command is only available when playing the match\", 15);", 5);
		return;
	}
	else
	{
		if (Client::getGuiMode(%clientId) != $GuiModeCommand)
			remoteCommandMode(%clientId);
		else
			remotePlayMode(%clientId);
	}
}

function remoteToggleInventoryMode(%clientId)
{

	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
	{
		remoteInventoryMode(%clientId);
	}
	else
	{
		remotePlayMode(%clientId);
	}
}

function remoteToggleObjectivesMode(%clientId)
{

	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

//========================================================================================== On Kill Self
function remoteKill(%client)
{
	if($Server::TourneyMode && (!$matchStarted || $matchStarting))
		return;

	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);

	if (%client.holo)
	{
		remotekill(%client.holo);
	}

	if(%armor == parmor)
	{
	 	Client::sendMessage(%client,0,"Removing the curse of the penis will not be that easy!");
		%rnd = floor(getRandom() * 30);	
		%random = (%rnd + 10);
		schedule("penisCurse(" @ %client @ ");", %random);
	}
	//======================================================================== Suicide Pack
   	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   	{
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack)
		{
			Player::unmountItem(%player,$BackpackSlot);	
			%client = Player::getClient(%player);
			%obj = newObject("","Mine","Suicidebomb"); %obj.deployer = %client;
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			$TeamItemCount[GameBase::getTeam(%player) @ "SuicidePack"]++;
		}
		else
		{
			playNextAnim(%client);
			Player::kill(%client);
			Client::onKilled(%client,%client, $NukeDamageType, "torso", "front_left");
		}
   	}
  	$animNumber = 25;
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
	Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

//======================================================= Log In Admins - Deals with SAD Password Logins
function login(%clientId, %password)
{
	%name = Client::getName(%clientId);
	%addr = Client::getTransportAddress(%clientId);

	echo ("ADMINMSG: **** Player " @ %name @ " is attempting to use Admin Login - IP = " @ Client::getTransportAddress(%clientId) @ " - Checking Password.");

	if ($Server::Admin["sadpw", %name] == "")
	{
		echo("ADMINMSG: **** Auto - Admining Failed : " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Client Has No SAD Password.");
	}
	else if(%password == $Server::Admin["sadpw", %name])
	{
		echo("ADMINMSG: **** SAD - Admining: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));

		if ($Server::Admin["admin", %name])
		{
			echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Normal-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-Admined\",5);",3);
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = false;
		}
		if ($Server::Admin["super", %name])
		{
			echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Super-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-SuperAdmined\",5);",5);
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = true;
		}
		if ($Server::Admin["noban", %name])
		{
			echo("ADMINMSG: **** No Banning : " @ %clientId @ " - " @ %name @ " - " @ %addr @ ".");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been added to the NoBan List, Dont Get Cocky!!!\",5);",8);
			%clientId.noban = 1;
		}
		%clientId.hackattempt = 0;
		%admin = 1;
	}
	
	if (%admin == 1)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f0>Your password is correct. You have been admined.\", 5);", 1);
		return 1;
	}
	else
	{
		echo("ADMINMSG: **** AutoAdmining Failed : " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Password Failed " @ %clientId.hackattempt @ " times.");
		%clientId.hackattempt++;
	}
	
	if (%clientId.hackattempt > 2)
	{
		%clientId.hackattempt = 0;
		KickPlayer(%clientId ,"You have been kicked for a hacking attempt, if you have forgotten your password please check with the server admin.");
		return 1;
	}
	else if (%client.hackattempt > 1)
	{		
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f0>Your password is failed. Final Warning.\", 1);", 5);
		return 1;
	}
	else
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f0>Your password is failed.\", 5);", 1);
		return 1;
	}
}

//======================================================= Console Functions
function SAD(%password)
{
	remoteEval(2048, AdminPassword, %password);
}

function SADSetPassword(%password)
{
	remoteEval(2048, SetPassword, %password);
}

//======================================================= Remote Console Functions
function remoteAdminPassword(%clientId, %password)
{
	%name = Client::getName(%clientId);
	%addr = Client::getTransportAddress(%clientId);
	echo("ADMINMSG: **** Attempting Admin Login : " @ %clientId @ " - " @ %name @ " - " @ %addr @ ".");
	login(%clientId, %password);
	return 1;
}










