using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DangerScript : MonoBehaviour {

    // Use this for initialization
    public GameObject Danger;
    Vector3 temp; int counterUpdate; bool state;
    RawImage ing;
    public Texture dangerIcon1;
    public Texture dangerIcon2;
    int sizeOfIcon = 15;
    void Start()
    {
        Danger = Instantiate(Danger, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Danger.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        counterUpdate = 0;
        state = false;
        ing = (RawImage)Danger.GetComponent<RawImage>();
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
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - sizeOfIcon, Camera.main.WorldToScreenPoint(transform.position).y, 0);
                    }
                    else if (Camera.main.WorldToScreenPoint(transform.position).x < Camera.main.pixelWidth && Camera.main.WorldToScreenPoint(transform.position).y > Camera.main.pixelHeight)
                    {
                        Danger.transform.position = new Vector3(Camera.main.WorldToScreenPoint(transform.position).x, Camera.main.pixelHeight, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - sizeOfIcon, Camera.main.pixelHeight, 0);
                    }
                }
                else if (Camera.main.WorldToScreenPoint(transform.position).x > 0 && Camera.main.WorldToScreenPoint(transform.position).y < 0)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).x < Camera.main.pixelWidth)
                    {
                        Danger.transform.position = new Vector3(Camera.main.WorldToScreenPoint(transform.position).x, sizeOfIcon, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - sizeOfIcon, sizeOfIcon, 0);
                    }
                }
                else if (Camera.main.WorldToScreenPoint(transform.position).x < 0 && Camera.main.WorldToScreenPoint(transform.position).y > 0)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).y < Camera.main.pixelHeight)
                    {
                        Danger.transform.position = new Vector3(sizeOfIcon, Camera.main.WorldToScreenPoint(transform.position).y, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(sizeOfIcon, Camera.main.pixelHeight, 0);
                    }
                }
                else
                {
                    Danger.transform.position = new Vector3(sizeOfIcon, sizeOfIcon, 0);
                }
            }
            else
            {
                if (Camera.main.WorldToScreenPoint(transform.position).y > 0 && Camera.main.WorldToScreenPoint(transform.position).x > 0)
                {
                    if (Camera.main.WorldToScreenPoint(transform.position).x < Camera.main.pixelWidth)
                    {
                        Danger.transform.position = new Vector3(Camera.main.pixelWidth - Camera.main.WorldToScreenPoint(transform.position).x, sizeOfIcon, 0);
                    }
                    else
                    {
                        Danger.transform.position = new Vector3(sizeOfIcon, sizeOfIcon, 0);
                    }
                }
            }

            if (counterUpdate % 9 == 0)
            {
                if (state)
                {
                    ing.texture = dangerIcon2;
                    Danger.transform.localScale = temp;
                    state = false;
                    ing.rectTransform.sizeDelta = new Vector2(30,30);
                }
                else
                {
                    ing.texture = dangerIcon1;
                    Danger.transform.localScale = temp;
                    state = true;
                    ing.rectTransform.sizeDelta = new Vector2(30, 30);
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

