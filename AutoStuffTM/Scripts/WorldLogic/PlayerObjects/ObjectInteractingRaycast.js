#pragma strict

var GUItext : GameObject;

function Update () {
	
	
	var Hit : RaycastHit;
	var ray : Ray = Camera.main.ScreenPointToRay(Vector3(Screen.width*0.5, Screen.height*0.5));
	
	if(Physics.Raycast (ray, Hit, 10) && Hit.transform.gameObject.tag == "InteractiveObject") {
											
		GUItext.SetActiveRecursively(true);																
	
		if (Input.GetKeyDown(KeyCode.E)) { //se clicarmos o botao fire
			
			
			Hit.transform.gameObject.SendMessage("Interact"); //mandar mensagem de dano pro alvo
		}
		
	}
	else{

		GUItext.SetActiveRecursively(false);

	}
	
	

	
}
