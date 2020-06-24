using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_controller : MonoBehaviour
{
    public Obstacle_creater obstacle_creater;
    public Obstacle_deleter obstacle_deleter;
    public Column_creater column_creater;

    public GameObject ball;

    public int limited;
    public Obstacle[] challange_obstacles;
    private int current_challange_obstacle;

    private Obstacle obstacle_to_delete;
    private Obstacle current_obstacle;
    private int position_to_create_obstacle;

    private int deleting_range = 50;

    private const int INF = 100000000;

    //в начале на моей стороне был только бог, теперь и его нет

    private void Start()
    {
        if (limited > 0)
        {
            position_to_create_obstacle = challange_obstacles[0].x_pos;
            current_challange_obstacle = 0;
        }
        else
            position_to_create_obstacle = 55;
    }

    private int new_position_to_create_obstacle()
    {
        if (limited > 0)
        {
            if (current_challange_obstacle < limited - 1)
            {
                current_challange_obstacle++;
                return challange_obstacles[current_challange_obstacle].x_pos;
            }
            else
                return INF;
        }
        else
            //if (Game.baby_mode())
            return position_to_create_obstacle + Random.Range(20, 45);
        //else
            //return position_to_create_obstacle + Random.Range(10, 25);
    }

    // Update is called once per frame
    void Update()
    {
        int current_pos = column_creater.current_pos;

        //creating new obstacles
        while (current_pos > position_to_create_obstacle)
        {
            Obstacle new_obstacle = new Obstacle();
            if (limited > 0)
            {
                new_obstacle = obstacle_creater.create(challange_obstacles[current_challange_obstacle]);
            }
            else
                new_obstacle = obstacle_creater.create(position_to_create_obstacle);


            if (current_obstacle)
                current_obstacle.next_obstacle = new_obstacle;
            current_obstacle = new_obstacle;
            position_to_create_obstacle = new_position_to_create_obstacle();
        }

        //deleting obstacles
        if (obstacle_to_delete)
            if (ball.transform.position.x > obstacle_to_delete.x_pos + deleting_range)
            {
                if (obstacle_to_delete.next_obstacle)
                {
                    Obstacle next_obstacle = obstacle_to_delete.next_obstacle;
                    obstacle_deleter.delete(obstacle_to_delete);
                    obstacle_to_delete = next_obstacle;
                }
            }
    }
}
