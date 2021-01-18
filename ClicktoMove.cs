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
            //..Damage on the player
            //StaminaBar.Instance.damagePerWalking();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //..Player animation down here bro.., :D
                anim.SetBool("isRunning", true);

                //Foot Special Sounds..
                AudioManager.Instance.Play("DeepFootStep");

                //Stamina method call down here.. 

                agent.SetDestination(hit.point);
                
                

                //Manager method class down here..

            }
        }

        /*TESTING, Bugs #2

        #if UNITY_IOS || UNITY_ANDROID
        //..If we have at least one touch in the screen..
        if (Input.touches.Length != 0)
        {
            //..Current phase of the touch..
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                //Stamina method call down here..

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(startTouch);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    //..Playing animation for the player..
                    anim.SetBool("isRunning", true);

                    //Foot Special Sounds..
                    AudioManager.Instance.Play("DeepFootStep");

                    //..Moving the player to desired location..
                    agent.SetDestination(hit.point);

                    //..Manager Game.. Saving Score Data down here
                }
            }

            else {return;}
        }
        #endif
        */
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")

        {
            //Playing enemy animation..
            EController.Instance.attackingAnimation();
            //Damage on the player..
            StaminaBar.Instance.attackingPlayer();
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //..Testing aqui
            EController.Instance.stoppingAttackAnimation();
        }
    }

    //..Testing
    private void OnTriggerStay(Collider col)
    {
        
    }
}