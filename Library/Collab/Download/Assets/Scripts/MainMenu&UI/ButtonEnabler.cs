using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnabler : MonoBehaviour {

    public UnityEngine.UI.Button but;
    public UnityEngine.UI.Text text;
    public GameObject[] other_but;
    public GameObject particles;
    public int my_number;
    public static int cur_number=0;

    public bool way_up = false;
    public bool way_down = false;
	void Start ()
    {
  
	}
	
	// Update is called once per frame
	void Update ()
    {
  
	}
    void OnTriggerEnter(Collider coll)
    {
        but.enabled = true;
        Color col = text.color;
        col.a = 1f;
        text.color = col;
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<UnityEngine.UI.Outline>().enabled = true;
        DisableOthers();
        particles.SetActive(true);
        //way_up = true;
       
    }
    private void DisableOthers()
    {
        for (int i = 0; i < other_but.Length; i++)
        {
            other_but[i].GetComponent<UnityEngine.UI.Button>().enabled = false;
            Color col = other_but[i].GetComponent<UnityEngine.UI.Text>().color;
            col.a = 0.8f;
            other_but[i].GetComponent<UnityEngine.UI.Text>().color = col;
            other_but[i].GetComponent<Animator>().enabled = false;
            other_but[i].GetComponent<ButtonEnabler>().particles.SetActive(false);
            other_but[i].GetComponent<UnityEngine.UI.Outline>().enabled = false;
            other_but[i].transform.localScale=new Vector3(0.8f,0.8f,1);
           
        }
    }
  

}
