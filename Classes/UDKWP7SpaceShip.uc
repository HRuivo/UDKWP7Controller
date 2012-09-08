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

simulated function SetInputs(float InForward, float InStrafe, float InUp)
{
	super.SetInputs(GetX(), GetY(), InUp);
}

DefaultProperties
{
}
