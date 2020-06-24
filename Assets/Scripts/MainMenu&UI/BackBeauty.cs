using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBeauty : MonoBehaviour {
    //moving hexagons on the background floor
    private float time = 0;
    private Vector3 pos;
    public float step_x = 1.79f, step_y_long = 2.08f, step_y_short = 1.03f; 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time +=Time.deltaTime;

        if (time > 0.2f)
        {
            
            time = 0;
            int t = Random.Range(1, 7);
            if (t == 1)
                WayX1();
            if (t == 2)
                WayX2();
            if (t == 3)
                WayX3();
            if (t == 4)
                WayX4();
            if (t == 5)
                WayY1();
            if (t == 6)
                WayY2();
        }
	}
    private void WayX1()
    {
        pos = gameObject.transform.localPosition;
        pos.x += step_x;
        pos.y += step_y_short;
      //  if(pos.y>-14f)
        gameObject.transform.localPosition = pos;
    }
    private void WayX2()
    {
        pos = gameObject.transform.localPosition;
        pos.x += step_x;
        pos.y -= step_y_short;
      //  if (pos.y > -14f)
        gameObject.transform.localPosition = pos;
    }
    private void WayX3()
    {
        pos = gameObject.transform.localPosition;
        pos.x -= step_x;
        pos.y -= step_y_short;
       // if (pos.y > -14f)
        gameObject.transform.localPosition = pos;
    }
    private void WayX4()
    {
        pos = gameObject.transform.localPosition;
        pos.x -= step_x;
        pos.y += step_y_short;
     //   if (pos.y > -14f)
        gameObject.transform.localPosition = pos;
    }
    private void WayY1()
    {
        pos = gameObject.transform.localPosition;
        pos.y += step_y_long;
       // if (pos.y < -14f)
        gameObject.transform.localPosition = pos;
    }
    private void WayY2()
    {
        pos = gameObject.transform.localPosition;
        pos.y -= step_y_long;
      //  if (pos.y > -14f)
        gameObject.transform.localPosition = pos;
    }
}
