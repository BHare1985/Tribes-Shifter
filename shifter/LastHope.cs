//LastHope 1.30 Server Code by Andrew
//http://www.lasthope.us &
//http://www.team5150.com/andrew


// USER DEFINED SECTION
//---------------------------------------

// we should never hit this message, unless they're a cheating d1cc or lagging
$LastHope::RequiredMessage = "YOU NEED THE 1.30 LAST HOPE T1 PATCH TO PLAY ON THIS SERVER:\nhttp://www.lasthope.us\n\n";
$LastHope::ModelMessage = "ONE OF YOUR MODELS FAILED TO VALIDATE";

// models to validate - edit to suit your tastes
$i=-1;

$LastHope::ModelList[$i++] = "flag.dts";
$LastHope::ModelList[$i++] = "invent_remote.dts";
$LastHope::ModelList[$i++] = "mine.dts";
$LastHope::ModelList[$i++] = "radar_small.dts";
$LastHope::ModelListCount = $i++;


// memory blocks - DO NOT TOUCH THESE OR ELSE
$i=-1;

$LastHope::MemoryRanges[$i++] = 0x4F9F30 @ " " @ 0xf8     @ " 1231";
$LastHope::MemoryRanges[$i++] = 0x4ACCC3 @ " " @ 0xf8     @ " 1112";
$LastHope::MemoryRanges[$i++] = 0x414033 @ " " @ 0xf8     @ " 3333";
$LastHope::MemoryRanges[$i++] = 0x4AD149 @ " " @ 0xf8     @ " 1563";
$LastHope::MemoryRanges[$i++] = 0x445F4F @ " " @ 0xf8     @ " 1232";
$LastHope::MemoryRanges[$i++] = 0x417A58 @ " " @ 0xf8     @ " 1212";
$LastHope::MemoryRanges[$i++] = 0x60B6CE @ " " @ 0x20     @ " 6969";
$LastHope::MemoryRangeCount = $i++;

//-- filler - DO NOT TOUCH THESE OR ELSE
$i=-1;

$LastHope::RandomRanges[$i++] = 0x401000 @ " " @ 0x2000  @ " header1";    //header
$LastHope::RandomRanges[$i++] = 0x420000 @ " " @ 0x2000  @ " header2";    //header

// FUNCTIONS
//-----------------------------------

//-- dbz...
function dbecho(%level, %str){}
function remoteK(%cl, %result){%cl.LastHopeResult = %result;}

function LastHope::Kick(%cl, %type) {
	if	(%cl && (Client::GetTransportAddress(%cl) == %cl.LastHopeIP)) {
		BanList::add(%cl.LastHopeIP, 30);
		if (%type == "req")
			%msg = $LastHope::RequiredMessage;
		else if (%type == "mod")
			%msg = $LastHope::ModelMessage;
		Net::Kick(%cl, %msg);
	}
}

function LastHope::Ban(%cl) {
	//faking lasthope results, ban the queer
	LogEntry(%cl, " failed LastHope ("@%cl.LastHopeDesc[0]@":"@%cl.LastHopeAddress[0]@","@%cl.LastHopeDesc[1]@":"@%cl.LastHopeAddress[1]@","@%cl.LastHopeDesc[2]@":"@%cl.LastHopeAddress[2]@")", "", "@");

	//ban the faggot
	%ip = Client::getTransportAddress(%cl);
	%truncated_ip = parseIP(%cl, 4, 18, false);
	$IPBan[$IPBanCount++] = format(%truncated_ip, 20) @ format (%ip, 26) @ Client::getName(%cl) @ " permanently banned by LastHope ("@%cl.LastHopeDesc[0]@":"@%cl.LastHopeAddress[0]@","@%cl.LastHopeDesc[1]@":"@%cl.LastHopeAddress[1]@","@%cl.LastHopeDesc[2]@":"@%cl.LastHopeAddress[2]@").";
	export("IPBan" @ $IPBanCount, "config\\" @ $zAdminBanLogFile, true);

	//goodbye
	BanList::add(%cl.LastHopeIP, 36000);
	Net::Kick(%cl, "");
}

