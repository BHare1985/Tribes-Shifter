// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function


//==== TribeStat Scoring.cs

function TribeStat_GetTeams()
{
	echo("//TS");
	echo("\"2\"-1\"0\"Reset\"");
	for(%i = 0; %i < getNumTeams() ; %i++)
		echo("\"2\"" @ %i @ "\"" @ $teamScore[%i] @ "\"" @ getTeamName(%i) @ "\"");
}

function TribeStat_GetPlayers()
{
	echo("//TS");
	echo("\"1\"2048\"Reset\"IP: 000.000.000.000:0000\"0\"0\"None\"");
	for(%cl = Client::getFirst(); %cl != -1; %cl=Client::getNext(%cl))
	{
		if (Client::getName(%cl) == "")
			%ClientName = "Unnamed";
		else
			%ClientName = Client::getName(%cl);

		echo("\"1\"" @ %cl @ "\"" @ escapeString(%ClientName) @ "\"" @ Client::getTransportAddress(%cl) @ "\"" @ Client::getTeam(%cl) @ "\"" @ %cl.score @ "\"" @ Client::getGender(%cl) @ "\"");
	}
}

function TribeStat_GetPreferences() 
{
	echo("//TS");
	echo("\"Q\"0\"" @
	$Server::HostName @ "\"" @
	$Server::Port @ "\"" @
	$Server::MaxPlayers @ "\"" @
	$Server::TimeLimit @ "\"" @
	$Server::WarmupTime @ "\"" @
	$Server::AutoAssignTeams @ "\"" @
	$Server::TeamDamageScale @ "\"" @
	$Server::TourneyMode @ "\"" @
	$Server::MinVotes @ "\"" @
	$Server::MinVotesPct @ "\"" @
	$Server::VoteWinMargin @ "\"" @
	$Server::VotingTime @ "\"" @
	$TribeStat::BlockADM @ "\"" @
	$TribeStat::BlockTD @ "\"" @
	$TribeStat::BlockGT @ "\"" @
	$TribeStat::BlockMIS @ "\"" @
	$Server::Password @ "\""
    );
    echo("\"Q\"1\"" @ escapeString($Server::Info) @ "\"" @ escapeString($Server::JoinMOTD) @ "\"");
}

function TribeStat_GetStatus()
{
    echo("//TS");
    echo("\"Q\"3\"" @
         $missionName @ "\"" @
         ($Server::timeLimit * 60) + $missionStartTime - getSimTime() @ "\"");
}

function TribeStat_ShowScores()
{
    %TSteamScores = "";
    for(%i = 0; %i < getNumTeams() ; %i++)
       %TSteamScores = %TSteamScores @ "\"" @ $teamScore[%i];
    echo("//TS");
    echo("\"S" @ %TSTeamScores @ "\"");
}

function TribeStat_GetMissions()
{
         echo ("//TS");
         echo ("\"3\"Reset\"Reset\"");
         for (%i = 0; %i < $MLIST::Count; %i++)
         {
	         echo ("\"3\"" @ $MLIST::EName[%i] @ "\"" @ $MLIST::EType[%i] @
		 "\"" @ $MLIST::Enabled[$MLIST::EName[%i]] @ "\"");
         }
         echo ("\"3\"Done\"Done\"");
}

//==================================================================================================== Normal Server.cs

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
	$Client::info[%clientId, 0] = %skin;
	$Client::info[%clientId, 1] = %name;
	$Client::info[%clientId, 2] = %email;
	$Client::info[%clientId, 3] = %tribe;
	$Client::info[%clientId, 4] = %url;
	$Client::info[%clientId, 5] = %info;
	
	if(%autowp)
		%clientId.autoWaypoint = true;
	
	if(%enterInv)
		%clientId.noEnterInventory = true;
	
	if(%msgMask != "")
		%clientId.messageFilter = %msgMask;
}

function Server::storeData()
{
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";
	
	$Server::LastMissionNum = (floor($TotalMissions / (getrandom()*10)));
	export("Server::*", "temp\\" @ $ServerDataFile, False);
	export("$Shifter::*", "temp\\" @ $ServerDataFile, true);
	export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
}

function Server::refreshData()
{
	exec($ServerDataFile);
	checkMasterTranslation();
	Server::loadMission($pref::lastMission, false);
}

