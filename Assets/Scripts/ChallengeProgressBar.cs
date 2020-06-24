using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChallengeProgressBar : MonoBehaviour
{
    private Slider slider;
    public float score_to_finish;
    public Character_controller character_controller;
    public bool infinite_moving=false;

    // Use this for initialization
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        float a= character_controller.score;
        if (!infinite_moving)
            slider.value = a / score_to_finish;
        else
        {
            slider.value += (1 - slider.value) / 5000;
        }
        
    }
    
        
}