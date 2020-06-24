using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//когда щит на персонаже, он должен крутиться
//и кароче этот скрипт висит на объекте щит
//когда он на персонаже и крутит его
//вооот

public class Shield_on_character : MonoBehaviour
{
    float rotation_speed = 120f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), rotation_speed * Time.deltaTime);
    }
}
