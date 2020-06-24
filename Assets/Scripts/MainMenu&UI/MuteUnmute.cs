using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteUnmute : MonoBehaviour {

    //Висит на камере главного меню
    private AudioSource source;
    public GameObject muted_picture;
    public GameObject unmuted_picture;
	void Awake ()
    {
        source = GameObject.Find("music").GetComponent<AudioSource>();
      
        if (PlayerPrefs.GetInt("muted") == 0)
        {
            muted_picture.SetActive(false);
            unmuted_picture.SetActive(true);
            source.mute = false;
        }
        if (PlayerPrefs.GetInt("muted") == 1)
        {
            muted_picture.SetActive(true);
            unmuted_picture.SetActive(false);
            source.mute = true;
        }

    }

    public void Mute()
    {
        PlayerPrefs.SetInt("muted", 1);
        muted_picture.SetActive(true);
        unmuted_picture.SetActive(false);
        //listener.enabled = false;
        source.mute = true;
    }
    public void Unmute()
    {
        PlayerPrefs.SetInt("muted", 0);
        muted_picture.SetActive(false);
        unmuted_picture.SetActive(true);
        //listener.enabled = true;
        source.mute = false;
    }
}
