using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour
{

    private CanvasGroup fadedGroup;
    //Track "All Time" loading period;
    private float loadTime;

    //In order to display the logo time properly;
    private float minimumLogoTime = 3.0f;

    //Start is called before the first frame update
    void Start()
    {
        fadedGroup = FindObjectOfType<CanvasGroup>();

        //Start with a white screen..
        fadedGroup.alpha = 1;

        //If statement related to the minimum time to check for the logo; 
        if (Time.time < minimumLogoTime)
        {
            loadTime = minimumLogoTime;
        }
        else { loadTime = Time.time;}
    }

    // Update is called once per frame
    void Update()
    {
        //Calling Function;
        fadingEffect();
    }

    public void fadingEffect()
    {
        //Fade-in Effect..
        if(Time.time < minimumLogoTime)
        {
            fadedGroup.alpha = Time.time - minimumLogoTime;
        }

        if(Time.time > minimumLogoTime && loadTime != 0)
        {
            fadedGroup.alpha = Time.time - minimumLogoTime;
            if (fadedGroup.alpha >= 1)
            {
                //Loading next Scene which is the Main Level Scene;
                SceneManager.LoadScene(1);
            }
        }
    }
}
