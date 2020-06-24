using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_creater : MonoBehaviour
{
    public GameObject coin_template;

    public Transform coins_parent;//object is parent for all coins

    public bool can_create(int starting_x)//return true if you can
    {
        Column column = GameObject.Find("column " + starting_x).GetComponent<Column>();
        if (!column.column)
            return false;

        if (column.obstacled)
            return false;

        return true;
    }

    public Coin create(int starting_x)
    {
        GameObject new_coin = Instantiate(coin_template);
        Coin coin_component = new_coin.GetComponent<Coin>();
       // coin_component.x_pos = starting_x;
        new_coin.transform.parent = coins_parent;

        if (Random.Range(0, 2) == 1)
        {
            //create ground coin

            new_coin.transform.position = new Vector3(starting_x, new_coin.transform.position.y);
            new_coin.AddComponent<Ground_coin>();
            Column column = GameObject.Find("column " + starting_x).GetComponent<Column>();
            new_coin.GetComponent<Ground_coin>().column = column.column.transform;
            new_coin.transform.parent = column.column.transform;
        }
        else
        {
            //create flying coin
            new_coin.transform.position = new Vector3(starting_x, new_coin.transform.position.y + 10);
            new_coin.AddComponent<Flying_coin>();
        }

        return coin_component;
    }
}
