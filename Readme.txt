   ____        _       ShifterK 8-01-03    _   _         _
  |  _ \  ___ | |  ___   __ _  ___   ___  | \ | |  ___  | |_  ___  ___
  | |_) |/ _ \| | / _ \ / _` |/ __| / _ \ |  \| | / _ \ | __|/ _ \/ __|
  |  _ <|  __/| ||  __/| (_| |\__ \|  __/ | |\  || (_) || |_|  __/\__ \
  |_| \_\\___||_| \___| \__,_||___/ \___| |_| \_| \___/  \__|\___||___/
                    +-------------------------------------------+
 %%%%%%%%%%%%%%%%%%%|%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%|%%%%%%%%
  +-----------------+-----+                                     |
  |                 |     | New Features                        |
  |   @@S@@@     @@@|@@@@ |                                     |
  |    @@@@      @@@|K@   |	In-Game Duel                    |
  |    @@@S     @@@@|     |	Admin Global commands           |
  |    @@@S    @@@@ |  	  |	Less lag during Tourny mode     |
  |    @@@@   @@@@  |     |                                     |
  |    S@@@@ @@@@   |  	  |	 Fixes                          |
  |    S@@@@@@@@    |     |         Save info works.            |
  |    S@@@@@@@     |  	  |         Readable echos.             |
  |    S@@@@@@@     |     |         Console config errors.      |
  |    S@@@@@@@K    +-----|-------------------------------------+
  |    @@@@SS@@@@         |
  |    @@@@@  @@@S        |
  |    @@@@@    @@@       |
  |   @@@@@@    %@@@#     |
  |  @@@@SSSSS   @@@@@%@@ |
  |        +--------------+----------------------------------+
  +--------+What-is-duel?-+ %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%|
           |                                                 |
           |First off, In normal game play (that is, when    |
           |its not in tournment or anything) you press tab, |
           |and then you press on the person you want to     |
           |duel. Once you do that options come up and it    |
           |says "Challege to a duel" and "View duel stats"  |
           |The it asks what armor you wanna challege them   |
           |in, scout, sniper, chem, merc, dread. and if     |        
           |they accpet it. You both go way out of bounds,   |
           |away from anyone...and you duel. when one wins.  |
           |you both go back in game                         |
           |                                                 |
           +-------------------------------------------------+

For those of you who get Shifter_K Base...Read the "How to run dedicated server"
For those of you who cant spawn favs...Read the "How to run dedicated server"
For those of you whose menus close...Read the "How to run dedicated server"


New in 8-1
-------------------
Redid builder so you could talk during it 
Jammers take 2 missiles 
Changed back to old Las cannon
Fixed return flag
Added menu to uneven teams
Made shocks more straight


New in 7-25
-------------------
Re-Organized Admin Menus 
Added Possess torture Option 
Added PDA Access torture Option 
Redid the Strip torture Option to Strip everything including flag 
Added a Drop menu in Termination
Added a Permanent Ban variable in the serverDefaults.cs File 
Re-Did enV's Fastopts message 
Re-did Penis message 
Re-did the kick/ban function to do more
Fixed return flag bug 
Added playerfuncs.cs
Boosted up HyperBlaster a bit, Still worthless
Decreased distance on blaster
Added Private message system 
Added AFK message system
Fixed EMP bug with Shocks
Added Mute Options in Player Funcs
Totally re-did the Equipment options
Able to set or destroy on a Team rather than everything

New in 7-21
----------------------
Weaken fast disc by half 
Chem touch now changes your arrow to green for enemies 
Assassin shockcharges hurt more, throw faster, and explode after 1.5 seconds  
Dart rifle is has slower dart, but faster reload
adds 5 deaths if they try to suicide while satcheled or poisoned
Fixed problem with engineer mines 
announces when a dart hit someone

Added a New variable in shifter_k.cs:
$Shifter::SuicideTimer = "1";

This is the ammount of time before you can suicide, its set at
one to help reduce when a player suicide before getting killed
so they cant be cheap.

I also un-attached the Laser rifle, alot of non-skillful laser
snipers started to whine.

I redid the Shifter Training map, You can now EMP juggs and they wont
shoot HP. also they shoot more than once.

I redid serverconfig, so that it doesnt depend on download.
The variables are now located in serverDefaults.cs
New variables:

$Shifter::noOTurrets = true;  			// Check Offensive Turrets On/Off -- Default: True (On)
$Shifter::Newairbase = true; 			// Toggle New/Old Airbase -- Default: True (New)
$Shifter::Turrets = true; 			// Turrets On/Off -- Default: True (On)
$Shifter::Deployables = true; 			// Deployables On/Off -- Default: True (On)
$Shifter::HelpOn = false;			// Shifter Help On/Off -- Default: False (Off)
$Shifter::Osniping = false;    		        // Offensive Sniping Check On/Off -- Default: False (Off)
$Shifter::Stationdeploy = true;   		// Deploy in Invostation On/Off -- Default: True (On)
$Shifter::Capping = true;  			// Capping Out On/Off -- Default: True (On)
$Shifter::PlayerDamage = true; 		        // Player Damage On/Off -- Default: True (On)
$Shifter::DetsNukesMCS = true; 		        // Nukes,Dets,MCS On/Off -- Default: True (On)
$Cheating::DeployCheck = true;  		// Deploy Cheat Check On/Off -- Default: True (On)
$Shifter::WeakLaserRifle = false;		// Weak is set to 0.010, Whereas normal is 0.014
$Shifter::RedLaserRifle = false; 		// Red laser/Blue laser
$Shifter::AttachedLaserRifle = true;		// Laser travels with weapon.
$Server::PacketRate = "14";     		// Cable Modem rate, Mess with this alittle.
$Server::PacketSize = "300";    		// Cable Modem rate, Mess with this alittle.


What did I change?
Re-Organized Menus 
Fixed blank messages of flag returns and shocks 
Added annoucements to satchel & Duel Re-did Creation of shocks better 
Added options to mess with Itemcounts 
Added option to set deploy speed
Added toggles for certain deployables 
Re-did some Admin Commands 
Added toggles for Player damage and Turret kills
Added support for Shifter Training Maps
Gave Osniping more range 
Added raindance for duel
Fixed New Airbase problem with not be able to use vechicles
Took away dart rifle for chem 
Boosting poison damage
Assassin more prone to lasers 
Assassin Shock charges faster throw rate & added EMP damage & Doubled live time
Added a new menu called ShiferK
New download place at tribeshifter.com
Blaster is stronger
Points for taken away when poisoned
Points given for satchels and taken
Kills given and deaths given when satcheled


Why is there Infinite Spawn in the Zip?
Thats a new updated 1.1 Infinite Spawn - patched up, less crashes
Used for hosting dedicated servers.
Never included in an update for Tribes

Whats the deal with Shifter Training maps?
Well right now the map is buggy, and only has juggbots. But in next release ill have it like it was
on GTC, then ill add more bots, such as capping scouts, detters. Some cool stuff.

Why did you mess with Assassin?
The idea behind doing so much with assassin is to get it played more. Id rather see people snipe
with a lower projectile weapon than a fast one such as laser. Maybe this will convert some people.

I owned in assassin already, now its too easy
Try a dart rifle and a blaster for a new challege, if mastered, both can own.

Why are there .dsc files that I already have in the zip?
Those are fixed .dsc files that I redid so you wont have 20 map error when you
start

I highly suggest peopel take a look at ShifterK help menu, it tells you how to spawn favorites
without an invo, and other FAQ.

If you havent been keeping track of ShifterK... There is a in-game dueling system now.
