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
	bool isFlared = false;
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

		if (!isFlared) {
			GameObject[] flares = GameObject.FindGameObjectsWithTag ("Flares");
			if (flares != null && flares.Length > 0) {
				float minDistance = float.MaxValue;
				int minIndex = -1;
				for (int i = 0; i < flares.Length; i++) {
					float d = Vector3.Distance (transform.position, flares [i].transform.position);
					if (d < minDistance) {
						minDistance = d;
						minIndex = i;
					}
				}


				float distanceToPlayer = Vector3.Distance (transform.position, obj.transform.position);
				if (distanceToPlayer > minDistance && minIndex != -1) {
					obj = flares [minIndex];
					isFlared = true;
					Debug.Log ("I'M FLARED!!");
				}
			}
		} 

		if (obj == null || obj.transform == null) {
			destroyself ();
			return;
		}

		if (isFlared && Vector3.Distance (obj.transform.position, transform.position) < 100f) {
			destroyself ();
		}



		float angle = Vector3.Angle (transform.forward, obj.transform.position - transform.position);
		if (Mathf.Abs (angle) > 45) {
		} else {
			Debug.DrawLine (transform.position, obj.transform.position, Color.red);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (obj.transform.position -
				transform.position), turnSpeed * Time.deltaTime);
		}

		//Debug.Log (lifeTime);
		if (lifeTime <= 0) {
			destroyself ();
		} else {
			transform.position += transform.forward * speed * Time.deltaTime;
		}

		lifeTime-=Time.deltaTime*100;

	}


	void OnCollisionEnter(Collision col){
		Debug.Log ("COLLISION: " + col.transform.tag);
		//audio.Play ();
		if (col.transform.tag == "Player") {
			col.transform.GetComponent<RunRestroyScript> ().startExplosion ();
			Destroy ((GameObject)transform.root.gameObject, 0f);
			reportRocketDestroyed ();
		} else if (col.transform.tag == "Flares") {
			destroyself ();
		}

	}

	private void reportRocketDestroyed(){
		if (!isReported) {
			ScoreControllerScript.onRockedDestroyed ();
			isReported = true;
		}
	}

	void destroyself ()
	{
		if (!explosion.isPlaying) {
			explosion.Play ();
		}
		Destroy ((GameObject)transform.root.gameObject, 1f);
		reportRocketDestroyed ();
	}
}
