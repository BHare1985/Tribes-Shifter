

//==========================================================================================================
//== Save Profile
//==========================================================================================================
function SaveCharacter(%clientId)
{
	if (gamebase::getteam(%clientId) < 0 || gamebase::getteam(%clientId) > 8)
		return;

	if ($Client::info[%clientId, 5] == "")
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0.01);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your profile.\", 5);", 5);	
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disconnect, enter a password that you would like to use in the OtherInfo field.\", 5);", 10);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Reconnect and you will be able to save your profile.\", 5);", 15);
		return;
	}
	else
	{
		%name = Client::getName(%clientId);
		%name = hashname(%name);

		for(%i = 1; %i <= 30; %i++)
			$funk::var["[\"" @ %name @ "\", 0, " @ %i @ "]"] = "";

		if(%clientId.dead != "1" || %clientId.observerMode == "" || client::getownedobject(%clientId) != "-1")
		{
			for(%i = 1; $funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] != ""; %i++)
				$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = "";

			$funk::var["[\"" @ %name @ "\", 1]"] = "";
		}

		//echo("Saving player " @ %name @ " (" @ %clientId @ ")...");

		%playerId = %clientId;
		%clientId.TotalKills = %clientId.TotalKills + %playerId.scoreKills;
		%clientId.TotalDeaths = %clientId.TotalDeaths + %playerId.scoreDeaths;
		%clientId.TotalScore = %clientId.TotalScore + %playerId.score;
		%clientId.TotalTKCount = %clientId.TotalTKCount + %playerId.TKCount;
		%clientId.TotalFlags = %clientId.TotalFlags + %playerId.FlagCaps;

		$funk::var["[\"" @ %name @ "\", 0, 1]"] = %clientId.spawntype;
		$funk::var["[\"" @ %name @ "\", 0, 2]"] = %clientId.EngMine;
		$funk::var["[\"" @ %name @ "\", 0, 3]"] = %clientId.Plastic;
		$funk::var["[\"" @ %name @ "\", 0, 4]"] = %clientId.Mortar;
		$funk::var["[\"" @ %name @ "\", 0, 5]"] = %clientId.Plasma;
		$funk::var["[\"" @ %name @ "\", 0, 6]"] = %clientId.gravbolt;
		$funk::var["[\"" @ %name @ "\", 0, 7]"] = %clientId.TotalKills;
		$funk::var["[\"" @ %name @ "\", 0, 8]"] = %clientId.TotalDeaths;
		$funk::var["[\"" @ %name @ "\", 0, 9]"] = %clientId.TotalScore;
		$funk::var["[\"" @ %name @ "\", 0, 10]"] = %playerId.TKCount;
		$funk::var["[\"" @ %name @ "\", 0, 11]"] = %clientId.TotalFlags;
		$funk::var["[\"" @ %name @ "\", 0, 12]"] = %clientId.MissionComplete;
		$funk::var["[\"" @ %name @ "\", 0, 13]"] = %clientId.EngBeacon;
		$funk::var["[\"" @ %name @ "\", 0, 14]"] = %clientId.rocket;
		$funk::var["[\"" @ %name @ "\", 0, 15]"] = %clientId.dmines;
		$funk::var["[\"" @ %name @ "\", 0, 16]"] = %clientId.obsmode;
		$funk::var["[\"" @ %name @ "\", 0, 17]"] = %clientId.spymode;
		$funk::var["[\"" @ %name @ "\", 0, 18]"] = %clientId.booster;
		$funk::var["[\"" @ %name @ "\", 0, 19]"] = %clientId.disc;
		$funk::var["[\"" @ %name @ "\", 0, 21]"] = %clientId.AssBcn;
		$funk::var["[\"" @ %name @ "\", 0, 22]"] = %clientId.ChemBeacon;
		$funk::var["[\"" @ %name @ "\", 0, 23]"] = %clientId.GolBeacon;
		
		$funk::var["[\"" @ %name @ "\", password]"] = $Client::info[%clientId, 5];
		
		if(%clientId.dead != "1" && %clientId.observerMode == "" && client::getownedobject(%clientId) != "-1")
		{
			%ii = 0;
			//if ($debug) echo ("Armor Type = " @ checkarmor(%cliendId) @ "") ;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i++)
			{
				%checkItem = getItemData(%i);

				if (%itemcount = Player::getItemCount(%clientId, %checkItem))
				{
					//if (%itemcount)
					//{
					//	if ($debug) echo ("Item Count  = " @ %itemcount @ "");
					//	if ($debug) echo ("Item Type   = " @ %checkitem @ "");
					//}

					if(%itemcount && %checkItem == checkarmor(%clientId))
					{
						//if ($debug) echo("Saving armor " @ %checkItem @ " for " @ %clientId);
						$funk::var["[\"" @ %name @ "\", 1]"] = %checkItem @ "";
					}
					else if(%itemcount)
					{
						//if ($debug) echo("Saving item/weapon " @ %checkItem @ " for " @ %clientId);
						%ii++;
						$funk::var["[\"" @ %name @ "\", 2, " @ %ii @ "]"] = %checkItem @ " " @ %itemcount;
					}
				}
			}
		}

		if ($Debug) echo("Deleting old file before save for " @ %clientId @ "...");
		
		File::delete("config\\" @ %name @ ".cs");
		export("funk::var[\"" @ %name @ "\",*", "config\\" @ %name @ ".cs", false);
		
		if ($Debug) echo("Save complete for " @ %name @ ".");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your profile has been saved.\", 3);", 0.01);
	}
}

