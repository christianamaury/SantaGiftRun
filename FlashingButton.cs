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
    private bool isFloating = false;

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

    


}
