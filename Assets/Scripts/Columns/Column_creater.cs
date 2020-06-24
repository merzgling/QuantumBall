using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column_creater : MonoBehaviour
{
    public GameObject column_template;

    public GameObject high_score_column_template;
    public GameObject flag_template;

    public GameObject roof_column_template;
    public GameObject ball;

    public Transform columns_parent;
    public Transform physical_columns_parent;

    private Transform roof_columns_parent;

    public int current_pos; 
    public int limited;

    public Pool column_pool;
    public Pool roof_pool;

    public Factory_created_object current_roof;
    public Factory_created_object first_roof;
    public float roof_deleting_dist = 45f;

    public Column current_column;
    private GameObject chalange;

    public int high_score;

    const float max_distance = 100;

    public void Awake()
    {
        chalange = GameObject.Find("Chalange");
        roof_columns_parent = GameObject.Find("Roof columns").transform;
    }

    private void Start()
    {
        high_score = Game.GetHighScore();
    }

    public Column initialize_first_column()
    {
        if (current_column)
            return current_column;

        current_pos = 0;
        current_pos = 0;
        current_column = null;
        create_column();

        Column result = current_column;

        create_column_cheker();
        
        return result;
    }
   

    private void create_column() 
    {
        GameObject new_column = new GameObject();
        GameObject physical_column;

        //создание флага
        if (current_pos == high_score + 11 && chalange == null && limited == 0)
        {
            if (high_score != Game.GetHighScore())
            {
                high_score = Game.GetHighScore();
                physical_column = column_pool.get();
            }
            else
            {
                GameObject flag = Instantiate<GameObject>(flag_template);
                flag.transform.position = new Vector3(current_pos - 2.5f, flag.transform.position.y + 10.68734f, flag.transform.position.z);
                physical_column = Instantiate<GameObject>(high_score_column_template);
            }
        }
        else
            physical_column = column_pool.get();

        //creating roof columns
        if (current_pos % 2 == 1)
        {
            GameObject roof_column = roof_pool.get();
            roof_column.transform.position = new Vector3(current_pos, 34 + Random.Range(0, 2.2f));
            roof_column.name = "roof column " + current_pos;
            roof_column.transform.parent = roof_columns_parent;
            roof_column.AddComponent<Factory_created_object>();
            Factory_created_object roof_component = roof_column.GetComponent<Factory_created_object>();
            if (current_roof)
            {
                current_roof.next_object = roof_component;
                roof_component.previos_object = current_roof;
                roof_component.x_position = current_pos;
                current_roof = roof_component;
            }
            else
                current_roof = roof_component;

            if (first_roof == null)
                first_roof = current_roof;
        }

        new_column.name = "column " + current_pos;
        new_column.transform.parent = columns_parent;


        physical_column.transform.tag = "column";
        physical_column.name = "physical column " + current_pos;
        physical_column.transform.position = new Vector3(current_pos, 0 - 0.00001f * current_pos);
        physical_column.transform.parent = physical_columns_parent;

        Column column_component = new_column.AddComponent<Column>();

        column_component.obstacled = false;
        column_component.column = physical_column;
        column_component.number = current_pos;
        column_component.next_column = null;
        column_component.pre_column = null;

        if (current_column)
        {
            current_column.next_column = column_component;
            column_component.pre_column = current_column;
        }

        current_column = column_component;

        current_pos++;
    }

    private void create_column_cheker()
    {
        if (current_pos >= limited && limited > 0)
            return;

        if (ball)
            while (current_pos < max_distance + ball.transform.position.x)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (current_pos >= limited && limited > 0)
                        return;
                    create_column();
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        create_column_cheker();
    }
}
