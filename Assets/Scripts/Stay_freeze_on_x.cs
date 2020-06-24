using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay_freeze_on_x : MonoBehaviour
{
    private Transform ball;
    private float delta;

    private const float k = 0.7f;
    private const float a = 7f;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("ball").transform;
        delta = transform.position.x - ball.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.position.x + delta + ball.position.y * k - a, transform.position.y);
    }
}
