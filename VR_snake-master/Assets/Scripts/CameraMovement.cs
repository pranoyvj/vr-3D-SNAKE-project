using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.UpArrow)) transform.Rotate(new Vector3(90, 0, 0));
		if (Input.GetKeyUp(KeyCode.DownArrow)) transform.Rotate(new Vector3(-90, 0, 0));
		if (Input.GetKeyUp(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0, 90, 0));
		if (Input.GetKeyUp(KeyCode.RightArrow)) transform.Rotate(new Vector3(0, -90, 0));
	}
}
