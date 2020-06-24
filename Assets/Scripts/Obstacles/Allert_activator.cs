using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allert_activator : MonoBehaviour
{
    public GameObject object_to_activate;
    private Transform ball;

    public float activating_range;

    //    Use this for initialization

    void Start()
    {
        ball = GameObject.Find("ball").transform;
    }

    //Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(ball.position.x - transform.position.x) <= activating_range)
        {
            if (object_to_activate)
                object_to_activate.SetActive(true);
            else
                Destroy(gameObject);
            gameObject.AddComponent<Living_bomb>();
            Destroy(this);
        }
    }
}
