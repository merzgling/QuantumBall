using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public List<GameObject> templates;
    public float deleting_range;
    public float creating_range;

    public Sequence position_function;
    public Sequence template_function;

    protected GameObject player;
    protected Factory_created_object first_object;
    public Factory_created_object current_object;
    protected int current_position;


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("ball");
        OnStart();
    }/*

    // Update is called once per frame
    void Update()
    {
        if (first_object)//deleting objects
            while (player.transform.position.x - first_object.x_position > deleting_range)
            {
                Factory_created_object next = first_object.next_object;
                OnDelete(first_object.gameObject);
                Destroy(first_object);
                if (next)
                    first_object = next;
            }

        
        while (current_position - player.transform.position.x < creating_range)//creating object
        {
            int creating_x = position_function.get_next();
            GameObject created_object = OnCreate(creating_x, templates[template_function.get_next()]);
            created_object.AddComponent<Factory_created_object>();
            Factory_created_object new_object = created_object.GetComponent<Factory_created_object>();
            new_object.x_position = creating_x;
            //if (current_object)
                //current_object.next_object = new_object;
            //new_object.previos_object = current_object;
            //current_object = new_object;
            //if (!first_object)
                //first_object = current_object;
        }
    }*/

    protected abstract GameObject OnCreate(int x_pos, GameObject template);

    protected abstract void OnDelete(GameObject deleting_object);

    protected abstract void OnStart();
}
