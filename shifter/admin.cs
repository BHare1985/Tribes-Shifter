$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$pskin = $Shifter::PersonalSkin;

function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	for(%type = 1; %type < $MLIST::TypeCount; %type++)
	if($MLIST::Type[%type] != "Training")
	{
		Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
		%index++;
	}
}

function processMenuCMType(%clientId, %options)
{
	echo ("Missions Change Menu");
	
	if(getWord(%options, 0) == "more")
	{
		%first = getWord(%options, 1);
		Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
		%index = 0;

		for(%i = %first; %i < $MLIST::TypeCount; %i++)
		{
			if ($MLIST::Type[%i] != "Training")
			{
				%index++;
				if (%index <= 7)
				{
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
				} else
				{
					Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %index);
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
		%clientId.vote = 0;
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
		Server::loadMission(%misName);
	}
	else
	{
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
	}
}

function remoteSetPassword(%client, %password)
{
   	if(%client.isSuperAdmin)
      		$Server::Password = %password;
}

function remoteSetTimeLimit(%client, %time)
{
	%time = floor(%time);
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
		return;
	if(%client.isAdmin)
	{
		$Server::timeLimit = %time;
		if(%time)
			messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
		else
			messageAll(0, Client::getName(%client) @ " disabled the time limit.");
	}
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
	if(%team >= 0 && %team < 8 && %client.isAdmin)
	{
		$Server::teamName[%team] = %teamName;
		$Server::teamSkin[%team] = %skinBase;
		messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
		@ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
	}
}

function remoteVoteYes(%clientId)
{
   	%clientId.vote = "yes";
   	centerprint(%clientId, "", 0);
}

function remoteVoteNo(%clientId)
{
   	%clientId.vote = "no";
   	centerprint(%clientId, "", 0);
}

function Admin::startMatch(%admin)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(!$CountdownStarted && !$matchStarted)
		{
			if(%admin == -1)
				messageAll(0, "Match start countdown forced by vote.");
			else
				messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));

			Game::ForceTourneyMatchStart();
		}
	}
}

function Admin::setTeamDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $Server::TeamDamageScale = 1;
         if(%admin == -1)
            messageAll(0, "Team damage set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "Team damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
      }
   }
}

function Admin::kick(%admin, %client, %ban)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%ban && !%admin.isSuperAdmin)
			return;
		if(%ban)
		{
			%word = "banned";
			%cmd = "BAN: ";
		}
		else
		{
			%word = "kicked";
			%cmd = "KICK: ";
		}
		if(%client.isSuperAdmin)
		{
			if(%admin == -1)
			{
				messageAll(0, Client::getName(%clientId) @ " Tried to kick the SuperAdmin. Duh!");
				messageAll(0, "A super admin cannot be " @ %word @ ".");
			}	
			else
			{ 
				messageAll(0, Client::getName(%clientId) @ " Tried to kick the SuperAdmin. Duh!");
				Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
			}	
			return;
		}
		%ip = Client::getTransportAddress(%client);

		//echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

		if(%ip == "")
			return;
		if(%ban)
			BanList::add(%ip, 1800);
		else
			BanList::add(%ip, 180);

		%name = Client::getName(%client);

		if(%admin == -1)
		{
			MessageAll(0, %name @ " was " @ %word @ " from vote.");
			KickPlayer(%client, "You were " @ %word @ " by  consensus.");
		}
		else
		{
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
			KickPlayer(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
		}
	}
}

function Admin::setModeFFA(%clientId)
{
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 0;
		if(%clientId == -1)
			messageAll(0, "Server switched to Free-For-All Mode.");
		else
			messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");

		$Server::TourneyMode = false;
		centerprintall(); // clear the messages
		if(!$matchStarted && !$countdownStarted)
		{
			if($Server::warmupTime)
				Server::Countdown($Server::warmupTime);
			else   
				Game::startMatch();
		}
	}
}

function Admin::setModeTourney(%clientId)
{
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 1;
		if(%clientId == -1)
			messageAll(0, "Server switched to Tournament Mode.");
		else
			messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}

function Admin::voteFailed()
{
	$curVoteInitiator.numVotesFailed++;

	if($curVoteAction == "kick" || $curVoteAction == "admin")
		$curVoteOption.voteTarget = "";
}

function Admin::voteSucceded()																					// admin.cs
{
	echo("\"V\"" @ $curVoteAction @ "\"" @ $curVoteOption @ "\"");

	$curVoteInitiator.numVotesFailed = "";
	if($curVoteAction == "kick")
	{
		if($curVoteOption.voteTarget)
			Admin::kick(-1, $curVoteOption);
	}
	else if($curVoteAction == "admin")
	{
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.isAdmin = true;
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
			if($curVoteOption.menuMode == "options")
				Game::menuRequest($curVoteOption);
		}
		$curVoteOption.voteTarget = false;
	}
	else if($curVoteAction == "cmission")
	{
		messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
		Vote::changeMission();
		Server::loadMission($curVoteOption);
	}
	else if($curVoteAction == "tourney")
		Admin::setModeTourney(-1);
	else if($curVoteAction == "ffa")
		Admin::setModeFFA(-1);   
	else if($curVoteAction == "etd")
		Admin::setTeamDamageEnable(-1, true);
	else if($curVoteAction == "dtd")
		Admin::setTeamDamageEnable(-1, false);
	else if($curVoteOption == "smatch")
		Admin::startMatch(-1);
}

