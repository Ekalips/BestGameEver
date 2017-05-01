using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonClick : MonoBehaviour {

	public MenusController menusController;

	public void onButtonClick(int position){  //Main menu buttons
		switch (position) {
		case 0:
			{
				menusController.displayPlayMenu ();
				break;
			}
		case 1:
			{
				break;
			}
		case 2:
			{
				break;
			}
		case 3:
			{
				Application.Quit ();
				break;
			}
		default:
			{
				menusController.displayMainMenu ();
				break;
			}

		}
	}


	public void onStartGameButtonClick(){
		Debug.Log (PlayerPrefs.GetFloat ("SPEED"));
		SceneManager.LoadScene (1);
	}

}
