#pragma strict

//Script para inimigos venciveis

var Health = 100; //Vida do alvo
var SourceDamage : AudioSource;
var Hit1 : AudioClip;
var Hit2 : AudioClip;




function ApplyDamage(Damage : int) { //quando essa funçao for chamada, subtraia a vida de acordo com o dano
 
 
 if (Health <= 0){					//se a vida chegar ou passar de zero, ativar funçao "morte"
  Dead();
  }
  
 if(Damage < 100) {
 SourceDamage.PlayOneShot(Hit1);
 
 }
 else {
 SourceDamage.PlayOneShot(Hit2);
 
 
 
 }
 
 Health -= Damage;

}

function Dead() { //quando essa funçao for chamada, destrua o gameobject

 Destroy (gameObject);

}