$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	%player = Client::getOwnedObject(%clientId);
	%name = Client::getName(%clientId);
	%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

	if(%clientid.gettag0)
	{
		$matchtrack::tag0 = escapeString(%message);
		if(escapeString(%message) != "")
			$server::teamname0 = escapeString(%message);
		%clientid.gettag0 = 0;
		%clientid.getpass = 0;
		%clientid.gettag1 = 1;
		%clientid.getbuild = 0;
		Client::sendMessage(%clientId, 1, "Please Enter Clan Tag #2");
		return;
	}
	else if(%clientid.gettag1)
	{
		$matchtrack::tag1 = escapeString(%message);
		if(escapeString(%message) != "")
			$server::teamname1 = escapeString(%message);
		%clientid.gettag1 = 0;
		%clientid.gettag0 = 0;
		%clientid.getglobal = 0;
		%clientid.getpass = 1;
		%clientid.getbuild = 0;
		Client::sendMessage(%clientId, 1, "Please Enter Server Password");
		return;
	}
	else if(%clientid.getpass)
	{
		$server::password = escapeString(%message);
		$matchtrack::pass = escapeString(%message);
		%clientid.getpass = 0;
		%clientid.gettag1 = 0;
		%clientid.gettag0 = 0;
		%clientid.getglobal = 0;
		$server::tourneymode = true;
		$Shifter::GlobalTChat = $matchtrack::global;
		$Shifter::DetPackLimit = 15;
		$Shifter::NukeLimit = 15;
		$Shifter::FlagNoReturn = "True";
		$Shifter::FlagReturnTime = "400";
		$Server::timeLimit = %time;
		if(!$Server::timeLimit)
			$Server::timeLimit = 45;
		if($builder != "scrim")
		{
			BottomPrintAll("<F1><jc>::::Cease Fire enabled For THIS Mission::::",5);
			messageAll(1, "Vote to Change Mission to Begin Match!~wteleport2.wav");
			messageAll(0, "CeaseFire Mode enabled by "@ Client::getName(%clientid) @".");
			messageAll(1, "password = "@ $server::password @"");
			messageteam(1, "Note to Refs: Flag Return Manual, Nuke/Det 15/15", -1);
			$ceasefire = true;
			NewMT();
			$shifter::tag0 = $matchtrack::tag0;
			$shifter::tag1 = $matchtrack::tag1;
			SortTeams();
			if(!$builder) CheckStayBase();
		}
		else
		{
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				processMenuPickTeam(%cl, -2, %cl);
			BottomPrintAll("<F1><jc>::::MIXED SCRIM::::",5);
			messageAll(0, "Mixed Scrim Mode enabled by "@ Client::getName(%clientid) @".");
			messageAll(1, "password = "@ $server::password @"");
			messageAll(1, "Vote for leaders to pick teams!~wteleport2.wav");
			$ceasefire = true;
			NewMT();
			$shifter::tag0 = "";
			$shifter::tag1 = "";
			CheckStayBase();
		}
		return;
	}

	//Mute Kpack, good idea gonzo
	if($server::tourneymode && %team == 0 && string::findsubstr(%msg, "#") != -1)
		%team = 1;

   if($Shifter::noSwearing)
   	CheckBadWords(%clientId,%message);

	if (%clientId.ismuted && !%team)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0.01);
		return;
	}

	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team || $ceasefire))
	{
		%time = getIntegerTime(true) >> 5;

		if(%clientId.floodMute)
		{
			%delta = %clientId.muteDoneTime - %time;
			if(%delta > 0)
			{
				Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
				return;
			}
			%clientId.floodMute = "";
			%clientId.muteDoneTime = "";
		}
		%clientId.floodMessageCount++;

		schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);

		if(%clientId.floodMessageCount > 4)
		{
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			return;
		}
	}

	if(%team)
	{
		if($dedicated) echo("SAYTEAM: " @ %msg);
		%team = Client::getTeam(%clientId);
	
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%armor = Player::getArmor(%cl);
	
			if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
			else
				if(Player::getMountedItem(%cl, $BackpackSlot) == Laptop && (%armor == "spyarmor" || %armor == "spyfemale" ) && $ceasefire != true)
					Client::sendMessage(%cl, $MsgTypeGame, %message, %clientId);
		}
	}
	else
	{
		if($Server::TourneyMode && $Shifter::GlobalTChat != "True" && !%clientId.isadmin && !%clientId.islead)
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Only Leaders & Admins Can Speak Globally In Tourney Mode...\", 3);", 0.01);
			return;
		}

		if($dedicated)
			echo("SAY: " @ %msg);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(!%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
		}
	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if (%commander.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0.01);
		return;
	}
	//if ($Shifter::ComChat && !isnetworkdown(gamebase::getteam(%clientId)) && !ispowerdown(gamebase::getteam(%clientId)))
	//{
	//	schedule ("bottomprint( " @ %clientId @ ", \"<jc><f2>Your sensor array and power are down, TEAM ONLY Com's Do Not Function!!!\", 10);" ,0.2);
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
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0.01);
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

function remoteCStatus(%clientId, %status, %message)
{

	if(setCommandStatus(%clientId, %status, %message))
	{
		if($dedicated)
			echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
	}
	else
		remoteSay(%clientId, true, %message);
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


