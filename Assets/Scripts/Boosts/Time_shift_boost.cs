using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_shift_boost : Effect
{
    public override void action()
    {
    }
    //kizor
    void Start()
    {
        
        Time_scale_controller.TimeShiftActivate(true);
        
    }
    
    void OnDestroy()
    {
        Time_scale_controller.TimeShiftActivate(false);
    }
    //kizor
}