function Admin::countVotes(%curVote)
{
   // if %end is true, cancel the vote either way
   if(%curVote != $curVoteCount)
      return;

   %votesFor = 0;
   %votesAgainst = 0;
   %votesAbstain = 0;
   %totalClients = 0;
   %totalVotes = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %totalClients++;
      if(%cl.vote == "yes")
      {
         %votesFor++;
         %totalVotes++;
      }
      else if(%cl.vote == "no")
      {
         %votesAgainst++;
         %totalVotes++;
      }
      else
         %votesAbstain++;
   }
   %minVotes = floor($Server::MinVotesPct * %totalClients);
   if(%minVotes < $Server::MinVotes)
      %minVotes = $Server::MinVotes;

   if(%totalVotes < %minVotes)
   {
      %votesAgainst += %minVotes - %totalVotes;
      %totalVotes = %minVotes;
   }
   %margin = $Server::VoteWinMargin;
   if($curVoteAction == "admin")
   {
      %margin = $Server::VoteAdminWinMargin;
      %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
      if(%totalVotes < %minVotes)
         %totalVotes = %minVotes;
   }
   if(%votesFor / %totalVotes >= %margin)
   {
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteSucceded();
   }
   else  // special team kick option:
   {
      if($curVoteAction == "kick") // check if the team did a majority number on him:
      {
         %votesFor = 0;
         %totalVotes = 0;
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
            {
               %totalVotes++;
               if(%cl.vote == "yes")
                  %votesFor++;
            }
         }
         if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
         {
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)													// admin.cs
{
	if(%clientId.lastVoteTime == "")
		%clientId.lastVoteTime = -$Server::MinVoteTime;

	%time = getIntegerTime(true) >> 5;
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;

	if(%diff > 0)
	{
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return;
	}
	if ((%action=="cmission") && ($TribeStat::BlockMIS == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled mission voting.");
	else if (((%action=="dtd") || (%action=="etd")) && ($TribeStat::BlockTD == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled team damage voting.");
	else if ((%action=="admin") && ($TribeStat::BlockADM == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled admin voting.");
	else if (((%action=="ffa") || (%action=="tourney")) && ($TribeStat::BlockGT == 1))
      		Client::sendMessage(%clientId,0,"The server administrator has disabled game type voting.");

	else if($curVoteTopic == "")
	{
		if(%clientId.numFailedVotes)
			%time += %clientId.numFailedVotes * $Server::VoteFailTime;

		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;
		
		if(%action == "kick")
		{
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		}
		$curVoteCount++;
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		%cl.vote = "";
		%clientId.vote = "yes";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(%cl.menuMode == "options")
			Game::menuRequest(%clientId);
		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
	}
	else
	{
		Client::sendMessage(%clientId, 0, "Voting already in progress.");
	}
}


function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		if(%clientId.menuMode == "options")
			Game::menuRequest(%clientId);

		%addr = Client::getTransportAddress(%selId);

		remoteEval(%clientId, "setInfoLine", 1, "Game Stats");
		remoteEval(%clientId, "setInfoLine", 2, "Addr-IP   :" @ %addr);
		remoteEval(%clientId, "setInfoLine", 3, "Last TKer :" @ $Shifter::LastTKer @ "    T-Kills   :" @ %clientId.TotalKills);
		remoteEval(%clientId, "setInfoLine", 4, "Last TKed :" @ $Shifter::LastTKed @ "    T-Score   :" @ %clientId.TotalScore);
		remoteEval(%clientId, "setInfoLine", 5, "TK Count  :" @ $Shifter::LastTKno @ "    T-Deaths  :" @ %clientId.TotalDeaths);
		remoteEval(%clientId, "setInfoLine", 6, "T-Caps    :" @ %clientId.TotalFlagCaps);
	}
}

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isAdmin)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId))
		return;

	if(%clientId.observerMode == "justJoined")
	{
		%clientId.observerMode = "";
		centerprint(%clientId, "");
	}

	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
	{
		if(Observer::enterObserverMode(%clientId))
		{
			%clientId.notready = "";
			if(%adminClient == "")
			{
				messageAll(0, Client::getName(%clientId) @ " became an observer.");
			}
			else
			{
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
				if ($debug) echo ("Observer Force");
				if ($Shifter::SwitchPerm)
				{
					%clientId.SwitchPerm = true;
				}
			}
			Game::resetScores(%clientId);	
			Game::refreshClientScore(%clientId);
		}
		return;
	}

	%player = Client::getOwnedObject(%clientId);

	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%clientId);
		Player::kill(%clientId);
	}
	
	%clientId.observerMode = "";

	if(%adminClient == "")
	{
		messageAll(0, Client::getName(%clientId) @ " changed teams.");
	}
	else
	{
		messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
		if ($Shifter::SwitchPerm)
		{
			%clientId.SwitchPerm = true;
		}
	}
	if(%team == -1)
	{
		Game::assignClientTeam(%clientId);
		%team = Client::getTeam(%clientId);
	}

	GameBase::setTeam(%clientId, %team);
	%clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

	echo ("Team Select 1");
	Game::playerSpawn(%clientId, false);
	echo ("Team Select 2");
	
	%team = Client::getTeam(%clientId);

	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;

}


//======================================================================================================================== 
//							Main Menus
//======================================================================================================================== 

