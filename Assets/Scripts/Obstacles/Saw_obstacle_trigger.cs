using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_obstacle_trigger : MonoBehaviour
{
    public GameObject object_to_destroy;

    void OnDestroy()
    {
        Destroy(object_to_destroy);
    }
}
