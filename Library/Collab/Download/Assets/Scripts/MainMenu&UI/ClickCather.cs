using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCather : MonoBehaviour {

    //public GameObject[] columns;
    private List<Transform> columns;
    private bool mouse_down=false;
    private Camera cam;
    private Vector3 mouse_pos;
    private int cen_col;
    public GameObject[] buttons;

	void Awake () 
    {
        cam = Camera.main;
        columns = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var column = transform.GetChild(i);
            columns.Add(column);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (mouse_down)
        {
            FindNearestColumn();
            MoveColumn();

        }
        else
        {
            NoneClicked();
        }
	}
    void OnMouseDown()
    {
        mouse_down = true;
    }
    void OnMouseUp()
    {
        mouse_down = false;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<UnityEngine.UI.Button>().enabled)
                buttons[i].GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        }
            
    }
  
    private void FindNearestColumn()
    {

        mouse_pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8.5f);
        // mouse_pos.z = 10;
        mouse_pos = cam.ScreenToWorldPoint(mouse_pos);

        float t=20;
        int z=0;
        for (int i = 0; i < gameObject.transform.childCount;i++)//columns.Length; i++)
        {
            if (Abs(mouse_pos.x - columns[i].transform.position.x) < t)
            {
                t = Abs(mouse_pos.x - columns[i].transform.position.x);
                z = i;
            }   
        }
        cen_col = z;
    }
    private void MoveColumn()
    {
        Vector3 column_pos;
     
        for (int i = 0; i < gameObject.transform.childCount; i++)//columns.Length; i++)
        {
            column_pos = columns[i].transform.localPosition;
            if ((i > cen_col - 5) && (i < cen_col + 5))
            {
                if (column_pos.y < (5 - Abs(cen_col - i)) * 0.1f)
                {
                    column_pos = new Vector3(column_pos.x, column_pos.y + Time.deltaTime*3, column_pos.z);
                    columns[i].transform.localPosition = column_pos;
                }
                else
                {
                    if (column_pos.y > (5 - Abs(cen_col - i)) * 0.1f + Time.deltaTime)
                    {
                        column_pos = new Vector3(column_pos.x, column_pos.y - Time.deltaTime, column_pos.z);
                        columns[i].transform.localPosition = column_pos;
                    }
                }
            }
            else
            {
                if (column_pos.y > 0)
                {
                    
                    column_pos = new Vector3(column_pos.x, column_pos.y - Time.deltaTime, column_pos.z);
                    if(column_pos.y < 0)
                        column_pos = new Vector3(column_pos.x, 0, column_pos.z);
                    columns[i].transform.localPosition = column_pos;
                }
            }

        }
        
    }
    private void NoneClicked()
    {
        Vector3 column_pos;

        for (int i = 0; i < gameObject.transform.childCount; i++)//columns.Length; i++)
        {
            column_pos = columns[i].localPosition; //transform.localPosition;
            if (column_pos.y > 0)
            {

                column_pos = new Vector3(column_pos.x, column_pos.y - Time.deltaTime, column_pos.z);
                if (column_pos.y < 0)
                    column_pos = new Vector3(column_pos.x, 0, column_pos.z);
                columns[i].transform.localPosition = column_pos;
            }
        }
    }
    private float Abs(float t)
    {
        if (t > 0)
            return t;
        else
            return -t;
    }

}
