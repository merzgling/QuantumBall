using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_allert : MonoBehaviour
{
    public bool activated;
    private float time;

    private void Start()
    {
        activated = false;
    }

    private void OnBecameVisible()
    {
        if (!activated)
        {
            activated = true;
            transform.position = new Vector3(transform.position.x - 7, transform.position.y);
            gameObject.AddComponent<Stay_freeze_on_x>();
        }
    }
}
