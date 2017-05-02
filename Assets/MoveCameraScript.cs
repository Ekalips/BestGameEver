using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour {

	public GameObject camera;

	public GameObject position1;
	public GameObject viewAt1;

	public GameObject position2;
	public GameObject viewAt2;

	public GameObject position3;
	public GameObject viewAt3;

	public List<GameObject> positionObjects;
	public List<GameObject> lookObjects;

	int currentPos = -1;
	bool isMovementFinished;
	int newPos = -1;

	float speed = 5;
	// Use this for initialization
	void Start () {
		if (camera == null) {
			camera = GameObject.FindGameObjectWithTag ("MainCamera");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (newPos != currentPos && !isMovementFinished) {
			Vector3 newPosV = positionObjects[newPos].transform.position;
			Vector3 newCameraLook = lookObjects[newPos].transform.position;
			if (camera.transform.position != newPosV) {
				camera.transform.position = Vector3.Lerp (camera.transform.position, newPosV, speed * Time.deltaTime);
				camera.transform.rotation = Quaternion.Slerp (camera.transform.rotation, Quaternion.LookRotation (newCameraLook -
					camera.transform.position), speed * Time.deltaTime);

				if (newCameraLook -
					camera.transform.position == Vector3.zero) {
					isMovementFinished = true;
					this.currentPos = newPos;
					Debug.Log ("finished");
				}
			
			} else {
				Debug.Log ("finished");
				isMovementFinished = true;
				this.currentPos = newPos;
			}


		}
	}

	public void changePosition(int newPos){
		Debug.Log ("changePosition: " + newPos);
		this.currentPos = -1;
		this.newPos = newPos;
		this.isMovementFinished = false;
	}
}
