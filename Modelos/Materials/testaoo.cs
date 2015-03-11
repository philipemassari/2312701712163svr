using UnityEngine;
using System.Collections;

public class testaoo : MonoBehaviour {
	public Texture[] myMaterials = new Texture[5];
	int maxMaterials;
	int arrayPos = 0;
	public static bool A = false;
	public static bool B = false;

	// Use this for initialization
	void Start () {
		maxMaterials = myMaterials.Length-1;
	}


	void updateMaterials()
	{
		//Avança a textura
		if (A == true) {
			if (arrayPos == maxMaterials)
				arrayPos = 0;
			else
				arrayPos++;			
			GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = myMaterials [arrayPos];
			A = false;
		}
		
				
		//Volta a textura anterior
		if (B == true) {            
			if (arrayPos == 0)
				arrayPos = maxMaterials;
			else
				arrayPos--;			
			GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = myMaterials [arrayPos];
			B = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateMaterials ();
	}
}
