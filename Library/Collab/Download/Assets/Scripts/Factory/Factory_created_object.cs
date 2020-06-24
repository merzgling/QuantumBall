using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_created_object : MonoBehaviour
{
    public int x_position;
    public Factory_created_object next_object;
    public Factory_created_object previos_object;

    protected void OnDestoy()
    {
        if (previos_object)
        {
            previos_object.next_object = next_object;
        }
        if (next_object)
        {
            next_object.previos_object = previos_object;
        }
    }
}
