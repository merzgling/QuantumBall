using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTheReal : MonoBehaviour {

    public Transform ball;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = ball.position;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")//------------------------------------------------------------------------------------------------------------------------------------------
        {
           // Game.AddCoin();
            StartCoroutine(MoveCoinToBall(other.transform));
            //other.tag = "Untagged";
        }
    }
    IEnumerator MoveCoinToBall(Transform coin_transform)//движение монетки
    {
        Vector3 normalizeDirection;
        float speed = 1f;

        while (((ball.position - coin_transform.position).magnitude > 0.5f)&&(coin_transform.tag == "coin"))
        {
            normalizeDirection = (ball.position - coin_transform.position).normalized;
            coin_transform.position += normalizeDirection * speed; //обычное движение в точку в нормальных координатах
            yield return 0.07f;
        }
        
        
    }
}
