using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AnimationControl : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float roll = CrossPlatformInputManager.GetAxis("Roll");
		float pitch = CrossPlatformInputManager.GetAxis("Pitch");
		float yaw = CrossPlatformInputManager.GetAxis("Yaw");
		animator.SetFloat ("turn",roll);
		animator.SetFloat ("pitch", pitch);
		animator.SetFloat ("yaw", -yaw);
	}
}
