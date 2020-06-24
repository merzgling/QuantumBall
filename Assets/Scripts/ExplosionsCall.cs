using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class ExplosionsCall : MonoBehaviour {
    //вызов взрывов, Висит на главной сцене Engine
    public static GameObject static_explosion_ball;
    public static GameObject static_explosion_obstacle;
    public GameObject explosion_ball;
    public GameObject explosion_obstacle;
    void Awake ()
    {
        static_explosion_ball = explosion_ball;
        static_explosion_obstacle = explosion_obstacle;

    }
    public static void BallExplosion(Vector3 pos,bool explosion_physics = true) //вызывает взрыв для мяча, булевая переменная указывает на наличие отталкивающей силы при взрыве
    {
        //static_explosion_ball.gameObject.SetActive(false);
        //static_explosion_ball.position = pos;
        GameObject expl = Instantiate(static_explosion_ball, pos, Quaternion.identity).gameObject;
        Destroy(expl, 1.5f);
        if (!explosion_physics)
            expl.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;
        else
            expl.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;//25;
       // static_explosion_ball.gameObject.SetActive(true);     
    }
    public static void ObstacleExplosion(Vector3 pos, bool explosion_physics = true)//вызывает взрыв для препятсвий
    {
        //static_explosion_obstacle.gameObject.SetActive(false);
        //static_explosion_obstacle.position = pos;
        GameObject expl = Instantiate(static_explosion_obstacle, pos, Quaternion.identity).gameObject;
        Destroy(expl, 1.5f);
        if (!explosion_physics)
            expl.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;
        else
            expl.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;//10;
       // static_explosion_obstacle.gameObject.SetActive(true);
    }
}
