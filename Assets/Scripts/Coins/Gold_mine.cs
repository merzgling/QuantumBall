using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_mine : MonoBehaviour
{
    public int starting_position;
    public int length;


    public int height;
    public int starting_height;

    public GameObject coin_template;

    // Use this for initialization
    void Awake()
    {

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if ((i + Mathf.Abs(((height + 1) / 2) - j)) % 6 >= 3)
                {
                    GameObject new_coin = Instantiate(coin_template);
                    new_coin.transform.position = new Vector3(i + starting_position, j + starting_height);
                }
            }
        }
    }
}
