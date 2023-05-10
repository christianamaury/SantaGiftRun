using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to Animate the Game Instructions Text;
public class GameInstruction : MonoBehaviour
{
    public static GameInstruction Instance {get; set;}
    private Animator anim;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopAnimatingText()
    {
        //Exit out the Text Animation; 
        anim.SetTrigger("GameInstructionsExit");
        anim.SetBool("ExitAnimation", true);
    }
}
