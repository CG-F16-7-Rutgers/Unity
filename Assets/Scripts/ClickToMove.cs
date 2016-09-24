using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	//NavMeshAgent agent;
	private RaycastHit hit;
    private ArrayList agentlist = new ArrayList();
	// Use this for initialization
	void Start () {
		//agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//left click
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown (0)) {
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            if (Physics.Raycast(ray, out hit, 100) && Input.GetKey(KeyCode.LeftControl) && hit.collider)
            {
                if (hit.collider.tag == "Agent")
                {
                    agentlist.Add(hit.collider.GetComponent<NavMeshAgent>());
                    
                }
            }
            else if (Physics.Raycast(ray, out hit, 100))
            {
                for(int i =  0;i < agentlist.Count; i++)
                {
                    NavMeshAgent agent = (NavMeshAgent)agentlist[i];
                    agent.destination = hit.point;
                }
                /*foreach (var agent in agentlist)
                {
                    agent.destination = hit.point;
                }*/
                agentlist.Clear();
            }
        }
	}
}

 