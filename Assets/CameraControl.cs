using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		 Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
	  Vector3 camera_t = new Vector3(0, Input.GetAxis("Mouse X"), 0);
		transform.Rotate(camera_t, Space.World);
	  camera_t = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
		transform.Rotate(camera_t, Space.Self);
		
	  Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	  
		transform.Translate(movement/5, Space.Self);
	}
}
