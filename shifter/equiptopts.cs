function processMenuEquiptOpts(%clientId, %Choice){
if (%Choice == "MyTeam" || %Choice == "OtherTeam")
{
	if (%Choice =="MyTeam"){
	$EquiptTeam = GameBase::getTeam(%ClientId);
	}
	else if(%Choice == "OtherTeam"){
	$EquiptTeam = GameBase::getTeam(%ClientId);
		if($EquiptTeam == 1)
			$EquiptTeam = $EquiptTeam - 1;
		else
			$EquiptTeam = $EquiptTeam + 1;
	}
	     %curItem = 0;
     		Client::buildText(%clientId, "Equipment Options:", "EquiptOpts", true);
       		Client::addMenuItem(%clientId, %curItem++ @ "Create", "CreateEquiptOpts");
       		Client::addMenuItem(%clientId, %curItem++ @ "Destroy", "DestroyEquiptOpts");
        	Client::addMenuItem(%clientId, %curItem++ @ "Repair", "RepairEquiptOpts");
}
 else if (%Choice == "DestroyEquiptOpts")
     {
     %curItem = 0;
       Client::buildText(%clientId, "Destroy What?:", "EquiptOpts", true);
  		Client::addMenuItem(%clientId, %curItem++ @ "Destroy Everything", "DestroyAll");
  		Client::addMenuItem(%clientId, %curItem++ @ "Destroy Flag Defense", "DestroyFlag");
  		Client::addMenuItem(%clientId, %curItem++ @ "Destroy Laser box", "DestroyLaser");
       return;
}	

      else if(%Choice == "RepairEquiptOpts")	FixALL(%clientId,true);
      else if(%Choice == "DestroyFlag"){	
      //%KillOpt = "flag";
      KillAll(%clientId,flag,true);
      }
      else if(%Choice == "DestroyLaser"){
      //%KillOpt = "lasers";
      KillAll(%clientId,lasers,true);
      }
      else if(%Choice == "DestroyAll"){
      KillAll(%clientId,All,true);
     // %KillOpt = "all";
      }
      
      else if (%Choice == "CreateEquiptOpts")
     {
     %curItem = 0;
       Client::buildText(%clientId, "Create What?:", "EquiptOpts", true);
       		Client::addMenuItem(%clientId, %curItem++ @ "Create Flag Defense", "CreateD");
  		Client::addMenuItem(%clientId, %curItem++ @ "Create Shocks", "CreateShocks");
       return;
}
      else if (%Choice == "CreateD")
     {
     %curItem = 0;
       Client::buildText(%clientId, "Which Side Do you want blastwalls on?:", "EquiptOpts", true);
       		Client::addMenuItem(%clientId, %curItem++ @ "North", "CreateDNorth");
  		Client::addMenuItem(%clientId, %curItem++ @ "South", "CreateDSouth");
  		Client::addMenuItem(%clientId, %curItem++ @ "East", "CreateDEast");
  		Client::addMenuItem(%clientId, %curItem++ @ "West", "CreateDWest");
       return;
}
      else if (%Choice == "CreateShocks")
     {
     %curItem = 0;
       Client::buildText(%clientId, "How hard of shocks?:", "EquiptOpts", true);
       		Client::addMenuItem(%clientId, %curItem++ @ "High", "CreateShocksHigh");
  		Client::addMenuItem(%clientId, %curItem++ @ "Medium", "CreateShocksMedium");
  		Client::addMenuItem(%clientId, %curItem++ @ "Low", "CreateShocksLow");
  		Client::addMenuItem(%clientId, %curItem++ @ "Very Low", "CreateShocksVeryLow");
       return;
}
else if(%Choice == "CreateShocksHigh") { %shockdiff = "godly"; Makeshocks(%clientId, %shockdiff);}
else if(%Choice == "CreateShocksMedium") { %shockdiff = "hard"; Makeshocks(%clientId, %shockdiff);}
else if(%Choice == "CreateShocksLow") { %shockdiff = "medium"; Makeshocks(%clientId, %shockdiff);}
else if(%Choice == "CreateShocksVeryLow") { %shockdiff = "easy"; Makeshocks(%clientId, %shockdiff);}
else if(%Choice == "CreateDNorth") {%direction = "north"; MakeD(%clientId,%direction);}
else if(%Choice == "CreateDWest") {%direction = "west"; MakeD(%clientId,%direction);}
else if(%Choice == "CreateDEast") {%direction = "east"; MakeD(%clientId,%direction);}
else if(%Choice == "CreateDSouth") {%direction = "south"; MakeD(%clientId,%direction);}


function MakeD(%player, %direction)
{
	%flag = $teamFlagStand[$EquiptTeam];
	%clientId = Player::getClient(%player);
	%deploypos = Vector::Add(GameBase::getPosition(%flag), "-0 -0 -0");
	%name = Client::Getname(%clientId);
	if(%direction == "east"){ %direction = 2; %direction2 = 0; %startingdegree=15;}
	if(%direction == "west"){ %direction = -2; %direction2 = 0; %startingdegree=15;} 
	if(%direction == "north"){ %direction2 = 2; %direction = 0; %startingdegree=104.85;}
	if(%direction == "south"){ %direction2 = -2;%direction = 0; %startingdegree=105;}	
	%rotation=0;
	%FFrotation=0;
	%blastfloorsdown=4.5;
	for(%num = 1; %num < 7; %num++){
	%lf[%num] = NewObject("Field", Staticshape, LargeForceField , true);
	GameBase::SetPosition(%lf[%num], Vector::Add(%deploypos, "0 0 0"));
	GameBase::SetRotation(%lf[%num], "0 0 " @ (%startingdegree + %FFrotation));
	GameBase::SetTeam(%lf[%num], $EquiptTeam);
	%FFrotation = %FFrotation+60;
	addToSet("MissionCleanup", %lf[%num]);
}
for(%num = 1; %num < 9; %num++){
	%sf[%num] = NewObject("Field", Staticshape, DeployableForceField , true);
	GameBase::SetPosition(%sf[%num], Vector::Add(%deploypos, "0 0 0"));
	GameBase::SetRotation(%sf[%num], "0 0 " @ (%startingdegree + %FFrotation));
	GameBase::SetTeam(%sf[%num], $EquiptTeam);
	%FFrotation = %FFrotation+60;
	addToSet("MissionCleanup", %sf[%num]);
}
	for(%num = 1; %num <7 ; %num++){
	%bw[%num] = NewObject("BlastWall", Staticshape, Blastwall , true);
	GameBase::SetPosition(%bw[%num], Vector::Add(%deploypos, %direction@" "@ %direction2 @" 0"));
	GameBase::SetRotation(%bw[%num], "0 0 " @ (%startingdegree + %rotation));
	GameBase::SetTeam(%bw[%num], $EquiptTeam);
	%rotation= %rotation+75;
	addToSet("MissionCleanup", %bw[%num]);
}
for(%num = 1; %num <7 ; %num++){
	%bf[%num] = NewObject("BlastFloor", Staticshape, BlastFloor , true);
	GameBase::SetPosition(%bf[%num], Vector::Add(%deploypos, "0 0 "@ %blastfloorsdown));
	GameBase::SetRotation(%bf[%num], "0 0 0");
	GameBase::SetTeam(%bf[%num], $EquiptTeam);
	addToSet("MissionCleanup", %bf[%num]);
	%blastfloorsdown = %blastfloorsdown -0.2;
}
for(%num = 1; %num <5 ; %num++){
	%ssf[%num] = NewObject("ShockFloor", Staticshape, ShockFloor , true);
	GameBase::SetPosition(%ssf[%num], Vector::Add(%deploypos, "0 "@ %direction2+2.5 @" 1.9"));
	GameBase::SetRotation(%ssf[%num], "-1.57 0.02591 -3.09105");
	GameBase::SetTeam(%ssf[%num], $EquiptTeam);
	addToSet("MissionCleanup", %ssf[%num]);
}

	
	Messageall(1,%name@" just created Flag Defense.");
}

function Makeshocks(%player, %shockdiff){
	%clientId = Player::getClient(%player);
	%name = Client::Getname(%clientId);
	if(%shockdiff == "godly"){ Messageall(1,%name@" just created High Shocks."); %shocksdiff = 1.7;}
	if(%shockdiff == "hard"){ Messageall(1,%name@" just created Medium Shocks.");%shocksdiff = 1.5;}
	if(%shockdiff == "medium"){Messageall(1,%name@" just created Low Shocks."); %shocksdiff = 1.3;}
	if(%shockdiff == "easy"){ Messageall(1,%name@" just created Very Low Shocks.");%shocksdiff = 1.1;}
	%flag = $teamFlag[$EquiptTeam];
	%deploypos = Vector::Add(GameBase::getPosition(%flag), "-0 -0 -0");
	for(%num = 1; %num <3 ; %num++){
	%ssf[%num] = NewObject("ShockFloor", Staticshape, ShockFloor , true);
	GameBase::SetPosition(%ssf[%num], Vector::Add(%deploypos, "0 2.5 "@ %shocksdiff));
	GameBase::SetRotation(%ssf[%num], "-1.57 0.02591 -3.09105");
	GameBase::SetTeam(%ssf[%num], $EquiptTeam);
	addToSet("MissionCleanup", %ssf[%num]);
}
}	
}
function KillAll(%clientId,%KillOpt,%base)//	'Gonzo'
{
	%start = nameToID("MissionCleanup");
	%teamname = getTeamName($EquiptTeam);
	for(%i = 8200; %i< 9300; %i++)
	{
		%name = GameBase::getDataName(%i);
		if(%name != "" && %name != "DropPointMarker" && %name != "False")
		{
			if(GameBase::getTeam(%i) == $EquiptTeam){
				if(%KillOpt == "All"){
			if(String::findSubStr(%name,"Turret") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Deployable") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "ForceField") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Floor") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Wall") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Station") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Generator") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Beacon") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Pad") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Sensor") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Solar") >= 0)
			{
				$NukeIt = true;
			}
		}
		else if(%KillOpt == "lasers"){
			if(String::findSubStr(%name,"Laser") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Platform") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Camera") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Motion") >= 0)
			{
				$NukeIt = true;
			}
			
		}
		else if(%KillOpt == "flag"){
			if(String::findSubStr(%name, "ForceField") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Floor") >= 0)
			{
				$NukeIt = true;
			}
			else if(String::findSubStr(%name, "Wall") >= 0)
			{
				$NukeIt = true;
			}
			
			}

			if($NukeIt)
			{
				$NukeIt = "";
				GameBase::setDamageLevel(%i,%name.maxDamage);
			}
		}
		}
	}
	if(%KillOpt == "All" && $GameMode == "Practice")	messageAll(1, Client::getName(%clientId) @ " destroyed all Objects for "@%teamname@". ~wmine_act.wav");
			else if(%KillOpt == "flag")	messageAll(1, Client::getName(%clientId) @ " destroyed Flag Defense for "@%teamname@". ~wmine_act.wav");
			else if(%KillOpt == "lasers")	messageAll(1, Client::getName(%clientId) @ " destroyed Laser Box for "@%teamname@". ~wmine_act.wav");
}

function FixAll(%clientId, %base)//	'Gonzo'
{
	%start = nameToID("MissionCleanup");

	for(%i = 8200; %i< 9300; %i++)
	{
		%name = GameBase::getDataName(%i);

		if(%name != "")
		{
			if(String::findSubStr(%name,"Turret") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Deployable") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "ForceField") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Floor") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Wall") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Station") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Generator") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Beacon") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Pad") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Sensor") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}
			else if(String::findSubStr(%name, "Solar") >= 0 && GameBase::getTeam(%i) == $EquiptTeam) 
			{
				$FixIt = true;
			}

			if($FixIt)
			{
				$FixIt = "";
				GameBase::setDamageLevel(%i, 0);
			}
		}
	}
	if($GameMode == "Practice")messageAll(1, Client::getName(%clientId) @ " fixed ALL Objects. ~wmine_act.wav");
}