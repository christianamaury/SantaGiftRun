using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOTextAnimator : MonoBehaviour
{
    public static GOTextAnimator Instance {get; set;}
    private Animator anim;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //This would ignore when the game is fully paused;
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTextAnimation()
    {

        //Activating the Animator on the Game Over Menu; 
        anim.SetTrigger("GameOver");
    }
}
