using UnityEngine;
using System.Collections;

public class NavContrl : MonoBehaviour {
	public static NavContrl Obj;
	private Animator anim;
	public NavMeshAgent agent;
	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;
	public bool dest_flg = false;
	public bool path_flg = false;
	private ArrayList path;
	private int index;
	// Use this for initialization
	void Start () {
		Obj = this;
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		index = 0;
		agent.enabled = false;
		//agent.updatePosition = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!dest_flg)
			return;
		if (!path_flg) {
			agent.enabled = true;
			NavMeshPath nevpath = new NavMeshPath ();
			agent.CalculatePath (agent.destination,nevpath);
			path = new ArrayList(nevpath.corners);
			index = 0;
			path_flg = true;
			agent.enabled = false;
			for (int i = 0; i < path.Count; i++) {
				print (path [i]);
			}
		} else {
			if (((Vector3)(path [index]) - transform.position).magnitude <= 0.5f && index < path.Count - 1)
				index++;
			if(index == path.Count - 1 && ((Vector3)(path[index]) - transform.position).magnitude <= 0.5f){
				anim.SetBool ("move", false);
				anim.SetFloat ("direct", 0.5f);
				path.Clear ();
			}
			Vector3 direction = (Vector3)(path[index]) - transform.position;
			float dir_z = Vector3.Dot (transform.forward, direction);
			float dir_x = Vector3.Dot (transform.right, direction);
			Vector2 deltaPosition = new Vector2 (dir_x, dir_z);

			// Low-pass filter the deltaMove
			float smooth = Mathf.Min (1.0f, Time.deltaTime / 0.15f);
			//print(Time.deltaTime / 0.15f);
			smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);
			//print(smoothDeltaPosition);
			//print(Time.deltaTime);
			// Update velocity if delta time is safe
			if (Time.deltaTime > 1e-5f)
				velocity = smoothDeltaPosition / Time.deltaTime;
			//print(velocity.magnitude);
//		anim.SetFloat ("direct", 0.5f);
			if (velocity.y > 0.0f && velocity.x < 2.1f && velocity.x > -2.1f) {
				anim.SetBool ("move", true);
				anim.SetFloat ("direct", 0.5f);
			} else if (velocity.x > 2.1f) {
				//anim.SetBool ("move", false);
				anim.SetFloat ("direct", 1.0f);
			} else if (velocity.x <= -2.1f) {
				//anim.SetBool ("move", false);
				anim.SetFloat ("direct", 0.0f);
			}
		}
	}
//	void OnAnimatorMove () {
//		// Update postion to agent position
//		//		transform.position = agent.nextPosition;
//
//		// Update position based on animation movement using navigation surface height
//		Vector3 position = anim.rootPosition;
//		position.y = agent.nextPosition.y;
//		transform.position = position;
//	}
}
