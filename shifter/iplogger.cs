// props to plas
function server::ConnectInfo(%client)
{
	%ip = Client::getTransportAddress(%client);
	%ip = String::ReplaceStr(%ip, ".", ":");
    	%ip = string::getsubstr(%ip, 3, (String::len(%ip) - 8) );
	%tempip = String::ReplaceStr(%ip, ":", " ");
    	%firstnumbers = getWord(%tempip, 0);
    	%secondnumbers = getWord(%tempip, 1);
    	%maskedip = %firstnumbers@":"@%secondnumbers@":";
	%clname = client::getName(%client);
    	$ClientsName = %clname;
	%nameString = %clname;
	%badname = String::findSubStr($Cheating::NofogBotNames, %clname);
	if(%badname == -1 && $Cheating::Nofog == "true")
	AddConnectingPlayerToBots(%clname);
	if(!string::ICompare($kinfo::[%ip],"") == 1)
	{
		%client.firstConnect = true;
		echo("No existing name, adding new name");
		$kinfo::[%ip] = %clname;
		%export = "$kinfo::"@%ip;
		export(%export, "config\\SmurfLog.cs", true);
		%adminmessage = %clname@"'s IP hasn't connected before.";
	}
	else
	{

		if(!string::ICompare($kinfo::[%ip],%clname) == 1)
		{
			%adminmessage = %clname@" Has connected before, only one name saved for this IP.";
			%names = %namestring;
            echo("Found an existing name");

		}
		else
		{
			if(String::findSubStr(%nameString, "~") > 0)
			{
				//check other names here.. code gnomes, do your work..
				%names = String::ReplaceStr(%namestring, "~", ", ");
				if(string::findSubStr(%nameString, %clname) != -1)
				{
					echo("*******Found clients name");
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;
				}
				else
				{
					echo("******Adding new name to list");
					$kinfo::[%ip] = %clname@"~"@$kinfo::[%ip];
					%export = "$kinfo::"@%ip;
					export(%export, "config\\SmurfLog.cs", true);
					%adminmessage = %clname@"'s IP Has connected before as: "@%names;
    }
			}
			else
			{
				echo("********Adding 2nd name to list");
				$kinfo::[%ip] = %clname@"~"@$kinfo::[%ip];
				%export = "$kinfo::"@%ip;
				export(%export, "config\\SmurfLog.cs", true);
				%adminmessage = %clname@"'s IP Has connected before as: "@%namestring;	
				%names = %namestring;
			}
		}
	}
	%adminmessage = %ip@" "@%adminmessage;
	//echo(%adminmessage);
	Server::BPAdminMessage(%adminmessage);
	%client.names = %names;
    helpadmin();
}

function helpadmin()
{
 // this will help the admin make his choice
  if(string::getSubStr(%adminmessage, "with "))
  {
 Server::BPAdminMessage("If this is the players new or correct name please go to SmurfLog.cs and delete his old names");
 }
 }
function compactIpLog()
{
	// This will clean up IP log, and sort by address. -Plasmatic

    exec(SmurfLog);
	export("$kinfo::*", "config\\SmurfLog.cs", false);

}


function Server::BPAdminMessage(%adminmessage)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		if(%cl.isSuperAdmin || %cl.isAdmin)
		{
			bottomprint(%cl, "<jc><f1>"@%adminmessage, 20);
			if(%cl.weaponHelp)
			{
				%cl.weaponHelp = false;
				schedule(%cl @ ".weaponHelp = true;" ,5);
			}
		}
	}
}   function String::ReplaceStr(%string, %search, %replace)

{
	%len = AnnStrLen(%search);
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
		if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	}
	return %string;
}
function AnnStrLen(%string)
 {
  for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++;
  return %length;
 }
