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

    //Distance kinda of threshold to be consider from the final Destination;
    //0.5f; 0.3f;
    private float stoppingThreshold = 0.2f;

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

                //Play audio sound only if it not playing already
                if (!AudioManager.Instance.isPlaying("SnowFootSteps"))
                {
                    //Playing audio
                    AudioManager.Instance.Play("SnowFootSteps");
                }

                //Player Destination to the Vector in the Screen
                agent.SetDestination(hit.point);

            }
        }

        //Checking if the player finally made it to the vector destination;
        if (!agent.pathPending && agent.remainingDistance <= stoppingThreshold)
        {
            //Disable animation since the player already the location;
            anim.SetBool("isRunning", false);
            //Stop playing Foot Special Sounds;
            AudioManager.Instance.Stop("SnowFootSteps");
        }

        //..Haven't reach the location yet, keep doing running animation;
        //Player is still moving..
        else
        {
            anim.SetBool("isRunning", true);

            //Only play audio sound if they're not already playing;
            if(!AudioManager.Instance.isPlaying("SnowFootSteps"))
            {
                //Foot Special Sounds..
                AudioManager.Instance.Play("SnowFootSteps");
            }
       
        }
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    if(col.gameObject.tag == "Enemy")

    //    {
    //        //Play Enemy Attack Animation..
    //        EController.Instance.attackingAnimation();

    //        //Setting Damage on Enemy Health
    //        StaminaBar.Instance.attackingPlayer();
    //    }

    //}

    //private void OnTriggerExit(Collider col)
    //{
    //    if(col.gameObject.tag == "Enemy")
    //    {
    //        //When Enemy exit Player collider, stop attack animation..
    //        EController.Instance.stoppingAttackAnimation();
    //    }
    //}

}