function processMenuShifter2K5Tabmenu(%clientId, %Choice)
{
	
	if (%Choice == "Shifter2K5Team")
	{
		%clientId.GettingInfo = 1;
		Shifter2K5Team(%clientId);	
	}
	else if (%Choice == "LastestUpdates")
	{
		%clientId.weaponHelp = "";
		%clientId.GettingInfo = 1;
		Client::buildMenu(%clientId, "LastestUpdates", "Shifter2K5Updates", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Version 8.5", "85");
		Client::addMenuItem(%clientId, %curItem++ @ "Version 8.0", "8");
		Client::addMenuItem(%clientId, %curItem++ @ "Version 7.5b", "75b");
		Client::addMenuItem(%clientId, %curItem++ @ "Version 7.5", "75");
		Client::addMenuItem(%clientId, %curItem++ @ "Version 7.0", "5");
		Client::addMenuItem(%clientId, %curItem++ @ "Version 6.0", "6");
		Client::addMenuItem(%clientId, %curItem++ @ "Version 5.0", "5");		
		return;
	}
	else if (%Choice == "DownloadShifter2K5")
	{
	%msg = "Download Shifter 2K5\nAvailable at +NET+ HomePage tribes.handytek.com";
	centerprint(%clientId,%msg, 10);

	}
	else if (%Choice == "Shifter2K5Help")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Shifter2K5Help", "Shifter2K5Tabmenu", true);
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

function processMenuShifter2K5Updates(%clientId, %Choice)
{
	if (%Choice == "85")
	{
		$GettingInfoMax = 15;
		%clientId.GettingInfoType = "updates"@%Choice;
		%Header = "<jc><f3>Lastest Updates<f1> - Page "@%clientId.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "<f2>Railgun: <f1>Changed back to normal ShifterK speed.";
		%msg[%num++]= "<f2>Armors: <f1> All armor sexes are back to normal.";
		%msg[%num++]= "<f2>Bugs: <f1> Fixed a bug for when !da is said you can destroy all even when you dont have admin.";
		%msg[%num++]= "<f2>Spawns: <f1> Re-did the random spawns to have better armors.";
		%msg[%num++]= "<f2>Options: <f1> Added option to disabled 1 sec plastique.";
			for( %num = %clientId.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%clientId,%message,30);	
	}
	else if (%Choice == "8")
	{
		$GettingInfoMax = 15;
		%clientId.GettingInfoType = "updates"@%Choice;
		%Header = "<jc><f3>Lastest Updates<f1> - Page "@%clientId.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "<f2>Recordable D: <f1>When in practice mode players can record D and save it to a file to use later on";
		%msg[%num++]= "<f2>Detpacks: <f1> If an engineer hacks/disassembles a laid detpack; their team receieves that extra detpack.\nWalking over the detpack will just disarm it.";
		%msg[%num++]= "<f2>Satchels: <f1>Satchels now wont cause duel errors and you recieve the kill and points for anything satcheled.\nSatchels have less explosion range but more damage.";
		%msg[%num++]= "<f2>Plastique: <f1>Plastique will now explode on impact unless you're engineer";
			for( %num = %clientId.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%clientId,%message,30);	
	}
		else if (%Choice == "75b")
	{
		$GettingInfoMax = 15;
		%clientId.GettingInfoType = "updates"@%Choice;
		%Header = "<jc><f3>Updates on Version 7.5b<f1> - Page "@%clientId.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "<f2>Version 7.5: <f1> Fixed a bug that in the game.cs that wouldnt allow deaths\nEverything else same as 7.5.";
			for( %num = %clientId.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%clientId,%message,30);	
	}
		else if (%Choice == "75")
	{
		$GettingInfoMax = 15;
		%clientId.GettingInfoType = "updates"@%Choice;
		%Header = "<jc><f3>Updates on Version 7.5<f1> - Page "@%clientId.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "<f2>Destroy All: <f1> Fixed DestroyAll crash when someone is in the forcefields";
		%msg[%num++]= "<f2>Planes: <f1> Fixed Plane crashes when someone runs into Flag D";
		%msg[%num++]= "<f2>Plasma Gun: <f1> SingleShot Plasma is a bit stronger";
			for( %num = %clientId.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%clientId,%message,30);	
	}
		else if (%Choice == "7")
	{
		$GettingInfoMax = 15;
		%clientId.GettingInfoType = "updates"@%Choice;
		%Header = "<jc><f3>Updates on Version 7.0<f1> - Page "@%clientId.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "<f2>AutoJJ Detection: <f1> Enhanced the AutoJJ detection to work better";
		%msg[%num++]= "<f2>Nofog Trickery: <f1> Bots move in a V path, that way they never come up from underground\n Bots also begin to decend before moving spots";
		%msg[%num++]= "<f2>Usage Detection: <f1> Enhanced the Usage detection to work better";
		%msg[%num++]= "<f2>Plasma Gun: <f1> Changed Rapid Plasma to SingleShot Plasma";
		%msg[%num++]= "<f2>Terminations: <f1> Speeded up the Kick/Ban process";
			for( %num = %clientId.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%clientId,%message,30);	
	}
		else if (%Choice == "6")
	{
		$GettingInfoMax = 15;
		%clientId.GettingInfoType = "updates"@%Choice;
		%Header = "<jc><f3>Updates on Version 6.0<f1> - Page "@%clientId.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "<f2>Time limit: <f1> Fixed a Bug with the Time limit";
		%msg[%num++]= "<f2>Armors: <f1> Made Armors all male but scout";
			for( %num = %clientId.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%clientId,%message,30);	
	}
		else if (%Choice == "5")
	{
		$GettingInfoMax = 15;
		%clientId.GettingInfoType = "updates"@%Choice;
		%Header = "<jc><f3>Updates on Version 5.0<f1> - Page "@%clientId.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "<f2>Merc Booster Pop: <f1> Instead of throwing plasma around, Merc catches on fire.\nOnce on fire, rockets are attracted to the Merc without jetting.";
		%msg[%num++]= "<f2>AFK System: <f1> If someone says \"brb\" or \"afk\" they go in AFK mode.\nBoth AFK Mode and Obs mode have limited Bandwidth usage.";
		%msg[%num++]= "<f2>Planes: <f1> Less crashes with Planes\nShows the MPH the plane is going.";
		%msg[%num++]= "<f2>Lag: <f1> The admin.cs file was broken down in seperate files - causing less lag.";
		%msg[%num++]= "<f2>Voice Packs: <f1> Gave Admins choice to disable soundpacks.";
		%msg[%num++]= "<f2>Base Damage: <f1> Added two new options for base damage\nBase Healing and also Disable Base damage";
		%msg[%num++]= "<f2>Nuke: <f1> The nuke was giving a new look\nThis new look includes alot go SFX and a mushroom cloud.";
		%msg[%num++]= "<f2>Suicides: <f1> Gave owner variable to decide if suicides count as a death\nTook out the point loss assoicated with suiciding.";
		%msg[%num++]= "<f2>Map Options: <f1> Admins can now select a map in which will play next.\nAdmins can also restart the current map or continue to the next.\n Switching Gamemodes no longer changes the map.";
		%msg[%num++]= "<f2>Railgun: <f1> Railgun power was increased.\nThe speed of the reload time for Sniper Rifle and RailGun were switched, RailGun is Slower.";
			for( %num = %clientId.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%clientId,%message,30);	
	}
}

function AdminCommands(%client)
{
// <jc> = center justified, 
// <f1> = tan font, 
// <f2> = white font, 
// <f3> = orange font, \n = new line)
		$GettingInfoMax = 15;
		%client.GettingInfoType = commands;
		%Header = "<jc><f3>Admin Commands<f1> - Page "@%client.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]= "!nba - Nobans All\n!undonba - Un-Nobans All\n!time - Disables Time\n!la - Leader everyone\n!undola - Un-Leader everyone\n!cease - Cease fire mode\n!ceaseoff - Disables cease fire ";
		%msg[%num++]= "!allobs - Puts everyone in observer \n !alltoteam1 - Puts everyone to team 1 \n !alltoteam2 - Puts everyone to team 2 \n !sortteams - sorts teams by tag";
		%msg[%num++]= "!da - Destroys all \n !ra - Repairs all ";
		%msg[%num++]= "!teleport - Teleports to mouse aim \n !heal - Heals you  \n !hide - Hides you  \n !comeout - Un-Hides you ";
			for( %num = %client.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%client,%message,30);		
}
function FavsHelp(%client)
{
// <jc> = center justified, 
// <f1> = tan font, 
// <f2> = white font, 
// <f3> = orange font, \n = new line)
		$GettingInfoMax = 15;
		%client.GettingInfoType = favhelp;
		%Header = "<jc><f3>Favorite Help<f1> - Page "@%client.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		%msg[%num++]= "How to spawn with favorites without the use of an Inventory system\n\nFirst you goto Player functions - Then Spawn options - Spawn favorites\n<f3>Hit Next Weapon<f1> for the next message...";
		%msg[%num++]= "Now that you have set favorites to spawn, Press the I button on your keyboard. This brings up the inventory mode, Select the favorite you want and press Buy favorite.\n<f3>Hit Next Weapon<f1> for the next message...";
		%msg[%num++]= "Now just suicide and you will automaticly spawn with that favorite, without using an inventory. Make sure you have pre-defined favorites before you try it.\n<f3>Hit Next Weapon<f1> for the next message...";
		
			for( %num = %client.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%client,%message,30);
			
}

function Shifter2K5Team(%client)
{
// <jc> = center justified, 
// <f1> = tan font, 
// <f2> = white font, 
// <f3> = orange font, \n = new line)
		$GettingInfoMax = 15;
		%client.GettingInfoType = team;
		%Header = "<jc><f3>Team Info<f1> - Page "@%client.GettingInfo@"\n\n";
		%Footer = "\n\n<f3>Hit Next Weapon<f1> for the next message...";
		
		%msg[%num++]="   Shifter 2k5 Modding Team\n\n   ParoXsitiC // Current Modder\nName: Brian     ::     Age: 18     ::    Location: Michigan    ::    AIM: onceup0nalie\n\n   Android  // New Modder\nName: Andy    ::    Age: 26     ::    Location: Canada    ::    AIM: HandyTekAndy";
		%msg[%num++]= "Gonzo The Clown   //   Contributions\nCzar   //   Contributions\nGreyFlcn   //   ShifterV1G\nEmo133   //   Shifter\nRenWerX   //   Renegades\n";

			for( %num = %client.GettingInfo; %num < 15; %num++ )
			{
				if(%msg[%num] == ""){
				$GettingInfoMax = %num - 1;
				break;}
			%message = %Header@""@%msg[%num]@""@%Footer;
			break;
			}
		centerprint(%client,%message,30);
}

function NextInfoLine(%client)
{
			if(%client.GettingInfoType == "updates5")
			processMenuShifter2K5Updates(%client, 5);
			else if(%client.GettingInfoType == "updates6")
			processMenuShifter2K5Updates(%client, 6);
			else if(%client.GettingInfoType == "updates7")
			processMenuShifter2K5Updates(%client, 7);
			else if(%client.GettingInfoType == "updates75")
			processMenuShifter2K5Updates(%client, 75);
			else if(%client.GettingInfoType == "updates75b")
			processMenuShifter2K5Updates(%client, "75b");
			else if(%client.GettingInfoType == "updates8")
			processMenuShifter2K5Updates(%client, 8);
			else if(%client.GettingInfoType == "updates85")
			processMenuShifter2K5Updates(%client, 85);
			else if(%client.GettingInfoType == "commands")
			AdminCommands(%client);
			else if(%client.GettingInfoType == "favhelp")
			FavHelp(%client);
			else if(%client.GettingInfoType == "team")
			Shifter2K5Team(%client);
}