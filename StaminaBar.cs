using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public static StaminaBar Instance {get; set;}

    public Slider healthBar;
    public Slider armorBar;

    public float maxArmorHealth = 50f;

    //..Reference of the Armor Health Points,
    public float armorHealthPoints = 15.5f;

    public float maxHealth = 50f;
    //..12.5f, 15.5
    public float healthPoints = 15.5f;

    //Previosly., 5 - 2.2, 1.7f, 0.9f, 0.4
    public float damagePerWalk = 0.1f;
    public float testingDamage = 0.1f;

    //..2.3f 2.1, 1.3f (pero lo cambio porque use OnTriggerEnter)
    //..Ahora como arregle bug y puse OnTrigger enter en el enemy class, baja el damage
    public float enemyDamage = 0.1f;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //..Health Bar
        healthBar.maxValue = maxHealth;

        //..Armor Bar..
        armorBar.maxValue = maxArmorHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrantArmorHealth()
    {
        maxArmorHealth = maxArmorHealth + armorHealthPoints;

        //..Updating Armor Bar Health Slide Bar
        armorBar.value = maxArmorHealth;

        if (maxArmorHealth >= 50f)
        {
            armorBar.value = maxArmorHealth;
        }
    }

    public void GrantHealth()
    {
        maxHealth = maxHealth + healthPoints;

      
        //..Updating Health Bar Slider Bar..
        healthBar.value = maxHealth;

        if(maxHealth >= 50f)
        {
            healthBar.value = maxHealth;
        }
    }

    public void damagePerWalking()
    {
        maxHealth = maxHealth - damagePerWalk;

        //Updating Health slider..
        healthBar.value = maxHealth;

        if(maxHealth <= 0)
        {
            //..Stop playing background music, maybe

            //..Game Over, Load Game Menu..
            RestartLevel.Instance.showingRestartMenu();
        }
    }

    public void attackingPlayer()
    {
        /*
        maxHealth = maxHealth - enemyDamage;

        //Updating Health Slider..
        healthBar.value = maxHealth;
        if(maxHealth <= 0)
        {
            //..Stop playing the music in the background

            //..Load Game Menu
            RestartLevel.Instance.showingRestartMenu();
        }
        */


        //..First check on Armor Bar
        if(maxArmorHealth > 0)
        {
            maxArmorHealth = maxArmorHealth - enemyDamage;

            //..Update the Armor Bar
            armorBar.value = maxArmorHealth;
           
        }

        if (maxArmorHealth <= 0)
        {
            maxHealth = maxHealth - enemyDamage;

            //..Updating Health Bar..
            healthBar.value = maxHealth;

            if(maxHealth <=0)
            {
                RestartLevel.Instance.showingRestartMenu();
            }
        }
    }

    public void attakingArea()
    {
        maxHealth = maxHealth - testingDamage;
        healthBar.value = maxHealth;
        if(maxHealth <= 0)
        {
            //..Load Game Menu
            RestartLevel.Instance.showingRestartMenu();
        }
    }

    /*
    public void setHealth(int health)
    {
        slider.value = health;
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health; 
    }
    */
}
