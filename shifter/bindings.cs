//==== Shifter Key Bindings
//=================================================================================================== Save Info4
function remotesaveinfo(%clientId)
{
	if ($Shifter::SaveOn)
	{
		SaveCharacter(%clientId);
	}
}

//=================================================================================================== Plastique
function remoteweapon_plastic_plas2(%clientId)
{
	%clientId.Plastic = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 2 Sec.\", 3);", 0.01);

}
function remoteweapon_plastic_plas5(%clientId)
{
	%clientId.Plastic = 5;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 5 Sec.\", 3);", 0.01);

}
function remoteweapon_plastic_plas10(%clientId)
{
	%clientId.Plastic = 10;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 10 Sec.\", 3);", 0.01);

}
function remoteweapon_plastic_plas15(%clientId)
{
	%clientId.Plastic = 15;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 15 Sec.\", 3);", 0.01);

}
function remoteweapon_plastic_plasvar(%clientId, %timer)
{
	
	if (%timer > 30)
		%timer = 30;
	else if (%time < 1)
		%timer = 1;
	
	%clientId.Plastic = %timer;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To " @ %timer @ " Sec.\", 3);", 0.01);
}
//=================================================================================================== Eng Mines 
function remoteweapon_engmine_proxy(%clientId)
{
	%clientId.EngMine = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Proximity Detector.\", 3);", 0.01);

}

function remoteweapon_engmine_cloak(%clientId)
{
	%clientId.EngMine = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Cloaking Mine.\", 3);", 0.01);

}
function remoteweapon_engmine_laser(%clientId)
{
	%clientId.EngMine = "2";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Point Defense Laser Mine.\", 3);", 0.01);

}
function remoteweapon_engmine_stand(%clientId)
{
	%clientId.EngMine = "3";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Standard Anti-Personell Mine.\", 3);", 0.01);

}
function remoteweapon_engmine_replica(%clientId)
{
	%clientId.EngMine = "4";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Replicator Mine.\", 3);", 0.01);

}

//==================================================================================== DMine Options
function remoteweapon_dmines1(%clientId)
{
	%clientId.dmines = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To DLM.\", 3);", 0.01);

}
function remoteweapon_dmines2(%clientId)
{
	%clientId.dmines = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Standard.\", 3);", 0.01);

}
//function remoteweapon_dmines3(%clientId)
//{
//	%clientId.dmines = 2;
//	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mines Set To Light-AP.\", 3);", 0.01);
//
//}

//==================================================================================== Engineer Beacons
function remoteweapon_engbeacon_standard(%clientId)
{
	%clientId.EngBeacon = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Standard.\", 3);", 0.01);

}
function remoteweapon_engbeacon_camera(%clientId)
{
	%clientId.EngBeacon = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Camera.\", 3);", 0.01);

}
function remoteweapon_engbeacon_antimissile(%clientId)
{
	%clientId.EngBeacon = "2";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.\", 3);", 0.01);

}
function remoteweapon_engbeacon_medikit(%clientId)
{
	%clientId.EngBeacon = "3";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.\", 3);", 0.01);

}
//======================================================================== Mortar Options
function remoteweapon_mortar_regular(%clientId)
{
	%clientId.Mortar = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Mortar Selected.\", 3);", 0.01);
	%player = Client::getOwnedObject(%clientId);
	%wep = Player::getMountedItem(%player,$WeaponSlot);
	if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
		Player::useItem(%player,mortar);
}
function remoteweapon_mortar_emp(%clientId)
{
	%clientId.Mortar = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Magnetic Pulse Shell Selected.\", 3);", 0.01);
	%player = Client::getOwnedObject(%clientId);
	%wep = Player::getMountedItem(%player,$WeaponSlot);
	if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
		Player::useItem(%player,mortar);
}

function remoteweapon_mortar_frag(%clientId)
{
	%clientId.Mortar = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Fragmenting Shell Selected.\", 3);", 0.01);
	%player = Client::getOwnedObject(%clientId);
	%wep = Player::getMountedItem(%player,$WeaponSlot);
	if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
		Player::useItem(%player,mortar);
}	
function remoteweapon_mortar_mdm(%clientId)
{
	%clientId.Mortar = 3;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MDM Shell Selected.\", 3);", 0.01);
	%player = Client::getOwnedObject(%clientId);
	%wep = Player::getMountedItem(%player,$WeaponSlot);
	if(%wep == mortar || %wep == mortar0 || %wep == mortar1 || %wep == mortar2)
		Player::useItem(%player,mortar);
}	

