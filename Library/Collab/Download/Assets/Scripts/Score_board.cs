using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_board : MonoBehaviour
{
    public Character_controller character_controller;
    public int current_score;
    public Text text;

    private float starting_heigth;
    private const float step = 700;

    // Use this for initialization
    void Start()
    {
        starting_heigth = transform.position.y;
        current_score = 0;
    }

    private void Update()
    {
        if (current_score != character_controller.score)
        {
            current_score = character_controller.score;
            text.text = "Your score : " + current_score.ToString();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody rd = gameObject.GetComponent<Rigidbody>();
        Vector3 speed = new Vector3(2, 0.5f);
        rd.MovePosition(rd.position + speed * Time.deltaTime);
    }    

    void OnBecameInvisible()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + step, starting_heigth, gameObject.transform.position.z);
    }
}
