using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {
	// Висит на ShopParent
    public GameObject[] mini_faders;
    public GameObject[] frames;
    public GameObject[] text_obj; 
    public GameObject root_option; //кнопка запуска рандомного гифта
    public GameObject extra_money_obj;
    private UnityEngine.UI.Text[] boost_amount = new UnityEngine.UI.Text[5];
    private UnityEngine.UI.Button extra_money_button;
    private UnityEngine.UI.Button root_option_button;
    private UnityEngine.UI.Image[] frame_colors = new UnityEngine.UI.Image[6];
    private UnityEngine.UI.Image[] fader_colors = new UnityEngine.UI.Image[6];
    public Color disabled_color;
    public Color enabled_color;
    public Color frame_color_enabled;
    public Color frame_color_disabled;
    private int coins;
    private int item_amount;
    private int boost_index;
    private int new_amount;
	void Awake () 
    {
        
        if (root_option != null)
        {
            root_option_button = root_option.GetComponent<UnityEngine.UI.Button>();
        }
        if (extra_money_obj != null)
        {
            extra_money_button = extra_money_obj.GetComponent<UnityEngine.UI.Button>();
        }
        for (int i = 0; i < 6; i++)
        {
            if (mini_faders[i] != null)
            {
                fader_colors[i] = mini_faders[i].GetComponent<UnityEngine.UI.Image>();
                frame_colors[i] = frames[i].GetComponent<UnityEngine.UI.Image>();
            }
        }
        for (int i = 0; i < 5; i++)
        {
            boost_amount[i] = text_obj[i].GetComponent<UnityEngine.UI.Text>();
        }
        AmountCheck();
        
    }


    public void BuyItem(string item_name)
    {
        coins = PlayerPrefs.GetInt("coins");
        switch (item_name)
        {
            case "Rocket":
                 item_amount = PlayerPrefs.GetInt(item_name + "amount")+1;
                PlayerPrefs.SetInt(item_name+ "amount", item_amount);
                if (coins >= 160)
                {
                    coins -= 160;
                    UpdateMoney();
                //    boost_amount[0].text = "x" + item_amount.ToString();
                //    boost_index = 0;
                //    new_amount = item_amount;
                }
                break;
            case "Shield":
                item_amount = PlayerPrefs.GetInt(item_name + "amount") + 1;
                PlayerPrefs.SetInt(item_name + "amount", item_amount);
                if (coins >= 160)
                {
                    coins -= 160;
                    UpdateMoney();
                    //boost_amount[1].text = "x" + item_amount.ToString();
                    //boost_index = 1;
                    //new_amount = item_amount;
                }
                break;
            case "DoubleCoin":
                item_amount = PlayerPrefs.GetInt(item_name + "amount") + 1;
                PlayerPrefs.SetInt(item_name + "amount", item_amount);
                if (coins >= 160)
                {
                    coins -= 160;
                    UpdateMoney();
                    //boost_amount[2].text = "x" + item_amount.ToString();
                    //boost_index = 2;
                    //new_amount = item_amount;
                }
                break;
            case "Magnet":
                item_amount = PlayerPrefs.GetInt(item_name + "amount") + 1;
                PlayerPrefs.SetInt(item_name + "amount", item_amount);
                if (coins >= 160)
                {
                    coins -= 160;
                    UpdateMoney();
                    //boost_amount[3].text = "x" + item_amount.ToString();
                    //boost_index = 3;
                    //new_amount = item_amount;
                }
                break;
            case "Timer":
                item_amount = PlayerPrefs.GetInt(item_name + "amount") + 1;
                PlayerPrefs.SetInt(item_name + "amount", item_amount);
                if (coins >= 160)
                {
                    coins -= 160;
                    UpdateMoney();
                    //boost_amount[4].text = "x" + item_amount.ToString();
                    //boost_index = 4;
                    //new_amount = item_amount;
                    //boost_amount
                }
                break;
            default:
                break;

        }
    }
    private void AmountCheck()
    {
        boost_amount[0].text = "x" + PlayerPrefs.GetInt("Rocket" + "amount").ToString();
        boost_amount[1].text = "x" + PlayerPrefs.GetInt("Shield" + "amount").ToString();
        boost_amount[2].text = "x" + PlayerPrefs.GetInt("DoubleCoin" + "amount").ToString();
        boost_amount[3].text = "x" + PlayerPrefs.GetInt("Magnet" + "amount").ToString();
        boost_amount[4].text = "x" + PlayerPrefs.GetInt("Timer" + "amount").ToString();
    }
    public void MoneyCheat()
    {
        coins = PlayerPrefs.GetInt("coins");
        coins += 80000;
        PlayerPrefs.SetInt("coins", coins);
        Game.GameStarts();
    }
    private void UpdateMoney()
    {
        PlayerPrefs.SetInt("coins", coins);
        Game.GameStarts();
    }
    public void RandomGift()
    {
        extra_money_button.enabled = false;
        extra_money_obj.GetComponent<Animator>().enabled = false;
        coins = PlayerPrefs.GetInt("coins");
        if (coins >= 160)
        {
            int r = Random.Range(0, 6);
            root_option_button.enabled = false;
            StartCoroutine(WaitingRandomChoice(r));
            switch (r)
            {
                case 0:
                    BuyItem("DoubleCoin");
                    break;
                case 1:
                    BuyItem("Shield");
                    break;
                case 2:
                    BuyItem("Rocket");
                    break;
                case 3:
                    BuyItem("Magnet");
                    break;
                case 4:
                    BuyItem("Timer");
                    break;
                case 5:
                    Invoke("AnimEnable", 4f);
                    
                    break;
                default:
                    break;
            }
        }

    }
    private void AnimEnable()
    {
        extra_money_button.enabled = true;
        extra_money_obj.GetComponent<Animator>().enabled = true;
    }
    IEnumerator WaitingRandomChoice(int r)
    {
        int k;
        float a = 0.0000001f;
        for (int i = 0; i < 36+r; i++)
        {
            k = i % 6;
            fader_colors[k].color = enabled_color;
            frame_colors[k].color = frame_color_enabled;
            if (k == 0)
            {
                fader_colors[5].color = disabled_color;
                frame_colors[5].color = frame_color_disabled;
            }

            else
            {
                fader_colors[k - 1].color = disabled_color;
                frame_colors[k - 1].color = frame_color_disabled;
            }
            yield return new WaitForSeconds(0.05f+a*i*i*i*i);
        }
        root_option_button.enabled = true;
        AmountCheck();
    }
}
