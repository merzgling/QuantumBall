using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {
 
    public int scene_number;
    private GameObject complete_image;
    private void Start()
    {
        int challenge_number = scene_number - 3;
        complete_image = transform.GetChild(2).gameObject;
       
        if (PlayerPrefs.GetInt("chalange " + challenge_number.ToString()) == 1)
        {
            complete_image.SetActive(true);

        }
        else
            complete_image.SetActive(false);
    }
}
