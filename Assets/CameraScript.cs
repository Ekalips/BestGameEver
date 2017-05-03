using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public float currentRotateX = 0f;
	public float currentRotateY = 0f;
    Vector3 lastposition;
	float distance = 60.0f;

    GameObject player;

    public const float cameraview = 15f;
    public const float minZoomDistance = 10f;
    public const float maxZoomDistance = 100f;
    public const float distanceZoomChange = 8f;

    float startRotateX;
    float startRotateY;

    // Use this for initialization
    void Start () {

        //   lastposition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // Read the user input
        float camera_sensitiv = 3f;

        Zoom();
        if (Input.GetAxis("Camera") == 1)
            CameraRotation(camera_sensitiv);
        else
        {
            Vector3 dist;
            dist = player.transform.forward;
            while (System.Math.Sqrt(dist.x * dist.x + dist.y * dist.y + dist.z * dist.z) < distance)
                dist += dist/10;
            dist.y -= 15;
            Camera.main.transform.position = transform.position - dist;
        }



        Quaternion rotation = Quaternion.Euler (-currentRotateY, currentRotateX, 0);                                        //Для камеры динамичное движение
        Quaternion rotationalways = Quaternion.Euler(0, 0, 0);                                                              //Для камеры статичное движение
        Vector3 position = rotation * new Vector3 (0.0f, 0.0f, -distance) + transform.position;
        Vector3 positionalways = rotationalways * new Vector3(0.0f, 0.0f, -distance) + transform.position;
        if (position.y < 5 ) { position.y = 5; positionalways.y = 5; }
		Vector3 moveCameraTo = transform.position - (transform.forward * 10.0f) + (Vector3.up * 7.0f);
		float bias = 0.83f; //0.95 изначально
                            //float bias = 0f;

        if (Input.GetAxis("Camera") == 1)
            Camera.main.transform.position = Camera.main.transform.position * bias + position * (1.0f - bias);              //Поворот камеры по мышке пока кнопка нажата
        else {
            Camera.main.transform.position = Camera.main.transform.position * bias + positionalways * (1.0f - bias);       //Камера стабильна пока кнопка не нажата
            currentRotateX = 0;
            currentRotateY = 0;
             }
        //if (Input.GetAxis("Camera2") == 1)


        Vector3 positionLookAt = transform.position;

        

        //if (Input.GetAxis("Camera") == 1)						//при нажатии (с) вид на точку, куда мы движемся
        //{										                //тип вид от кабины пилота
        //    Camera.main.transform.position = transform.position;
        //    positionLookAt.y += 5;
        //    Camera.main.transform.position = positionLookAt;
        //    positionLookAt += cameraview*(transform.position - lastposition);
        //} else
        //    if (Input.GetAxis("Camera2") == 1)						//если (с) не нажата при нажатии (v) вид на точку
        //    {										//откуда мы двигались
        //        Camera.main.transform.position = transform.position;			//тип вид на жопу.
        //        positionLookAt.y += 5;
        //        Camera.main.transform.position = positionLookAt;
        //        positionLookAt -= cameraview * (transform.position - lastposition);
        //    }

        
       
        if (Input.GetAxis("Camera2") ==1)
        {
            
            ////Camera.main.transform.position = transform.position;
            ////positionLookAt.y += 5;
            //dist = transform.position - lastposition;

            //while (System.Math.Sqrt(dist.x*dist.x + dist.y*dist.y + dist.z*dist.z)<20)
            //{
            //    dist += dist / 100;
            //}

            //dist.y -= 15;
            //Vector3 camposition = transform.position - dist;
            //Camera.main.transform.position = camposition;
            //positionLookAt += cameraview * (transform.position - lastposition);
            
            
        }

        Camera.main.transform.LookAt(positionLookAt);
        lastposition = transform.position;
    }

    void CameraRotation(float camera_sensitiv)       //Вращение камеры
    {
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
    }

    void Zoom()                                 //Зум 
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance-= distanceZoomChange;   
        } else
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                distance+= distanceZoomChange;
            }
        if (distance < minZoomDistance) distance = minZoomDistance;
        else if (distance > maxZoomDistance) distance = maxZoomDistance;
    }
     
}

