using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPresentsInstructions : MonoBehaviour
{
    //Access and Set variables on this class from other clases, OOP;
    public static GPresentsInstructions Instance {get; set;}

    //Getting animator Component;
    public Animator anim;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Getting Animator Component Reference; 
        anim = GetComponent<Animator>();
    }

    public void StopTextAnimation() {

        //Stopping Text Animation;
        anim.SetBool("ExitAnimation", true);
        anim.enabled = false;

    }
}
