$GuiModeCommand    = 2;
$LastControlObject = 0;

function Observer::triggerDown(%client){}
function Observer::orbitObjectDeleted(%cl){}
function Observer::leaveMissionArea(%cl){}

function Observer::enterMissionArea(%cl){}

function Observer::triggerUp(%client)
{
	if(%client.observerMode == "dead")
	{
		if(%client.dieTime + $Server::respawnTime < getSimTime())
		{
			if(Game::playerSpawn(%client, true))
			{
				if($matchStarted)
					%client.observerMode = "";
				Observer::checkObserved(%client);
			}
		}
	}
	else if(%client.observerMode == "observerOrbit")
		Observer::nextObservable(%client);
	else if(%client.observerMode == "observerFly")
	{
		%camSpawn = Game::pickObserverSpawn(%client);
		Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
		GameBase::getRotation(%camSpawn), true, true);
	}
	else if(%client.observerMode == "justJoined")
	{
		%client.observerMode = "";
		Game::playerSpawn(%client, false);
	}
	else if(%client.observerMode == "pregame" && $Server::TourneyMode)
	{
		if($CountdownStarted)
			return;

		if(%client.notready)
		{
			%client.notready = "";
			MessageAll(0, Client::getName(%client) @ " is READY.");
			%msg = "<jc><f0>PRESS <f1>FIRE <f0>TO START!";
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.notready == "true")
					remoteEval(%cl, "CP", %msg, 2);
			}

			if(%client.notreadyCount < 1)
				centerprint(%client, "<f1><jc>Waiting for match start (FIRE if not ready).", 0);
			else 
				centerprint(%client, "<f1><jc>Waiting for match start.", 0);
		}
		else
		{
			%client.notreadyCount++;
			if(%client.notreadyCount < 2)
			{
				%client.notready = true;
				MessageAll(0, Client::getName(%client) @ " is NOT READY.");
				centerprint(%client, "<f1><jc>Press FIRE when ready.", 0);
			}
			return;
		}
		Game::CheckTourneyMatchStart();
	}
}

function Observer::jump(%client)
{
	if(%client.observerMode == "observerFly")
	{
		%client.observerMode = "observerOrbit";
		%client.observerTarget = %client;
		Observer::nextObservable(%client);
	}
	else if(%client.observerMode == "observerOrbit")
	{
		%client.observerTarget = "";
		%client.observerMode = "observerFly";

		%camSpawn = Game::pickObserverSpawn(%client);
		Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
		GameBase::getRotation(%camSpawn), true, true);
	}
}

function Observer::isObserver(%clientId)
{
	return %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly";
}

function Observer::enterObserverMode(%clientId)
{
	if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
		return false;
	Client::clearItemShopping(%clientId);
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%clientId);
		Player::kill(%clientId);
	}
	Client::setOwnedObject(%clientId, -1);
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%clientId.observerMode = "observerOrbit";
	GameBase::setTeam(%clientId, -1);
	Observer::jump(%clientId);
	remotePlayMode(%clientId);
	return true;
}
 //greyflcn
//very suspicios
function Observer::checkObserved(%client)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerTarget == %client)
		{
			if(%cl.observerMode == "observerOrbit")
			{
				if (%cl.obsmode == "0" || !%cl.obsmode)
				{
					Observer::setOrbitObject(%cl, %client, 10, 10, 10);
				}
				else if (%cl.obsmode == "1")
				{
					Observer::setOrbitObject(%cl, %client, 35, 35, 35);
				}
				else if (%cl.obsmode == "2")	
				{
					Observer::setOrbitObject(%cl, %client, -3, -1, -0);
				}
				else if (%cl.obsmode == "3")	
				{
					Observer::setOrbitObject(%cl, %client, 5, 5, 5);
				}				
				else if (%cl.obsmode == "4")	
				{
					Observer::setOrbitObject(%cl, %client, -5, -5, -0);
				}				
				else if (%cl.obsmode == "5")
				{
					Observer::setOrbitObject(%cl, %client, -15, -15, -0);
				}
			}
			else if(%cl.observerMode == "commander")
				Observer::setOrbitObject(%cl, %client, -3, -3, -3);
		}
	}
}

function Observer::setTargetClient(%client, %target)
{
	if(%client.observerMode != "observerOrbit")
		return false;

	%owned = Client::getOwnedObject(%target);

	if(%owned == -1)
		return false;

	if (%client.obsmode == "0" || !%client.obsmode)
	{
		Observer::setOrbitObject(%client, %target, 10, 10, 10);
	}
	else if (%client.obsmode == "1")
	{
		Observer::setOrbitObject(%client, %target, 35, 35, 35);
	}
	else if (%client.obsmode == "2")	
	{
		Observer::setOrbitObject(%client, %target, -3, -1, -0);
	}
	else if (%client.obsmode == "3")
	{
		Observer::setOrbitObject(%client, %target, 5, 5, 5);
	}
	else if (%client.obsmode == "4")	
	{
		Observer::setOrbitObject(%client, %target, -5, -5, -0);
	}				
	else if (%client.obsmode == "5")
	{
		Observer::setOrbitObject(%client, %target, -15, -15, -0);
	}				
	
	bottomprint(%client, "<jc>Observing " @ Client::getName(%target), 5);
	
	%client.obstarget = %target;
	
	if (%client.spymode)
	{
		if (%client.isadmin && %client.isSuperAdmin)
			bottomprint(%target, "<jc>You Being Observed By : " @ Client::getName(%client) @ " who is admin...", 5);
		else
			bottomprint(%target, "<jc>You Being Observed By : " @ Client::getName(%client), 5);
	}
	
	%client.observerTarget = %target;
	return true;
}


function Observer::CheckFlagViewers()
{
	%flag = $FlagCarry[%flagTeam];
	if (!%flag)
	{
		
	}
}

function Observer::nextObservable(%client)
{
	%lastObserved = %client.observerTarget;
	%nextObserved = Client::getNext(%lastObserved);
	%ct = 128;
	while(%ct--)
	{
		if(%nextObserved == -1)
		{
			%nextObserved = Client::getFirst();
			continue;
		}
		%owned = Client::getOwnedObject(%nextObserved);
		if(%nextObserved == %lastObserved && %owned == -1)
		{
			Observer::jump(%client);
			return;
		}
		if(%owned == -1)
		{
			%nextObserved = Client::getNext(%nextObserved);
			continue;
		}
		Observer::setTargetClient(%client, %nextObserved);
		return;
	}
	Observer::jump(%client);
}

function Observer::prevObservable(%client){}

function remoteSCOM(%clientId, %observeId)
{
	if (%observeId != -1)
	{
		if (Client::getTeam(%clientId) == Client::getTeam(%observeId) && (%clientId.observerMode == "" || %clientId.observerMode == "commander") && Client::getGuiMode(%clientId) == $GuiModeCommand)
		{
			Client::limitCommandBandwidth(%clientId, true);
			if(%clientId.observerMode != "commander")
			{
				%clientId.observerMode = "commander";
				%clientId.lastControlObject = Client::getControlObject(%clientId);
			}
			Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
			Observer::setOrbitObject(%clientId, %observeId, -3, -3, -3);
			%clientId.observerTarget = %observeId;
			Observer::setDamageObject(%clientId, %clientId);
		}
	}
	else
	{
		Client::limitCommandBandwidth(%clientId, false);
		if(%clientId.observerMode == "commander")
		{
			Client::setControlObject(%clientId, %clientId.lastControlObject);
			%clientId.lastControlObject = "";
			%clientId.observerMode = "";
			%clientId.observerTarget = "";
		}
	}
}