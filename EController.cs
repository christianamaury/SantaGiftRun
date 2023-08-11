using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EController : MonoBehaviour
{
    public static EController Instance {get; set;}
    NavMeshAgent enemy;
    private Transform playerTransform;
    private Animator anim;

    //Checking how close is the enemy from the Player in order to play an Audio;
    private float detectPlayerRadius = 5f;

    //Playing Enemy Sound every 12 seconds as the most..
    //Volume Default Sound Range: 0.068
    //Initially set to 20f; 18.5f;19.6f;, 35.6f;
    private float enemySoundCooldown = 45.7f;

    //In order to Timestamp when the audio was last played
    private float lastTimePlayed = -Mathf.Infinity;

    public bool isDamaging = false;


    private void Awake()
    {
        Instance = this;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
    }

    //Update is called once per frame
    void Update()
    {
        //..Enemy movement function;
        enemyMovement();
    }

    public void enemyMovement()
    {
        //Play animation..
        anim.SetBool("isWalking", true);
        //Enemy Following Player..
        enemy.SetDestination(playerTransform.position);

        //Checking how far is the Player from the Enemy;
        float currentDistancePlayer = Vector3.Distance(enemy.transform.position, playerTransform.position);

        //If the enemy is within the area;
        if (currentDistancePlayer <= detectPlayerRadius && Time.time >= lastTimePlayed + enemySoundCooldown)
        {
            //AudioManager.Instance.Play("EnemySound");
            if (AudioManager.Instance != null)
            {
                //Play Enemy Sound Effect;
                AudioManager.Instance.Play("EnemySound");
            }

            lastTimePlayed = Time.time;
        }
        
    }
    public void attackingAnimation()
    {
        //Enemy Attack Animation;
        anim.SetBool("isAttacking", true);
    }

    public void stoppingAttackAnimation()
    {
        //Stop playing attack animation; 
        anim.SetBool("isAttacking", false);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isDamaging = true;
            if(isDamaging == true)
            {
                attackingAnimation();
                //Damage on the player..
                StaminaBar.Instance.attackingPlayer();
                isDamaging = false;
            }

        }
    }

    public void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            isDamaging = false;
            stoppingAttackAnimation();
        }
    }

}
