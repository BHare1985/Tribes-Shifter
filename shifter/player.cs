$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
if ($CorpseTimeoutValue < 1)
	$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

function Player::onAdd(%this)
{
	%armor = Player::getArmor(%this);
	GameBase::setRechargeRate(%this,8);
	if(%armor == aarmor || %armor == afemale)
		GameBase::setRechargeRate(%player,10);
}

function Player::onRemove(%this)
{
	for (%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) 
		{
			%item = newObject("","Item",%type,1,false);
         		schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
         		addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

//function Player::onNoAmmo(%player,%imageSlot,%itemType)
//{
//if($debug) echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
//}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (%type == $GravDamageType || $builder) return;
	if (Player::isDead(%this)) return;
	%damagedClient = Player::getClient(%this);
	%damTeam = Client::getTeam(%damagedClient);
	%armor = Player::getArmor(%this);
	%objArmor = Player::getArmor(%object);
	%clientId = %damagedClient;
	if (getObjectType(%object) == "Player")
		%shooterClient = Player::getClient(%object);
	else %shooterClient = %object;
	%damagedClient.lastdamager = %shooterClient;
	%shootTeam = Client::getTeam(%shooterClient);	
	if(%type == $BulletDamageType || %type == $LaserDamageType || %type == $SniperDamageType)
		%snipeType = 1; else %snipeType = 0;
	if(%armor == "harmor" || %armor == "darmor" || %armor == "jarmor")
		%heavyArmor = 1; else %heavyArmor = 0;
	if(%damTeam == %shootTeam)
		%td = true; else %td = false;
	if (%damagedClient.inflyer && %this.vehicle && (%this.vehicle).isalive && !%snipeType)
	{
		Vehicle::onDamage(%this.vehicle,%type,%value,%pos,%vec,%mom,%object);
			return;
	}
	if(%vertPos == "head")
		%head = 1;
	else if(%vertPos == "torso")
		%torso = 1;
	else if(%vertPos == "legs")
		%legs = 1;
	if (Player::isExposed(%this))
	{
		Player::applyImpulse(%this,%mom);
		//=============================================== Determin Team Damage
		if($teamplay && %damagedClient != %shooterClient && %td && %shooterClient)
		{
			%curTime = getSimTime();
		   if ((%curTime - %this.DamageStamp > 1.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) 
		   {
				if(%type != $MineDamageType)
				{
					Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
					Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					if(!$Server::TourneyMode)
					{
	           		%shooterClient.score -= 1;
						if ($ScoreOn) bottomprint(%shooterClient, "You harmed your teammate... Score -1 = " @ %shooterClient.score @ " Total Score");
					}
				}
				else
				{
					Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
					Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
				}
				%this.LastHarm = %shooterClient;
				%this.DamageStamp = %curTime;
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == %damTeam) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;
		//=================================================== Reaction Damage
		if(%torso)
		{
			%packType = Player::getMountedItem(%damagedClient,$BackpackSlot);
			if(%quadrant == "front_right" || %quadrant == "front_left")
			{
				%kick = (%value * 100);
				ixApplyKickback(%damagedClient,%kick, (%kick/2));
			}
			else if(%quadrant == "back_right" || %quadrant == "back_left")
			{
				%kick = (%value * 150);
				ixApplyKickback(%damagedClient, -%kick, (%kick/2));
				if (%kick > 90)
					Player::dropItem(%damagedClient,%packtype);
			}
		}
		else if(%legs)
		{
			if(%quadrant == "front_right" || %quadrant == "front_left")
			{
				%kick = (%value * 150);
				ixApplyKickback(%damagedClient,%kick, %kick);
			}
			else if(%quadrant == "back_right" || %quadrant == "back_left")
			{
				%kick = (%value * 200);
				ixApplyKickback(%damagedClient, -%kick, -%kick);
			}
		}
		else if(%head)
		{
			if(%quadrant == "front_right" || %quadrant == "front_left")
			{
				%kick = (%value * 50);
				ixApplyKickback(%damagedClient,%kick, %kick);
			}
			else if(%quadrant == "back_right" || %quadrant == "back_left")
			{
				%kick = (%value * 100);
				ixApplyKickback(%damagedClient, -%kick, -%kick);
			}

			if (%snipetype)
				%value += %value;
			else
			{
				if(%heavy)
				{ 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						%value += (%value * 0.2);
				}
				else
					%value += (%value * 0.5);
			}
		}
		//==================================== Flash Damage Does EMP Effect
		if(%type == $FlashDamageType || %type == $nukedamagetype)
			ixstartEMP(%damagedClient, %this, 14);
		else if(%type == $MDMDamageType && %value > 0.3)
			ixstartEMP(%damagedClient, %this, 14);

		//=============================================== Shield Pack On
		if (%type != -1 && %this.shieldStrength && %type != $HBlasterDamageType && %type != $EnergyDamageType)
		{
			%energy = GameBase::getEnergy(%this);
			%strength = %this.shieldStrength;

			if (%type == $SniperDamageType || %type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $ExplosionDamageType || %type == $MineDamageType)
				%strength *= 0.75;
			else if (%type == $ElectricityDamageType)
				%strength = 0.0;

			%absorb = %energy * %strength;
				
			if (%value < %absorb)
			{
				GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
				%thisPos = getBoxCenter(%this);
				%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
				GameBase::activateShield(%this,%vec,%offsetZ);
				%value = 0;
			}
			else
			{
				GameBase::setEnergy(%this,0);
				%value -= %absorb;
			}
		}

		//========================================== Merc Booster Pop
		else if (%armor == "marmor" || %armor == "mfemale")
		{
			if (%clientId.boostercool)
			{
				%rnd = (getRandom());
				if((%snipeType || %type == $BulletDamageType)
					&& (%quadrant == "back_right" || %quadrant == "back_left" || 
					%quadrant == "middle_back" || %quadrant == "middle_middle") && !%td)
				{
					if (%rnd > 0.5)
					{
						Player::blowUp(%this);
						%value = %value * 10;
						bottomprint(%clientId, "Your booster popped!");
						if (%clientID.boostpop < 2)
							DeployFrags(%this, 5, %clientId);
						else if(%clientID.boostpop <= 5)
							quietDeployFrags(%this, 5, %clientId);
						GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.02, 2, %shooterClient); 
						GameBase::applyDamage(%player, $PlasmaDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %shooterClient);
						%clientID.boostpop++;
					}
				}
				else
				if ( (%type == $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType
					|| %type == $ElectricityDamageType || %type == $NukeDamageType  || %type == $MDMDamageType) && !%td)
				{
					if (%rnd > 0.6)
					{
						Player::blowUp(%this);
						%value = %value * 10;
						bottomprint(%clientId, "Your booster popped!");
						if (%clientID.boostpop < 2)
							DeployFrags(%this, 5, %clientId);
						else if(%clientID.boostpop <= 6)
							quietDeployFrags(%this, 5, %clientId);
						GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.02, 2, %shooterClient); 
						GameBase::applyDamage(%player, $PlasmaDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %shooterClient);
						%clientID.boostpop++;
					}
				}
			}
		}

		//Arbitor: No damage own shockwave cannon
		if (%type == $MissileDamageType && %shooterClient == %damagedClient && (%armor == "aarmor" || %armor == "afemale"))
			%value = 0.0;

		//======================================= Juggernaught Shield

		if (%armor == "jarmor" && !%this.shieldStrength)
			Renegades_startShield(%damagedClient, %this);

		//============================================ Cloaking Blast
		if(%type == $CloakDamageType)
		{
			GameBase::startFadeOut(%this);
			schedule("GameBase::startFadeIn(" @ %this @ ");", 90);
		}

		//======================================= Life Drain - Poison
		else if (%type == $EnergyDamageType && !%td && (%armor != "aarmor" && %armor != "afemale"))
			Renegades_startBlind(%damagedClient, %this);
		
		//======================= Plasma Damage Catches Player On Fire
		else if ((%type == $PlasmaDamageType || %type == $NukeDamageType || %type == $MDMDamageType) && !%td && %armor != "barmor" && %armor != "bfemale")
		{
			%rnd = floor(getRandom() * 10);
			if(%rnd > 5)
				Renegades_startBurn(%damagedClient, %this);
		}

		//================================== Sniper Shot Effects
		%hitdamageval = 0.05;
		%hittolerance = 0.25;
		%weaponType = Player::getMountedItem(%this,$WeaponSlot);
		if(%weapontype == mortar0 || %weapontype == mortar1 || %weapontype == mortar2)
			%weapontype = "mortar";
		%packType = Player::getMountedItem(%this,$BackpackSlot);
		if (%value > %hittolerance && %snipetype && %torso) 
			%snipeoff = 1;

		//======================================= Suicide Pack Explodes
		if((Player::getMountedItem(%this,$BackpackSlot) == SuicidePack))
		{						
			if( (%type == $LaserDamageType || %type == $SniperDamageType || %type == $BulletDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")  && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
			{
				MessageAllExcept(Player::getClient(%damagedClient), 0, Client::getName(%shooterClient) @ " sniped the huge bomb on " @ Client::getName(%damagedClient) @ "'s back!");
				Client::sendMessage(Player::getClient(%damagedClient),0,"Your Suicide Pack exploded!");
				Player::unmountItem(%this,$BackpackSlot);	
				%obj = newObject("","Mine","Suicidebomb");
				%obj.deployer = %shooterClient;
 				addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%this);
				GameBase::throw(%obj,%this,9 * %client.throwStrength,false);
			}
		}

		//========================= Check for flag kick on sniper shot - *IX*Savage1
		if (%snipetype && Player::getMountedItem(%this,$FlagSlot) != -1 && %torso  && (%quadrant == "back_left" == %quadrant == "back_right" || %quadrant == "middle_back" || %quadrant == "middle_middle") && !td)
				DoTheFlagDrop(%this, %shooterClient);

		//======================================= Godhammer Snipe Off
		if(%snipeoff && Player::getMountedItem(%player,4) == "Hammer1Pack" || Player::getMountedItem(%player,5) == "Hammer2Pack" && !%td)
		{
			if (%quadrant == "middle_left" || %quadrant == "middle_right")
			{
				%clientId.heatup += 60;
				GodHammer::HeatUp(%clientId);
			}
		}

		//======================================= Snipe Off
		else if(%type != $SniperDamageType && %snipeoff && %quadrant == "front_right" && (%weaponType != -1 && %weaponType != "RepairGun"))
		{
			Player::dropItem(%this,%weaponType);
			%dlevel = GameBase::getDamageLevel(%this) + 0.05;
			Client::sendMessage(%shooterClient,0,"You shot the " @ %weaponType @ " out of "  @ Client::getName(%damagedClient) @ "'s hand!");
		}
		else //IT DOES ACTUAL DAMAGE
		{
			if(%damagedClient.JustSpawned)
				%value = 0;
			%value = $DamageScale[%armor, %type] * %value * %friendFire;
			%dlevel = GameBase::getDamageLevel(%this) + %value;
		}

		%spillOver = %dlevel - %armor.maxDamage;
		GameBase::setDamageLevel(%this,%dlevel);
		%flash = Player::getDamageFlash(%this) + %value * 2;
		
		if (%flash > 0.75)
			%flash = 0.75;

		Player::setDamageFlash(%this,%flash);
			
		if(!Player::isDead(%this))
		{ 
			if(%damagedClient.lastDamage < getSimTime())
			{
				%sound = radnomItems(3,injure1,injure2,injure3);
				playVoice(%damagedClient,%sound);
				%damagedClient.lastdamage = getSimTime() + 1.5;
			}
		}
		else 
		{
			if(%spillOver > 0.5)
			{
				if ($Shifter::AmmoBoom != "False" && %damagedClient != %shooterClient)
					itemfuncs::ammoboom(%this);
				if (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType
					|| %type == $MissileDamageType || %type == $ElectricityDamageType || %type == $NukeDamageType || %type == $MDMDamageType)
				{
					Player::trigger(%this, $WeaponSlot, false);
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);
					if(%weaponType != -1)
						Player::dropItem(%this,%weaponType);
					if (%type == $ElectricityDamageType) 
						playSound(ShockExplosion,GameBase::getPosition(%this));
					Player::blowUp(%this);
				}
			}
			else
			{
				if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType
					|| %type == $MissileDamageType || %type == $NukeDamageType || %type == $MDMDamageType )) || Player::getLastContactCount(%this) > 6)
				{
					if(%quadrant == "front_left" || %quadrant == "front_right") 
						%curDie = $PlayerAnim::DieBlownBack;
					else
						%curDie = $PlayerAnim::DieForward;
				}
				else if( Player::isCrouching(%this) ) 
					%curDie = $PlayerAnim::Crouching;							
				else if(%vertPos=="head")
				{
					if(%quadrant == "front_left" ||	%quadrant == "front_right") 
						%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
					else 
						%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
				}
				else if (%torso)
				{
					if(%quadrant == "front_left" ) 
						%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
					else if(%quadrant == "front_right") 
						%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
					else if(%quadrant == "back_left" ) 
						%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
					else if(%quadrant == "back_right") 
						%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
				}
				else if (%legs)
				{
					if(%quadrant == "front_left" ||	%quadrant == "back_left") 
						%curDie = $PlayerAnim::DieLegLeft;
					if(%quadrant == "front_right" || %quadrant == "back_right") 
						%curDie = $PlayerAnim::DieLegRight;
				}
				Player::setAnimation(%this, %curDie);
			}
//End Death Animation
			if(%type == $ImpactDamageType && %object.clLastMount != "")  
				%shooterClient = %object.clLastMount;
			if (gamebase::getposition(%object) != "0 0 0" && gamebase::getposition(%this) != "0 0 0")
				%distance = Vector::getDistance(gamebase::getposition(%object), gamebase::getposition(%this));
			else
				%distance = 0;
			
			%shooterClient.lastkill = %distance;
			Client::onKilled(%damagedClient,%shooterClient, %type, %vertPos, %quadrant);
		}
	}
}


