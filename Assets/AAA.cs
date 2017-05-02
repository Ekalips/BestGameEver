using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;

public class AAA : MonoBehaviour {

	public float delay = 0f;
	GameObject player;
	public GameObject rocketPrefab;

	private Transform lineAt;

	public float launchDelay = 75;


	public float detectDistanse = 1500;
    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		lineAt = player.transform.FindChild("TrackPoint");

		detectDistanse = detectDistanse * PlayerPrefs.GetFloat (PrefsController.KEY_HARDINA,1f);
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance (transform.position, lineAt.position) ;
		if (distance <= detectDistanse && delay==0 && !player.GetComponent<AeroplaneController>().IsImmobilized()) {
			DrawLine (transform.position, lineAt.position, Color.red);
		}


		transform.LookAt (player.transform.position);
		if (distance <= detectDistanse && delay == 0 && !player.GetComponent<AeroplaneController>().IsImmobilized()) {

			launchDelay -= (Time.deltaTime * 100);
			if (launchDelay <= 0) {
				Vector3 _direction = (player.transform.position - transform.position).normalized;
				Quaternion _lookRotation = Quaternion.LookRotation (_direction);         

				Instantiate (rocketPrefab, transform.position + transform.forward * 5f, _lookRotation);
				delay = 400f;
				launchDelay = 75;
			}
		} else {
			launchDelay = 75;
		}
		if (delay != 0)
			delay -= 0.5f;
		if (delay < 0)
			delay = 0;
	}



	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.02f){
		GameObject line = new GameObject ();
		line.transform.position = start;
		line.AddComponent<LineRenderer> ();
		LineRenderer lr = line.GetComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.SetColors (color, color);
		lr.SetWidth (0.1f, 0.1f);
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
		GameObject.Destroy (line, duration);
	}
}
