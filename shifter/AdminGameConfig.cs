//========================================================================================================
//
//					     Game Config
//
//========================================================================================================

function processMenuGameConfig(%clientId, %Choice)
{ 
   // if(%clientId.isSuperAdmin)
  // {
 
   	if(%Choice == "ChangeTimeLimit")
   	{
      	  Client::buildMenu(%clientId, "Change Time Limit:", "CTLimit", true);
      	  Client::addMenuItem(%clientId, "110 Minutes", 10);
      	  Client::addMenuItem(%clientId, "215 Minutes", 15);
      	  Client::addMenuItem(%clientId, "320 Minutes", 20);
      	  Client::addMenuItem(%clientId, "425 Minutes", 25);
      	  Client::addMenuItem(%clientId, "530 Minutes", 30);
      	  Client::addMenuItem(%clientId, "645 Minutes", 45);
      	  Client::addMenuItem(%clientId, "760 Minutes", 60);
      	  Client::addMenuItem(%clientId, "8No Time Limit", 0);
      	 return;
  	}
  	else if (%Choice == "ScoringOptionsMenu")
	{
	 %curItem = 0;
       	    Client::buildText(%clientId, "Scoring Options:", "ScoringMenu", true);
        	if ($Shifter::Capping == "true")
		  Client::addMenuItem(%clientId, %curItem++ @ "Disable Captures", "CapOut");
 		else
		  Client::addMenuItem(%clientId, %curItem++ @ "Enable Captures", "CapOut");
         	if ($Shifter::UnlimitedCapping == "true")
 		  Client::addMenuItem(%clientId, %curItem++ @ "Disable Unlimited Captures", "UnCap");
	 	else
	 	  Client::addMenuItem(%clientId, %curItem++ @ "Unlimited Captures", "UnCap");
   		if ($Objscoring == "true")
		  Client::addMenuItem(%clientId, %curItem++ @ "Disable Objective scoring", "ObjScore");
	 	else
		  Client::addMenuItem(%clientId, %curItem++ @ "Enable Objective scoring", "ObjScore");
	   	if ($Flag::ManualReturn == "true")
		  Client::addMenuItem(%clientId, %curItem++ @ "Enable Auto Flag Return", "FlagReturn");
		else
		  Client::addMenuItem(%clientId, %curItem++ @ "Enable Manual Flag Return", "FlagReturn");      
	}
	else if (%Choice == "ItemsOptionsMenu")
	{
	  %curItem = 0;
       	     Client::buildText(%clientId, "Item Options:", "ItemMenu", true);
       		Client::addMenuItem(%clientId, %curItem++ @ "Reset Items", "ResetItems");
       		Client::addMenuItem(%clientId, %curItem++ @ "Max Items", "MaxItems");
             if ($Shifter::Osniping)
 		Client::addMenuItem(%clientId, %curItem++ @ "Enable Offensive sniping", "OffensiveSnipingSwitch");
 	     else
 		Client::addMenuItem(%clientId, %curItem++ @ "Disable Offensive sniping", "OffensiveSnipingSwitch");
 	}
 
	else if (%Choice == "fairteams")
	{
 	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::FairTeams";
		if($Shifter::FairTeams == true){%Msg = "Turned off Fair teams.~wmine_act.wav";
	 	  ChangeVariabletoItsOpposite(%VariableName, $Shifter::FairTeams, %AdminName, %Msg);}
		else if($Shifter::FairTeams == false){%Msg = "Made Teams Fair.~wmine_act.wav";
	   	  ChangeVariabletoItsOpposite(%VariableName, $Shifter::FairTeams, %AdminName, %Msg);}
	}
	else if (%Choice == "ReturnTheFlags")
	{
	ReturnAllFlags();
	messageAll(1, Client::getName(%clientId) @ " Returned all flags.~wmine_act.wav");
	}
   //}
}

//========================================================================================================
//
//					     Scoring Config
//
//========================================================================================================

