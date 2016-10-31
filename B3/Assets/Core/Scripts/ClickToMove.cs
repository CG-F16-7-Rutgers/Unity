using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	
	private RaycastHit hit;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown (0)) {
            Physics.Raycast(ray, out hit, 100);
            transform.position = hit.point;
        }
    }
}

 