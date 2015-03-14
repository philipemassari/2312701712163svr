#pragma strict

var Damage : int = 50;            			//Quanto de dano o ataque causara
var Distance : float = 1.0;       			//A distancia do player ate o alvo
var Maxdistance : float = 1.5;   		 	//O alcance maximo do ataque
var Sword : Transform;            			//O GameObject que sera a arma 
var audioSource : AudioSource;				// Fonte do audio
var clip : AudioClip;						// Audio que sera displeyado do som da espada
var clipBody : AudioClip;					// Audio que sera displeyado do corpo levando
var breath : AudioClip;
var Melee : Transform;

@HideInInspector
var ArmasPrincipais : GameObject;	

function Start(){
	ArmasPrincipais = gameObject.transform.parent.gameObject;
}


function Update ()                 			//A cada frame, sera registrado:
{

	if (Input.GetButtonDown ("Fire1"))		//se o botao "fire 1" esta sendo clicado faça oque esta entre chaves
	{
 		
 		Sword.GetComponent.<Animation>().Play("Attack");		//Animaçao do ataque da espada
 		
 		
 	}
 	
 	if (Sword.GetComponent.<Animation>().isPlaying == false) {
 	
 	
     	Sword.GetComponent.<Animation>().CrossFade("idle");

	 	if (Input.GetKey (KeyCode.LeftShift)) 
	 	{
	        Sword.GetComponent.<Animation>().Play("Sprint");
	    }
 		if (Input.GetKeyUp (KeyCode.LeftShift)) 
 		{
        	Sword.GetComponent.<Animation>().CrossFade("idle");
      	}
   	}
}

public function DealDamage () {

		var hit : RaycastHit;          		//Detecta se o ataque acertou
 		
 		if (Physics.Raycast(Melee.transform.position,Melee.transform.TransformDirection(Vector3.forward),hit)) //se o ataque acertar
  		{
  
  			Distance=hit.distance;       	// calcula a distancia
  			if (Distance < Maxdistance)		// se distancia for menor que o alcance maximo
  			{ 
  				hit.transform.SendMessage("ApplyDamage", Damage,SendMessageOptions.DontRequireReceiver); //ativa a funçao "Aplicar dano"
   				audioSource.PlayOneShot(clipBody);
		       
		   	}
		   else { 
		   audioSource.PlayOneShot(clip);
  		}
    }
    else {
    audioSource.PlayOneShot(clip);
    }
}

public function Breath () {


	audioSource.PlayOneShot(breath);


}

public function callWeaponSwitch(){
	ArmasPrincipais.GetComponent(WeaponSwitch).SwapWeapons();
}






