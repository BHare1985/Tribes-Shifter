
$Happy::Time = 15;   // shuffle time + 0~15 random 
$Happy::Dist = 600;   // random distance around clients 

//do nothings..
function HappyBreakerStand::onDamage(){}
function HappyBreakerStand::onCollision(){}
function HappyBreakerStand::onAdd(){}
function HappyBreakerJack::onplayercontact(){}
function HappyBreakerJack:::onDamage(){}
function HappyBreakerJack:::onCollision(){}
function HappyBreakerJack:::onAdd(){}

function HappyBreaker::CreateStuff() 
{ 
   %Group = newObject("HappyFakes", SimGroup); 
   addToSet("MissionCleanup", %Group);       
   %Group = newObject("HappyBreakerStands", SimGroup); 
   addToSet("MissionCleanup", %Group);    
   
   %itemCount = $Cheating::NofogBots; 
       
   for (%i=0; %i < %itemCount; %i++) 
   { 
      //create Fakey dude 
      		
		%aiName = getword($Cheating::NofogBotNames,%i);//
		if(AI::spawn( %aiName, "HappyBreakerJack", %spawnPos, %spawnRot,%aiName, "male2" ))	
		{
			%aiId = AI::getId(%aiName);	//return cl#
			%player = Client::getOwnedObject(%aiId);
			GameBase::startFadeOut(%player);
			addtoset("MissionCleanup/HappyFakes", %player);
			GameBase::setDamageLevel(%player, floor(getrandom() * 400));
			schedule("HappyBreaker::PickRandomPos("@%player@");",%i);					
		}
    
     		 //create Fakey flag 
      		%flagobj = newobject("flag1", "item", "HappyBreakerFlag", 1, false); 
      		addtoset("MissionCleanup/HappyFakes", %flagobj); 
      		schedule("HappyBreaker::PickRandomPos("@%flagobj@");",%i); 
      		schedule("HappyBreaker::PickRandomPos();",$Happy::Time); 
      	}
} 


// H'ok, we're going to move these dudes in a v shaped path to their new home so they don't collide with players when moving.
// Moving them in a more random way now, instead of all at once. Less server load and goofyness.
// We're also going to delete their stands a little early so we get some movement, even if it's just falling.... -Plasmatic
function HappyBreaker::PickRandomPos(%object)
{	
	if(%object != -1 && %object != "")
	{
	%clients = getnumclients()-1;
	if(%clients != -1)
	{
		if(%object.camera != -1 && %object.camera != "")
		deleteobject(%object.camera);
		%newPos = vector::add(gamebase::getposition(%object),"0 0 -750");
		schedule("GameBase::setPosition("@%object@",\""@%newPos@"\");",2);		
		if($Happy::ClientIndex > %clients)
			$Happy::ClientIndex = 0;
		%client = getClientByIndex($Happy::ClientIndex);
		%clPos = gamebase::getposition(%client);
		%try = 0;
		%continue = "";
		while(!%continue && %try < 10)
		{
			%try++;
			%newpos = vector::add(%clPos,(getrandom()-0.5)*$Happy::Dist @" "@(getrandom()-0.5)*$Happy::Dist @ " 0");	
			%continue = HappyBreaker::CheckVertical(%newpos,%object);
			//echo("Moving Object "@%object@" around "@%client@" try "@%try);	
		}
		$Happy::ClientIndex++;
	}
	%Shuffle = $Happy::Time + getrandom()*15;
	schedule("HappyBreaker::PickRandomPos("@%object@");",%Shuffle);
}
}


function HappyBreaker::CheckVertical(%pos,%object)
{
	if(%object != -1 && %object != "")
	{
	//looking up..  -plasmatic	
	%camera = newObject("Camera","Turret",HappyBreakerStand,true);
	addtoset("MissionCleanup/HappyBreakerStands", %camera);
	GameBase::setPosition(%camera,vector::add(%pos,"0 0 -3000"));
	GameBase::startFadeOut(%camera);
	if(GameBase::getLOSInfo(%camera,5000,"1.5708 0 0"))
	{	
		
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object	
		
		%name = getObjectType($los::object);
		if(%name == SimTerrain)
		{
			%newPos = vector::add($los::position,"0 0 -3.5");//players are 2.2m tall -plasmatic
			GameBase::setPosition(%camera,%newPos);
			Item::setVelocity(%object,"0 0 0");
			
			schedule("GameBase::setPosition("@%object@",\""@%newPos@"\");",2.5);
			%object.camera = %camera;
			return true;
		}	
	}
	
	if(%camera != -1 && %camera != "")
	deleteobject(%camera);	//We ain't found shit!
	return false;	
}
}
function AddConnectingPlayerToBots(%aiName)
{
		if(AI::spawn( %aiName, "HappyBreakerJack", %spawnPos, %spawnRot,%aiName, "male2" ))	
		{
			%aiId = AI::getId(%aiName);	//return cl#
			%player = Client::getOwnedObject(%aiId);
			GameBase::startFadeOut(%player);
			addtoset("MissionCleanup/HappyFakes", %player);
			GameBase::setDamageLevel(%player, floor(getrandom() * 400));	
			schedule("HappyBreaker::PickRandomPos("@%player@");",$Happy::Time);				
		}
}