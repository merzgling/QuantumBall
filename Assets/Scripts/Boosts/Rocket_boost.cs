using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_boost : Effect
{
    public float force;

    GameObject red_flame;
    GameObject blue_flame;
    public Rigidbody rd;
    public GameObject player;
    public GameObject ball;

    private float destroing_range = 70f;

    protected void Start()
    {
        if (!(rd))
            rd = gameObject.GetComponent<Rigidbody>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        ball = GameObject.Find("ball");
        blue_flame = GameObject.Find("TrackVisual");
        for (int i = 0; i < player.transform.childCount; i++)
        {
            if (player.transform.GetChild(i).name == "RocketFlamesVisual")
            {
                red_flame = player.transform.GetChild(i).gameObject;
            }
        }
        red_flame.SetActive(true);
        blue_flame.SetActive(false);
    }

    public override void action()
    {
        rd.AddForce(new Vector3(force * 1.5f, 0));
       // rd.AddForce(new Vector3(0, 20));
       
    }

    public void OnDestroy()
    {
        List<GameObject> objects_to_destroy = new List<GameObject>();

        for (int i = 0; i < Obstacle_creater.created_obstacles.Count; i++)
        {
            GameObject obstacle = Obstacle_creater.created_obstacles[i];
            if (obstacle)
            {
                if ((ball.transform.position - obstacle.transform.position).magnitude < destroing_range)
                {
                    Obstacle_creater.created_obstacles.Remove(obstacle);
                    ExplosionsCall.ObstacleExplosion(obstacle.transform.position, false);
                    Destroy(obstacle);
                }
            }
        }

        for (int i = 0; i < Obstacle_creater.created_obstacles.Count; i++)
        {
            GameObject obstacle = Obstacle_creater.created_obstacles[i];
            if (obstacle)
            {
                
            }
            else
            {
                Obstacle_creater.created_obstacles.Remove(obstacle);
            }
        }

        red_flame.SetActive(false);
        blue_flame.SetActive(true);
    }
}
