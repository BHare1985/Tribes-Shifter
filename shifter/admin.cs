$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$Shifter::TKDefault = $Shifter::TeamKillOn;
$pskin = $Shifter::PersonalSkin;
$CPU::estimatedSpeed = 091202;
$greyflcn::newdate = "9-12-2002";
$Server::Info = $Server::Info @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
//if($dedicated) 
if(!$noTabChange) $ModList = "Shifter_v1G";
if(String::findSubStr($Server::MODInfo, "\nRunning Shifter_v1G " @ $greyflcn::newdate) == -1)
	$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
function dbecho(%this)
{
	if($debug) echo(%this);
}

function remotebwadmin::iscompatible(%client) { echo("bwadmin is not compatible"); return false; }

function bp(%arg1, %arg2, %arg3, %arg)
{
	echo(%arg1);
	echo(%arg2);
	echo(%arg3);
	echo(%arg4);
}

//remoteeval(2048, getip, 2049);

function remoteGetIp(%clientId, %selId)
{
	if(%clientId != %selId)
	{
		%ip = Client::getTransportAddress(%selId);
		%name = Client::getName(%selId);
		if(%ip != ""&& %name != "")
		{
			Client::sendMessage(%clientId, 0, "- Plr Name: " @ %name @ " - Plr IP: " @ %ip);
			return true;
		}
		return false;	
	}
}

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
				}
				else
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
		messageAll(1, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
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

//remoteEval(2048, flagreturnmanual);
function remoteflagreturnmanual(%client)
{
  	if(%client.isSuperAdmin)
		messageAll(0, Client::getName(%client) @ " set Flag Return to Manual-Return");
	$Shifter::FlagNoReturn = "True";
}

//remoteEval(2048, flagreturnauto);
function remoteflagreturnauto(%client)
{
  	if(%client.isSuperAdmin)
		messageAll(0, Client::getName(%client) @ " set Flag Return to Auto-Return");
	$Shifter::FlagNoReturn = "False";
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

function remoteSetTeamInfo(%client, %team, %teamName, %tag) //%skinBase)
{
	if(%team >= 0 && %team < 8 && %client.isSuperAdmin)
	{
		$Server::teamName[%team] = %teamName;

		//$Server::teamSkin[%team] = %skinBase;
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
		{
			return;
		}
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
		$builder = false;
		$ceasefire = false;
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
		//Server::loadMission($missionName);
		//Game::ForceTourneyMatchStart();
	}
}


function Admin::voteFailed()
{
	$curVoteInitiator.numVotesFailed++;

	if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "leader")
		$curVoteOption.voteTarget = "";
}

function Admin::voteSucceded()																					// admin.cs
{
	echo("\"V\"" @ $curVoteAction @ "\"" @ $curVoteOption @ "\"");

	$curVoteInitiator.numVotesFailed = "";
	if($curVoteAction == "kick")
	{
		if($curVoteOption.voteTarget)
		{
			Admin::kick(-1, $curVoteOption);
		}
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
	else if($curVoteAction == "leader")
	{
		//greygrey
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.islead = true;
			messageAll(0, Client::getName($curVoteOption) @ " has recieved leader status.");
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
		%totalVotes = %votesFor + %votesAgainst;
		if(%totalVotes < %minVotes)
			%totalVotes = %minVotes;
	}

	if($curVoteAction == "leader")
	{
		%margin = $Server::VoteAdminWinMargin;
		%totalVotes = %votesFor + %votesAgainst;
		if(%totalVotes < %minVotes)
			%totalVotes = %minVotes;
	}
	
	if(%votesFor / %totalVotes >= %margin)
	{
		messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesAbstain @ " abstentions.");
		Admin::voteSucceded();
	}
	else
	{

		if($curVoteAction == "kick")
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

			if(%votesFor / %totalVotes >= $Server::VoteWinMargin)
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
		messageall(1, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic, 10);
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
		%name = Client::getName(%selId);
		remoteEval(%clientId, "setInfoLine", 1, "Game Stats");
		remoteEval(%clientId, "setInfoLine", 2, "Addr-IP   :" @ %addr);
		remoteEval(%clientId, "setInfoLine", 3, "Last TKer :" @ $Shifter::LastTKer @ "    T-Kills   :" @ %clientId.TotalKills);
		remoteEval(%clientId, "setInfoLine", 4, "Last TKed :" @ $Shifter::LastTKed @ "    T-Score   :" @ %clientId.TotalScore);
		remoteEval(%clientId, "setInfoLine", 5, "TK Count  :" @ $Shifter::LastTKno @ "    T-Deaths  :" @ %clientId.TotalDeaths);
		remoteEval(%clientId, "setInfoLine", 6, "T-Caps    :" @ %clientId.TotalFlagCaps);
		Client::sendMessage(%clientId, 0, "- Plr Name:" @ %name @ " - " @ %addr @ "");		
	}
}

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isAdmin || %clientId.islead)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
        checkPlayerCash(%clientId);
        if(%team < -2 || %team > ( getNumTeams() - 1 ))
                return;
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
                                if ($Shifter::SwitchPerm && %clientId != %adminClient)
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

  	if(%clientId.islead && $Server::TourneyMode && %clientId.selClient)
  	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);				
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

		//=============================================================== Client Selected 
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
	else if(%opt == "warnp")  //============================================================== Send Observe Warning
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
	else if(%opt == "observep") //============================================================== Obs, Selected
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		Observer::setTargetClient(%clientId, %sel);
	}
	
	//==================================================================== Set Observer Options
	else if(%opt == "obssetcfollow") {		%clientId.obsmode = 4; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetffollow") {	%clientId.obsmode = 5; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetaction") {	%clientId.obsmode = 6; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetvclose") { 	%clientId.obsmode = 3; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Very close mode set as default.",3); return; }
	else if(%opt == "obssetclose") { 	%clientId.obsmode = 0; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Close mode set as default.",3); return; }
	else if(%opt == "obssetfar") { 		%clientId.obsmode = 1; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Far View set as default.",3); return; }
	else if(%opt == "obssetfirst") { 	%clientId.obsmode = 2; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, First person view set as default.",3); return; }
	else if(%opt == "obssetspy") { if (	%clientId.spymode == "0" || !%clientId.spymode) { %clientId.spymode = "1"; bottomprint(%clientId, "Observer Spy mode is set, observed player will recieve no warning.",3); } else { %clientId.spymode = "0"; bottomprint(%clientId, "Observer Warn mode is set, player will recieve notice that you are observing",3); } return; }
	
	//========================================================================== Voting Options
	else if(%opt == "menurequest3")
	{   
		if ($Debug) echo("*** Process Voting Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Voting Menu");
		%curItem = 0;
		Client::buildMenu(%clientId, "Voting Options", "options", true);
		//================================================================== Client Selected 
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
				if($server::tourneymode == true)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to leader " @ %name, "vleader " @ %sel);
			}

			if(%clientId.muted[%sel])
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}

		//=============================================================== No Client Selected 
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
//==========================================================
//  Secondary Menu System - Mostly Super Admin Functions
//==========================================================

	else if(%opt == "menurequest2")
	{   
		if ($Debug) echo("*** Process Admin Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Admin Menu");
		%curItem = 0;
		Client::buildMenu(%clientId, "Admin Options", "options", true);
		//=============================================================== Client Is Only Admin
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
				else if(%clientId.isSuperAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Tournament mode", "ctourney");
			}
		}
		
		//=========================================================== Client Is Admin & Super
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
			//============================================================ With No Client			
			else
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");		
				if($Shifter::TeamKillOn)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Team Kills", "dtk");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Team Kills", "etk");	
				//Client::addMenuItem(%clientId, %curItem++ @ "Server Configuration", "serversetup");
				Client::addMenuItem(%clientId, %curItem++ @ "Run MatchConfig.cs", "matchConfig");
				Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");		
			}
		}
		//============================================== Client Is Admin But NOT Super Admin
		//greyflcn
		//wth is this do?
		if(%clientId.isAdmin && %clientId.isSuperAdmin && %clientId.isGod)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);
			}
		}
		return;
	}
	else if (%clientid.isadmin && %opt == "cyclemissions")
	{
		remoteCycleMission(%clientId);
	}

