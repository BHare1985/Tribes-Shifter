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

   if($Shifter::noSwearing)
   {
   	CheckBadWords(%clientId,%message);
	}

	if (%clientId.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0.01);
		return;
	}

	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
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
				if(Player::getMountedItem(%cl, $BackpackSlot) == Laptop && (%armor == "spyarmor" || %armor == "spyfemale" ))
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
         if(%cl.messageFilter & %filter)
            Client::sendMessage(%cl, %mtype, %message);
      }
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


