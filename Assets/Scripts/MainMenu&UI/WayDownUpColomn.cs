using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayDownUpColomn : MonoBehaviour {

    private bool way_up=false;
    private bool way_down=false;
    private float step = 0.15f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (way_up)
            {
                Vector3 pos = gameObject.transform.localPosition;
                pos.y = -5;               
                gameObject.transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, step);
                if (transform.position.y == pos.y)
                    way_down = false;
            }
        if(way_down)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y = -8;
            //float step = 0.1f;
            gameObject.transform.position = Vector3.MoveTowards(transform.position, pos, step);
            if (transform.position.y == pos.y)
                way_down = false;
        }
	}
    public void GoDown()
    {
        way_down = true;
        way_up = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void GoUp()
    {
        way_up = true;
        way_down = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
