function processMenuPlayerFuncs(%clientId, %Choice)
{
	%sel = %clientId.selClient;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%playerId = %cl;
	%armor = Player::getArmor(%clientId);
	%weapon = Player::getMountedItem (%clientId, $WeaponSlot);
	%pack = Player::getMountedItem (%clientId, $BackPackSlot);
	%flag = Player::getMountedItem (%clientId, $FlagSlot);
	if(%Choice == "menurequest5")
	{   
		%curItem = 0;
		Client::buildMenu(%clientId, "Mute Functions", "PlayerFuncs", true);
		if(%ClientId.MuteKill != "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Mute Kills", "MuteKill");
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Un-Mute Kills", "MuteKill");
		if(%ClientId.MuteKpack != "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Mute Kpack", "MuteKpack");
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Un-Mute Kpack", "MuteKpack");
		if(%ClientId.MuteGlobal != "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Mute Global", "MuteGlobal");
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Un-Mute Global", "MuteGlobal");
		if(%ClientId.MuteTeam != "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Mute Team", "MuteTeam");
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Un-Mute Team", "MuteTeam");
		if(%clientId.isAdmin){
		if($Server::MuteSP != "true")
		Client::addMenuItem(%clientId, %curItem++ @ "Mute SoundPacks", "MuteSound");
		else
		Client::addMenuItem(%clientId, %curItem++ @ "Un-Mute SoundPacks", "MuteSound");	
		}
	}
	else if(%Choice == "MuteKill"){
		if(%ClientId.MuteKill != "true")
		%ClientId.MuteKill = true;
		else
		%ClientId.MuteKill = false;
	}
	else if(%Choice == "saveinfo")
	{
		SaveCharacter(%clientId);
		return;
	}
	else if(%Choice == "MuteGlobal"){
		if(%ClientId.MuteGlobal != "true")
		%ClientId.MuteGlobal = true;
		else
		%ClientId.MuteGlobal = false;
	}
	else if(%Choice == "MuteTeam"){
		if(%ClientId.MuteTeam != "true")
		%ClientId.MuteTeam = true;
		else
		%ClientId.MuteTeam = false;
	}
	else if(%Choice == "MuteSound"){
		if($Server::MuteSP != "true"){
		$Server::MuteSP  = true;
		messageAll(0, "All SoundPacks muted by " @ Client::getName(%clientId) @ "."); }
		else{
		$Server::MuteSP = false;
		messageAll(0, "All SoundPacks un-muted by " @ Client::getName(%clientId) @ ".");}
	}
	else if(%Choice == "MuteKpack"){
		if(%ClientId.MuteKpack != "true")
		%ClientId.MuteKpack = true;
		else
		%ClientId.MuteKpack = false;
	}

	else if(%Choice == "nospeak "@%sel) {
		%clientId.speakto = "";
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%sel) @ ".");
		return;
		} 
	else if(%Choice == "speak "@%sel) {
		%sel = %clientId.selClient;
		if(%clientId.speakto)
			Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.speakto) @ ".");
		%clientId.speakto = %sel;
		Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%sel) @ ".");
		Client::sendMessage(%clientId, 3,"To speak to them, type =MESSAGE.");
		return;
	}
	else if(%Choice == "mute "@%sel){
   	  	%clientId.muted[%sel] = true;
   	 	Client::sendMessage(%clientId, 3,"You are now Muting " @ Client::getName(%sel) @ ".");
   	 }
	else if(%Choice == "unmute "@%sel){
  	  	%clientId.muted[%sel] = "";
  	   	Client::sendMessage(%clientId, 3,"You are now Un-Muting " @ Client::getName(%sel) @ ".");
  	 }
	else if (%Choice == "locate")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Locate Options", "PlayerFuncs", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Enemy Flag Location", "nmeflag");
   	Client::addMenuItem(%clientId, %curItem++ @ "Friendly Flag Location", "frdflag");
			return;
	}
	else if (%Choice == "nmeflag")
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
	else if (%choice == "frdflag")
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
	if (%Choice == "weaponoptions") 
  	{ 	
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Weapon Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Options", "weapon_plasma");

		if (%armor == "harmor" || %armor == "darmor" || %armor == "jarmor" || %armor == "barmor" || %armor == "bfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Mortar Options", "weapon_mortar");
   		
		if (%armor == "harmor" || %armor == "darmor")
   			Client::addMenuItem(%clientId, %curItem++ @ "Mine Options", "weapon_dmines");

   		Client::addMenuItem(%clientId, %curItem++ @ "Rocket Options", "weapon_rocket");

		if (%armor == "earmor" || %armor == "efemale" || %armor == "aarmor" || %armor == "afemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "GravGun Options", "weapon_gravgun");

		if (%armor == "marmor" || %armor == "mfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Booster Options", "booster_options");

		if (%armor == "earmor" || %armor == "efemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Engineer Options", "engineer_options");

		if (%armor == "spyarmor" || %armor == "spyfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Plastique Options", "weapon_plastic");
		
		if (%armor == "spyarmor" || %armor == "spyfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Command LapTop Options", "weapon_laptop");

		if (%armor == "aarmor" || %armor == "afemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Clear Telepoint", "cleartelepoint");
	   		   		
		if (%armor != "jarmor")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Disc Options", "weapon_disc");
		
		if (%armor == "barmor" || %armor == "bfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_gbeacon");

		if (%armor == "larmor" || %armor == "lfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_abeacon");

		if (%armor == "spyarmor" || %armor == "spyfemale")
   			Client::addMenuItem(%clientId, %curItem++ @ "Beacon Options", "weapon_cbeacon");

   		Client::addMenuItem(%clientId, %curItem++ @ "Weapon Order", "weaponorder");			
   		
   	if ($Shifter::WeaponAdmin)
   	{
   		if(%clientId.isSuperAdmin)
   		{
				Client::addMenuItem(%clientId, %curItem++ @ "Admin Weapons", "admin_weapons");
  			}
  		}
  		return;
  	}
  	
  	
	else if(%opt == "saveinfo")
	{
		SaveCharacter(%clientId);
		return;
	}
	else if(%clientid.isadmin && %opt == "admin_weapons")
	{
		Client::buildMenu(%clientId, "Admin Weapons", "PlayerFuncs", true);

		if ($Shifter::LockOn=="true")
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Missle Lock", "ad_missle_off");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Turn On Missle Lock", "ad_missle_on");

		return;
	}
	
	else if (%Choice == "cleartelepoint")
	{
		%clientId.telepoint = "False";
		if(%clientId.telebeacon)
		{
			deleteobject(%clientId.telebeacon);
			%clientId.telebeacon = "False";
		}
		if(%clientId.teledisk)
		{
			deleteobject(%clientId.teledisk);
			%clientId.teledisk = "False";
		}		
		return;
	}
	else if (%Choice == "weapon_laptop")
	{
 		%curItem = 0;
  		Client::buildMenu(%clientId, "Laptop Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Turret Control", "laptop_control");
  		Client::addMenuItem(%clientId, %curItem++ @ "Turret Hack", "laptop_hack");
  		return;	
	}
	else if (%Choice == "laptop_control")
	{
		%ClientId.HackPack = True;
      bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Command Mode", 2);
		return;
	}
	else if (%Choice == "laptop_hack")
	{
      bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Hack Mode", 2);
		%ClientId.HackPack = False;
		return;
	}	

	else if (%Choice == "spawn_options")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Spawn Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Standard", "spawn_standard");
  		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Random", "spawn_random");
		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Favorites", "spawn_favs");
  		return;
	}
	else if (%Choice == "spawn_standard")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Standard.",5);
		%clientId.spawntype = "standard";
		return;
	}
	else if (%Choice == "spawn_random")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Random.",5);
		%clientId.spawntype = "random";
		return;
	}
	else if (%Choice == "spawn_favs")
	{
		bottomprint(%clientId, "<jc><f2>Spawn Set To Favs.",5);
		%clientId.spawntype = "favs";
		return;
	}
	else if (%Choice == "booster_options")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Booster Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Normal Booster", "booster_norm");
  		Client::addMenuItem(%clientId, %curItem++ @ "Advanced Booster", "booster_adv");
  		return;
	}
	else if (%Choice == "weapon_mortar")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Mortar Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_mortar_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "EMP Shell", "weapon_mortar_emp");
  		Client::addMenuItem(%clientId, %curItem++ @ "Frag Shell", "weapon_mortar_frag");
  		Client::addMenuItem(%clientId, %curItem++ @ "MDM Shell", "weapon_mortar_mdm");
  		return;
	}
	else if (%Choice == "weapon_rocket")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Stinger Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Stinger", "weapon_rocket1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Locking Stinger", "weapon_rocket2");
		if ($Shifter::LockOn)
	  		Client::addMenuItem(%clientId, %curItem++ @ "Lock Jaw", "weapon_rocket3");
  		Client::addMenuItem(%clientId, %curItem++ @ "Wire Guided", "weapon_rocket4");
  		return;
	}
	else if (%Choice == "weapon_plasma")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Plasma Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_plasma_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "Single Fire", "weapon_plasma_rapid");
  		Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
  		return;
	}
	else if (%Choice == "weapon_disc")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Disc Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_disc_regular");
  		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_disc_rapid");
  		return;
	}
    //else if (%Choice == "weapon_gmines")
    //{
    // %curItem = 0;
    // Client::buildMenu(%clientId, "Mine Options", true);
    //Client::addMenuItem(%clientId, %curItem++ @ "Anti-Grav Mines", "weapon_grav1");
    //Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_grav2");
    // return;
    // }
	else if (%Choice == "weapon_dmines")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Mine Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "DLM (Laser Mines)", "weapon_dmines1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_dmines2");
  		return;
	}
	else if (%Choice == "weapon_abeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Poison Throwing Stars", "weapon_abeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Shock Charges", "weapon_abeacon2");
 		return;
	}
	else if (%Choice == "weapon_cbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Satchel", "weapon_cbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_cbeacon2");
 		return;
	}
	else if (%Choice == "weaponorder")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Weapon Order Option", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Old style", "weaponorder_0");
  		Client::addMenuItem(%clientId, %curItem++ @ "Hud-Follow", "weaponorder_1");
 		return;
	}
	else if (%Choice == "weapon_gbeacon")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Beacon Options", "PlayerFuncs", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "FireBomb", "weapon_gbeacon1");
  		Client::addMenuItem(%clientId, %curItem++ @ "Targeting", "weapon_gbeacon2");
 		return;
	}
	else if (%Choice == "weapon_gravgun")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "GravGun Options", "PlayerFuncs", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Tractor Effect", "weapon_gravgun_tract");
   	Client::addMenuItem(%clientId, %curItem++ @ "Repulse Effect", "weapon_gravgun_repulse");
   	Client::addMenuItem(%clientId, %curItem++ @ "Grapler Effect", "weapon_gravgun_pull");
   	return;
	}
	else if (%Choice == "weapon_plastic")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Plastique Options", "PlayerFuncs", true);
   	if($Shifter::1secPlastique == "true")
   	Client::addMenuItem(%clientId, %curItem++ @ "1 Sec. Delay", "weapon_plastic_plas1");
   	Client::addMenuItem(%clientId, %curItem++ @ "2 Sec. Delay", "weapon_plastic_plas2");
   	Client::addMenuItem(%clientId, %curItem++ @ "5 Sec. Delay", "weapon_plastic_plas5");
   	Client::addMenuItem(%clientId, %curItem++ @ "10 Sec. Delay", "weapon_plastic_plas10");
   	Client::addMenuItem(%clientId, %curItem++ @ "15 Sec. Delay", "weapon_plastic_plas15");
   	return;
	}
	//========================================================= Engineer Opts
	else if (%Choice == "engineer_options")
	{
  		%curItem = 0;
  		Client::buildMenu(%clientId, "Engineer Options", "PlayerFuncs", true);
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Mines", "weapon_engmine");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Gun", "weapon_eng");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Beacons", "weapon_engbeacon");
		return;
	}	
	else if (%Choice == "weapon_engmine")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Mine Type", "PlayerFuncs", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Proximity Warning", "weapon_engmine_proxy");
   	Client::addMenuItem(%clientId, %curItem++ @ "Cloaking Mine", "weapon_engmine_cloak");
   	Client::addMenuItem(%clientId, %curItem++ @ "Laser Mine", "weapon_engmine_laser");
    //Client::addMenuItem(%clientId, %curItem++ @ "Anti-Grav", "weapon_gmine1");   // anti grav mines
   	Client::addMenuItem(%clientId, %curItem++ @ "Anti-Personel", "weapon_engmine_stand");
   	Client::addMenuItem(%clientId, %curItem++ @ "Replicator", "weapon_engmine_replica");
   	return;
	}
	else if (%Choice == "weapon_engbeacon")
	{
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Mine Type", "PlayerFuncs", true);
   	Client::addMenuItem(%clientId, %curItem++ @ "Standard Beacon", "weapon_engbeacon_standard");
   	Client::addMenuItem(%clientId, %curItem++ @ "Cloaked Camera", "weapon_engbeacon_camera");
		Client::addMenuItem(%clientId, %curItem++ @ "Missile Jammer", "weapon_engbeacon_antimissile");
   	Client::addMenuItem(%clientId, %curItem++ @ "Medi-Pack Patch", "weapon_engbeacon_medikit");
   	return;
	}
	else if (%Choice == "weapon_eng")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Engineer Gun Options", "PlayerFuncs", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Repair", "weapon_eng_repair");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hack", "weapon_eng_hack");
   		Client::addMenuItem(%clientId, %curItem++ @ "Disassymbler", "weapon_eng_disa");
   		return;
	}	
	//========================================================= Merc Booster
	else if (%Choice == "booster_norm")
	{
		%clientId.booster = "0";
		bottomprint(%clientId, "<jc><f1>Booster Set To Normal Mode.", 3);
   	return;
	}
	else if (%Choice == "booster_adv")
	{
		%clientId.booster = "1";
		bottomprint(%clientId, "<jc><f1>Booster Set To Advanced Mode.", 3);
   	return;
	}
	//========================================================= Engineer Mines
	else if(%Choice == "weapon_engmine_proxy")
	{
		%clientId.EngMine = "0";
		bottomprint(%clientId, "<jc><f1>Mine Set To Proximity Detector.", 3);
  		return;
	}
	else if(%Choice == "weapon_engmine_cloak")
	{
		%clientId.EngMine = "1";
		bottomprint(%clientId, "<jc><f1>Mine Set To Cloaking Mine.", 3);
  		return;
	}
   // else if(%Choice == "weapon_gmine1")
   // {
  //  %clientId.EngMine = "2";
  //  bottomprint(%clientId, "<jc><f1>Mine Set to Point Defense Anti-Grav Mine.", 3);
  //  return;
  //  }
	else if(%Choice == "weapon_engmine_laser")
	{
		%clientId.EngMine = "2"; // 2
		bottomprint(%clientId, "<jc><f1>Mine Set To Point Defense Laser Mine.", 3);
  		return;
	}
	else if(%Choice == "weapon_engmine_stand")
	{
		%clientId.EngMine = "3";       // 3
		bottomprint(%clientId, "<jc><f1>Mine Set To Standard Anti-Personell Mine.", 3);
  		return;
	}
	else if(%Choice == "weapon_engmine_replica")
	{
		%clientId.EngMine = "4";      // 4
		bottomprint(%clientId, "<jc><f1>Mine Set To Replicator Mine.", 3);
  		return;
	}
	//================================================================= Engineer Beacons
	else if(%Choice == "weapon_engbeacon_standard")
	{
		%clientId.EngBeacon = "0";
		bottomprint(%clientId, "<jc><f1>Beacon Set To Standard.", 3);
  		return;
	}
	else if (%Choice == "weapon_engbeacon_camera")
	{
		%clientId.EngBeacon = "1";
		bottomprint(%clientId, "<jc><f1>Beacons Set To Cloaking Camera.", 3);
   		return;
	}
	else if (%Choice == "weapon_engbeacon_antimissile")
	{
		%clientId.EngBeacon = "2";
		bottomprint(%clientId, "<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.", 3);
   		return;
	}
	else if (%Choice == "weapon_engbeacon_medikit")
	{
		%clientId.EngBeacon = "3";
		bottomprint(%clientId, "<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.", 3);
   		return;
	}		
	//=================================================================== Eng-Gun Options
	else if (%Choice == "weapon_eng_repair")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 0;		
			Player::setItemCount(%clientId, Fixit , 1);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::mountItem(%clientId, Fixit, $WeaponSlot);		
			bottomprint(%clientId, "<jc><f1>Repair Gun Option Selected.", 3);
		}
		else
		{		
			if (Player::getItemCount(%clientId, Fixit))
				bottomprint(%clientId, "<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.", 3);
			else			
				bottomprint(%clientId, "<jc><f1>You do not possess a Engineer Gun.", 3);
		}
   		return;
	}
	else if (%Choice == "weapon_eng_hack")
	{
		if (Player::getItemCount(%clientId, Fixit) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::setItemCount(%clientId, Hackit, 1);
			Player::mountItem(%clientId, HackIt, $WeaponSlot);
			bottomprint(%clientId, "<jc><f1>Hacking Option Selected.", 3);
		}
		else
		{		
			if (Player::getItemCount(%clientId, HackIt))
				bottomprint(%clientId, "<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.", 3);
			else			
				bottomprint(%clientId, "<jc><f1>You do not possess a Engineer Gun.", 3);
		}
   		return;
	}
	else if (%Choice == "weapon_eng_disa")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, Fixit))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 1);
			Player::mountItem(%clientId, DisIt, $WeaponSlot);
			bottomprint(%clientId, "<jc><f1>Disassymbler Option Selected.", 3);
		}
		else
		{		
			if (Player::getItemCount(%clientId, DisIt))
				bottomprint(%clientId, "<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.", 3);
			else			
				bottomprint(%clientId, "<jc><f1>You do not possess a Engineer Gun.", 3);
		}
   	return;
	}

	//========================================================= Plastique
	else if(%Choice == "weapon_plastic_plas1" && $Shifter::1secPlastique == "true")
	{
		%clientId.Plastic = 1;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 1 Sec.", 3);
   	return;
	}
	else if(%Choice == "weapon_plastic_plas2")
	{
		%clientId.Plastic = 2;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 2 Sec.", 3);
   	return;
	}
	else if (%Choice == "weapon_plastic_plas5")
	{
		%clientId.Plastic = 5;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 5 Sec.", 3);
   	return;
	}
	else if (%Choice == "weapon_plastic_plas10")
	{
		%clientId.Plastic = 10;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 10 Sec.", 3);
   	return;
	}
	else if (%Choice == "weapon_plastic_plas15")
	{
		%clientId.Plastic = 15;
		bottomprint(%clientId, "<jc><f1>Plastique Delay Set To 15 Sec.", 3);
   	return;
	}

	//===================================================== Mortar Options
	//greygrey
	if (%Choice == "weapon_mortar_regular")
	{
		%clientId.Mortar = 0;
		bottomprint(%clientId, "<jc><f1>Standard Mortar Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
		return;
	}
	else if (%Choice == "weapon_mortar_emp")
	{
		%clientId.Mortar = 1;
		bottomprint(%clientId, "<jc><f1>Magnetic Pulse Shell Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	else if (%Choice == "weapon_mortar_frag")
	{
		%clientId.Mortar = 2;
		bottomprint(%clientId, "<jc><f1>Fragmenting Shell Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	else if (%Choice == "weapon_mortar_mdm")
	{
		%clientId.Mortar = 3;
		bottomprint(%clientId, "<jc><f1>MDM Shell Selected.", 3);
		%player = Client::getOwnedObject(%clientId);
		%wep = Player::getMountedItem(%player,$WeaponSlot);
		if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
			Player::useItem(%player,mortar);
   	return;
	}
	//===================================================== Rocket Options
	else if (%Choice == "weapon_rocket1")
	{
		%clientId.rocket = 0;
		bottomprint(%clientId, "<jc><f1>Stinger Rocket Initiated.", 3);
   	return;
	}
	else if (%Choice == "weapon_rocket2")
	{
		%clientId.rocket = 1;
		bottomprint(%clientId, "<jc><f1>Stinger Locking Initiated.", 3);
   		return;
	}
	else if (%Choice == "weapon_rocket3")
	{
		%clientId.rocket = 2;
		bottomprint(%clientId, "<jc><f1>Heat Seeking Initiated.", 3);
   		return;
	}
	else if (%Choice == "weapon_rocket4")
	{
		%clientId.rocket = 3;
		bottomprint(%clientId, "<jc><f1>Wire Guided System Initiated.", 3);
  		return;
	}

	//====================================================== Dread Mine Options
	else if (%Choice == "weapon_dmines1")
	{
		%clientId.dmines = 0;
		bottomprint(%clientId, "<jc><f1>Mines Set To DLM.", 3);
   		return;
	}
	else if (%Choice == "weapon_dmines2")
	{
		%clientId.dmines = 1;
		bottomprint(%clientId, "<jc><f1>Mines Set To Standard.", 3);
   		return;
	}
	else if (%Choice == "weapon_dmines3")
	{
		%clientId.dmines = 2;
		bottomprint(%clientId, "<jc><f1>Mines Set To Light-AP.", 3);
   		return;
	}

	//===============================Assassin Beacon
	else if (%Choice == "weapon_abeacon1")
	{
		%clientId.AssBcn = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Poison Throwing Stars.", 3);
   	return;
	}
	else if (%Choice == "weapon_abeacon2")
	{
		%clientId.AssBcn = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Shock Charge.", 3);
  		return;
	}

	else if (%Choice == "weaponorder_0")
	{
		%clientId.WeaponOrder = "0";
		bottomprint(%clientId, "<jc><f1>Old style WeaponOrder.", 3);
   	return;
	}
	else if (%Choice == "weaponorder_1")
	{
		%clientId.WeaponOrder = "1";
		bottomprint(%clientId, "<jc><f1>Hud-Follow style WeaponOrder.", 3);
  		return;
	}

	else if (%Choice == "weapon_cbeacon1")
	{
		%clientId.ChemBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Satchel.", 3);
   	return;
	}
	else if (%Choice == "weapon_cbeacon2")
	{
		%clientId.ChemBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}

	else if (%Choice == "weapon_gbeacon1")
	{
		%clientId.GolBeacon = 0;
		bottomprint(%clientId, "<jc><f1>Beacon Set To FireBomb.", 3);
   	return;
	}
	else if (%Choice == "weapon_gbeacon2")
	{
		%clientId.GolBeacon = 1;
		bottomprint(%clientId, "<jc><f1>Beacon Set To Targeting.", 3);
  		return;
	}

	//====================================================== Plasma Options
	else if (%Choice == "weapon_plasma_regular")
	{
		%clientId.Plasma = 0;
		bottomprint(%clientId, "<jc><f1>Standard Plasma Bolt Selected.", 3);
   	return;
	}
	else if (%Choice == "weapon_plasma_rapid")
	{
		%clientId.Plasma = 1;
		bottomprint(%clientId, "<jc><f1>Single-Shot Plasma Selected.", 3);
   	return;
	}
	else if (%Choice == "weapon_plasma_multi")
	{
		%clientId.Plasma = 2;
		bottomprint(%clientId, "<jc><f1>Multi-Bold Plasma Selected.", 3);
   	return;
	}
	else if (%Choice == "weapon_disc_regular")
	{
		%clientId.disc = 0;
		bottomprint(%clientId, "<jc><f1>Standard Disc Shell Selected.", 3);
   	return;
	}
	else if (%Choice == "weapon_disc_rapid")
	{
		%clientId.disc = 1;
		bottomprint(%clientId, "<jc><f1>Rapid Disc Shell Selected.", 3);
   		return;
	}
	//==================================================== Grav Gun Options
	else if (%Choice == "weapon_gravgun_tract")
	{
		%clientId.gravbolt = 0;
		bottomprint(%clientId, "<jc><f1>Grav Gun Tractor Setting Selected.", 3);
   		return;
	}
	else if (%Choice == "weapon_gravgun_repulse")
	{
		%clientId.gravbolt = 1;
		bottomprint(%clientId, "<jc><f1>Grav Gun Repulse Setting Selected.", 3);
   		return;
	}
	else if (%Choice == "weapon_gravgun_pull")
	{
		%clientId.gravbolt = 2;
		bottomprint(%clientId, "<jc><f1>Grav Gun Repulse Grapler Selected.", 3);
   		return;
	}
	}