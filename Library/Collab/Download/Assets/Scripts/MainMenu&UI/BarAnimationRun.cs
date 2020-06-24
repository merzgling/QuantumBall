using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;


public class BarAnimationRun : MonoBehaviour {

	// висит на родительском бар объекте
    public Animation anim;
    private bool bar_opened=false;
    private float cur_time_scale=1f;
    public GameObject cam;
	void Start () 
    {
        	
	}
	

	void Update () {
		
	}
    public void RunAnim() //запускаем выдвиг рюкзака, блюрим экран
    {
        if (!bar_opened)
        {
            anim.CrossFade("BarAnim");         
            bar_opened = true;
            //--------------работа со временем
            Time_scale_controller.Bag_time_shift(true);
            //Debug.Log(Time.timeScale);
            foreach (AnimationState state in anim)
            {
                state.speed = 10f;// скорость анимации
            }
            cam.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;
            cam.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = true;
        }
        else
        {
            anim.CrossFade("BarAnimBack");
            bar_opened = false;
            //--------------работа со временем
            Time_scale_controller.Bag_time_shift(false);
            foreach (AnimationState state in anim)
            {
                state.speed = 1f;
            }
            cam.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = false;
            cam.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = false;
        }
        
    }
}