function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{return %an[floor(getRandom() * (%num - 0.01))];}

//====================================================================
//===================================== Collisions With Players ======
//====================================================================

function Player::onCollision(%this,%object)
{
	%thisTeam = gamebase::getteam(%this);
	%objTeam = gamebase::getteam(%object);
	%objtype = getObjectType(%object);
	if (%objtype == "Player")
	{
		%sound = false;
		//but what if a corpse flys AT you?
		if (Player::isDead(%object))
		{	return;
		}
		else
		if (Player::isDead(%this))
		{
			%pickarmor = Player::getArmor(%object);
			%deadarmor = Player::getArmor(%this);
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%count = Player::getItemCount(%this,%i);
				%itemname = getItemData(%i);
								
				if (%itemname == "Grenade" && %pickarmor != %deadarmor && (%pickarmor != "spyarmor" && %pickarmor != "spyfemale"))
				{
					%itemname = "";
				}
				
				if (%itemname == "Beacon" && %pickarmor == "jarmor" && %deadarmor != "jarmor")
				{
					%itemname = "";
				}
				
				if (%itemname == "mineammo")
				{
					if (%pickarmor == "earmor" || %pickarmor == "efemale" || %deadarmor == "earmor" || %deadarmor == "efemale")
					{
					}
					else if (%pickarmor != %deadarmor)
					{
						%itemname = "";
					}
				}
				
				if (%count && %itemname != "")
				{
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0)
					{
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if(%sound)
			{
				if (%thisteam != %objTeam && (%deadarmor == "lfemale" || %deadarmor == "larmor") && (%pickarmor != "lfemale" && %pickarmor != "larmor"))
				{
					bottomprint(player::getclient(%object), "<jc>You are poisoned by assassins items.");
					Renegades_startBlind(player::getclient(%object), %object);
				}
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
		//==========================================================================
		//Werewolfs Bot stuff Dealing with Bots   Bot Collision	  Edited By Emo1313
		//==========================================================================
		else
		if(Player::isAIControlled(%this) == "true" && Player::isAIControlled(%object) == "false")
		{
			%Player1 = Player::getClient(%this);
			%Player2 = Player::getClient(%object);
			%aiId = Player::getClient(%this);
			%aiName = Client::GetName(%aiId);
			//%aiTeam = Client::GetTeam(%this);	 
			//%objTeam = Client::GetTeam(%object);
			//echo("BOT: Collision <" @ %aiName @ " - " @ %aiId @ ">");
			//========================================= Class Specific
			//if (%aiTeam == %objTeam)     //===== Make Sure Bot Doesnt Repair Other Teams Stuff
			//{}
			//============================== Attempt Object Move Around
			if((GameBase::testPosition(%aiId,(%posX + 2) @ " " @ (%posY + 2) @ " " @ (%posZ + 2)))  && (getObjectType(%object) != "Vehicle"))
			{	
				%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));		
				%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));		
				%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%aiId)); 
			  	if (getRandom() > 0.5)
			  		%aiRotation = (%aiRotation + 60);
				else
					%aiRotation = (%aiRotation - 60);
				%Length = 225;
				%Zvalue = $aiRotation;
				%aiVect = Vector::getFromRot(%aiRotation, %Length, %Zvalue); 			
				%rotZ = getWord(GameBase::getRotation(Client::getOwnedObject(%aiId)),2);			
				%rotZ = (%rotZ + 90);
				%velocity = 75;
				GameBase::setRotation(Client::getOwnedObject(%aiId), "0 0 " @ %rotZ);
				%jumpDir = Vector::getFromRot(GameBase::getRotation(%aiId),%velocity,%Zvalue);
				Vehicle::passengerJump(0,%aiId,0);		 								 		//Crude way to make players avoid obstacles
				Player::applyImpulse(%aiId, %jumpDir);
			}
			//else
      	//{
			//echo ( %aiId @ " Can not avoid...");
			//}
		}
