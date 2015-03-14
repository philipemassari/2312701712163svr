#pragma strict




var BaseHealth = 100;
var Health : int;

function Start () {

Health = BaseHealth;


}

function ApplyDamage(Damage : int) { //quando essa funçao for chamada, subtraia a vida de acordo com o dano
 
 
 if (Health <= 0){					//se a vida chegar ou passar de zero, ativar funçao "morte"
  Dead();
  }
  
 
 
 Health -= Damage;

}

function Dead() { //quando essa funçao for chamada, destrua o gameobject

	 Respawn.PlayerIsDead = true;
	 print("Player died");

}		

function Ressurrect() {

	Health = BaseHealth;
	Respawn.PlayerIsDead = false;

}