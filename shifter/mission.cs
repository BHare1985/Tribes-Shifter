//--------------------------------------------------------------------------

//--------------------------------------------------------------------------


//--------------------------------------------------------------------------

StaticShapeData Example
{
   shapeFile = "radar";
   shadowDetailLevel = 0;
//   explosionId = 0;
   ambientSoundId = IDSFX_GENERATOR;
   maxDamage = 2.0;
};

function Example::onAdd(%this)
{
   if($debug) echo("Example added: ", %this);
}

function Example::onRemove(%this)
{
   if($debug) echo("Example removed: ", %this);
}

function Example::onEnabled(%this)
{
   if($debug) echo("Example enabled");
}

function Example::onDisabled(%this)
{
   if($debug) echo("Example disabled");
}

function Example::onDestroyed(%this)
{
   if($debug) echo("Example destroyed");
}

function Example::onPower(%this, %newState, %generator)
{
   if($debug) echo("Example power state: ", %newState);
}

function Example::onCollision(%this, %object)
{
   if($debug) echo("Example collision with ", %object);
}

function Example::onAttack(%this, %object)
{
   if($debug) echo("Example attacked ", %object);
}

