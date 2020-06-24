using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class ExplosionsCall : MonoBehaviour {
    //вызов взрывов, Висит на главной сцене Engine
    public static Transform static_explosion_ball;
    public static Transform static_explosion_obstacle;
    public Transform explosion_ball;
    public Transform explosion_obstacle;
    void Awake ()
    {
        static_explosion_ball = explosion_ball;
        static_explosion_obstacle = explosion_obstacle;

    }
    public static void BallExplosion(Vector3 pos,bool explosion_physics = true) //вызывает взрыв для мяча, булевая переменная указывает на наличие отталкивающей силы при взрыве
    {
        static_explosion_ball.gameObject.SetActive(false);
        static_explosion_ball.position = pos;
        if (!explosion_physics)
            static_explosion_ball.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;
        else
            static_explosion_ball.GetComponent<ExplosionPhysicsForce>().explosionForce = 25;
        static_explosion_ball.gameObject.SetActive(true);     
    }
    public static void ObstacleExplosion(Vector3 pos, bool explosion_physics = true)//вызывает взрыв для препятсвий
    {
        static_explosion_obstacle.gameObject.SetActive(false);
        static_explosion_obstacle.position = pos;
        if (!explosion_physics)
            static_explosion_obstacle.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;
        else
            static_explosion_obstacle.GetComponent<ExplosionPhysicsForce>().explosionForce = 10;
        static_explosion_obstacle.gameObject.SetActive(true);
    }
}
