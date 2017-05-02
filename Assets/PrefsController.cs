using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsController : MonoBehaviour {

	public const string KEY_SPEED = "SPEED";
	public const string KEY_TURN = "TURN";
	public const string KEY_HARDINA = "HARDINA";
	public const string KEY_COUNT = "COUNT";
	public const string KEY_FLARES_COUNT = "FLARES_COUNT";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void writeEasyPrefs(){
		PlayerPrefs.SetFloat (KEY_SPEED, 250);
		PlayerPrefs.SetFloat (KEY_TURN, 3);
		PlayerPrefs.SetFloat (KEY_HARDINA, 1f);
		PlayerPrefs.SetFloat (KEY_COUNT, 0.1f);
		PlayerPrefs.SetInt (KEY_FLARES_COUNT, 5);
		PlayerPrefs.Save();
	}

	public void writeNormalPrefs(){
		PlayerPrefs.SetFloat (KEY_SPEED, 300);
		PlayerPrefs.SetFloat (KEY_TURN, 5);
		PlayerPrefs.SetFloat (KEY_HARDINA, 1.2f);
		PlayerPrefs.SetFloat (KEY_COUNT, 0.2f);
		PlayerPrefs.SetInt (KEY_FLARES_COUNT, 3);
		PlayerPrefs.Save();
	}

	public void writeHardPrefs(){
		PlayerPrefs.SetFloat (KEY_SPEED, 350);
		PlayerPrefs.SetFloat (KEY_TURN, 10);
		PlayerPrefs.SetFloat (KEY_HARDINA, 1.5f);
		PlayerPrefs.SetFloat (KEY_COUNT, 0.4f);
		PlayerPrefs.SetInt (KEY_FLARES_COUNT, 1);
		PlayerPrefs.Save();
	}

	public void clearAll(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save();
	}
}
