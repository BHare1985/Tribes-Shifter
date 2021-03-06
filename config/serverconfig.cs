//=================================================================================
// Serverconfig.cs
//
//                         Created by: ParoXsitiC & Android
//				Assisted by: Kill(--), Gonzo, Grey & Czar
//                                    Orignal by: Emo
//================================================================================

$Server::HostName = "Shifter 2K5";	// The name of your Server -- Default: Shifterv1G
$Server::MaxPlayers = "16"; 			// Max Players On Your Server -- Default: 20
$Server::timeLimit = "60";			// Mission Time Limit In Minutes -- Default: 240
$Server::Password = "";				// Server Main Password - One that is on when started
$Server::Password2 = "password";		// Server Password  - One that can be issued in-game -- Default: sbamatch
$Server::TeamDamageScale = "1";			// Team Damage On/Off -- Default: 1 (On)


//============================================================================
//                          Public Notices
//============================================================================
                
//	 White Text = <f2>                 
//	 Light Text = <f1>                  
// 	 Normal Text = <f0>                 
// 	 \n = New Line                  

$Shifter::PublicNotice = "";				// This Message will be dispalyed every so ofter as players spawn, leave it null to disable
$Server::Info 	= "<jc><f3>Shifter2K5 "@$Shifterv1G::Version@"\nCreated by: ParoXsitiC & Android\n";
// ^ This is the message displayed when you click info on the server
$Server::JoinMOTD = "<jc><f3>"@$Shifterv1G::Version@"\nCreated by: ParoXsitiC & Android\nCUSTOM FLAG MODELS ARE NO LONGER ALLOWED. HOWEVER, YOU WILL ONLY BE KICKED FOR A SHORT PERIOD FOR MODEL VIOLATIONS "; 
// ^ This is what you see when you first join the server.
$Server::MODInfo 	= "<jc><f0>Shifter2K5 <f2> ::  <f0>Created by:<f2> ParoXsitiC & Android\n<f2><f0>XXXClanTagHERE<f2>   XXXWebsiteHERE <f1>\nGamePlay Changes: <f2>BoosterPop Toggle <f1>-<f2> Match\Scrim Options";
// ^ This is what you see when the server is loading.
$Shifter::WelcomeMsg = "<jc><f2>Welcome to Shifter 2K5\nMOD: Shifter 2K5\nMission: <f0>" @ $missionName @ " <f1>Mission Type: <f0>" @ $Game::missionType @ "\n";
$Shifter::WelcomeDelay = "30";  //== Amount in seconds that the message is shown. If "0" message will not be displayed.

//============================================================================
//                         Networking Options
//============================================================================
$Server::FloodProtectionEnabled = "true";	// Check for chat flooding players
$Server::HostPublicGame = "true";		// List your server with the master list.
$Server::Port = "28001";			// Port To Run Server On
$pref::noIpx = "true";				// Disallow IPX/SPX binding
$Server::respawnTime = "1";			// Time after death to respawn.
$TelnetPort = "28010";				// Telnet port number
$TelnetPassword = "XXX";			// Telnet password
$Console::LogMode = "0"; 	   		// save the console to a logfile, 1 for TRUE
$Shifter::LocalNetMask = "IP:107.5";	//== Local IP's (Assuming you have a LAN connection to the server and are not worried about band width from connecting Lan players, You can increase the limit when a player from this IP Mask connects.



//============================================================================
//                     Team Names and Default Skins
//============================================================================
$Server::teamName0 = "Imperial Knights";	$Server::teamSkin0 = "cphoenix";
$Server::teamName1 = "Blood Eagles";	$Server::teamSkin1 = "swolf";
$Server::teamName2 = "Phoenix";		$Server::teamSkin2 = "beagle";
$Server::teamName3 = "XXXX";		$Server::teamSkin3 = "dsword";
$Server::teamName4 = "XXXXX";		$Server::teamSkin4 = "base";


//============================================================================
//                         Mission Settings
//============================================================================
$pref::LastMission = "CanyonCrusade";	//== Sets the Starting Mission if Random Start Missions are off.
$Shifter::RandomMissions = False;	//== Random Missions on/off
$Shifter::TeamJuggle = 1000;		//== Juggles the teams every X missions
$Server::warmupTime = "20";		//== Mission Start Time (Delay before missions starts)
$Shifter::RandomStart = False;		//== Start server with a Random mission
$Shifter::Refresh = True; 		//== Refresh the server after last player drops 

