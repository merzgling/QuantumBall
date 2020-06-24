using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTimerAnim : MonoBehaviour {

    public float life_time=10f;
    private float time = 0f;
    private UnityEngine.UI.Image image;
	void Start () 
    {
        image = gameObject.GetComponent<UnityEngine.UI.Image>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
       
        if (time < life_time)
        {
            image.fillAmount = (life_time - time) / life_time;

            
        }
        else
        {
            Destroy(gameObject);
            RunBoostScript.RemoveFromList(gameObject);
        }
            
	}
}
