#pragma strict

var MouseLook1 : MouseLook;
var MouseLook2 : MouseLook;
var CharMotor : CharacterMotor;
var SprintScript : Sprint;
var SpawnMenu : GameObject;
var Weapons : GameObject;
//var Maincamera : Camera;
var RespawnPos : Transform;
//var DeathScreen : GameObject;

static var PlayerIsDead = false;

function Start () {

	//Maincamera = GameObject.Find("MainCamera").GetComponent (Camera);
	MouseLook1 = gameObject.GetComponent (MouseLook);
	MouseLook2 = GameObject.Find("MainCamera").GetComponent (MouseLook);
	CharMotor = gameObject.GetComponent (CharacterMotor);
	SprintScript = gameObject.GetComponent (Sprint);

}		

function Update () {
	
	if (PlayerIsDead == true) {
		
		//DeathScreen.SetActiveRecursively(true);
		//Maincamera.enabled = false;
		MouseLook1.enabled = false;
		MouseLook2.enabled = false;
		CharMotor.enabled = false;
		SprintScript.enabled = false;
		SpawnMenu.SetActiveRecursively(true);
		Weapons.SetActiveRecursively(false);
	
	}

}

function RespawnPlayer () {
	
	//Maincamera.enabled = false;
	//DeathScreen.SetActiveRecursively(false);
	transform.position = RespawnPos.position;
	transform.rotation = RespawnPos.rotation;
	gameObject.SendMessage("Ressurrect");
	print("Mene");
	MouseLook1.enabled = true;
	MouseLook2.enabled = true;
	CharMotor.enabled = true;
	SprintScript.enabled = true;
	SpawnMenu.SetActiveRecursively(false);
	Weapons.SetActiveRecursively(true);
	print("Player has respawned");
}

@script RequireComponent(CharacterController)