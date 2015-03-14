
var Distance;
var Target : Transform;
var LookatDistance = 25.0;
var ChaseDistance = 15.0;
var AttackDistance = 2;
var MoveSpeed = 5.0;
var Damping = 6.0;
var AttackRepeat = 1;
var Damage = 30;


var controller : CharacterController;
var gravity : float = 60;
private var moveDirection : Vector3 = Vector3.zero;

private var AttackTime : float;

function Start () {

	AttackTime = Time.time;


}

function Update () {

	Distance = Vector3.Distance(Target.position, transform.position);
	
	if (Distance > LookatDistance) {
		GetComponent.<Renderer>().material.color = Color.green;
	}
	if (Distance < LookatDistance) {
		GetComponent.<Renderer>().material.color = Color.yellow;
		LookAt ();
	
	}
	if (Distance < AttackDistance) {
		Attack ();
	}
	else if (Distance < ChaseDistance) {
		Chase ();
		GetComponent.<Renderer>().material.color = Color.red;
	}


}
 function LookAt () {
 	var rotation = Quaternion.LookRotation(Target.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
 
 }
 
 function Chase () {
    moveDirection = transform.forward;
    moveDirection *= MoveSpeed;
    
    moveDirection.y -= gravity*Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);
 }
 
 function Attack () {
	if (Time.time > AttackTime) {
 		Target.SendMessage("ApplyDamage",Damage, SendMessageOptions.DontRequireReceiver);
 		print("attack");
 		AttackTime = Time.time + AttackRepeat;
 	}
 }
 function ApplyDamage () {
 
 	ChaseDistance += 20;
 	
 
 
 }