using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAA : MonoBehaviour {

	public float delay = 0f;
	GameObject player;
	public GameObject rocketPrefab;
    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
		Debug.DrawRay (transform.position, transform.forward*300f,Color.red);

		if (Input.GetKey (KeyCode.Space) && delay == 0) {
			Vector3 _direction = (player.transform.position - transform.position).normalized;
			Quaternion _lookRotation = Quaternion.LookRotation(_direction);

           

            Instantiate (rocketPrefab,transform.position + transform.forward*5f, _lookRotation);
			delay = 200f;
		}
		if (delay != 0)
			delay -= 0.5f;
		if (delay < 0)
			delay = 0;
	}



	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.03f){
		GameObject line = new GameObject ();
		line.transform.position = start;
		line.AddComponent<LineRenderer> ();
		LineRenderer lr = line.GetComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.SetColors (color, color);
		lr.SetWidth (0.1f, 0.1f);
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
		GameObject.Destroy (line, duration);
	}
}
