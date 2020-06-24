using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_item : MonoBehaviour
{
    public bool moving;

    private void Start()
    {
        moving = false;
    }

    
    void FixedUpdate()
    {
        if (!moving)
            return;

        Rigidbody rd = gameObject.GetComponent<Rigidbody>();
        Vector3 speed = new Vector3(2, 0.5f);
        rd.MovePosition(rd.position + speed * Time.deltaTime);
    }

    void OnBecameVisible()
    {
        moving = true;
    }
}
