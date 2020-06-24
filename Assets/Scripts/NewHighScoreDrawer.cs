using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewHighScoreDrawer : MonoBehaviour {

    private Text high_score_counter;

    // Use this for initialization
    void Start()
    {
        high_score_counter = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        high_score_counter.text = "New High Score " + Game.GetHighScore().ToString();
    }
}
