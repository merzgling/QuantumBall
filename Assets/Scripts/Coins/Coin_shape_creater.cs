using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_shape_creater : MonoBehaviour
{
    //public GameObject[] coin_template;
    public int number_of_shapes;

    private Coin_pool coin_pool;
    private Transform coin_parent;

    void Start()
    {
        coin_parent = GameObject.Find("Coins").transform;
        coin_pool = GameObject.Find("Coin pool").GetComponent<Coin_pool>();
        number_of_shapes = coin_pool.number_of_shapes;
    }

    public Coin_shape create(int starting_x)
    {
        GameObject new_coin_shape = coin_pool.get(Random.Range(0, number_of_shapes));
        
        new_coin_shape.transform.parent = coin_parent;

        Coin_shape coin_shape_component = new_coin_shape.GetComponent<Coin_shape>();
        coin_shape_component.x_pos = starting_x;

        new_coin_shape.transform.position = new Vector3(starting_x, new_coin_shape.transform.position.y);

        return coin_shape_component;
    }
}
