using UnityEngine;
using System.Collections;
using Assets.Scripts.MyScripts.MotionLib;

public class Movimentacao : NunchuckListener {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Listener(NunchuckData data)
	{
		gameObject.transform.Translate (data.Analog.X * Time.deltaTime, 
		                                0, 
		                                data.Analog.Y * Time.deltaTime); 
	}

}
