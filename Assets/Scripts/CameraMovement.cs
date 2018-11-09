using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	static float CAMERA_DISTANCE = 10;

	public GameObject target;
	public float smoothTime;

	private Vector3 currVelocity = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
		Vector3 camPosition = transform.position;

		// Camera should follow the target
		Vector3 targetPosition = target.transform.position;
		targetPosition.z -= CAMERA_DISTANCE;

		// Smoothly move the camera towards the target
		transform.position = Vector3.SmoothDamp(camPosition, targetPosition, ref currVelocity, smoothTime);
	}
}
