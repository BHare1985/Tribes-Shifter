echo ("Executing A.S.S.");

function Scoring::Object(%this)
{
	if ($Shifter::ObjScore == "False"){dbecho ("Scoring Is Off (Object Destoryed)");return;}

	%destroyerTeam = %this.lastDamageTeam;						//=== Team who destroyed Object.
	%thisTeam = GameBase::getTeam(%this); 						//=== Team whos object belongs.

	if (%this.lastDamageObject < 4000)
	{
		%playerClient = %this.lastDamageObject;  				//=== Player Who Did The Damage.
	}
	else if (%this.lastDamageObject > 4000)
	{
		%playerClient = GameBase::getOwnerClient(%this.lastDamageObject);	//=== Player Who Did The Damage.
	}
	//$lastdamageobj[%this]
	//greyflcn
	%this.lastdamageobj = GameBase::getControlClient(%this.lastDamageObject);

	if(%playerClient != -1 || !%playerClient)					//=== Get The Players Name Who Killed.
		%clientName = Client::getName(%playerClient);

	%objtype = getObjectType(%this);
	%objname = (GameBase::getDataName(%this)).description;

	dbecho ("Object Detroyed = " @ %objname);

	if (%thisTeam == -1) //=== Doesnt Matter - Not A Team Item
		return;

	//============================================================================= Generators
	if (%objname == "Generator")				%pntval = $Score::ObjGeneratorB;
	else if (%objname == "Solar Panel")			%pntval = $Score::ObjGeneratorS;
	else if (%objname == "Portable Generator")		%pntval = $Score::ObjGeneratorS;
	//============================================================================= Full Stations
	else if (%objname == "Ammo Supply Unit")	   	%pntval = $Score::ObjStationA;
	else if (%objname == "Station Supply Unit")		%pntval = $Score::ObjStationS;
	else if (%objname == "Command Station")			%pntval = $Score::ObjStationA;
	//============================================================================= Remote Stations
	else if (%objname == "Remote Ammo Unit")		%pntval = $Score::ObjStationR;
	else if (%objname == "Remote Inv Unit")			%pntval = $Score::ObjStationR;
	else if (%objname == "Remote Command Station")		%pntval = $Score::ObjStationR;
	//============================================================================= Flier Pad
	else if (%objname == "Station Vehicle Unit")		%pntval = $Score::ObjFlier;
	else if (%objname == "Vehicle Pad")			%pntval = $Score::ObjFlier;	
	//============================================================================= Turrets
	else if (%objname == "Remote Mortar Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Ion Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Plasma Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Remote Laser Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Point Defense Laser Mine")	%pntval = $Score::ObjTurretS;
	else if (%objname == "EMP Turret")			%pntval = $Score::ObjTurretS;
	else if (%objname == "1Satchel Charge")			%pntval = $Score::ObjTurretS;
	else if (%objname == "Deployable Elf Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "ELF Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "RMT Mortar Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "RMT Rocket Turret")		%pntval = $Score::ObjTurretS;
	else if (%objname == "Camera")				%pntval = $Score::ObjTurretS;
	else if (%objname == "")				%pntval = $Score::ObjTurretS;
	//============================================================================= Sensor Damage
	else if (%objname == "Large Pulse Sensor")		%pntval = $Score::ObjSensorL;
	else if (%objname == "Medium Pulse Sensor")		%pntval = $Score::ObjSensorL;
	else if (%objname == "Motion Sensor")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Pulse Sensor")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Remote Sensor Jammer")		%pntval = $Score::ObjSensorS;
	else if (%objname == "Arbitor Beacon")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Shield Beacon")			%pntval = $Score::ObjSensorS;
	else if (%objname == "EMP Beacon")			%pntval = $Score::ObjSensorS;
	else if (%objname == "Jammer Beacon")			%pntval = $Score::ObjSensorS;
	//============================================================================= Powered Items
	else if (%objname == "Plasma Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "ELF Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "Rocket Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "Mortar Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else if (%objname == "Indoor Turret") { %pntval = $Score::ObjTurretL; if (GameBase::isPowered(%this)) %pntval = floor(%pntval * 2); }
	else
	{
		return 0;
	}

	%pntval = %pntval + 1; //=== Minimum Points for destoying something.
	%kpos = gamebase::getposition(%playerClient);
	%dpos = gamebase::getposition(%this); 

	if (%dpos != "0 0 0" || %kpos != "0 0 0")
		%killdist = Vector::getDistance(%dpos,%kpos);
	else
		%killdist = "10";

	if (%killdist > 1200)
	{
		%pntval = (%pntval + ($Score::Kill800Plus * 2));
		if($debug) echo ("*** Plus " @ $Score::Kill800Plus);
		if($debug) echo ("*** Range Bonus Points");				
	}	
	else if (%killdist > 800 && %killdist <= 1200)
	{
		%pntval = (%pntval + ($Score::Kill800Plus + $Score::Kill250Meters));
		if($debug) echo ("*** Plus " @ $Score::Kill800Plus);
		if($debug) echo ("*** Range Bonus Points");				
	}				
	else if (%killdist > 500 && %killdist <= 800)
	{
		%pntval = (%pntval + $Score::Kill800Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill800Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist > 250 && %killdist <= 500)
	{
		%pntval = (%pntval + $Score::Kill500Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill500Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist > 100 && %killdist <= 250)
	{
		%pntval = (%pntval + $Score::Kill250Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill250Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist > 50 && %killdist <= 100)
	{
		%pntval = (%pntval + $Score::Kill100Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill100Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}				
	else if (%killdist > 15 && %killdist <= 50)
	{
		%pntval = (%pntval + $Score::Kill50Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill50Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	else if (%killdist <= 15)
	{
		%pntval = (%pntval + $Score::Kill15Meters);
		if($debug) echo ("*** Plus " @ $Score::Kill15Meters);
		if($debug) echo ("*** Range Bonus Points");				
	}
	if (%playerClient.missilekill)
	{
		%pntval = floor(%pntval * 0.25);
	}

	//====================================================================== End Of Point Values
	%item = Player::getMountedItem(%playerClient,$WeaponSlot);
	return %pntval;
}


function Scoring::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant)
{
	if ($Shifter::PlrScore == "False"){dbecho ("Scoring Is Off (Player Kill)");return;}

	//==================================================================================================================== Advanced Scoring
	//== See also in the objectives.cs file for the print out of stats... Currently Stats are printed for all players... 
	//==================================================================================================================== Advanced Scoring

	%score = 0;						//== Reset Scoring
	%killerteam = Client::getTeam(%killerId);		//== Killers Team
	%diedteam = Client::getTeam(%playerId);			//== Died Team
	%killedpos = %playerId.lastkillpos;			//== Killed Pos
	%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
	%killerarmor = Player::getArmor(%killerId);		//== Killers Armor
	%diedarmor = $killedarmor;				//== Died Armor
	%flagpos = ($teamFlag[%killerteam]).originalPosition;	//== Flags Home Pos
	%flagdist = Vector::getDistance(%killedpos,%flagpos);	//== Distance from Killed Player To Enemy
	%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag

	$killedflagcarry = "False";

	%playerId.lastkillpos = -1; //== Reset
	$killedarmor = -1; //== Reset

	//============================================================================================================== Flag Runner Killed Bonus

	if (%killedflag)
	{
		%score = (%score + $Score::FlagKill);
	}

	if (%killerarmor == "larmor") 		  %kval = 1; //== Assassin Armor
	else if (%killerarmor == "lfemale")	  %kval = 1; //== Assassin Armor 
	else if (%killerarmor == "marmor")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "mfemale")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "earmor") 	  %kval = 3; //== Engineer 
	else if (%killerarmor == "efemale")	  %kval = 3; //== Engineer 
	else if (%killerarmor == "spyarmor")  	  %kval = 1; //== Chemeleon 
	else if (%killerarmor == "spyfemale") 	  %kval = 1; //== Chemeleon 
	else if (%killerarmor == "sarmor")	  %kval = 1; //== Scout 
	else if (%killerarmor == "sfemale")	  %kval = 1; //== Scout 
	else if (%killerarmor == "stimarmor")	  %kval = 2; //== Scout 
	else if (%killerarmor == "stimfemale")	  %kval = 2; //== Scout 
	else if (%killerarmor == "barmor") 	  %kval = 4; //== Goliath 
	else if (%killerarmor == "bfemale")	  %kval = 4; //== Goliath 
	else if (%killerarmor == "darmor") 	  %kval = 5; //== Dreadnaught 
	else if (%killerarmor == "harmor")	  %kval = 4; //== Heavy 
	else if (%killerarmor == "aarmor")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "afemale")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "dmarmor")	  %kval = 2; //== Death Match
	else if (%killerarmor == "dmfemale")      %kval = 2; //== Death Match
	else if (%killerarmor == "parmor")        %kval = 0; //== Penis Curse Armor
	else if (%killerarmor == "jarmor")	  %kval = 6; //== Juggernaught

	if (%diedarmor == "larmor") 		 %dval = 1; //== Assassin Armor
	else if (%diedarmor == "lfemale")	 %dval = 1; //== Assassin Armor 
	else if (%diedarmor == "marmor")         %dval = 2; //== Medium 
	else if (%diedarmor == "mfemale")	 %dval = 2; //== Medium 
	else if (%diedarmor == "earmor") 	 %dval = 3; //== Engineer 
	else if (%diedarmor == "efemale")	 %dval = 3; //== Engineer 
	else if (%diedarmor == "spyarmor")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "spyfemale")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "sarmor")	 %dval = 1; //== Scout 
	else if (%diedarmor == "sfemale")	 %dval = 1; //== Scout 
	else if (%diedarmor == "stimarmor")	 %dval = 2; //== Scout 
	else if (%diedarmor == "stimfemale")	 %dval = 2; //== Scout 
	else if (%diedarmor == "barmor") 	 %dval = 4; //== Goliath 
	else if (%diedarmor == "bfemale")	 %dval = 4; //== Goliath 
	else if (%diedarmor == "darmor") 	 %dval = 5; //== Dreadnaught 
	else if (%diedarmor == "harmor")	 %dval = 4; //== Heavy 
	else if (%diedarmor == "aarmor")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "afemale")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "dmarmor")	 %dval = 2; //== Death Match
	else if (%diedarmor == "dmfemale")	 %dval = 2; //== Death Match
	else if (%diedarmor == "parmor")  	 %dval = 0; //== Penis Curse Armor
	else if (%diedarmor == "jarmor")	 %dval = 6; //== Juggernaught

	//=============================================================== Base-Flag Defence Scoring

	if (%flagdist <= 25)
	{
		%score = (%score + $Score::25Meters);
	}
	else if ((%flagdist > 25) && (%flagdist <= 75))
	{
		%score = (%score + $Score::75Meters);
	}
	else if ((%flagdist > 75) && (%flagdist <= 150))
	{
		%score = (%score + $Score::150Meters);
	}
	else if ((%flagdist > 150) && (%flagdist <= 250))
	{
		%score = (%score + $Score::250Meters);
	}
	else
	{
		%score = (%score + 1);
	}

	//=============================================================== Armor Kill Armor Bonuses
	if (%kval < %dval) 
	{
		%armordiff = (%dval - %kval);
		if($debug) echo ("    Kill Armor Diff   = " @ %armordiff);
		%score = (%score + %armordiff);
	}
	//=============================================================== Kill Range Bonus
		
	if (%killdist >= 800)
	{
		%score = (%score + $Score::Kill800Plus);
			
	}				
	else if (%killdist > 500 && %killdist <= 800)
	{
		%score = (%score + $Score::Kill800Meters);
			
	}
	else if (%killdist > 250 && %killdist <= 500)
	{
		%score = (%score + $Score::Kill500Meters);
			
	}
	else if (%killdist > 100 && %killdist <= 250)
	{
		%score = (%score + $Score::Kill250Meters);
			
	}
	else if (%killdist > 50 && %killdist <= 100)
	{
		%score = (%score + $Score::Kill100Meters);
			
	}				
	else if (%killdist > 15 && %killdist <= 50)
	{
		%score = (%score + $Score::Kill50Meters);
			
	}
	else if (%killdist <= 15)
	{
		%score = (%score + $Score::Kill15Meters);
			
	}	

	if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $BulletDamageType || %damagetype == $LaserDamageType) )
	{
		%score = %score + $Shifter::HeadShot;
	}

	if (%playerId.driver)
	{
		%score = %score + 3;
	}
	
	if (%damagetype == $NukeTypeDamage)
	{
		%score = %score / 2;
	}

	%killtime = getsimtime();
	%killlife = (%killtime - %killerId.spawntime) - $Shifter::KillTime;

	if (%killlife > 0)
	{
		%killscore = floor(%killlife / 180);
		%score += %killscore;
	}
	
	dbecho ("Player Killed SCORE " @ %score);
	return %score;
}

