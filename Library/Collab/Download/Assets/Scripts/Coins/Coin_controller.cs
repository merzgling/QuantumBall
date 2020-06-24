using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_controller : MonoBehaviour
{
    public Column_creater column_creater;
    public Coin_creater coin_creater;
    public Coin_deleter coin_deleter;

    public Coin_shape_creater coin_shape_creater;

    public GameObject ball;

    private Coin_shape coin_to_delete;
    private Coin_shape current_coin;
    private int position_to_create_coin;
    


    private const float deleting_range = 50f;

    private int new_position_to_create_coin()
    {
        int result = position_to_create_coin + Random.Range(50, 120);

        return result;
    }

    // Use this for initialization
    void Awake()
    {
        position_to_create_coin = 0;
        position_to_create_coin = new_position_to_create_coin();
    }

    // Update is called once per frame
    void Update()
    {
        if (position_to_create_coin == 0)
            position_to_create_coin = new_position_to_create_coin();

        int current_pos = column_creater.current_pos;

        //creating new coin
        if (current_pos > position_to_create_coin)
        {
            if (coin_creater.can_create(position_to_create_coin))
            {
                Coin_shape new_coin = coin_shape_creater.create(position_to_create_coin);
                if (current_coin)
                    current_coin.next_coin = new_coin;
                current_coin = new_coin;

                position_to_create_coin = new_position_to_create_coin();
            }
            else
                position_to_create_coin++;
        }

        //deleting coins
        if (coin_to_delete)
            if (ball.transform.position.x > coin_to_delete.x_pos + deleting_range)
            {
                if (coin_to_delete.next_coin)
                {
                    Coin_shape next_coin = coin_to_delete.next_coin;
                    coin_deleter.delete(coin_to_delete);
                    coin_to_delete = next_coin;
                }
            }
    }
}
