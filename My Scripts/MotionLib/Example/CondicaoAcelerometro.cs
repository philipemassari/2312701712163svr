using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using Assets.Scripts.MyScripts.MotionLib;
using System.Collections.Generic;

public class Analogico : NunchuckListener {

	public Text text;
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Listener(NunchuckData nunchuckData)
	{
		if (nunchuckData.Acelerometro.Y > 300 && nunchuckData.Acelerometro.Y < 500) {
			text.text = "De pe";
		} else {
			text.text = "Deitado";
		}

	}
}
