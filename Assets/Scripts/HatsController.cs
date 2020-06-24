using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatsController : MonoBehaviour {
    private List<Transform> hats;
    private int choosen_hat;
    private int real_choosen_hat;
    public Transform ball;
    public Gradient rainbow_color;
    public Gradient color1;//gladiator color
    private Transform current_hat;
    private Vector3 deltaz;
    private bool hat_launched = false;
    void Awake ()
    {
        hats = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var hat = transform.GetChild(i);
            hats.Add(hat);
        }
        

       // choosen_hat = PlayerPrefs.GetInt("Current Hat");
        real_choosen_hat= PlayerPrefs.GetInt("Current Hat");
        if (real_choosen_hat > 0)
            choosen_hat = real_choosen_hat * 2 - 1;
        else
            choosen_hat = real_choosen_hat * (-2);

       // var go1 = GameObject.Find("TrackVisual");
       // go1.GetComponent<TrailRenderer>().colorGradient = color1;//colors testing here

        hats[choosen_hat].gameObject.SetActive(true);
        current_hat = hats[choosen_hat];
        deltaz = ball.position - current_hat.position;
        if (Application.loadedLevel == 2)
        {
            var go = GameObject.Find("TrackVisual");
            switch (real_choosen_hat)
            {
                case -1:
                    acceleration_little_force_effect();
                    break;
                case 1:
                    double_coins_effect();
                    break;
                case 2:
                    power_jump_effect();
                    break;
                case 3:
                    break;
                case 4:
                    Shield_effect();
                    
                  //  go.GetComponent<TrailRenderer>().colorGradient = color1;
                    break;
                case -2:
                    magnet_effect();
                    break;
                case -3:
                    rocker_effect();
                    break;
                case -4:
                    //var go = GameObject.Find("TrackVisual");
                    go.GetComponent<TrailRenderer>().colorGradient = rainbow_color;
                    break;
                default:
                    break;
            }
        }
        else
        {
            var go = GameObject.Find("TrackVisual");
            switch (real_choosen_hat)//pick the color
            {
                case -1:
                    
                    break;
                case 1:
                   
                    break;
                case 2:
                    
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case -2:
                    
                    break;
                case -3:
                   
                    break;
                case -4:
                    //var go = GameObject.Find("TrackVisual");
                    go.GetComponent<TrailRenderer>().colorGradient = rainbow_color;
                    break;
                default:
                    break;
            }

        }
      
    }
	
	void Update ()
    {
        if ((ball.gameObject.activeInHierarchy))
            current_hat.position = ball.position - deltaz;
        else
        {
            if ((!hat_launched)&&(choosen_hat!=0))
            {
                hat_launched = true;
                current_hat.GetComponent<BoxCollider>().enabled = true;
                current_hat.gameObject.AddComponent<Rigidbody>();

                Vector3 v3 = new Vector3(-10f, 500f, 40f);
                var rb = current_hat.gameObject.GetComponent<Rigidbody>();
                 rb.AddForce(v3);
                //current_hat.Rotate()
            }
        }
       
    }
    //место для функции активирующих эффкты шапок



    public void double_coins_effect()
    {
        Boost_manager.double_coins_duration_activate(1000000);
    }

    public void magnet_effect()
    {
        Boost_manager.magnet_boost_activate(1000000);
    }

    public void rocker_effect()
    {
        Boost_manager.acceleration_boost_activate();
    }

    public void acceleration_little_force_effect()
    {
        ball.GetComponent<Acceleration_force>().force = 5;
    }

    public void power_jump_effect()
    {
        ball.GetComponent<SphereCollider>().material.bounciness = 0.51f;
    }

    public void Shield_effect()
    {
        Boost_manager.shield_boost_activate(11f);
    }
}
