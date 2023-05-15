using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClicktoMove : MonoBehaviour
{
    public static ClicktoMove Instance { get; set; }

    Animator anim; 
    NavMeshAgent agent;

    //Movement Started? Purposes..
    public bool startMovement = false;

    private Vector3 startTouch;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        startMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }
    void playerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Player animation when it start running..
                anim.SetBool("isRunning", true);

                //Foot Special Sounds..
                AudioManager.Instance.Play("DeepFootStep");

                //Player Destination to the Vector in the Screen
                agent.SetDestination(hit.point);
            }
        }

        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")

        {
            //Play Enemy Attack Animation..
            EController.Instance.attackingAnimation();

            //Setting Damage on Enemy Health
            StaminaBar.Instance.attackingPlayer();
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //When Enemy exit Player collider, stop attack animation..
            EController.Instance.stoppingAttackAnimation();
        }
    }

}