function Game::menuRequest(%clientId)
{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Options", "options", true);

	//=========================================================================================== Basic Menu   	
   	if(!$matchStarted || !$Server::TourneyMode)
   	{
		if(!%clientId.selClient && !$Server::TourneyMode)
		{
	    		if (!%clientId.SwitchPerm)
	    			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		}
   	}

	if ($Shifter::HelpOn)
		Client::addMenuItem(%clientId, %curItem++ @ "Shifter Help", "helpprint");

	if (%clientId.observerMode != "observerOrbit" && %clientId.observerMode != "observerFly")
	{
		if ($Shifter::Weapons && !%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
		
		if ($Shifter::SaveOn && !%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Save Player Info", "saveinfo");
	}
	else 
	if (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Observer Functions", "menurequest4");
	}
	
	//=========================================================================================== If Vote Topic
	if($curVoteTopic != "" && %clientId.vote == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
	
	//=========================================================================================== Admin's Menus
	if(%clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Admin Functions", "menurequest2");
	}

	Client::addMenuItem(%clientId, %curItem++ @ "Voting Functions", "menurequest3");
}
//================================================================================================================
//						End of Initial Menu System
//================================================================================================================


//================================================================================================================ 
//						     Main Menu Process
//================================================================================================================ 
function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%playerId = %cl;
	%armor = Player::getArmor(%clientId);
	%weapon = Player::getMountedItem (%clientId, $WeaponSlot);
	%pack = Player::getMountedItem (%clientId, $BackPackSlot);
	%flag = Player::getMountedItem (%clientId, $FlagSlot);

	if(%opt == "menurequest4")
	{   
		if ($Debug) echo("*** Process Observer Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Observer Options Menu");
		%curItem = 0;
		
		Client::buildMenu(%clientId, "Observer Options", "options", true);

		//================================================================================== Client Selected 
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Observe Player " @ %name, "observep " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Warn Player " @ %name, "warnp " @ %sel);
		}

		Client::addMenuItem(%clientId, %curItem++ @ "Observe Very Close ", "obssetvclose");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Close ", "obssetclose");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Far ", "obssetfar");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe 1st Person ", "obssetfirst");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Follow Close ", "obssetcfollow");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Follow Far ", "obssetffollow");
		
		if (%clientId.isAdmin && %clientId.isSuperAdmin)
		{
			if (%clientId.spymode == "0" || !%clientId.spymode)
				Client::addMenuItem(%clientId, %curItem++ @ "Set Warning Mode ", "obssetspy");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Set Silent Mode ", "obssetspy");
		}

		return;
	}
	else if(%opt == "warnp")  //================================================================================= Send Observe Warning
	{
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if (%clientId.isadmin && %clientId.isSuperAdmin)
				bottomprint(%sel, "<jc>You Being Observed By : " @ Client::getName(%clientId) @ " who is admin...", 5);
			else
				bottomprint(%sel, "<jc>You Being Observed By : " @ Client::getName(%clientId), 5);
			
		}
		return;
	}
	else if(%opt == "observep") //================================================================================= Obs, Selected
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		Observer::setTargetClient(%clientId, %sel);
	}
	
	//========================================================================================================== Set Observer Options
	if(%opt == "obssetcfollow") {		%clientId.obsmode = 4; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetffollow") {	%clientId.obsmode = 5; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetaction") {	%clientId.obsmode = 6; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetvclose") { 	%clientId.obsmode = 3; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Very close mode set as default.",3); return; }
	else if(%opt == "obssetclose") { 	%clientId.obsmode = 0; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Close mode set as default.",3); return; }
	else if(%opt == "obssetfar") { 		%clientId.obsmode = 1; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Far View set as default.",3); return; }
	else if(%opt == "obssetfirst") { 	%clientId.obsmode = 2; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, First person view set as default.",3); return; }
	else if(%opt == "obssetspy") { if (	%clientId.spymode == "0" || !%clientId.spymode) { %clientId.spymode = "1"; bottomprint(%clientId, "Observer Spy mode is set, observed player will recieve no warning.",3); } else { %clientId.spymode = "0"; bottomprint(%clientId, "Observer Warn mode is set, player will recieve notice that you are observing",3); } return; }
	
	//================================================================================================================ Voting Options
	if(%opt == "menurequest3")
	{   
		if ($Debug) echo("*** Process Voting Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Voting Menu");
		%curItem = 0;
		
		Client::buildMenu(%clientId, "Voting Options", "options", true);

		//======================================================================================================== Client Selected 
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if($curVoteTopic == "")
			{
				if ($Shifter::VoteAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
				if ($Shifter::VoteKick)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			}

			if(%clientId.muted[%sel])
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}

		//================================================================================== No Client Selected 
		if (!%clientId.selClient && $curVoteTopic == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");

			if($Shifter::VoteDTD)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}         

			if($Shifter::VoteFFA)
			{
				if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
			}	
		}
		return;
	}
	//================================================================================================
	//  Secondary Menu System - Mostly Super Admin Functions
	//================================================================================================

	else if(%opt == "menurequest2")
	{   
		if ($Debug) echo("*** Process Admin Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Admin Menu");
		%curItem = 0;
		
		Client::buildMenu(%clientId, "Admin Options", "options", true);

		//================================================================================== Client Is Only Admin
		if(%clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);				

				if (%sel.ismuted)
					Client::addMenuItem(%clientId, %curItem++ @ "Global UnMute " @ %name @ ".", "muteplayer " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Global Mute " @ %name @ ".", "muteplayer " @ %sel);
					
				if (%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "UnLock " @ %name @ "'s Team", "tcrights " @ %sel);
				if (!%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "Lock " @ %name @ "'s Team", "tcrights " @ %sel);			

				if ($Server::TourneyMode)
				{
					if (%sel.islead)
						Client::addMenuItem(%clientId, %curItem++ @ "Revoke Leader From " @ %name, "leader " @ %sel);
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Grant Leader To " @ %name, "leader " @ %sel);
				}

			}
			else
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
				Client::addMenuItem(%clientId, %curItem++ @ "Cycle To Next Mission", "cyclemissions");

				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");			
				if($Server::TourneyMode)																	//============ Toggle Tourney Mode
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Tournament mode", "ctourney");
			}
		}
		
		//============================================================================== Client Is Admin & Super
		if(%clientId.isSuperAdmin && %clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				Client::addMenuItem(%clientId, %curItem++ @ "KBK " @ %name, "kbk " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Clear TK's " @ %name, "removetk " @ %sel);
				
				if (%sel.noban)
					Client::addMenuItem(%clientId, %curItem++ @ "Revoke No Ban " @ %name, "fnoban " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Grant No Ban " @ %name, "fnoban " @ %sel);
		
				if (%sel.isAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin " @ %name, "deadmin " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);

				if (%armor != parmor)
					Client::addMenuItem(%clientId, %curItem++ @ "Give " @ %name @ " the Penis Curse", "peniscurse " @ %sel); //== Penis Curse
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ "'s Penis Curse", "peniscurse " @ %sel); //== Penis Curse
			}
			//=============================================================================== With No Client			
			else
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");		

				Client::addMenuItem(%clientId, %curItem++ @ "Enable Match Configuration", "matchConfig");
				Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");		
			}
		}
		//================================================================= Client Is Admin But NOT Super Admin
		if(%clientId.isAdmin && %clientId.isSuperAdmin && %clientId.isGod)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);
			}
			else
			{
			}
		}
		return;
	}

	else if (%opt == "cyclemissions")
	{
		remoteCycleMission(%clientId);
	}

   	//====================================================================================================================
   	// Print Help Screens.
   	//====================================================================================================================

	else if (%opt == "helpprint") 
	{ 	
   		%curItem = 0;
      
   		Client::buildText(%clientId, "Help Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Weapon Help", "weapon");
   		Client::addMenuItem(%clientId, %curItem++ @ "Pack Help", "pack");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grenade Help", "grenade");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mine Help", "mine");
   		Client::addMenuItem(%clientId, %curItem++ @ "Beacon Help", "beacon");
   		Client::addMenuItem(%clientId, %curItem++ @ "Flag Help", "flag");
   		Client::addMenuItem(%clientId, %curItem++ @ "Locate", "locate");
   		return;
   	} 	

	else if (%opt == "locate")
	{
		Client::buildMenu(%clientId, "Locate Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Enemy Flag Location", "nmeflag");
   		Client::addMenuItem(%clientId, %curItem++ @ "Friendly Flag Location", "frdflag");
		return;
	}
	
	
	else if (%opt == "nmeflag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);

		if (%playerteam == 0)
		{
			%pos = GameBase::getPosition($teamFlag[1]);
			%posX = getWord(%pos,0);
			%posY = getWord(%pos,1);
			%distance = Vector::getDistance(%pos, %playerpos);
		}
		else if (%playerteam == 1)
		{
			%pos = GameBase::getPosition($teamFlag[0]);
			%posX = getWord(%pos,0);
			%posY = getWord(%pos,1);
			%distance = Vector::getDistance(%pos, %playerpos);
		}
		else if (%playerteam > 1)
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Locate does not work in multi team.\", 3);", 0);
			return;
		}
		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The enemy flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
	
	else if (%opt == "tcrights")
	{
		if (%cl.SwitchPerm)
		{
			%cl.SwitchPerm = "False";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You now have rights to switch teams.\", 3);", 0);			
		}
		else if (!%cl.SwitchPerm)
		{
			%cl.SwitchPerm = "True";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>Your rights to switch teams has been revoked.\", 3);", 0);
		}
	}
	else if (%opt == "muteplayer")
	{
		if (%cl.ismuted)
		{
			%cl.ismuted = "False";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You have been allow to speak again, watch you mouth...\", 3);", 0);			
		}
		else if (!%cl.ismuted)
		{
			%cl.ismuted = "True";
			schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You have been globally muted by admin, NO ONE CAN HEAR YOU ANY MORE...\", 3);", 0);
		}
	}	
	else if (%opt == "frdflag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);
		%pos = GameBase::getPosition($teamFlag[%playerteam]);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%distance = Vector::getDistance(%pos, %playerpos);
		issueCommand(%clientId, %clientId, 0,"Way point set to your flag. Your flag is " @ %distance @ "meters away.", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
//===================================================================================================================
//============================================== Weapon Options =====================================================
//===================================================================================================================
   	else if (%opt == "weaponoptions") 
   	{ 	
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Weapon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Options", "weapon_plasma");

		if (%armor == "harmor" || %armor == "darmor" || %armor == "jarmor" || %armor == "barmor" || %armor == "bfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Mortar Options", "weapon_mortar");
   		
		if (%armor == "harmor" || %armor == "darmor")
   			Client::addMenuItem(%clientId, %curItem++ @ "Mine Options", "weapon_dmines");

   		Client::addMenuItem(%clientId, %curItem++ @ "Rocket Options", "weapon_rocket");

		if (%armor == "earmor" || %armor == "efemale" || %armor == "aarmor" || %armor == "afemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "GravGun Options", "weapon_gravgun");

		if (%armor == "marmor" || %armor == "mfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Booster Options", "booster_options");

		if (%armor == "earmor" || %armor == "efemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Engineer Options", "engineer_options");

		if (%armor == "spyarmor" || %armor == "spyfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Plastique Options", "weapon_plastic");
		
		if (%armor == "spyarmor" || %armor == "spyfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Command LapTop Options", "weapon_laptop");
		
		if (%armor == "aarmor" || %armor == "afemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Clear Telepoint", "cleartelepoint");
   		
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Options", "spawn_options");
   		
   		if ($Shifter::WeaponAdmin)
   		{
   			if(%clientId.isSuperAdmin)
   			{
				Client::addMenuItem(%clientId, %curItem++ @ "Admin Weapons", "admin_weapons");
      			}
      		}
      		return;
   	}
	else if(%opt == "saveinfo")
	{
		SaveCharacter(%clientId);
		return;
	}
	else if(%opt == "admin_weapons")
	{
		Client::buildMenu(%clientId, "Admin Weapons", "options", true);

		if ($Shifter::LockOn)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Missle Lock", "ad_missle_off");
		if (!$Shifter::LockOn)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn On Missle Lock", "ad_missle_on");

		if ($Shifter::TurretKill)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Turret Kills", "ad_turret_off");
		if (!$Shifter::TurretKill)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn On Turret Kills", "ad_turret_on");
		return;
	}
	else if (%opt == "ad_missle_on")
	{
		$Shifter::LockOn = True;
		return;
	}
	else if (%opt == "ad_missle_off")
	{
		$Shifter::LockOn = False;
		return;
	}
	else if (%opt == "ad_turret_on")
	{	
		$Shifter::TurretKill = True;
		return;
	}
	else if (%opt == "ad_turret_off")
	{
		$Shifter::TurretKill = False;
		return;
	}
	else if (%opt == "cleartelepoint")
	{
		%player = client::getownedobject(%clientId);
		
		%obj = newObject("","Mine","EMPBlast");
		Client::setOwnedObject(%clientId, %obj);
		
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 1.5";
		%pos = Vector::add(GameBase::getPosition(%clientId.telepoint), %padd);
		GameBase::setPosition(%obj, %pos);
		Client::setOwnedObject(%clientId, %player);
		
		%clientId.telepoint = "false";
	
		return;
	}
	else if (%opt == "weapon_laptop")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Laptop Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Turret Control", "laptop_control");
   		Client::addMenuItem(%clientId, %curItem++ @ "Turret Hack", "laptop_hack");
   		return;	
	}
	else if (%opt == "laptop_control")
	{
		%ClientId.HackPack = True;
	        bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Command Mode", 2);
		return;
	}
	else if (%opt == "laptop_hack")
	{
	        bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Hack Mode", 2);
		%ClientId.HackPack = False;
		return;
	}	

	else if (%opt == "spawn_options")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Spawn Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Standard", "spawn_standard");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Random", "spawn_random");
   		if ($Shifter::SpawnFavs) Client::addMenuItem(%clientId, %curItem++ @ "Spawn Favorites", "spawn_favs");
   		return;
	}
	else if (%opt == "spawn_standard")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Standard.",5);
		%clientId.spawntype = "standard";
		return;
	}
	else if (%opt == "spawn_random")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Random.",5);
		%clientId.spawntype = "random";
		return;
	}
	else if (%opt == "spawn_favs")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Favs.",5);
		%clientId.spawntype = "favs";
		return;
	}
	else if (%opt == "booster_options")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Booster Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Normal Booster", "booster_norm");
   		Client::addMenuItem(%clientId, %curItem++ @ "Advanced Booster", "booster_adv");
   		return;
	}
	else if (%opt == "weapon_mortar")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mortar Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_mortar_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMP Shell", "weapon_mortar_emp");
   		Client::addMenuItem(%clientId, %curItem++ @ "Frag Shell", "weapon_mortar_frag");
   		Client::addMenuItem(%clientId, %curItem++ @ "MDM Shell", "weapon_mortar_mdm");
   		return;
	}
	else if (%opt == "weapon_rocket")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Stinger Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Stinger", "weapon_rocket1");
   		if ($Shifter::LockOn)
   			Client::addMenuItem(%clientId, %curItem++ @ "Locking Stinger", "weapon_rocket2");
   		Client::addMenuItem(%clientId, %curItem++ @ "LockJaw", "weapon_rocket3");
   		Client::addMenuItem(%clientId, %curItem++ @ "Wire Guided", "weapon_rocket4");
   		return;
	}
	else if (%opt == "weapon_plasma")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Plasma Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_plasma_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_plasma_rapid");
   		Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
   		return;
	}
	else if (%opt == "weapon_dmines")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "DLM (Laser Mines)", "weapon_dmines1");
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_dmines2");
   		//Client::addMenuItem(%clientId, %curItem++ @ "Light AP-Mine", "weapon_dmines3");
   		return;
	}
	else if (%opt == "weapon_gravgun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "GravGun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Tractor Effect", "weapon_gravgun_tract");
   		Client::addMenuItem(%clientId, %curItem++ @ "Repulse Effect", "weapon_gravgun_repulse");
   		return;
	}
	else if (%opt == "weapon_plastic")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Plastique Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "2 Sec. Delay", "weapon_plastic_plas2");
   		Client::addMenuItem(%clientId, %curItem++ @ "5 Sec. Delay", "weapon_plastic_plas5");
   		Client::addMenuItem(%clientId, %curItem++ @ "10 Sec. Delay", "weapon_plastic_plas10");
   		Client::addMenuItem(%clientId, %curItem++ @ "15 Sec. Delay", "weapon_plastic_plas15");
   		return;
	}
	//=============================================================================================== Engineer Opts
	else if (%opt == "engineer_options")
	{
   		%curItem = 0;
   		
   		Client::buildMenu(%clientId, "Engineer Options", "options", true);
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Mines", "weapon_engmine");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Gun", "weapon_eng");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Beacons", "weapon_engbeacon");
	   	
		return;
	}	
	else if (%opt == "weapon_engmine")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Type", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Proximity Warning", "weapon_engmine_proxy");
   		Client::addMenuItem(%clientId, %curItem++ @ "Cloaking Mine", "weapon_engmine_cloak");
   		Client::addMenuItem(%clientId, %curItem++ @ "Laser Mine", "weapon_engmine_laser");
   		Client::addMenuItem(%clientId, %curItem++ @ "Anti-Personel", "weapon_engmine_stand");
   		Client::addMenuItem(%clientId, %curItem++ @ "Replicator", "weapon_engmine_replica");
   		return;
	}
	else if (%opt == "weapon_engbeacon")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Type", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Beacon", "weapon_engbeacon_standard");
   		Client::addMenuItem(%clientId, %curItem++ @ "Cloaked Camera", "weapon_engbeacon_camera");
   		Client::addMenuItem(%clientId, %curItem++ @ "Medi-Pack Patch", "weapon_engbeacon_medikit");
   		return;
	}
	else if (%opt == "weapon_eng")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Engineer Gun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Repair", "weapon_eng_repair");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hack", "weapon_eng_hack");
   		Client::addMenuItem(%clientId, %curItem++ @ "Disassymbler", "weapon_eng_disa");
   		return;
	}	
	//=============================================================================================== Merc Booster
	if (%opt == "booster_norm")
	{
		%clientId.booster = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Set To Normal Mode.\", 3);", 0);
   		return;
	}
	else if (%opt == "booster_adv")
	{
		%clientId.booster = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Ser To Advanced Mode.\", 3);", 0);
   		return;
	}
	//=============================================================================================== Engineer Mines
	if (%opt == "weapon_engmine_proxy")
	{
		%clientId.EngMine = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Proximity Detector.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_cloak")
	{
		%clientId.EngMine = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Cloaking Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_laser")
	{
		%clientId.EngMine = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Point Defense Laser Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_stand")
	{
		%clientId.EngMine = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Standard Anti-Personell Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_replica")
	{
		%clientId.EngMine = "4";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Replicator Mine.\", 3);", 0);
   		return;
	}
	//==================================================================================== Engineer Beacons
	else if (%opt == "weapon_engbeacon_standard")
	{
		%clientId.EngBeacon = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Standard.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_camera")
	{
		%clientId.EngBeacon = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Cloaking Camera.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_antimissile")
	{
		%clientId.EngBeacon = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_medikit")
	{
		%clientId.EngBeacon = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.\", 3);", 0);
   		return;
	}		

	//====================================================================================== Eng-Gun Options
	else if (%opt == "weapon_eng_repair")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 0;		
			Player::setItemCount(%clientId, Fixit , 1);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::mountItem(%clientId, Fixit, $WeaponSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Repair Gun Option Selected.\", 3);", 0);
		}
		else
		{		
			if (Player::getItemCount(%clientId, FixIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.\", 3);", 0);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
		}

   		return;
	}
	else if (%opt == "weapon_eng_hack")
	{
		if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::setItemCount(%clientId, Hackit, 1);
			Player::mountItem(%clientId, HackIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hacking Option Selected.\", 3);", 0);
		}
		else
		{		
			if (Player::getItemCount(%clientId, HackIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.\", 3);", 0);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
		}
		
   		return;
	}
	else if (%opt == "weapon_eng_disa")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, FixIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 1);
			Player::mountItem(%clientId, DisIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disassymbler Option Selected.\", 3);", 0);
		}
		else
		{		
			if (Player::getItemCount(%clientId, DisIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.\", 3);", 0);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
		}
		
   		return;
	}

	//=============================================================================================== Plastique
	if (%opt == "weapon_plastic_plas2")
	{
		%clientId.Plastic = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 2 Sec.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plastic_plas5")
	{
		%clientId.Plastic = 5;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 5 Sec.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plastic_plas10")
	{
		%clientId.Plastic = 10;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 10 Sec.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plastic_plas15")
	{
		%clientId.Plastic = 15;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 15 Sec.\", 3);", 0);
   		return;
	}

	//======================================================================== Mortar Options
	if (%opt == "weapon_mortar_regular")
	{
		%clientId.Mortar = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Mortar Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_emp")
	{
		%clientId.Mortar = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Magnetic Pulse Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_frag")
	{
		%clientId.Mortar = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Fragmenting Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_mdm")
	{
		%clientId.Mortar = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MDM Shell Selected.\", 3);", 0);
   		return;
	}
	//======================================================================== Rocket Options
	if (%opt == "weapon_rocket1")
	{
		%clientId.rocket = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Rocket Initiated.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket2")
	{
		%clientId.rocket = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Locking Initiated.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket3")
	{
		%clientId.rocket = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Lock Jaw Initiated.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket4")
	{
		%clientId.rocket = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Wire Guided System Initiated.\", 3);", 0);
   		return;
	}

	//========================================================================= Dread Mine Options
	if (%opt == "weapon_dmines1")
	{
		%clientId.dmines = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To DLM.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_dmines2")
	{
		%clientId.dmines = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Standard.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_dmines3")
	{
		%clientId.dmines = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Light-AP.\", 3);", 0);
   		return;
	}

	//========================================================================= Plasma Options
	if (%opt == "weapon_plasma_regular")
	{
		%clientId.Plasma = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Plasma Bolt Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_rapid")
	{
		%clientId.Plasma = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid-Bold Plasma Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_multi")
	{
		%clientId.Plasma = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0);
   		return;
	}

	//======================================================================= Grav Gun Options
	else if (%opt == "weapon_gravgun_tract")
	{
		%clientId.gravbolt = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_gravgun_repulse")
	{
		%clientId.gravbolt = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0);
   		return;
	}
//=============================================================================== Print Help Menu Selections
   	
   	if (%opt == "weapon") //================================================================================== Weapons Help
   	{
   		if ($Shifter::Debug) echo ("Weapon - " @ %weapon);

		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You do not currently have a weapon mounted.\", 10);", 0);		
		}
		if (%weapon == "Blaster")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The blaster is a modified version of the original with a little more kick.\", 10);", 0);
		}
		if (%weapon == "PlasmaGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The plasma gun has not changed much, great for taking out heavies and lights at close range.\", 10);", 0);
		}
		if (%weapon == "ChainGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The chain gun, with a explosive tipped ammo.\", 10);", 0);
		}
		if (%weapon == "DiscLauncher")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> This disc-launcher has undergone only a slight projectile speed upgrade.\", 10);", 0);
		}
		if (%weapon == "GrenadeLauncher")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The grenade-launcher is the same stock weapon as always.\", 10);", 0);
		}
		if (%weapon == "Mortar")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The heavies best friend, the mortar has only under gone a slight speed upgrade in fire rate.\", 10);", 0);
		}
		if (%weapon == "LaserRifle")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The laser rifle has not changed, still a great deal for taking out enemies at long range.\", 10);", 0);
		}
		if (%weapon == "RocketLauncher")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The target locking rocket launcher, get them in your cross hairs and the rocket will lock to its target.\", 10);", 0);
		}
		if (%weapon == "SniperRifle")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> This is a projectile based version of its brother LserRifle... Fires a very fast projectile instead of a laser.\", 10);", 0);
		}
		if (%weapon == "ConCun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The shock wave cannon is a great weapon for getting away from the enemy or getting the enemy away from you. Does very little damage.\", 10);", 0);
		}
		if (%weapon == "EnergyRifle")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The good-ole ELF gun. Suck the enemies energy right out with this one.\", 10);", 0);
		}
		if (%weapon == "RailGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The rail-gun is a quite nasty, high speed projectile weapon that can lay out a light or medium armor in one shot. Very little ammo capasity.\", 10);", 0);
		}
		if (%weapon == "Mfgl")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Tactical Nuke. This is the most devistating weapn in the game. How ever you will not get points or credit for its massive destructiveness.\", 10);", 0);
		}
		if (%weapon == "Silencer")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The magnum is a smaller version of the Rail Gun, Less damage but a much greater rate of fire.\", 10);", 0);
		}
		if (%weapon == "Vulcan")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Vulcan is the BIG brother to the chain-gun, firing several more rounds a seconds can lay out the largest targets in quick time.\", 10);", 0);
		}
		if (%weapon == "IonGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> This is one very devistating weapon, developed for use with the arbitor armor, the Ion Cannon drains massive energy, but is worth it.\", 10);", 0);
		}
		if (%weapon == "Flamer")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> This Goliath only weapon is great on the enemy at close range, but does little damage to turrets and stations, etc...\", 10);", 0);
		}
		if (%weapon == "TranqGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Tranq... Much like the Sniper Rifle, does very little initial damage, but poisons the enemy.\", 10);", 0);
		}
		if (%weapon == "HyperB")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The HyperBlaster is the light-weight rapid firing little brother to the Blaster.\", 10);", 0);
		}
		if (%weapon == "Volter")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Volter is an arbitor only weapon that is quite devistating if used correctly, firing a ion charged stream of plasma.\", 10);", 0);
		}
		if (%weapon == "FixIt")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Engineers firend, this little repair gun doesnt need a repair-pack but will repair in great time.\", 10);", 0);
		}
		if (%weapon == "GravGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The grav gun can be a flag runners worst nightmare. Grabbing at pulling the enemy to you and back into firing range.\", 10);", 0);
		}
		if (%weapon == "BoomStick")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Boomstick (shotgun) will match the little guy with the big-boys at close range.\", 10);", 0);
		}
		if (%weapon == "TargetingLaser")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The targetting laser will allow you to pin point targets for heavies to launch mortars at.\", 10);", 0);
		}
		if (%weapon == "RepairGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The repair gun comes with the repair pack and will allow you to repair other players and your own base items.\", 10);", 0);
		}
   	}
   	if (%opt == "flag") //======================================================================================= Flag Help
   	{

		if (%flag == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You are not carrying a flag! .\", 10);", 0);		
		}   	
		if (%flag == "flag")
		{
			if ($Shifter::FlagNoReturn == "True")
			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You are carrying a flag, you need to take the flag to your flag stand!.\", 10);", 0); 			
			else
			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You are carrying a flag, you need to take the flag to your flag stand!.\", 10);", 0);		
		}
	}

   	if (%opt == "pack") //======================================================================================= Pack Help
   	{
   			//echo ("Pack - " @ %pack);	

		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You do not currently have a pack.\", 10);", 0);		
		}
		if (%pack == "EnergyPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The energy pack will regenerate your energy quicker and you will use less.\", 10);", 0);
		}
		if (%pack == "RepairPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The repair pack gives you the ability to repair items and other players.\", 10);", 0);
		}
		if (%pack == "ShieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Shield pack will convert your energy into shielding to resist damage.\", 10);", 0);
		}
		if (%pack == "SensorJammerPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Sensor Jammer will dampen your sensor signal with in a certain radius.\", 10);", 0);
		}
		if (%pack == "RocketPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Deployable rocket turret is a smaller version of the large base rocket turret.\", 10);", 0);
		}
		if (%pack == "LaserPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Deployable laser turret is the God of turrets, they can be attached to nearly any surface for devistating results.\", 10);", 0);
		}
		if (%pack == "CloakingDevice")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Cloaking Device will make you invisable to enemies as well as friendly.\", 10);", 0);
		}
		if (%pack == "StealthShieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Stealth Shield will hide you from turrets and locking missles.\", 10);", 0);
		}
		if (%pack == "LapTop")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Command Lap Top will allow you to use varrious remote items with out being at a command station.\", 10);", 0);
		}
		if (%pack == "ShockPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The EMP turret will drop en EMP blasting shell that will knock out all enemy energy ans shielding as well as friendly.\", 10);", 0);
		}
		if (%pack == "TargetPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Mortar turret can be deployed but will only fire when it is being commanded.\", 10);", 0);
		}
		if (%pack == "SuicidePack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The suicide pack is quite devistating, basically a nuclear device that you can drop, it will detonate in 20 seconds after drop.\", 10);", 0);
		}
		if (%pack == "DetPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The suicide pack is quite devistating, basically a nuclear device that you can drop, it will detonate in 20 seconds after drop..\", 10);", 0);
		}
		if (%pack == "CameraPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The camera pack will allow you to spy on the enemy (from a command station or lap top), placed in a sneaky location they might not even see it.\", 10);", 0);
		}
		if (%pack == "TurretPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Ion turret is quite nasty, firing the same bolts as the Ion Cannon gun.\", 10);", 0);
		}
		if (%pack == "AmmoPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The ammo pack gives you an extra supplt of ammo for those long trips.\", 10);", 0);
		}
		if (%pack == "DeployableInvPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The deployable inventory station is quite nice for those far away mission, allowing you to purchace weapons, ammo and turrets.\", 10);", 0);
		}
		if (%pack == "DeployableAmmoPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> This small deployable station allows you to resupply just like the larger ones in your base.\", 10);", 0);
		}
		if (%pack == "MotionSensorPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The motion sensor will allow your turrets to see targets that are cloaked or shielded by sensor surpression.\", 10);", 0);
		}
		if (%pack == "PulseSensorPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The deployable pulse sensor is a smaller version of the pulsing sensor found on many bases.\", 10);", 0);
		}
		if (%pack == "DeployableSensorJammerPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The deployable sensor jammer will shield you and your team mates from enemy sensors.\", 10);", 0);
		}
		if (%pack == "DeployableComPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The deployable command center will allow you or a team mate to command turrets and other remote items from afar.\", 10);", 0);
		}
		if (%pack == "LaserTurret")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Deployable Plasma turret is a version of the base defence, it jsut can not take quite the same ammount of damage.\", 10);", 0);
		}
		if (%pack == "ForceFieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> This is a smaller version of the force-fields found in some bases, make sure that you do not block your only enterance with it.\", 10);", 0);
		}
		if (%pack == "LargeForceFieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The larger force field is a stonger version of the regular force field, it can sustain a good deal of damage.\", 10);", 0);
		}
		if (%pack == "DeployableElf")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Deployable ELF turret is the smaller companion to the larger base defence version and can be mounted any where.\", 10);", 0);
		}
		if (%pack == "TeleportPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Teleport pack is just that. A Telepad platform. You must use two of these.\", 10);", 0);
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Place one where you want to start and the other were you want to go, your team can use it too.\", 10);", 10);
		}
		if (%pack == "TripwirePack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The blast wall is a great defence, it can take great ammounts of heavy damage but is misleading in that...\", 10);", 0);
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The blast wall can only take smaller ammount of lesser damage...\", 10);", 10);
		}
		if (%pack == "PlatformPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The deployable platform has many uses such as covering things up and blocking floor or cieling enterences.\", 10);", 0);
		}
		if (%pack == "TreePack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Mechanical tree serves little purpose but can be used for cover in many cases.\", 10);", 0);
		}
		if (%pack == "FgcPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Containment pack is needed for the Tactical Nuke, when wielded by a Dreadnaught.\", 10);", 0);
		}
		if (%pack == "MechPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Deployable Interceptor pack is basically a small portable weaponless version of the Interceptor flier.\", 10);", 0);
		}
		if (%pack == "HoloPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The HoloGram is just that, a Holo of a friendly player, it will not do anything other than stand there, great for a sniper decoy.\", 10);", 0);
		}
		if (%pack == "RegenerationPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The regeneration pack will allow you to heal your self, you can switch it on and leave it for isntant healing when you most need it.\", 10);", 0);
		}
		if (%pack == "LightningPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Teleport pack will do just that, teleport you in a random direction, but be careful you could end up in the wrong place.\", 10);", 0);
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You can lock a Telepoint with the weapons options menu to bring you back to a specific location.\", 10);", 10);
		}
		if (%pack == "PlantPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The healing plant will allow all how touches it to begin to heal quite quickly.\", 10);", 0);
		}
		if (%pack == "FlightPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The flight pack gives lighter armors a mush greater energy supply and quicker regeneration time.\", 10);", 0);
		}
		if (%pack == "SMRPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Auto-Rocket is a shoulder mounted rocket launcher that works just like the normal launcher.\", 10);", 0);
		}
		if (%pack == "LaunchPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The launch pad is a small platform that when hit will jet you into the air, great for getting a long way.\", 10);", 0);
		}
  	}   

   	else if (%opt == "mine") //================================================================================================= Mines
   	{
		if ($Shifter::Debug) echo ("Armor = " @ %armor);
   		
		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You are either dead or in observer mode.\", 10);", 0);
		}
		if (%armor == "spyarmor" || %armor == "spyfemale") 		//== Chemeleon
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The chemeleon mines are cloaking anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "sarmor" || %armor == "sfemale") 			//== Scout
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Scout armor mines are standard anti personel mines.\", 10);", 0);
   		}
   		if (%armor == "larmor" || %armor == "lfemale") 			//== Assasin
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Assassin armor mines are very simple flag decoys.\", 10);", 0);
   		}
   		if (%armor == "aarmor" || %armor == "afemale")			//== Arbitor
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Arbitor armor mines are concussion mines, the also cloak so that enemy will never see them.\", 10);", 0);
   		}
   		if (%armor == "marmor" || %armor == "mfemale")			//== Mercinary
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mercinary armor carries standard anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "earmor" || %armor == "efemale")			//== Engineer
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Engineer armor mines are not quite mines, they will however alert you to enemies with in 25m.\", 10);", 0);
   		}
   		if (%armor == "barmor" || %armor == "bfemale")			//== Goliath
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Goliath mines are standard anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "harmor")						//== Base Heavy
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Heavy's mines are standard anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "darmor")						//== Dreadnaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Dreadnauhght armors mine are special, the are small Point Defence Laser turrets that will detonate after 25 seconds.\", 10);", 0);
   		}
   		if (%armor == "jarmor")						//== Juggernaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Juggernaught does not carry any mines.\", 10);", 0);
   		}
   		if (%armor == "parmor")
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not have any mines.\", 10);", 0);
   		}
   	}
   	else if (%opt == "grenade") //===================================================================================== Grenades
   	{
		if ($Shifter::Debug) echo ("Armor = " @ %armor);
   		
		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You are either dead or in observer mode.\", 10);", 0);
		}
		if (%armor == "spyarmor" || %armor == "spyfemale") 		//== Chemeleon
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Chemeleon grenades are Plastique, they will stick to any surface and detonate in 15 seconds.\", 10);", 0);
   		}
   		if (%armor == "sarmor" || %armor == "sfemale") 			//== Scout
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The scout grenades are Fire Bomb grenades...\", 10);", 0);
   		}
   		if (%armor == "larmor" || %armor == "lfemale") 			//== Assasin
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Assassin grenades are more like mines, but they look just like repair packs.\", 10);", 0);
   		}
   		if (%armor == "aarmor" || %armor == "afemale")			//== Arbitor
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Arbitor grenades will poison the enemy.\", 10);", 0);
   		}
   		if (%armor == "marmor" || %armor == "mfemale")			//== Mercinary
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Merc armor has only standard grenades.\", 10);", 0);
   		}
   		if (%armor == "earmor" || %armor == "efemale")			//== Engineer
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The engineer grenage does a good deal of shock damage but will also EMP the enemy.\", 10);", 0);
   		}
   		if (%armor == "barmor" || %armor == "bfemale")			//== Goliath
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Goliath grenades are Concussion grenades, they will do a good bit of damage and bang the enemy around aswell.\", 10);", 0);
   		}
   		if (%armor == "harmor")									//== Base Heavy
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Heavy's grenade is much like a mortar shell.\", 10);", 0);
   		}
   		if (%armor == "darmor")									//== Dreadnaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Dreadnaught grenade is much like a mortar shell.\", 10);", 0);
   		}
   		if (%armor == "jarmor")									//== Juggernaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Juggernaught does not carry grenades.\", 10);", 0);
   		}
   		if (%armor == "parmor")
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You do not have grenades.\", 10);", 0);
   		}
   	}
   	else if (%opt == "beacon") //===================================================================================== Beacon
   	{
		if ($Shifter::Debug) echo ("Armor = " @ %armor);
   		
		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You are either dead or in observer mode.\", 10);", 0);
		}
		if (%armor == "spyarmor" || %armor == "spyfemale") 		//== Chemeleon
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Chemeleon beacons look much like cameras, however when deployed can be detonated from any command station or laptop.\", 10);", 0);
   		}
   		if (%armor == "sarmor" || %armor == "sfemale") 			//== Scout
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Scout armor beacon is a small pulse sensor for scouting out awawy from the base.\", 10);", 0);
   		}
   		if (%armor == "larmor" || %armor == "lfemale") 			//== Assasin
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Assassin beacons are Deployable Sensor Jammers.\", 10);", 0);
   		}
   		if (%armor == "aarmor" || %armor == "afemale")			//== Arbitor
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Arbitor beacons will allow you to cloak for about 15 seconds.\", 10);", 0);
   		}
   		if (%armor == "marmor" || %armor == "mfemale")			//== Mercinary
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Mercinary armor carries a booster that will create a force behind you that will launch you in the direction that you are facing.\", 10);", 0);
   		}
   		if (%armor == "earmor" || %armor == "efemale")			//== Engineer
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Engineer beacon is a camera unit that you can use to spy on the enemy with.\", 10);", 0);
   		}
   		if (%armor == "barmor" || %armor == "bfemale")			//== Goliath
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Goliath beacons are Fire Bomb grenades, they will explode and catch players on fire.\", 10);", 0);
   		}
   		if (%armor == "harmor")									//== Base Heavy
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> With standard heavy armor, you have Nuke Bomb grenades, much like mortar shells.\", 10);", 0);
   		}
   		if (%armor == "darmor")									//== Dreadnaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Dreadnaught beacons are an emergency force shield, your will be better protected for a few seconds.\", 10);", 0);
   		}
   		if (%armor == "jarmor")									//== Juggernaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Juggernaught armor does not carry any beacons.\", 10);", 0);
   		}
   		if (%armor == "parmor")
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You do not have any beacons.\", 10);", 0);
   		}
   	}

