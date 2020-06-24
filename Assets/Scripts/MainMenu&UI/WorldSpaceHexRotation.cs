using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceHexRotation : MonoBehaviour {
    //висит на шапках, поворачивает их лицом на камеру
    public GameObject parent;
    private float y;
    private Vector3 start_rot;
    private RectTransform rectTransform;
    private RectTransform my_rectTransform;
   


    void Start ()
    {
       
        rectTransform = parent.GetComponent<RectTransform>();
        my_rectTransform = gameObject.GetComponent<RectTransform>();
        start_rot = my_rectTransform.eulerAngles;
   
    }
	

	void Update ()
    {
        y = rectTransform.eulerAngles.y;

     
        transform.eulerAngles = new Vector3(90, -y/2, -y/2);

    }
}
