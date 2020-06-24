using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_deleter : MonoBehaviour
{
    public void delete(Floor floor)
    {
        Destroy(floor.gameObject);
    }
}
