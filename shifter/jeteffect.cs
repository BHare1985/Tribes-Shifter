//this is a special effect which makes u smoke when u jet...made by star, edited, implimented by killa
ExplosionData JetEffectExp
{
   shapeName = "smoke.dts";

   faceCamera = TRUE;
   randomSpin = TRUE;
   hasLight   = TRUE;
   lightRange = 3.0;
	 timeScale = 3.0;
   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };

   shiftPosition = TRUE;
};
MineData JetEffect
{
	className = "Mine";
 	description = "Jetting Effect";
 	shapeFile = "breath";
 	shadowDetailMask = 4;
 	explosionId = JetEffectExp;
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
function JetEffect::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function Player::JetEffect(%player)
{
	if(!Player::IsDead(%player))
	{

        
		if(Player::IsJetting(%player))
		{
			%bomb = NewObject("JetEffect", "Mine", "JetEffect");
			AddToSet($JetMainSet, %bomb);
			GameBase::Throw(%bomb, %player, 5, true);
			schedule("Player::JetEffect(" @ %player @ ");", 0.085);
		}
		else
			schedule("Player::JetEffect(" @ %player @ ");", 0.15);
	}
}