function checkarmor(%clientId)
{
	%playerarmor = Player::getArmor(%clientId);
	%armor = $ArmorName[%playerarmor];
	if ($Debug) echo ("Armor = " @ %armor @ "");
	if (%armor == "LightArmor" ||%armor == "MediumArmor" ||%armor == "HeavyArmor" ||%armor == "ScoutArmor" ||%armor == "StimArmor" ||%armor == "BursterArmor" ||%armor == "EngArmor" ||%armor == "DragArmor" ||%armor == "SpArmor" ||%armor == "AlArmor" ||%armor == "Juggernaught")
	{
		if (%armor == "StimArmor")
			%armor = "ScoutArmor";
			
		if (%armor == "StimArmor")
			%armor = "ScoutAmror";
			
		if ($debug) echo ("Armor saved...");
		return %armor;
	}
	else
	{
		if ($debug) echo ("Could not verify armor type.");
		return "marmor";
	}
}

//==========================================================================================================
//== Load Profile
//==========================================================================================================
function LoadCharacter(%clientId)
{
	%name = Client::getName(%clientId);
	%name = hashname(%name);
	
	%filename = %name @ ".cs";
	%playerId = %clientId;

	//if ($Debug) echo ("Cinfo 1" @ $Client::info[%clientId, 1] @ "");
	//if ($Debug) echo ("Cinfo 2" @ $Client::info[%clientId, 2] @ "");
	//if ($Debug) echo ("Cinfo 3" @ $Client::info[%clientId, 3] @ "");
	//if ($Debug) echo ("Cinfo 4" @ $Client::info[%clientId, 4] @ "");
	//if ($Debug) echo ("Cinfo 5" @ $Client::info[%clientId, 5] @ "");
	//if ($Debug) echo ("Cinfo 6" @ $Client::info[%clientId, 6] @ "");

	if(isFile("config\\" @ %filename))
	{
		//=================================================================== clear $funk::var's
		
		for(%i = 1; %i <= 30; %i++)
			$funk::var[%name, 0, %i] = "";
		for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
			$funk::var[%name, 2, %i] = "";
		$funk::var[%name, 1] = "";

		//====================================================================== load character
		if ($debug) echo("Loading player... " @ %name @ " (" @ %clientId @ ")...");
		exec(%filename);
		if ($funk::var[%name , password] == $Client::info[%clientId, 5])
		{
			%clientId.spawntypetwo = $funk::var[%name, 0, 1];
			%clientId.EngMine = $funk::var[%name, 0, 2];
			%clientId.Plastic = $funk::var[%name, 0, 3];
			%clientId.Mortar = $funk::var[%name, 0, 4];
			%clientId.Plasma = $funk::var[%name, 0, 5];
			%clientId.gravbolt = $funk::var[%name, 0, 6];
			%clientId.TotalKills = $funk::var[%name, 0, 7];		
			%clientId.TotalDeaths = $funk::var[%name, 0, 8];
			%clientId.TotalScore = $funk::var[%name, 0, 9];
			%clientId.TotalTKCount = $funk::var[%name, 0, 10];
			%clientId.TotalFlags = $funk::var[%name, 0, 11];
			%clientId.MissionComplete = $funk::var[%name, 0, 12];
			%clientId.EngBeacon = $funk::var[%name, 0, 13];
			%clientId.rocket = $funk::var[%name, 0, 14];
			%clientId.dmines = $funk::var[%name, 0, 15];
			%clientId.obsmode = $funk::var[%name, 0, 16];
			%clientId.spymode = $funk::var[%name, 0, 17];
			%clientId.booster = $funk::var[%name, 0, 18];
			%clientId.disc = $funk::var[%name, 0, 19];
			%clientId.AssBcn = $funk::var[%name, 0, 21];
			%clientId.ChemBeacon = $funk::var[%name, 0, 22];
			%clientId.GolBeacon = $funk::var[%name, 0, 23];

			if ($matchStarted != "True")
			{
				%playerId.scoreKills = 0;
				%playerId.scoreDeaths = 0;  
				%playerId.score = 0;
				%playerId.FlagCaps = 0;
			}
			
			%clientId.spawntype = "saved";
			$spawnBuyList[%clientId, 0] = $funk::var[%name, 1];
			%clientId.SavedList[0] = $funk::var[%name, 1];

			if ($Debug) echo("Loading armor " @ $spawnBuyList[%clientId, 0] @ " for " @ %clientId);
			for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
			{
				$spawnBuyList[%clientId, %i] = $funk::var[%name, 2, %i];
				%clientId.SavedList[%i] = $funk::var[%name, 2, %i];
			}
	
			if ($Debug) echo("Load complete.");
			%clientId.SavedInfo = "True";
		}
		else
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0.01);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your profile.\", 5);", 5);
			for(%i = 1; %i <= 30; %i++)
				$funk::var[%name, 0, %i] = "";
			for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
				$funk::var[%name, 2, %i] = "";
			$funk::var[%name, 1] = "";
			return;
		}
			
	}
	else
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0.01);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your profile.\", 5);", 5);

		//================================================================= give defaults

		echo("Giving defaults to new player " @ %clientId);
		%clientId.spawntype = "random";
		%clientId.EngMine = "0";
		%clientId.Plastic = "15"; 
		%clientId.Mortar =  "0";
		%clientId.Plasma =  "0";
		%clientId.gravbolt = "0";
		%clientId.scoreKills = "0";
		%clientId.scoreDeaths = "0";
		%clientId.score =  "0";
		%clientId.TKCount =  "0";
		%clientId.FlagCaps = "0";
		%clientId.rocket = "0";
		%clientId.EngBeacon = "0";
		for(%i = 0; $spawnBuyList[%clientId, %i] != ""; %i++)
			$spawnBuyList[%clientId, %i] = "";

	}
   	Game::refreshClientScore(%clientId);
}


