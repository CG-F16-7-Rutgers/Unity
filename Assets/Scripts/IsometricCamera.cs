using UnityEngine;
using System.Collections;

public class IsometricCamera : MonoBehaviour {

	private float Movespeed = 0.1f;
	private Vector3 look = Vector3.zero;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		look.x = transform.position.x;
		look.z = transform.position.z;
		transform.LookAt(look);
		if (Input.GetKey(KeyCode.W))
		{ transform.Translate(Vector3.forward * Movespeed, Space.World); }
		if (Input.GetKey(KeyCode.S))
		{ transform.Translate(Vector3.back * Movespeed, Space.World); }
		if (Input.GetKey(KeyCode.A))
		{ transform.Translate(Vector3.left * Movespeed, Space.World); }
		if (Input.GetKey(KeyCode.D))
		{ transform.Translate(Vector3.right * Movespeed, Space.World); }
		float zoom = Input.GetAxis("Mouse ScrollWheel") * Movespeed;
		transform.Translate(Vector3.up * zoom, Space.World);
	}
}
