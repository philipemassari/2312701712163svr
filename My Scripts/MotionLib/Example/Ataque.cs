using UnityEngine;
using System.Collections;
using Assets.Scripts.MyScripts.MotionLib;
using UnityEngine.UI;

public class Ataque : NunchuckListener {

	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Listener (NunchuckData nunchuckData)
	{
		if (nunchuckData.Button.Z) {
			text.text  = "Ataque";
		} else {
			text.text  = "Idle";
		}
	}
}
