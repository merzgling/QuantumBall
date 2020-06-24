using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deep_obstacle : MonoBehaviour
{
    public void initialize(int x)
    {
        Column column = GameObject.Find("column " + x).GetComponent<Column>();
        for (int i = 0; i < 4; i++)
        {
            Destroy(column.column);
            column = column.pre_column;
        }
    }
}
