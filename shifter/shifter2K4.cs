function processMenuShifter2K4Tabmenu(%clientId, %Choice)
{
	
	if (%Choice == "Shifter2K4Team")
	{
		%clientId.GettingInfo = 1;
		Shifter2K4Team(%clientId);	
	}
	else if (%Choice == "LastestUpdates")
	{
		%clientId.weaponHelp = "";
		%clientId.GettingInfo = 1;
		Shifter2K4Updates(%clientId);			
		return;
	}
	else if (%Choice == "DownloadShifter2K4")
	{
	%msg = "Download Shifter 2K4\nVisit WE NEED A HOST to download the lastest Shifter 2K4";
	centerprint(%clientId,%msg, 10);

	}
	else if (%Choice == "Shifter2K4Help")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Shifter2K4Help", "Shifter2K4Tabmenu", true);
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
		%clientId.GettingInfo = 1;
		AdminCommands(%clientId);
	}
	else if (%Choice == "DuelHelp")
	{
		%msg= "You can Challege someone to a duel by clicking on their name in the TAB Menu.";
		centerprint(%clientId,%msg, 10);
	}
	else if (%Choice == "FavsHelp")
	{
		%clientId.GettingInfo = 1;
		FavsHelp(%clientId);
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
		%msg ="Say \"AFK\"";
		centerprint(%clientId,%msg, 5);
	}
	else if (%Choice == "PMsgHelp")
	{
	%msg ="Press TAB\nNow click on the Player you wish to send a Private Message\nNow goto Player Functions\nNow click speak to\n";
	centerprint(%clientId,%msg, 15);	
}
}

