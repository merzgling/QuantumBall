using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Coins_drawer : MonoBehaviour
{
    private Text coin_counter;

    // Use this for initialization
    void Start()
    {
        coin_counter = gameObject.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        coin_counter.text = Game.GetCoin().ToString();
       
    }
  
}
