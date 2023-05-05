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
    public float flashInterval = 0.05f;

    //Count value to check if the Player has available potions
    public int count = 0;

    //Check if the image if flashing on and off
    private bool isFlashing = false;

    public void Awake()
    {
        //Potions Count variable from the Currency System;
        count = CurrencySystem.Instance.healthCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Getting Button Image Component from the Button..
        buttonImage = uiButton.GetComponent<Image>();

        //Assigning default color reference from the Image;
        originalColor = buttonImage.color; 


    }

    // Update is called once per frame
    void Update()
    {
        //Start flashing on and off color on the image;

    }

    //Co-routine for the Flashing Functionality;
    private IEnumerator FlashButton()
    {
        isFlashing = true;
        //Light Red Color..
        Color lightRedColor = new Color(1f, 0f, 0f, 0.5f);

        while (isFlashing)
        {

            //Changing Colors;
            buttonImage.color = lightRedColor;

            //Wait for the following amount of seconds before changing: 0.05f;
            yield return new WaitForSeconds(flashInterval);

            //Changing Color back to Default color;
            buttonImage.color = originalColor;

            //Wait for the following amount of seconds before changing: 0.05f;
            yield return new WaitForSeconds(flashInterval);

        }
    }

    


}
