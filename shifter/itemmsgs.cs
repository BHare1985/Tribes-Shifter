function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Blaster", 2);
}

function PlasmaGun::onUse(%player,%item)
{
   Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if(!%client.Plasma || %client.Plasma == 0)
		bottomprint(%client, "<jc><f2>Using Plasma Gun - Standard", 2);
	else if(%client.Plasma == 1)
		bottomprint(%client, "<jc><f2>Using Plasma Gun - Rapid Fire", 2);
	else if (%client.Plasma == 2)
		bottomprint(%client, "<jc><f2>Using Plasma Gun - Spread Fire", 2);
}


function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Equalizer", 2);
}

function LasCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Gattling Laser Cannon", 2);
}


function DiscLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if(!%client.disc || %client.disc == 0)
		bottomprint(%client, "<jc><f2>Using Disc Launcher - Standard", 2);
	else if(%client.disc == 1)
		bottomprint(%client, "<jc><f2>Using Disc Launcher - Rapid Fire", 2);
}


function GrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Grenade Launcher", 2);
}

function LaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Laser Rifle", 2);
}

function EnergyRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using ELF Gun", 2);
}

function Mortar::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	%ammo = Player::getItemCount(%player,MortarAmmo);
	if(%ammo < 1) Client::sendMessage(%client,0,"Mortar has no ammo");
	else if (!%client.mortar || %client.mortar == 0)
	{
		Player::mountItem(%player,mortar0,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Standard Shell", 2);
	}
	else if (%client.mortar == 1)
	{
		Player::mountItem(%player,mortar1,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - EMP Shell", 2);
	}
	else if (%client.mortar == 2)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Frag Shell", 2);
	}
	else if (%client.mortar == 3)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - MDM Shell", 2);
	}
}

function Mortar0::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	%ammo = Player::getItemCount(%player,MortarAmmo);
	if(%ammo < 1) Client::sendMessage(%client,0,"Mortar has no ammo");
	else if (!%client.mortar || %client.mortar == 0)
	{
		Player::mountItem(%player,mortar0,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Standard Shell", 2);
	}
	else if (%client.mortar == 1)
	{
		Player::mountItem(%player,mortar1,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - EMP Shell", 2);
	}
	else if (%client.mortar == 2)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Frag Shell", 2);
	}
	else if (%client.mortar == 3)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - MDM Shell", 2);
	}
}

function Mortar1::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	%ammo = Player::getItemCount(%player,MortarAmmo);
	if(%ammo < 1) Client::sendMessage(%client,0,"Mortar has no ammo");
	else if (!%client.mortar || %client.mortar == 0)
	{
		Player::mountItem(%player,mortar0,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Standard Shell", 2);
	}
	else if (%client.mortar == 1)
	{
		Player::mountItem(%player,mortar1,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - EMP Shell", 2);
	}
	else if (%client.mortar == 2)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Frag Shell", 2);
	}
	else if (%client.mortar == 3)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - MDM Shell", 2);
	}
}

function Mortar2::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	%ammo = Player::getItemCount(%player,MortarAmmo);
	if(%ammo < 1) Client::sendMessage(%client,0,"Mortar has no ammo");
	else if (!%client.mortar || %client.mortar == 0)
	{
		Player::mountItem(%player,mortar0,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Standard Shell", 2);
	}
	else if (%client.mortar == 1)
	{
		Player::mountItem(%player,mortar1,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - EMP Shell", 2);
	}
	else if (%client.mortar == 2)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - Frag Shell", 2);
	}
	else if (%client.mortar == 3)
	{
		Player::mountItem(%player,mortar2,$WeaponSlot);
		bottomprint(%client, "<jc><f2>Using Mortar - MDM Shell", 2);
	}
}

function TargetingLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Targeting Laser", 2);
}

function HyperB::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Hyper Blaster", 2);
}

function RocketLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if(!%client.rocket || %client.rocket == 0)
		bottomprint(%client, "<jc><f2>Using Rocket Launcher - Stinger Mode", 2);
	else if(%client.rocket == 1)
		bottomprint(%client, "<jc><f2>Using Rocket Launcher - Locking Mode", 2);
	else if(%client.rocket == 2)
		bottomprint(%client, "<jc><f2>Using Rocket Launcher - HeatSeeker Mode", 2);
	else if(%client.rocket == 3)
		bottomprint(%client, "<jc><f2>Using Rocket Launcher - WireGuided Mode", 2);
}

function SniperRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Sniper Rifle", 2);
}

function Equalizer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Equalizer", 2);
}

function BoomStick::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Boom Stick", 2);
}

function TranqGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Dart Rifle", 2);
}

function Silencer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Magnum", 2);
}

function ConCun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Shockwave Cannon", 2);
}

function Railgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Railgun", 2);
}

function Vulcan::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Vulcan", 2);
}

function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Flame Thrower", 2);
}

function IonGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ion Rifle", 2);
}

function Volter::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Volter", 2);
}

function GravGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.gravbolt || %client.gravbolt == 0)
		bottomprint(%client, "<jc><f2>Using Grav Gun - Tractor Setting", 2);
	else if (%client.gravbolt == 1)
		bottomprint(%client, "<jc><f2>Using Grav Gun - Repulse Setting", 2);
	else if (%client.gravbolt == 2)
		bottomprint(%client, "<jc><f2>Using Grav Gun - Grapler Setting", 2);
}

function FixIt::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Repair-Gun", 2);
}

function Hackit::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Hack-Gun", 2);
}

function DisIt::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Disassymbler", 2);
}

function PlasmaCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Plasma Cannon", 2);
}