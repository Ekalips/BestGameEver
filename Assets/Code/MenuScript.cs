using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width/2-100, Screen.height/2-150, 200, 300), "Menu");
        if(GUI.Button(new Rect(Screen.width/2 - 50,Screen.height/2 - 100, 100, 25), "Play"))
        {
            SceneManager.LoadScene(0);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 25), "Options"))
        {
            
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 25), "Exit"))
        {
            Application.Quit();
        }
    }
}
