#pragma strict

var WalkSpeed : float = 6;
var SprintSpeed : float = 10;

private var CharMotor : CharacterMotor;
private var CharController : CharacterController;

function Start () {

	CharMotor = GetComponent(CharacterMotor);
	CharController = GetComponent(CharacterController);

}

function Update () {
	
	//Variavel da velocidade
	var Speed = WalkSpeed;

	//Checa se o player esta no chao e o shift esta clicado
	if (CharController.isGrounded && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
		
		//Mudando a velocidade do player
		Speed = SprintSpeed;
	
	}
	//COnfigura a velocidade
	CharMotor.movement.maxForwardSpeed = Speed;
}