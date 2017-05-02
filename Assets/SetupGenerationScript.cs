using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGenerationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float difficulty = PlayerPrefs.GetFloat (PrefsController.KEY_COUNT,0.2f);
		TrackObstacle generator = transform.root.GetComponent<TrackObstacle> ();
		generator.mainprobab = difficulty;
		generator.enabled = true;
		generator.Recycle();
		generator.seedobstacle();
	}
}