function ScoreTracker(%clientId)
{
	%addr = Client::getTransportAddress(%clientId);

	if (!$Shifter::CheckScores || $Shifter::CheckScores == "" || $Shifter::CheckScores == "0")
	{
		$Shifter::CheckScores = 30;
	}
	if($Server::TourneyMode == true)
	{}
	else if (%clientId.score < $Shifter::WarnScoreFinal)
	{
		%name = Client::getName(%clientId);
		if ($Server::Admin["noban", %name] && %clientId.noban)
		{
			echo ("ADMINMSG **** " @ %name @ " has crappy Score but is NoBan");
			return;
		}
		else if (%clientId.noban)
		{
			echo ("ADMINMSG **** " @ %name @ " has crappy Score but is NoBan");
			return;
		}
		
		MessageAll(1, Client::getName(%clientId) @ " got Kicked For Having A Crappy Score...");
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0> got Kicked For Having A Crappy Score...<f1>", 10);
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " got Kicked For Having A Crappy Score...");
		KickPlayer(%clientId, "You were kicked for having a crappy score. Score = " @ %clientId.score );
	}
	else if (%clientId.score < $Shifter::WarnScore3)
	{
		bottomprint(%clientId, "<jc><f2>You will be kicked if your score falls to low. This is your *LAST* warning.<f0>", 10);
		//echo("ADMINMSG: **** Shifter Is Checking For Poopy Player");
	}
	else if (%clientId.score < $Shifter::WarnScore2)
	{
		bottomprint(%clientId, "<jc><f2>LEVEL TWO WARNING - You will be kicked if your score falls to low.<f0>", 10);
		//echo("ADMINMSG: **** Shifter Is Checking For Poopy Player");
	}
	else if (%clientId.score < $Shifter::WarnScore1)
	{
		bottomprint(%clientId, "<jc><f2>LEVEL ONE WARNING - You will be kicked if your score falls to low.<f0>", 10);
		//echo("ADMINMSG: **** Shifter Is Checking For Poopy Player");
	}
}
