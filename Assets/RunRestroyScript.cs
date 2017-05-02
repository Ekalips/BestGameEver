using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;

public class RunRestroyScript : MonoBehaviour {

	public ParticleSystem oneTimesystem;
	public ParticleSystem permamentSystem1;
	public AudioSource explosionSoundSrc;

	static bool isRun;

	float lifetime = 4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isRun) {
			if (!oneTimesystem.isPlaying) {
				oneTimesystem.Play ();
				explosionSoundSrc.Play ();
			} else {
				lifetime -= Time.deltaTime;
			}
			if (!permamentSystem1.isPlaying) {
				permamentSystem1.Play ();
			}

			if (lifetime <= 0) {
				isRun = false;
				oneTimesystem.Stop ();
				lifetime = 4f;
			}
		}

		
	}

	public void startExplosion(){
		isRun =true;
		GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController> ().Immobilize ();
		Destroy (GetComponent<PlaneGUIUpdater> ());
	}

	void OnCollisionEnter(Collision col){
		//audio.Play ();
		if (col.transform.tag == "Terrain") {
			permamentSystem1.Play ();
			isRun = true;
			lifetime = 4f;
			GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController> ().Immobilize ();
			Destroy (GetComponent<PlaneGUIUpdater> ());
		}
	}

	public void Reset(){
		GetComponent<UnityStandardAssets.Vehicles.Aeroplane.AeroplaneController> ().Reset ();
		isRun = false;
		lifetime = 4f;
		permamentSystem1.Stop ();
		explosionSoundSrc.Stop ();
		oneTimesystem.Stop ();
	}
}
