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
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
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

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	if($debug) echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	%damagedClient = Player::getClient(%this);
	%shooterClient = %object;
	%armor = Player::getArmor(%this);

	if (getObjectType(%object) == "Player")
		%shooterClient = Player::getClient(%object);

	if (Player::isDead(%this))
		return;

	if (%shooterClient)
		%damagedClient.lastdamager = %shooterClient; 

	if (Player::isExposed(%this))
	{
		Player::applyImpulse(%this,%mom);
		//======================================================================== Determin Team Damage
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) )
		{
			if (%shooterClient)
			{
				%curTime = getSimTime();

			   if ((%curTime - %this.DamageTime > 1.5 || %this.LastHarm != %shooterClient) && (%type != $GravDamageType) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) 
			   {
					if(%type != $MineDamageType)
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
			            		%shooterClient.score = (%shooterClient.score -1);
						if ($ScoreOn) bottomprint(%shooterClient, "You harmed your team mate... Score -1 = " @ %shooterClient.score @ " Total Score");
					}
					else
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");

					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
			%friendFire = $Server::TeamDamageScale;
		else  
			%friendFire = 1.0;	

		//============================================================== Reaction Damage
		if ($Shifter::Reactions)
		{
			if(%vertPos == "torso")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%damagedClient,%kick, (%kick/2));
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%damagedClient, -%kick, (%kick/2));
					if (%kick > 45)
					{
						%item = Player::getMountedItem(%damagedClient,$BackpackSlot);
						Player::dropItem(%damagedClient,%item);
					}
				}
			}
			else if (%vertPos == "legs")
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
			else if (%vertPos == "head")
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
			}
		}

		//============================================================== More Damage To Head Shots
		if (!Player::isDead(%this))
		{
			%armor = Player::getArmor(%this);
			
			if(%vertPos == "head")
			{
				if (%type == $LaserDamageType || %type == $SniperDamageType)
				{
					%value += %value;
				}
				else
				{
					if(%armor == "harmor")
					{ 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						{
							%value += (%value * 0.2);
						}
					}
					else
					{
						%value += (%value * 0.5);
					}
				}
			}
			
			//================================================================ Shield Pack On
			if (%type != -1 && %this.shieldStrength && %type != $HBlasterDamageType)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				if (%type == $ElectricityDamageType)
					%strength *= 0.0;

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
					%value = %value - %absorb;
				}
			}
			//============================================================ Flash Damage Does EMP Effect
			if( ((%type == $FlashDamageType) || (%type == $NukeDamageType)) )
			{
				Insomniax_startEMP(%damagedClient, %this, 14);
				%emptime = (%value * 10);
				if ($debug) echo ("Emp Time = " @ %emptime);
			}
			//============================================================ Juggernaught Shield
			if ((%armor == "jarmor") && (!%this.shieldStrength))
				Renegades_startShield(%damagedClient, %this);

			//============================================================ Merc Booster Pop
			%clientId = %damagedClient;
			if (%armor == "marmor" || %armor == "mfemale")
			{
				if (%clientId.boostercool)
				{
					%rnd = (getRandom());
					if( (%type == $LaserDamageType || %type == $SniperDamageType || %type == $BulletDamageType) && (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back" || %quadrant == "middle_middle") && ( Client::getTeam(%clientId) != Client::getTeam(%shooterClient) ) )
					{
						if (%rnd > 0.5)
						{
							Player::blowUp(%this);
							%value = %value * 10;
							bottomprint(%clientId, "Your booster popped!");
							DeployFrags(%this, 10, %clientId);
							GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.02, 2, %shooterClient); 
							GameBase::applyDamage(%player, $PlasmaDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %shooterClient);
						}
					}
					if ( (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $ElectricityDamageType || %type == $NukeDamageType) && (Client::getTeam(%clientId) != Client::getTeam(%shooterClient) ) )
					{
						if (%rnd > 0.6)
						{
							Player::blowUp(%this);
							%value = %value * 10;
							bottomprint(%clientId, "Your booster popped!");
							DeployFrags(%this, 10, %clientId);
							GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.02, 2, %shooterClient); 
							GameBase::applyDamage(%player, $PlasmaDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %shooterClient);
						}
					}
				}
			}
			//======================================================= Cloaking Blast
			if (%type == $CloakDamageType)
			{
		        	GameBase::startFadeOut(%this);
		        	schedule("GameBase::startFadeIn(" @ %this @ ");", 90);
			}

			//======================================================= Life Drain - Poison

			if ((%type == $EnergyDamageType) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) ) )
			{
				%armor = Player::getArmor(%this);
				if ((%armor != "aarmor") && (%armor != "afemale"))
					Renegades_startBlind(%damagedClient, %this);
			}


			//======================================================= Grav Damage 
			if (%type == $GravDamageType){return;}

			//======================================================= Plasma Damage Catches Player On Fire
			if (((%type == $PlasmaDamageType) || (%type == $NukeDamageType)) && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
			{
				%rnd = floor(getRandom() * 10);
				if(%rnd > 7)
				{
					%armor = Player::getArmor(%this);
					if ( (%armor != "barmor") && (%armor != "bfemale"))
						Renegades_startBurn(%damagedClient, %this);
				}
			}
			//================================================= Body Area Damage Effects

  			if (%value) 
			{
				%armor = Player::getArmor(%this);
				%hitdamageval = 0.05;
				%hittolerance = 0.25;
				%weaponType = Player::getMountedItem(%this,$WeaponSlot);

				//============================================ Suicide Pack Explodes
				if((Player::getMountedItem(%this,$BackpackSlot) == SuicidePack))
				{						
					if( ((%type == $LaserDamageType) || (%type == $SniperDamageType) || (%type == $BulletDamageType)) && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")  && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
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
				//=========================================== Weapons Drop On Sniper Shot

				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun"))
				{
					Player::dropItem(%this,%weaponType);
					%dlevel = GameBase::getDamageLevel(%this) + 0.05;
					Client::sendMessage(Player::getClient(%shooterClient),0,
					"You shot the " @ %weaponType @ " out of "  @ Client::getName(%damagedClient) @ "'s hand!");
				}
				else
				{
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
					//========================= Check for flag kick on sniper shot - *IX*Savage1
					%flag = Player::getMountedItem(%this,$FlagSlot);
					if((%value > %hittolerance) && (%type == $LaserDamageType || %type = $SniperDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_middle") && (%vertpos == "head") && (%flag == "flag") && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
						DoTheFlagDrop(%this, %shooterClient);

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
						{
							itemfuncs::ammoboom(%this);
						}
						if (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $ElectricityDamageType || %type == $NukeDamageType)
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
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $NukeDamageType )) || (Player::getLastContactCount(%this) > 6) )
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
						else if (%vertPos == "torso")
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
						else if (%vertPos == "legs")
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" || %quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
	
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;

					Client::onKilled(%damagedClient,%shooterClient, %type, %vertPos, %quadrant);
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{return %an[floor(getRandom() * (%num - 0.01))];}

//========================================================================================================================================
//==================================================== Collisions With Players ===========================================================
//========================================================================================================================================

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this))
	{
		%pickarmor = Player::getArmor(%object);
		%deadarmor = Player::getArmor(%this);
		
		if (getObjectType(%object) == "Player")
		{
			%sound = false;
			%max = getNumItems();
			
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%count = Player::getItemCount(%this,%i);
				%itemname = getItemData(%i);
								
				if (%itemname == "Grenade" && %pickarmor != %deadarmor)
				{
					%itemname = "";
				}
				
				if (%itemname == "Beacon" && %pickarmor == "jarmor")
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
			
			if (%sound && gamebase::getteam(%this) != gamebase::getteam(%object))
			{
				if (%deadarmor == "lfemale" || %deadarmor == "larmor")
				{
					if (%pickarmor == "lfemale" || %pickarmor == "larmor")
					{
					}
					else
					{
						bottomprint(player::getclient(%object), "<jc>You are poisoned by assassins items.");
						Renegades_startBlind(player::getclient(%object), %object);
					}
				}
			}
			
			if (%sound)
			{
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	
//=================================================================================================================
// 												Werewolfs Bot stuff
//												 Dealing with Bots
//												   Bot Collision	                                          Edited By Emo1313
//=================================================================================================================

	if (Player::isAIControlled(%this) == "true" && Player::isAIControlled(%object) == "false" && (%object != "Flier") && (!Player::isDead(%this) || !Player::isDead(%object)))
	{
											
		%Player1 = Player::getClient(%this);
		%Player2 = Player::getClient(%object);

		%aiId = Player::getClient(%this);
		%aiName = Client::GetName(%aiId);
		%aiTeam = Client::GetTeam(%this);	 
		%objTeam = Client::GetTeam(%object);
		echo("BOT: Collision <" @ %aiName @ " - " @ %aiId @ ">");
		
//======================================================================================================== Class Specific

		if (%aiTeam == %objTeam)                          //===== Make Sure Bot Doesnt Repair Other Teams Stuff
		{

		}

//====================================================================================== Attempt Object Move Around

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
		else
        	{
			echo ( %aiId @ " Can not avoid...");
		}

	}

//=============================================================================================== End AI Collision
//=============================================================================================== Scout Steal Items
	if (getObjectType(%object) == "Player") 
	{
		if (Player::isDead(%object))
		{
			return;
		}
		
		if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
		{
			%armor = Player::getArmor(%object);
			if (%armor == "sarmor" || %armor == "sfemale")
			{
				// Transfer all our items to the player and drop players pack...
				%DropPack = (Player::getMountedItem(%this, $BackPackSlot));
				Player::dropItem(%this, %DropPack) ;

				%FlagDrop = (Player::getMountedItem(%this, $FlagSlot));
				Player::dropItem(%this, %FlagDrop) ;
				
				Player::setDamageFlash(%this,0.95);
				%sound = false;
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
							%sound = true;
						}
					}
				}
				if (%sound)
				{
					playSound(SoundPickupItem,GameBase::getPosition(%this));
				}
			}		
		}
	}

//============================================================================= Eng. Medic Touch
		if (getObjectType(%object) == "Player") 
		{
			if (Player::isDead(%object))
			{
				return;
			}
				if (Player::isDead(%this))
				{
					return;
				}

				if(GameBase::getTeam(%object) == GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					if (%armor == "earmor" || %armor == "efemale")
			      		{
						if(GameBase::getDamageLevel(%this)) 
						{
							GameBase::repairDamage(%this,0.10);
							GameBase::playSound(%this,ForceFieldOpen,0);
				      		}
					}		
				}	
			}

//============================================================================= Arbitor Death Touch
	
			if (getObjectType(%object) == "Player") 
			{
				if (Player::isDead(%this))
				{
					return;
				}
				
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);
	
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					%tarmor = Player::getArmor(%this);
					
					if ((%armor == "aarmor" || %armor == "afemale") && (%tarmor != "aarmor" && %tarmor != "afemale" && %tarmor != "larmor" && %tarmor != "lfemale" && %tarmor != "marmor" && %tarmor != "mfemale"))
		    	  		{
		    	  			if($debug) echo ("Shock From " @ %armor @ " to " @ %tarmor @ ".");
						GameBase::applyDamage(%this,$FlashDamageType,0.10,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  
						if(GameBase::getDamageLevel(%object)) 
						{
							GameBase::repairDamage(%object,0.30);
						}
						GameBase::playSound(%this,ForceFieldOpen,0);
						Client::sendMessage(Player::getClient(%object),1,
						"You drain "  @ Client::getName(%thisId) @ "'s energy...");
					}		
				}	
			}
	
//============================================================================= Assassin Death Touch
			if (getObjectType(%object) == "Player") 
			{
				if (Player::isDead(%this))
				{
					return;
				}
			
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);

				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
		
					if ((%armor == "larmor") || (%armor == "lfemale"))
		    	  	{
						GameBase::applyDamage(%this,$EnergyDamageType,0.25,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  
						GameBase::playSound(%this,ForceFieldOpen,0);
								
						Client::sendMessage(Player::getClient(%object),1,
						"You death touch "  @ Client::getName(%thisId) @ ".");
				
					}		
				}	
			}