//======================================================== End AI Collision
//botcode
//================================================ Eng. Medic Touch
		else if(%objTeam == %thisteam)
		{
			%armor = Player::getArmor(%object);
			%thisId = Player::getClient(%this);
			if (%armor == "earmor" || %armor == "efemale")
			{
				if(GameBase::getDamageLevel(%this)) 
				{
					GameBase::repairDamage(%this,0.10);
					GameBase::playSound(%this,ForceFieldOpen,0);
		    	}
			}
			else if (%armor == "aarmor" || %armor == "afemale")
			{
				if(%thisId.empTime != 0)
				{
					%thisId.empTime = 0;
					GameBase::playSound(%this,ForceFieldOpen,0);
		    	}
			}	
		}
//======================================================== Touch Attacks
		else if(%objTeam != %thisteam)
		{	%armor = Player::getArmor(%object);
			%tarmor = Player::getArmor(%this);
			%thisId = Player::getClient(%this);
			//============================================== Scout Steal Items
			if ((%armor == "sarmor" || %armor == "sfemale") && (%tarmor != "spyarmor" && %tarmor != "spyfemale"))
			{
				// Transfer all our items to the player and drop players pack...
				%DropPack = (Player::getMountedItem(%this, $BackPackSlot));
				Player::dropItem(%this, %DropPack) ;	
				%FlagDrop = (Player::getMountedItem(%this, $FlagSlot));
				Player::dropItem(%this, %FlagDrop) ;
				Player::setDamageFlash(%this,0.95);
				%max = getNumItems();
				for (%i = 0; %i < %max; %i = %i + 1)
				{
					%count = Player::getItemCount(%this,%i);
					if (%count)
					{
						%delta = Item::giveItem(%object,getItemData(%i),%count);					
						if (%delta > 0)
						{
							Player::decItemCount(%this,%i,%delta);
							Player::unmountItem(%this,$WeaponSlot);
							playSound(SoundPickupItem,GameBase::getPosition(%this));
						}
					}
				}
			}
			//============================================= Arbitor Death Touch
			else if ((%armor == "aarmor" || %armor == "afemale") && (%tarmor != "aarmor" && %tarmor != "afemale"))
  	  		{	
				GameBase::applyDamage(%this,$FlashDamageType,0.20,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  
				if(GameBase::getDamageLevel(%object)) 
				{	GameBase::repairDamage(%object,0.30);
					(player::getclient(%object)).empTime = 0;
				}
				GameBase::playSound(%this,ForceFieldOpen,0);
				Client::sendMessage(Player::getClient(%object),1,"You drain " @ Client::getName(%thisId) @ "'s energy...");
				return;
			}	
			//============================================= Juggy Crunch :)   by  -Kind-Defeat
			else if (%armor == "jarmor" && %tarmor != "jarmor") // || %armor == "darmor")
			{
				%tpos = GameBase::getPosition(%this);
				%oZpos = getword(GameBase::getPosition(%object), 2);
				%tZpos = getword(%tpos, 2) + 1.5;
				//%armor is object
				//echo("CRUNCHY!");
				if(%tZpos < %oZpos)
				{
					Player::blowUp(%this);
					GameBase::applyDamage(%this,$CrushDamageType,10.0,%tpos,"0 0 0","0 0 0",%object);  
					GameBase::playSound(%object,SoundFlierCrash,0);
					Client::sendMessage(Player::getClient(%this),0,"CRUNCH!");
					Client::sendMessage(Player::getClient(%object),0,"CRUNCH!");
				}
			}
			//============================================ Assassin Death Touch
			else if ((%armor == "larmor" || %armor == "lfemale") && (%tarmor != "larmor") && (%tarmor != "lfemale"))
	    	{
				GameBase::applyDamage(%this,$EnergyDamageType,0.25,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  
				GameBase::playSound(%this,ForceFieldOpen,0);
				Client::sendMessage(Player::getClient(%object),1,
				"You death touch "  @ Client::getName(%thisId) @ ".");
				return;
			}		
			//===================================== Spy Disguise - Skin Snatch
			else if (%armor == "spyarmor" || %armor == "spyfemale")
		   {
				%ClientId = Player::getClient(%object);
				%thisId = Player::getClient(%this);
				%grabskin = Client::getSkinBase(%thisId);
				%origskin = Client::getSkinBase(%clientId);
				Client::setSkin(%clientId,%grabskin);
				GameBase::playSound(%this,ForceFieldOpen,0);
				Client::sendMessage(%clientId,0,"You went undercover disguised as " @ Client::getName(%thisId) @ " !");
				Client::sendMessage(Player::getClient(%object),1,"You go undercover disguised as "  @ Client::getName(%thisId) @ "!" );
     			schedule("Client::setSkin("@ %clientId @"," @ %origskin @");", 120);
				%clientID.cloaktime = 1;
     			schedule(""@ %clientID @".cloaktime = 1;", 120);
				Cloaker(%object);
				//EVIL EVIL EVIL GREY
				//Player::setDetectParameters(%this, 1000, 3000);
				//Shifter_startHide(%this, 30);
			}
		}		
	}
	else if(%objtype == "Turret" || %objtype == "Sensor")
	{
		%shape = (GameBase::getDataName(%object)).shapeFile;
		%name = GameBase::getMapName(%object);
		%datab = GameBase::getDataName(%object);
		if(%objTeam == %thisteam)
		{
			%armor = Player::getArmor(%this);
			if (%armor == "earmor" || %armor == "efemale")
			{
				if(GameBase::getDamageLevel(%object)) 
				{
					GameBase::repairDamage(%object,0.10);
					GameBase::playSound(%object,ForceFieldOpen,0);
		     	}
			}
		}
	}
}


