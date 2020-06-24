using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_creater : MonoBehaviour
{
    public GameObject floor_template;
    public Transform floors_parent;//object is parent for all floors
    private GameObject previos_go; //предыдущая труба, чтобы сохранялся поворот.Kizor   

    public Floor first_floor;
    public Floor current_floor;

    public Floor create(float starting_x)
    {
        GameObject new_floor = Instantiate(floor_template);
        if (previos_go == null) //Kizor
            previos_go = new_floor.transform.GetChild(1).gameObject;
        else
        {
            new_floor.transform.GetChild(1).rotation = previos_go.transform.rotation;
            previos_go = new_floor.transform.GetChild(1).gameObject;
        } 


        Floor floor_component = new_floor.GetComponent<Floor>();
        floor_component.x_pos = starting_x;

        if (current_floor)
        {
            current_floor.next_floor = floor_component;
            current_floor = floor_component;
        }
        else
            current_floor = floor_component;

        if (first_floor == null)
            first_floor = current_floor;

        new_floor.transform.position = new Vector3(starting_x, new_floor.transform.position.y, new_floor.transform.position.z);
        new_floor.transform.parent = floors_parent;

        return floor_component;
    }
}
