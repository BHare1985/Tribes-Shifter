    // Tried some weather stuff from RPG, didnt work to well, but it was cool, although, have of tribes players
    // have weather off anyway. thats y im stopping this, although, i may pick it up one day.
//--------------------------------------

//function RecursiveWorld(%seconds)
//{
   // %si = $NM::skyIndex;
   // %wi = $NM::worldIndex;
   // %timeOfDay = $worldTypes[%wi, time, %si];
   // %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   // %dawn = $Server::timeLimit / 1;
   // %dawn = $dawn;
  //  %day = $Server::timeLimit / 2;
  //  %day = $day;
  //  %dusk = $Server::timeLimit / 3;
  //  %dusk = $dusk;
  //  %night = $Server::timeLimit / 4;
  //  %night = $night;
  //  if(%timeOfDay == Night || %timeOfDay == Midnight)
  //    newObject("Sun", Planet, 0, 0, 60, T, F, 0.4, 0.4, 0.4, 0.15, 0.15, 0.15);
  // else
  //    newObject("Sun", Planet, 0, 0, 60, T, F, 0.7, 0.7, 0.7, 0.3, 0.3, 0.3);
 //  addToSet("MissionGroup\\Landscape", "Sun");
   
  //  if(%curTimeLeft >= 3598 && %curTimeLeft <= 3600) // half way threw  $ticker[2] >= ($ChangeWeatherFreq / %seconds)
	//{
		//change weather call
	//	ChangeWeather();


	//}
	//if(%curTimeLeft >= 3598 && %curTimeLeft <= 3600) // dawn  %curTimeLeft >= 3598 && %curTimeLeft <= 3600
	//{
    //    echo("dawn");
     //   messageall(3, "Its now Dawn...");
	//	setTerrainVisibility(8, 800, $dawnHaze);
	//	ChangeSky($dawnSky);
    //    $dawnTime = true;
   // }
   // if(%curTimeLeft >= 2398 && %curTimeLeft <= 2400) // day
	//{
   //     echo("day");
   // //    messageall(3, "Its now Daytime...");
	//	setTerrainVisibility(8, 800, $dayHaze);
	//	ChangeSky($daySky);
    //    $dayTime = true;
   //}
   // if(%curTimeLeft >= 1198 && %curTimeLeft <= 1200) // dusk
	//{
       // echo("dusk");
       // messageall(3, "Its now Dusk...");
		//setTerrainVisibility(8, 800, $duskHaze);
		//ChangeSky($duskSky);
       // $duskTime = true;
    //}
    //if(%curTimeLeft >= 898 && %curTimeLeft <= 900) // night
	//{
    //    echo("night");
    //    messageall(3, "Its now Nighttime");
	//	setTerrainVisibility(8, 800, $nightHaze);
	//	ChangeSky($nightSky);
     //   $nightTime = true;
    //}
    //if($nightTime)
   // {
    //    %skydmlName = $worldTypes[%wi, skydml, %si];
    //    if(%skydmlname == "starfield")
     //   {
     //   newObject(Stars, StarField);
     //   addToSet("MissionGroup\\Landscape", Stars);
     //   %skydmlName = "";
    //    }

     //   newObject(Sky, Sky, 0, 0, 0, %skydmlName, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
     //   addToSet("MissionGroup\\Landscape", Sky);
  // }
 
// schedule("RecursiveWorld(" @ %seconds @ ");", %seconds);
// }
// function ChangeSky(%sky) // below recursive world
//{
 //   echo("changed sky");
 // %group = nameToId("MissionGroup\\LandScape");
//   //%count = Group::objectCount(%group);
     //%skydmlName = $worldTypes[%wi, skydml, %si];
 //   %object = Group::getObject(%group);
 // if(isObject("Sky"))
 //    deleteObject("Sky");



	//%newsky = newObject(Sky, Sky, 0, 0, 0, %sky, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
	//addToSet("MissionGroup\\LandScape", %newsky);
//}
 
// function ChangeWeather(%seconds) // below recursive
//{



	//credits go to LabRat for the original code for this... Thanks Lab!
      // if(OddsAre(1))
      // {
		///$isRaining = "";

	//	%intensity = getRandom();// echo(%intensity);

	//	%x = -1 + (getRandom() * 1.5); // echo(%x);
	//	%y = -1 + (getRandom() * 1.5); // echo(%y);
	//	%z = -300 + (floor(getRandom() * 40)); //  echo(%z);
		//%vec = %x @ " " @ %y @ " " @ %z;        //  echo(%vec);

	//	%t = floor(getRandom() * 100);   // echo(%t);
	//	if(%t >= 0 && %t < 20)
	//	{
	///		%type = 1;			//rain
	//		$isRaining = True;
			//setTerrainVisibility(8, 600, 0);
	//	}
	//	else
	//	{
	//		%type = -1;			//stop any weather
			//setTerrainVisibility(8, 1000, 700);
	//	}
    //       echo(%type);
	//	if(isObject("weather"))
	//		deleteObject("weather");

	//	if(%type == 1)
	//		%weather = newObject("weather", Snowfall, %intensity, %vec, 0, %type);
//   }
//   schedule("ChangeWeather(" @ %seconds @ ");", %seconds);
//}
//function OddsAre(%n)      // below all
//{
// echo("OddsAre(" @ %n @ ")");

	//%a = floor(getRandom() * %n);
	//if(%a == %n-1)
	//	return True;
	//else
	////	return False;
//}

