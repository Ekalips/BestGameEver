using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRelativeToPlane : MonoBehaviour {

	GameObject playerPlane;
	// Use this for initialization
	void Start () {
		playerPlane = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = playerPlane.transform.position + Vector3.up * 150;
	}
}
