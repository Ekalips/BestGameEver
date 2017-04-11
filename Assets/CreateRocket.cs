using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRocket : MonoBehaviour {

	public float delay = 0f;
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && delay == 0) {
			Instantiate (prefab);
			delay = 500f;
		}
		if (delay != 0)
			delay -= 0.5f;
		if (delay < 0)
			delay = 0;
	}
}
