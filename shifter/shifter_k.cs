function processMenuShifterKTabmenu(%clientId, %Choice)
{
	
	if (%Choice == "ShifterKTeam")
	{
		%msg = "ShifterK Modding Team\n\nenV.3zer0 // Current Modder\nName: Brian     ::     Age: 18     ::    Location: Michigan    ::    AIM: enV3zer0\n\nKiLL(-)  // Retired Modder\nName: J. Alan    ::    Age: 17     ::    Location: Tennesee    ::    AIM: theonlydmkilla";
		//%msg2 = "Gonzo The Clown   //   Contributions\nCzar   //   Contributions\nGreyFlcn   //   ShifterV1G\nEmo133   //   Shifter\nRenWerX   //   Renegades\n";
		centerprint(%clientId,%msg, 10);
		//schedule("centerprint(" @ %clientId @ ",\"Gonzo The Clown   //   Contributions\nCzar   //   Contributions\nGreyFlcn   //   ShifterV1G\nEmo133   //   Shifter\nRenWerX   //   Renegades\n\", 10);", 10);
	}
	else if (%Choice == "LastestUpdates")
	{
		%msg = "ShifterK 8-3-2003\nAdded a repetitive trigger for Sticky :: Made an option to have a custom password :: Re-did Deploy cheat detection to work better :: Re-did the Gameplay modes";
		%msg2 = "Added a LeaderAll Admin command, the command is !la :: Made it so Create and Destroy D is only aviable in Practice mode :: Males are now as fast as Females :: Support for AutowayPoint to Flags";
		//%msg3 = "Boosted up HyperBlaster a bit, Still worthless :: Decreased distance on blaster :: Added Private message system :: Added AFK message system :: Fixed EMP bug with Shocks :: Added Mute Options in Player Funcs";
		//%msg4 = "Totally re-did the Equipment options :: Able to set or destroy on a Team rather than everything";
		//%msg = "";
		centerprint(%clientId,%msg, 20);
		schedule("centerprint(" @ %clientId @ ",\"" @ %msg2@ "\", 20);", 20);
		//schedule("centerprint(" @ %clientId @ ",\"" @ %msg3@ "\", 10);", 20);
		//ShifterK 8-01-2003
		//-------------------
		//Redid builder so you could talk during it :: Jammers take 2 missiles :: Changed back to old Las cannon :: Fixed return flag :: Added menu to uneven teams :: Made shocks more straight
		//
		//ShifterK 7-29-2003
		//-------------------
		//Made Blaster go a bit farther :: Toned down Godhammer :: Fixed mortar problems :: Got rid of invincable AFK
		//
		//ShifterK 7-25-2003
		//-------------------
		//Re-Organized Admin Menus :: Added Possess torture Option :: Added PDA Access torture Option :: Redid the Strip torture Option to Strip everything including flag :: Added a Drop menu in Termination
		//Added a Permanent Ban variable in the serverDefaults.cs File :: Re-Did enV's Fastopts message :: Re-did Penis message :: Re-did the kick/ban function to do more :: Fixed return flag bug :: Added playerfuncs.cs
		//Boosted up HyperBlaster a bit, Still worthless :: Decreased distance on blaster :: Added Private message system :: Added AFK message system :: Fixed EMP bug with Shocks :: Added Mute Options in Player Funcs
		//Totally re-did the Equipment options :: Able to set or destroy on a Team rather than everything
		//
		//ShifterK 7-21-2003
		//-------------------
		//Weaken fast disc by half :: Chem touch now changes your arrow to green for enemies :: Assassin shockcharges hurt more, throw faster, and explode after 1.5 seconds :: Dart rifle is has slower dart, but faster reload 
		//Adds 5 deaths if they try to suicide while satcheled or poisoned :: Fixed problem with engineer mines :: announces when a dart hit someone
		//
		//ShifterK 7-20-2003
		//-------------------
		//Re-Organized Menus :: Fixed blank messages of flag returns and shocks :: Added annoucements to satchel & Duel Re-did Creation of shocks better :: Added options to mess with Itemcounts :: Added option to set deploy speed
		//"Added toggles for certain deployables :: Re-did some Admin Commands :: Added toggles for Player damage and Turret kills :: Added support for Shifter Training Maps :: Gave Osniping more range :: Fixed New Airbase problem with not be able to use vechicles";
		//"Re-configured Important variables in Shifter Default, Thus removing options for servers ever having to update Serverconfig :: Fixed Duel so you cant duel yourself :: Observers cannot Duel :: 
  		//Took away dart rifle for chem :: Boosting poison damage :: Assassin more prone to lasers :: Assassin Shock charges faster throw rate & added EMP damage & Doubled live time :: Points for taken away when poisoned :: Points given for satchels and taken
	}
	else if (%Choice == "DownloadShifterK")
	{
	%msg = "Download ShifterK\nVisit http://www.tribeshifter.com/k/ to download the lastest ShifterK";
	centerprint(%clientId,%msg, 10);

	}
	else if (%Choice == "ShifterKHelp")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "ShifterK Help", "ShifterKTabmenu", true);
		if(%clientId.isAdmin == "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Admin Commands", "AdminCommandsHelp");
		Client::addMenuItem(%clientId, %curItem++ @ "How to Duel", "DuelHelp");
		Client::addMenuItem(%clientId, %curItem++ @ "How to Spawn favs", "FavsHelp");
		Client::addMenuItem(%clientId, %curItem++ @ "How to Shoot 2 Lasers", "StimHelp");
		Client::addMenuItem(%clientId, %curItem++ @ "How to Jugg Jump", "JuggHelp");
		Client::addMenuItem(%clientId, %curItem++ @ "How Private Msg", "PMsgHelp");
		Client::addMenuItem(%clientId, %curItem++ @ "How to Use AFK", "AFKHelp");
	}
	else if (%Choice == "AdminCommandsHelp")
	{
		%msg = "!nba - Nobans All\!undonba - Un-Nobans All\n!time - Disables Time\n!la - Leader everyone\n!undola - Un-Leader everyone\n!cease - Cease fire mode\n!ceaseoff - Disables cease fire";
		%msg2= "!allobs - Puts everyone in observer  ::  !alltoteam1 - Puts everyone to team 1  ::  !alltoteam2 - Puts everyone to team 2  ::  !sortteams - sorts teams by tag";
		%msg3= "!teleport - Teleports to mouse aim  ::  !heal - Heals you   ::  !hide - Hides you   ::  !comeout - Un-Hides you";
		centerprint(%clientId,%msg, 10);
		schedule("centerprint(" @ %clientId @ ",\"" @ %msg2@ "\", 10);", 10);
		schedule("centerprint(" @ %clientId @ ",\"" @ %msg3@ "\", 10);", 20);
	}
	else if (%Choice == "DuelHelp")
	{
		%msg= "You can Challege someone to a duel by clicking on their name in the TAB Menu.";
		centerprint(%clientId,%msg, 10);
	}
	else if (%Choice == "FavsHelp")
	{
		%msg ="How to spawn with favorites without the use of an Inventory system\n\nFirst you goto Player functions - Then Spawn options - Spawn favorites";
		%msg2 ="Now that you have set favorites to spawn, Press the I button on your keyboard. This brings up the inventory mode, Select the favorite you want and press Buy favorite.";
		%msg3 ="Now just suicide and you will automaticly spawn with that favorite, without using an inventory. Make sure you have pre-defined favorites before you try it.";
		centerprint(%clientId,%msg, 15);
		schedule("centerprint(" @ %clientId @ ",\"" @ %msg2@ "\", 15);", 15);
		schedule("centerprint(" @ %clientId @ ",\"" @ %msg3@ "\", 15);", 30);
	}
	else if (%Choice == "StimHelp")
	{
		%msg ="In order to shoot a weapon twice, very quickly. You need scout armor\nOnce you are in scout, just shoot the weapon and then use your beacon soon afterwards";
		centerprint(%clientId,%msg, 15);
	}
	else if (%Choice == "JuggHelp")
	{
		%msg ="In order to Jugg Jump, First you need Juggernaught armor.\nThen all you so is shoot a mortar directly down/nShoot rocket and use pack when mortar explodes.";
		centerprint(%clientId,%msg, 15);
	}
		else if (%Choice == "AFKHelp")
	{
		%msg ="Say \"AFK\" in team chat";
		centerprint(%clientId,%msg, 5);
	}
	else if (%Choice == "PMsgHelp")
	{
	%msg ="Press TAB\nNow click on the Player you wish to send a Private Message\nNow goto Player Functions\nNow click speak to\n";
	centerprint(%clientId,%msg, 15);	
	}
}