//==============================================================================
// Print Help Screens.
//==============================================================================

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
   		Client::addMenuItem(%clientId, %curItem++ @ "Updates", "update");
   		return;
  	} 	
	else if (%opt == "locate")
	{
		Client::buildMenu(%clientId, "Locate Options", "options", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Enemy Flag Location", "nmeflag");
   	Client::addMenuItem(%clientId, %curItem++ @ "Friendly Flag Location", "frdflag");
			return;
	}

	else if (%opt == "update")
	{
		%helpmsg1 = "Would be 9/11.. but I couldn't do that";
		//%helpmsg1 = "Shifter040402 Added the teamchange hack fix.";
		//%helpmsg1 = "Shifter021302 Sensor Jammer replaces Jammer Device, Nuke/Det/Missile/Score Counter in reg mode, and a bunch of stuff to smooth out matches";
		//%helpmsg1 = "Shifter232 Damn 222 was a cool date, fixed my dumb MDM mistake, also put builder as an option, and not standard for ceasefire.  Made it so ppl can't lag out servers w/ droppers."; 
		//Shifter222 Hella stuff 9-28'ized, awesome tourney setup, builder in ceasefire ;), jammer works.";
		//%helpmsg1 = "Shifter0104 Rehauled the heavy weapon code.... oooh clean.\nShifter0102Lotsa stuff, uhg tired.  Open the g_whats_new.txt\nShifter1103 Fixed some bugs, ion rifle better, Godhammer module WORKS, ion & elf for scout, EMP on MDM hits first.";
		//\nShifter924 LasCannon, One blastwalls worth of damage, exact\nShifter923 One more tweak for mortars, Arbitor Teammate Anti-EMP touch, Chem gets targeting beacon option
		//\nShifter922 Sloppy fix for broadside elevator,Targeting for mortars (FINALLY),Laser mines take 1 second to activate
		//\nShifter919: Fixed some laser mine code,flight/cloak/senjam/RMTSenJam packs allow you to dodge non-stinger rockets,MDM emp 8m radius,EngCamBeacon,6 blastfloor bugfix, No fakedeath in matchs,Sniper rifle fixed,Stim laser rifle=lowered energy, multi plasma extra fireball
		//%helpmsg1 = "<jc><f1>Shifter919 Read whats_new.txt in the ZIP. Lazy right now.  :P\nShifter912 Fixed some buggies, merc magnum, chem no EMP beacon damage, station weaponback";
		//%helpmsg2 = "<jc><f1>Shifter907 no sniper rifle \"lag\",Telefragging,Assassin Ninja Stars & Shockcharges,Ion gun (testing),Disc Launcer Options\nShifter830 Fixed range w/ throwing stars, If telebeacon is set, can press pack\nShifter829 Ass beacon-mine-grenade, Arb beacon cures EMP, Teleport Pack changed Warped, LasCannon lowered (1.75 blastwalls), Base projectile damage of plasma cannnon raised, 1 sec. plastique added to TAB menu (Heh) remoteEval(2048, weapon_plastic_plasvar, 1);";

  		centerprint(%clientId,%helpmsg1, 10);
  		//schedule("centerprint(" @ %clientId @ ",\"" @ %helpmsg2 @ "\", 10);", 10);
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
			bottomprint(%clientId, "<jc><f1>Locate does not work in multi team.", 3);
			return;
		}
		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
		bottomprint(%clientId, "<jc><f1>The enemy flag is " @ %distance @ " meters away.", 3);
			return;
	}
	else if (%clientid.isadmin && %opt == "tcrights")
	{
		if (%cl.SwitchPerm)
		{
			%cl.SwitchPerm = "False";
			bottomprint(%cl, "<jc><f1>You now have rights to switch teams.", 3);
		}
		else if (!%cl.SwitchPerm)
		{
			%cl.SwitchPerm = "True";
			bottomprint(%cl, "<jc><f1>Your rights to switch teams has been revoked.", 3);
		}
	}
	else if (%clientid.isadmin && %opt == "muteplayer")
	{
		if (%cl.ismuted)
		{
			%cl.ismuted = "False";
			bottomprint(%cl, "<jc><f1>You have been allow to speak again, watch you mouth...", 3);			
		}
		else if (!%cl.ismuted)
		{
			%cl.ismuted = "True";
			bottomprint(%cl, "<jc><f1>You have been globally muted by admin, NO ONE CAN HEAR YOU ANY MORE...", 3);
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
		bottomprint(%clientId, "<jc><f1>Your flag is " @ %distance @ " meters away.", 3);
		return;
	}


//===============================================================================================
//=========================== Weapon Options ====================================================
//===============================================================================================
	if (%opt == "weaponoptions") 
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
   		
		if (%armor != "jarmor")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Disc Options", "weapon_disc");
		
		if (%armor == "barmor" || %armor == "bfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_gbeacon");

		if (%armor == "larmor" || %armor == "lfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_abeacon");

		if (%armor == "spyarmor" || %armor == "spyfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_cbeacon");

   		Client::addMenuItem(%clientId, %curItem++ @ "Weapon Order", "weaponorder");			
   		
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
	else if(%clientid.isadmin && %opt == "admin_weapons")
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
	else if (%clientid.isadmin && %opt == "ad_missle_on")
	{
		$Shifter::LockOn = True;
		return;
	}
	else if (%clientid.isadmin && %opt == "ad_missle_off")
	{
		$Shifter::LockOn = False;
		return;
	}
	else if (%clientid.isadmin && %opt == "ad_turret_on")
	{	
		$Shifter::TurretKill = True;
		return;
	}
	else if (%clientid.isadmin && %opt == "ad_turret_off")
	{
		$Shifter::TurretKill = False;
		return;
	}
	else if (%opt == "cleartelepoint")
	{
		%clientID.telepoint = "False";
		if(%clientID.telebeacon)
		{
			deleteobject(%clientID.telebeacon);
			%clientID.telebeacon = "False";
		}
		if(%clientID.teledisk)
		{
			deleteobject(%clientID.teledisk);
			%clientID.teledisk = "False";
		}		
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
		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Favorites", "spawn_favs");
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
  		Client::addMenuItem(%clientId, %curItem++ @ "Locking Stinger", "weapon_rocket2");
		if ($Shifter::LockOn)
	  		Client::addMenuItem(%clientId, %curItem++ @ "Heat Seeker", "weapon_rocket3");
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
	else if (%opt == "weapon_disc")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Disc Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_disc_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_disc_rapid");
  		return;
	}
	else if (%opt == "weapon_dmines")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Mine Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "DLM (Laser Mines)", "weapon_dmines1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_dmines2");
  		return;
	}
	else if (%opt == "weapon_abeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Poison Throwing Stars", "weapon_abeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Shock Charges", "weapon_abeacon2");
 		return;
	}
	else if (%opt == "weapon_cbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Satchel", "weapon_cbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_cbeacon2");
 		return;
	}
	else if (%opt == "weaponorder")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Weapon Order Option", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Old style", "weaponorder_0");
  		Client::addMenuItem(%clientId, %curItem++ @ "Hud-Follow", "weaponorder_1");
 		return;
	}
	else if (%opt == "weapon_gbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "options", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "FireBomb", "weapon_gbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_gbeacon2");
 		return;
	}
	else if (%opt == "weapon_gravgun")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "GravGun Options", "options", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Tractor Effect", "weapon_gravgun_tract");
   	Client::addMenuItem(%clientId, %curItem++ @ "Repulse Effect", "weapon_gravgun_repulse");
   	Client::addMenuItem(%clientId, %curItem++ @ "Grapler Effect", "weapon_gravgun_pull");
   	return;
	}
	else if (%opt == "weapon_plastic")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Plastique Options", "options", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "1 Sec. Delay", "weapon_plastic_plas1");
   	Client::addMenuItem(%clientId, %curItem++ @ "2 Sec. Delay", "weapon_plastic_plas2");
   	Client::addMenuItem(%clientId, %curItem++ @ "5 Sec. Delay", "weapon_plastic_plas5");
   	Client::addMenuItem(%clientId, %curItem++ @ "10 Sec. Delay", "weapon_plastic_plas10");
   	Client::addMenuItem(%clientId, %curItem++ @ "15 Sec. Delay", "weapon_plastic_plas15");
   	return;
	}
	//========================================================= Engineer Opts
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
		Client::addMenuItem(%clientId, %curItem++ @ "Missile Jammer", "weapon_engbeacon_antimissile");
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
	//========================================================= Merc Booster
	else if (%opt == "booster_norm")
	{
		%clientId.booster = "0";
		bottomprint(%clientId, "<jc><f1>Booster Set To Normal Mode.", 3);
   	return;
	}
	else if (%opt == "booster_adv")
	{
		%clientId.booster = "1";
		bottomprint(%clientId, "<jc><f1>Booster Set To Advanced Mode.", 3);
   	return;
	}
	//========================================================= Engineer Mines
	else if(%opt == "weapon_engmine_proxy")
	{
		%clientId.EngMine = "0";
		bottomprint(%clientId, "<jc><f1>Mine Set To Proximity Detector.", 3);
  		return;
	}
	else if(%opt == "weapon_engmine_cloak")
	{
		%clientId.EngMine = "1";
		bottomprint(%clientId, "<jc><f1>Mine Set To Cloaking Mine.", 3);
  		return;
	}
	else if(%opt == "weapon_engmine_laser")
	{
		%clientId.EngMine = "2";
		bottomprint(%clientId, "<jc><f1>Mine Set To Point Defense Laser Mine.", 3);
  		return;
	}
	else if(%opt == "weapon_engmine_stand")
	{
		%clientId.EngMine = "3";
		bottomprint(%clientId, "<jc><f1>Mine Set To Standard Anti-Personell Mine.", 3);
  		return;
	}
	else if(%opt == "weapon_engmine_replica")
	{
		%clientId.EngMine = "4";
		bottomprint(%clientId, "<jc><f1>Mine Set To Replicator Mine.", 3);
  		return;
	}
	//================================================================= Engineer Beacons
	else if(%opt == "weapon_engbeacon_standard")
	{
		%clientId.EngBeacon = "0";
		bottomprint(%clientId, "<jc><f1>Beacon Set To Standard.", 3);
  		return;
	}
	else if (%opt == "weapon_engbeacon_camera")
	{
		%clientId.EngBeacon = "1";
		bottomprint(%clientId, "<jc><f1>Beacons Set To Cloaking Camera.", 3);
   		return;
	}
	else if (%opt == "weapon_engbeacon_antimissile")
	{
		%clientId.EngBeacon = "2";
		bottomprint(%clientId, "<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.", 3);
   		return;
	}
	else if (%opt == "weapon_engbeacon_medikit")
	{
		%clientId.EngBeacon = "3";
		bottomprint(%clientId, "<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.", 3);
   		return;
	}		
	//=================================================================== Eng-Gun Options
	else if (%opt == "weapon_eng_repair")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 0;		
			Player::setItemCount(%clientId, Fixit , 1);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::mountItem(%clientId, Fixit, $WeaponSlot);		
			bottomprint(%clientId, "<jc><f1>Repair Gun Option Selected.", 3);
		}
		else
		{		
			if (Player::getItemCount(%clientId, FixIt))
				bottomprint(%clientId, "<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.", 3);
			else			
				bottomprint(%clientId, "<jc><f1>You do not possess a Engineer Gun.", 3);
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
			bottomprint(%clientId, "<jc><f1>Hacking Option Selected.", 3);
		}
		else
		{		
			if (Player::getItemCount(%clientId, HackIt))
				bottomprint(%clientId, "<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.", 3);
			else			
				bottomprint(%clientId, "<jc><f1>You do not possess a Engineer Gun.", 3);
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
			bottomprint(%clientId, "<jc><f1>Disassymbler Option Selected.", 3);
		}
		else
		{		
			if (Player::getItemCount(%clientId, DisIt))
				bottomprint(%clientId, "<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.", 3);
			else			
				bottomprint(%clientId, "<jc><f1>You do not possess a Engineer Gun.", 3);
		}
   	return;
	}

	//========================================================= Plastique
	else if(%opt == "weapon_plastic_plas1")
	{
		%clientId.Plastic = 1;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 1 Sec.", 3);
   	return;
	}
	else if(%opt == "weapon_plastic_plas2")
	{
		%clientId.Plastic = 2;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 2 Sec.", 3);
   	return;
	}
	else if (%opt == "weapon_plastic_plas5")
	{
		%clientId.Plastic = 5;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 5 Sec.", 3);
   	return;
	}
	else if (%opt == "weapon_plastic_plas10")
	{
		%clientId.Plastic = 10;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 10 Sec.", 3);
   	return;
	}
	else if (%opt == "weapon_plastic_plas15")
	{
		%clientId.Plastic = 15;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 15 Sec.", 3);
   	return;
	}

	//===================================================== Mortar Options
	//greygrey
	if (%opt == "weapon_mortar_regular")
	{
		%clientId.Mortar = 0;
		bottomprint(%clientId, "<jc><f1>Standard Mortar Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
		return;
	}
	else if (%opt == "weapon_mortar_emp")
	{
		%clientId.Mortar = 1;
		bottomprint(%clientId, "<jc><f1>Magnetic Pulse Shell Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	else if (%opt == "weapon_mortar_frag")
	{
		%clientId.Mortar = 2;
		bottomprint(%clientId, "<jc><f1>Fragmenting Shell Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	else if (%opt == "weapon_mortar_mdm")
	{
		%clientId.Mortar = 3;
		bottomprint(%clientId, "<jc><f1>MDM Shell Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	//===================================================== Rocket Options
	else if (%opt == "weapon_rocket1")
	{
		%clientId.rocket = 0;
		bottomprint(%clientId, "<jc><f1>Stinger Rocket Initiated.", 3);
   	return;
	}
	else if (%opt == "weapon_rocket2")
	{
		%clientId.rocket = 1;
		bottomprint(%clientId, "<jc><f1>Stinger Locking Initiated.", 3);
   		return;
	}
	else if (%opt == "weapon_rocket3")
	{
		%clientId.rocket = 2;
		bottomprint(%clientId, "<jc><f1>Heat Seeking Initiated.", 3);
   		return;
	}
	else if (%opt == "weapon_rocket4")
	{
		%clientId.rocket = 3;
		bottomprint(%clientId, "<jc><f1>Wire Guided System Initiated.", 3);
  		return;
	}

	//====================================================== Dread Mine Options
	else if (%opt == "weapon_dmines1")
	{
		%clientId.dmines = 0;
		bottomprint(%clientId, "<jc><f1>Mines Set To DLM.", 3);
   		return;
	}
	else if (%opt == "weapon_dmines2")
	{
		%clientId.dmines = 1;
		bottomprint(%clientId, "<jc><f1>Mines Set To Standard.", 3);
   		return;
	}
	else if (%opt == "weapon_dmines3")
	{
		%clientId.dmines = 2;
		bottomprint(%clientId, "<jc><f1>Mines Set To Light-AP.", 3);
   		return;
	}

	//===============================Assassin Beacon
	else if (%opt == "weapon_abeacon1")
	{
		%clientId.AssBcn = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Poison Throwing Stars.", 3);
   	return;
	}
	else if (%opt == "weapon_abeacon2")
	{
		%clientId.AssBcn = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Shock Charge.", 3);
  		return;
	}

	else if (%opt == "weaponorder_0")
	{
		%clientId.WeaponOrder = "0";
		bottomprint(%clientId, "<jc><f1>Old style WeaponOrder.", 3);
   	return;
	}
	else if (%opt == "weaponorder_1")
	{
		%clientId.WeaponOrder = "1";
		bottomprint(%clientId, "<jc><f1>Hud-Follow style WeaponOrder.", 3);
  		return;
	}

	else if (%opt == "weapon_cbeacon1")
	{
		%clientId.ChemBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Satchel.", 3);
   	return;
	}
	else if (%opt == "weapon_cbeacon2")
	{
		%clientId.ChemBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}

	else if (%opt == "weapon_gbeacon1")
	{
		%clientId.GolBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To FireBomb.", 3);
   	return;
	}
	else if (%opt == "weapon_gbeacon2")
	{
		%clientId.GolBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}

	//====================================================== Plasma Options
	else if (%opt == "weapon_plasma_regular")
	{
		%clientId.Plasma = 0;
		bottomprint(%clientId, "<jc><f1>Standard Plasma Bolt Selected.", 3);
   	return;
	}
	else if (%opt == "weapon_plasma_rapid")
	{
		%clientId.Plasma = 1;
		bottomprint(%clientId, "<jc><f1>Rapid-Bold Plasma Selected.", 3);
   	return;
	}
	else if (%opt == "weapon_plasma_multi")
	{
		%clientId.Plasma = 2;
		bottomprint(%clientId, "<jc><f1>Multi-Bold Plasma Selected.", 3);
   	return;
	}
	else if (%opt == "weapon_disc_regular")
	{
		%clientId.disc = 0;
		bottomprint(%clientId, "<jc><f1>Standard Disc Shell Selected.", 3);
   	return;
	}
	else if (%opt == "weapon_disc_rapid")
	{
		%clientId.disc = 1;
		bottomprint(%clientId, "<jc><f1>Rapid Disc Shell Selected.", 3);
   		return;
	}
	//==================================================== Grav Gun Options
	else if (%opt == "weapon_gravgun_tract")
	{
		%clientId.gravbolt = 0;
		bottomprint(%clientId, "<jc><f1>Grav Gun Tractor Setting Selected.", 3);
   		return;
	}
	else if (%opt == "weapon_gravgun_repulse")
	{
		%clientId.gravbolt = 1;
		bottomprint(%clientId, "<jc><f1>Grav Gun Repulse Setting Selected.", 3);
   		return;
	}
	else if (%opt == "weapon_gravgun_pull")
	{
		%clientId.gravbolt = 2;
		bottomprint(%clientId, "<jc><f1>Grav Gun Repulse Grapler Selected.", 3);
   		return;
	}

//================================================================================   
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
   else if($Shifter::VoteAdmin && %opt == "vadmin") //grey, doubled check
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vleader") //grey, doubled check
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "leader " @ Client::getName(%cl), "leader", %cl);
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
   else if(%clientid.isadmin && %opt == "cffa")
   {
		Admin::setModeFFA(%clientId);
   	return;
   }
   else if(%clientid.isadmin && %opt == "ctourney")
   {
      Client::buildMenu(%clientId, "Tourney Mode:", "faffirm", true);
      Client::addMenuItem(%clientId, "1New Match", "new");
      Client::addMenuItem(%clientId, "2Continue Saved Match", "old");
      Client::addMenuItem(%clientId, "mMixed Scrim", "scrim");
      Client::addMenuItem(%clientId, "bBuilder Mode", "builder");
      return;
   }
   else if(%opt == "voteYes" && %cl == $curVoteCount) //=================================================== Yes
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount) //==================================================== No
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%clientid.isadmin && %opt == "kick") //=========================================================== Kick Player
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   
   else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "admin") //========================================================== Admin
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "deadmin") //======================================================== DeAdmin Conf
   {
      Client::buildMenu(%clientId, "Confirm deadmim:", "daffirm", true);
      Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "ban") //============================================================ Ban Player
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "kill") //===================================================== Admin Kill Player
   {
		Player::setArmor(%cl,larmor);
		armorChange(%cl);
		Player::blowUp(%cl);
		remoteKill(%cl);
		messageAll(0, Client::getName(%cl) @ " spontaneously combusted.");
		return; 
   }
   else if(%clientid.isadmin && %opt == "removetk")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
		%cl.TKCount = 0;
		echo("ADMINMSG: **** " @ %aname @ " cleared " @ %name @ "'s TK Count.");
		BottomPrint(%cl,"<F1><jc>Your TK's have been cleared. Be thankful!",5);
   }
   else if(%clientid.isadmin && %opt == "leader")
   {
		%name = Client::getName(%cl);
		%aname = Client::getName(%clientId);
		if (%cl.islead)
  		{
			%cl.islead = 0;
			echo("ADMINMSG: **** " @ %aname @ " revoked " @ %name @ "'s LeaderShip Status");
			BottomPrint(%cl,"<F1><jc>Your LeaderShip Status Has Been Revoked!",5);
	  	}
	  	else
  		{
			%cl.islead = 1;
			echo("ADMINMSG: **** " @ %aname @ " granted " @ %name @ " LeaderShip Status");
			BottomPrint(%cl,"<F1><jc>You Have Been Granted LeaderShip Status!",5);
	  	}   
   }
   else if(%clientid.isadmin && %opt == "fnoban")
   {
   	%name = Client::getName(%cl);
   	%aname = Client::getName(%clientId);
   	if (%cl.noban)
	  	{
			%cl.noban = 0;
			echo("ADMINMSG: **** " @ %aname @ " revoked " @ %name @ "'s No Ban Status");
			BottomPrint(%cl,"<F1><jc>Your No Ban Status Has Been Revoked!",5);
	  	}
		else
		{
			%cl.noban = 1;
			echo("ADMINMSG: **** " @ %aname @ " granted " @ %name @ " No Ban Status");
			BottomPrint(%cl,"<F1><jc>You Have Been Granted No Ban Status!",5);
  		}   
   }
   else if(%clientid.isSuperAdmin && %clientid.isadmin && %opt == "kbk") //===================================================== Kill Ban Kick Menu
   {
		Client::buildMenu(%clientId, "Kill Ban Kick:", "options", true);
		%name = Client::getName(%cl);%sel = %cl;
		Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
		return;
   }
