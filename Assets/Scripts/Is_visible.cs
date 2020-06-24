using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_visible : MonoBehaviour
{
    public bool is_visible;

    private void Start()
    {
        is_visible = false;
    }

    private void OnBecameVisible()
    {
        is_visible = true;
    }

    private void OnBecameInvisible()
    {
        is_visible = false;
    }
}
