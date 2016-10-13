// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	NavMeshAgent agent;
	private int count;
	private float first_time;
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		count = 0;
		first_time = Time.time;
	}
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				if (Time.time - first_time > 1.0f)
					count = 0;
				if (count == 1) {
					if (Time.time - first_time < 0.5f) {
						NavContrl.Obj.run_flg = true;
					}
					count = 0;
					return;
				}
				agent.enabled = true;
				agent.destination = hitInfo.point;
				NavContrl.Obj.dest_flg = true;
				NavContrl.Obj.path_flg = false;
				count++;
				first_time = Time.time;
			}
		}
	}
}