#pragma strict

//private var DrawGui = false;
private var DoorisOpen = false;
var GuiText : GameObject;
var Clip1 : AudioClip;
var Clip2 : AudioClip;
var Source : AudioSource;

function Interact () {
	
	
	
	if (DoorisOpen == false) {
	
		GetComponent.<Animation>().CrossFade("Open");
		Source.PlayOneShot(Clip1);
		DoorisOpen = true;
		
	}
	else {
		
		GetComponent.<Animation>().CrossFade("Close");
		Source.PlayOneShot(Clip2);
		DoorisOpen = false;
		
	}
}

