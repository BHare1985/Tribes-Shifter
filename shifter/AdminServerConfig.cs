//========================================================================================================
//
//					     Server Config
//
//========================================================================================================

function processMenuServerConfig(%clientId, %Choice)
{
   if(%clientId.isSuperAdmin)
   {
	if(%Choice == "ResetServerDefaults")
	{
     	  Client::buildMenu(%clientId, "Confirm Reset:", "ResetAffirm", true);
     	  Client::addMenuItem(%clientId, "1Reset", "yes");
     	  Client::addMenuItem(%clientId, "2Don't Reset", "no");
    	 return;
	}
	else if (%Choice == "DeployOptions")
	{
	 %curItem = 0;
	 Client::buildText(%clientId, "Deploying Options:", "DeployingMenu", true);
          if ($Shifter::Stationdeploy)
 	  Client::addMenuItem(%clientId, %curItem++ @ "Disable Station Deploy", "StationDeploySwitch");
 	  else
	  Client::addMenuItem(%clientId, %curItem++ @ "Enable Station Deploy", "StationDeploySwitch");
 	  Client::addMenuItem(%clientId, %curItem++ @ "Change Deploys Per Second", "DeploysPerSec");
 	  if ($Shifter::Deployables=="false")
	  Client::addMenuItem(%clientId, %curItem++ @ "Turn On Defensive Deployables", "DeployablesSwitch");
	  else
	  Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Defensive Deployables", "DeployablesSwitch");
	  if ($Shifter::Turrets=="false")
	  Client::addMenuItem(%clientId, %curItem++ @ "Turn On Turrets", "TurretsSwitch");
	  else
	  Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Turrets", "TurretsSwitch");
	}
	else if (%Choice == "DamageOptions")
	{
         %curItem = 0;
         Client::buildText(%clientId, "Damage Options:", "DamageMenu", true);
       	  if($Server::TeamDamageScale == true)
 	  Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "TeamDamageSwitch");
 	  else
	  Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "TeamDamageSwitch");
	  if ($Shifter::PlayerDamage == "true")
	  Client::addMenuItem(%clientId, %curItem++ @ "Enable Player Damage", "PlayerDamageSwitch");
	  else 
	  Client::addMenuItem(%clientId, %curItem++ @ "Enable on Damage", "PlayerDamageSwitch");
 	  if($Shifter::SafeBase == "true")
	  Client::addMenuItem(%clientId, %curItem++ @ "Enable gen/station damage", "BaseDamageSwitch");
	  else 
	  Client::addMenuItem(%clientId, %curItem++ @ "Disable gen/station damage", "BaseDamageSwitch");	
	  if($Shifter::BaseHeal == "true")
	  Client::addMenuItem(%clientId, %curItem++ @ "Disable base healing", "BaseHealingSwitch");
	  else 
	  Client::addMenuItem(%clientId, %curItem++ @ "Enable base healing", "BaseHealingSwitch");		
	  if($Shifter::NoOutside == "true")
	  Client::addMenuItem(%clientId, %curItem++ @ "Disable out of area damage", "OutofAreaDamageSwitch");
	  else 
	  Client::addMenuItem(%clientId, %curItem++ @ "Enable out of area damage", "OutofAreaDamageSwitch");
	}
  }
       if(%Choice == "EnablePassword")
   	{
 	  %curItem = 0;
	   Client::buildText(%clientId, "Password Setup:", "ServerConfig", true);
 	   Client::addMenuItem(%clientId, %curItem++ @ "Enable Server Password", "ServerPass");
 	   if(%clientId.isSuperAdmin)
	   Client::addMenuItem(%clientId, %curItem++ @ "Enter Custom Password", "CustomPass");     
	}
		else if(%Choice == "ServerPass" )
		{
   		  $Server::Password = $Server::Password2;
		  messageAll(1, "The server password is "@ $Server::Password @"~wmine_act.wav");
		}
   	 	else if(%Choice == "CustomPass")
   		{
   	 	  %clientId.setpassword = "yes";
  	  	  Client::sendMessage(%clientId, 1, "Please Enter Custom Password");	
  	 	}
	else if(%Choice == "DisabledPassword")
   	{
      	  $Server::Password = "";
	  messageAll(1, "The server password is disabled~wmine_act.wav");
      	}
}

