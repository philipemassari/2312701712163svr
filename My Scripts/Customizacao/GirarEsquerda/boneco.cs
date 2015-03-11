using UnityEngine;
using System.Collections;

public class boneco : MonoBehaviour {
	public static bool buttonL = false;
	public static bool buttonR = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(buttonL == true){
			transform.Rotate(0, -60 * Time.deltaTime , 0);
		}

		if(buttonR == true){
			transform.Rotate(0, 60 * Time.deltaTime , 0);
		}

	}
}