//=========================================================================================================================================   
   else if(%opt == "fteamchange")
   {
	if ($debug) echo("fteamchange");
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);

		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
	return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
      }
      
	  if($Shifter::KeepBalanced)
      {
	      %j = checkTeams();
	      
		  if($Shifter::KeepBalanced)
      	  {
      	  	%i = checkTeams();
          	Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
          }
      	  else
          {
          	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
               Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      	  }
      }
      return;
      
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
      
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
      
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   
   else if(%opt == "cffa")
   {
	Admin::setModeFFA(%clientId);
   	return;
   }
   
   else if(%opt == "ctourney")
   {
      Client::buildMenu(%clientId, "Confirm Toruney Mode:", "faffirm", true);
      Client::addMenuItem(%clientId, "1Enable", "yes");
      Client::addMenuItem(%clientId, "2Cancel", "no");
      return;
   }
      
   else if(%opt == "voteYes" && %cl == $curVoteCount) //====================================================================== Yes
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   
   else if(%opt == "voteNo" && %cl == $curVoteCount) //======================================================================= No
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   
   else if(%opt == "kick") //================================================================================================= Kick Player
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   
   else if(%opt == "admin") //================================================================================================ Admin
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   
   else if(%opt == "deadmin") //============================================================================================== DeAdmin Conf
   {
      Client::buildMenu(%clientId, "Confirm deadmim:", "daffirm", true);
      Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   
   else if(%opt == "botmenu") //============================================================================================== Bot Menu
   {
         Client::buildMenu(%clientId, "Bot Menu:", "selbotaction", true);
         Client::addMenuItem(%clientId, "1Spawn A Bot", "spawnbot");
	     Client::addMenuItem(%clientId, "2Remove Bot", "removebot");
	     if(%clientId.isSuperAdmin)
		 	Client::addMenuItem(%clientId, "3Killem All", "kbaffirm");
         
		 return;
   }
   
   else if(%opt == "ban") //================================================================================================== Ban Player
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "kill") //======================================================================== Admin Kill Player
   {
	Player::setArmor(%cl,larmor);
	armorChange(%cl);
	Player::blowUp(%cl);
	remoteKill(%cl);
	messageAll(0, Client::getName(%cl) @ " spontaneously combusted.");
	return; 
   }
   else if(%opt == "removetk")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
	%cl.TKCount = 0;
	echo("ADMINMSG: **** " @ %aname @ " cleared " @ %name @ "'s TK Count.");
	schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>Your TK's have been cleared. Be thankful!\",5);",0.5);
   }
   else if(%opt == "leader")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
   	if (%cl.islead)
  	{
		%cl.islead = 0;
		echo("ADMINMSG: **** " @ %aname @ " revoked " @ %name @ "'s LeaderShip Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>Your LeaderShip Status Has Been Revoked!\",5);",0.5);
  	}
  	else
  	{
		%cl.islead = 1;
		echo("ADMINMSG: **** " @ %aname @ " granted " @ %name @ " LeaderShip Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>You Have Been Granted LeaderShip Status!\",5);",0.5);
  	}   
   }
   else if(%opt == "fnoban")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
   	if (%cl.noban)
  	{
		%cl.noban = 0;
		echo("ADMINMSG: **** " @ %aname @ " revoked " @ %name @ "'s No Ban Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>Your No Ban Status Has Been Revoked!\",5);",0.5);
  	}
  	else
  	{
		%cl.noban = 1;
		echo("ADMINMSG: **** " @ %aname @ " granted " @ %name @ " No Ban Status");
		schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>You Have Been Granted No Ban Status!\",5);",0.5);
  	}   
   }
   else if(%opt == "kbk") //======================================================================== Kill Ban Kick Menu
   {
	Client::buildMenu(%clientId, "Kill Ban Kick:", "options", true);
	%name = Client::getName(%cl);%sel = %cl;
	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
	return;
   }
