
//==========================================================================================================================================
// The following bot configurations should be used ONLY by admins who know what they are doing... This can seriously mess up the way the
// bots in Shifter/Spoon Bots work... Please make very sure of what you are doing before you alter any of these settings!!!
//==========================================================================================================================================


//================================= The following weapons are for what the bot will use when the enemy is...
//================================= The Pack is the pack that the bot will have mounted.
//================================= All items listed here **MUST** be listed in the particular bots inventory below...

//=========================== Guard Gear
$Spoonbot::GuardMArmor  = "harmor";
$Spoonbot::GuardFArmor  = "harmor";
$Spoonbot::GuardGear[0] = "mortar";			$Spoonbot::GuardAmmo[0] = "1";
$Spoonbot::GuardGear[1] = "mortarammo";		$Spoonbot::GuardAmmo[1] = "500";
$Spoonbot::GuardGear[2] = "chaingun";		$Spoonbot::GuardAmmo[2] = "1";
$Spoonbot::GuardGear[3] = "bulletammo";		$Spoonbot::GuardAmmo[3] = "50000";
$Spoonbot::GuardGear[4] = "";

$Spoonbot::GuardClose = "chaingun"; 
$Spoonbot::GuardLong  = "mortar";
$SpoonBot::GuardJet   = "chaingun";
$Spoonbot::GuardPack  = "";

//=========================== Demo Gear
$SpoonBot::DemoMArmor  = "marmor";
$SpoonBot::DemoFArmor  = "mfemale";
$SpoonBot::DemoGear[0] = "plasma";			$Spoonbot::DemoAmmo[0] = "1";
$SpoonBot::DemoGear[1] = "plasmaammo";		$Spoonbot::DemoAmmo[1] = "500";
$SpoonBot::DemoGear[2] = "disclauncher";	$Spoonbot::DemoAmmo[2] = "1";
$SpoonBot::DemoGear[3] = "discammo";		$Spoonbot::DemoAmmo[3] = "500";
$SpoonBot::DemoGear[4] = "grenade";			$Spoonbot::DemoAmmo[4] = "1";
$SpoonBot::DemoGear[5] = "grenadeammo0";	$Spoonbot::DemoAmmo[5] = "500";
$SpoonBot::DemoGear[6] = "";

$Spoonbot::DemoClose = "plasma";
$Spoonbot::DemoLong  = "disclauncher";
$SpoonBot::DemoJet   = "disclauncher";
$Spoonbot::DemoPack  = "";

//=========================== Medic Gear
$SpoonBot::MedicMArmor  = "larmor";
$SpoonBot::MedicFArmor  = "lfemale";
$SpoonBot::MedicGear[0] = "blaster";		$Spoonbot::MedicAmmo[0] = "1";
$SpoonBot::MedicGear[1] = "disclauncher";	$Spoonbot::MedicAmmo[1] = "1";
$SpoonBot::MedicGear[2] = "discammo";		$Spoonbot::MedicAmmo[2] = "500";
$SpoonBot::MedicGear[3] = "repairkit";		$Spoonbot::MedicAmmo[3] = "15";
$SpoonBot::MedicGear[4] = "repairpack";		$Spoonbot::MedicAmmo[4] = "1";
$SpoonBot::MedicGear[5] = "";

$Spoonbot::MedicClose = "plasma";
$Spoonbot::MedicLong  = "blaster";
$SpoonBot::MedicJet   = "blaster";
$Spoonbot::MedicPack  = "repairpack";

//=========================== Miner Gear
$SpoonBot::MinerMArmor  = "larmor";
$SpoonBot::MinerFArmor  = "lfemale";
$SpoonBot::MinerGear[0] = "blaster";		$Spoonbot::MinerAmmo[0] = "1";
$SpoonBot::MinerGear[1] = "disclauncher";	$Spoonbot::MinerAmmo[1] = "1";
$SpoonBot::MinerGear[2] = "discammo";		$Spoonbot::MinerAmmo[2] = "500";
$SpoonBot::MinerGear[3] = "repairpack";		$Spoonbot::MinerAmmo[3] = "1";
$SpoonBot::MinerGear[4] = "repairkit";		$Spoonbot::MinerAmmo[4] = "10";
$SpoonBot::MinerGear[5] = "";

$Spoonbot::MinerClose = "disclauncher";
$Spoonbot::MinerLong  = "disclauncher";
$SpoonBot::MinerJet   = "blaster";
$Spoonbot::MinerPack  = "";

//=========================== Sniper Gear
$SpoonBot::SniperMArmor  = "larmor";
$SpoonBot::SniperFArmor  = "lfemale";
$SpoonBot::SniperGear[0] = "plasma";		$Spoonbot::SniperAmmo[0] = "1";
$SpoonBot::SniperGear[1] = "plasmaammo";	$Spoonbot::SniperAmmo[1] = "500";
$SpoonBot::SniperGear[2] = "LaserRifle";	$Spoonbot::SniperAmmo[2] = "1";
$SpoonBot::SniperGear[3] = "energypack";	$Spoonbot::SniperAmmo[3] = "1";
$SpoonBot::SniperGear[4] = "";

$Spoonbot::SniperClose = "plasma";
$Spoonbot::SniperLong  = "LaserRifle";
$SpoonBot::SniperJet   = "LaserRifle";
$Spoonbot::SniperPack  = "energypack";

//=========================== Painter Gear
$SpoonBot::PainterMArmor  = "larmor";
$SpoonBot::PainterFArmor  = "lfemale";
$SpoonBot::PainterGear[0] = "targeting";	$Spoonbot::PainterAmmo[0] = "1";
$SpoonBot::PainterGear[1] = "plasma";		$Spoonbot::PainterAmmo[1] = "1";
$SpoonBot::PainterGear[2] = "plasmaammo";	$Spoonbot::PainterAmmo[2] = "500";
$SpoonBot::PainterGear[3] = "dislauncher"; 	$Spoonbot::PainterAmmo[3] = "1";
$SpoonBot::PainterGear[4] = "discammo";		$Spoonbot::PainterAmmo[4] = "500";
$SpoonBot::PainterGear[5] = "";

$Spoonbot::PainterClose = "plasma";
$Spoonbot::PainterLong  = "targeting";
$SpoonBot::PainterJet   = "targeting";
$Spoonbot::PainterPack  = "";

//=========================== Standard Gear -- Used if Bot has no preset name...
$SpoonBot::StandardMArmor  = "marmor";
$SpoonBot::StandardFArmor  = "mfemale";
$SpoonBot::StandardGear[0] = "energypack";		$Spoonbot::StandardAmmo[0] = "1";
$SpoonBot::StandardGear[1] = "plasma";			$Spoonbot::StandardAmmo[1] = "1";
$SpoonBot::StandardGear[2] = "plasmaammo";		$Spoonbot::StandardAmmo[2] = "500";
$SpoonBot::StandardGear[3] = "dislauncher";		$Spoonbot::StandardAmmo[3] = "1";
$SpoonBot::StandardGear[4] = "discammo";		$Spoonbot::StandardAmmo[4] = "500";
$SpoonBot::StandardGear[5] = "";

$Spoonbot::StandardClose = "plasma";
$Spoonbot::StandardLong  = "disclauncher";
$SpoonBot::StandardJet   = "disclauncher";
$Spoonbot::StandardPack  = "energypack";