//============================================================================
//                       Voting Varriables
//============================================================================
$Server::MinVotes = "1";			// Minimum Votes to count
$Server::MinVotesPct = "0.69999"; 		// Percentage of votes needed to pass a vote
$Server::MinVoteTime = "45";			// Time a vote lasts
$Server::VoteFailTime = "30";			// Length Of Votes if people are NOT voting.
$Server::VoteWinMargin = "0.699999";	// Ratio of Yeh to Neh to win vote.
$Server::VotingTime = "20";			// Length Of Votes if people are voting.


//=========================================================================
//                      Advanced Flag Options
//=========================================================================
$Shifter::FlagNoReturn = "True";
$Shifter::FlagReturnTime = "400";

//=========================================================================
//                     Fair Teams Variables
//=========================================================================
$Shifter::KeepBalanced = True; //== Keep Balanced
$Shifter::FairTeams = True; 	 //== Is Fair Teams Is On
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
$Shifter::TeamKillMsg = "You have been kicked and banned for team killing, I hope you enjoyed it. Email:" @ $Shifter::emailAddress @ " for reinstatement.";
$Shifter::emailAddress = "XXX";	//== Email address to show banned users for reinstatement


//===============================================================
//                Score Kick Options
//===============================================================
$Shifter::ScoreTracker = True;		//== Score Tracker = Warns then Kicks players for having bad scores.
$Shifter::CheckScores = 30;		//== How often to check.
$Shifter::WarnScore1 = "-20";		//== 1st Warning
$Shifter::WarnScore2 = "-40";		//== 2nd Warning
$Shifter::WarnScore3 = "-60";		//== 3rd Warning
$Shifter::WarnScoreFinal = "-100";	//== Kick Player For Crappy Score


//===============================================================
//                Automatic Admin Options
//===============================================================
$Server::AdminPassword = "tickle";  	   // This is the password people can say VIA chat to get admin
$Server::SuperAdminPassword = "pickle";      // This is the password people can say VIA chat to get superadmin
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
addsad("+NET+Android", "modder", 1, "70.25");

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
$Server::Master1 = "t1m1.masters.tribesmasterserver.com:28000 t1m1.pu.net:28000 t1m1.tribes0.com:28000 skbmaster.ath.cx:28000 kigen.ath.cx:28000 t1m1.masters.dynamix.com:28000";
$Server::MasterAddressN0 = "t1m1.masters.tribesmasterserver.com:28000 t1m1.pu.net:28000 t1m1.tribes0.com:28000 skbmaster.ath.cx:28000 kigen.ath.cx:28000 t1m1.masters.dynamix.com:28000";
$Server::MasterName0 = "US Tribes Master";
$Server::Master2 = "IP:BROADCAST:28001";
$Server::XLMaster1 = "IP:198.74.38.23:28000";
$Server::XLMaster2 = "IP:Broadcast:28001";
$Server::XLMasterN0 = "IP:66.39.167.52:28000";
$Server::XLMasterN1 = "IP:209.223.236.114:28000";
$Server::XLMasterN2 = "IP:173.26.99.132:28000";
$Server::XLMasterN3 = "IP:216.249.100.66:28000";
$Server::XLMasterN4 = "IP:75.126.191.58:28000";
$Server::MasterAddress0 = "IP:tribes.dynamix.com:28000";
$Server::MasterAddressN1 = "t1ukm1.masters.dynamix.com:28000 t1ukm2.masters.dynamix.com:28000 t1ukm3.masters.dynamix.com:28000";
$Server::MasterAddressN2 = "t1aum1.masters.dynamix.com:28000 t1aum2.masters.dynamix.com:28000 t1aum3.masters.dynamix.com:28000";
$Server::MasterName1 = "UK Tribes Master";
$Server::MasterName2 = "Australian Tribes Master";
//==========================================================
//=== These are for Debug - Do not change these lines
//$Shifter::ObjScore = "";				// Allow Objects Being Destroyed To Award Bonus Points
//$Shifter::PlrScore = "";				// Allow Player Bonus Points To Be Awarded
$Debug = "False";

