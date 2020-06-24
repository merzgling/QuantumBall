using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_deleter : MonoBehaviour
{
    public void delete(Coin_shape coin)
    {
        Destroy(coin.gameObject);
    }
}
