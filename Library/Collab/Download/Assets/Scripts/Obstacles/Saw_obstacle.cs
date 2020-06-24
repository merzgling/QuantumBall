using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_obstacle : MonoBehaviour
{
    private Transform ball;

    const float deleting_range = 70f;

    private void Awake()
    {
        if (GameObject.Find("ball"))
            ball = GameObject.Find("ball").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -600) * Time.deltaTime);

        if (ball)
            if (ball.position.x > transform.position.x + deleting_range)
                Destroy(gameObject);
    }
}
