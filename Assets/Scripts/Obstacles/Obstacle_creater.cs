using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_creater : MonoBehaviour
{
    public Transform ball;
    public List <GameObject> Obstacle_templates;

    public Transform obstacles_parent;//object is parent for all obstacles

    public static List<GameObject> created_obstacles = new List<GameObject>();

    public Obstacle create(int start_x)
    {
        GameObject new_obstacle = Instantiate(Obstacle_templates[Random.Range(0, Obstacle_templates.Count)]);
        Obstacle obstacle_component = new_obstacle.GetComponent<Obstacle>();
        obstacle_component.x_pos = start_x;
        new_obstacle.transform.parent = obstacles_parent;

        //обработка частного случая с пилой
        if (obstacle_component.type == "saw")
        {
            Column column = GameObject.Find("column " + start_x).GetComponent<Column>();
            new_obstacle.transform.position = new Vector3(start_x, 3.8f);
            new_obstacle.transform.parent = column.column.transform;
            column.obstacled = true;
        }

        //обработка частного случая с пропостью
        if (obstacle_component.type == "deep")
        {
            new_obstacle.GetComponent<Deep_obstacle>().initialize(start_x);
        }

        //обработка частного случая с лезвием
        if (obstacle_component.type == "razer")
        {
            new_obstacle.GetComponent<Razer_obstacle>().initialize(start_x, ball);
        }

        //обработка частного случая с котящейся пилой
        if (obstacle_component.type == "rolling saw")
        {
            new_obstacle.transform.position = new Vector3(start_x, new_obstacle.transform.position.y);
        }

        //обработка частного случая с прыгающей пилой
        if (obstacle_component.type == "jumping saw")
        {
            //Column column = GameObject.Find("column " + start_x).GetComponent<Column>();// old sistem with allert
            //column.obstacled = true;       
            new_obstacle.transform.parent = obstacles_parent.transform;
            new_obstacle.transform.position = new Vector3(start_x, new_obstacle.transform.position.y);

            created_obstacles.Add(new_obstacle.transform.GetChild(0).gameObject);
        }

        if (obstacle_component.type == "roof saw")
        {
            int roof_pos = start_x;
            if (roof_pos % 2 == 0)
                roof_pos--;
            GameObject roof = GameObject.Find("roof column " + roof_pos);
            new_obstacle.transform.position = new Vector3(roof_pos + 0.5f, roof.transform.position.y - 10f);
        }

        created_obstacles.Add(new_obstacle);

        return new_obstacle.GetComponent<Obstacle>();
    }

    public Obstacle create(Obstacle need_obstacle)
    {
        GameObject new_obstacle = new GameObject();

        for (int i = 0; i < Obstacle_templates.Count; i++)
        {
            if (need_obstacle.type == Obstacle_templates[i].GetComponent<Obstacle>().type)
            {
                new_obstacle = Instantiate(Obstacle_templates[i]);
                break;
            }
        }


        int start_x = need_obstacle.x_pos;

        Obstacle obstacle_component = new_obstacle.GetComponent<Obstacle>();
        obstacle_component.x_pos = start_x;

        //обработка частного случая с пилой
        if (obstacle_component.type == "saw")
        {
            Column column = GameObject.Find("column " + start_x).GetComponent<Column>();
            new_obstacle.transform.position = new Vector3(start_x, 3.8f);
            new_obstacle.transform.parent = column.column.transform;
            column.obstacled = true;
        }

        if (obstacle_component.type == "roof saw")
        {
            int roof_pos = start_x;
            if (roof_pos % 2 == 0)
                roof_pos--;
            GameObject roof = GameObject.Find("roof column " + roof_pos);
            new_obstacle.transform.position = new Vector3(roof_pos + 0.5f, roof.transform.position.y - 10f);
        }

        //обработка частного случая с пропостью
        if (obstacle_component.type == "deep")
        {
            new_obstacle.GetComponent<Deep_obstacle>().initialize(start_x);
        }

        //обработка частного случая с лезвием
        if (obstacle_component.type == "razer")
        {
            new_obstacle.GetComponent<Razer_obstacle>().initialize(start_x, ball);
        }

        //обработка частного случая с котящейся пилой
        if (obstacle_component.type == "rolling saw")
        {
            new_obstacle.transform.position = new Vector3(start_x, new_obstacle.transform.position.y);
        }

        //обработка частного случая с прыгающей пилой
        if (obstacle_component.type == "jumping saw")
        {
            Column column = GameObject.Find("column " + start_x).GetComponent<Column>();
            new_obstacle.transform.position = new Vector3(start_x, new_obstacle.transform.position.y);
            new_obstacle.transform.parent = column.column.transform;
            column.obstacled = true;
        }

        return new_obstacle.GetComponent<Obstacle>();
    }
}
