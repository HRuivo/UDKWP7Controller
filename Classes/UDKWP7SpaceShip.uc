class UDKWP7SpaceShip extends UTVehicle_Cicada_Content
	DLLBind(WP7SensorReader)
	placeable;

dllimport final function Initialize();
dllimport final function Terminate();
dllimport final function float GetX();
dllimport final function float GetY();
dllimport final function float GetZ();


simulated function PostBeginPlay()
{
	super.PostBeginPlay();

	
	Initialize();
}

/**
 * Console specific input modification
 */
simulated function SetInputs(float InForward, float InStrafe, float InUp)
{
	local Rotator viewRot;

	super.SetInputs(GetX(), 0, InUp);

	viewRot = GetViewRotation();
	viewRot.Yaw += GetY() * 512;

	SetViewRotation(viewRot);
}

DefaultProperties
{
	bUsingLookSteer=false
}