//============================================================================= Get Heat Factor
function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	
	if (Client::getControlObject(%client) != %this)
		return 1.0;
	
	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;

	if ((%lastTime + 1.5) < %time)
	{
		return 0.0;
	}
	else
	{
		%diff = %time - %lastTime;
		%heat = 1.0 - (%diff / 1.5);
		return %heat;
	}
}

//============================================================================= Jump To Mount Point

function Player::jump(%this,%mom)
{

   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
	%vehicle = Player::getMountObject (%this);
	%this.lastMount = %vehicle;
	%this.newMountTime = getSimTime() + 3.0;
	Player::setMountObject(%this, %vehicle, 0);
	Player::setMountObject(%this, -1, 0);
	Player::applyImpulse(%pl,%mom);
	playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}

function penisCurse(%cl)
{
	 %armor = Player::getArmor(%cl);
	 if (%armor != parmor) 
	 {
		 Player::setArmor(%cl,parmor);
		 checkMaxDrop(%cl,parmor);
		 armorChange(%cl);
       for(%i=0;%i<=$WeaponAmmt;%i++) 
         Player::dropItem(%cl,$WeaponList[%i]); 
		 Player::setItemCount(%cl, $ArmorName[%armor], 0);
		 messageAll(0, " The Penis Curse Has Returned To " @ Client::getName(%cl) @ ", and you thought it was over. " @ Client::getName(%cl) @ " should have played nicer...");
		 Player::setItemCount(%cl, Penis, 1);
		 Player::mountItem(%cl, Penis, $BackPackSlot);
 
	  	 if(Player::getMountedItem(%cl,$FlagSlot) != -1)
	 	 	Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
	 }
}


