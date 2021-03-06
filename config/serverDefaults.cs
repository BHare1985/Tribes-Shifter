//====================================================================
// 		Shifter variables
// Note: It is recommended to announce when you change any of the below,
// for as this is what people expect from this MOD.
//====================================================================

$Shifter::BoosterPopping = true;	//== Booster Spray, may LAG server a bit
$Shifter::AmmoBoom = True;		//== Players ammo can blow up when killed 
$Shifter::Weapons = True;		//== Advanced Weapon Options On
$Shifter::LockOn = True;		//== Stinger Missle Locks Available
$Shifter::SpawnRandom = True;		//== Turn on Random Spawn Setup?
$Shifter::NoOutside = True;		//== Turn on Outside of mission area damage
$Shifter::TurretKill = True;		//== Turret Kills Count For Player
$Shifter::PersonalSkin = True;		//== Personal Skins On or Off
$Shifter::TwoMinute = "True";		//== Two Minute Warning Notice On/Off (Default = True)
$Shifter::LooseScore = 1.00;		//== This is the score ratio for the loosing team. 0.5 for instance would cut a loosing players score by half.
$Shifter::Guided = True;		//== Allow Guided Missile Stations in game?
$Shifter::SpawnType = "Random"; 	//== Must be 'Standard' or 'Random'
$Shifter::SpawnSafe = "10";   		//== If the player is killed before X - Only Half Points Are Awarded.
$Shifter::SaveOn = True;		//== Allow players to save thier profiles.
$Shifter::SpawnFavs = True;		//== Allow spawn faves
$Shifter::EngHealAll = True;		//== Engineers touch heals objects.
$Shifter::SwitchPerm = True;		//== Admin Team Changing Players Is Perminant
$Shifter::NoSwearing="false"; 		//== True means disallow swearing on your server? (update the SHBadwordlist.cs file)
$Shifter::BadWordsMax=3; 		//== If no swearing, This value is the limit at which the client starts being killed for swearing
$Shifter::BadWordskick=4; 		//== If no swearing, This value is the limit at which the client is kicked for swearing
$Shifter::VoteDTD = True;		//== Allow Team Damage Disable Vote
$Shifter::VoteKick = True;		//== Allow Vote to kick
$Shifter::VoteAdmin = False;		//== Can players initiate vote to admin
$Shifter::Reactions = True;		//-- Damage knocks player back
$Shifter::HackedTime = 90;		// -- Time hacked items will remain hacked. 0 = Must be hacked back... - Defults To 90
$Shifter::HackTime = 5;			// -- Length Of Time To Complete Hacking - Defaults To 5
$Shifter::HackLock = 90;		// -- Legth of time a hacked item will be disabled for after being hacked. - Defaults To 0
$Shifter::LaserMineLive = 5;		// -- Live Time For Laser Mines - Defaults To 5 Seconds
$Shifter::ItemLimit = True;		// -- Makes it so that ONLY the armors that can buy a given item can see it in the invo list.
$Shifter::DetPackLimit = 15;		// -- Limit of DetPacks per match
$Shifter::NukeLimit = 15;		// -- Limit of Nukes per match
$Shifter::HeadShot = 10;		//== Bonus for Head Shots
$Shifter::KillTime = 120;		//== Starting timer for kill -vs- live time bonuses, the longer a player lives the higher the bonus. Bonus counting does not start UNTIL this many seconds after player spawns.
// ================================================
// 	Shifter 2K5 Variables
// ================================================
$Shifter::noOTurrets = true;  			// Check Offensive Turrets On/Off -- Default: True (On)
$Shifter::Newairbase = true; 			// Toggle New/Old Airbase -- Default: True (New)
$Shifter::Turrets = true; 			// Turrets On/Off -- Default: True (On)
$Shifter::Deployables = true; 			// Deployables On/Off -- Default: True (On)
$Shifter::HelpOn = false;			// Shifter Help On/Off -- Default: False (Off)
$Shifter::Osniping = false;    		        // Offensive Sniping Check On/Off -- Default: False (Off)
$Shifter::Stationdeploy = true;   		// Deploy in Invostation On/Off -- Default: True (On)
$Shifter::PlayerDamage = true; 		        // Player Damage On/Off -- Default: True (On)
$Shifter::DetsNukesMCS = true; 		        // Nukes,Dets,MCS On/Off -- Default: True (On)
$Shifter::WeakLaserRifle = false;		// Weak is set to 0.010, Whereas normal is 0.014
$Shifter::RedLaserRifle = false; 		// Red laser/Blue laser
$Shifter::AttachedLaserRifle = false;		// Laser travels with weapon.
$Shifter::SuicideTimer = "0";			// Seconds before they can Ctrl K
$Shifter::KickMessage = "Go away Idiot!";	// Center print player sees before being kicked
$Cheating::Ban = false;				// Ban anyone who brings up the cheat message 5 times
$Cheating::DeployCheck = true;  		// Deploy Cheat Check On/Off -- Default: True (On)
$Server::AutoAssignTeams = "true";		// Places players on teams automatically
$Server::PacketRate = "14";     		// Cable Modem rate, Mess with this alittle.
$Server::PacketSize = "300";    		// Cable Modem rate, Mess with this alittle.


// ================================================
// 		New Shifter 2K5 Variables
// ================================================

$Flag::ManualReturn = "True";			// True -  Manaual Flag return || False - Auto Return
$Flag::TimeTeamcanHold = 120;			// Time a player can hold the flag until its returned.
$Duel::DamageDelay = 2.0;			// Time before damage can be done in the In-game Duelfa
$Shifter::1secPlastique = true;			// Allow chem 1 second plastique
$Shifter::PowerCheck = false;//buggy		//== If True - Spawns players in Standard armor if power is down
$Shifter::ComChat = false;			// If true =   Players can't use teamchat or commands with sensors down
$Shifter::SafeBase = false;			// Undestroyable Generators and stations
$Shifter::BaseHeal = false;			// Base heals itself
$Shifter::BaseRepairRate = 0.025;		// How Fast Base Repairs itself - Repairgun = 0.1 , instant = 1.0
$Shifter::UnlimitedCapping = false;  		// Capping Out On/Off -- Default: False (Off)
$Shifter::Capping = true;  			// Capping On/Off -- Default: True (On)
$Server::JetEffect = false;  			// Different Jet Effects
$Server::Smurf = false;//buggy			// Smurf Detection
$Server::MuteSP = false;			// Mute Soundpacks
$Server::SuicideCountasDeath = false;		// Do Suicides count as a death
$Cheating::UsageCheck = false;  		// Scheduled Use Cheat Check On/Off -- Default: True (On)
$Cheating::AutoJJCheck = true;  		// Auto JJ Cheat Check On/Off -- Default: True (on)
$Cheating::Nofog = false;//buggy		// Spawn Bots under the Map to make fake Arrows
$Cheating::NofogBots = "8";			// How many Orignal Bots do you want to start with
$Cheating::NofogBotNames = "enV.3zer0 KiLL(--) GonzoTheClown GreyFlcn Plasmica Czar FuckingCheater NoFogLoser";
// Make sure the above the names are the same as the number of Fogbots, 8 Names, 8 Bots

// ================================================
// 		Permanent Bans
// ================================================
// This can be used for a Tag or a Name ban
// If any client has this in their name, they are banned.
