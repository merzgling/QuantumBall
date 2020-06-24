using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_boost : Effect
{
    GameObject shield;

    void Start()
    {
        shield = Instantiate(GameObject.Find("shield template"));
        shield.AddComponent<To_be_conected_with>();
        shield.GetComponent<To_be_conected_with>().target = GameObject.Find("ball").transform;
    }

    public override void action()
    {

    }

    void OnDestroy()
    {
        Destroy(shield);
    }
}
