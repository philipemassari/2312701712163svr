using UnityEngine;
using System.Collections;

public class PlayerStatsController : MonoBehaviour {
	public static PlayerStatsController intance;
	public int xpMultiply = 1;
	public float xpFirstLevel = 100;
	public float difficultFactor = 1.5f;

	// Use this for initialization
	void Start () {
		intance = this;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			AddXp (100);
		} 
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerPrefs.DeleteAll();
		} 


	}
	// metodo para add xp ex "receber valor do xp q o monstro te da ao morrer"
	public static void AddXp(float xpAdd){
		float newXP = (GetCurrentXp() + xpAdd )*PlayerStatsController.intance.xpMultiply;
		while(newXP >= GetNextXp()){
			newXP -= GetNextXp();
			AddLevel();

		}

		PlayerPrefs.SetFloat ("currentXp", newXP);
		}




// xp atual do personagem
	public static float GetCurrentXp(){

		return PlayerPrefs.GetFloat("currentXp");
	}
	// level atual do personagem
	public static int GetCurrentLevel(){

		return PlayerPrefs.GetInt ("currentLevel");

	}
	// adiciona o novo level
	public static void AddLevel(){
		int newLevel = GetCurrentLevel () + 1;
		PlayerPrefs.SetInt ("currentLevel", newLevel);
	}

public static float GetNextXp(){
	return PlayerStatsController.intance.xpFirstLevel * (GetCurrentLevel() + 1) * PlayerStatsController.intance.difficultFactor;
}


void OnGUI(){
	GUI.Label(new Rect(0,0,100,50), "Current Xp" + " " + GetCurrentXp());
    GUI.Label(new Rect(0,70,100,50), "Current Level" + " " + GetCurrentLevel());
    GUI.Label(new Rect(0,140,100,50), "Next xp" + " " + GetNextXp());
}


}
