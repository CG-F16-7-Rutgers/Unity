using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
    public float Movespeed;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.I))
        { transform.Translate(Vector3.forward * Movespeed, Space.Self); }
        if (Input.GetKey(KeyCode.K))
        { transform.Translate(Vector3.back * Movespeed, Space.Self); }
        if (Input.GetKey(KeyCode.J))
        { transform.Translate(Vector3.left * Movespeed, Space.Self); }
        if (Input.GetKey(KeyCode.L))
        { transform.Translate(Vector3.right * Movespeed, Space.Self); }
    }
}
