$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$Shifter::TKDefault = $Shifter::TeamKillOn;
$pskin = $Shifter::PersonalSkin;
$CPU::estimatedSpeed = 2000;
$Shifter::Version = "1.0";
$Server::Info = $Server::Info @ "\nRunning Shifter 2K5 " @ $Shifter::Version;
$ModList = "Shifter 2K5";
$Server::TourneyMode = false;
if($dedicated) $ModList = "Shifter 2K5";
if(String::findSubStr($Server::MODInfo, "\nRunning Shifter 2K5 " @ $Shifter::Version) == -1)
	$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter 2K5 " @ $Shifter::Version;
	
if($Shifter::Turrets == "false"){
%ResetCMD = Turrets;
Items::On(%ResetCMD);}
if($Shifter::Deployables == "false"){
%ResetCMD = Deployables;
Items::On(%ResetCMD);}
if($Shifter::DetsNukesMCS == "false"){
%ResetCMD = DNM;
Items::On(%ResetCMD);}

if($Server::JetEffect == true){
exec("jeteffect.cs");}
else
{//do nothing
}
exec("telexp.cs");
//exec("weather.cs");
function dbecho(%this)
{
	if($debug) echo(%this);
}

function remotebwadmin::iscompatible(%client) { //echo("bwadmin is not compatible"); 
	return false; }

//function bp(%arg1, %arg2, %arg3, %arg)
//{
//	echo(%arg1);
//	echo(%arg2);
//	echo(%arg3);
//	echo(%arg4);
//}

//remoteeval(2048, getip, 2049);    // greys shit dont really know what its doin..looks like nothing from here.

function remoteGetIp(%clientId, %selId)
{
	if(%clientId != %selId)
	{
		%ip = Client::getTransportAddress(%selId);
		%name = Client::getName(%selId);
		if(%ip != ""&& %name != "" && %clientId.isadmin) // Only admins get IP -tubs
		{
			Client::sendMessage(%clientId, 0, "- Player Name: " @ %name @ " - Player IP: " @ %ip);
			return true;
		}
		return false;	
	}
}

function remoteSetPassword(%client, %password)
{
   	if(%client.isSuperAdmin)
      		$Server::Password = %password;
}

function remoteflagreturnmanual(%client)
{
  	if(%client.isSuperAdmin)
		messageAll(0, Client::getName(%client) @ " set Flag Return to Manual-Return");
	$Flag::ManualReturn = "True";
}

