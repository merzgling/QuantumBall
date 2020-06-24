using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public int created_pool;
    public int starting_pool;
    public GameObject template;

    bool initialized = false;

    protected List<GameObject> pool;
    
    protected void Awake()
    {
        if (!initialized)
            initialize();
    }

    void initialize()
    {
        created_pool = 0;
        pool = new List<GameObject>();
        while (pool.Count < starting_pool)
        {
            create_new();
        }

        initialized = true;
    }

    public virtual GameObject get()
    {
        GameObject return_object;

        if (!initialized)
            initialize();

        if (pool.Count <= 0)
        {
            create_new();
        }

        return_object = pool[0];
        pool.Remove(return_object);
        return_object.SetActive(true);

        return return_object;
    }

    public void push(GameObject new_object)
    {
        new_object.transform.position = transform.position;
        transform.parent = null;
        pool.Add(new_object);
        new_object.SetActive(false);
    }

    protected GameObject create_new()
    {
        created_pool++;
        GameObject new_object = Instantiate<GameObject>(template);
        new_object.transform.position = transform.position;
        pool.Add(new_object);
        new_object.SetActive(false);

        return new_object;
    }
}
