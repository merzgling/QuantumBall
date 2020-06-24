using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_controller : MonoBehaviour
{
    public List<GameObject> templates;

    public int min_creating_range;
    public int max_creating_range;

    public float creating_y;

    GameObject ball;
    List<GameObject> created_boosts;
    private int position_to_create_boost;

    int boost_counter = 0;
    private Transform boost_parent;





    private const float deleting_range = 50f;
    private const float creating_range = 150f;

    private int new_position_to_create_boost()
    {
        int result = position_to_create_boost + Random.Range(min_creating_range, max_creating_range);

        return result;
    }

    // Use this for initialization
    void Awake()
    {
        position_to_create_boost = 0;
        position_to_create_boost = new_position_to_create_boost();
    }

    void Start()
    {
        ball = GameObject.Find("ball");
        boost_parent = GameObject.Find("Boosts").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (position_to_create_boost == 0)
            position_to_create_boost = new_position_to_create_boost();


        //creating new boost
        if (ball.transform.position.x + creating_range > position_to_create_boost)
        {
            boost_counter++;
            GameObject new_boost = Instantiate(templates[Random.Range(0, templates.Count)]);


            new_boost.transform.position = new Vector3(position_to_create_boost, creating_y);
            new_boost.transform.name = "boost " + boost_counter;
            new_boost.transform.parent = boost_parent;
            //created_boosts.Add(new_boost);


            position_to_create_boost = new_position_to_create_boost();
        }

        //deleting boosts
        /*if (created_boosts.Count > 0)
            foreach(GameObject element in created_boosts)
                if (ball.transform.position.x > element.transform.position.x + deleting_range)
                {
                    created_boosts.Remove(element);
                    Destroy(element);
                }*/
    }

    
}
