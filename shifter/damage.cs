//================================================================================ Players
function InitDamageRatios()
{
	%damageId[0] = "aarmor";
	%damageId[1] = "afemale";
	%damageId[2] = "barmor";
	%damageId[3] = "bfemale";
	%damageId[4] = "darmor";
	%damageId[5] = "dmarmor";
	%damageId[6] = "dmfemale";
	%damageId[7] = "earmor";
	%damageId[8] = "efemale";
	%damageId[9] = "harmor";
	%damageId[10] = "jarmor";
	%damageId[11] = "larmor";
	%damageId[12] = "lfemale";
	%damageId[13] = "marmor";
	%damageId[14] = "mfemale";
	%damageId[15] = "parmor";
	%damageId[16] = "sarmor";
	%damageId[17] = "sfemale";
	%damageId[18] = "spyarmor";
	%damageId[19] = "spyfemale";
	%damageId[20] = "stimarmor";
	%damageId[21] = "stimfemale";
	%damageId[22] = "ShortCoolProj";
	%damageId[23] = "NapProj";
	%damageId[24] = "CoolProj";
	%damageId[25] = "BooProj";
	%damageId[26] = "EmpProj";
	%damageId[27] = "GasProj";
	%damageId[28] = "SpyPodProj";
	%damageId[29] = "Scout";
	%damageId[30] = "LAPC";
	%damageId[31] = "HAPC";

	for(%k = 0; %k < 32; %k++)
	{
		%thing = %damageId[%k];
		for(%i = -1; %i < 34; %i++)
			$DamageScale[%thing, %i] = 1.0;
		$DamageScale[%thing,	$CloakDamageType] = 0.0;
		$DamageScale[%thing, $GravDamageType]	= 0.1;
	}
}
InitDamageRatios();

function CopyDamageRatio(%armor1, %armor2)
{
	for(%i = -1; %i < 34; %i++)
		$DamageScale[%armor2, %i] = $DamageScale[%armor1, %i];
}

//===== Arbitor Armor
$DamageScale[aarmor,	$BlasterDamageType] 	= 0.5;
$DamageScale[aarmor,	$DebrisDamageType] 	= 1.2;
$DamageScale[aarmor,	$ElectricityDamageType] = 0.2;
$DamageScale[aarmor,	$EnergyDamageType] 	= 0.3;
$DamageScale[aarmor,	$EqualizerDamageType] 	= 1.2;
$DamageScale[aarmor,	$FlashDamageType] 	= 0.5;
$DamageScale[aarmor,	$IDamageType] 	 	= 0.7;
$DamageScale[aarmor,	$ImpactDamageType] 	= 0.4;
$DamageScale[aarmor,	$LandingDamageType] 	= 0.1;
$DamageScale[aarmor,	$LaserDamageType] 	= 0.5;
$DamageScale[aarmor,	$MissileDamageType] 	= 0.9;
$DamageScale[aarmor,	$MortarDamageType] 	= 1.5;
$DamageScale[aarmor,	$NukeDamageType] 	= 1.3;
$DamageScale[aarmor,	$MDMDamageType] 	= 1.3;
$DamageScale[aarmor,	$ShellDamageType] 	= 1.2;
$DamageScale[aarmor,	$ShrapnelDamageType] 	= 1.2;
$DamageScale[aarmor,	$SniperDamageType] 	= 1.2;
CopyDamageRatio(aarmor, afemale);

//===== Goliath Armor
$DamageScale[barmor,	$BlasterDamageType] = 1.2;
$DamageScale[barmor,	$BulletDamageType] = 1.3;
$DamageScale[barmor,	$EnergyDamageType] = 1.1;
$DamageScale[barmor,	$EqualizerDamageType] 	 = 1.1;
$DamageScale[barmor,	$ExplosionDamageType] = 0.5;
$DamageScale[barmor,	$IDamageType] 	 = 0.7;
$DamageScale[barmor,	$LaserDamageType] = 1.2;
$DamageScale[barmor,	$MineDamageType] = 0.5;
$DamageScale[barmor,	$MissileDamageType] = 0.5;
$DamageScale[barmor,	$MortarDamageType] = 0.5;
$DamageScale[barmor,	$PlasmaDamageType] = 0.4;
$DamageScale[barmor,	$ShrapnelDamageType] = 0.5;
CopyDamageRatio(barmor, bfemale);

