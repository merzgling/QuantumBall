using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomShopContrloller : MonoBehaviour {

    // висит на кастомшоп вращающейся панеле
    private List<Transform> models;
    private List<Transform> models_names;
    private List<Transform> models_costs;
    public float radius, delta_angle;
    private const float ang_rad= Mathf.PI / 180f;
    public static int current_hat = 0;
    public GameObject explosion;
    private int border_number;

    private AudioSource audio_1;
   
    public AudioClip qb_sound;
    public AudioClip ben_sound;
 
    private int coins;
	void Awake ()
    {    
        models = new List<Transform>();
        models_names = new List<Transform>();
        models_costs = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var model = transform.GetChild(i);
            models.Add(model);
            var model_name_obj = model.GetChild(0);
            models_names.Add(model_name_obj);
            model_name_obj.gameObject.SetActive(false);
            var model_cost_obj = model.GetChild(1);
            models_costs.Add(model_cost_obj);
            model_cost_obj.gameObject.SetActive(false);
        }
        for (int i = 0; i < transform.childCount; i += 2)//число шапок обязательно должно быть нечетно
        {
            models[i].localPosition = new Vector3(radius * Mathf.Sin(i/2 * delta_angle * ang_rad), 0, radius * Mathf.Cos(i/2 * delta_angle * ang_rad));
            if(i!=0)
                models[i - 1].localPosition = new Vector3(-1*radius * Mathf.Sin(i/2 * delta_angle * ang_rad), 0, radius * Mathf.Cos(i/2 * delta_angle * ang_rad));
        }
        PlayerPrefs.SetInt("HatOwned" + 0.ToString(), 1);
        current_hat = PlayerPrefs.GetInt("Current Hat");
        border_number = transform.childCount / 2;

        audio_1 = GameObject.Find("music").GetComponent<AudioSource>();
    }
    private int GetPositiveNumber(int real_current_hat)
    {
        if (real_current_hat > 0)
            return real_current_hat * 2 - 1;
        else
            return real_current_hat * (-2);
    }
    void Start()
    {
        StartCoroutine(RotateCustomBar(delta_angle*current_hat));
        models_names[GetPositiveNumber(current_hat)].gameObject.SetActive(true);
    }
	void Update () {
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
        {
            MoveAround(true);
        }
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
        {
            MoveAround(false);
        }
    }
    private void MoveAround(bool left)
    {

        
        if ((left)&&(current_hat!=border_number))
        {
            StartCoroutine(RotateCustomBar(delta_angle));
            current_hat++;
        }

        else
        {
            if ((!left)&&(current_hat!=(-border_number)) )
            {
                StartCoroutine(RotateCustomBar(-delta_angle));
                current_hat--;
            }          
        }

        
    }
     IEnumerator RotateCustomBar(float y_degrees)
    {

        models_costs[GetPositiveNumber(current_hat)].gameObject.SetActive(false);
        models_names[GetPositiveNumber(current_hat)].gameObject.SetActive(false);
        float step = y_degrees/20;
        for (int i = 0; i < 20; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, step, 0));
              yield return new WaitForSeconds(0.01f);
        }
        models_names[GetPositiveNumber(current_hat)].gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("HatOwned" + current_hat.ToString()) == 1)
        {
            models_costs[GetPositiveNumber(current_hat)].gameObject.SetActive(false);
            PlayerPrefs.SetInt("Current Hat", current_hat);
            
        }
        else
        {
            models_costs[GetPositiveNumber(current_hat)].gameObject.SetActive(true);
        }

    }
    public void BuyHat(int cost=300)
    {
        coins = PlayerPrefs.GetInt("coins");
        if (coins >= cost)
        {
            coins -= cost;
            PlayerPrefs.SetInt("HatOwned" + current_hat.ToString(), 1);
            PlayerPrefs.SetInt("Current Hat", current_hat);
            UpdateMoney();
            Destroy(Instantiate(explosion, new Vector3(0f, 0f, 0f), Quaternion.identity),1f);
        }
    }
    public void HideButton(GameObject button)
    {
        if (PlayerPrefs.GetInt("Current Hat") == current_hat)
            button.SetActive(false);

    }
    private void UpdateMoney()
    {
        PlayerPrefs.SetInt("coins", coins);
        Game.GameStarts();
    }
    public void ChangeSoundTrack()
    {
        int cur_hat = PlayerPrefs.GetInt("Current Hat");
        bool was_track_changed=false;
        if (cur_hat == 3)
        {
            audio_1.clip = ben_sound;
            if (audio_1.volume == 1f)
                was_track_changed = true;
            audio_1.volume = 0.5f;
        }
        else
        {
            audio_1.clip = qb_sound;
            if (audio_1.volume == 0.5f)
                was_track_changed = true;
            audio_1.volume = 1f;
        }
            if(was_track_changed)
        audio_1.Play();
    }
}