//========================================================================================================
//
//					     Server Reset
//
//========================================================================================================

 function processMenuResetAffirm(%clientId, %Choice)
{
   if(%clientId.isSuperAdmin)
   {
  	 if(%Choice == "yes")
   	{
		echo(" Server Reset By " @ Client::getName(%clientId));
     		messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
		$noFakeDeath = false;
     		exec("serverConfig.cs");
		$server::tourneymode = false;
		$ceasefire = false;
		$GameMode = Normal;
		if ($Shifter::DetPackLimit == ""){ $Shifter::DetPackLimit = "15"; }
		if ($Shifter::NukeLimit == ""){ $Shifter::NukeLimit = "15"; }
		$TeamItemMax[SuicidePack] = $Shifter::DetPackLimit;
		$TeamItemMax[MFGLAmmo] = $Shifter::NukeLimit;
		$Server::Info = $Server::Info @ "\nRunning Shifter 2K4 " @ $Shifter::Version;
		//if($dedicated) 
		if(!$noTabChange) $ModList = "Shifter 2K4";
		$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter 2K4 " @ $Shifter::Version;
		Server::storeData();
		echo(" Default config stored");
		Server::refreshData();
   	}
   }
   Game::menuRequest(%clientId);
}     	

//========================================================================================================
//
//					     Deploying Config
//
//========================================================================================================