function hashname(%name)
{
	%name = escapeString(%name);
	%name = String::replace(%name, "\?", "A1");
	%name = String::replace(%name, "\\", "A2");
	%name = String::replace(%name, "\/", "A3");
	%name = String::replace(%name, "\!", "A4");
	%name = String::replace(%name, "\@", "A5");
	%name = String::replace(%name, "\#", "A6");
	%name = String::replace(%name, "\$", "A7");
	%name = String::replace(%name, "\%", "A8");
	%name = String::replace(%name, "\^", "A9");
	%name = String::replace(%name, "\&", "A0");
	%name = String::replace(%name, "\*", "B1");
	%name = String::replace(%name, "\(", "B2");
	%name = String::replace(%name, "\)", "B3");
	%name = String::replace(%name, "\+", "B4");
	%name = String::replace(%name, "\=", "B5");
	%name = String::replace(%name, "\:", "B6");
	%name = String::replace(%name, "\;", "B7");
	%name = String::replace(%name, "\<", "B8");
	%name = String::replace(%name, "\>", "B9");
	%name = String::replace(%name, "\,", "B0");
	%name = String::replace(%name, "\|", "C1");
	%name = String::replace(%name, "\`", "C2");
	%name = String::replace(%name, "\~", "C3");
	
	%name = ("ShifterProfile_" @ %name);
	return %name;
}
function String::len(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;

	return %length;
}

function String::replace(%string, %search, %replace)
{
	%loc = String::findSubStr(%string, %search);
	for(%loc; %loc != -1; %i++)
	{
		%lenstr = String::len(%string);
		%lenser = String::len(%search);
		%part1 = String::getSubStr(%string, 0, %loc - 1);
		%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);
		%string = %part1 @ "" @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);
	}
	return %string;
}

function saveall()
{
	%numClients = getNumClients();
	%numCl = ((2049 + %numClients) + 20);
	%linenum = 10;

	for(%k = 0 ; %k < %numClients; %k++) 
		%clientList[%k] = getClientByIndex(%k);

	for(%k= 0 ; %k < %numClients; %k++)
	{
		if($missionComplete == "True")
		{
			if ($Debug) echo ("Incrementing Mission For " @ %clientList[%k] @".");
			%clientList[%k].MissionComplete++;
		}
		SaveCharacter(%clientList[%k]);
	}
}