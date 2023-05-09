using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To access the Button Reference
using UnityEngine.UI;

public class armorFlashingButton : MonoBehaviour
{

    public Button uiArmorButton;
    private Image armorButtonImage;

    //Original Button Color;
    private Color originalColor;

    //This is the time to interval the Flashing System;
    //Initial Value 0.05f;
    //1.0f = This interval time works decent
    private float flashInterval = 0.9f;

    //Count value to check if the Player has available potions
    private int armorCount = 0;
    private int armorSavedCount = 0;

    //Check if the image if flashing on and off
    private bool isFlashingAmor = false;

    // Start is called before the first frame update
    void Start()
    {
        //Safety Check to prevent the NullReferenceException from being thrown;
        //Armor Count;
        armorCount = CurrencySystem.Instance.armorCount;

        //Armor Saved Count;
        armorSavedCount = PlayerPrefs.GetInt("ArmorPotions", 0);

        //Getting Button Image Component from the Armor Button;
        armorButtonImage = uiArmorButton.GetComponent<Image>();

        //Assigning default color reference from the Image;
    
        originalColor = armorButtonImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Safety Check to prevent the NullReferenceException from being thrown
        //Potions Count variable from the Currency System;
   
        //Armor Count;
        armorCount = CurrencySystem.Instance.armorCount;

        //Armor Saved Count;
        armorSavedCount = PlayerPrefs.GetInt("ArmorPotions", 0);

        //If Check Logic for the Flashing Effect
        armorPotionsCheckEffect();

    }

    private void armorPotionsCheckEffect()
    {

        //..Starting Flashing when count is greater than zero;
        //savedCount just to look for saved available potions for the player; 
        //!isFlashing is not false

        if (armorCount > 0 && !isFlashingAmor)
        {
            StartCoroutine(ArmorFlashButton());
        }

        else if (armorSavedCount > 0 && !isFlashingAmor)
        {
            StartCoroutine(ArmorFlashButton());
        }

        else if (armorCount == 0 && isFlashingAmor)
        {
            StopFlashingArmor();
        }

        else if (armorSavedCount == 0 && isFlashingAmor)
        {
            StopFlashingArmor();
        }
    }

    public IEnumerator ArmorFlashButton()
    {

        isFlashingAmor = true;

        //Light Blue Color;
        Color lightBlueColor = new Color(0f, 0f, 1f, 0.5f);

        while (isFlashingAmor)
        {
            //Changing Colors;
            armorButtonImage.color = lightBlueColor;

            //Wait for the following amount of seconds before changing 0.9f;
            yield return new WaitForSeconds(flashInterval);

            //Changing Colors again, Original Color;
            armorButtonImage.color = originalColor;

            //Wait for the following amount of seconds before changing 0.9f;
            yield return new WaitForSeconds(flashInterval);
        }
    }

    public void StopFlashingArmor()
    {
        //Changing Variable value;
        isFlashingAmor = false;

        //Resetting imaging color;
        armorButtonImage.color = originalColor;
        StopCoroutine(ArmorFlashButton());
    }
}
