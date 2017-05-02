using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneGUIUpdater : MonoBehaviour {

	ScrollRect horizontScroll;
	RectTransform verticalPannel;
	// Use this for initialization
	void Start () {
		horizontScroll = GameObject.Find ("PlaneHorizontScroll").GetComponent<ScrollRect>();
		verticalPannel = GameObject.Find ("VerticalPannel").GetComponent<RectTransform> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hangle = (transform.rotation.x  + 1)/2 ;
		float vangle;
		if (transform.localRotation.y > 0) {
			 vangle = transform.localRotation.z * 180;
		}
		else {
			 vangle = -transform.localRotation.z * 180;
		}
		horizontScroll.verticalNormalizedPosition = hangle;
		verticalPannel.localRotation = Quaternion.Euler (0.0f, 0.0f, vangle);

	}
}
