using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour
{

    private CanvasGroup fadedGroup;
    //..Track of it all time
    private float loadTime;

    //..In order to display the logo time properly
    private float minimumLogoTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        fadedGroup = FindObjectOfType<CanvasGroup>();
        //..Start with a white screen.
        fadedGroup.alpha = 1;

        //..In order to appreacite the logo
        if (Time.time < minimumLogoTime)
        {
            loadTime = minimumLogoTime;
        }
        else { loadTime = Time.time;}
    }

    // Update is called once per frame
    void Update()
    {
        fadingEffect();
    }

    public void fadingEffect()
    {
        //..Fade-in
        if(Time.time < minimumLogoTime)
        {
            fadedGroup.alpha = Time.time - minimumLogoTime;
        }

        if(Time.time > minimumLogoTime && loadTime != 0)
        {
            fadedGroup.alpha = Time.time - minimumLogoTime;
            if (fadedGroup.alpha >= 1)
            {
                //..Loading next Scene, Main Level
                SceneManager.LoadScene(1);
            }
        }
    }
}
