using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling_saw_obstacle : MonoBehaviour
{
    public bool is_flying;

    private bool move;
    private Transform ball;

    const float deleting_range = 10;
    Rigidbody rd;

    // Use this for initialization
    void Start()
    {
        move = false;
        ball = GameObject.Find("ball").transform;
        rd = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!move)
            return;

        Vector3 speed = new Vector3(-10, 0, 0);

        transform.Rotate(new Vector3(0, 0, 700) * Time.deltaTime);
        
        rd.MovePosition(rd.position + speed * Time.deltaTime);

    }
    
    
   
    private void OnBecameVisible()
    {
        move = true;
    }

    private void OnBecameInvisible()
    {if (ball != null)
        {
            if (move && ball.position.x > transform.position.x + deleting_range)
                Destroy(gameObject);
        }
    else
            Destroy(gameObject);
    }
}
