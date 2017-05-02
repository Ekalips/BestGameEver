using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class FlareLauncher : MonoBehaviour {

	public static int flaresCount = 3;
	public GameObject flarePrefab;

	private float delay = 100;

	private Text flaresLabel;
	// Use this for initialization
	void Start () {
		flaresCount = PlayerPrefs.GetInt (PrefsController.KEY_FLARES_COUNT, 3);
		flaresLabel = GameObject.Find ("FlaresLabel").GetComponent<Text>();
		flaresLabel.text = "Flares: " + flaresCount;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetAxis ("Flares") == 1f && delay == 100 && flaresCount>0) {
			Vector3 _direction = (transform.forward * -1f).normalized;
			Quaternion _lookRotation = Quaternion.LookRotation (_direction);         
			Debug.Log ("Lauch the flare!");


			GameObject flare1 = Instantiate (flarePrefab, transform.position + transform.forward * -1f, _lookRotation);
			flare1.GetComponent<Rigidbody> ().AddForce (transform.forward * -100f);
			GameObject flare2 = Instantiate (flarePrefab, transform.position + transform.forward * -1f, _lookRotation);
			flare2.GetComponent<Rigidbody> ().AddForce (transform.forward * -50f + transform.right*100f);
			GameObject flare3 = Instantiate (flarePrefab, transform.position + transform.forward * -1f, _lookRotation);
			flare3.GetComponent<Rigidbody> ().AddForce (transform.forward * -50f + transform.right*-100f);

			flaresCount--;
			flaresLabel.text = "Flares: " + flaresCount;

			delay -= Time.deltaTime * 100;
		} else if (delay != 100) {
			delay -= Time.deltaTime * 100;
			if (delay < 0)
				delay = 100;
		}
	}
}
