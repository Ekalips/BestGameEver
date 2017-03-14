using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;

public class GeasControl : MonoBehaviour {

	public float raiseAtAltitude = 100;
	public float lowerAtAltitude = 200;
	private Animator m_Animator;
	private Rigidbody m_Rigidbody;
	private AeroplaneController m_Plane;
	bool isRised = false;
	// Use this for initialization
	void Start () {
		m_Plane = GetComponent<AeroplaneController>();
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {


		if (m_Plane.Altitude > raiseAtAltitude )
		{
			isRised = true;
		}

		if (m_Plane.Altitude < lowerAtAltitude )
		{
			isRised = false;
		}

		m_Animator.SetBool ("IsGearsOpen",isRised);
	}
}
