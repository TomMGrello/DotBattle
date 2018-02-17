using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	// Use this for initialization
	float starting_z;
	void Start () {
		starting_z = transform.position.z;
	}

	void FixedUpdate () {
		Touch touch = Input.GetTouch (0);

		if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began){
			Vector3 touchedPos = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, starting_z));
			transform.position = Vector3.Lerp (transform.position, touchedPos, 5f);
		}
	}

	void OnGUI(){
		GUI.Label (new Rect (100, 100, 200, 50), string.Format("X: {0}, Y: {1}, Z: {0}",transform.position.x,transform.position.y,transform.position.z));
	}
}
