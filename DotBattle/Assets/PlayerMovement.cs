using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	// Use this for initialization
	public float starting_z;
	Vector3 touchPosition;
	public GameObject marker;

	void Start () {
		touchPosition = new Vector3 (0, 0, 0);
	}

	void FixedUpdate() {
		Touch[] touches = Input.touches;
		for(int i = 0; i < touches.Length; i++){
			// The screen has been touched so store the touch
			Touch touch = touches[i];

			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				// If the finger is on the screen, move the object smoothly to the touch position
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));   
				if (i == 0) {
					             
					transform.position = Vector3.Lerp (transform.position, touchPosition, Time.deltaTime);
				} else if (i == 1) {
					Instantiate (marker, touchPosition, Quaternion.identity);
				}
			}
		}
	}

	void OnGUI(){
		GUI.Label (new Rect (100, 100, 300, 100), string.Format("X: {0}, Y: {1}, Z: {2}",transform.position.x,transform.position.y,transform.position.z));
		GUI.Label (new Rect (100, 150, 300, 100), string.Format("X: {0}, Y: {1}, Z: {2}",touchPosition.x,touchPosition.y,touchPosition.z));
	}
}
