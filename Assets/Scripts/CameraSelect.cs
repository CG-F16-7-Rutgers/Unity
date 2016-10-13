using UnityEngine;
using System.Collections;

public class CameraSelect : MonoBehaviour {
	public Camera isometric;
	public Camera follow;
	// Use this for initialization
	void Start () {
		follow.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			follow.enabled = !follow.enabled;
			isometric.enabled = !isometric.enabled;
		}
	}
}
