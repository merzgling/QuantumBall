using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {

    public GameObject pause_panel;
    public GameObject dead_menu;
    public GameObject head_parent;
    private Application_controller app;
	void Start ()
    {
        app = gameObject.GetComponent<Application_controller>();
	}
	void Update () 
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (((pause_panel.activeInHierarchy) || (dead_menu.activeInHierarchy)))
            {
                app.Load(1);
                app.Pause(false);
            }
            else
            {
                app.Pause(pause_panel);
                head_parent.SetActive(false);
                head_parent.SetActive(true);
            }
        }
               
	}

       
}
