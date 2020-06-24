using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_coin : MonoBehaviour
{
    public Transform column;

    private float time;
    private float starting_x;
    private float starting_y;

    private const float delta_heigth = 0.8f;
    private const float speed = 2.5f;

    private void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        transform.position = new Vector3(column.position.x, column.position.y + 6.3f + delta_heigth * Mathf.Cos(time * speed));
    }
}
