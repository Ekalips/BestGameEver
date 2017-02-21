using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace{
	
	[RequireComponent(typeof (Rigidbody))]
	public class Lel : MonoBehaviour {

		public float thrust = 0;

		public float maxEnginePower = 40f;

		public float EnginePower = 0f;

		public float currentSpeed = 0;

		private Rigidbody m_Rigidbody;

		public float lyft = 0.5f;

		public float pitch = 0;

		// Use this for initialization
		void Start () {
			m_Rigidbody = GetComponent<Rigidbody>();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S)) {
				thrust = Mathf.Max (0, Mathf.Min (100, (thrust + (15f * Time.deltaTime))));
			} else if (Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.W)) {
				thrust = Mathf.Max (0, Mathf.Min (100, (thrust - (15f * Time.deltaTime))));
			}

			pitch = Input.GetAxis ("Horizontal");
		}


		void FixedUpdate(){
			Vector3 force = Vector3.zero;

			EnginePower = Mathf.Clamp01 (thrust) * maxEnginePower;

			force += EnginePower * transform.forward;


			transform.Rotate (transform.right*pitch);

			m_Rigidbody.AddForce (force);

		}
	}

}