//================================================================ Rocket Options
function remoteweapon_rocket1(%clientId)
{
	%clientId.rocket = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Rocket Initiated.\", 3);", 0.01);

}
function remoteweapon_rocket2(%clientId)
{
	%clientId.rocket = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Locking Initiated.\", 3);", 0.01);

}
function remoteweapon_rocket3(%clientId)
{
	if($Shifter::LockOn)
	{
		if (%clientId.target != -1)
		{
			%clientId.rocket = 2;
			%clientId.target = -1;
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>HeatSeeker Initiated. Target Lock Lost.\", 3);", 0.01);
		}
		else
		{
			%clientId.target = -1;
			%clientId.rocket = 2;
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>HeatSeeker Initiated. Fire To Acquire Target.\", 3);", 0.01);
		}
	}
}
function remoteweapon_rocket4(%clientId)
{
	%clientId.rocket = 3;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>WireGuided Rocket Initiated.\", 3);", 0.01);

}
//========================================================================= Plasma Options
function remoteweapon_plasma_regular(%clientId)
{
	%clientId.Plasma = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Plasma Bolt Selected.\", 3);", 0.01);

}
function remoteweapon_plasma_rapid(%clientId)
{
	%clientId.Plasma = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid-Bold Plasma Selected.\", 3);", 0.01);

}
function remoteweapon_plasma_multi(%clientId)
{
	%clientId.Plasma = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0.01);

}

//======================================================================= Grav Gun Options
function remoteweapon_gravgun_tract(%clientId)
{
	%clientId.gravbolt = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0.01);

}
function remoteweapon_gravgun_repulse(%clientId)
{
	%clientId.gravbolt = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0.01);

}
function remoteweapon_gravgun_pull(%clientId)
{
	%clientId.gravbolt = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Grapler Setting Selected.\", 3);", 0.01);
}
//====================================================================================== Eng-Gun Options
function remoteweapon_eng_repair(%clientId)
{
	if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
	{
		%clientId.Eng = 0;		
		Player::setItemCount(%clientId, Fixit , 1);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::mountItem(%clientId, Fixit, $WeaponSlot);		
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Repair Gun Option Selected.\", 3);", 0.01);
	}
	else
	{		
		if (Player::getItemCount(%clientId, FixIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.\", 3);", 0.01);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
	}


}

function remoteweapon_eng_hack(%clientId)
{
	if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt))
	{
		%clientId.Eng = 1;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::setItemCount(%clientId, Hackit, 1);
		Player::mountItem(%clientId, HackIt, $WeaponSlot);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hacking Option Selected.\", 3);", 0.01);
	}
	else
	{		
		if (Player::getItemCount(%clientId, HackIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.\", 3);", 0.01);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
	}


}

function remoteweapon_eng_disa(%clientId)
{
	if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, HackIt))
	{
		%clientId.Eng = 1;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 1);
		Player::mountItem(%clientId, DisIt, $WeaponSlot);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disassymbler Option Selected.\", 3);", 0.01);
	}
	else
	{		
		if (Player::getItemCount(%clientId, DisIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.\", 3);", 0.01);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0.01);
	}


}
function remotePlayFakeDeath(%client,%anim)
{
	if(!$server::tourneymode && %anim != 51 && %anim != 114 )
		Player::setAnimation(%client,%anim);
}

function remoteclear_telepoint(%clientId)
{
	%clientID.telepoint = "False";
	%beacon = %clientID.telebeacon;
	//%disk = %clientID.teledisk;
	if(%beacon)
	{
		deleteobject(%beacon);
		%clientID.telebeacon = "False";
	}
	//if(%disk && %disk.check)
	//{
	//	deleteobject(%disk);
	//	%clientID.teledisk = "False";
	//}
	//else if(%disk && !%disk.check)
	//{
	//	%clientID.teledisk = "False";
	//}
}

//========================================================== Remote Spawn Settings
function remotespawn_standard(%clientId)
{	
	%clientId.spawntype = "standard";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Spawn type set to Standard.\", 3);", 0.01);

}

function remotespawn_random(%clientId)
{
	%clientId.spawntype = "random";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Spawn type set to Random.\", 3);", 0.01);

}

function remotespawn_favs(%clientId)
{	
	if($Shifter::SpawnFavs != "False") 
	{
		%clientId.spawntype = "favs";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Spawn type set to Favorites.\", 3);", 0.01);
	
	}	
}

//======================================================= Observer Remote Functions
function remoteobssetcfollow(%clientId)
{
	%clientId.obsmode = 4;
	if (%clientId.observerTarget)
	{
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	} 
	bottomprint(%clientId, "Observer,Follow mode set as default.",3);

}

