using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBoostScript : MonoBehaviour {
    public static RunBoostScript instance;
    //висит на буст канвасе
    public static bool test;
    public GameObject[] boost_timers; //таймеры на каждый буст
    private GameObject cur;
    private Vector3 pos;
    private Vector3[] poses = new Vector3[5];
  
   
    public static List<GameObject> boosts_on_screen = new List<GameObject> { };
    void Awake()
    {
        instance = this;
    }

    public void RunBoost(string boost_name) //включаем буст
    {
      int num = PlayerPrefs.GetInt(boost_name + "amount");
        if ((num > 0))
        {
           
                PlayerPrefs.SetInt(boost_name + "amount", num - 1);
            switch (boost_name)
            {
                case "Rocket":                  
                    cur = Instantiate(boost_timers[0], pos, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    cur.transform.SetParent(gameObject.transform, false);
                   // cur.GetComponent<BoostTimerAnim>().life_time = 10;
                    if (!BoostReplaced(cur))
                    {
                        boosts_on_screen.Add(cur);
                        cur.GetComponent<RectTransform>().anchoredPosition = new Vector3(-272, boosts_on_screen.Count * -200, 0); 
                    }

                    Boost_manager.acceleration_boost_activate(10f);
                    break;
                case "Shield":
                    cur = Instantiate(boost_timers[1], pos, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    cur.transform.SetParent(gameObject.transform, false);
                    cur.GetComponent<BoostTimerAnim>().life_time = 40f;
                    if (!BoostReplaced(cur))
                    {
                        boosts_on_screen.Add(cur);
                        cur.GetComponent<RectTransform>().anchoredPosition = new Vector3(-272, boosts_on_screen.Count * -200, 0);
                    }
                    Boost_manager.shield_boost_activate(40f);
                    break;
                case "DoubleCoin":                   
                    cur = Instantiate(boost_timers[2], pos, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    cur.transform.SetParent(gameObject.transform, false);
                    cur.GetComponent<BoostTimerAnim>().life_time = 30f;
                    if (!BoostReplaced(cur))
                    {
                        boosts_on_screen.Add(cur);
                        cur.GetComponent<RectTransform>().anchoredPosition = new Vector3(-272, boosts_on_screen.Count * -200, 0);
                    }
                    Boost_manager.double_coins_duration_activate(30f);
                    break;
                case "Magnet":
                    cur = Instantiate(boost_timers[3], pos, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    cur.transform.SetParent(gameObject.transform, false);
                    cur.GetComponent<BoostTimerAnim>().life_time = 25f;
                    if (!BoostReplaced(cur))
                    {
                        boosts_on_screen.Add(cur);
                        cur.GetComponent<RectTransform>().anchoredPosition = new Vector3(-272, boosts_on_screen.Count * -200, 0);
                    }
                    Boost_manager.magnet_boost_activate(25f);
                    break;
                case "Timer":
                    cur = Instantiate(boost_timers[4], pos, Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
                    cur.transform.SetParent(gameObject.transform, false);
                    if (!BoostReplaced(cur))
                    {
                        boosts_on_screen.Add(cur);
                        cur.GetComponent<RectTransform>().anchoredPosition = new Vector3(-272, boosts_on_screen.Count * -200, 0);
                    }
                    Boost_manager.time_shift_boost_activate(10f);
                    break;               
                default:
                    break;
            }
        }

    }
    public static IEnumerator Moving(GameObject cur_boost,Vector3 new_pos)
    {
        float step = 10f;
        RectTransform trans =cur_boost.GetComponent<RectTransform>();
        Vector3 cur_pos = trans.anchoredPosition;
        while (new_pos.y - trans.anchoredPosition.y > 1)
        {
            cur_pos.y += step;
            trans.anchoredPosition = cur_pos;
            yield return new WaitForSeconds(0.01f);
            
        }
            
        
       
    }
    public static void RemoveFromList(GameObject game_obj)
    {
        boosts_on_screen.Remove(game_obj);
        for (int i = 0; i < boosts_on_screen.Count; i++)
        {          
            instance.StartCoroutine(Moving(boosts_on_screen[i], new Vector3(-272, (i + 1) * -200, 0)));
        }
    }
    private bool BoostReplaced(GameObject obj_to_inst)
    {
        foreach (GameObject go in boosts_on_screen)
        {
            if (go.tag == obj_to_inst.tag)
            {
                cur.GetComponent<RectTransform>().anchoredPosition = go.GetComponent<RectTransform>().anchoredPosition;
                int i = boosts_on_screen.IndexOf(go);
                boosts_on_screen.Remove(go);
                Destroy(go);
                boosts_on_screen.Insert(i, obj_to_inst);
                return true;
            }
        }      
        return false;
    }
}