//==================================================================================== Outside Mission Area Damage
function Player::enterMissionArea(%player)
{
	%player.outArea="";
	//echo("player entering map again");
	%cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have returned to the mission area");
}

function Player::leaveMissionArea(%player)
{
	%flag = Player::getMountedItem(%player,$flagSlot);
	

	%pack = Player::getMountedItem(%player,$BackpackSlot);
	
	if (%pack == "PowerGeneratorPack" || %pack == "CoolLauncher" || %pack == "EmplacementPack" || %pack == "airbase" || %pack == "TeleportPack")
	{
	   	%cl = Player::getClient(%player);

		if(%cl != -1)
			%clname = Client::getName(%cl);

		%obj = newObject("","Mine","EMPBlast");
		GameBase::throw(%obj,%player,0,true);

	   	Player::blowUp(%player);
	   	GameBase::applyDamage(%player,$FlashDamageType, 5.0,GameBase::getPosition(%this),"0 0 0","0 0 0",%player);  
		GameBase::applyRadiusDamage($FlashDamageType, getBoxCenter(%player), 20, 20, 30, %player);
		if (%pack == "PowerGeneratorPack")
		{
			%cl.score = %cl.score - 25;
			bottomprint(%cl, "You have left the mission area with a Deployable Generator, naughty naughty.",3);
			Client::sendMessage(%cl,1,"You have left the mission area with a Deployable Generator, naughty naughty.");
			MessageAllExcept(%cl, 0, %clname @ " was trying to cheat buy taking a deployable Generator out side the mission area, and has been terminated.");
		}
		Game::refreshClientScore(%cl);
		return;
	}
	if (%pack == "DeployableInvPack")
	{
		Player::setItemCount(%player, DeployableInvPack, 0);
	}
  	if($Shifter::NoOutside)
  	{
		//if($Game::missionType == "CTF")
		//{
		  dbecho("Player " @ %player @ " has left the mission area. 10 Sec to Death");

	   	%cl = Player::getClient(%player);
		Client::sendMessage(%cl,1,"You have left the mission area. In 10 secs, you start to die!");
		%player.outArea=1;
		alertPlayer(%player, 5);
		//}
		//else dbecho("Player " @ %player @ " has left the mission area.");
  	}
}

