using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusController : MonoBehaviour
{

	public GameObject mainMenu;
	public GameObject playMenu;

	public PrefsController prefsController;

	// Use this for initialization
	void Start ()
	{
		displayMainMenu ();
		prefsController.clearAll ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void displayMainMenu ()
	{
		mainMenu.SetActive (true);
		playMenu.SetActive (false);
	}

	public void displayPlayMenu ()
	{
		mainMenu.SetActive (false);
		playMenu.SetActive (true);
	}

	public void onPlaySliderValueChanged (GameObject slider)
	{
		switch ((int)slider.GetComponent<Slider> ().value) {
		case 0:
			{
				writeToPrefs (0);
				playMenu.gameObject.transform.FindChild ("CustomDifficultyPannel").gameObject.SetActive (false);
				playMenu.gameObject.transform.FindChild ("DifficultyLabel").GetComponent<Text> ().text = "Difficulty: Easy";
				break;
			}
		
		case 1:
			{
				writeToPrefs (1);
				playMenu.gameObject.transform.FindChild ("CustomDifficultyPannel").gameObject.SetActive (false);
				playMenu.gameObject.transform.FindChild ("DifficultyLabel").GetComponent<Text> ().text = "Difficulty: Normal";
				break;
			}
		case 2:
			{
				writeToPrefs (2);
				playMenu.gameObject.transform.FindChild ("CustomDifficultyPannel").gameObject.SetActive (false);
				playMenu.gameObject.transform.FindChild ("DifficultyLabel").GetComponent<Text> ().text = "Difficulty: Hard";
				break;
			}
		case 3:
			{
				playMenu.gameObject.transform.FindChild ("CustomDifficultyPannel").gameObject.SetActive (true);
				playMenu.gameObject.transform.FindChild ("DifficultyLabel").GetComponent<Text> ().text = "Difficulty: Custom";
				break;
			}
		}
	}

	public void writeToPrefs(int gameMode){
		switch (gameMode) {
		case 0:
			{
				prefsController.writeEasyPrefs ();
				break;
			}
		case 1:
			{
				prefsController.writeNormalPrefs ();
				break;
			}
		case 2:
			{
				prefsController.writeHardPrefs ();
				break;
			}
		}

	}
}
