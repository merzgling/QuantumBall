using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomShopContrloller : MonoBehaviour {

    // висит на кастомшоп вращающейся панеле
    private List<Transform> models;
    public float radius, delta_angle;
    private const float ang_rad= Mathf.PI / 180f;
    public static int current_hat = 0;
    public GameObject buy_button;
    private int coins;
	void Awake ()
    {
        PlayerPrefs.SetInt("HatOwned" + 0.ToString(), 1);
        current_hat = PlayerPrefs.GetInt("Current Hat");
        models = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var model = transform.GetChild(i);
            models.Add(model);
            

        }
        for (int i = 0; i < transform.childCount; i += 2)
        {
            models[i].localPosition = new Vector3(radius * Mathf.Sin(i/2 * delta_angle * ang_rad), 0, radius * Mathf.Cos(i/2 * delta_angle * ang_rad));
            if(i!=0)
                models[i - 1].localPosition = new Vector3(-1*radius * Mathf.Sin(i/2 * delta_angle * ang_rad), 0, radius * Mathf.Cos(i/2 * delta_angle * ang_rad));
        }
	}
    void Start()
    {
        StartCoroutine(RotateCustomBar(delta_angle*current_hat));
    }
	void Update () {
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
        {
            MoveAround(false);
        }
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
        {
            MoveAround(true);
        }
    }
    private void MoveAround(bool left)
    {
        if (left)
        {
            StartCoroutine(RotateCustomBar(delta_angle));
            current_hat++;
        }

        else
        {
            StartCoroutine(RotateCustomBar(-delta_angle));
            current_hat--;           
        }
        if (PlayerPrefs.GetInt("HatOwned" + current_hat.ToString()) == 1)
        {
            buy_button.SetActive(false);
            PlayerPrefs.SetInt("Current Hat", current_hat);
        }
        else
        {
            buy_button.SetActive(true);
        }

    }
     IEnumerator RotateCustomBar(float y_degrees)
    {
        
        float step = y_degrees/20;
        for (int i = 0; i < 20; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, step, 0));
              yield return new WaitForSeconds(0.01f);
        }

    }
    public void BuyHat()
    {
        coins = PlayerPrefs.GetInt("coins");
        if (coins >= 300)
        {
            coins -= 300;
            PlayerPrefs.SetInt("HatOwned" + current_hat.ToString(), 1);
            UpdateMoney();
        }
    }
    private void UpdateMoney()
    {
        PlayerPrefs.SetInt("coins", coins);
        Game.GameStarts();
    }
}