//==================================================================================================== Penis Curse
else if(%opt == "peniscurse") 
{
	%armor = Player::getArmor(%cl);
	if (%armor != parmor) 
	{
		 Player::setArmor(%cl,parmor);
		 checkMaxDrop(%cl,parmor);
		 armorChange(%cl);
		 Player::setItemCount(%cl, $ArmorName[%armor], 0);
		 
		 messageAll(0, Client::getName(%cl) @ " was given ONE FOR BEING ONE by " @ Client::getName(%clientId) @ ".");
		 Player::setItemCount(%cl, Penis, 1);
		 Player::mountItem(%cl, Penis, $WeaponSlot);
 
	  	 if(Player::getMountedItem(%cl,$FlagSlot) != -1)
	 	 	Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
 	}
	else
	{
	  	Client::sendMessage(%clientId,0,"Removing The Curse...");
		messageAll(0, " The curse has been lifted from " @ Client::getName(%cl) @ ", the price is death...");
		Player::setArmor(%cl,aarmor);
		schedule ("Player::setArmor(" @ %cl @ ",marmor);", 0.4);
		schedule ("Player::setArmor(" @ %cl @ ",larmor);", 0.8);
		schedule ("Player::setArmor(" @ %cl @ ",harmor);", 1.1);
		schedule ("Player::setArmor(" @ %cl @ ",earmor);", 1.4);
		schedule ("Player::setArmor(" @ %cl @ ",spyarmor);", 1.7);
		Vehicle::passengerJump(0,%cl,0);	
		Player::dropItem(%cl,Penis);
	   	Player::blowUp(%cl);
		schedule ("Player::Kill(" @ %cl @ ");", 2.0);
		schedule ("playSound(ShockExplosion,GameBase::getPosition(" @ %cl @ "));",2.0);

		%obj = newObject("","Mine","PenisBlast");
		addToSet("MissionCleanup", %obj);
		%pos = GameBase::getPosition(%cl);
		GameBase::setPosition(%obj, %pos);
	}
}
//======================================================================================================================= End Penis Curse

   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   
   else if(%opt == "vcmission" || %opt == "cmission")
   {
	%first = getWord(%options, 1);

	if (%opt == "vcmission")
		%clientId.vote = 1;

	Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
	%index = 0;

	if ($MList::TypeCount < 2) $TypeStart = 0; else $TypeStart = 1;

	for(%i = $TypeStart; %i < $MLIST::TypeCount; %i++)
	{
		if ($MLIST::Type[%i] != "Training")
		{
			%index++;
			if (%index <= 7)
			{
				Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
			}
			else
			{
				Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %i);
				break;
			}
		}
	}
	return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "matchConfig")
   {
      Client::buildMenu(%clientId, "Confirm Match configuration:", "maffirm", true);
      Client::addMenuItem(%clientId, "1Enable", "yes");
      Client::addMenuItem(%clientId, "2Cancel", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }

   Game::menuRequest(%clientId);
}