function Server::onClientDisconnect(%clientId)																	// server.cs
{
   	%player = Client::getOwnedObject(%clientId);

	echo ("Clearing " @ Client::getName(%clientId) @ "Cached Data.");
	%name = Client::getName(%clientId);

	%clientId.TotalKills = "";
	%clientId.TotalDeaths = "";
	%clientId.TotalScore = "";
	%clientId.TotalTKCount = "";
	%clientId.TotalFlags = "";
	%clientId.scoreKills = "";
	%clientId.scoreDeaths = "";
	%clientId.ratio = "";
	%clientId.score = "";
	%clientId.FlagCaps = "";
	%clientId.TKCount = "";

	%clientId.BadWordsSpoken = "";
	%clientId.lastBuyFavTime = "";
	%clientId.driver = "";
	%clientId.vehicle = "";
	%clientId.ismuted	= "";

	%clientId.fav0 = "";
	%clientId.fav1 = "";
	%clientId.fav2 = "";
	%clientId.fav3 = "";
	%clientId.fav4 = "";
	%clientId.fav5 = "";
	%clientId.fav6 = "";
	%clientId.fav7 = "";
	%clientId.fav8 = "";
	%clientId.fav9 = "";
	%clientId.fav10 = "";
	%clientId.fav11 = "";
	%clientId.fav12 = "";
	%clientId.fav13 = "";
	%clientId.fav14 = "";
	%clientId.fav15 = "";
	%clientId.fav16 = "";
	%clientId.fav17 = "";
	%clientId.fav18 = "";
	%clientId.fav19 =	"";
	%clientId.hacking = "";
	%clientId.module = "";
	%clientId.observerMode = "";
	
	%clientId.isadmin = "";
	%clientId.isSuperAdmin = "";
	%clientId.isGod = "";
	%clientId.noban = "";

	%clientId.heatup = "";
	%clientId.heatlock = "";
	%clientId.plasmacharge = "";
	%clientId.charging = "";
	%clientId.lascharge = "";

	%clientId.spawntype = "";
	%clientId.EngMine = "";
	%clientId.Plastic = "";
	%clientId.Mortar = "";
	%clientId.Plasma = "";
	%clientId.gravbolt = "";
	%clientId.TotalKills = "";
	%clientId.TotalDeaths = "";
	%clientId.TotalScore = "";
	%playerId.TKCount = "";
	%clientId.TotalFlags = "";
	%clientId.MissionComplete = "";
	%clientId.EngBeacon = "";
	%clientId.rocket = "";
	%clientId.Laptop  = "";
	%clientId.obsmode  = "";
	%clientId.spymode  = "";
	%clientId.spawnnum = "";
	%clientId.hackattempt = "";
	%clientId.booster = "";
	%ClientId.boostercool = "";
	%ClientId.boostpop = "";
	%clientId.vote = "";

	$funk::var["[\"" @ %name @ "\", 0, 1]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 2]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 3]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 4]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 5]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 6]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 7]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 8]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 9]"] = "";  
	$funk::var["[\"" @ %name @ "\", 0, 10]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 11]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 12]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 13]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 14]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 15]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 16]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 17]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 18]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 19]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 20]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 21]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 22]"] = "";
	$funk::var["[\"" @ %name @ "\", 0, 23]"] = "";

	for(%i = 1; %i < 26; %i++)
	$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = "";
	$funk::var["[\"" @ %name @ "\", 1, " @ %i @ "]"] = "";
	purgeresources();

	echo ("Finished Clearing " @ Client::getName(%clientId) @ "Cached Data.");

	if($Shifter::LocalNetMask != "" && String::findSubStr(%clientId.addr,$Shifter::LocalNetMask) == 0)
	{
		echo ("ADMINMSG: **** Local Player DIS-Connected - DEcreasing Client Ammount");
		$Server::MaxPlayers--; 
	}
   
   	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   	{
			playNextAnim(%player);
		        Player::kill(%player);
   	}

   	Client::setControlObject(%clientId, -1);
   	Client::leaveGame(%clientId);
   	
   	echo("\"D\"" @ %clientId @ "\"");
   	
   	Game::CheckTourneyMatchStart();
   	
   	if ($Shifter::Refresh != False)
   	{
   		if(getNumClients() == 1)
   			Server::refreshData();
   	}
}

