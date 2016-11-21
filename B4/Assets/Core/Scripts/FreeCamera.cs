using UnityEngine;
using System.Collections;

public class FreeCamera : MonoBehaviour
{
	public float rotateSensitivity = 100.0f;
    public float speed;
    public float Movespeed;
    private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis
    private Rigidbody rb;

    void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
    }

	void FixedUpdate ()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rotY += moveHorizontal * rotateSensitivity * Time.deltaTime;
        rotX += moveVertical * rotateSensitivity * Time.deltaTime;
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;

        if (Input.GetKey(KeyCode.W))
        { transform.Translate(Vector3.forward * Movespeed, Space.Self); }
        if (Input.GetKey(KeyCode.S))
        { transform.Translate(Vector3.back * Movespeed, Space.Self); }
        if (Input.GetKey(KeyCode.A))
        { transform.Translate(Vector3.left * Movespeed, Space.Self); }
        if (Input.GetKey(KeyCode.D))
        { transform.Translate(Vector3.right * Movespeed, Space.Self); }
    }
}