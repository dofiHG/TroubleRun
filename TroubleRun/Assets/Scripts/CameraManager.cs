using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public float followSpeed = 3; //Speed ​​at which the camera follows us
	public float mouseSpeed = 2; //Speed ​​at which we rotate the camera with the mouse
	//public float controllerSpeed = 5; //Speed ​​at which we rotate the camera with the joystick
	public float cameraDist = 3; //Distance to which the camera is located

	public Transform target; //Player the camera follows

	[HideInInspector]
	public Transform pivot; //Pivot on which the camera rotates(distance that we want between the camera and our character)
	[HideInInspector]
	public Transform camTrans; //Camera position

	float turnSmoothing = .1f; //Smooths all camera movements (Time it takes the camera to reach the rotation indicated with the joystick)
	public float minAngle = -35; //Minimum angle that we allow the camera to reach
	public float maxAngle = 35; //Maximum angle that we allow the camera to reach

	float smoothX;
	float smoothY;
	float smoothXvelocity;
	float smoothYvelocity;
	public float lookAngle; //Angle the camera has on the Y axis
	public float tiltAngle; //Angle the camera has up / down

	public void Init()
	{
		camTrans = Camera.main.transform;
		pivot = camTrans.parent;
	}

	void FollowTarget()
	{
		float speed = Time.deltaTime * followSpeed;
		Vector3 targetPosition = Vector3.Lerp(transform.position, target.position, speed);
		transform.position = targetPosition;
	}

	void HandleRotations(float v, float h, float targetSpeed)
	{
		if (turnSmoothing > 0)
		{
			smoothX = Mathf.SmoothDamp(smoothX, h, ref smoothXvelocity, turnSmoothing); //Gradually change a value toward a desired goal over time.
			smoothY = Mathf.SmoothDamp(smoothY, v, ref smoothYvelocity, turnSmoothing);
		}
		else
		{
			smoothX = h;
			smoothY = v;
		}

		tiltAngle -= smoothY * targetSpeed;
		tiltAngle = Mathf.Clamp(tiltAngle, minAngle, maxAngle);
		pivot.localRotation = Quaternion.Euler(tiltAngle, 0, 0);

		lookAngle += smoothX * targetSpeed;
		transform.rotation = Quaternion.Euler(0, lookAngle, 0);

	}

	private void FixedUpdate()
	{
		float h = Input.GetAxis("Mouse X");
		float v = Input.GetAxis("Mouse Y");

		FollowTarget();
		HandleRotations(v, h, mouseSpeed);
	}

	private void LateUpdate()
	{
		float dist = cameraDist + 1.0f;
		Ray ray = new Ray(camTrans.parent.position, camTrans.position - camTrans.parent.position);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, dist))
		{
			if (hit.transform.tag == "Wall")
			{
				dist = hit.distance - 0.25f;
			}
		}
		if (dist > cameraDist) dist = cameraDist;
		camTrans.localPosition = new Vector3(0, 0, -dist);
	}

	public static CameraManager singleton; //You can call CameraManager.singleton from other script (There can be only one)
	void Awake()
	{
		singleton = this; //Self-assigns
		Init();
	}
}
