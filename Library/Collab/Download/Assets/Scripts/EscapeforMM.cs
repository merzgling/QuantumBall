using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeforMM : MonoBehaviour {

    public GameObject shop_parent;
    public GameObject roulet_shop;
    public GameObject custom_shop;
    public GameObject main_parent;
    public GameObject challenge_parent;
    public GameObject head_parent;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {        
            if(challenge_parent.activeInHierarchy)
                challenge_parent.transform.Find("BackButton").gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            if (shop_parent.activeInHierarchy)
                shop_parent.transform.Find("BackButton").gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            if (roulet_shop.activeInHierarchy)
                roulet_shop.transform.Find("BackButton").gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            if (custom_shop.activeInHierarchy)
                custom_shop.transform.Find("BackButton").gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            head_parent.SetActive(false);
            head_parent.SetActive(true);
            if (main_parent.activeInHierarchy)
            {
                gameObject.GetComponent<Application_controller>().CloseApplication();
            }

        }

    }
}