function LastHope::RequiredMessage(%cl) {
	centerPrint(%cl, "<f1><jc>"@$LastHope::RequiredMessage @ "\n<f2>You will be kicked in 30 seconds", 60);
	BanList::add(%cl.LastHopeIP, 30);
	schedule("LastHope::Kick("@%cl@",'req');", 30);
}

function LastHope::BadModels(%cl) {
	centerPrint(%cl, "<f1><jc>ONE OF THE FOLLOWING MODELS DOES NOT MATCH THE SERVER:\n"@%cl.modelList@"\n<f2>You will be kicked in 30 seconds", 60);
	BanList::add(%cl.LastHopeIP, 30);
	schedule("LastHope::Kick("@%cl@",'mod');", 30);
}

// tests a client result
function LastHope::MemoryTest(%cl, %tag) {
	// make sure we're testing the client who actually got sent the request
	if	(
			%cl && 
			(%tag == %cl.LastHopeTag) && 
			(Client::GetTransportAddress(%cl) == %cl.LastHopeIP)
		)
	{
		remoteLH_CHMEM(-1, %cl.LastHopeAddress[0], %cl.LastHopeAddress[1], %cl.LastHopeAddress[2], q);
		
		if (%cl.LastHopeResult == "") {
			%cl.LastHopeRetries++;
			if ( %cl.LastHopeRetries > 4 ) {
				LastHope::RequiredMessage(%cl);
			} else {
				LastHope::ValidateMemory( %cl, false );
			}
			return;
		}
		else if (%cl.LastHopeResult != $k) {
			LastHope::Ban(%cl);
			return;
		}
		
		// cycle through required blocks
		%cl.LastHopeRetries = 0;
		if (%cl.LastHopeBlock < $LastHope::MemoryRangeCount)
			schedule("LastHope::ValidateMemory("@%cl@",true);", 0.5);
		else
			%cl.LastHopeValidating = false;
	}
}

function LastHope::ModelTest(%cl, %tag)
{
	// make sure we're testing the client who actually got sent the request
	if	(
			%cl && 
			(%tag == %cl.LastHopeTag) && 
			(Client::GetTransportAddress(%cl) == %cl.LastHopeIP)
		)
	{
		eval("remoteLH_CHMOD(-1,"@%cl.Validator@",q,"@%cl.ModelList@");");

		if (%cl.LastHopeResult == "")
		{
			%cl.LastHopeRetries++;
			if ( %cl.LastHopeRetries > 4 ) {
				LastHope::RequiredMessage(%cl);
			} else {
				LastHope::ValidateModels(%cl);
			}
			
			return;
		}
		else if ($k != %cl.LastHopeResult) {
			LastHope::BadModels(%cl);
			return;
		}
	
		// if we got this far the models are clean, start the memory checks
		%cl.LastHopeRetries = 0;
		LastHope::ValidateMemory(%cl,true);
	}
}

// starts a new check for a client
function LastHope::ValidateMemory( %cl, %getBlocks ) {
	%cl.LastHopeTag++;
	%cl.LastHopeResult = "";
	%cl.LastHopeIP = Client::GetTransportAddress(%cl);

	if ( %getBlocks ) {
		%cl.LastHopeAddress[0] = LastHope::GetNextBlock(%cl);   %cl.LastHopeDesc[0] = $LastHope::Desc;
		%cl.LastHopeAddress[1] = LastHope::GetRandomAddress();	%cl.LastHopeDesc[1] = $LastHope::Desc;
		%cl.LastHopeAddress[2] = LastHope::GetRandomAddress();  %cl.LastHopeDesc[2] = $LastHope::Desc;
	}
	%validator = (Floor(GetRandom()*8192) + 0x4AD24F) | 2;
	
	//echo("Validating "@%cl@", block="@%cl.LastHopeAddress[0]);
	
	remoteEval(%cl, LH_CHMEM, %cl.LastHopeAddress[0], %cl.LastHopeAddress[1], %cl.LastHopeAddress[2], %validator);
	
	//give them 2 seconds to respond
	schedule("LastHope::MemoryTest("@%cl@","@%cl.LastHopeTag@");", 2);
}


