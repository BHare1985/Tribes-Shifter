function SHLoadBanList()
{
	//EvalSearchPath();
	exec(SHBanList @ $Server::Port);
	echo("Ban List Loaded");
}

function SHSaveBanList()
{
   export("$SHBanList*", "config\\SHBanList" @ $Server::Port @ ".cs", False);
	if ($debug) echo("Ban List Saved");
}

function SHKickClient(%clientid)
{
	KickPlayer(%clientid,"You are banned from this server");
}

function SHBan(%addr)
{
	for(%i=0;$SHBanList[%i] != "";%i++)
	{
	}
	$SHBanList[%i] = %addr;
	SHSaveBanList();
}

function SHBanReset()
{
	for(%i=0;%i != "100";%i++)
	{
		$SHBanList[%i] = "";
	}
	SHSaveBanList();
}


function SHCheckTransportAddress(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);
	if ($debug) echo(%clientid @ " <- " @ %addr);

	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
		return;

	if(String::getSubStr(%addr,0,3) != "IP:" && String::getSubStr(%addr,0,4) != "IPX:")
	{
		if ($debug) echo(%clientid @ " is not correct address form, kicking");
		schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			if ($debug) echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",20,%clientid);
			return;
		}
	}
}

function SHclearBanlist()
{
    for(%i=1;$SHBanList[%i] != "";%i++)
    {
        $SHBanList[%i-1] = "";
    }
    $SHBanList[%i-1] = "";
    //EvalSearchPath();
    // exec("PermaBan.cs");    // use this line if you want to have 'certain' clients banned always
    SHSaveBanList();
    if ($debug) echo("*** banlist cleared ***");
}

SHLoadBanList();
if ($debug) echo("SHBan Loaded.");
