using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public Coin next_coin;
    //public Coin pre_coin;
    //public int x_pos;

    //public Pool coin_pool;

    //protected bool was_magnituded;

    //Transform player;
    //GameObject ball;
    //Character_controller character_controller;
    //GameObject player_effects;

    //Rigidbody rd;

    //static Vector3 coin_image_position = new Vector3(70, Screen.height - 50, 0);
    //public static int delta_coins;

    //const float magnet_range = 35;
    //const float deleting_range = 35;

    //void Start()
    //{
    //    player = GameObject.Find("ball").transform;
    //    ball = GameObject.Find("ball");
    //    character_controller = ball.GetComponent<Character_controller>();
    //    player_effects = GameObject.Find("Player effects");
    //    rd = gameObject.GetComponent<Rigidbody>();
    //    was_magnituded = false;

    //    coin_pool = GameObject.Find("Coin pool").GetComponent<Coin_pool>();
    //}

    //void Update()
    //{
    //    if (ball.transform.position.x > transform.position.x + deleting_range)
    //    {
    //        coin_pool.push(gameObject);
    //    }
    //}

    //void FixedUpdate()
    //{
    //    if (!Character_controller.GameOvered)
    //    {
    //        if (player_effects.GetComponent<Magnet_boost>())
    //        {
    //            float speed = 8.3f;

    //            if (Character_controller.is_rocket_boost_active())
    //                speed *= 2f;

    //            Vector3 delta = player.position - new Vector3(transform.position.x, transform.position.y);
    //            if (delta.magnitude < magnet_range)
    //            {
    //                was_magnituded = true;
    //                if (delta.magnitude < magnet_range * 0.4f)
    //                    speed = (0.6f * magnet_range * speed) / Mathf.Max(delta.magnitude, 1);
    //                //if (delta.magnitude > magnet_range * 0.8f)
    //                //    speed = speed * (delta.magnitude/magnet_range);

    //                delta.Normalize();

    //                rd.MovePosition(transform.position + delta * speed * Time.deltaTime);

    //            }
    //        }
    //        else
    //            was_magnituded = false;
    //    }
    //    else
    //    {
    //        if (was_magnituded)
    //        {
    //            deleting();
    //        }
    //    }

    //}

    //public void deleting(float speed = 25f)
    //{
    //    delta_coins++;
    //    if (pre_coin)
    //        pre_coin.next_coin = next_coin;
    //    gameObject.tag = "Untagged";
    //    gameObject.AddComponent<Move_to_UI_position>();
    //    Move_to_UI_position m = gameObject.GetComponent<Move_to_UI_position>();
    //    m.UI_position = coin_image_position;
    //    m.speed = speed;
    //    transform.parent = null;
    //    Destroy(this);
    //}
}
