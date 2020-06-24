using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_boost : Effect
{
    void Start()
    {
        Character_controller.MagnetTrigger.SetActive(true);
    }

    public override void action()
    {
        
    }

    void OnDestroy()
    {
        Character_controller.MagnetTrigger.SetActive(false);
    }
}
