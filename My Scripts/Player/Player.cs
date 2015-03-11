using UnityEngine;
using System.Collections;
public enum TypeCharacter{
	Demonio,
	BestaAlada,
}
public class Player : CharacterBase {
	public TypeCharacter type;
	// Use this for initialization
protected void Start () {
		base.Start ();
		Level = PlayerStatsController.GetCurrentLevel ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
