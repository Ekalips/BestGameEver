using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float currentRotateX = 0f;
	public float currentRotateY = 0f;
	float distance = 20.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Read the user input
		float x = Input.GetAxis("Mouse X") * 1.5f;
		float y = Input.GetAxis("Mouse Y") * 1.5f;

		currentRotateX += x;
		if (currentRotateX >= 360) {
			currentRotateX -= 360;
		} else if (currentRotateX < 0) {
			currentRotateX += 360;
		}
		currentRotateY += y;
		if (currentRotateY >= 360) {
			currentRotateY -= 360;
		} else if (currentRotateY < 0) {
			currentRotateY += 360;
		}



		Quaternion rotation = Quaternion.Euler (-currentRotateY, currentRotateX, 0);
		Vector3 position = rotation * new Vector3 (0.0f, 0.0f, -distance) + transform.position;

		//Vector3 moveCameraTo = transform.position - (transform.forward * 10.0f) + (Vector3.up * 7.0f);
		//float bias = 0.95f;
		float bias = 0f;
		Camera.main.transform.position = Camera.main.transform.position * bias + position * (1.0f - bias);

		Camera.main.transform.LookAt (transform.position);

		
	}
}
