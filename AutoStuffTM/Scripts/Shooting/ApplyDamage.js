#pragma strict

var Damage = 50;
var Ativo = true;

function OnCollisionEnter (info : Collision) {


	if (Ativo == true) {
	
		info.gameObject.SendMessage("ApplyDamage",Damage, SendMessageOptions.DontRequireReceiver) ;
		Ativo = false;
	}
}




