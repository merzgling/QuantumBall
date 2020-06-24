using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniform_distributed_sequence : Sequence
{
    public int starting_position;//exclusive
    public int min_delta;//inclusive
    public int max_delta;//inclusive
    int current;

    // Use this for initialization
    void Start()
    {
        current = starting_position;
    }

    public override int get_next()
    {
        current += Random.Range(min_delta, max_delta + 1);
        return current;
    }
}
