using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneGUIUpdater : MonoBehaviour {

	ScrollRect horizontScroll;
	ScrollRect horizontScroll2;
	RectTransform verticalPannel;

	GameObject inGamePannel;
	GameObject gameOverPannel;

	Text scoreText;

	// Use this for initialization
	void Start () {
		horizontScroll = GameObject.Find ("PlaneHorizontScroll").GetComponent<ScrollRect>();
		horizontScroll2 = GameObject.Find ("PlaneHorizontScroll2").GetComponent<ScrollRect>();
		verticalPannel = GameObject.Find ("VerticalPannel").GetComponent<RectTransform> ();
		inGamePannel = GameObject.Find ("InGamePannel");
		gameOverPannel = GameObject.Find ("GameOverPannel");
		gameOverPannel.SetActive (false);

		scoreText = gameOverPannel.transform.FindChild ("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hangle = (transform.rotation.x  + 1)/2 ;
		float vangle;
		if (transform.localRotation.y > 0) {
			 vangle = transform.localRotation.z * 180;
		}
		else {
			 vangle = -transform.localRotation.z * 180;
		}
		horizontScroll.verticalNormalizedPosition = 1-hangle;
		horizontScroll2.verticalNormalizedPosition = 1-hangle;
		verticalPannel.localRotation = Quaternion.Euler (0.0f, 0.0f, vangle);
	}

	void OnDestroy(){
		scoreText.text = "Your score: " + ScoreControllerScript.score;
		inGamePannel.SetActive (false);
		gameOverPannel.SetActive (true);
	}
}
