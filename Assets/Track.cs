using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

	GameObject obj;
	public AudioSource audio;
	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource> ();
		obj = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (obj.transform.position -
		//transform.position), 2f * Time.deltaTime);

		//transform.position += transform.forward * 300f * Time.deltaTime;

		Debug.DrawRay (transform.position, transform.forward * 300f);

		float angle = Vector3.Angle (transform.forward, obj.transform.position - transform.position);
		if (Mathf.Abs (angle) > 45) {
			//print ("nope");
		} else {
			Debug.DrawLine (transform.position, obj.transform.position, Color.red);
			//print ("yay");

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (obj.transform.position -
			transform.position), 5f * Time.deltaTime);
		}

		transform.position += transform.forward * 150f * Time.deltaTime;
	}


	void OnCollisionEnter(Collision col){
		print ("yay");
		audio.Play ();
		Destroy ((GameObject)transform.root.gameObject,1f);
	}
}