function KickDaJackal(%clientId)
{
   	KickPlayer(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function String::len(%string) 
{
    for(%length=0; String::getSubStr(%string, %length, 1) != ""; %length++)
    {} // it's all done above!
    return %length;
}

function String::greplace(%string, %search, %replace)    
{
    if(%search == %replace || String::findSubStr(%replace, %search) != -1) // prevent infinite loops
        return %string;
        
    while((%idx = String::findSubStr(%string, %search)) != -1)             
    {   
        %len = String::len(%string);
        %front = String::getSubStr(%string, 0, %idx);
        %idx += String::len(%search);
        %back = String::getSubStr(%string, %idx, %len - %idx);
        %string = %front @ %replace @ %back;
    }
    return %string; 
}

function String::replace(%string, %search, %replace)    
{
    if(%search == %replace || String::findSubStr(%replace, %search) != -1) // prevent infinite loops
        return %string;
        
    while((%idx = String::findSubStr(%string, %search)) != -1)             
    {   
        %len = String::len(%string);
        %front = String::getSubStr(%string, 0, %idx);
        %idx += String::len(%search);
        %back = String::getSubStr(%string, %idx, %len - %idx);
        %string = %front @ %replace @ %back;
    }
    return %string; 
}

function Server::onClientConnect(%clientId)																		// server.cs
{
	if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8)  &&  !$dedicated)
	{
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
      
	echo("\"C\"" @ %clientId @ "\"" @ escapeString(Client::getName(%clientId)) @ "\"" @ Client::getTransportAddress(%clientId) @ "\"" @ Client::getGender(%clientId) @ "\"");
	
	// Call Labrat's Anti-Clone flood attack code
	///clonecheck(%clientID);

	///echo ("Checking player name for ban " @ Client::getName(%clientId));
	%name = Client::getName(%clientId);

	%clientkick = 0;

	for(%i=0; %i != "25";%i++)
	{
		%checkname = $Server::NameBan[%i];
		if (%checkname != "")
		{
			if (String::findSubStr(%name,%checkname) >= 0)
			{
				schedule("KickPlayer(" @ %clientId @ ",\"You name has been banned.\");", 20, %clientId);
				%clientkick = 1;
			}
		}
	}
	if (%clientkick == 1)
	{
		echo (%name @ " Was on Perma Ban list and was kicked");
	}

	if(Client::getName(%clientId) == "DaJackal")
	{
		schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);
  	}
  	
	%addr = Client::getTransportAddress(%clientId);

	if($Shifter::LocalNetMask != "" && String::findSubStr(%addr,$Shifter::LocalNetMask) == 0)
	{
		echo ("ADMINMSG: **** Local Player Connected - Increasing Client Ammount");
		%clientId.addr = %addr;
		$Server::MaxPlayers++; 		
	}

	%clientId.noghost = true;
	%clientId.messageFilter = -1;

	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);

	//Idea used from GTC, props to Gonzo
	%ip = Client::getTransportAddress(%clientId);
	%ip = string::getsubstr(%ip, 3, (String::len(%ip) - 8) );
	%name = client::getname(%clientid);
	$IPTrak = %ip @ " - " @ %name;
	echo("IPTRACE   **** " @ $IPTrak @ " ****");
	export("$IPTrak", "config\\IPTrak_v1G.cs", true);

	if($shifter::joincustom != "")
	{
		%phrase = string::greplace($shifter::joincustom, "%name", %name);
		%phrase = string::greplace(%phrase, "%mission", $missionname);
		%phrase = string::greplace(%phrase, "%ip", %ip);
		remoteEval(%clientId, MODInfo, %phrase);
	}
	else
		remoteEval(%clientId, MODInfo, $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);

	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";

	Game::onPlayerConnected(%clientId);
}

