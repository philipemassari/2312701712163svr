using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.MyScripts.MotionLib;

public class Analog : NunchuckListener {
		
	public Text analogLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Listener(NunchuckData data){
		analogLabel.text = "X: " + data.Analog.X + "\nY: " + data.Analog.Y;
	}
}
