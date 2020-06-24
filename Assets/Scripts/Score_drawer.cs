using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score_drawer : MonoBehaviour
{
    private Text score;
    public Character_controller character_controller;

    // Use this for initialization
    void Start()
    {
        score = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        score.text =  character_controller.score.ToString();
    }
}
