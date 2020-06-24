using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBar : MonoBehaviour {
    //висит на кнопке с бустом
    public string boost_name;
  
    public GameObject text_object;
    private UnityEngine.UI.Text amount;
    private int num;
	
	void Start ()
    {
        amount = text_object.GetComponent<UnityEngine.UI.Text>();
      //  PlayerPrefs.SetInt(boost_name + "amount", 99);
        AmountUpdate();
    }
	
    
    public void AmountUpdate() //обновляем число бустов
    {
        amount.text = "X" + PlayerPrefs.GetInt(boost_name + "amount").ToString();
    }
}
