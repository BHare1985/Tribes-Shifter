//greyflcn
ExplosionData quietGrenadeExp
{
   shapeName = "fiery.dts";
   //soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   //hasLight   = true;
   lightRange = 9.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData TeleExp
{
   shapeName = "shield_large.dts";
   //soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData starExp
{
	shapeName = "mine.dts"; //smoke.dtschainspk
   soundId   = SoundPickupWeapon;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 4.0;

   timeScale = 4.0;

   timeZero = 0.250;
   timeOne  = 0.661;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData RepMineExp
{
   shapeName = "plasmaex.dts";
   soundId   = RepExp;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };

};

ExplosionData flamerExp
{
   shapeName = "plasmaex.dts";
   soundId   = quietExp4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData IonGunExp
{
   shapeName = "fusionex.dts";
   soundId   = quietIonExp;//turretExplosion;

   faceCamera = true;
   //randomSpin = true;
   //hasLight   = true;
   lightRange = 2.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData GH1Exp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   //hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData GH2Exp
{
   shapeName = "bluex.dts";
   //soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   //hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData boosterExp
{
   shapeName = "plasmaex.dts";

   faceCamera = true;
   randomSpin = true;
   lightRange = 3.0;

   timeZero = 0.100;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData vehiclesmokeExp
{
	shapeName = "smoke.dts";

	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 0;

	timeZero = 1.250;
	timeOne = 1.550;

	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData rocketExp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

ExplosionData energyExp
{
   shapeName = "enex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = True;
};

ExplosionData blasterExp
{
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData hblasterExp
{
   shapeName = "paint.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

ExplosionData plasmaExp
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData onFireExp
{
   shapeName = "plasmaex.dts";

   faceCamera = true;
   randomSpin = true;
   lightRange = 3.0;

   timeZero = 0.100;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};

ExplosionData plasmaExp2
{
   shapeName = "plasmaex.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 15.0;

   timeScale = 2.5;
   timeZero = 0.200;
   timeOne  = 2.2;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 1.375, 1.5, 1.9 };
};


ExplosionData grenadeExp
{
   shapeName = "fiery.dts";
   soundId   = bigExplosion3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData mineExp
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData mortarExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData quietMortarExp
{
   shapeName = "mortarex.dts";
   //soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   //hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData turretExp
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData quietbulletExp0
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = false;

   timeZero = 0.100;
   timeOne  = 0.900;

   shiftPosition = True;

   //hasLight   = false;
   //lightRange = 0.0;
	//colors[0] = { 0.0, 0.0, 0.0 };
	//colors[1] = { 0.0, 0.0, 0.0 };
	//colors[2] = { 0.0, 0.0, 0.0 };
	//radFactors = { 0.0, 0.0, 0.0 };
};

ExplosionData bulletExp0
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData bulletExp1
{
   shapeName = "chainspk.dts";
   soundId   = ricochet2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 0.5 };
   colors[2]  = { 1.0, 1.0, 0.5 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData bulletExp2
{
   shapeName = "chainspk.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0,  0.0, 0.0 };
   colors[1]  = { 0.75, 1.0, 1.0 };
   colors[2]  = { 0.75, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData debrisExpSmall
{
   shapeName = "tumult_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpMedium
{
   shapeName = "tumult_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData debrisExpLarge
{
   shapeName = "tumult_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 5.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpSmall
{
   shapeName = "flash_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpMedium
{
   shapeName = "flash_medium.dts";
   soundId   = debrisMediumExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.75;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData flashExpLarge
{
   shapeName = "flash_large.dts";
   soundId   = debrisLargeExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData Shockwave
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 6.0;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData LargeShockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData QuietLargeShockwave
{
   shapeName = "shockwave_large.dts";
   //soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   //hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};

ExplosionData NukeShockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = true;
   hasLight   = true;
   lightRange = 50.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 4.0, 0.0 };
   colors[2]  = { 4.0, 2.0, 0.0 };
   radFactors = { 1.0, 1.5, 0.0 };
};

ExplosionData napExp 
{    
	shapeName = "fiery.dts";
	soundId   = explosion4;
	faceCamera = true;  
	randomSpin = true;   
	hasLight   = true;   
	lightRange = 35.0; 
	timeScale = 8.0;  
	timeZero = 0.200;  
	timeOne  = 0.950;  
	colors[0]  = { 1.0, 1.0,  0.0 };
	colors[1]  = { 1.0, 0.4, 0.0 };
	colors[2]  = { 1.0, 0.0, 0.0 };
	radFactors = { 0.8, 0.9, 1.0 };
};

ExplosionData SockExp 
{  
	shapeName = "tumult_large.dts";  
	soundId   = debrisLargeExplosion; 
	faceCamera = true;  
	randomSpin = true; 
	hasLight   = true; 
	lightRange = 23.0; 
	timeScale = 5.0; 
	timeZero = 0.250; 
	timeOne  = 0.850;  
	colors[0]  = { 1.0, 1.0,  0.1 };
	colors[1]  = { 1.0, 1.0,  1.0 };
	colors[2]  = { 1.0, 1.0, 1.0 };  
	radFactors = { 0.5, 1.0, 1.0 };
};
ExplosionData fakeExp 
{  
	shapeName = "breath.dts"; 
	faceCamera = true;  
	randomSpin = true;  
	hasLight   = false;  
	lightRange = 0;    
	timeZero = 0.100;   
	timeOne  = 0.500;  
	colors[0]  = { 0.0, 0.0, 0.0 }; 
	colors[1]  = { 1.0, 1.0, 0.5 }; 
	colors[2]  = { 1.0, 1.0, 0.5 };  
	radFactors = { 0.0, 1.0, 0.0 };  
	shiftPosition = False;
}; 

ExplosionData puffEx
{   
	shapeName = "mortarex.dts"; 
	soundId   = shockExplosion; 
	faceCamera = true;  
	randomSpin = true;  
	hasLight   = false;  
	lightRange = 0;  
	timeScale = 15.0;   
	timeZero = 0.0;   
	timeOne  = 0.500; 
	colors[0]  = { 1.0, 1.0, 1.0 }; 
	colors[1]  = { 1.0, 1.0, 0.2 };
	colors[2]  = { 1.0, 1.0, 0.0 }; 
	radFactors = { 1.0, 1.0, 1.0 };
};
ExplosionData ShockwaveTwo
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 50.0;
   timeScale = 5.0;   
   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 5.0, 4.0, 5.0 };
   colors[2]  = { 0.1, 0.0, 10.0 };
   radFactors = { 1.0, 1.0, 3.0 };
};

ExplosionData ShockwaveThree
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 25.0;
   timeScale = 1.0;   
   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 5.0, 4.0, 5.0 };
   colors[2]  = { 0.1, 0.0, 10.0 };
   radFactors = { 0.1, 0.1, 3.0 };
};

ExplosionData ShockwaveFour
{
   shapeName = "shield_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;
   timeScale = 0.5;   
   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 0.0, 0.0, 5.0 };
   colors[2]  = { 0.1, 0.0, 10.0 };
   radFactors = { 0.0, 0.0, 3.0 };
};

ExplosionData modBomb
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;
   timeScale = 0.5;   
   timeZero = 0.100;
   timeOne  = 0.400;

   colors[0]  = { 0.0, 0.0, 1.0 };
   colors[1]  = { 0.0, 0.0, 5.0 };
   colors[2]  = { 0.1, 0.0, 10.0 };
   radFactors = { 0.0, 0.0, 3.0 };
};

ExplosionData NukeWave
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 55.0;
   timeScale = 1.5;   
   timeZero = 0.100;
   timeOne  = 0.300;
   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};