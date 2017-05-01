using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

	GameObject obj;
	public AudioSource audio;

	public ParticleSystem explosion;

	public float speed = 300f;
	public float turnSpeed = 5f;

	public float lifeTime;

	bool isReported = false;

	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource> ();
		obj = GameObject.FindGameObjectWithTag ("TrackObject");

		speed = PlayerPrefs.GetFloat (PrefsController.KEY_SPEED, 300f);
		turnSpeed = PlayerPrefs.GetFloat (PrefsController.KEY_TURN, 5f);
		lifeTime = 1000f;

		ScoreControllerScript.onRocketCreated ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (obj.transform.position -
		//transform.position), 2f * Time.deltaTime);

		//transform.position += transform.forward * 300f * Time.deltaTime;

		Debug.DrawRay (transform.position, transform.forward * 300f);

		float angle = Vector3.Angle (transform.forward, obj.transform.position - transform.position);
		if (Mathf.Abs (angle) > 45) {
		} else {
			Debug.DrawLine (transform.position, obj.transform.position, Color.red);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (obj.transform.position -
				transform.position), turnSpeed * Time.deltaTime);
		}

		//Debug.Log (lifeTime);
		if (lifeTime <= 0) {
			if (!explosion.isPlaying) {
				explosion.Play ();
			}
			Destroy ((GameObject)transform.root.gameObject, 1f);
			reportRocketDestroyed ();
		} else {
			transform.position += transform.forward * speed * Time.deltaTime;
		}

		lifeTime-=Time.deltaTime*100;

	}


	void OnCollisionEnter(Collision col){
		//audio.Play ();
		if (col.transform.tag == "Player") {
			col.transform.GetComponent<RunRestroyScript> ().startExplosion ();
			Destroy ((GameObject)transform.root.gameObject, 0f);
			reportRocketDestroyed ();
		}
	}

	private void reportRocketDestroyed(){
		if (!isReported) {
			ScoreControllerScript.onRockedDestroyed ();
			isReported = true;
		}
	}
}
