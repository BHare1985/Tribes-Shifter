
function SBA::duelMenu(%clientId)
{
	%curItem = 0;
	Client::buildMenu(%clientId, "Select Armor Choice.", "SBAduelArmor", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Scout", "scout");
	Client::addMenuItem(%clientId, %curItem++ @ "Sniper", "Sniper");
	Client::addMenuItem(%clientId, %curItem++ @ "Chemeleon", "Chemeleon");
	Client::addMenuItem(%clientId, %curItem++ @ "Mercenary", "Mercenary");
	Client::addMenuItem(%clientId, %curItem++ @ "Dreadnaught", "Dreadnaught");
}

function processMenuSBAduelArmor(%clientId, %opt)
{
	if(%clientId.answered == "counter")
	{
		Client::sendMessage(%clientId, 1, "Your counter offer has been sent.");
		Client::sendMessage(%challenger, 1, "Your opponant made a counter offer.~wbuysellsound.wav");
		schedule("client::sendMessage(" @ %defender @ ",1,\"Your opponant request's a " @ %opt @ " Duel.~wbuysellsound.wav\");", 0.5);
	}
	else
	{
		%clientId.offer = %opt;
		%clientId.engaged = %clientId.selclient;
		%defender = %clientId.selclient;
		%defender.engaged = %clientId;

		Client::sendMessage(%clientId, 1, "Your challenge has been sent!");
		SBA::duelMail(%defender, %opt);
		return;
	}
}

function SBA::duelMail(%defender, %opt)
{
	if(!%defender.answered && %defender.rings != 3 && !%defender.dueling)
	{
		schedule("client::sendMessage(" @ %defender @ ",1,\"You are challenged to a  " @ %opt @ "  duel!~wbuysellsound.wav\");", 0.1);
		schedule("client::sendMessage(" @ %defender @ ",1,\"Please hit TAB to respond to your challenge.~wbuysellsound.wav\");", 0.7);
		schedule("SBA::duelMail(" @ %defender @ ", " @ %opt @ ");", 6);
	}
	if(%defender.rings == "3")
	{
		%challenger = %defender.engaged;
		client::sendMessage(%challenger, 1, "Your opponant did not respond.");
		SBA::SetupReset(%challenger);
		SBA::SetupReset(%defender);
		return;
	}
	if(!%defender.rings)
		%defender.rings = 1;
	else
		%defender.rings++;
}

function SBA::duelRespond(%clientId)
{
	%clientId.answered = True;
	%curItem = 0;
	Client::buildMenu(%clientId, "Select Your Response.", "SBAduelResponse", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Accept.", "accept");
	Client::addMenuItem(%clientId, %curItem++ @ "Decline.", "decline");
	Client::addMenuItem(%clientId, %curItem++ @ "Counter Challenge", "counter");
	Client::addMenuItem(%clientId, %curItem++ @ "Ignore Challenger", "ignore");
	Client::addMenuItem(%clientId, %curItem++ @ "Disable ALL Challenges", "noDuels");
}

function processMenuSBAduelResponse(%clientId, %opt)
{
	%challenger = %clientId.engaged;
	%clientId.answered = %opt;

	if(%opt == "accept")
	{
		%eplayer = Client::getOwnedObject(%clientId);
		%cplayer = Client::getOwnedObject(%challenger);
		%clientname = Client::getName(%clientId);
		%challengername = Client::getName(%challenger);
		messageall(0,%clientname@" & "@%challengername@" are about to duel");
		SBA::duelSetup(%challenger, %clientId, %cplayer, %eplayer);
		%clientId.rings = "";
		%clientId.answer = "";
		%clientId.answered = "";
		%enemy.rings = "";
		%enemy.answer = "";
		%enemy.answered = "";
		return;
	}
	if(%opt == "decline")
	{
		Client::sendMessage(%clientId, 1, "Duel declined.  Your challenger was notified.");
		Client::sendMessage(%challenger, 1, "Your challenge has been Declined.");
		Client::sendMessage(%challenger, 1, "You are now free to challange again.");
		schedule("SBA::SetupReset(" @ %clientId @ ");", 6);
		SBA::SetupReset(%challenger);
	}
	if(%opt == "counter")
	{
		%challenger.answered = %opt;
		SBA::duelMenu(%clientId);
	}
	if(%opt == "ignore")
	{
		%clientId.ignored[%challenger] = true;
		Client::sendMessage(%clientId, 1, "Duel declined and challenger is ignored.");
		Client::sendMessage(%challenger, 1, "Your challenge has been Declined.");
		Client::sendMessage(%challenger, 1, "Your opponant requested no more challenges.");
		schedule("SBA::SetupReset(" @ %clientId @ ");", 6);
		SBA::SetupReset(%challenger);
	}
	if(%opt == "noDuels")
	{
		%clientId.noDuels = true;
		Client::sendMessage(%clientId, 1, "All future challenges will be rejected.");
		Client::sendMessage(%challenger, 1, "Your challenge has been Declined.");
		Client::sendMessage(%challenger, 1, "Your opponant requested no more challenges.");
		schedule("SBA::SetupReset(" @ %clientId @ ");", 6);
		SBA::SetupReset(%challenger);
	}
}

function SBA::duelCounterResponse(%clientId)
{
	Client::buildMenu(%clientId, "Select Your Response.", "SBAduelResponse", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Accept.", "accept");
	Client::addMenuItem(%clientId, %curItem++ @ "Decline.", "decline");
}
function SBA::duelSpawnDuelers(%clientId, %enemy)
{
	Game::playerSpawn(%clientId, "true");
	Game::playerSpawn(%enemy, "true");
	SBA::duelPlayersReady(%clientId, %enemy);
}
function SBA::duelSetup(%clientId, %enemy, %cplayer, %eplayer)
{
	if($DspotOneTaken == "true")
	{
		%clientId.dueling = %enemy;
		%clientId.three = "true";
		%enemy.dueling = %clientId;
		%enemy.four = "true";
		$DspotTwoTaken = "true";
	}
	else
	{
		%clientId.dueling = %enemy;
		%clientId.one = "true";
		%enemy.dueling = %clientId;
		%enemy.two = "true";
		$DspotOneTaken = "true";
	}

	%type = %clientId.offer;
	%clientId.duelcountdown = true;
	%enemy.duelcountdown = true;
	playNextAnim(%clientId);
	Player::kill(%clientId);
	playNextAnim(%enemy);
	Player::kill(%enemy);
	SBA::duelSpawnSetup(%clientId, %type, %rndpick);
	SBA::duelSpawnSetup(%enemy, %type, %rndpick);
	schedule("SBA::duelSpawnDuelers(" @ %clientId @ ", " @ %enemy @ ");", 2);
}

function SBA::duelPlayersReady(%clientId, %enemy)
{
	%cplayer = Client::getOwnedObject(%clientId);
	%eplayer = Client::getOwnedObject(%enemy);
 	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
 	Client::setControlObject(%enemy, Client::getObserverCamera(%enemy));
 	Observer::setOrbitObject(%clientId, %cplayer, 5, 5, 5);                
 	Observer::setOrbitObject(%enemy, %eplayer, 5, 5, 5);
	SBA::duelCountdown(%clientId, %enemy, %cplayer, %eplayer, 12);
}

function SBA::duelCountdown(%clientId, %enemy, %cplayer, %eplayer, %time)
{
	if(%time == "0")
	{
			%clientId.duelcountdown = false;
			%enemy.duelcountdown = false;
		client::sendmessage(%clientId, 1, "FIGHT!!!~wduelfight.wav");
		client::sendmessage(%enemy, 1, "FIGHT!!!~wduelfight.wav");
		SBA::duelStart(%clientId, %enemy, %cplayer, %eplayer);
		return;
	}
	if(%time == "10" || %time <= "5")
	{
		client::sendmessage(%clientId, -1, "Duel Starts in " @ %time @ " seconds");
		client::sendmessage(%enemy, -1, "Duel Starts in " @ %time @ " seconds");
	%clientId.rings = "";
	%clientId.answer = "";
	%clientId.answered = "";
	%enemy.rings = "";
	%enemy.answer = "";
	%enemy.answered = "";
	}
	%time--;
	schedule("SBA::duelCountdown(" @ %clientId @ ", " @ %enemy @ ", " @ %cplayer @ ", " @ %eplayer @ ", " @ %time @ ");", 1);
	
}

function SBA::duelStart(%clientId, %enemy, %cplayer, %eplayer)
{
	%clientId.rings = "";
	%clientId.answer = "";
	%clientId.answered = "";
	%enemy.rings = "";
	%enemy.answer = "";
	%enemy.answered = "";
	Client::setControlObject(%clientId, %cplayer);
	Client::setControlObject(%enemy, %eplayer);
	%clientId.duelStart = getsimtime();
	%enemy.duelStart = getsimtime();
	%clientId.isSet = "true";
	%enemy.isSet = "true";
}

function SBA::duelFinished(%clientId, %winner)
{
	%clientId.dfinish = getSimtime();
	%winner.dfinish = getSimtime();
	SBA::duelScoring(%clientId, %winner);
}

function SBA::duelScoring(%clientId, %winner)
{
	%duelTT = (%winner.dfinish - %winner.duelStart);
	%winner.duelPrevDuel = "win";
	%clientId.duelLastDuel = "loss";
	%winner.duelKills++;
	%clientId.duelDeaths++;

	if(%winner.duelLastDuel == "win")
		%winner.duelWinStreak++;
	else
		%winner.duelLastDuel = %winner.duelPrevDuel;

	if(%winner.duelWinStreak == "0")
		%winner.duelWinStreak = 1;

	if(%winner.duelFastWin > %duelTT)
		%winner.duelFastWin = %duelTT;

	SBA::duelSaveStats(%clientId);

	schedule("client::sendMessage(" @ %winner @ ", 1, \"You are Victorious!!!\");",1.0);
	%losername = client::getName(%clientId);
	%winnername = client::getName(%winner);
	messageall(0,""@%winnername@" Defeated "@%losername@" in "@%duelTT@" Seconds!");
      			                        schedule("remoteKill(" @ %winner @ ");", 3.0);

		   	//Player::blowUp(%player);
		   	//GameBase::applyDamage(%player,$DamageTypeFlash, 5.0,GameBase::getPosition(%this),"0 0 0","0 0 0",%player);
			//GameBase::applyRadiusDamage($DamageTypeFlash, getBoxCenter(%player), 20, 20, 30, %player);

	SBA::duelSaveStats(%winner);
}

function SBA::duelSaveStats(%clientId)
{
	if($Client::info[%clientId, 5] == "")
	{
		client::sendmessage(%clientId, 1, "You must have a password entered to save duel stats");
	}
	else
	{
		%name = Client::getName(%clientId);
		%name = hashname(%name);
	
		$funk::dvar["[\"" @ %name @ "\", 0, 1]"] = %clientId.duelKills;
		$funk::dvar["[\"" @ %name @ "\", 0, 2]"] = %clientId.duelDeaths;
		$funk::dvar["[\"" @ %name @ "\", 0, 3]"] = %clientId.duelWinStreak;
		$funk::dvar["[\"" @ %name @ "\", 0, 4]"] = %clientId.duelFastWin;
		$funk::dvar["[\"" @ %name @ "\", 0, 5]"] = %clientId.duelLastDuel;
		$funk::dvar["[\"" @ %name @ "\", password]"] = %clientId.infoPassW;
	
		export("funk::dvar[\"" @ %name @ "\",*", "config\\DuelStats" @ %name @ ".cs", false);
	}
	SBA::SetupReset(%clientId);
}

function SBA::SetupReset(%clientId)
{
	%clientId.engaged = "";
	%clientId.rings = "";
	%clientId.answer = "";
	%clientId.answered = "";
	%clientId.dueling = "";
	%clientId.one = "";
	%clientId.duelStart = "";
	%clientId.finish = "";
	%clientId.one = "";
	%clientId.two = "";
	%clientId.three = "";
	%clientId.four = "";
	%clientId.isSet = "";
}

function SBA::duelViewStats(%clientId, %sel)
{
	%name = Client::getName(%sel);

	processMenuOptions(%clientId, "SBAplayerinfo");
	remoteEval(%clientId, "setInfoLine", 1, %name @ "'s Duel Stats");
	remoteEval(%clientId, "setInfoLine", 2, "Total Duel Kills        " @ %sel.duelKills);
	remoteEval(%clientId, "setInfoLine", 3, "Total Duel Deaths     " @ %sel.duelDeaths);
	remoteEval(%clientId, "setInfoLine", 4, "Total Win/Loss Ratio  " @ SBA::duelRatio(%sel.duelKills, %sel.duelDeaths));
	remoteEval(%clientId, "setInfoLine", 5, "Longest Win Streak   " @ %sel.duelWinStreak);
	remoteEval(%clientId, "setInfoLine", 6, "Fastest Kill  (secs)     " @ %sel.duelFastWin);
}

function SBA::duelRatio(%kills, %deaths)
{
	if(%kills == "0" && %deaths == "0")
	{
		%fratio = "0.0%";
		return %fratio;
	}
	else
	{
		%ratio = floor((%kills/(%kills + %deaths))*100);
		%fratio = %ratio @ ".0%";		
		return %fratio;
	}
}

function SBA::duelSpawnSetup(%clientId, %type, %rndpick)
{
	%client = %clientId;
	for(%i = 0;$spawnBuyList[%i, %client] != "";%i++) 
	{
		$oldSpawn[%i, %client] = $spawnBuyList[%i, %client]; 
		$spawnBuyList[%i, %client] = ""; 
	}
	SBA::duelSpawnSetup2(%client, %type, %rndpick);
}

function SBA::duelSpawnSetup2(%clientId, %type, %rndpick)
{
	%client = %clientId;
	if (%type == "Sniper" || %rndpick == "0")
	{
		$spawnBuyList[0, %client] = LightArmor;
		$spawnBuyList[1, %client] = PlasmaGun;
		$spawnBuyList[2, %client] = Disclauncher;
		$spawnBuyList[3, %client] = SniperRifle;
		$spawnBuyList[4, %client] = TargetingLaser; 
		$spawnBuyList[5, %client] = EnergyPack; 
		$spawnBuyList[6, %client] = RepairKit; 
		$spawnBuyList[7, %client] = mineammo; 
		$spawnBuyList[8, %client] = Grenade;
		$spawnBuyList[9, %client] = Beacon;
		$spawnBuyList[10, %client] = PlasmaAmmo;
		$spawnBuyList[11, %client] = discammo;
		$spawnBuyList[12, %client] = SniperAmmo;
		$spawnBuyList[13, %client] = "";
		$fa_armor = "Assassin";
		$fa_pack = "EnergyPack";
	}
	else if (%type == "Chemeleon" || %rnd == "1")
	{
		$spawnBuyList[0, %client] = SpArmor;
		$spawnBuyList[1, %client] = PlasmaGun;
		$spawnBuyList[2, %client] = Disclauncher;
		$spawnBuyList[3, %client] = BoomStick;
		$spawnBuyList[4, %client] = TargetingLaser; 
		$spawnBuyList[5, %client] = FlightPack; 
		$spawnBuyList[6, %client] = RepairKit; 
		$spawnBuyList[7, %client] = mineammo; 
		$spawnBuyList[8, %client] = Grenade;
		$spawnBuyList[9, %client] = Beacon;
		$spawnBuyList[10, %client] = PlasmaAmmo;
		$spawnBuyList[11, %client] = discammo;
		$spawnBuyList[12, %client] = BoomAmmo;
		$spawnBuyList[13, %client] = "";
		$fa_pack = "FlightPack";
		$fa_armor = "Chemeleon";
		
	}
	else if (%type == "Mercenary" || %rnd == "2")
	{
		$spawnBuyList[0, %client] = MediumArmor;
		$spawnBuyList[1, %client] = Silencer;
		$spawnBuyList[2, %client] = PlasmaGun;
		$spawnBuyList[3, %client] = RocketLauncher;
		$spawnBuyList[4, %client] = BoomStick; 
		$spawnBuyList[5, %client] = Vulcan; 
		$spawnBuyList[6, %client] = TargetingLaser; 
		$spawnBuyList[7, %client] = ammopack; 
		$spawnBuyList[8, %client] = RepairKit;
		$spawnBuyList[9, %client] = mineammo;
		$spawnBuyList[10, %client] = Grenade;
		$spawnBuyList[11, %client] = Beacon;
		$spawnBuyList[12, %client] = SilencerAmmo;
		$spawnBuyList[13, %client] = PlasmaAmmo;
		$spawnBuyList[14, %client] = GrenadeAmmo;
		$spawnBuyList[15, %client] = "RocketAmmo";
		$spawnBuyList[16, %client] = "BoomAmmo";
		$spawnBuyList[17, %client] = "VulcanAmmo";
		$spawnBuyList[18, %client] = "";
		$fa_pack = "ammopack";
		$fa_armor = "Mercenary";
	}
	else if (%type == "Dreadnaught" || %rnd == "3")
	{
		$spawnBuyList[0, %client] = DragArmor;
		$spawnBuyList[1, %client] = Mortar;
		$spawnBuyList[2, %client] = RocketLauncher;
		$spawnBuyList[3, %client] = ConCun;
		$spawnBuyList[4, %client] = Vulcan; 
		$spawnBuyList[5, %client] = TargetingLaser; 
		$spawnBuyList[6, %client] = SMRPack; 
		$spawnBuyList[7, %client] = RepairKit; 
		$spawnBuyList[8, %client] = mineammo;
		$spawnBuyList[9, %client] = Grenade;
		$spawnBuyList[10, %client] = Beacon;
		$spawnBuyList[11, %client] = MortarAmmo;
		$spawnBuyList[12, %client] = RocketAmmo;
		$spawnBuyList[13, %client] = VulcanAmmo;
		$spawnBuyList[14, %client] = AutoRocketAmmo;
		$spawnBuyList[15, %client] = "";
		$fa_pack = "SMRPack";
		$fa_armor = "Dreadnaught";
	}
	else if (%type == "scout" || %rnd == 5)
	{
		$spawnBuyList[0, %client] = ScoutArmor;
		$spawnBuyList[1, %client] = LaserRifle;
		$spawnBuyList[2, %client] = Disclauncher;
		$spawnBuyList[3, %client] = TargetingLaser; 
		$spawnBuyList[4, %client] = FlightPack; 
		$spawnBuyList[5, %client] = RepairKit; 
		$spawnBuyList[6, %client] = mineammo; 
		$spawnBuyList[7, %client] = Grenade;
		$spawnBuyList[8, %client] = Beacon;
		$spawnBuyList[9, %client] = discammo;
		$spawnBuyList[10, %client] = "";
		$fa_armor = "Scout";
		$fa_pack = "EnergyPack";
	}
	else if (%type == "none2" || %rnd == 6)
	{
		$spawnBuyList[0, %client] = EngArmor;
		$spawnBuyList[1, %client] = RailGun;
		$spawnBuyList[2, %client] = DiscLauncher;
		$spawnBuyList[3, %client] = RocketLauncher;
		$spawnBuyList[4, %client] = RepairKit; 
		$spawnBuyList[5, %client] = Grenade; 
		$spawnBuyList[6, %client] = Grenade; 
		$spawnBuyList[7, %client] = Grenade; 
		$spawnBuyList[8, %client] = Grenade;
		$spawnBuyList[9, %client] = Beacon;
		$spawnBuyList[10, %client] = Beacon;
		$spawnBuyList[11, %client] = Beacon;
		$spawnBuyList[12, %client] = Beacon;
		$spawnBuyList[13, %client] = TargetingLaser;
		$spawnBuyList[14, %client] = DeployableInvPack;
		$spawnBuyList[15, %client] = "";
		$fa_pack = "Invo. Station";
		$fa_armor = "Engineer2";
	}
}

function SBA::duelSpawnsPos()
{
	if($missionName == "Blastside" || $missionName == "Broadside" || $missionName == "Scarabrae" || $missionName == "Massive_Sides")
	{
		$SBAduelPos1 = "-162.989 -1031.72 152.0";
		$SBAduelRot1= "0 -0 1.23802";

		$SBAduelPos2 = "-213.472 -1012.43 152.0";
		$SBAduelRot2= "0 -0 -1.92005";

		$SBAduelPos3 = "-422.234 737.757 64.0";
		$SBAduelRot3 = "0 -0 0.664661";

		$SBAduelPos4 = "-459.747 785.733 64.0";
		$SBAduelRot4 = "0 -0 -2.49259";
	}
	else if($missionName == "CanyonCrusade" || $missionName == "CanyonCrusade_deluxe" || $missionName == "Shifter_Training")
	{
		$SBAduelPos1 = "-791.535 34.4084 49.815";
		$SBAduelRot1 = "0 -0 -0.427054";

		$SBAduelPos2 = "-744.536 130.315 50.9388";
		$SBAduelRot2 = "0 -0 2.7365";

		$SBAduelPos3 = "742.841 -2.42455 50.3731";
		$SBAduelRot3 = "0 -0 0.463299";

		$SBAduelPos4 = "703.132 77.3147 50.1424";
		$SBAduelRot4 = "0 -0 -2.53091";
	}
	else if($missionName == "OlympusMons")
	{
		$SBAduelPos1 = "-340.523 -968.426 39.6221";
		$SBAduelRot1= "0 -0 -1.86703";

		$SBAduelPos2 = "-261.323 -990.32 43.7969";
		$SBAduelRot2= "0 -0 1.29965";

		$SBAduelPos3 = "-28.8053 830.977 59.0028";
		$SBAduelRot3= "0 -0 0.346479";

		$SBAduelPos4 = "-60.4451 923.822 60.0023";
		$SBAduelRot4= "0 -0 -2.821";
	}
	else if($missionName == "Spartacus'sGauntlet")
	{
		$SBAduelPos1 = "-391.105 1417.47 100";
		$SBAduelRot1= "0 -0 2.16049";

		$SBAduelPos2 = "-453.614 1375.53 100";
		$SBAduelRot2= "0 -0 -0.976376";

		$SBAduelPos3 = "-1346.14 -926.639 100";
		$SBAduelRot3= "0 -0 0.633303";

		$SBAduelPos4 = "-1400 -848.823 100";
		$SBAduelRot4= "0 -0 -2.54119";
	}
	else if($missionName == "Sulfurious")
	{
		$SBAduelPos1 = "-498.492 -2.04616 9.83395";
		$SBAduelRot1= "0 -0 1.66718";

		$SBAduelPos2 = "-575.294 -8.22813 10.0011";
		$SBAduelRot2= "0 -0 -1.49011";

		$SBAduelPos3 = "52.7335 519.234 10.7943";
		$SBAduelRot3= "0 -0 1.67651";

		$SBAduelPos4 = "-71.5195 504.824 9.93136";
		$SBAduelRot4= "0 -0 -1.49954";
	}
	else if($missionName == "TheLongWalk")
	{
		$SBAduelPos1 = "498.896 -162.497 113.668";
		$SBAduelRot1= "0 -0 3.00988";

		$SBAduelPos2 = "490.365 -228.089 109.284";
		$SBAduelRot2= "0 -0 -0.0941103";

		$SBAduelPos3 = "-1404.27 237.251 57.7916";
		$SBAduelRot3= "0 -0 1.68712";

		$SBAduelPos4 = "-1472.85 228.041 58.3998";
		$SBAduelRot4= "0 -0 -1.43099";
	}
	else if($missionName == "")
	{
		$SBAduelPos1 = "170.199 676.887 133.981";
		$SBAduelRot1= "0 -0 1.97874";

		$SBAduelPos2 = "83.1936 642.931 130.355";
		$SBAduelRot2= "0 -0 -1.19894";

		$SBAduelPos3 = "580.173 -600.475 97.9514";
		$SBAduelRot3= "0 -0 0.748907";

		$SBAduelPos4 = "521.461 -543.461 98.4665";
		$SBAduelRot4= "0 -0 -2.51185";
	}
	else if($missionName == "desert_of_death")
	{
		$SBAduelPos1 = "-608.965 -890.611 37.5432";
		$SBAduelRot1= "0 -0 2.75279";

		$SBAduelPos2 = "-640.911 -966.731 31.5466";
		$SBAduelRot2= "0 -0 -0.397405";

		$SBAduelPos3 = "-222.009 1292.29 37.078";
		$SBAduelRot3= "0 -0 -2.36412";

		$SBAduelPos4 = "-180.434 1261.21 36.35";
		$SBAduelRot4= "0 -0 0.940481";
	}
	else if($missionName == "IceRidge" || $missionName == "Death_Row")
	{
		$SBAduelPos1 = "-180.356 -419.624 57.4049";
		$SBAduelRot1= "0 -0 -2.35588";

		$SBAduelPos2 = "-132.164 -470.2 58.1219";
		$SBAduelRot2= "0 -0 0.769225";

		$SBAduelPos3 = "651.524 277.318 112.449";
		$SBAduelRot3= "0 -0 0.639582";

		$SBAduelPos4 = "626.335 324.894 108.587";
		$SBAduelRot4= "0 -0 -2.66977";
	}
	else if($missionName == "Stonehenge")
	{
		$SBAduelPos1 = "54.6968 -98.1165 58.6003";
		$SBAduelRot1= "0 -0 -1.86024";

		$SBAduelPos2 = "141.695 -101.94 63.5466";
		$SBAduelRot2= "0 -0 1.51249";

		$SBAduelPos3 = "1043.78 916.569 56.7963";
		$SBAduelRot3= "0 -0 -1.58745";

		$SBAduelPos4 = "1103.17 913.822 55.4282";
		$SBAduelRot4= "0 -0 1.52907";
	}
	else if($missionName == "SpinCycle")
	{
		$SBAduelPos1 = "-550.973 1725.54 103.517";
		$SBAduelRot1= "0 -0 -0.691923";

		$SBAduelPos2 = "-444.277 1871.76 114.363";
		$SBAduelRot2= "0 -0 2.48023";

		$SBAduelPos3 = "-540.311 103.58 65.2795";
		$SBAduelRot3= "0 -0 -3.10837";

		$SBAduelPos4 = "-540.436 25.6864 68.3577";
		$SBAduelRot4= "0 -0 0.117873";
	}
	else if($missionName == "SideWinder")
	{
		$SBAduelPos1 = "-1074.28 -19.8486 100";
		$SBAduelRot1= "0 -0 3.10832";

		$SBAduelPos2 = "-1076.12 -82.2085 100.002";
		$SBAduelRot2= "0 -0 -0.0238526";

		$SBAduelPos3 = "971.491 -19.6827 100";
		$SBAduelRot3= "0 -0 -3.10988";

		$SBAduelPos4 = "970.408 -82.7923 100";
		$SBAduelRot4= "0 -0 -0.0310199";
	}
	else if($missionName == "ArcticWolf")
	{
		$SBAduelPos1 = "-111.936 723.393 100";
		$SBAduelRot1= "0 -0 -0.211494";

		$SBAduelPos2 = "-95.7513 799.743 99.8497";
		$SBAduelRot2= "0 -0 2.92066";

		$SBAduelPos3 = "884.978 -1066.68 100.001";
		$SBAduelRot3= "0 -0 -0.920101";

		$SBAduelPos4 = "955.375 -1012.18 100.001";
		$SBAduelRot4= "0 -0 2.23717";
	}
	else if($missionName == "JaggedClaw")
	{
		$SBAduelPos1 = "-60.5489 -1037.12 135.572";
		$SBAduelRot1= "0 -0 -2.82285";

		$SBAduelPos2 = "-32.7609 -1119.82 133.239";
		$SBAduelRot2= "0 -0 0.284229";

		$SBAduelPos3 = "-15.5074 1058.29 108.581";
		$SBAduelRot3= "0 -0 -0.344878";

		$SBAduelPos4 = "17.5511 1151.93 102.784";
		$SBAduelRot4= "0 -0 2.75439";
	}
	else if($missionName == "IceDagger")
	{
		$SBAduelPos1 = "-470.508 -493.969 65.215";
		$SBAduelRot1= "0 -0 -2.55826";

		$SBAduelPos2 = "-411.558 -572.791 58.1796";
		$SBAduelRot2= "0 -0 0.649188";

		$SBAduelPos3 = "433.083 1532.21 175.353";
		$SBAduelRot3= "0 -0 0.028183";

		$SBAduelPos4 = "421.892 1597.94 173.782";
		$SBAduelRot4= "0 -0 -2.96447";
	}
	else if($missionName == "Reliquary")
	{
		$SBAduelPos1 = "291.308 -1155.22 55.6973";
		$SBAduelRot1= "0 -0 -1.31994";

		$SBAduelPos2 = "359.092 -1136.19 59.4721";
		$SBAduelRot2= "0 -0 1.85062";

		$SBAduelPos3 = "-399.83 902.846 64.5964";
		$SBAduelRot3= "0 -0 1.12869";

		$SBAduelPos4 = "-454.754 928.496 57.5459";
		$SBAduelRot4= "0 -0 -2.00589";
	}
	else if($missionName == "DarkAurora")
	{
		$SBAduelPos1 = "577.974 85.1737 67.7706";
		$SBAduelRot1 = "0 -0 -1.46111";

		$SBAduelPos2 = "716.007 101.868 73.6979";
		$SBAduelRot2 = "0 -0 1.83093";

		$SBAduelPos3 = "116.318 -971.776 35.9126";
		$SBAduelRot3 = "0 -0 -2.26065";

		$SBAduelPos4 = "236.787 -1066 34.1773";
		$SBAduelRot4 = "0 -0 0.899763";
	}
	else if($missionName == "MidnightMayhem" || $missionName == "MidnightMayhem_deluxe")
	{
		$SBAduelPos1 = "571.819 -1016.05 152.887";
		$SBAduelRot1 = "0 -0 1.63891";

		$SBAduelPos2 = "431.81 -1031.76 148.622";
		$SBAduelRot2 = "0 -0 -1.40547";

		$SBAduelPos3 = "-462.642 483.059 63.3389";
		$SBAduelRot3 = "0 -0 -0.919502";

		$SBAduelPos4 = "-328.903 584.531 64.532";
		$SBAduelRot4 = "0 -0 2.23147";
	}
	else if($missionName == "Simoom")
	{
		$SBAduelPos1 = "-308.759 641.123 157.437";
		$SBAduelRot1 = "0 -0 -0.532993";

		$SBAduelPos2 = "-251.987 740.972 155.289";
		$SBAduelRot2 = "0 -0 2.68385";

		$SBAduelPos3 = "741.045 -830.876 121.726";
		$SBAduelRot3 = "0 -0 -0.777509";

		$SBAduelPos4 = "821.09 -747.792 121.673";
		$SBAduelRot4 = "0 -0 2.40799";
	}
	else if($missionName == "Raindance")
	{
		$SBAduelPos1 = "-1015.69 621.193 22.2016";
		$SBAduelRot1 = "0 -0 -0.1343";

		$SBAduelPos2 = "-1006.01 740.333 28.2448";
		$SBAduelRot2 = "0 -0 2.9038";

		$SBAduelPos3 = "490.736 76.9463 27.5604";
		$SBAduelRot3 = "0 -0 -0.837164";

		$SBAduelPos4 = "585.405 156.944 30.7054";
		$SBAduelRot4 = "0 -0 2.2511";
	}
	else if($missionName == "Rollercoaster")
	{
		$SBAduelPos1 = "701.544 1558.16 40.247";
		$SBAduelRot1 = "0 -0 1.85857";

		$SBAduelPos2 = "578.592 1524.92 39.3255";
		$SBAduelRot2 = "0 -0 -1.42096";

		$SBAduelPos3 = "108.761 -557.434 44.5603";
		$SBAduelRot3 = "0 -0 -0.98319";

		$SBAduelPos4 = "197.509 -492.14 39.0654";
		$SBAduelRot4 = "0 -0 2.2023";
	}
//	else if($missionName == "")
//	{
//
//	}
	else
	{
		$NoDuelSupport = "true";
	}
}