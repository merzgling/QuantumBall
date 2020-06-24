using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_to_UI_position : MonoBehaviour
{
    //public Pool coin_pool;
    //public Vector3 UI_position;
    //public float speed;


    //const float deleting_range = 0.7f;
    //Rigidbody rd;
    //Camera cam;

    //private void Start()
    //{
    //    cam = Camera.main;
    //    rd = gameObject.GetComponent<Rigidbody>();
    //    coin_pool = GameObject.Find("Coin pool").GetComponent<Pool>();
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    Vector3 position_to_go = new Vector3(0, 0);

    //    Ray ray = cam.ScreenPointToRay(UI_position);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 100))
    //    {
    //        position_to_go = hit.point;
    //    }

    //    Vector3 delta = position_to_go - transform.position;

    //    if (delta.magnitude < deleting_range)
    //    {
    //        Coin.delta_coins--;
    //        Game.AddCoin();
    //        coin_pool.push(gameObject);
    //        Destroy(this);
    //    }

    //    delta.Normalize();

    //    rd.MovePosition(transform.position + delta * speed * Time.deltaTime);
    //}
}
