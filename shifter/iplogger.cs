// props to plas
function server::ConnectInfo(%client)
{
	%ip = Client::getTransportAddress(%client);


	%ip = String::ReplaceStr(%ip, ".", ":");
    %ip = string::getsubstr(%ip, 3, (String::len(%ip) - 8) );
	%clname = client::getName(%client);
    $ClientsName = %clname;
	%nameString = %clname;
	if(!string::ICompare($kinfo::[%ip],"") == 1)
	{
		echo("*********No existing name, adding new name");
		$kinfo::[%ip] = %clname;
		%export = "$kinfo::"@%ip;
		export(%export, "config\\KSmurf.cs", true);
		%adminmessage = %clname@"'s IP hasn't connected before.";
	}
	else
	{

		if(!string::ICompare($kinfo::[%ip],%clname) == 1)
		{
			%adminmessage = %clname@" Has connected before, only one name saved for this IP.";
			%names = %namestring;
            echo("********Found an existing name");

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
					%adminmessage = %clname@"'s IP Has connected before with another name. Check his ip";
                    //messageall(0, %clname @ " is or has been a Smurf...The name(s) he has used are: " @ %names @ "~wmine.wav");
                    centerprintall("If you have had your name changed...and it still says your a smurf..Ask the admin to clear your name.", 20);
				}
				else
				{
					echo("******Adding new name to list");
					$kinfo::[%ip] = %clname@"~"@$kinfo::[%ip];
					%export = "$kinfo::"@%ip;
					export(%export, "config\\KSmurf.cs", true);
					%adminmessage = %clname@"'s IP Has connected before with a different name, adding this one to ksmurf.cs";
                   // messageall(0, %clname @ " is or has been a Smurf...The name(s) he has used are: " @ %names @ "~wmine.wav");
                    centerprintall("If you have had your name changed...and it still says your a smurf..Ask the admin to clear your name.", 20);
    }
			}
			else
			{
				echo("********Adding 2nd name to list");
				$kinfo::[%ip] = %clname@"~"@$kinfo::[%ip];
				%export = "$kinfo::"@%ip;
				export(%export, "config\\KSmurf.cs", true);
				%adminmessage = %clname@"'s IP Has connected before with 2 different names, adding this one to ksmurf.cs";
				%names = %namestring;
               // messageall(0, %clname @ " is or has been a Smurf...The name(s) he has used are: " @ %names @ "~wmine.wav");
                centerprintall("If you have had your name changed...and it still says your a smurf..Ask the admin to clear your name.", 20);
			}
		}
	}
	%adminmessage = %ip@" "@%adminmessage;
	echo(%adminmessage);
	Server::BPAdminMessage(%adminmessage);
	%client.names = %names;
    helpadmin();
}

function helpadmin()
{
 // this will help the admin make his choice
  if(string::getSubStr(%adminmessage, "with "))
  {
 Server::BPAdminMessage("If this is the players new or correct name please go to ksmurf.cs and delete his old names");
 }
 }
function compactIpLog()
{
	// This will clean up IP log, and sort by address. -Plasmatic

    exec(KSmurf);
	export("$kinfo::*", "config\\KSmurf.cs", false);

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
