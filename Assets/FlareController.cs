using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareController : MonoBehaviour {

	float lifetime = 500f;

	void Update () {
		lifetime -= (Time.deltaTime * 100f);
		if (lifetime < 0) {
			Destroy ((GameObject)transform.root.gameObject, 0f);
		}
	}

	void OnCollisionEnter(Collision col){
		Debug.Log ("flares collided" + col.transform.tag);
		//audio.Play ();
		if (col.transform.tag != "Player" && col.transform.tag != "Flares") {
			Destroy ((GameObject)transform.root.gameObject, 0f);
		}
	}
}
