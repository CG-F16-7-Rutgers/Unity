using UnityEngine;
using System.Collections;

public class AutoMoving : MonoBehaviour
{
    public float minspeed;
    Vector3 Origin;
    Vector3 Status;
    private Vector3 velocity = Vector3.zero;
    private int Count = 1;
    public int count_dest = 200;
    private float smoothtime = 0.3f;

    private bool is_lerp;
    private float time_start_lerp;
    private float time_taken = 1.0f;
    Vector3 target;
    // Use this for initialization
    void Start()
    {

        Origin = transform.position;
        target = Origin + Vector3.right * 10;
        time_start_lerp = Time.time;
        is_lerp = true;
    }
    // Update is called once per frame
    void lerp_do(Vector3 Origin, Vector3 target)
    {
        float time_since_start = Time.time - time_start_lerp;
        float percentage = time_since_start / time_taken;
        transform.position = Vector3.Lerp(Origin, target, percentage);
        if (percentage >= 1.0f)
        {
            is_lerp = !is_lerp;
            time_start_lerp = Time.time;
        }
    }
    void FixedUpdate()
    {
        if (is_lerp)
        {
            lerp_do(Origin, target);
        }
        else
        {
            lerp_do(target, Origin);
        }

        //transform.position = new Vector3(Mathf.Lerp(0.0f,30.0f,10*Time.deltaTime), 0.0f, 0.0f);
        //float Newposition = Mathf.SmoothDamp(Status.x, Status.x + 200.0f, ref velocity, 0.3.f);

        //transform.position = new Vector3(Newposition, transform.position.y, transform.position.z);
        //transform.position = Vector3.SmoothDamp(Origin, target, ref velocity, 0.1f, 100.0f);
        //Status = transform.position;
        /* else
         {

             float Newposition = Mathf.SmoothDamp(Status.x, Origin.x, ref velocity, 0.3f);
             transform.position = new Vector3(Newposition, transform.position.y, transform.position.z);
         }*/

        //Status = new Vector3(Origin.x + 1.0f, Origin.y + 1.0f, Origin.z + 1.0f);


    }
}
