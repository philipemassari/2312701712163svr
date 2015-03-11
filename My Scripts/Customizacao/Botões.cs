using UnityEngine;
using System.Collections;

public class Botões : MonoBehaviour {



	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MudarCabeloA(){
		
		Cabelo.A = true;
	}


	public void MudarCabeloB (){
	
		Cabelo.B = true;
	}

	public void MudarRostoA(){

		Rosto.A = true;

	}

	public void MudarRostoB (){
		Rosto.B = true;
	
	}



}
