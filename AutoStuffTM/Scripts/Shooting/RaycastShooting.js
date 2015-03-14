#pragma strict

var Effect : Transform; //o efeito que surgira quando o raio chegar
var Damage = 50;		//O dano do tiro

function Update () {

	var hit : RaycastHit; //variavel das informaçoes do acerto do raycast
	var ray : Ray = Camera.main.ScreenPointToRay(Vector3(Screen.width*0.5, Screen.height*0.5)); //variavel sobre o raycast
	
	if (Input.GetMouseButtonDown(0)) { //se clicarmos o botao fire
		
		if (Physics.Raycast (ray, hit, 100)) { //se o raio acertar
			
			var particle = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal)); //criar o efeito
			Destroy(particle.gameObject, 2);													//destroir o efeito 2 segundos depois
			hit.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver); //mandar mensagem de dano pro alvo
		}
	}
}