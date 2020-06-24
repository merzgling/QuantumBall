using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Pool column_pool;
    public static Pool roof_column_pool;
    public static Coin_pool coin_pool;
    public static Pool saw_pool;
    public static Pool rolling_saw_pool;
    public static Pool roof_saw_pool;

    public static int number_of_chalanges = 8;
    private static int number_of_baby_games = 15;

    protected static int number_of_played_games;
    public static int Number_of_played_games
    {
        get
        {
            return number_of_played_games;
        }
    }

    private static int high_score;
    private static int coins;

    public static void chalange_comleted(int chalange_index)
    {
        if (chalange_index < number_of_chalanges)
            PlayerPrefs.SetInt("chalange " + chalange_index.ToString(), 1);

    }

    public static bool is_chalange_comleted(int chalange_index)
    {
        if (PlayerPrefs.GetInt("chalange " + chalange_index.ToString()) == 1)
            return true;
        else
            return false;
    }

    public static bool baby_mode()
    {
        return number_of_played_games < number_of_baby_games;
    }

    public static int GetCoin()
    {
        return coins;
    }

    public static int GetHighScore()
    {
        return high_score;
    }


    public static void AddCoin()
    {
        AddCoin(1);      
    }

    public static void AddCoin(int x)
    {
        if (GameObject.Find("Player effects"))
        if (GameObject.Find("Player effects").GetComponent<Double_coins>())
            x += x;
        coins += x;
      
        if (PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.Save();
        }
    }

    public static void NewHighScore(int new_score)
    {
        if (new_score > high_score)
        {
            high_score = new_score;

            if (PlayerPrefs.HasKey("high score"))
            {
                PlayerPrefs.SetInt("high score", high_score);
            }
        }
    }

    public static void BurnHighScore()
    {
        PlayerPrefs.SetInt("high score", 0);
    }

    public static void GameStarts()
    {
        if (!PlayerPrefs.HasKey("played games"))
            PlayerPrefs.SetInt("played games", 0);

        if (Application.loadedLevel != 1)
        {
            column_pool = GameObject.Find("Physical columns pool").GetComponent<Pool>();
            roof_column_pool = GameObject.Find("Roof columns pool").GetComponent<Pool>();
            coin_pool = GameObject.Find("Coin pool").GetComponent<Coin_pool>();
            saw_pool = GameObject.Find("Saws pool").GetComponent<Pool>();
            rolling_saw_pool = GameObject.Find("Rolling saws pool").GetComponent<Pool>();
            roof_saw_pool = GameObject.Find("Roof saws pool").GetComponent<Pool>();

            PlayerPrefs.SetInt("played games", PlayerPrefs.GetInt("played games") + 1);
        }

        if (!PlayerPrefs.HasKey("coins"))
            PlayerPrefs.SetInt("coins", 0);
        coins = PlayerPrefs.GetInt("coins");

        if (!PlayerPrefs.HasKey("high score"))
            PlayerPrefs.SetInt("high score", 0);
        high_score = PlayerPrefs.GetInt("high score");

        number_of_played_games = PlayerPrefs.GetInt("played games");

       
    }
}