function createServer(%mission, %dedicated)
{
	%mission = Server::NewMission(%mission);

	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
	renderCanvas(MainWindow);

	if(!%dedicated)
	{
		deleteServer();
		purgeResources();
		newServer();
		focusServer();
	}

	newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);

	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	exec(Mine);
	exec(Grenade);
	//exec(Rockets);
	exec(Bombs);
	exec(Blasts);
	exec(ArmorData);
	exec(Mission);
	exec(Item);
	
	BuildItemList(); //=== Build Items List From ArmorData.cs
	
	if ($Shifter::Guided)
	{
		exec(coolturret);
	}

	exec(ItemFuncs);
	exec(ItemMsgs);
	exec(Player);
	exec(Scoring);
	exec(Vehicle);
	exec(Turret);
	//exec(mapobjects);
	exec(Beacon);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	exec(AI);
	exec(InteriorLight);
	exec(Saveinfo);
	exec(bindings);
	exec(HoloGram);
	//exec(objTree);

	preloadServerDataBlocks();

	Server::loadMission(($missionName = %mission), true );

	if(!%dedicated)
	{
		focusClient();
		if ($IRC::DisconnectInSim == "")
		{
			$IRC::DisconnectInSim = true;
		}
		if ($IRC::DisconnectInSim == true)
		{
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}

		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	return "True";
}


function Server::newMission(%mission)
{
	//===================================== Mission Load
   	
   	$loadingMission = false;
   	$ME::Loaded = false;
	
	if ($Shifter::RandomStart)
	{
		exec ("ServerMission.cs");
		
		if ($Server::LastMissionNum == "" || !$Server::LastMissionNum)
		{
			$Server::LastMissionNum = (floor($TotalMissions * getrandom() ));
		}
		else
		{
			$Server::LastMissionNum = (floor($Server::LastMissionNum * getrandom() ));
		}	

		%rnd = $Server::LastMissionNum;
		
		for (%i = 0; %i < %rnd;%i++)
		{
			%j = (floor($TotalMissions *getrandom() ));
		}
		
		%mission = $TotalMissionList[%j];
		
		if(%mission == "")
		{
			%mission = $pref::lastMission;
			$Server::LastMissionNum = (floor($TotalMissions *getrandom() ));
		}
		
		export("$Server::LastMissionNum", "config\\ServerMission.cs", False);
	}
	else
	{
		if(%mission == "")
			%mission = $pref::lastMission;
	}

	if(%mission == "")
	{
		if ($debug) echo("Error: no mission provided.");
		return "False";
	}
//greygrey
	//if($noCrash == false)
	//{
	//	if(isFile("config\\matchtrack.cs"))	
	//		exec("matchtrack.cs");
	//	if($matchtrack::mission != "")
	//		%mission = $matchtrack::mission;
	//}

	$pref::lastMission = %mission;
	
	$Server::LastMissionNum = (%j);
	
	//export("pref::*", "config\\ClientPrefs.cs", False);
	//export("Server::*", "config\\ServerPrefs.cs", False);
	//export("$Shifter::*", "config\\ServerPrefs.cs", true);
	//export("pref::lastMission", "config\\ServerPrefs.cs", True);
	
	return %mission;
	//===================================== End Start Mission
}

function Server::nextMission(%replay)
{
	if($Shifter::RandomMissions)
	{
		%rnd = floor(getRandom() * ($TotalMissions));
		
		if ($MissionName == $TotalCTFMaps[%rnd])
		{
			%nextMission = $TotalCTFMaps[1];
			$pref::LastMission = $TotalCTFMaps[1];
		}
		else
		{
			%nextMission = $TotalCTFMaps[%rnd];
			$pref::LastMission = $TotalCTFMaps[%rnd];
		}
		
		$Server::LastMissionNum = (floor($TotalCTFMaps *getrandom() ));

		for (%i=0; %i < 10; %i++)
		{
			if (%nextmission == $pastmission[%i] && $TotalCTFMaps > 10)
			{
				Server::nextMission();
				return;
			}
		}
		if ($TotalCTFMaps > 10)
		{
			for (%i=10; %i >= 0; %i--)
			{
				if (%i == 0)
					$pastmission[0] = %nextmission;
				else
					$pastmission[%i] = $pastmission[%i - 1];
			}
		}
	}
	else
	{
		%nextMission = $nextMission[$missionName];
	}

	if (%nextMission == "")
	{
		Server::nextMission();
		return;
	}
	//****if($ceasefire == false && $server::tourneymode == true)
	//****NewMT();
	//greygrey
	//$dlist = " ";
	//if($server::tourneymode)
	//	export($dlist, "config\\dtrack.cs", true);
	export("pref::*", "config\\ClientPrefs.cs", False);
	//****export("Server::*", "config\\ServerPrefs.cs", False);
	//****export("$Shifter::*", "config\\ServerPrefs.cs", true);
	//echo("ADMINMSG: **** Changing to mission ", %nextMission, ".");
	Server::loadMission(%nextMission);
}
function remoteCycleMission(%clientId)
{
	if(%clientId.isAdmin || !%clientId)
	{
		messageAll(0, Client::getName(%clientId) @ " cycled the mission.");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ "Force Cycled TO Next Mission.");
		Server::nextMission();
	}
}

