using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_be_conected_with : MonoBehaviour
{
    public Transform target;
    public Vector3 delta;

    // Update is called once per frame
    void Update()
    {
        if (target)
            transform.position = target.position + delta;
        else
            Destroy(gameObject);
    }
}