function processMenuDeployingMenu(%clientId, %Choice)
{
   if(%clientId.isSuperAdmin)
   {
   	if(%Choice == "StationDeploySwitch")
     	{
     	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::Stationdeploy";
	  if($Shifter::Stationdeploy == false){%Msg = "Disabled Station Deploying~wmine_act.wav";
	   ChangeVariabletoItsOpposite(%VariableName, $Shifter::Stationdeploy, %AdminName, %Msg);}
	  else if($Shifter::Stationdeploy == true){%Msg = "Enabled Station Deploying~wmine_act.wav";
	   ChangeVariabletoItsOpposite(%VariableName, $Shifter::Stationdeploy, %AdminName, %Msg);}
      	}
        else if(%Choice == "DeploysPerSec")
        {
               %curItem = 0;
 		 Client::buildText(%clientId, "Change Deploy per Second ", "DeployingMenu", true);
 		  Client::addMenuItem(%clientId, %curItem++ @ "Tournament DPS", "TournyDeploysPerSec");
 		  Client::addMenuItem(%clientId, %curItem++ @ "No DPS", "NoDeploysPerSec");
 		  Client::addMenuItem(%clientId, %curItem++ @ "5 DPS", "5DeploysPerSec");
 		  Client::addMenuItem(%clientId, %curItem++ @ "3 DPS", "3DeploysPerSec");
 		  Client::addMenuItem(%clientId, %curItem++ @ "2 DPS", "2DeploysPerSec");
 		  Client::addMenuItem(%clientId, %curItem++ @ "1 DPS", "1DeploysPerSec");
    
	}
		else if(%Choice == "TournyDeploysPerSec"){
      		  $DPSAllowedChanged = 0.15;
     		  exec("itemfuncs.cs");
    		  messageAll(1, Client::getName(%clientId) @ " Changed Deploys per Second allowed to Tournament~wmine_act.wav");
		}
		else if(%Choice == "NoDeploysPerSec"){
       		  $DPSAllowedChanged = 0.0;
      		  exec("itemfuncs.cs");
          	  messageAll(1, Client::getName(%clientId) @ " Disabled All Restraints on Deploying ~wmine_act.wav");
		}
		else if(%Choice == "5DeploysPerSec"){
    		  $DPSAllowedChanged = 0.2;
       		  exec("itemfuncs.cs");
                  messageAll(1, Client::getName(%clientId) @ " Changed Deploys per Second allowed to 5 ~wmine_act.wav");
		}
		else if(%Choice == "3DeploysPerSec"){
      		  $DPSAllowedChanged = 0.33333;
      		  exec("itemfuncs.cs");
           	  messageAll(1, Client::getName(%clientId) @ " Changed Deploys per Second allowed to 3~wmine_act.wav");
		}
		else if(%Choice == "2DeploysPerSec"){
     		  $DPSAllowedChanged = 2.0;
      		  exec("itemfuncs.cs");
         	  messageAll(1, Client::getName(%clientId) @ " Changed Deploys per Second allowed to 2~wmine_act.wav");
		}
		else if(%Choice == "1DeploysPerSec"){
       		  $DPSAllowedChanged = 1.0;
       		  exec("itemfuncs.cs");
           	  messageAll(1, Client::getName(%clientId) @ " Changed Deploys per Second allowed to 1~wmine_act.wav");
		}
	else if (%Choice == "DeployablesSwitch")
	{
	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::Deployables";
		if($Shifter::Deployables == false)
		{
		  %Msg = "Enabled Defensive Deployables~wmine_act.wav";
		  ChangeVariabletoItsOpposite(%VariableName, $Shifter::Deployables, %AdminName, %Msg);
		  %ResetCMD = Deployables;
		  Items::On(%ResetCMD);
		}
		else if($Shifter::Deployables == true)
		{
		  %Msg = "Disabled Defensive Deployables~wmine_act.wav";
		  ChangeVariabletoItsOpposite(%VariableName, $Shifter::Deployables, %AdminName, %Msg);
		  %MaxCMD = Deployables;
		  Items::Off(%MaxCMD);
		}
	}
	else if (%Choice == "TurretsSwitch")
	{
	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::Turrets";
		if($Shifter::Turrets == false)
		{
		  %Msg = "Enabled Defensive Deployables~wmine_act.wav";
		  ChangeVariabletoItsOpposite(%VariableName, $Shifter::Turrets, %AdminName, %Msg);
		  %ResetCMD = Turrets;
		  Items::On(%ResetCMD);
		}
		else if($Shifter::Turrets == true)
		{
		  %Msg = "Disabled Defensive Deployables~wmine_act.wav";
		  ChangeVariabletoItsOpposite(%VariableName, $Shifter::Turrets, %AdminName, %Msg);
		  %MaxCMD = Turrets;
		  Items::Off(%MaxCMD);
		}
	}
   	
   }
}
function Items::On(%ResetCMD)
{
	if($Shifter::Turrets == "true" && %ResetCMD == "Turrets" || %ResetCMD == "All")
	{
	recountitem("BarragePack");
	recountitem("CoolLauncher");
	recountitem("DeployableElf");
	recountitem("FlamerTurretPack");
	recountitem("LaserPack");
	recountitem("PlasmaTurretPack");
	recountitem("proxLaserT");
	recountitem("RocketPack");
	recountitem("ShockPack");
	recountitem("TurretPack");
	recountitem("TargetPack");
   	recountitem("OmegaTurretPack");
   	}
 	if($Shifter::Deployables == "true" && %ResetCMD == "Deployables" || %ResetCMD== "All")
 	{
	recountitem("AccelPPack");
	recountitem("AirAmmoPad");
	recountitem("AirBase");
	recountitem("AOE");
	recountitem("BlastFloorPack");
	recountitem("BlastWallPack");
	recountitem("DeployableAmmoPack");
	recountitem("DeployableComPack");
	recountitem("DeployableTeleport");
	recountitem("EMPBeaconPack");
	recountitem("EmplacementPack");
	recountitem("ForceFieldPack");
	recountitem("hologram");
	recountitem("JammerBeaconPack");
	recountitem("LargeForceFieldPack");
	recountitem("LargeShockForceFieldPack");
	recountitem("PlantPack");
	recountitem("PlatformPack");
	recountitem("PowerGeneratorPack");
	recountitem("ShieldBeaconPack");
	recountitem("ShockFloorPack");
	recountitem("TeleportPack");
	recountitem("TeleBeacons");
	recountitem("TreePack");
	}
	if($Shifter::DetsNukesMCS == "true" && %ResetCMD == "DNM" || %ResetCMD== "All")
	{
	recountitem("BooM");
	recountitem("CoolLauncher");
	recountitem("EmpM");
	recountitem("GasM");
	recountitem("MFGLAmmo");
	recountitem("NapM");
	recountitem("PhoenixM");
	recountitem("SpyPod");
	recountitem("SuicidePack");
   	recountitem("OmegaTurretPack");
   	}
   	%ResetCMD = "";
}
function Items::Off(%MaxCMD)
{
	if($Shifter::Turrets == "false" && %MaxCMD == "Turrets" || %MaxCMD == "All")
	{
	   decountitem("BarragePack");
	   decountitem("CoolLauncher");
	   decountitem("DeployableElf");
	   decountitem("FlamerTurretPack");
	   decountitem("LaserPack");
	   decountitem("PlasmaTurretPack");
	   decountitem("proxLaserT");
	   decountitem("RocketPack");
	   decountitem("ShockPack");
	   decountitem("TurretPack");
	   decountitem("TargetPack");
   	   decountitem("OmegaTurretPack");
	}
	if($Shifter::Deployables == "false" && %MaxCMD == "Deployables" || %MaxCMD == "All")
	{
	  decountitem("AccelPPack");
	  decountitem("AirAmmoPad");
	  decountitem("AirBase");
	  decountitem("AOE");
	  decountitem("BlastFloorPack");
	  decountitem("BlastWallPack");
	  decountitem("DeployableAmmoPack");
	  decountitem("DeployableComPack");
	  decountitem("DeployableTeleport");
	  decountitem("EMPBeaconPack");
	  decountitem("EmplacementPack");
	  decountitem("ForceFieldPack");
	  decountitem("hologram");
	  decountitem("JammerBeaconPack");
	  decountitem("LargeForceFieldPack");
	  decountitem("LargeShockForceFieldPack");
	  decountitem("PlantPack");
	  decountitem("PlatformPack");
	  decountitem("PowerGeneratorPack");
	  decountitem("ShieldBeaconPack");
	  decountitem("ShockFloorPack");
	  decountitem("TeleportPack");
	  decountitem("TeleBeacons");
	  decountitem("TreePack");
	}
	if($Shifter::DetsNukesMCS == "false" && %MaxCMD == "DNM" || %MaxCMD == "All")
	{
	  decountitem("BooM");
	  decountitem("CoolLauncher");
	  decountitem("EmpM");
	  decountitem("GasM");
	  decountitem("MFGLAmmo");
	  decountitem("NapM");
	  decountitem("PhoenixM");
	  decountitem("SpyPod");
	  decountitem("SuicidePack");
   	  decountitem("OmegaTurretPack");
   	}
   	%MaxCMD = "";
}

