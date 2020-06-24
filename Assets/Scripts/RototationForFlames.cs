using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RototationForFlames : MonoBehaviour {

	//Висит на RocketFlames, префаб для огня ракеты рокеты
    private Transform ball;
    private float y_rot=0;
	void Start ()
    {
        ball = gameObject.GetComponentInParent<Transform>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        y_rot += Time.deltaTime * 100;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,0f));	
	}
}
