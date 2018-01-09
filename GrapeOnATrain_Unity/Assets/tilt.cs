using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour {

	public double tiltSensitivity = 0.2;
	public double maxRotation = 350;
	public double minRotation = 8;
	public Vector3 currentRotation;
	public Vector3 currentAcceleration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentRotation = GetComponent<Transform>().eulerAngles;
		currentAcceleration = Input.acceleration;
		Debug.Log(currentRotation.x);

		if (currentAcceleration.x < -tiltSensitivity &&
				(currentRotation.z <= minRotation || currentRotation.z >= maxRotation)) {
			transform.Rotate (0, 0, 1);	//TODO use timer

		} else if (currentAcceleration.x > tiltSensitivity &&
				(currentRotation.z >= maxRotation + 1 || currentRotation.z <= minRotation + 1)) {
			transform.Rotate (0, 0, -1);	//TODO use timer
		}

		if (currentAcceleration.y < -tiltSensitivity &&
				(currentRotation.x >= maxRotation + 1 || currentRotation.x <= minRotation + 1)) {
			transform.Rotate (-1, 0, 0);

		} else if (currentAcceleration.y > tiltSensitivity &&
				(currentRotation.x <= minRotation || currentRotation.x >= maxRotation)) {
			transform.Rotate (1, 0, 0);
		}

	}
}