//========================================================================================================
//
//					     Damage Config
//
//========================================================================================================

function processMenuDamageMenu(%clientId, %Choice)
{
   if(%clientId.isSuperAdmin)
   {
   	if(%Choice == "TeamDamageSwitch")
 	{
 	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Server::TeamDamageScale";
		if($Server::TeamDamageScale == false){%Msg = "Enabled Team Damage~wmine_act.wav";
	 	  ChangeVariabletoItsOpposite(%VariableName, $Server::TeamDamageScale, %AdminName, %Msg);}
		else if($Server::TeamDamageScale == true){%Msg = "Disabled Team Damage~wmine_act.wav";
	   	  ChangeVariabletoItsOpposite(%VariableName, $Server::TeamDamageScale, %AdminName, %Msg);}
	}
	
 	 else if(%Choice == "PlayerDamageSwitch")
  	{
  	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::PlayerDamage";
		if($Shifter::PlayerDamage == false){%Msg = "Enabled Player Damage~wmine_act.wav";
		  ChangeVariabletoItsOpposite(%VariableName, $Shifter::PlayerDamage, %AdminName, %Msg);}
		else if($Shifter::PlayerDamage == true){%Msg = "Disabled Player Damage~wmine_act.wav";
		  ChangeVariabletoItsOpposite(%VariableName, $Shifter::PlayerDamage, %AdminName, %Msg);}
	}
  	else if(%Choice == "BaseDamageSwitch")
 	{
  	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::SafeBase";
		if($Shifter::SafeBase == true){%Msg = "Enabled Generator and Station Damage~wmine_act.wav";
		 ChangeVariabletoItsOpposite(%VariableName, $Shifter::SafeBase, %AdminName, %Msg);}
		else if($Shifter::SafeBase == false){%Msg = "Disabled Generator and Station Damage~wmine_act.wav";
		 ChangeVariabletoItsOpposite(%VariableName, $Shifter::SafeBase, %AdminName, %Msg);}
	}
 	else if(%Choice == "BaseHealingSwitch")
	{
  	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::BaseHeal";
		if($Shifter::BaseHeal == false){%Msg = "Enabled Base Healing~wmine_act.wav";
		 ChangeVariabletoItsOpposite(%VariableName, $Shifter::BaseHeal, %AdminName, %Msg);
		 AutoRepair($Shifter::BaseRepairRate);}
		else if($Shifter::BaseHeal == true){%Msg = "Disabled Base Healing~wmine_act.wav";
		 ChangeVariabletoItsOpposite(%VariableName, $Shifter::BaseHeal, %AdminName, %Msg);
		 AutoRepair("-"@$Shifter::BaseRepairRate);}
	}
 	else if(%Choice == "OutofAreaDamageSwitch")
 	{
  	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::NoOutside";
		if($Shifter::NoOutside == false){%Msg = "Enabled Out of Area Damage~wmine_act.wav";
		 ChangeVariabletoItsOpposite(%VariableName, $Shifter::NoOutside, %AdminName, %Msg);}
		else if($Shifter::NoOutside == true){%Msg = "Disabled Out of Area Damage~wmine_act.wav";
		 ChangeVariabletoItsOpposite(%VariableName, $Shifter::NoOutside, %AdminName, %Msg);}
	}
   }
}

function AutoRepair(%fixRate)
{
	for(%i = 8200; %i< 9300; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
		if (%data.className == Generator || %data.className == Station) 
		{					
			//echo(%data,%count);		
			%rate = GameBase::getAutoRepairRate(%i) + %fixrate;	
			GameBase::setAutoRepairRate(%i,%rate);
		}
	}	
}