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
        //..Enemy movement function
        enemyMovement();
    }

    public void enemyMovement()
    {
        //Play animation..
        anim.SetBool("isWalking", true);
        //..Enemy Following Player
        enemy.SetDestination(playerTransform.position);
        
    }
    public void attackingAnimation()
    {
        //anim.SetBool("isWalking", false);
        //anim.SetTrigger("Attacking");
        anim.SetBool("isAttacking", true);
    }

    public void stoppingAttackAnimation()
    {
        anim.SetBool("isAttacking", false);
        //anim.SetBool("isWalking", true);
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
                 attackingAnimation();
                //Damage on the player..
                StaminaBar.Instance.attackingPlayer();   
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            stoppingAttackAnimation();
        }
    }

}