//============================================================================= Spy Disguise - Skin Snatch

			if (getObjectType(%object) == "Player") 
			{		
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);

				if (Player::isDead(%object))
				{
					return;
				}
		
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					if (%armor == "spyarmor" || %armor == "spyfemale")
			      	{
						%grabskin = Client::getSkinBase(%thisId);
						
						if ($Shifter::SkinDiff)
							%origskin = Client::getSkinBase(%cliendId);
						
						$Shifter::SkinDiff = "True";
						Client::setSkin(%cliendId,(%grabskin));

						GameBase::playSound(%this,ForceFieldOpen,0);
						Client::sendMessage(%cliendId,0,"You went undercover disguised as " @ Client::getName(%thisId) @ " !");
						Client::sendMessage(Player::getClient(%object),1,"You go undercover disguised as "  @ Client::getName(%thisId) @ "!" );

	        				schedule("Client::setSkin(" @ %cliendId @ ",(" @(%origskin)@ "));", 120);
						schedule("$Shifter::SkinDiff = False;",120);
					}	
				}		
			}
//========================================================================================== Eng Touch Heal All			
			%shape = (GameBase::getDataName(%object)).shapeFile;
			%name = GameBase::getMapName(%object);
			%datab = GameBase::getDataName(%object);
	
			if ($Shifter::EngHealAll && checkhackable(%name, %shape) == 0)
			{
				if(GameBase::getTeam(%object) == GameBase::getTeam(%this))
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

	%pack = Player::getMountedItem(%player,$BackpackSlot);
	
	if (%pack == "PowerGeneratorPack" || %pack == "CoolLauncher" || %pack == "EmplacementPack" || %pack == "airbase")
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
  	if($Shifter::NoOutside)
  	{
		if($Game::missionType == "CTF")
		{
		  if ($debug) echo("Player " @ %player @ " has left the mission area. 10 Sec to Death");

		   	%cl = Player::getClient(%player);
			Client::sendMessage(%cl,1,"You have left the mission area. In 10 secs, you start to die!");
			%player.outArea=1;
			alertPlayer(%player, 5);
		}
		else if ($debug) echo("Player " @ %player @ " has left the mission area.");
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
		echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	
        %player = Client::getOwnedObject(%clientId);
        %name = GameBase::getDataName(%objectId);
        %armor = Player::getArmor(%clientId);
        
        if(Player::getMountedItem(%player,$BackpackSlot) != Laptop && (%armor != "sarmor" || %armor != "sfemale" ))
        {
                if (!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableHolo && GameBase::getDataName(%objectId) != DeployableHolo2 && GameBase::getDataName(%objectId) != DeployableMini && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats)
                {
                        Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
                        return;
                }
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

//============================================================================= EMP Effects

function Insomniax_startEMP(%clientId, %player, %time)
{

	Client::sendMessage(%clientId,1,"You were hit with EMP!");
	Player::unmountItem(%player,$WeaponSlot);
	%armor = player::getarmor(%player);

	if($empTime[%clientId] == 0)
	{
		if (%armor == earmor || %armor == efemale)
		{
			GameBase::setEnergy(%player,45);
			GameBase::setRechargeRate(%player,2);
			$empTime[%clientId] = 8;
			checkPlayerEMP(%clientId, %player);
		}
		else
		{
			GameBase::setEnergy(%player,0);
			GameBase::setRechargeRate(%player,0);
			$empTime[%clientId] = 12;
			checkPlayerEMP(%clientId, %player);
		}
	}
	else
	{
		if (%time)
			$empTime[%clientId] = %time;
		else
			$empTime[%clientId] = 14;
	}
}

function checkPlayerEMP(%clientId, %player)
{

	if($empTime[%clientId] > 0)
	{
		$empTime[%clientId] -= 2;  
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
	else
	{
		Client::sendMessage(%clientId,1,"EMP Effects have dissapated.");
		GameBase::setRechargeRate(%player,8);
	}			
}

//============================================================================= Poisoning

function Renegades_startBlind(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You are poisoned!");
	if($poisonTime[%clientId] == 0)
	{
		
		Player::setDamageFlash(%player,0.75);
		$poisonTime[%clientId] = 15;
		checkPlayerBlind(%clientId, %player);
	}
	else
		$poisonTime[%clientId] = 15;
}


function checkPlayerBlind(%clientId, %player)
{

	if($poisonTime[%clientId] > 0)
	{
		$poisonTime[%clientId] -= 2;  
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
					$poisonTime[%clientId] = 0;
				}
			}
			else
			{
		
			$poisonTime[%clientId] = 0;
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
	
	if($burnTime[%clientId] == 0)
	{
		Player::setDamageFlash(%player,0.50);
		$burnTime[%clientId] = 5;
		checkPlayerBurn(%clientId, %player);
	}
	else
		$burnTime[%clientId] = 7;
}

function checkPlayerBurn(%clientId, %player)
{

	if($burnTime[%clientId] > 0)
	{
		$burnTime[%clientId] -= 1;  
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
				$burnTime[%clientId] = 0;
			}
		}
		else
		{
			$burnTime[%clientId] = 0;
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