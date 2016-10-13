using UnityEngine;
using System.Collections;

public class anictrl : MonoBehaviour {

	public Animator Anim;
	static int speed = Animator.StringToHash ("Base Layer.speed");
	static int move = Animator.StringToHash ("Base Layer.move");
	static int jump = Animator.StringToHash ("Base Layer.jump");
	static int direct = Animator.StringToHash ("Base Layer.direct");
	 Rigidbody rb;

	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animator>();
		Anim.SetFloat ("direct", 0.5f);
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		//		Anim.SetBool ("move", true);
		//		Anim.SetFloat ("direct", 0.5f);

		if (Input.GetKeyDown (KeyCode.W)) {
			Anim.SetBool ("move", true);
		}
		else if (Input.GetKeyUp (KeyCode.W)) {
			Anim.SetBool ("move", false);
		}

		else if (Input.GetKey (KeyCode.S)) {
			
			Anim.SetBool ("move", true);
			float s= Anim.GetFloat ("fb");
			if(s<1f)	Anim.SetFloat ("fb", s+Time.deltaTime);
		}
		else if (Input.GetKeyUp (KeyCode.S)){
			Anim.SetBool ("move", false);
			float s = Anim.GetFloat ("fb");
			if(s>0f)	Anim.SetFloat ("fb", 0);
			print (s);
			}


		if (Input.GetKey (KeyCode.A)) {
			float a = Anim.GetFloat ("direct");
			if(a>0f)	Anim.SetFloat ("direct", a-Time.deltaTime);
		}
		else  {
			float a = Anim.GetFloat ("direct");
			if(a<0.5f)	Anim.SetFloat ("direct", a+Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			float d = Anim.GetFloat ("direct");
			if(d<1f)	Anim.SetFloat ("direct", d+Time.deltaTime);
		}
		else {
			float d = Anim.GetFloat ("direct");
			if(d>0.5f)	Anim.SetFloat ("direct", d-Time.deltaTime);
		}



		if (Input.GetKey (KeyCode.RightShift)) {
			
			float shift = Anim.GetFloat ("speed");
			if(shift<1f)	Anim.SetFloat ("speed", shift+Time.deltaTime);
		}
		else
		{
			float shift = Anim.GetFloat ("speed");
			if(shift>0f)	Anim.SetFloat ("speed", shift-Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Anim.SetBool ("jump", true);
//			print (rb.transform.position.y);
//			print (rb.transform.position);
			Vector3 v=rb.transform.position;
			v.y += 0.5f;
			if (Physics.Raycast (v, Vector3.down, 0.51f))
//				print (Anim.velocity.z);
//				rb.AddForce (new Vector3(Anim.velocity.x*100,200.0f,Anim.velocity.z*100));
				rb.AddForce (Anim.velocity.x,4.0f,Anim.velocity.z,ForceMode.VelocityChange);
//			print (rb.transform.position.y);
		} 
		if(Input.GetKeyUp (KeyCode.Space)) {
			Anim.SetBool ("jump", false);
		}

	}
}
