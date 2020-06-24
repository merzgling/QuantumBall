using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_obstacle : MonoBehaviour
{
    public GameObject allert;
    public GameObject rocket;

    private const float speed = -13f;
    private bool rocket_launched;

    private void Start()
    {
        rocket_launched = false;
    }

    private void FixedUpdate()
    {
        if (rocket_launched)
        {
            Rigidbody rd = rocket.GetComponent<Rigidbody>();
            rd.MovePosition(rd.position + new Vector3(speed, 0) * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool is_visible = rocket.GetComponent<Is_visible>().is_visible;

        if (!rocket_launched)
            if (is_visible)
                rocket_launched = true;

        if (allert)
        {
            if (is_visible)
                Destroy(allert);
        }
        else
        {
            if (!is_visible)
                Destroy(gameObject);
        }

    }
}
