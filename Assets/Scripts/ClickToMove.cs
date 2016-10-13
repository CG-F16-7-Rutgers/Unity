// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hitInfo)) {
				agent.enabled = true;
				agent.destination = hitInfo.point;
				NavContrl.Obj.dest_flg = true;
				NavContrl.Obj.path_flg = false;
			}
		}
	}
}