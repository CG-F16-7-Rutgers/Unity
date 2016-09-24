using UnityEngine;
using System.Collections;

public class MovingObstacle : MonoBehaviour {
    private RaycastHit hit;
    private ArrayList agentlist = new ArrayList();
    public float Movespeed;
    // Use this for initialization
    void Start () {
        transform.GetComponent<Moving>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray, out hit, 100) && Input.GetKey(KeyCode.LeftControl) && hit.collider)
            {


                if (!transform.GetComponent<Moving>().enabled)
                {

                    if (hit.collider.tag == "Moving")
                    {

                        transform.GetComponent<Moving>().enabled = true;

                    }
                }





                else if (transform.GetComponent<Moving>().enabled)
                {

                    if (hit.collider.tag == "Moving")
                    {

                        transform.GetComponent<Moving>().enabled = false;

                    }
                }

            }

        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        //    if (Physics.Raycast(ray, out hit, 100) && Input.GetKey(KeyCode.LeftControl) && hit.collider && transform.GetComponent<Moving>().enabled )
        //    {
        //        if (hit.collider.tag == "Moving")
        //        {
        //            transform.GetComponent<Moving>().enabled = false;

        //        }
        //    }

        //}
    }
}


//       if(Input.GetKey(KeyCode.I)) 
//       { transform.Translate(Vector3.forward* Movespeed, Space.Self); }
//       if (Input.GetKey(KeyCode.K))
//       { transform.Translate(Vector3.back* Movespeed, Space.Self); }
//       if (Input.GetKey(KeyCode.J))
//       { transform.Translate(Vector3.left* Movespeed, Space.Self); }
//       if (Input.GetKey(KeyCode.L))
//       { transform.Translate(Vector3.right* Movespeed, Space.Self); }