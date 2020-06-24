using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column_deleter : MonoBehaviour
{
    public Pool column_pool;
    private float living_time;
    private float current_time;

    public Column_deleter(float t)
    {
        living_time = t;
    }

    public Column_deleter()
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
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.GetComponent<Obstacle>())
                    if (child.GetComponent<Obstacle>().type == "saw")
                        Destroy(child.gameObject);
            }

            column_pool.push(gameObject);
            Destroy(this);
        }
        current_time += Time.deltaTime;
    }
}
