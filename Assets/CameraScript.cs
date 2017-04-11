using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float currentRotateX = 0f;
	public float currentRotateY = 0f;
    Vector3 lastposition;
	float distance = 50.0f;

    public const float cameraview = 15f;
    public const float minZoomDistance = 10f;
    public const float maxZoomDistance = 50f;
    public const float distanceZoomChange = 2f;

    // Use this for initialization
    void Start () {

        lastposition = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // Read the user input
        float camera_sensitiv = 3f;

        Zoom();

		float x = Input.GetAxis("Mouse X") * camera_sensitiv;
		float y = Input.GetAxis("Mouse Y") * camera_sensitiv;

       

        currentRotateX += x;
        if (currentRotateX >= 360)
        {
            currentRotateX -= 360;
        }
        else if (currentRotateX < 0)
        {
            currentRotateX += 360;
        }
        currentRotateY += y;

        if (currentRotateY > 89 && currentRotateY < 180)        //обзор самолета только сзади (на 180 градусов)
            currentRotateY = 89;                                //дабы избежать скачков
        if (currentRotateY > 180 && currentRotateY < 271)
            currentRotateY = 271;

        if (currentRotateY >= 360)
        {
            currentRotateY -= 360;
        }
        if (currentRotateY < 0)
        {
            currentRotateY += 360;
        }


        Quaternion rotation = Quaternion.Euler (-currentRotateY, currentRotateX, 0);
		Vector3 position = rotation * new Vector3 (0.0f, 0.0f, -distance) + transform.position;
        
		Vector3 moveCameraTo = transform.position - (transform.forward * 10.0f) + (Vector3.up * 7.0f);
		float bias = 0.6f; //0.95 изначально
		//float bias = 0f;
		Camera.main.transform.position = Camera.main.transform.position * bias + position * (1.0f - bias);

        Vector3 positionLookAt = transform.position;
        
        if (Input.GetAxis("Camera") == 1)
        {
            Camera.main.transform.position = transform.position;
            positionLookAt.y += 5;
            Camera.main.transform.position = positionLookAt;
            positionLookAt += cameraview*(transform.position - lastposition);
        } else
            if (Input.GetAxis("Camera2") == 1)
            {
                Camera.main.transform.position = transform.position;
                positionLookAt.y += 5;
                Camera.main.transform.position = positionLookAt;
                positionLookAt -= cameraview * (transform.position - lastposition);
            }
       
        Camera.main.transform.LookAt (positionLookAt);
        lastposition = transform.position;

    }

    void Zoom()                                 //Зум 
    {
        if (Input.GetAxis("Mouse ScrollWheel")> 0)
        {
            distance-= distanceZoomChange;   
        } else
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                distance+= distanceZoomChange;
            }
        if (distance < minZoomDistance) distance = 10;
        else if (distance > maxZoomDistance) distance = 50;
    }
     
}
