ExplosionData TeleFX
{
   shapeName = "fusionex.dts";

   faceCamera = TRUE;
   randomSpin = TRUE;
   hasLight   = TRUE;
   lightRange = 3.0;
	 timeScale = 3.5;
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
MineData TeleSparkle
{
	className = "Mine";
 	description = "A Cowpie";
 	shapeFile = "breath";
 	shadowDetailMask = 4;
 	explosionId = TeleFX;
	explosionRadius = 0.0;
	damageValue = 0;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.5;
	collideWithOwner   = FALSE;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
function TeleSparkle::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function Teleport::CreateFX(%this)
{
	%pos = GameBase::GetPosition(%this);
	%rot = GameBase::GetRotation(%this);
	%pos0	=	Vector::Add(%pos,	EmplacementPack::RotVector("0	2	2",	%rot));
	%pos1	=	Vector::Add(%pos,	EmplacementPack::RotVector("2	0	2",	%rot));
	%pos2	=	Vector::Add(%pos,	EmplacementPack::RotVector("-2 0 2", %rot));
	%pos3	=	Vector::Add(%pos,	EmplacementPack::RotVector("0	-2 2", %rot));
	%poss0 = Vector::Add(%pos, EmplacementPack::RotVector("0 2 3.5", %rot));
	%poss1 = Vector::Add(%pos, EmplacementPack::RotVector("2 0 3.5", %rot));
	%poss2 = Vector::Add(%pos, EmplacementPack::RotVector("-2	0	3.5",	%rot));
	%poss3 = Vector::Add(%pos, EmplacementPack::RotVector("0 -2	3.5",	%rot));
	for(%i = 0;	%i < 4;	%i++)
	{
		%obj = NewObject("TeleFX", "Mine", TeleSparkle);
		GameBase::SetPosition(%obj,	%pos[%i]);
		AddToSet("MissionCleanup", %obj);
		%obj = NewObject("TeleFX", "Mine", TeleSparkle);
		GameBase::SetPosition(%obj,	%poss[%i]);
		AddToSet("MissionCleanup", %obj);
	}
}
