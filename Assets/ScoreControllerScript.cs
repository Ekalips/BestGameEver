using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControllerScript : MonoBehaviour {

	static int currentRockets;
	float scoreMultiplier;
	static float score;
	// Use this for initialization
	void Start () {
		scoreMultiplier = PlayerPrefs.GetFloat (PrefsController.KEY_HARDINA, 1);
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime * 10 * scoreMultiplier;
	}

	public static void onRocketCreated(){
		currentRockets++;
	}

	public static void onRockedDestroyed(){
		if (currentRockets>0)
			currentRockets--;

		Debug.Log (score);
	}
}
