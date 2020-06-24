using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_to_gameobject_position : MonoBehaviour
{
    public Transform target;
    public float speed;

    const float deleting_range = 0.7f;
    //Rigidbody rd;

    private void Start()
    {
       // rd = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject);
    }
    //Kizor убрал засасывание, т.к. в динамике и без него смотрится хорошо, а с ним бывают косяки, ну и подразгрузил апдейт


    //void FixedUpdate()
    //{
    //    //Vector3 position_to_go = target.position;

    //    //Vector3 delta = position_to_go - transform.position;

    //    //if (delta.magnitude < deleting_range)
    //    //{
    //    //    Destroy(gameObject);
    //    //}

    //    //delta.Normalize();
    //    //if (rd)
    //    //    rd.MovePosition(transform.position + delta * speed * Time.deltaTime);
    //    transform.position = target.position;
    //}
}