function Shifter2K4Updates(%client)
{
// <jc> = center justified, 
// <f1> = tan font, 
// <f2> = white font, 
// <f3> = orange font, \n = new line)
	
	$GettingInfoMax = 15;
	%client.GettingInfoType = updates;
	if(%client.GettingInfo == 1)
		centerprint(%client,"<jc><f1>Welcome to <f2>Shifter 2K4 "@$Shifter::Version@"\n<f1>This Menu will list the most lasted updates of the mod.\n<f1>You can view this message again through the TAB menu.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 2)
		centerprint(%client,"<jc><f2>New in 0.7: <f1> Kick/Ban Delay shorten\nAutoJJ and Usage Detection refinded\nNofog Trickery now goes in a V path<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 3)
		centerprint(%client,"<jc><f2>Map Options: <f1> Admins can now select a map in which will play next.\nAdmins can also restart the current map or continue to the next.\n Switching Gamemodes no longer changes the map.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 4)
		centerprint(%client,"<jc><f2>Merc Booster Pop: <f1> Instead of throwing plasma around, Merc catches on fire.\nOnce on fire, rockets are attracted to the Merc without jetting.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 5)
		centerprint(%client,"<jc><f2>AFK System: <f1> If someone says \"brb\" or \"afk\" they go in AFK mode.\nBoth AFK Mode and Obs mode have limited Bandwidth usage.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 6)
		centerprint(%client,"<jc><f2>Planes: <f1> Less crashes with Planes\nShows the MPH the plane is going.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 7)
		centerprint(%client,"<jc><f2>Lag: <f1> The admin.cs file was broken down in seperate files - causing less lag.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 8)
		centerprint(%client,"<jc><f2>Voice Packs: <f1> Gave Admins choice to disable soundpacks.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 9)
		centerprint(%client,"<jc><f2>Base Damage: <f1> Added two new options for base damage\nBase Healing and also Disable Base damage\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 10)
		centerprint(%client,"<jc><f2>Nuke: <f1> The nuke was giving a new look\nThis new look includes alot go SFX and a mushroom cloud.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 11)
		centerprint(%client,"<jc><f2>Suicides: <f1> Gave owner variable to decide if suicides count as a death\nTook out the point loss assoicated with suiciding.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 12)
		centerprint(%client,"<jc><f2>Duel: <f1> Duel was giving a time in which no damage can be done\nFixed problem with extra duel dummies being created.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 13)
		centerprint(%client,"<jc><f2>Railgun: <f1> Railgun power was increased.\nThe speed of the reload time for Sniper Rifle and RailGun were switched, RailGun is Slower.\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 14)
		centerprint(%client,"<jc><f2>Things to come: <f1> No crashes on Destroy all or satchels  -- IP ban and a IP range (56kers) Ban -- Better smurf detection -- Choosable Weapon Duel\nTAB Admin and Ban list to deadmin or deban anyone - Included 2 new admins : Owner and God\n<f3>Hit Next Weapon<f1> for the next message...",30);
	else if(%client.GettingInfo == 15)
		centerprint(%client,"<jc><f1>This is a Beta version -- Modders/Scripters Wanted for help in development\nPlease post comments or suggestions to AIM: onceup0nalie.\nEnjoy your stay, and have fun.\n<f3>Hit Next Weapon<f1> to return to the game.",30);
	else 	centerprint(%client,"",0);
}

function AdminCommands(%client)
{
// <jc> = center justified, 
// <f1> = tan font, 
// <f2> = white font, 
// <f3> = orange font, \n = new line)
			%client.GettingInfoType = commands;
		%msg = "<jc>!nba - Nobans All\n!undonba - Un-Nobans All\n!time - Disables Time\n!la - Leader everyone\n!undola - Un-Leader everyone\n!cease - Cease fire mode\n!ceaseoff - Disables cease fire\n<f3>Hit Next Weapon<f1> for the next message...";
		%msg2= "<jc>!allobs - Puts everyone in observer \n !alltoteam1 - Puts everyone to team 1 \n !alltoteam2 - Puts everyone to team 2 \n !sortteams - sorts teams by tag\n !da - Destroys all \n !ra - Repairs all\n<f3>Hit Next Weapon<f1> for the next message...";
		%msg3= "<jc>!teleport - Teleports to mouse aim \n !heal - Heals you  \n !hide - Hides you  \n !comeout - Un-Hides you\n<f3>Hit Next Weapon<f1> for the next message...";
		$GettingInfoMax = 3;
	if(%client.GettingInfo == 1)
		centerprint(%client,%msg,30);
	else if(%client.GettingInfo == 2)
		centerprint(%client,%msg2,30);
	else if(%client.GettingInfo == 3)
		centerprint(%client,%msg3,30);
	else 	centerprint(%client,"",0);	
}
function FavsHelp(%client)
{
// <jc> = center justified, 
// <f1> = tan font, 
// <f2> = white font, 
// <f3> = orange font, \n = new line)

			%client.GettingInfoType = favhelp;
		%msg ="How to spawn with favorites without the use of an Inventory system\n\nFirst you goto Player functions - Then Spawn options - Spawn favorites\n<f3>Hit Next Weapon<f1> for the next message...";
		%msg2 ="Now that you have set favorites to spawn, Press the I button on your keyboard. This brings up the inventory mode, Select the favorite you want and press Buy favorite.\n<f3>Hit Next Weapon<f1> for the next message...";
		%msg3 ="Now just suicide and you will automaticly spawn with that favorite, without using an inventory. Make sure you have pre-defined favorites before you try it.\n<f3>Hit Next Weapon<f1> for the next message...";
		$GettingInfoMax = 3;
	if(%client.GettingInfo == 1)
		centerprint(%client,%msg,30);
	else if(%client.GettingInfo == 2)
		centerprint(%client,%msg2,30);
	else if(%client.GettingInfo == 3)
		centerprint(%client,%msg3,30);
	else 	centerprint(%client,"",0);	
}

function Shifter2K4Team(%client)
{
// <jc> = center justified, 
// <f1> = tan font, 
// <f2> = white font, 
// <f3> = orange font, \n = new line)

		%client.GettingInfoType = team;
		%msg = "   Shifter 2K4 Modding Team\n\n   ParoXsitiC // Current Modder\nName: Brian     ::     Age: 18     ::    Location: Michigan    ::    AIM: onceup0nalie\n\n   KiLL(-)  // Retired Modder\nName: J. Alan    ::    Age: 17     ::    Location: Tennesee    ::    AIM: theonlydmkilla";
		%msg2 = "Gonzo The Clown   //   Contributions\nCzar   //   Contributions\nGreyFlcn   //   ShifterV1G\nEmo133   //   Shifter\nRenWerX   //   Renegades\n";
		$GettingInfoMax = 2;
	if(%client.GettingInfo == 1)
		centerprint(%client,%msg,30);
	else if(%client.GettingInfo == 2)
		centerprint(%client,%msg2,30);
	else 	centerprint(%client,"",0);	
}


function NextInfoLine(%client)
{
			if(%client.GettingInfoType == "updates")
			Shifter2K4Updates(%client);
			else if(%client.GettingInfoType == "commands")
			AdminCommands(%client);
			else if(%client.GettingInfoType == "favhelp")
			FavHelp(%client);
			else if(%client.GettingInfoType == "team")
			Shifter2K4Team(%client);
}