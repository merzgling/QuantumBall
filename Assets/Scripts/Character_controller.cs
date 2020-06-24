using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;
public class Character_controller : MonoBehaviour
{
    public Transform coins_destination;//пустой объект для положения направления монет
    public int score=0;
    public GameObject dead_menu;//kizor
    public GameObject head_parent;//kizor
    public GameObject player_effects;
    public GameObject player;
    public GameObject gameplay_ui_parent;//kizor
    private RunBoostScript boost_runner;
    public Pool coin_pool;

    private static GameObject ball;
    private static GameObject ball_effects;
    private static Rigidbody rd;
    public static GameObject MagnetTrigger;


    const int max_number_of_shields = 3;
    public int number_of_shields;

    const float max_speed = 21f;
    const float max_speed_rocket = 35f;

    private static bool gameOvered;
    public static bool GameOvered
    {
        get
        {
            return gameOvered;
        }
    }

    public void GameOver()
    {
        gameOvered = true;
       
       
        dead_menu.SetActive(true);//kizor
        head_parent.SetActive(false);
        head_parent.SetActive(true);
        head_parent.transform.Find("PauseButton").gameObject.SetActive(false);
        ExplosionsCall.BallExplosion(gameObject.transform.position, false);
        gameObject.SetActive(false);//kizor
        if (Application.loadedLevel == 2)
        {
            if (score > PlayerPrefs.GetInt("high score"))
            {
                dead_menu.transform.Find("HighScore").gameObject.SetActive(false);
            }
            else
            {
                dead_menu.transform.Find("NewHighScore").gameObject.SetActive(false);

            }
            Game.NewHighScore(score);
        }
        Time_scale_controller.RebootTimeVariables();
    }

    private void coin_add(int x)
    {
        Game.AddCoin(x);
    }

    private void coin_add()
    {
        coin_add(1);
    }

    private void shield_add(int x)
    {
        if (number_of_shields + x > max_number_of_shields)
            number_of_shields = max_number_of_shields;
        else
            number_of_shields += x;
    }

    private void shield_add()
    {
        shield_add(1);
    }

    private void shield_lose(int x)
    {
        if (x > number_of_shields)
            number_of_shields = 0;
        else
            number_of_shields -= x;
    }

    private void shield_lose()
    {
        shield_lose(1);
    }

    public static bool is_rocket_boost_active()
    {
        if (ball.GetComponent<Rocket_boost>())
            return true;
        else
            return false;
    }

    private void Start()
    {
        gameOvered = false;
        score = 0;
        number_of_shields = 0;
        player_effects = GameObject.Find("Player effects");
        player = GameObject.Find("ball");
        player.GetComponent<Rigidbody>().AddForce(new Vector3(300, 0));
        boost_runner=gameplay_ui_parent.GetComponent<RunBoostScript>();

        ball = player;
        ball_effects = player_effects;
        rd = gameObject.GetComponent<Rigidbody>();
        MagnetTrigger = GameObject.Find("MagnetTrigger");
        MagnetTrigger.SetActive(false);
    }

    private void use_gravity()
    {
        float gravity_hight = 15f;
        if (player.transform.position.y > gravity_hight)
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0, (-Mathf.Abs(player.transform.position.y - 25))));
    }

    private void Update()
    {
        score = Mathf.Max(score, (int)transform.position.x - 10);
    }

    private void FixedUpdate()
    {
        if (is_rocket_boost_active())
        {
            if (rd.velocity.magnitude > max_speed_rocket)
                rd.AddForce(new Vector3(-(rd.velocity.magnitude - max_speed_rocket), 0));
        }
        else
            if (rd.velocity.magnitude > max_speed)
                rd.AddForce(new Vector3(-(rd.velocity.magnitude - max_speed), 0));
        use_gravity();
    }

    private void on_obstacle_enter(GameObject obstacle)
    {
        if (player_effects.GetComponent<Shield_boost>() || player.GetComponent<Rocket_boost>())
        {
            ExplosionsCall.ObstacleExplosion(obstacle.transform.position, false);///взрыв
            Destroy(obstacle);
        }
        else
            GameOver();
    }
   
    IEnumerator MoveCoin(Transform coin_transform, Vector3 destination)//движение монетки
    {
        Vector3 normalizeDirection;
        float speed = 1f;
        
        while ((destination - coin_transform.position).magnitude > 1f)
        {      
             normalizeDirection = (destination - coin_transform.position).normalized;
             coin_transform.position += normalizeDirection * speed; //обычное движение в точку в нормальных координатах
            yield return 0.1f;
        }
        coin_pool.push(coin_transform.gameObject);
        coin_transform.tag = "coin";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "death_zone")
        {
            if (Application.loadedLevel == 8)
            {
                var ap = new Application_controller();
                ap.Load(1);
                return;
            }
            else
                GameOver();
        }
            

        if (other.tag == "obstacle")
            on_obstacle_enter(other.gameObject);

        if ((other.tag == "coin")||(other.tag=="coin2"))//------------------------------------------------------------------------------------------------------------------------------------------
        {
            other.tag = "coin2";
            Game.AddCoin();
            StartCoroutine(MoveCoin(other.transform, coins_destination.position)); 
                   
        }

        if ((other.tag == "chalange completer"))
        {
            var ap = new Application_controller();
            if (other.GetComponent<Chalange_completer>().chalange_index == -1)
            {
                ap.Load(1);
                return;
            }


            if ((other.GetComponent<Chalange_completer>().chalange_index == 4) && ((PlayerPrefs.GetInt("chalange " + 4.ToString()) == 1)))
                ap.Load(1);
            else
            {
                Game.chalange_comleted(other.GetComponent<Chalange_completer>().chalange_index);
                ap.Load(8);
            }
            
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        if (other.tag == "eaten_entity") //kizor
        {
            string boost_name = other.GetComponent<Eaten_entity>().name_of_action;
            other.GetComponent<Eaten_entity>().deleting();
            //запускаю подобранные бусты через элемент UI
            // Если бусты не работают перетащи на переменную game_play_parent объект GameplayUI который находится в UI 
            string true_name;
            switch(boost_name)
            {
                case "acceleration force":
                    true_name = "Rocket";
                    PlayerPrefs.SetInt(true_name + "amount", PlayerPrefs.GetInt(true_name + "amount") + 1);
                    boost_runner.RunBoost(true_name);
                    break;
                case "double coins":
                    true_name = "DoubleCoin";
                    PlayerPrefs.SetInt(true_name + "amount", PlayerPrefs.GetInt(true_name + "amount") + 1);
                    boost_runner.RunBoost(true_name);
                    break;
                case "time shift":
                    true_name = "Timer";
                   PlayerPrefs.SetInt(true_name + "amount", PlayerPrefs.GetInt(true_name + "amount") + 1);
                    boost_runner.RunBoost(true_name);
                    break;
                case "shield":
                    true_name = "Shield";
                    PlayerPrefs.SetInt(true_name + "amount", PlayerPrefs.GetInt(true_name + "amount") + 1);
                    boost_runner.RunBoost(true_name);
                    break;
                case "magnet":
                    true_name = "Magnet";
                   PlayerPrefs.SetInt(true_name + "amount", PlayerPrefs.GetInt(true_name + "amount") + 1);
                    boost_runner.RunBoost(true_name);
                    break;
                default:
                    break;
            }

        }
    }
}
