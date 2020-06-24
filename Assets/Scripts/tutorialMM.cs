using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialMM : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        if (PlayerPrefs.GetInt("tutorialed") == 1)
            gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