//====================================================================================================== Varrious Menu Process

function processMenuKAffirm(%clientId, %opt)
{
	echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Kicked By " @ Client::getName(%clientId));

   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
	echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Banned By " @ Client::getName(%clientId));

   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
 	 echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Admined By " @ Client::getName(%clientId));
         
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuDAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
	if(%clientId.isSuperAdmin && !%cl.isSuperadmin)
	{
		%cl = getWord(%opt, 1);
		%cl.isAdmin = false;
		messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s admin ability.");
		echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Admined Revoked By " @ Client::getName(%clientId));
		return;
	}
	else if (%cl.isSuperadmin)
	{
		bottomprint(%clientId, "<jc>You can not Revoke a Super Admin.");
		return;
	}
   }
   Game::menuRequest(%clientId);
}


function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server Reset By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      exec("serverConfig.cs");
       	 Server::storeData();
      	 echo("ADMINMSG: **** Default config stored");
      	 Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuFAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server set to Tournament Mode By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " has set the server to Tournament mode.");
      Admin::setModeTourney(%clientId);
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

function processMenuMAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server set to match configuration By " @ Client::getName(%clientId));
	 messageAll(0, Client::getName(%clientId) @ " set the server to match settings.");
     	 exec("matchConfig.cs");
     	 Server::storeData();
      	 echo("ADMINMSG: **** Match config stored");
      	 Server::refreshData();
    
   }
   Game::menuRequest(%clientId);
}

