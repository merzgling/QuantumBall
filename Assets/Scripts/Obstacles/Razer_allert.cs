using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer_allert : MonoBehaviour
{
    public Razer_obstacle razer_obstacle;
    public Transform ball;

    private const int trigger_range = 7;

    private void Update()
    {
        if (ball != null)
        {
            if (ball.position.x + trigger_range > transform.position.x)
            {
                razer_obstacle.activate = true;
                Destroy(this);
            }
        }
    }
}
