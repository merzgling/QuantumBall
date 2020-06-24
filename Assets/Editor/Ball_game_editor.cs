using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Ball_game_editor : EditorWindow
{
    int high_score;
    int coins;
    int number_of_played_games;

    bool initialized = false;

    [MenuItem("Window/Ball game")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Ball_game_editor>();
    }

    void initialize()
    {
        if (!PlayerPrefs.HasKey("played games"))
            PlayerPrefs.SetInt("played games", 0);
        number_of_played_games = PlayerPrefs.GetInt("played games");

        if (!PlayerPrefs.HasKey("coins"))
            PlayerPrefs.SetInt("coins", 0);
        coins = PlayerPrefs.GetInt("coins");

        if (!PlayerPrefs.HasKey("high score"))
            PlayerPrefs.SetInt("high score", 0);
        high_score = PlayerPrefs.GetInt("high score");
        
    }

    void OnGUI()
    {
        initialize();

        EditorGUILayout.LabelField("High score", high_score.ToString());
        EditorGUILayout.LabelField("Coins", coins.ToString());
        EditorGUILayout.LabelField("Number of played games", number_of_played_games.ToString());

        EditorGUILayout.LabelField("Baby mode", Game.baby_mode().ToString());

        for (int i = 0; i < Game.number_of_chalanges; i++)
        {
            EditorGUILayout.LabelField("chalange " + i.ToString(), PlayerPrefs.GetInt("chalange " + i.ToString()).ToString());
        }

        if (GUILayout.Button("burn played games"))
        {
            PlayerPrefs.SetInt("played games", 0);
            for (int i = 0; i < Game.number_of_chalanges; i++)
            {
                PlayerPrefs.SetInt("chalange " + i.ToString(), 0);
            }
        }
    }
}
