using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_coin : MonoBehaviour
{
    private const float speed = 80f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
