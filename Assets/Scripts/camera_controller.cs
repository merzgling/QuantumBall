using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    public Transform target;
    private Camera camera;

    private float fixed_z;
    private const float indentation_x = 8f;
    private const float indentation_y = 2.5f;
    private const float max_height = 18f;
    private const float min_height = 9.6f;





    private void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        fixed_z = transform.position.z;
        
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point_to_go = new Vector3(target.position.x + indentation_x, Mathf.Min(Mathf.Max(target.position.y + indentation_y, min_height), max_height));

            Vector3 point = camera.WorldToViewportPoint(new Vector3(point_to_go.x, point_to_go.y + 0.75f + indentation_y, point_to_go.z));
            Vector3 delta = new Vector3(point_to_go.x, point_to_go.y + 0.75f, point_to_go.z) - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            //хочу чтобы камеру по y не выходила за промежуток [0,9]
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);         
            transform.position = new Vector3(transform.position.x, transform.position.y, fixed_z);
        }
    }
}