// check the clients models against ours
function LastHope::ValidateModels(%cl)
{
	//-- init
	%cl.LastHopeTag++;
	%cl.LastHopeResult = "";
	%cl.LastHopeIP = Client::GetTransportAddress(%cl);
	
	%cl.ModelList = LastHope::GetModelList();
	%cl.Validator = %validator = (Floor(GetRandom()*8192) + 0x4AD24F) | 2;
	
	%eval = "remoteEval("@%cl@",LH_CHMOD,"@%validator@",18754,"@%cl.ModelList@");";
	eval(%eval);
	eval(%eval);
	
	schedule("LastHope::ModelTest("@%cl@","@%cl.LastHopeTag@");", 2);
}

//-- reset a clients validating state
function LastHope::ResetClient(%cl)
{
	%cl.LastHopeValidating = false;
}

//-- call this to initiate a check sequence
function LastHope::InitClient(%cl, %clIP)
{
	//-- make sure we are testing the same client we originally requested (used to schedule checks on join)
	if (Client::GetTransportAddress(%cl) != %clIP)
		return;

	//-- dont check if we're currently validating
	if (%cl.LastHopeValidating)
		return;
	%cl.LastHopeValidating = true;

	%cl.LastHopeRetries = 0;
	%cl.LastHopeBlock = 0; //block test on
	%cl.LastHopeResult = "";
	%cl.LastHopeTag = getIntegerTime(true) >> 5;

	LastHope::ValidateModels(%cl);
}

function LastHope::PeriodicCheck()
{
	//-- checks for everybody!
	for (%cl=Client::getFirst(); %cl!=-1; %cl=Client::getNext(%cl))
		LastHope::InitClient(%cl, Client::GetTransportAddress(%cl));
	
	//-- every 8 minutes
	Schedule("LastHope::PeriodicCheck();", 8*60);
}


// DATA & RETRIEVAL
//-----------------------------------

// gets the next concerned block
function LastHope::GetNextBlock(%cl) {
	//-- grab the next range pair in the check list
	%pair = $LastHope::MemoryRanges[ %cl.LastHopeBlock++ -1 ];
	
	%start = GetWord(%pair, 0);
	%size = GetWord(%pair, 1);
	$LastHope::Desc = GetWord(%pair, 2);
	
	return (Floor(GetRandom()*%size) + %start);
}

// gets a random filler block, cough
function LastHope::GetRandomAddress() {
	// grab the next range pair in the check list
	%pair = $LastHope::RandomRanges[ Floor(GetRandom()*$LastHope::RandomRangeCount) ];
	
	%start = GetWord(%pair, 0);
	%size = GetWord(%pair, 1);
	$LastHope::Desc = GetWord(%pair, 2);
	
	return (Floor(GetRandom()*%size) + %start);
}

//-- builds a list in the form of:
//   "'Model1.dts', 'Model2.dts', 'Model3.dts'"
function LastHope::GetModelList() {
	%list = "'flagstand.DTS'"; //yeah..
	%modelsToAdd = $LastHope::ModelListCount;
	
	while (%modelsToAdd > 0) {
		%modelIndex = Floor(GetRandom()*$LastHope::ModelListCount);
		if (!%modelAdded[ %modelIndex ]) {
			%modelAdded[ %modelIndex ] = true;
			%list = %list @ ",'" @ $LastHope::ModelList[%modelIndex] @ "'";
			
			%modelsToAdd--;
		}
	}
	
	return %list;
}

//init models..
eval("remoteLH_CHMOD(-1,1024,q,"@LastHope::GetModelList()@");");