//============================================================== Penis Curse
	if(%clientid.isSuperAdmin && %clientid.isadmin && %opt == "peniscurse") 
	{
		%armor = Player::getArmor(%cl);
		if (%armor != parmor) 
		{
			 Player::setArmor(%cl,parmor);
			 checkMaxDrop(%cl,parmor);
			 armorChange(%cl);
			 Player::setItemCount(%cl, $ArmorName[%armor], 0);
			 
			 messageAll(0, Client::getName(%cl) @ " was given ONE FOR BEING ONE by " @ Client::getName(%clientId) @ ".");
          for(%i=0;%i<=$WeaponAmmt;%i++) 
            Player::dropItem(%cl,$WeaponList[%i]); 
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
//================================================================================= End Penis Curse
   else if(%clientid.isadmin && %opt == "smatch")
	{
      Admin::startMatch(%clientId);
	}
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
   else if(%clientid.isadmin && %opt == "ctimelimit")
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
   else if(%clientid.isSuperAdmin && %clientid.isadmin && %opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%clientid.isSuperAdmin && %clientid.isadmin && %opt == "matchConfig")
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
	{
		Admin::kick(%clientId, getWord(%opt, 1));
	}
	Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
	if(%clientId.isSuperAdmin)
	{
		echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Banned By " @ Client::getName(%clientId));
	   if(getWord(%opt, 0) == "yes")
			Admin::kick(%clientId, getWord(%opt, 1), true);
		Game::menuRequest(%clientId);
	}
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
		$noFakeDeath = false;
      exec("serverConfig.cs");
		$server::tourneymode = false;
		$ceasefire = false;
		$builder = false;
		if ($Shifter::DetPackLimit == ""){ $Shifter::DetPackLimit = "15"; }
		if ($Shifter::NukeLimit == ""){ $Shifter::NukeLimit = "15"; }
		$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
		$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;
		$Server::Info = $Server::Info @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
		//if($dedicated) 
		if(!$noTabChange) $ModList = "Shifter_v1G";
		$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
		Server::storeData();
		echo("ADMINMSG: **** Default config stored");
		Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuFAffirm(%clientId, %opt)
{
   if(%opt == "new" && %clientId.isAdmin)
   {
		echo("ADMINMSG: **** Server set to Tournament Mode By " @ Client::getName(%clientId));
		%clientid.gettag0 = 1;
		%clientid.getpass = 0;
		%clientid.gettag1 = 0;
		%clientid.getglobal = 0;
		$matchtrack::global = "False";
		Client::sendMessage(%clientId, 1, "Please Enter Clan Tag #1");
		$Server::TeamDamageScale = 1;
   }
	else if(%opt == "old" && %clientId.isAdmin)
   {
		echo("ADMINMSG: **** Server set to Tournament Mode By " @ Client::getName(%clientId));
		BottomPrintAll("<F1><jc>::::Cease Fire enabled For THIS Mission::::",5);
		messageAll(1, "CeaseFire Mode enabled by "@ Client::getName(%clientid) @".");
		%clientid.getpass = 0;
		%clientid.gettag1 = 0;
		%clientid.gettag0 = 0;
		%clientid.getglobal = 0;
		$server::tourneymode = true;
		$ceasefire = true;
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Shifter::FlagNoReturn = "True";
		$Shifter::FlagReturnTime = "400";
		exec("matchtrack.cs");
		$Shifter::GlobalTChat = $matchtrack::global;
		$shifter::tag0 = $matchtrack::tag0;
		$shifter::tag1 = $matchtrack::tag1;
		$Server::HostName = $matchtrack::name;
		$server::password = $matchtrack::pass;
		messageAll(1, "password = "@ $server::password @"");
		messageAll(1, "Vote to Change Mission to Begin Match!~wteleport2.wav");
		SortTeams();
		CheckStayBase();
   }
	else if(%opt == "scrim" && %clientId.isAdmin)
   {
		%clientid.getpass = true;
		$builder = "scrim";
		$ceasefire = "true";
		$shifter::tag0 = "";
		$shifter::tag1 = "";
		$matchtrack::global = "False";
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Shifter::FlagNoReturn = "True";
		$Shifter::FlagReturnTime = "400";
		Client::sendMessage(%clientId, 1, "Please Enter Server Password");
	}
	else if(%opt == "builder" && %clientId.isAdmin)
   {
		$builder = "true";
		$ceasefire = "true";
		$server::tourneymode = true;
		$shifter::tag0 = "";
		$shifter::tag1 = "";
		$matchtrack::global = true;
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Shifter::FlagNoReturn = "True";
		$Shifter::FlagReturnTime = "400";
		messageAll(0, "You now have Full Access to Inventory Station, Press i, and Set your Faves!");
		messageAll(2, "*** *** Builder mode - GO BUILD STUFF *** ***~wteleport2.wav");
	}
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
		$noFakeDeath = true;
     	exec("matchConfig.cs");
		$server::tourneymode = false;
		$ceasefire = false;
		$builder = false;
		if ($Shifter::DetPackLimit == ""){ $Shifter::DetPackLimit = "15"; }
		if ($Shifter::NukeLimit == ""){ $Shifter::NukeLimit = "15"; }
		$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
		$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;
		$Server::Info = $Server::Info @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
		//if($dedicated) 
		if(!$noTabChange) $ModList = "Shifter_v1G";
		$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
		//$match::ceaseFireBegin = true;
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

// ===============================================================================================================

function beginMatchMode()
{
	$noFakeDeath = true;
	exec("matchConfig.cs");
	$server::tourneymode = false;
	$ceasefire = false;
	$builder = false;
	if ($Shifter::DetPackLimit == ""){ $Shifter::DetPackLimit = "15"; }
		if ($Shifter::NukeLimit == ""){ $Shifter::NukeLimit = "15"; }
		$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
		$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;
		$Server::Info = $Server::Info @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
		if(!$noTabChange) $ModList = "Shifter_v1G " @ $greyflcn::newdate;
		$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter_v1G " @ $greyflcn::newdate;
	  	 Server::storeData();
      	 echo("ADMINMSG: **** Match config enabled");
      	 Server::refreshData();
}
