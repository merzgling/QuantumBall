using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_deleter : MonoBehaviour
{
    public void delete(Obstacle obst)
    {
        Destroy(obst.gameObject);
    }
}
