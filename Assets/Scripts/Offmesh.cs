using UnityEngine;
using System.Collections;

public class Offmesh : MonoBehaviour {
	OffMeshLink f;
	// Use this for initialization
	void Start () {
		f = GetComponent<OffMeshLink> ();
	}
	
	// Update is called once per frame
	void Update () {
		//print (f.activated);
	}
}
