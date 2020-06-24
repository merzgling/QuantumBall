using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;


public class BarAnimationRun : MonoBehaviour {

	// висит на родительском бар объекте
   
    private bool bar_opened=false;
    
    public GameObject cam;
    public Animator anim;
    public GameObject fader;

    //}
    void Awake()
    {
        fader = gameObject.transform.parent.GetChild(0).gameObject;
    }
    public void RunAnim()
    {
        if (!bar_opened)
        {
            bar_opened = true;
            anim.SetBool("isOpened", true);
            Time_scale_controller.Bag_time_shift(true);
            //cam.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;
            //cam.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = true;
            fader.SetActive(true);
        }
        else
        {
            bar_opened = false;
            anim.SetBool("isOpened", false);
            Time_scale_controller.Bag_time_shift(false);
            //cam.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = false;
            //cam.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = false;
            fader.SetActive(false);
        }
    }
}
