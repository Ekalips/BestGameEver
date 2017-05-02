using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonsController : MonoBehaviour {

	public void onResetButtonClick(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<RunRestroyScript> ().Reset ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void onGoToMenuButtonClick(){
		SceneManager.LoadScene (0);
	}
}
