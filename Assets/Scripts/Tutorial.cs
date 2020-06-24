using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public UnityEngine.UI.Button bar_open;
    public GameObject finger;
	void Start ()
    {
        //int item_amount = 1;
        int cur_am=0;
         //PlayerPrefs.SetInt("Shield" + "amount", item_amount);
        cur_am = PlayerPrefs.GetInt("Rocket" + "amount");
        PlayerPrefs.SetInt("Rocket" + "amount", cur_am + 2);
        cur_am = PlayerPrefs.GetInt("Shield" + "amount");
        PlayerPrefs.SetInt("Shield" + "amount", cur_am + 3);
        cur_am = PlayerPrefs.GetInt("Magnet" + "amount");
        PlayerPrefs.SetInt("Magnet" + "amount", cur_am + 2);
        cur_am = PlayerPrefs.GetInt("DoubleCoin" + "amount");
        PlayerPrefs.SetInt("DoubleCoin" + "amount", cur_am + 2);
        cur_am = PlayerPrefs.GetInt("Timer" + "amount");
        PlayerPrefs.SetInt("Timer" + "amount", cur_am + 2);
        bar_open.onClick.Invoke();
        finger.SetActive(false);

    }

    // Update is called once per frame
    public void TutComplet()
    {
        PlayerPrefs.SetInt("tutorialed", 1);
    }
}
