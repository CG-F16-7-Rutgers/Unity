using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    public OffMeshLink off;
    Animator ani;
    Vector3 direction = Vector3.zero;
    private float forward_speed = 0.0f;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            if(forward_speed < 0.02f)
                forward_speed += 0.01f;
            ani.SetBool("walk", true);
            direction = Vector3.forward;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            forward_speed = 0.0f;
            ani.SetBool("walk", false);
            direction = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (direction.x < 1.0f)
                direction.x += 0.5f;
            ani.SetFloat("direction",1.0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (direction.x > -1.0f)
                direction.x -= 0.5f;
            ani.SetFloat("direction",0.5f);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            direction.x = 0;
            ani.SetFloat("direction",direction.x);
        }
	}
}
