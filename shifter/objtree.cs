//============================================================
// This file has functions that allow you to check weather a 
// teams power is down.
//============================================================
function DumpObjectTree()
{
	echo ("DUMPING OBJECT TREE");
	
	%c = 0;
	$PObjList = 0;
	
	for(%team=0;%team < 9;%team++)
	{
		%count[%team] = 0;
		%counts[%team] = 0;
	}
		
		
	for(%object = 8205; (%object < 12000); %object++)
	{
		if (GameBase::getDataName(%object) != "")
		{
			%name = GameBase::getDataName(%object);
			%team = GameBase::getTeam(%object);		  
			%objtype = getObjectType(%object);
			%objname = (GameBase::getDataName(%object));

			if (%objtype != "" && %team != "-1")
			{
				%tc = %count[%team];
				%ts = %counts[%team];
				if (%objname == "Generator")		{$PObj[%tc,%team] = %object;} //echo ("Gen "@ %team @ " " @ %tc); %count[%team]++;}
				else if (%objname == "SolarPanel")	{$PObj[%tc,%team] = %object;} //echo ("Sol "@ %team @ " " @ %tc); %count[%team]++;}
				else if (%objname == "PortGenerator")	{$PObj[%tc,%team] = %object;} //echo ("PGn "@ %team @ " " @ %tc); %count[%team]++;}

				if (%objname == "PulseSensor")			{$SObj[%ts,%team] = %object;} //echo ("LRd "@ %team @ " " @ %ts); %counts[%team]++;}
				else if (%objname == "MediumPulseSensor")	{$SObj[%ts,%team] = %object;} //echo ("SRd "@ %team @ " " @ %ts); %counts[%team]++;}
				else if (%objname == "DeployablePulseSensor")	{$SObj[%ts,%team] = %object;} //echo ("DRd "@ %team @ " " @ %ts); %counts[%team]++;}
			}
		}
	}
	
	schedule ("DumpObjectTree();", 360);
}

function CheckObjectTree()
{
	for (%t = 0; %t < getNumTeams(); %t++)
	{
		echo ("Checking Team " @ %t);
		
		for (%tc = 0; $PObj[%tc,%t] != ""; %tc++)
		{
			echo ("Object on team " @ %tc @ " - " @ %t @ " = " @ $PObj[%tc,%t]);
		}
	}
}

function ClearObjectTree()
{
	for (%t = 0; %t < 9; %t++)
	{
		for (%tc = 0; %tc < 20; %tc++)
		{
			$PObj[%tc,%t] = "";
		}
	}
}

function IsPowerDown(%t)
{
	if ($debug) echo ("Checking Team " @ %t);
	
	if(!$matchStarted || $matchStarting)
		return True;
	
	for (%tc = 0; $PObj[%tc,%t] != ""; %tc++)
	{
		%object = $PObj[%tc,%t];
		if (GameBase::getDamageState(%object) == "Enabled")
		{
			echo ("Team " @ %t @ "'s power is up. ");
			return True;
		}
	}
	
	if (!%tc || %tc < 1)
	{
		echo ("Team " @ %t @ " has no power units to check. ");
		return True;
	}
	echo ("Team " @ %t @ "'s power is down ");
	return False;
}

function IsNetWorkDown(%t)
{
	if ($debug) echo ("Checking Team " @ %t);
		
	for (%tc = 0; $SObj[%tc,%t] != ""; %tc++)
	{
		%object = $SObj[%tc,%t];
		if (GameBase::getDamageState(%object) == "Enabled")
		{
			//echo ("Team " @ %t @ "'s network is up. ");
			return True;
		}
	}
	
	if (!%tc || %tc < 1)
	{
		//echo ("Team " @ %t @ " has no sensors to check. ");
		return True;
	}
	//echo ("Team " @ %t @ "'s sensors are down.");
	return False;
}