//===== DreadNaught Armor
$DamageScale[darmor,	$BlasterDamageType] = 0.7;
$DamageScale[darmor,	$BulletDamageType] = 0.5;
$DamageScale[darmor,	$CrushDamageType] = 0.8;
$DamageScale[darmor,	$DebrisDamageType] = 0.8;
$DamageScale[darmor,	$ElectricityDamageType] = 0.8;
$DamageScale[darmor,	$EnergyDamageType] = 0.7;
$DamageScale[darmor,	$EqualizerDamageType] 	 = 0.8;
$DamageScale[darmor,	$ExplosionDamageType] = 0.6;
$DamageScale[darmor,	$IDamageType] 	 = 0.7;
$DamageScale[darmor,	$ImpactDamageType] = 0.8;
$DamageScale[darmor,	$LandingDamageType] = 0.8;
$DamageScale[darmor,	$LaserDamageType] = 0.6;
$DamageScale[darmor,	$MineDamageType] = 0.8;
$DamageScale[darmor,	$MissileDamageType] = 0.6;
$DamageScale[darmor,	$MortarDamageType] = 0.7;
$DamageScale[darmor,	$PlasmaDamageType] = 0.7;
$DamageScale[darmor,	$ShrapnelDamageType] = 0.8;
$DamageScale[darmor,	$SniperDamageType] = 0.6;
CopyDamageRatio(darmor, harmor);

//===== Death Match Armor
$DamageScale[dmarmor,	$EqualizerDamageType]	= 1.2;
$DamageScale[dmarmor,	$IDamageType]	 	= 0.7;
$DamageScale[dmarmor,	$NukeDamageType] 	= 1.2;
$DamageScale[dmarmor,	$MDMDamageType] 	= 1.2;
$DamageScale[dmarmor,	$ShellDamageType] 	= 1.2;
CopyDamageRatio(dmarmor, dmfemale);

//===== Engineer Armor
$DamageScale[earmor,	$EqualizerDamageType] 	 = 0.7;
$DamageScale[earmor,	$FlashDamageType] = 0.7;
$DamageScale[earmor,	$IDamageType] 	 = 0.7;
CopyDamageRatio(earmor, efemale);

//===== Assassin Armor
$DamageScale[larmor,	$BlasterDamageType] = 1.3;
$DamageScale[larmor,	$BulletDamageType] = 1.2;
$DamageScale[larmor,	$DebrisDamageType] = 1.2;
$DamageScale[larmor,	$EnergyDamageType] = 1.3;
$DamageScale[larmor,	$IDamageType]	 = 0.7;
$DamageScale[larmor,	$MineDamageType] = 1.2;
$DamageScale[larmor,	$MortarDamageType] = 1.3;
$DamageScale[larmor,	$ShrapnelDamageType] = 1.2;
CopyDamageRatio(larmor, lfemale);

//===== Mercenary Armor
$DamageScale[marmor,	$ElectricityDamageType] = 0.6;
$DamageScale[marmor,	$IDamageType]	 = 0.7;
CopyDamageRatio(marmor, mfemale);

//===== Scout Armor
$DamageScale[sarmor,	$BlasterDamageType] = 1.3;
$DamageScale[sarmor,	$BulletDamageType] = 1.2;
$DamageScale[sarmor,	$CrushDamageType] = 0.5;
$DamageScale[sarmor,	$DebrisDamageType] = 1.2;
$DamageScale[sarmor,	$EnergyDamageType] = 1.3;
$DamageScale[sarmor,	$EqualizerDamageType]	 = 1.1;
$DamageScale[sarmor,	$IDamageType]	 = 0.7;
$DamageScale[sarmor,	$ImpactDamageType] = 0.5;
$DamageScale[sarmor,	$LandingDamageType] = 0.5;
$DamageScale[sarmor,	$MineDamageType] = 1.2;
$DamageScale[sarmor,	$MortarDamageType] = 1.3;
$DamageScale[sarmor,	$ShrapnelDamageType] = 1.2;
CopyDamageRatio(sarmor, sfemale);

//===== Chemelion Armor
$DamageScale[spyarmor,	$BlasterDamageType] = 1.3;
$DamageScale[spyarmor,	$BulletDamageType] = 0.5;
$DamageScale[spyarmor,	$EqualizerDamageType]	 = 0.9;
$DamageScale[spyarmor,	$IDamageType]	 = 0.7;
$DamageScale[spyarmor,	$NukeDamageType] = 0.9;
$DamageScale[spyarmor,	$MDMDamageType] = 0.9;
$DamageScale[spyarmor,	$ShellDamageType] = 0.9;
CopyDamageRatio(spyarmor, spyfemale);

