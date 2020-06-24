using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living_bomb : MonoBehaviour
{
    private float living_time;
    private float current_time;

    public Living_bomb(float t)
    {
        living_time = t;
    }

    public Living_bomb()
    {
        living_time = 0.5f;
    }

    // Use this for initialization
    void Start()
    {
        current_time = 0f;
    }

    private void FixedUpdate()
    {
        Rigidbody rd = gameObject.GetComponent<Rigidbody>();
        Vector3 speed = new Vector3(0, -21);
        if (rd)
            rd.MovePosition(rd.position + speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_time > living_time)
            Destroy(gameObject);
        current_time += Time.deltaTime;
    }
}
