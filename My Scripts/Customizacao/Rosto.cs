using UnityEngine;
using System.Collections;

public class Rosto : MonoBehaviour {
	// arraypos = numero do objeto que foi definido
	public Texture[] myMaterials = new Texture[2];
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
			
			GetComponent<SkinnedMeshRenderer>().materials[2].mainTexture = myMaterials [arrayPos];
			A = false;
		}						
		//Volta a textura anterior
		if (B == true) {            
			if (arrayPos == 0)
				arrayPos = maxMaterials;
			else
				arrayPos--;
			
			GetComponent<SkinnedMeshRenderer>().materials[2].mainTexture = myMaterials [arrayPos];
			B = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateMaterials ();
	}
}