function remoteListMissions()
{
	for (%i=0;$TotalMissionList[%i] != ""; %i++)
	{
		echo ("Missions = " @ $TotalMissionList[%i]);
	}
}

function remoteDataFinished(%clientId)
{
	if(%clientId.dataFinished)
		return;
	%clientId.dataFinished = true;
	Client::setDataFinished(%clientId);
	%clientId.svNoGhost = ""; // clear the data flag
	if($ghosting)
	{
		%clientId.ghostDoneFlag = true; // allow a CGA done from this dude
		startGhosting(%clientId);  // let the ghosting begin!
	}
}

function remoteCGADone(%playerId)
{
	if(!%playerId.ghostDoneFlag || !$ghosting)
		return;
	
	%playerId.ghostDoneFlag = "";
	
	Game::initialMissionDrop(%playerid);

	if ($cdTrack != "")
		remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
	
	remoteEval(%playerId, MInfo, $missionName);
}

function Server::loadMission(%missionName, %immed)
{  
   	if($loadingMission)
   		return;

	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
			return;
	}

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
		remoteEval(%cl, missionChangeNotify, %missionName);
	}

	$loadingMission = true;
	$missionName = %missionName;
	$missionFile = %missionFile;
	$prevNumTeams = getNumTeams();

	deleteobject("MissionGroup");
	deleteobject("MissionCleanup");
	deleteobject("ConsoleScheduler");

	resetPlayerManager();
	resetGhostManagers();
	$matchStarted = false;
	$countdownStarted = false;
	$ghosting = false;

	resetSimTime(); // deal with time imprecision

	newObject(ConsoleScheduler, SimConsoleScheduler);

	if(!%immed)
		schedule("Server::finishMissionLoad();", 18);
	else
		Server::finishMissionLoad();

	$Shifter::MissionCycle = $Shifter::MissionCycle + 1;
}

function Server::finishMissionLoad()
{
   	$loadingMission = false;
	$TestMissionType = "";
   	// instant off of the manager
   	setInstantGroup(0);
   	newObject(MissionCleanup, SimGroup);

   	exec($missionFile);
	$flagchecking = false;
	if($bounds[$missionName] != "")
	{
		%xpos = getword($bounds[$missionName], 0);
		%ypos = getword($bounds[$missionName], 1);		
		%width = getword($bounds[$missionName], 2);
		%height = getword($bounds[$missionName], 3);
		$xMin = %xpos;
		$yMin = %ypos;
		$xMax = %xpos + %width;
		$yMax = %ypos + %height;
		$flagchecking = true;
	}
	$noEleCol = false;
	if	(String::findSubStr($missionName, "Broadside") != -1 || String::findSubStr($missionName, "Blastside") != -1)
	{
		//$noEleCol = true;
		function GroupTrigger::onEnter(%this, %object)
		{
		}
	}
	else if($missionName == "DusktoDawn")
	{
		//greyflcn
		function GroupTrigger::onEnter(%this, %object)
		{
			NuclearExplosion(%object);
			%object.deployer = %clientId;
			Client::sendMessage(%clientID, 0, "You tripped a mine!~wButton2.wav");
		}
	}
	
	Mission::init(); 		//-- Init for next mission
	Mission::reinitData();		//-- Init Items

   if($prevNumTeams != getNumTeams())
  	{
		// loop thru clients and setTeam to -1;
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			GameBase::setTeam(%cl, -1);
  	}

	$ghosting = true;

	echo ("Ghosting Fin Missions Load");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(!%cl.svNoGhost)
		{
			%cl.ghostDoneFlag = true;
			startGhosting(%cl);
		}
	}

	if($SinglePlayer)
		Game::startMatch();
	//else if($noCrash == false)
	//{
	//	Server::Countdown(120);
	//	deploy::init();
	//	InitMT();
	//	$noCrash = true;
	//}
	else if($Server::warmupTime && !$Server::TourneyMode)
		Server::Countdown($Server::warmupTime);
	else if(!$Server::TourneyMode)
		Game::startMatch();


	//============================= Cycle Player Teams
	if ($debug) echo ("$Shifter::TeamJuggle " @ $Shifter::TeamJuggle);
	if ($debug) echo ("$Shifter::MissionCycle " @ $Shifter::MissionCycle);
	
	if ($Shifter::TeamJuggle > 0)
	{
		echo ("ADMINMSG **** Teams Assigned Every " @ $Shifter::TeamJuggle @ " Mission(s).");
		echo ("ADMINMSG **** Mission Cycle On Mission Number " @ $Shifter::MissionCycle @ ".");
	}
	
	if ($Shifter::TeamJuggle > 0 && $Shifter::TeamJuggle < $Shifter::MissionCycle && !$Server::TourneyMode)
	{
		$Shifter::MissionCycle = 0;
		echo ("ADMINMSG **** Resetting Players Teams - Mission Reset Every " @ $Shifter::TeamJuggle @ " Mission.");
      		Game::setRandomTeam();
	}


	$teamplay = (getNumTeams() != 1);
	purgeResources(true);

	return "True";
}

