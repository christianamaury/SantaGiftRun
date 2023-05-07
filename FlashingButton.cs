using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To access the Button Reference
using UnityEngine.UI; 


public class FlashingButton : MonoBehaviour
{
    public Button uiButton;
    private Image buttonImage;

    //Original Button Color;
    private Color originalColor;

    //This is the time to interval the Flashing System;
    //Initial Value 0.05f;
    //1.0f = This interval time works decent
    private float flashInterval = 0.9f;

    //Count value to check if the Player has available potions
    private int count = 0;
    private int savedCount = 0;

    //Check if the image if flashing on and off
    private bool isFlashing = false;

  
    // Start is called before the first frame update
    void Start()
    {
        //Safety Check to prevent the NullReferenceException from being thrown
        //Potions Count variable from the Currency System;
        count = CurrencySystem.Instance.healthCount;

        //Already saved potions
        savedCount = PlayerPrefs.GetInt("HealthPotions", 0);

        //Getting Button Image Component from the Button..
        buttonImage = uiButton.GetComponent<Image>();

        //Assigning default color reference from the Image;
        originalColor = buttonImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Safety Check to prevent the NullReferenceException from being thrown
        //Potions Count variable from the Currency System;
        count = CurrencySystem.Instance.healthCount;

        //Already saved potions
        savedCount = PlayerPrefs.GetInt("HealthPotions", 0);

        //..Starting Flashing when count is greater than zero;
        //savedCount just to look for saved available potions for the player; 
        //!isFlashing is not false
        if (count > 0 && !isFlashing)
        {
            StartCoroutine(FlashButton());
        }
        else if (savedCount > 0 && !isFlashing)
        {
            StartCoroutine(FlashButton());
        }
        else if (count == 0 && isFlashing)
        {
            //Stopping Co-Routine;
            StopFlashing();
        }
        else if (savedCount == 0 && isFlashing)
        {
            //Stopping Co-Routine;
            StopFlashing();
        }

    }

    //Co-routine for the Flashing Functionality;
    public IEnumerator FlashButton()
    {
        isFlashing = true;
        //Light Red Color..
        Color lightRedColor = new Color(1f, 0f, 0f, 0.5f);

        while (isFlashing)
        {

            //Changing Colors;
            buttonImage.color = lightRedColor;
            Debug.Log("Flashing Lights On and On"); 

            //Wait for the following amount of seconds before changing: 0.05f;
            yield return new WaitForSeconds(flashInterval);

            //Changing Color back to Default color;
            buttonImage.color = originalColor;

            //Wait for the following amount of seconds before changing: 0.05f;
            yield return new WaitForSeconds(flashInterval);

        }
    }

    //..Method to Flashing;
    public void StopFlashing()
    {
        //..Changing Variable to False;
        isFlashing = false;

        //Resetting imaging color;
        buttonImage.color = originalColor;
        StopCoroutine(FlashButton());

    }
}
