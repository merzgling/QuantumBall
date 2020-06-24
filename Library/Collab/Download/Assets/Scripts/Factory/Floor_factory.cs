using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_factory : Factory
{
    private Transform column_parent;
    private Transform physical_columns_parent;

    private Column current_column;

    protected override void OnStart()
    {
        column_parent = GameObject.Find("Columns").transform;
        physical_columns_parent = GameObject.Find("Physical columns").transform;
    }

    protected override GameObject OnCreate(int x_pos, GameObject template)
    {
        GameObject new_column = new GameObject();
        GameObject physical_column = Instantiate<GameObject>(template);

        new_column.name = "column " + x_pos;
        new_column.transform.parent = column_parent;

        physical_column.transform.tag = "column";
        physical_column.name = "physical column " + x_pos;
        physical_column.transform.position = new Vector3(x_pos, 0);
        physical_column.transform.parent = physical_columns_parent;

        Column column_component = new_column.AddComponent<Column>();

        column_component.obstacled = false;
        column_component.column = physical_column;
        column_component.number = x_pos;
        column_component.next_column = null;
        column_component.pre_column = null;

        if (current_column)
        {
            current_column.next_column = column_component;
            column_component.pre_column = current_column;
        }

        current_column = column_component;

        return physical_column;
    }

    protected override void OnDelete(GameObject deleting_object)
    {
        deleting_object.AddComponent<Living_bomb>();
    }
}