function Server::Countdown(%time)
{
   $countdownStarted = true;
   schedule("Game::startMatch();", %time);
   
   Game::notifyMatchStart(%time);
   if(%time > 30)
      schedule("Game::notifyMatchStart(30);", %time - 30);
   if(%time > 15)
      schedule("Game::notifyMatchStart(15);", %time - 15);
   if(%time > 10)
      schedule("Game::notifyMatchStart(10);", %time - 10);
   if(%time > 5)
      schedule("Game::notifyMatchStart(5);", %time - 5);
}

function Client::setInventoryText(%clientId, %txt)
{
   remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
	if ($debug) echo ("CenterPrint");
	if(%timeout == "")
	%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
	if ($debug) echo ("BottomPrint");
	if(%timeout == "")
	%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
	if ($debug) echo ("TopPrint");
	if(%timeout == "")
	%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function teamcenterprint(%msg, %time, %tn)
{
   if(%time == "")
      %time = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	if (GameBase::getTeam(%clientId) == %tn)
      	remoteEval(%clientId, "CP", %msg, %time);
}

function teambottomprint(%msg, %time, %tn)
{
   if(%time == "")
      %time = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	if (GameBase::getTeam(%clientId) == %tn)
	      remoteEval(%clientId, "BP", %msg, %time);
}

function teamtopprint(%msg, %time, %tn)
{
   if(%time == "")
      %time = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	if (GameBase::getTeam(%clientId) == %tn)
	      remoteEval(%clientId, "TP", %msg, %time);
}

//==================================================================================== AutoAdmin Checking
function SHCheckTransportAddress(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	if ($debug) echo(%clientid @ " <- " @ %addr);

	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
		return;

	if(String::getSubStr(%addr,0,3) != "IP:" && String::getSubStr(%addr,0,4) != "IPX:" )
	{
		if ($debug) echo(%clientid @ " is not correct address form, kicking");
		schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			if ($debug) echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
			return;
		}
	}
}