function alertPlayer(%player, %count)
{

	if(%player.outArea == 1)
	{
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count == 4)
		{
			%set = nameToID("MissionCleanup/ObjectivesSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	  		GameBase::virtual(%obj, "playerLeaveMissionArea", %player);		
			schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		}	
		else if(%count > 1)
		   	schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		else
		   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) 
	{
		if(!Player::isDead(%player))
		{
		  	Player::setDamageFlash(%client,0.1);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
   			schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
		}
		else 
			playNextAnim(%client);	
	}
}



//=============================================================================================================
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;		
	Player::setAnimation(%client,$animNumber++);
}
//greyflcn
function Client::takeControl(%clientId, %objectId)
{
	if(%objectId == -1){return;}
	
	// If mounted to a vehicle then can't mount any other objects
	%pl = Client::getOwnedObject(%clientId);
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{
		return;
	}
	if(GameBase::getControlClient(%objectId) != -1)
	{
		dbecho("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	
        %player = Client::getOwnedObject(%clientId);
        %name = GameBase::getDataName(%objectId);
        %armor = Player::getArmor(%clientId);
        
        if(Player::getMountedItem(%player,$BackpackSlot) != Laptop)      //|| (%armor != "sarmor" && %armor != "sfemale" ))
        {		%turretType = GameBase::getDataName(%objectId);
				   if (!(Client::getOwnedObject(%clientId)).CommandTag && %turretType != CameraTurret && %turretType != DeployableHolo && %turretType != DeployableHolo2 && %turretType != DeployableMini && %turretType != DeployableSatchel && %turretType != MortarTurret && %turretType != DeployableMortar && !$TestCheats)
               {
               	Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
               	return;
               }
        }
			if (GameBase::getDataName(%objectId) == BarrageTurret)
			{
				Client::SendMessage(%clientId,0,"The AA Turret can not be controlled by players.");
				return;
			}
   	if(GameBase::getDamageState(%objectId) == "Enabled") 
   	{
   		Client::setControlObject(%clientId, %objectId);
   		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
   	Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}

function ixStartEMP(%clientId, %player)
{
	//%weapon = Player::getMountedItem(%player,$WeaponSlot);
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	%armor = player::getarmor(%player);
	//if(($WeaponAmmo[%weapon] == ""))
	//	Player::unmountItem(%player,$WeaponSlot);
	Client::sendMessage(%clientId,1,"You were hit with EMP!");
	if(%clientId.empTime == 0)
	{
		if (%armor == earmor || %armor == efemale)
		{
			GameBase::setEnergy(%player,45);
			if(%pack != energypack)
			{
				Player::unmountItem(%player,$WeaponSlot);
				GameBase::setRechargeRate(%player,2);
				%clientId.empTime = 8;
				checkPlayerEMP(%clientId, %player);
			}
			else
				Client::sendMessage(%clientId,1,"EMP Effects have dissapated.");
		}
		else
		{
			GameBase::setEnergy(%player,0);
			if(%pack != energypack)
			{
				Player::unmountItem(%player,$WeaponSlot);
				GameBase::setRechargeRate(%player,0);
				%clientId.empTime = 12;
				checkPlayerEMP(%clientId, %player);
			}
			else
				Client::sendMessage(%clientId,1,"EMP Effects have dissapated.");
		}
	}
	else
		%clientId.empTime = 10;
}
function checkPlayerEMP(%clientId, %player)
{
	if(%clientId.empTime > 0)
	{
		//ixEMPShock(%player);
		%clientId.empTime -= 1;
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",1,%player);
	}
	else
	{
		Client::sendMessage(%clientId,1,"EMP Effects have dissipated.");
		GameBase::setRechargeRate(%player,8);
		if(%armor == aarmor || %armor == afemale)
			GameBase::setRechargeRate(%player,10);
	}
}

function ixEMPShock(%this)
{
	%vel = Item::getVelocity(%this);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%this);
	Projectile::spawnProjectile("EMPShock",%trans,%this,%vel,%this);
} 

ExplosionData nullExp
{
	shapeName = "fusionex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.0;
	timeScale = 0.1;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

GrenadeData EMPShock
{
	bulletShapeName = "breath.dts";
	explosionTag = nullExp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.1;
	damageClass = 0;
	damageValue = 0.01;
	damageType = $TargetingDamageType;
	explosionRadius = 1;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 1;
	totalTime = 0.05;
	liveTime = 0.05;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "breath.dts";
};

//============================================================================= Poisoning

function Renegades_startBlind(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You are poisoned!");
	if(%clientId.poisonTime == 0)
	{
		
		Player::setDamageFlash(%player,0.75);
		%clientId.poisonTime = 15;
		checkPlayerBlind(%clientId, %player);
	}
	else
		%clientId.poisonTime = 15;
}


function checkPlayerBlind(%clientId, %player)
{

	if(%clientId.poisonTime > 0)
	{
		%clientId.poisonTime -= 2;  
		%drrate = GameBase::getDamageLevel(%player) + 0.07;
			if  (!Player::isDead(%player)) 
			{
				GameBase::setDamageLevel(%player, %drrate);  
				Player::setDamageFlash(%player,0.75);  
				if  (Player::isDead(%player))
				{
					messageall(0, Client::getName(%clientId) @ " died from a strange disease.");
					%clientId.scoreDeaths++;
		      		%clientId.score--;
					Game::refreshClientScore(%clientId);
					%clientId.poisonTime = 0;
				}
			}
			else
			{
		
			%clientId.poisonTime = 0;
		}
		

		schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",5,%player);
      }
	else
	{
		Client::sendMessage(%clientId,1,"The effects of the poison wear off.");		
	}			
}

//============================================================================= Flamer Burn

function Renegades_startBurn(%clientId, %player)
{

	Client::sendMessage(%clientId,1,"You are on fire!");
	
	if(%clientId.burnTime == 0)
	{
		Player::setDamageFlash(%player,0.50);
		%clientId.burnTime = 3;
		checkPlayerBurn(%clientId, %player);
	}
	else
		%clientId.burnTime = 7;
}

function checkPlayerBurn(%clientId, %player)
{

	if(%clientId.burnTime > 0)
	{
		%clientId.burnTime -= 1;  
		%drrate = GameBase::getDamageLevel(%player) + 0.01;
		if  (!Player::isDead(%player)) 
		{
			GameBase::setDamageLevel(%player, %drrate);  
			Player::setDamageFlash(%player,0.50);  
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " was incinerated.");
				%clientId.scoreDeaths++;
      				%clientId.score--;
				Game::refreshClientScore(%clientId);
				%clientId.burnTime = 0;
			}
		}
		else
		{
			%clientId.burnTime = 0;
		}
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",1,%player);
     	}
	else
	{
		Client::sendMessage(%clientId,1,"You stop burning.");
	}			
}

//============================================================================= Flag Shot Off
function DoTheFlagDrop(%player, %shooterId) 
{
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);
	%shooterName = Client::getName(%shooterId);

	if (%shooterid)
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of your back!");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of your back!");
			TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
		}
	}	
	else
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %dropClientName @ " has butter fingers and dropped the flag.");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %dropClientName @ " has butter fingers and dropped the flag.");
		}
	}
	GameBase::throw(%flag, %player, -15, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}