function remoteflagreturnauto(%client)
{
  	if(%client.isSuperAdmin)
		messageAll(0, Client::getName(%client) @ " set Flag Return to Auto-Return");
	$Flag::ManualReturn = "False";
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

function remoteVoteYes(%clientId)
{
   	%clientId.vote = "yes";

   	centerprint(%clientId, "You voted yes", 3);
}

function remoteVoteNo(%clientId)
{
   	%clientId.vote = "no";

   	centerprint(%clientId, "You voted no", 3);
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

function Admin::drop(%admin, %client)
{
	if(%admin == -1 || %admin.isAdmin)
	{


		if(%client.isSuperAdmin)
		{
			
			if(%admin == -1)
			{
				messageAll(0, Client::getName(%admin) @ " Tried to mess with "@Client::getName(%client)@" the SuperAdmin. Duh!");
				messageAll(0, "A super admin cannot be Dropped.");
			}	
			else
			{ 
				messageAll(0,  Client::getName(%admin) @ " Tried to mess with "@Client::getName(%client)@" the SuperAdmin. Duh!");
				Client::sendMessage(%admin, 0, "A super admin cannot be Dropped.");
			}	
			return;
		}
		else
			Net::Kick(%client, "");
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
				messageAll(0, Client::getName(%admin) @ " Tried to mess with "@Client::getName(%client)@" the SuperAdmin. Duh!");
				messageAll(0, "A super admin cannot be " @ %word @ ".");
			}	
			else
			{ 
				messageAll(0,  Client::getName(%admin) @ " Tried to mess with "@Client::getName(%client)@" the SuperAdmin. Duh!");
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
	if($Server::TourneyMode == "true" && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = false;
		if(%clientId == -1)
			messageAll(0, "Server switched to Normal Mode.");
		else
			messageAll(0, "Server switched to Normal Mode by " @ Client::getName(%clientId) @ ".");

		$Server::TourneyMode = false;
		$GameMode = Normal;
		$ceasefire = false;
			for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
			{
			%client.SwitchPerm = "False";
			}
		$Shifter::PlayerDamage = true;
		
        $ModList = "Shifter 2K5";
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
	if($Server::TourneyMode == "false" && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = true;
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
	%VoteName = Client::getName($curVoteOption);
	echo("Vote to " @ $curVoteAction @ " " @ %VoteName @ " Passed.");
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
		echo("" @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "");
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
		remoteEval(%clientId, "setInfoLine", 3, "Last TKer :" @ $Shifter::LastTKer @ "    Kills   :" @ %clientId.TotalKills);
		remoteEval(%clientId, "setInfoLine", 4, "Last TKed :" @ $Shifter::LastTKed @ "    Score   :" @ %clientId.TotalScore);
		remoteEval(%clientId, "setInfoLine", 5, "TK Count  :" @ $Shifter::LastTKno @ "    Deaths  :" @ %clientId.TotalDeaths);
		remoteEval(%clientId, "setInfoLine", 6, "Caps    :" @ %clientId.TotalFlagCaps);
        if (%selId.isadmin && !%selId.isSuperAdmin)
            Client::sendMessage(%clientId, 3, "" @ %name @ " is a Admin");
        if (%selId.isSuperAdmin)
            Client::sendMessage(%clientId, 3, "" @ %name @ " is a Super Admin");
        
        if (%clientId.isadmin) // only send IP to admins -tubs
		{
			remoteEval(%clientId, "setInfoLine", 2, "Addr-IP   :" @ %addr);
			Client::sendMessage(%clientId, 3, "Player Name: " @ %name @ " - " @ %addr @ "");
		}
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

        if((!$matchStarted || $Server::TourneyMode == "false" || %adminClient) && %team == -2)
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
	if(%clientId.isAFK == true || %clientId.dueling)
	return;
	if(%clientId.engaged && %clientId.rings){
		%clientId.answered = true;
		SBA::duelRespond(%clientId);
		return;
	}
	
		if(%clientId.answered == "counter")
	{
		SBA::duelCounterResponse(%clientId);
	}
	else
	{
  	%curItem = 0;
  	Client::buildMenu(%clientId, "Options", "options", true);

	//=========================================================================================== Basic Menu   	

  	if(!$matchStarted || $Server::TourneyMode == "false")
  	{
		if(!%clientId.selClient && $Server::TourneyMode == "false")
		{
    		if (!%clientId.SwitchPerm && %clientId.isAFK != "true" && %clientId.possessing != "true" && %clientId.possessed != "true" && %clientId.dan != "true")
  			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		}
  	}

  	if(%clientId.islead && $Server::TourneyMode && %clientId.selClient)
  	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);				
  	}
  	if(!%clientId.selClient)
  	Client::addMenuItem(%clientId, %curItem++ @ "Shifter 2K5 " @ $Shifter::Version, "sk");
	if (%clientId.observerMode != "observerOrbit" && %clientId.observerMode != "observerFly")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Player Functions", "playerfuncs");
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
	%sel = %clientId.selClient;
		if(%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Challenge to a Duel!", "SBADuelChallenge");
		if(%clientId.noDuels)
			Client::addMenuItem(%clientId, %curItem++ @ "Allow Duel Challenges.", "SBAduelAllow");
		if(%clientId.ignored[%sel])
			Client::addMenuItem(%clientId, %curItem++ @ "Remove Duel ignore", "SBAignoreRemove");
			if(%clientId.selClient)
	Client::addMenuItem(%clientId, %curItem++ @ "View players Duel stats", "SBADuelstats");


}
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
	%sel = %clientId.selClient;
	if(%opt == "SBADuelChallenge")
	{
		if($DspotOneTaken == "true" && $DspotTwoTaken == "true")
		{
			Client::sendMessage(%clientId, -1, "Both Duel Slots Taken.");
			client::sendMessage(%clientId, 1, "Please try again later.~waccess_denied.wav");
			return;
		}
		if($NoDuelSupport == "true")
		{
			Client::sendMessage(%clientId, -1, "This map is NOT supported for dueling.");
			client::sendMessage(%clientId, 1, "Please try again on another map.~waccess_denied.wav");
			return;
		}
		if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" || %clientId.observerMode == "dead")
		{
			Client::sendMessage(%clientId, -1, "You're in a Observer mode, you can not Duel.");
			client::sendMessage(%clientId, 1, "Please try again when Spawned.~waccess_denied.wav");
			return;
		}
		if(%sel && %clientId == %sel)
		{
			Client::sendMessage(%clientId, -1, "You can not Duel yourself.");
			return;
		}
		if($server::tourneymode == "true")
		{
			Client::sendMessage(%clientId, -1, "You can not Duel in Tourneymode");
			client::sendMessage(%clientId, 1, "Please try again in Normal Mode.~waccess_denied.wav");
			return;
		}
		if(%clientId.selclient.engaged == "true")
		{
			client::sendMessage(%clientId, 1, "Player has already been challenged");
			client::sendMessage(%clientId, 1, "Please try again later.~waccess_denied.wav");
			return;
		}
		if(%clientId.selclient.dueling == "true")
		{
			client::sendMessage(%clientId, 1, "Player is currently dueling.");
			client::sendMessage(%clientId, 1, "Please try again later.~waccess_denied.wav");
			return;
		}
		Game::menuRequest(%clientId);
		SBA::duelMenu(%clientId);
	}
	else if(%opt == "SBADuelstats")
	{
		Game::menuRequest(%clientId);
		%sel = %clientId.selClient;
		SBA::duelViewStats(%clientId, %sel);
	}
	else if(%opt == "SBAduelAllow")
	{
		%clientId.noDuels = "";
	}
	else if(%opt == "SBAignoreRemove")
	{
		%clientId.ignored[%clientId.selClient] = "";
	}
	 else if(%opt == "menurequest4")
	{   
		if ($Debug) echo("*** Process Observer Options ***");
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
	else if(%opt == "obssetclose1") { 	%clientId.obsmode = 0; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Close mode set as default.",3); return; }
	//========================================================================== Voting Options
	else if(%opt == "menurequest3")
	{   
		if ($Debug) echo("*** Process Voting Options ***");
//		echo("" @ Client::getName(%clientId) @ " Is Accessing Voting Menu");
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


			if(%clientId.observerMode == "observerOrbit")
				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
		}

		//=============================================================== No Client Selected 
		if (!%clientId.selClient && $curVoteTopic == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");

			if($Shifter::VoteDTD)
			{
				if($Server::TeamDamageScale == true)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}         

			if($Shifter::VoteFFA)
			{
				if($server::tourneymode == "true")
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Normal mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
			}	
		}
		return;
	}
	// Chat functions

//==========================================================
//  Secondary Menu System - Mostly Super Admin Functions
//==========================================================

	else if(%opt == "menurequest2")
	{   
		if ($Debug) echo("*** Process Admin Options ***");
///		echo("" @ Client::getName(%clientId) @ " Is Accessing Admin Menu");
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
                //Client::addMenuItem(%clientId, %curItem++ @ "Observe Close ", "obssetclose1");
				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);

				if (%sel.ismuted)
					Client::addMenuItem(%clientId, %curItem++ @ "Global UnMute " @ %name @ ".", "muteplayer " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Global Mute " @ %name @ ".", "muteplayer " @ %sel);
					
				if (%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "UnLock " @ %name @ "'s Team", "tcrights " @ %sel);
				if (!%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "Lock " @ %name @ "'s Team", "tcrights " @ %sel);			

				if ($Server::TourneyMode == "true")
				{
					if (%sel.islead)
						Client::addMenuItem(%clientId, %curItem++ @ "Revoke Leader From " @ %name, "leader " @ %sel);
					else
						Client::addMenuItem(%clientId, %curItem++ @ "Grant Leader To " @ %name, "leader " @ %sel);
				}
			}
			else
			{
                Client::addMenuItem(%clientId, %curItem++ @ "Mission Options", "mapMenu");
                //Client::addMenuItem(%clientId, %curItem++ @ "Send SS Command", "sscommand");    // next release
				if($server::tourneymode == "true")																	//============ Toggle Tourney Mode
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Change to Normal mode", "cffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");

				}
				else if(%clientId.isSuperAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Change Gameplay mode", "ctourney");
			}
		}
		
		//=========================================================== Client Is Admin & Super
		if(%clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

                Client::addMenuItem(%clientId, %curItem++ @ "Terminate " @ %name, "kbk " @ %sel);
                Client::addMenuItem(%clientId, %curItem++ @ "Manage " @ %name, "manage " @ %sel);

			}
			//============================================================ With No Client			
			else
			{

        
				Client::addMenuItem(%clientId, %curItem++ @ "Server Configuration", "serversetup");
				Client::addMenuItem(%clientId, %curItem++ @ "Game Configuration", "gamesetup");
				 if($GameMode == "Practice" || $GameMode == "Builder")
				Client::addMenuItem(%clientId, %curItem++ @ "Equipment Options", "EquiptTeam");    // equip opts    
			}
    		 }
		//============================================== Client Is Admin But NOT Super Admin

		//if(%clientId.isAdmin && %clientId.isSuperAdmin && %clientId.isGod)
		//{
			//if(%clientId.selClient)
			//{
				//%sel = %clientId.selClient;
				//%name = Client::getName(%sel);                 // i think emmo wanted to add somthing..takeing it out
				//%armor = Player::getArmor(%sel);
			//}
		//}
		return;
	}
	else if (%clientid.isadmin && %opt == "cyclemissions")
	{
		remoteCycleMission(%clientId);
	}
		else if(%opt == "mapMenu" && %clientId.isadmin)
	{
		MissMenu(%clientId,true);
		return;
	}
 else if (%opt == "serversetup")
 {
 %curItem = 0;
 Client::buildText(%clientId, "Server Setup:", "ServerConfig", true);
 if(%clientId.isSuperAdmin)
 Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "ResetServerDefaults");
 if($Server::Password == "")
 Client::addMenuItem(%clientId, %curItem++ @ "Enable Password", "EnablePassword");
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Disable Password", "DisabledPassword");
 if(%clientId.isSuperAdmin){
 Client::addMenuItem(%clientId, %curItem++ @ "Deploying Options", "DeployOptions"); 
 Client::addMenuItem(%clientId, %curItem++ @ "Damage Options", "DamageOptions");}			 
 return;
}
else if (%opt == "gamesetup")
 {
 %curItem = 0;
 Client::buildText(%clientId, "Game Setup:", "GameConfig", true);
 Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ChangeTimeLimit");
 Client::addMenuItem(%clientId, %curItem++ @ "Scoring Options", "ScoringOptionsMenu");
  Client::addMenuItem(%clientId, %curItem++ @ "Item Options", "ItemsOptionsMenu");
  Client::addMenuItem(%clientId, %curItem++ @ "Return Flag", "ReturnTheFlags");
  if($Shifter::FairTeams =="false")   
  Client::addMenuItem(%clientId, %curItem++ @ "Make Teams fair", "fairteams");  
  else 
  Client::addMenuItem(%clientId, %curItem++ @ "Uneven the Teams", "fairteams");     
 }

 else if (%opt == "manage" && %clientId.selClient)
 {
 %sel = %clientId.selClient;
 %curItem = 0;
 Client::buildText(%clientId, "Manage Player:", "options", true);
 //Client::addMenuItem(%clientId, %curItem++ @ "Shoot Fireworks", "fworks" @ %sel);
 if(%clientId.selClient)
 {
	%sel = %clientId.selClient;
	%name = Client::getName(%sel);
	%armor = Player::getArmor(%sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Admining Options", "adminopts");
  Client::addMenuItem(%clientId, %curItem++ @ "Punishment Options", "Punish");
 if (%sel.noban)
 Client::addMenuItem(%clientId, %curItem++ @ "Revoke No Ban " @ %name, "fnoban " @ %sel);
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Grant No Ban " @ %name, "fnoban " @ %sel);

  }


 return;
}
else if (%opt == "Punish" && %clientId.selClient)
 {
 %sel = %clientId.selClient;
 %name = Client::getName(%sel);
 %armor = Player::getArmor(%sel);
 %curItem = 0;
 Client::buildText(%clientId, "Torture Player:", "options", true);
   Client::addMenuItem(%clientId, %curItem++ @ "Respawn Player", "respawn " @%sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Throw Player", "bounce " @ %sel);
 Client::addMenuItem(%clientId, %curItem++ @ "Strip Player", "strip " @ %sel);
 		if(%sel.dan) 
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Accessing PDA", "undan " @ %sel); 
		else if(!%sel.dan && %sel != %clientId) 
			Client::addMenuItem(%clientId, %curItem++ @ "Force PDA", "dan " @ %sel); 
			if(%sel.possessed == true)
			Client::addMenuItem(%clientId, %curItem++ @ "Stop Possessing", "unposs " @ %sel);
			else{
			if(%sel != %clientId)
			Client::addMenuItem(%clientId, %curItem++ @ "Possess Player", "poss " @ %sel);
			}
			
			 if (%armor != parmor)
 Client::addMenuItem(%clientId, %curItem++ @ "Give " @ %name @ " the Penis Curse", "peniscurse " @ %sel); //== Penis Curse
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ "'s Penis Curse", "peniscurse " @ %sel); //== Penis Curse
 }
//==============================================================================
// Begin Equiptment Options - Killa, props to plen for ideas.
//==============================================================================
else if (%opt == "EquiptTeam")
     {
     %curItem = 0;
       Client::buildText(%clientId, "Which Team?:", "EquiptOpts", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "My Team", "MyTeam");
  		Client::addMenuItem(%clientId, %curItem++ @ "Other Team", "OtherTeam");
       return;
}
     
//==============================================================================
// End New Menu Admin Options
//==============================================================================

	else if (%opt == "sk")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Shifter 2K5 Info", "Shifter2K5Tabmenu", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Team", "Shifter2K5Team");
		Client::addMenuItem(%clientId, %curItem++ @ "Updates", "LastestUpdates");
		Client::addMenuItem(%clientId, %curItem++ @ "Download", "DownloadShifter2K5");
		Client::addMenuItem(%clientId, %curItem++ @ "Help", "Shifter2K5Help");
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
if (%opt == "playerfuncs") 
{
		%curItem = 0;
		Client::buildMenu(%clientId, "Player Functions", "PlayerFuncs", true);
		if(%clientId.selClient)
		{
		     %sel = %clientId.selClient;
		     %name = Client::getName(%sel);
			if(%clientId.speakto != %sel)
			  Client::addMenuItem(%clientId, %curItem++ @ "Speak To "@%name@"...", "speak " @ %sel);
			else
			  Client::addMenuItem(%clientId, %curItem++ @ "Stop Speaking to "@%name@"...", "nospeak " @ %sel);
			if(%clientId.muted[%sel])
			  Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
			  Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);	
		}
		else
		{
		    Client::addMenuItem(%clientId, %curItem++ @ "Mute Functions", "menurequest5");
		    Client::addMenuItem(%clientId, %curItem++ @ "Locate Flag", "locate");
			if ($Shifter::Weapons && !%clientId.selClient)
			  Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
			  Client::addMenuItem(%clientId, %curItem++ @ "Spawn Options", "spawn_options");
			if ($Shifter::SaveOn && !%clientId.selClient)
			  Client::addMenuItem(%clientId, %curItem++ @ "Save Player Info", "saveinfo");
		}
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
		if(!$matchStarted || $Server::TourneyMode == "false")
		{
			Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
			Client::addMenuItem(%clientId, "0Observer", -2);
			Client::addMenuItem(%clientId, "1Automatic", -1);
		}
			if($Shifter::FairTeams == "false")
			{
				%i = checkTeams();
				Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
			}
      return;
   }
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
   else if(%clientid.isadmin && %opt == "cffa")
   {
		Admin::setModeFFA(%clientId);
   	return;
   }
   else if(%clientid.isadmin && %opt == "ctourney")
   {
      Client::buildMenu(%clientId, "Gameplay Modes:", "faffirm", true);
      Client::addMenuItem(%clientId, "mMatch", "new");
      //Client::addMenuItem(%clientId, "2Continue Saved Match", "old");
      Client::addMenuItem(%clientId, "sScrimmage", "scrim");
      Client::addMenuItem(%clientId, "xMixed Scrim", "mixscrim");
      Client::addMenuItem(%clientId, "pPractice", "practice");
      Client::addMenuItem(%clientId, "bBuilder", "builder");
      return;
   }
   else if(%opt == "voteYes" && %cl == $curVoteCount) //=================================================== Yes
   {
      %clientId.vote = "yes";
      bottomprint(%clientId, "<jc><f1>You voted<f2>YES!", 4);
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount) //==================================================== No
   {
      %clientId.vote = "no";
      bottomprint(%clientId, "<jc><f1>You voted<f2>NO!", 4);
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
       else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "drop") //============================================================ Ban Player
   {
      Client::buildMenu(%clientId, "Confirm Drop:", "dropaffirm", true);
      Client::addMenuItem(%clientId, "1Drop " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't Drop " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
     else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "kill") //===================================================== Admin Kill Player
   {
		Client::buildMenu(%clientId, "Kill Options:", "options", true);
		%name = Client::getName(%cl);%sel = %cl;
		Client::addMenuItem(%clientId, %curItem++ @ "Explode " @ %name, "killexplode " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Sniper Kill " @ %name, "killsniper " @ %sel);
		return;
   }
   else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "killexplode") //===================================================== Admin Kill Player
   {
		Player::setArmor(%cl,larmor);
		armorChange(%cl);
		Player::blowUp(%cl);
		remoteKill(%cl);
		messageAll(0, Client::getName(%cl) @ " spontaneously combusted.");
		return; 
   }
      else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "killsniper") //===================================================== Admin Kill Player
   {
   	if(%cl.observerMode == "observerOrbit" || %cl.observerMode == "observerFly" || %cl.observerMode == "dead")
   	return;
		GameBase::playSound(%cl, ricochet1, 0);
		%curDie = radnomItems(3, $PlayerAnim::DieHead, $PlayerAnim::DieBack,$PlayerAnim::DieForward);
		Player::setAnimation(%this, %curDie);
		playNextAnim(%cl);
		Player::kill(%cl);
		%Snipe1 = Client::getName(%cl)@" stood still to long for "@Client::getName(%clientid);
		%Snipe2 =Client::getName(%clientid)@" rips "@Client::getName(%cl)@" a new one..";
		%Snipe3 =Client::getName(%cl)@" gets sniped by "@Client::getName(%clientid);
		%Snipe4 =Client::getName(%clientid)@" caps "@Client::getName(%cl)@" with a sniper round.";
		%curMess = radnomItems(4, %Snipe1,%Snipe2,%Snipe3,%Snipe4);
		//messageAll(0, Client::getName(%clientid) @ " put a bullet through "@ Client::getName(%cl)@"'s ear");
		messageAll(0, %curMess);
		return;
   }
   // shifter v2g added killa. all manage options are below
   else if(%opt == "respawn")
   {

        %sel = %clientId.selClient;
	%name = Client::getName(%sel);
        Player::blowUp(%sel);
        remoteKill(%sel);
      	messageAll(0, Client::getName(%clientId) @ " respawned " @ %name);
  		schedule("Game::playerSpawn("@%sel@", "@true@");",$Shifter::SuicideTimer+0.5);
  		//Game::playerSpawn(%sel, true);
		return;
   }

   else if(%opt == "bounce")
	{

    %sel = %clientId.selClient;
    %name = Client::getName(%sel);
	%rotZ = getWord(GameBase::getRotation(%sel),2);
	GameBase::setRotation(%sel, "0 0 " @ %rotZ);
	%forceDir = Vector::getFromRot(GameBase::getRotation(%sel),2000,1000);
	Player::applyImpulse(%sel,%forceDir);

		centerprint(%sel, "<jc><f3>"@Client::getName(%clientId)@"<f2> throws you like a golf ball.", 5);
		MessageAllExcept(%sel,1, Client::getName(%clientId) @ " throws " @ %name @ ", and hes outta site!!");

    }
	else if(%opt == "strip") 
	{
		%sel = %clientId.selClient;
		Player::dropItem(%sel,Flag);
		if(%sel.observerMode == "" || %sel.observerMode == "pregame") {
			%numweapon = Player::getItemClassCount(%sel,"Weapon");
			%max = getNumItems(); 
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				%count = Player::getItemCount(%sel,%item); 
				if(%count) {
					Player::setItemCount(%sel,%item,0); 
				}
			}
		}
		Player::setDamageFlash(%sel,1); 
		echo(Client::getName(%sel) @ " has been stripped by " @ Client::getName(%clientId));
		MessageAllExcept(%sel , 0, Client::getName(%sel) @ " has been stripped by " @ Client::getName(%clientId) @ "."); 
		Client::sendMessage(%sel ,1,"You've been stripped by " @ Client::getName(%clientId)@"!"); 
	}
	else if(%opt == "dan") {
		%sel = %clientId.selClient;
		%sel.dan = true; 
		if(!String::ICompare(Client::getGender(%clientId), "Male")) {
			MessageAllExcept(%sel, 0, Client::getName(%sel) @ " has been forced to access his PDA by " @ Client::getName(%clientId) @ ".~wmale3.wtaunt3.wav"); 
			Client::sendMessage(%sel, 1,"You've been forced to access your PDA by " @ Client::getName(%clientId) @ "!~wmale3.wtaunt3.wav"); 
		} else { 
			MessageAllExcept(%sel, 0, Client::getName(%sel) @ " has been forced to access her PDA by " @ Client::getName(%clientId) @ ".~wfemale4.wtaunt3.wav"); 
			Client::sendMessage(%sel, 1,"You've been forced to access your PDA by " @ Client::getName(%clientId) @ "!~wfemale4.wtaunt3.wav"); 
		}
		echo(Client::getName(%sel) @ " has been forced to access their PDA by " @ Client::getName(%clientId));
		doneposs(%sel);
		Player::dropItem(%sel,Flag);
		if(%sel.observerMode == "" || %sel.observerMode == "pregame") {
			%numweapon = Player::getItemClassCount(%sel,"Weapon");
			%max = getNumItems(); 
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				%count = Player::getItemCount(%sel,%item); 
				if(%count) {
					Player::setItemCount(%sel,%item,0); 
				}
			}
		}
		Player::setDamageFlash(%sel,1); 
        Client::setControlObject(%sel, Client::getObserverCamera(%sel));
        Observer::setOrbitObject(%sel, Client::getOwnedObject(%sel), 3, 3, 3);
	%sel.safet = true;
	}
	else if(%opt == "undan") {
		%sel = %clientId.selClient;
		%sel.dan = false; 
		MessageAllExcept(%sel, 0, Client::getName(%clientId) @ " has allowed " @ Client::getName(%sel) @ " to stop accessing their PDA."); 
		Client::sendMessage(%sel, 1, Client::getName(%clientId) @ " has allowed you to stop accessing your PDA."); 	
		doneposs(%sel);
		Client::setControlObject(%sel, Client::getOwnedObject(%sel));
		%sel.safet = false;
	}
	else if(%opt == "poss") {
		%sel = %clientId.selClient;
		if(Client::getControlObject(%sel) != Client::getOwnedObject(%sel)) {
			Client::sendMessage(%clientId,1,"Unable to gain Meld - Player currently is not in control of themselves~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
			if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to gain Meld - You have to be in control of yourself~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
		if(Client::getControlObject(%clientId) != Client::getOwnedObject(%clientId) && !Observer::isObserver(%clientId)) {
			Client::sendMessage(%clientId,1,"Unable to Meld - You are currently not controlling your player~waccess_denied.wav"); 	
			Game::menuRequest(%clientId); 
			return;
		}	
        Client::setControlObject(%sel, Client::getObserverCamera(%sel));
        Observer::setOrbitObject(%sel, Client::getOwnedObject(%sel), 3, 3, 3);
        %sel.obsmode = 2;
        Observer::setTargetClient(%sel, %clientId);
		Client::setControlObject(%clientId, %sel);
		%sel.possessed = true;
		%sel.possby = %clientId;
		%clientId.poss = %sel;
		%clientId.possessing = true;
		echo(Client::getName(%sel) @ " is being Mind Melded by " @ Client::getName(%clientId));
		MessageAllExcept(%sel , 0, Client::getName(%sel) @ " has been possessed by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%sel ,1,"You're being Mind Melded by " @ Client::getName(%clientId)@"!~wteleport2.wav");
		%time = 30;
		Client::sendMessage(%clientId ,1,"You have "@%time@" Seconds left before Possessing is over.~wteleport2.wav");
		Client::sendMessage(%sel,1,"You have "@%time@" Seconds left before Possessing is over.~wteleport2.wav");  
		possessedtime(%clientId,%sel,%time); 	
	} 
	else if(%opt == "unposs") {
		%sel = %clientId.selClient;
		Client::setControlObject(%clientId, %clientId);
       		Client::setControlObject(%sel, %sel);
		%sel.possessed = false;
		%sel.possby = "";
		%clientId.possessing = false;
		%clientId.poss = "";
		MessageAllExcept(%sel, 0, Client::getName(%sel) @ " has been released of his Mind Meld by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%sel ,1,"You have been freed of your Mind Meld by " @ Client::getName(%clientId)@".~wteleport2.wav"); 	
	}

   else if(%clientid.isadmin && %opt == "leader")
   {
		%name = Client::getName(%cl);
		%aname = Client::getName(%clientId);
		if (%cl.islead)
  		{
			%cl.islead = 0;
			echo("" @ %aname @ " revoked " @ %name @ "'s LeaderShip Status");
			BottomPrint(%cl,"<F1><jc>Your LeaderShip Status Has Been Revoked!",5);
	  	}
	  	else
  		{
			%cl.islead = 1;
			echo("" @ %aname @ " granted " @ %name @ " LeaderShip Status");
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
			echo("" @ %aname @ " revoked " @ %name @ "'s No Ban Status");
			BottomPrint(%cl,"<F1><jc>Your No Ban Status Has Been Revoked!",5);
	  	}
		else
		{
			%cl.noban = 1;
   			BottomPrint(%cl,"<F1><jc>You Have Been Granted No Ban Status!",5);
  		}   
   }
   else if(%clientid.isSuperAdmin && %clientid.isadmin && %opt == "kbk") //===================================================== Kill Ban Kick Menu
   {
		Client::buildMenu(%clientId, "Kill Ban Drop Kick:", "options", true);
		%name = Client::getName(%cl);%sel = %cl;
		Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Drop " @ %name, "drop " @ %sel);
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
			// checkMaxDrop(%cl,parmor); server was giving bad call...removed.
			 armorChange(%cl);
			 Player::setItemCount(%cl, $ArmorName[%armor], 0);
			 
			 messageAll(0, Client::getName(%cl) @ " was given a penis for being one by " @ Client::getName(%clientId) @ ".");
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
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   else if(%opt == "adminopts")
  {
  %sel = %clientId.selClient;
  %name = Client::getName(%sel);
  %curItem = 0;
  Client::buildText(%clientId, "Admining Options: ", "options", true);
  if (%sel.isAdmin)
 Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin " @ %name, "deadmin " @ %sel);
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
 if (%sel.isSuperAdmin)
 Client::addMenuItem(%clientId, %curItem++ @ "De Super Admin " @ %name, "dsuperadmin " @ %sel);
 else
 Client::addMenuItem(%clientId, %curItem++ @ "Super Admin " @ %name, "superadmin " @ %sel);
 return;
 }
      else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "superadmin") //========================================================== Admin
   {
      %sel = %clientId.selClient;
	  %name = Client::getName(%sel);
      Client::buildMenu(%clientId, "Confirm admim:", "saaffirm", true);
      Client::addMenuItem(%clientId, "1Super Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%clientid.isSuperadmin && %clientid.isadmin && %opt == "dsuperadmin") //========================================================== Admin
   {
      %sel = %clientId.selClient;
	  %name = Client::getName(%sel);
      Client::buildMenu(%clientId, "Confirm admim:", "dsaaffirm", true);
      Client::addMenuItem(%clientId, "1DeSuper Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't deadmin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }


//   Game::menuRequest(%clientId);  seems like i need this done..dunno

}

//====================================================================================================== Varrious Menu Process



function processMenuKAffirm(%clientId, %opt)
{
	echo("" @ Client::getName(getWord(%opt, 1)) @ " Kicked By " @ Client::getName(%clientId));

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
		echo("" @ Client::getName(getWord(%opt, 1)) @ " Banned By " @ Client::getName(%clientId));
	   if(getWord(%opt, 0) == "yes")
			Admin::kick(%clientId, getWord(%opt, 1), true);
		Game::menuRequest(%clientId);
	}
}
function processMenuDropAffirm(%clientId, %opt)
{

	if(getWord(%opt, 0) == "yes")
	{
		Admin::drop(%clientId, getWord(%opt, 1));
	}
	Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
 	 echo("" @ Client::getName(getWord(%opt, 1)) @ " Admined By " @ Client::getName(%clientId));
         
      }
   }
   Game::menuRequest(%clientId);
}
function processMenuSAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         %cl.isSuperAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an Super admin.");
 	 echo("" @ Client::getName(getWord(%opt, 1)) @ " Admined By " @ Client::getName(%clientId));

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
			%cl.isSuperAdmin = false;
			messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s admin ability.");
			echo("" @ Client::getName(getWord(%opt, 1)) @ " Admined Revoked By " @ Client::getName(%clientId));
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


function processMenuFAffirm(%clientId, %opt)
{
   if(%opt == "new" && %clientId.isAdmin)
   {
		echo(" Server set to Tournament Mode By " @ Client::getName(%clientId));
		$GameMode = Match;
		%clientid.gettag0 = 1;
		%clientid.getpass = 0;
		$DPSAllowedChanged = 0.15;
    		exec("itemfuncs.cs");
		%clientid.gettag1 = 0;
		%clientid.getglobal = 0;
		$matchtrack::global = "False";
		Client::sendMessage(%clientId, 1, "Please Enter Clan Tag #1");
		$Server::TeamDamageScale = true;
         	$ModList = "Shifter| 2K5 |Match";
   }
	else if(%opt == "old" && %clientId.isAdmin)
   {
		echo(" Server set to Tournament Mode By " @ Client::getName(%clientId));
		BottomPrintAll("<F1><jc>::::Cease Fire enabled For THIS Mission::::",5);
		messageAll(1, "CeaseFire Mode enabled by "@ Client::getName(%clientid) @".");
		%clientid.getpass = 0;
		%clientid.gettag1 = 0;
		%clientid.gettag0 = 0;
		$DPSAllowedChanged = 0.15;
      		exec("itemfuncs.cs");
		%clientid.getglobal = 0;
		$server::tourneymode = true;
		$ceasefire = true;
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Flag::ManualReturn = "True";
		$Shifter::FlagReturnTime = "400";
		exec("matchtrack.cs");
		$Shifter::GlobalTChat = $matchtrack::global;
		$Shifter::tag0 = $matchtrack::tag0;
		$Shifter::tag1 = $matchtrack::tag1;
		$Server::HostName = $matchtrack::name;
		$server::password = $matchtrack::pass;
		messageAll(1, "password = "@ $server::password @"");
		messageAll(1, "Vote to Change Mission to Begin Match!~wteleport2.wav");
		SortTeams();
		CheckStayBase();
  //$ModList = "Shifter|SvdMatch";
   }
	else if(%opt == "mixscrim" && %clientId.isAdmin)
   {

		%clientid.getpass = true;
		$GameMode = MixScrim;
		$ceasefire = "true";
		$Shifter::tag0 = "";
		$Shifter::tag1 = "";
		$DPSAllowedChanged = 0.15;
     		exec("itemfuncs.cs");
		$matchtrack::global = "False";
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Flag::ManualReturn = "True";
		$Shifter::FlagReturnTime = "400";
		Client::sendMessage(%clientId, 1, "Please Enter Server Password");
  $ModList = "Shifter| 2K5 |MixScrim";
}

else if(%opt == "scrim" && %clientId.isAdmin)
   {

		%clientid.getpass = true;
		$GameMode = Scrimmage;
		$DPSAllowedChanged = 0.15;
     		exec("itemfuncs.cs");
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Flag::ManualReturn = "True";
		$Shifter::FlagReturnTime = "400";
		Client::sendMessage(%clientId, 1, "Please Enter Server Password");
  $ModList = "Shifter| 2K5 |Scrim";
}
	else if(%opt == "practice" && %clientId.isAdmin)
   {

		%clientid.getpass = true;
		$GameMode = Practice;
		$DPSAllowedChanged = 0.15;
     		exec("itemfuncs.cs");
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Flag::ManualReturn = "True";
		$Shifter::FlagReturnTime = "400";
		Client::sendMessage(%clientId, 1, "Please Enter Server Password");
  $ModList = "Shifter| 2K5 |Practice";
	}
	else if(%opt == "builder" && %clientId.isAdmin)
   {

		$GameMode = Builder;
		$ceasefire = "true";
		$server::tourneymode = true;
		$Shifter::tag0 = "";
		$Shifter::tag1 = "";
		$Shifter::PlayerDamage = false;
		$matchtrack::global = "false";
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Flag::ManualReturn = "True";
		$Shifter::FlagReturnTime = "400";
		messageAll(0, "You now have Full Access to Inventory Station, Press i, and Set your Faves!");
		messageAll(2, "Builder mode - GO BUILD STUFF~wteleport2.wav");
  $ModList = "Shifter| 2K5 |Builder";
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
	 	echo(" Server set to match configuration By " @ Client::getName(%clientId));
	 	messageAll(0, Client::getName(%clientId) @ " set the server to match settings.");
		$noFakeDeath = true;
     		exec("matchConfig.cs");
		$server::tourneymode = false;
		$ceasefire = false;
		$GameMode = Normal;
		if ($Shifter::DetPackLimit == ""){ $Shifter::DetPackLimit = "15"; }
		if ($Shifter::NukeLimit == ""){ $Shifter::NukeLimit = "15"; }
		$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
		$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;
		$Server::Info = $Server::Info @ "\nRunning Shifter 2K5 " @ $Shifter::Version;
		if($dedicated)
		if(!$noTabChange) $ModList = "Shifter| 2K5 |SBA";
		$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter 2K5 " @ $Shifter::Version;
		$match::ceaseFireBegin = true;
		Server::storeData();
		echo(" Match config stored");
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
 // plen if you read this...then your scared..dont worry man
 // props to plen.
function OffensiveSniping()     // on yea plen...dosent this look a little like shifter cease fire :O
{
	if(!$matchstarted || !$Shifter::Osniping)
		return;
		if($Shifter::OSniping) // Allows admins to disable the offensive sniping through the menu/ killa/ and turns it off or on before the match
		{

			%wheretheflagbe[0]	= ($teamFlag[0]).originalPosition;
			%wheretheflagbe[1] = ($teamFlag[1]).originalPosition;

			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				%player = Client::getOwnedObject(%cl);
				if(Player::getItemCount(%cl,"LaserRifle") == 1 || Player::getItemCount(%cl,"SniperRifle") == 1)
				{
					%ppos = GameBase::getPosition(%cl);
					%team = GameBase::getTeam(%cl);
					%howfarpersonbe = Vector::getDistance(%ppos, %wheretheflagbe[%team]);
					if(%howfarpersonbe > 150)
					{
                        player::BlowUp(%cl);
      					remoteKill(%cl);  // killa
						schedule("centerprint(" @ %cl @ ", \"<jc><f2>**<f1>**<f3>** <f2>Offensive sniping is prohibited <f3>**<f1>**<f2>**\", 5);", 5);
					}
				}
			}
		}
		schedule("OffensiveSniping();", 3); // runs it over and over again
}

function beginMatchMode()
{
	$noFakeDeath = true;
	exec("matchConfig.cs");
	$server::tourneymode = false;
	$ceasefire = false;
	$GameMode = Normal;
   	if ($Shifter::DetPackLimit == ""){ $Shifter::DetPackLimit = "15"; }
		if ($Shifter::NukeLimit == ""){ $Shifter::NukeLimit = "15"; }
		$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
		$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;
		$Server::Info = $Server::Info @ "\nRunning Shifter 2K5 " @ $Shifter::Version;
		if(!$noTabChange) $ModList = "Shifter 2K5 " @ $Shifter::Version;
		$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter 2K5 " @ $Shifter::Version;
	  	 Server::storeData();
      	 echo(" Match config enabled");
      	 Server::refreshData();
}

function possessedtime(%clientId,%sel,%time)
{
	if(%time >= "1")
	{
	%time--;
	schedule("possessedtime("@%clientId@","@%sel@","@%time@");",1.0);
	}
		if(%time == "10" || %time <= "5" && %time != "0")
		Client::sendMessage(%clientId ,1,"You have "@%time@" Seconds left before Possessing is over.~wteleport2.wav"); 
		Client::sendMessage(%sel,1,"You have "@%time@" Seconds left before Possessing is over.~wteleport2.wav"); 
		if(%time <= "0")
		{
		%time = 30;
		Client::setControlObject(%clientId, %clientId);
       		Client::setControlObject(%sel, %sel);
		%sel.possessed = false;
		%sel.possby = "";
		%clientId.possessing = false;
		%clientId.poss = "";
		MessageAllExcept(%sel, 0, Client::getName(%sel) @ " has been released of his Mind Meld by " @ Client::getName(%clientId) @ ".~wteleport2.wav"); 
		Client::sendMessage(%sel ,1,"You have been freed of your Mind Meld by " @ Client::getName(%clientId)@".~wteleport2.wav"); 
		}
}	
function ChangeVariabletoItsOpposite(%VariableName, %DefiningVariable, %AdminsName, %Msg)
{
if(%DefiningVariable == "true")
	%OppositeofVariable = false;
else
	%OppositeofVariable = true;
eval(%VariableName @" = "@ %OppositeofVariable @";");
messageAll(1, %AdminsName@" "@%Msg);
}