function MissMenu(%clientId,%admin)
{
	Client::buildMenu(%clientId, "Mission Options:", "Mission", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Start next mission", "nextMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Restart mission", "ReplayMap");
		Client::addMenuItem(%clientId, %curItem++ @ "Pick next mission", "PickNextMiss");
}

function processMenuMission(%clientId, %option)
{
%opt = getWord(%option, 0);

if(%opt == "cmission")
{
			Admin::changeMissionMenu(%clientId, "cmission");
			return;
}

if(%opt == "PickNextMiss")
		{
			%clientId.PickNextMiss = true;
			Admin::changeMissionMenu(%clientId, "PickNextMiss");
			return;			
			
		}

		else if(%opt == "ReplayMap")
		{
			Client::buildMenu(%clientId, "Restart Mission:", "Mission", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Yes, Restart.", "cReplayMap");
			Client::addMenuItem(%clientId, %curItem++ @ "No.", "return");	
			return;
		}
		else if(%opt == "nextMiss")
		{
			Client::buildMenu(%clientId, "Start Next Mission:", "Mission", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Yes, next.", "cnextMiss");
			Client::addMenuItem(%clientId, %curItem++ @ "No.", "return");	
			return;
		}		
		else if(%opt == "return")
		{
			MissMenu(%clientId,true);
			return;
		}				
		else if(%opt == "cReplayMap")
		{
			ReplayMap(%clientId);
			return;
		}		
		else if(%opt == "cnextMiss")
		{
			nextmap(%clientId);
			return;
		}	
		
}	

function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type Page 1", "cmtype", true);
	%index = 0;
	for(%type = 1; %type <= $MLIST::TypeCount; %type++)
	if($MLIST::Type[%type] != "Training")
	{
		%index++;
		if (%index <= 7)
		Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
		else
		{
		Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @%index@" 1");
		break;
		}
	}
}

function processMenuCMType(%clientId, %options)
{
	if(getWord(%options, 0) == "more")
	{
		%page = (getWord(%options, 2)) + 1;
		%firstmission = getWord(%options, 1);
		Client::buildMenu(%clientId, "Pick Mission Type Page "@%page, "cmtype", true);
		%index = 0;
		for(%type = %firstmission; %type < $MLIST::TypeCount; %type++)
		{
			if ($MLIST::Type[%type] != "Training")
			{
				%index++;
				if (%index <= 7)
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
				else
				{
					Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @%type@" "@%page);
					break;
				}
			}
		}
		return;
	}
	%curItem = 0;
	%option = getWord(%options, 0);
	%first = getWord(%options, 1);
	Client::buildMenu(%clientId, "SELECT MISSION", "cmission", true);	
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
	{
		if(%i > 6)
		{
			Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
			break;
		}
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
	}
}

function processMenuCMission(%clientId, %option)
{
	if(getWord(%option, 0) == "more")
	{
		%first = getWord(%option, 1);
		%type = getWord(%option, 2);
		processMenuCMType(%clientId, %type @ " " @ %first);
		return;
	}
	%mi = getWord(%option, 0);
	%mt = getWord(%option, 1);

	%misName = $MLIST::EName[%mi];
	%misType = $MLIST::Type[%mt];

	if(%misType == "" || %misType == "Training")
		return;
		
	for(%i = 0; true; %i++)
	{
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if(%misIndex == %mi)
			break;
		if(%misIndex == -1)
			return;
	}
	
	if(%clientId.isAdmin && %clientId.vote != "1")
	{
		if(%clientId.PickNextMiss=="true")
		{
			messageAll(0, %adminName @ " chose the next mission, " @ %misName @ " (" @ %misType @ ")~wCapturedTower.wav");
			%clientId.PickNextMiss = "false";
			$nextMap = %misName;
			//Vote::changeMission();
			//Server::loadMission(%misName);			
		}
		else
		{
		%clientId.vote = 0;
		messageAll(1, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
		Server::loadMission(%misName);
		}
	}
	else
	{
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
	}
}