function remoteobssetffollow(%clientId)
{
	%clientId.obsmode = 5;
	if (%clientId.observerTarget) 
	{
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
	bottomprint(%clientId, "Observer,Follow mode set as default.",3);

}

function remoteobssetaction(%clientId)
{
	%clientId.obsmode = 6;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	} 
	bottomprint(%clientId, "Observer,Follow mode set as default.",3);

}
function remoteobssetvclose(%clientId)
{
	%clientId.obsmode = 3;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
	bottomprint(%clientId, "Observer, Very close mode set as default.",3);
 
}

function remoteobssetclose(%clientId)
{
	%clientId.obsmode = 0;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget); 
	}
	bottomprint(%clientId, "Observer, Close mode set as default.",3); 

}

function remoteobssetfar(%clientId)
{ 		
	%clientId.obsmode = 1;
	if (%clientId.observerTarget) 
	{ 
		Observer::setTargetClient(%clientId, %clientId.observerTarget); 
	} 
	bottomprint(%clientId, "Observer, Far View set as default.",3); 

}

function remoteobssetfirst(%clientId)
{ 
	%clientId.obsmode = 2;
	if (%clientId.observerTarget)
	{
		Observer::setTargetClient(%clientId, %clientId.observerTarget);
	}
	bottomprint(%clientId, "Observer, First person view set as default.",3);

}

function remoteobssetspy(%clientId)
{ 
	if (!%clientId.isadmin)
	
	if(%clientId.spymode == "0" || !%clientId.spymode) 
	{ 
		%clientId.spymode = "1";
		bottomprint(%clientId, "Observer Spy mode is set, observed player will recieve no warning.",3); 
	}
	else 
	{ 
		%clientId.spymode = "0"; 
		bottomprint(%clientId, "Observer Warn mode is set, player will recieve notice that you are observing",3);
	} 

}


//======================================================= Lap Top Options for Remote.
function remotelaptop_control(%clientId)
{
	%ClientId.HackPack = True;
	bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Command Mode", 2);

}

function remotelaptop_hack(%clientId)
{
	bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Hack Mode", 2);
	%ClientId.HackPack = False;

}	

//=============================================================================================== Merc Booster
function remotebooster_norm(%clientId)
{
	%clientId.booster = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Set To Normal Mode.\", 3);", 0.01);
}
function remotebooster_adv(%clientId)
{
	%clientId.booster = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Booster Set To Advanced Mode.\", 3);", 0.01);
}

function remoteenemyflag(%clientId)
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
}

function remoteteamflag(%clientId)
{
	%playerteam = GameBase::getTeam(%clientId);
	%playerpos = GameBase::getPosition(%clientId);
	%pos = GameBase::getPosition($teamFlag[%playerteam]);
	%posX = getWord(%pos,0);
	%posY = getWord(%pos,1);
	%distance = Vector::getDistance(%pos, %playerpos);
	issueCommand(%clientId, %clientId, 0,"Way point set to your flag. Your flag is " @ %distance @ "meters away.", %posX, %posY);
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your flag is " @ %distance @ " meters away.\", 3);", 0.01);
}

function remoteshockcharge(%clientId)
{
	%clientId.AssBcn = "1";
	bottomprint(%clientId, "<jc><f1>Beacon Set To Shock Charge.", 3);
}

function remoteninjastar(%clientId)
{
	%clientId.AssBcn = "0";
	bottomprint(%clientId, "<jc><f1>Beacon Set To Poison Throwing Stars.", 3);
}

function remoteweapon_disc_regular(%clientID)
{
	%clientId.disc = 0;
	bottomprint(%clientId, "<jc><f1>Standard Disc Shell Selected.", 3);
}

function remoteweapon_disc_rapid(%clientID)
{
	%clientId.disc = 1;
	bottomprint(%clientId, "<jc><f1>Rapid Disc Shell Selected.", 3);
}

function remotechembeacon_satchel(%clientId)
{
	%clientId.ChemBeacon = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Satchel.\", 3);", 0.01);
}

function remotechembeacon_standard(%clientId)
{
	%clientId.ChemBeacon = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Targeting.\", 3);", 0.01);
}

function remotegolbeacon_fire(%clientId)
{
	%clientId.GolBeacon = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To FireBomb.\", 3);", 0.01);
}

function remotegolbeacon_standard(%clientId)
{
	%clientId.GolBeacon = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Targeting.\", 3);", 0.01);
}

function remoteshroom_em(%clientID, %target)
{
	if(%clientID.isadmin)
		player::mountitem(%target, shroom, 7);
}

function remoteweaponorder_0(%clientID)
{
	%clientId.WeaponOrder = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Old style WeaponOrder.\", 3);", 0.01);
}

function remoteweaponorder_1(%clientID)
{
	%clientId.WeaponOrder = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hud-Follow style WeaponOrder.\", 3);", 0.01);
}