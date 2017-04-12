using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour {

    // Use this for initialization
    GameObject Danger;
    Vector3 temp; int counterUpdate; bool state;
    void Start()
    {
        Danger = GameObject.FindWithTag("Dang");
        counterUpdate = 0;
        state = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Danger != null)
        {
            temp = Danger.transform.localScale;
            if (Camera.main.WorldToScreenPoint(transform.position).z > 0)
            {
                if (Camera.main.WorldToScreenPoint(transform.position).x > 0 && Camera.main.WorldToScreenPoint(transform.position).y > 0)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).x < Camera.main.pixelWidth && Camera.main.WorldToScreenPoint(transform.position).y < Camera.main.pixelHeight)
                    {
                        Danger.transform.position = new Vector3(Camera.main.WorldToScreenPoint(transform.position).x, Camera.main.WorldToScreenPoint(transform.position).y, 0);
                    }
                    else if (Camera.main.WorldToScreenPoint(transform.position).x > Camera.main.pixelWidth && Camera.main.WorldToScreenPoint(transform.position).y < Camera.main.pixelHeight)
                    {
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - 50, Camera.main.WorldToScreenPoint(transform.position).y, 0);
                    }
                    else if (Camera.main.WorldToScreenPoint(transform.position).x < Camera.main.pixelWidth && Camera.main.WorldToScreenPoint(transform.position).y > Camera.main.pixelHeight)
                    {
                        Danger.transform.position = new Vector3(Camera.main.WorldToScreenPoint(transform.position).x, Camera.main.pixelHeight, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - 50, Camera.main.pixelHeight, 0);
                    }
                }
                else if (Camera.main.WorldToScreenPoint(transform.position).x > 0 && Camera.main.WorldToScreenPoint(transform.position).y < 0)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).x < Camera.main.pixelWidth)
                    {
                        Danger.transform.position = new Vector3(Camera.main.WorldToScreenPoint(transform.position).x, 50, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - 50, 50, 0);
                    }
                }
                else if (Camera.main.WorldToScreenPoint(transform.position).x < 0 && Camera.main.WorldToScreenPoint(transform.position).y > 0)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).y < Camera.main.pixelHeight)
                    {
                        Danger.transform.position = new Vector3(50, Camera.main.WorldToScreenPoint(transform.position).y, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(50, Camera.main.pixelHeight, 0);
                    }
                }
                else
                {
                    Danger.transform.position = new Vector3(50, 50, 0);
                }
            }
            else
            {
                if (Camera.main.WorldToScreenPoint(transform.position).y > 0 && Camera.main.WorldToScreenPoint(transform.position).x > 0)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).x < Camera.main.pixelWidth)
                    {
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - Camera.main.WorldToScreenPoint(transform.position).x, 50, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(50, 50, 0);
                    }
                }
            }

            if (counterUpdate % 15 == 0)
            {
                if (state)
                {
                    temp.x = 1f;
                    temp.y = 1f;
                    Danger.transform.localScale = temp;
                    state = false;
                }
                else
                {
                    temp.x = 0.5f;
                    temp.y = 0.5f;
                    Danger.transform.localScale = temp;
                    state = true;
                }
            }
            counterUpdate++;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Destroy((GameObject)Danger);
    }
}

