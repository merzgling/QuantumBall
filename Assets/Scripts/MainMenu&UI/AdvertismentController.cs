using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertismentController : MonoBehaviour {
    public GameObject ads_button;
    private Character_controller char_controller;
    private void Awake()
    {
        if (ads_button != null)//значит находимся на главной сцене
        {
            char_controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();          
            if (Random.Range(1, 5) == 1)
                ads_button.SetActive(true);
            else
                ads_button.SetActive(false);
        }
    }
    void Start()
    {
        if(ads_button!=null)
        {
            if (char_controller.score < 1)
                ads_button.SetActive(false);
        }
       
    }
    public void ShowAds()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
            int coins = PlayerPrefs.GetInt("coins");
            coins += 300;
            PlayerPrefs.SetInt("coins", coins);
            Game.GameStarts();          
            
        }
    }
    public void ShowAdsOnMainScene()
    {
        //if (char_controller.score > 200)
        //{
            if (Advertisement.IsReady("rewardedVideo"))
            {
                Advertisement.Show("rewardedVideo");
                int coins = PlayerPrefs.GetInt("coins");
                coins += 230;
                PlayerPrefs.SetInt("coins", coins);
                Game.GameStarts();

            }
        //}
        //else
        //    ads_button.SetActive(false);
    }
}
