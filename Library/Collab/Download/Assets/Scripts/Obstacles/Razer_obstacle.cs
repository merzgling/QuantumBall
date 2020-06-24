using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer_obstacle : MonoBehaviour
{
    public GameObject razer_allert;
    public bool activate;

    private const float activation_rate = 1.1f;
    private float timer;

    public void initialize(int starting_x, Transform ball)
    {
        transform.position = new Vector3(starting_x, transform.position.y);
        razer_allert.GetComponent<Razer_allert>().ball = ball;
        Column column = GameObject.Find("column " + starting_x).GetComponent<Column>();
        razer_allert.transform.parent = column.column.transform;
        column.obstacled = true;
    }

    // Use this for initialization
    void Start()
    {
        activate = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
            timer += Time.deltaTime;

        if (transform.localEulerAngles.z >= 90 && transform.localEulerAngles.z <= 180)
        {
            if (razer_allert)
                Destroy(razer_allert);
            Destroy(gameObject);
        }

        if (timer >= activation_rate)
        {
            if (razer_allert)
                Destroy(razer_allert);
            transform.Rotate(new Vector3(0, 0, -200) * Time.deltaTime);
            
        }
       
       
    }
}
