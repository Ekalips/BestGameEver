using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlaneScript : MonoBehaviour {

	public bool destroy = false;
	public bool isDestroyng = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (destroy && !isDestroyng) {
			foreach(Transform child in transform){
				child.gameObject.AddComponent<BoxCollider> ();
				child.gameObject.AddComponent<Rigidbody> ();
			}
			transform.DetachChildren ();
			GameObject.Destroy ((GameObject)transform.root.gameObject);
			isDestroyng = true;
		}
	}
}
