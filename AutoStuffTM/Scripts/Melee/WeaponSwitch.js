#pragma strict

var primaryWep : GameObject;
var secondaryWep : GameObject;
var Weapon : Transform;

function Update () {
 	if (Input.GetKeyDown (KeyCode.Q)) {
		Weapon.GetComponent.<Animation>().Play("Switch");
		
 	}
 
}
	
public function SwapWeapons() {

	if (primaryWep.active == true) {
 		primaryWep.SetActiveRecursively(false);
  		secondaryWep.SetActiveRecursively(true);
 		Weapon = secondaryWep.transform;
	}else {
		primaryWep.SetActiveRecursively(true);
		secondaryWep.SetActiveRecursively(false);
		Weapon = primaryWep.transform;
	}

}