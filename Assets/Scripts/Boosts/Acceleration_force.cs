using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration_force : Effect
{
    public Rigidbody rd;
    public float force;

    const float max_speed = 80f;

    protected void Start()
    {
        if (!(rd))
            rd = gameObject.GetComponent<Rigidbody>();
    }

    public override void action()
    {
        rd.AddForce(new Vector3(force * (1 - rd.velocity.magnitude/ max_speed), 0));
    }
}