function Shifter_startHide(%player, %time)
{
	if(%time == "")
		%time = 18;
	Player::setDetectParameters(%player, 1000, 3000);
	%player.blindTime = %time;
	checkPlayerHide(%player);
}

function checkPlayerHide(%player)
{
	if(%player.blindTime > 0)
	{
		%player.blindTime -= 1;
		Player::setDetectParameters(%player, 1000, 3000);
		schedule("checkPlayerHide("@ %player @");", 1.0);
	}
	else
	{
		Player::setDetectParameters(%player , 0.027, 0);
		%player.blindTime = 0;
	}			
}

function Cloaker(%player)
{
	%cl = Player::getclient(%player);
	%plTeam = GameBase::GetTeam(%player);
	%UserPos = gamebase::getPosition(%player);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%TargetPlayer = Client::getOwnedObject(%clientId);
		if(GameBase::GetTeam(%clientId) != %plTeam)
		{
			%TargetPos = gamebase::getPosition(%TargetPlayer);
			%dist = Vector::getDistance(%UserPos, %TargetPos);
			%matrix = %clientId @ %player;
			if(%dist < 140 && %player.cloaked == 1)
			{
				if($cloakEffected[%matrix] != 1)
				{
					Player::setDetectParameters(%Targetplayer, 90, 300);
					$TotalCloaks[%ClientId]++;
					$cloakEffected[%matrix] = 1;
				}
			}
			else
			{
				if($cloakEffected[%matrix] == 1) $TotalCloaks[%ClientId]--;
				if($TotalCloaks[%ClientId] < 1)
				{
					Player::setDetectParameters(%Targetplayer, 0.027, 0);
					$cloakEffected[%matrix] = 0;
				}
			}
		}
	}
	if((Player::isTriggered(%player, $BackPackSlot) && Player::getMountedItem(%player, $BackPackSlot) == "CloakingDevice") || %cl.cloaktime) 
		schedule("Cloaker(" @ %player @ ");", 0.5, %player);
}