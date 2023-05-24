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

    public bool isDamaging = false;

    private void Awake()
    {
        Instance = this;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
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