//================================================================================================================ Bot Control Functions
// Check for team with lowest # of players  (Based on code by Shrike and Labrat)

function checkTeams()
{
      %numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i=0;%i<%numTeams;%i=%i+1)
         	%numTeamPlayers[%i] = 0;
			
      for(%i=0;%i<%numPlayers;%i=%i+1)
      {
         	%pl = getClientByIndex(%i);
         	if(%pl != %playerId)
         	{
            		%team = Client::getTeam(%pl);
            		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         	}
      }
      %lowPlayer = %numTeamPlayers[0];
      %lowTeam = 0;

      for(%i=1;%i<%numTeams;%i=%i+1)
      {
         	if(%numTeamPlayers[%i] < %lowPlayer)
         	{
            		%lowTeam = %i;
            		%lowPlayer = %numTeamPlayers;
         	}
      }
      return %lowTeam;
} 

function DistanceToTarget (%clientId, %targetId)
{
	return (Vector::getDistance(GameBase::getPosition(%clientId),GameBase::getPosition(%targetId)));
}

// ===============================================================================================================
function MatchAssign()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%clName = Client::getName(%pl);
		if ($debug) echo($Shifter::tag0 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag0 @ %pl));
      		if ($debug) echo($Shifter::tag1 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag1 @ %pl));
      		if(String::findSubStr(%clName,$Shifter::Tag0) == 0)
		 {
			//processmenuPickTeam(%pl,0,"");
			GameBase::setTeam(%pl,0);
		 }		
		else if(String::findSubStr(%clName,$Shifter::Tag1) == 0)
		 {
			//processmenuPickTeam(%pl,1,"");
			GameBase::setTeam(%pl, 1);
		 }
		 else 
      			GameBase::setTeam(%pl, -1);
	}
	return;
}

function beginMatchMode()
{
             exec("matchConfig.cs");
     	 Server::storeData();
      	 echo("ADMINMSG: **** Match config enabled");
      	 Server::refreshData();
}