//===== Stim Scout Armor
$DamageScale[stimarmor,	$BlasterDamageType] = 1.3;
$DamageScale[stimarmor,	$BulletDamageType] = 1.2;
$DamageScale[stimarmor,	$CrushDamageType] = 0.5;
$DamageScale[stimarmor,	$DebrisDamageType] = 1.2;
$DamageScale[stimarmor,	$EnergyDamageType] = 1.3;
$DamageScale[stimarmor,	$EqualizerDamageType]	 = 1.1;
$DamageScale[stimarmor,	$IDamageType]	 = 0.7;
$DamageScale[stimarmor,	$ImpactDamageType] = 0.5;
$DamageScale[stimarmor,	$LandingDamageType] = 0.5;
$DamageScale[stimarmor,	$MineDamageType] = 1.2;
$DamageScale[stimarmor,	$MortarDamageType] = 1.3;
$DamageScale[stimarmor,	$ShrapnelDamageType] = 1.2;
CopyDamageRatio(stimarmor, stimfemale);

//===== Juggernaught Armor
$DamageScale[jarmor,	$BlasterDamageType] = 1.5;
$DamageScale[jarmor,	$CrushDamageType] = 0.6;
$DamageScale[jarmor,	$ElectricityDamageType] = 1.2;
$DamageScale[jarmor,	$EnergyDamageType] = 1.3;
$DamageScale[jarmor,	$FlashDamageType] = 1.5;
$DamageScale[jarmor,	$IDamageType] 	 = 0.7;
$DamageScale[jarmor,	$ImpactDamageType] = 0.5;
$DamageScale[jarmor,	$LandingDamageType] = 0.2;
$DamageScale[jarmor,	$LaserDamageType] = 0.5;
$DamageScale[jarmor,	$MortarDamageType] = 1.2;
$DamageScale[jarmor,	$PlasmaDamageType] = 2.0;
$DamageScale[jarmor,	$BoomStickDamageType] 	= 1.2;
$DamageScale[jarmor,	$HBlasterDamageType] 	= 1.1;

//===== Cursed Armor
$DamageScale[parmor,	$BlasterDamageType] 	= 0.0;
$DamageScale[parmor,	$BulletDamageType] 	= 0.0;
$DamageScale[parmor,	$CloakDamageType]  	= 0.0;
$DamageScale[parmor,	$CrushDamageType] 	= 0.0;
$DamageScale[parmor,	$DebrisDamageType] 	= 0.0;
$DamageScale[parmor,	$ElectricityDamageType] = 0.0;
$DamageScale[parmor,	$EnergyDamageType] 	= 0.0;
$DamageScale[parmor,	$EqualizerDamageType]   = 0.0;
$DamageScale[parmor,	$ExplosionDamageType] 	= 0.0;
$DamageScale[parmor,	$FlashDamageType] 	= 0.0;
$DamageScale[parmor,	$IDamageType]  	 	= 0.0;
$DamageScale[parmor,	$ImpactDamageType] 	= 0.0;
$DamageScale[parmor,	$LandingDamageType] 	= 0.0;
$DamageScale[parmor,	$LaserDamageType] 	= 0.0;
$DamageScale[parmor,	$MineDamageType] 	= 0.0;
$DamageScale[parmor,	$MissileDamageType] 	= 0.0;
$DamageScale[parmor,	$MortarDamageType] 	= 0.0;
$DamageScale[parmor,	$NukeDamageType] 	= 0.0;
$DamageScale[parmor,	$MDMDamageType] 	= 0.0;
$DamageScale[parmor,	$PlasmaDamageType] 	= 0.0;
$DamageScale[parmor,	$ShellDamageType] 	= 0.0;
$DamageScale[parmor,	$ShrapnelDamageType] 	= 0.0;
$DamageScale[parmor,	$SniperDamageType] 	= 0.0;
$DamageScale[parmor,	$BoomStickDamageType] 	= 0.0;
$DamageScale[parmor,	$HBlasterDamageType] 	= 0.0;

//================================================================================ Flyers

$DamageScale[Scout,	$BulletDamageType] 	= 1.6;
$DamageScale[Scout,	$SniperDamageType] 	= 1.6;

$DamageScale[LAPC,	$ImpactDamageType] 	= 0.8;

$DamageScale[HAPC,	$BulletDamageType] 	= 0.8;
$DamageScale[HAPC,	$ImpactDamageType] 	= 0.8;
$DamageScale[HAPC,	$LaserDamageType] 	= 0.8;
$DamageScale[HAPC,	$MortarDamageType] 	= 0.8;
$DamageScale[HAPC,	$SniperDamageType] 	= 0.8;
$DamageScale[HAPC,	$HBlasterDamageType] 	= 0.8;