function Shifter::Autoadmin(%clientId)
{
	%addr = Client::getTransportAddress(%clientId);
	%name = Client::getName(%clientId);
	
	if ($Server::Admin["autoa", %name])
	{
		echo ("ADMINMSG **** Checking for AutoAdmin for " @ %name);
	}
	else
	{
		echo ("ADMINMSG **** Player " @ %name @ " is not an Auto-Admin.");
		return;
	}

	if ($Server::Admin["ipadr", %name] == "")
	{
		echo ("ADMINMSG **** Player " @ %name @ " is not an Auto-Admin - Can Not Verify - No IP Listed.");
		return;
	}

	if(String::findSubStr(%addr,$Server::Admin["ipadr", %name]) == 0)
	{
		echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Checking IP Address");

		if ($Server::Admin["admin", %name])
		{
			echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Normal-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-Admined\",5);",10);
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = false;
		}
		if ($Server::Admin["super", %name])
		{
			echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " Super-Admin");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been Auto-SuperAdmined\",5);",10);
			%clientId.isAdmin = true;
			%clientId.isSuperAdmin = true;
		}
		if ($Server::Admin["noban", %name])
		{
			echo("ADMINMSG: **** No Banning : " @ %clientId @ " - " @ %name @ " - " @ %addr @ ".");
			schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have been added to the NoBan List, Dont Get Cocky!!!\",5);",8);
			%clientId.noban = 1;
		}
	}
	else
	{
		echo("ADMINMSG: **** Auto - Admining: " @ %clientId @ " - " @ %name @ " - " @ %addr @ " IP Address Did Not Match Up");
		schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You have not been admined, IP does not match.\",5);",10);
		%clientId.isAdmin = false;
		%clientId.isSuperAdmin = false;
		%clientId.noban = false;
	}
}

function CheckNoBans(%clientid)
{
	%name = Client::getName(%clientId);
	if ($Server::Admin["noban", %name] && %clientId.noban)
	{
		echo("ADMINMSG: **** No Ban List: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
		schedule ("BottomPrint( " @ %clientid @ ",\"<F1><jc>You are on the NO BAN list, Dont get cocky!!!\",5);",5);
	}
}

function KickPlayer(%clientId,%msg)
{
	%name = Client::GetName(%clientId);
	echo("ADMINMSG: **** Player " @ %name @ " is being kicked.");
	schedule ("Net::Kick(" @ %clientId @ ", \"" @ %msg @ "\");",1);
}

//===========================================================================
// Copyright (c) 2000 Harold "LabRat" Brown.  All rights reserved. 
// All duplication and modification of code included below is subject
// to the terms outlined in the readme.txt included with this file.

function clonecheck(%clientID)
{
	clonetranspcheck(%clientID);
	clonenamecheck(%clientID);
}


// Copyright (c) 2000 Harold "LabRat" Brown.  All rights reserved. 
// All duplication and modification of code included below is subject
// to the terms outlined in the readme.txt included with this file.

function clonetranspcheck(%clientID) 
{
	%transp = Client::getTransportAddress(%clientId);
	%z = getWord($connect[%transp],0);
	for(%x=1;%x <= %z; %x=%x+1)
	{
		%connect[%x] = getWord($connect[%transp],%x);
		if ((getsimtime() - %connect[%x]) <= 120)
		{
		%string = %string @ " " @ %connect[%x];
		}
	}
	%connect[%z+1] = getsimtime();
	$connect[%transp] = %z+1 @ " " @ %string @ " " @ %connect[%z+1];
//	echo($connect[%transp]);
	if((%z >= 4) && ((%connect[%z] - %connect[1]) <= 120))
	{
		BanList::add(Client::getTransportAddress(%clientId), 1800);
		KickPlayer(%clientId, "Clone attacks will not be tolerated.");
	}	
}


// Copyright (c) 2000 Harold "LabRat" Brown.  All rights reserved. 
// All duplication and modification of code included below is subject
// to the terms outlined in the readme.txt included with this file.

function clonenamecheck(%clientID) 
{
	%name = Client::getName(%clientId);
	%strIndex = String::findSubStr(%name, ".1");
	%name2 = String::getSubStr(%name, 0, %strIndex);
	%z = getWord($connect[%name],0);
	for(%x=1;%x <= %z; %x=%x+1)
	{
		%connect[%x] = getWord($connect[%name],%x);
		if ((getsimtime() - %connect[%x]) <= 120)
		{
		%string = %string @ " " @ %connect[%x];
		}
	}
	%connect[%z+1] = getsimtime();
	$connect[%name] = %z+1 @ " " @ %string @ " " @ %connect[%z+1];
//	echo($connect[%name]);
	if((%z > 4) && ((%connect[%z] - %connect[1]) <= 120))
	{
		BanList::add(Client::getTransportAddress(%clientId), 1800);
		KickPlayer(%clientId, "Clone attacks will not be tolerated.");
	}
}