function processMenuScoringMenu(%clientId, %Choice)
{
	if(%Choice == "CapOut")
  	{
 	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::Capping";
		if($Shifter::Capping == true){%Msg = "Disabled Flag Captures.~wmine_act.wav";
	 	  ChangeVariabletoItsOpposite(%VariableName, $Shifter::Capping, %AdminName, %Msg);}
		else if($Shifter::Capping == false){%Msg = "Enabled Flag Captures.~wmine_act.wav";
	   	  ChangeVariabletoItsOpposite(%VariableName, $Shifter::Capping, %AdminName, %Msg);}
	}
	else if(%Choice == "ObjScore")
	{
	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Objscoring";
		if($Objscoring == true){%Msg = "Disabled Objective scoring~wmine_act.wav";
	 	  ChangeVariabletoItsOpposite(%VariableName, $Objscoring, %AdminName, %Msg);}
		else if($Objscoring == false){%Msg = "Enabled Objective scoring~wmine_act.wav";
	   	  ChangeVariabletoItsOpposite(%VariableName, $Objscoring, %AdminName, %Msg);}
	}
  	else if(%Choice == "UnCap")
   	{
   	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::UnlimitedCapping";
		if($Shifter::UnlimitedCapping == true){%Msg = "Disabled Unlimited Captures.~wmine_act.wav";
	 	  ChangeVariabletoItsOpposite(%VariableName,$Shifter::UnlimitedCapping, %AdminName, %Msg);}
		else if($Shifter::UnlimitedCapping == false){%Msg = "Enabled Unlimited Captures.~wmine_act.wav";
	   	  ChangeVariabletoItsOpposite(%VariableName,$Shifter::UnlimitedCapping, %AdminName, %Msg);}
	}
	else if(%Choice == "FlagReturn")
 	{
 	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Flag::ManualReturn";
		if($Flag::ManualReturn == true){%Msg = "Enabled Auto Flag Return~wmine_act.wav";
	 	  ChangeVariabletoItsOpposite(%VariableName, $Flag::ManualReturn, %AdminName, %Msg);}
		else if($Flag::ManualReturn == false){%Msg = "Enabled Manual Flag Return~wmine_act.wav";
	   	  ChangeVariabletoItsOpposite(%VariableName, $Flag::ManualReturn, %AdminName, %Msg);}
	}	
}


function processMenuItemMenu(%clientId, %Choice)
{
 	if (%Choice == "ResetItems")
	{
	  %curItem = 0;
	  Client::buildText(%clientId, "Reset Options:", "ItemMenu", true);
              Client::addMenuItem(%clientId, %curItem++ @ "Reset All Items", "ResetAllItems");
              Client::addMenuItem(%clientId, %curItem++ @ "Reset Det,Nuke,MSC Count", "ResetDNM");
	}
		else if(%Choice == "ResetAllItems")
       		{
		%ResetCMD = All;
		Items::On(%ResetCMD);
 		messageAll(1, Client::getName(%clientId) @ " Reset All Items.~wmine_act.wav");
		}
		else if(%Choice == "ResetDNM")
		{
		$Shifter::DetsNukesMCS = true;
		%ResetCMD = DNM;
		Items::On(%ResetCMD);
 		messageAll(1, Client::getName(%clientId) @ " Reset the Nuke, Det, MCS Count.~wmine_act.wav");
 		}
        else if (%Choice == "MaxItems")
	{
	  %curItem = 0;
          Client::buildText(%clientId, "Max Options:", "ItemMenu", true);
          	Client::addMenuItem(%clientId, %curItem++ @ "Max All Items", "MaxAllItems");
                Client::addMenuItem(%clientId, %curItem++ @ "Max Det,Nuke,MSC Count", "MaxNDM");
        }
		else if(%Choice == "MaxAllItems")
		{
		%MaxCMD = All;
		Items::Off(%MaxCMD);
 		messageAll(1, Client::getName(%clientId) @ " Maxed All Items.~wmine_act.wav");
		}
		else if(%Choice == "MaxNDM")
		{
		$Shifter::DetsNukesMCS = false;
		%MaxCMD = DNM;
		Items::Off(%MaxCMD);
 		messageAll(1, Client::getName(%clientId) @ " Maxed Nuke, Det, MCS Count.~wmine_act.wav");
		}            
	else if(%Choice == "OffensiveSnipingSwitch")
     	{
     	  %adminName = Client::getName(%clientId);
	  %VariableName = "$Shifter::Osniping";
		if($Shifter::Osniping == true){%Msg = "Enabled Offensive sniping.~wmine_act.wav";
	 	  ChangeVariabletoItsOpposite(%VariableName,$Shifter::Osniping, %AdminName, %Msg);}
		else if($Shifter::Osniping == false){%Msg = "Disabled Offensive sniping.~wmine_act.wav";
		  OffensiveSniping();
	   	  ChangeVariabletoItsOpposite(%VariableName,$Shifter::Osniping, %AdminName, %Msg);}
      	}  
}