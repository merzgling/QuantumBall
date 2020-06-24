using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant_sequence : Sequence
{
    public int constant_value;

    public override int get_next()
    {
        return constant_value;
    }
}
