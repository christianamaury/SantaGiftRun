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

    //Reference of the Armor Health Points,..
    public float armorHealthPoints = 15.5f;

    //Health variables;
    public float maxHealth = 100f;
    public float healthPoints = 15.5f;

    //Damage Variables;
    public float damagePerWalk = 0.1f;
    public float testingDamage = 0.02f;

    //This value works fine on the Unity Editor, but it takes too much Damage on Mobile
    //0.01f;
    public float enemyDamage = 0.006f;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Health Bar;
        healthBar.maxValue = maxHealth;

        //Armor Bar..
        armorBar.maxValue = maxArmorHealth;

        CurrencySystem.Instance.armorCount = PlayerPrefs.GetInt("ArmorPotions");
        CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions");
        
    }

    public void GrantArmorHealth()
    {

        if(CurrencySystem.Instance.armorCount > 0)

        {
            //Drinking Armor Potion Sound Effect;
            AudioManager.Instance.Play("PotionsDrink");

            maxArmorHealth = maxArmorHealth + armorHealthPoints;

            //Updating Armor Bar Health Slide Bar;
            armorBar.value = maxArmorHealth;

            CurrencySystem.Instance.armorCount = PlayerPrefs.GetInt("ArmorPotions", 0);
            CurrencySystem.Instance.armorCount = CurrencySystem.Instance.armorCount - 1;
            CurrencySystem.Instance.armorPotionsTextCount.text = CurrencySystem.Instance.armorCount.ToString();

            if (CurrencySystem.Instance.armorCount < PlayerPrefs.GetInt("ArmorPotions", 0))
            {
                //Setting up Potions Available..
                PlayerPrefs.SetInt("ArmorPotions", CurrencySystem.Instance.armorCount);

                //Updating Text Count;
                CurrencySystem.Instance.armorPotionsTextCount.text = PlayerPrefs.GetInt("ArmorPotions", 0).ToString();

            }

            if (maxArmorHealth >= 50f)
            {
                armorBar.value = maxArmorHealth;
            }

        }

    }

    public void GrantHealth()
    {
        if(CurrencySystem.Instance.healthCount > 0)

        {
            //Drinking Health Potion Sound Effect;
            AudioManager.Instance.Play("PotionsDrink");
            
            maxHealth = maxHealth + healthPoints;

            //Updating Health Bar Slider Bar..
            healthBar.value = maxHealth;

            CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);
            CurrencySystem.Instance.healthCount = CurrencySystem.Instance.healthCount - 1;
            CurrencySystem.Instance.healthPotionsCount.text = CurrencySystem.Instance.healthCount.ToString();

            if (CurrencySystem.Instance.healthCount < PlayerPrefs.GetInt("HealthPotions", 0))
            {
                //Setting up available Potions;
                PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);

                //Updating Text Count;
                CurrencySystem.Instance.healthPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();
            }

            if (maxHealth >= 50f)
            {
                healthBar.value = maxHealth;
            }
        }

    }

    public void damagePerWalking()
    {
        maxHealth = maxHealth - damagePerWalk;

        //Updating Health slider..
        healthBar.value = maxHealth;

        //I can stop playing the game background music in the if statement, eventually..
        if(maxHealth <= 0)
        {
            //Game Over, Load Game Menu..
            RestartLevel.Instance.showingRestartMenu();
        }
    }

    public void attackingPlayer()
    {
        //Check 1st on the Armor Bar;
        if(maxArmorHealth > 0)
        {
            maxArmorHealth = maxArmorHealth - enemyDamage;

            //Update the Armor Bar;
            armorBar.value = maxArmorHealth;
        }

        if (maxArmorHealth <= 0)
        {
            maxHealth = maxHealth - enemyDamage;

            //Updating Health Bar..
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
            //Load Game Menu..,
            RestartLevel.Instance.showingRestartMenu();
        }
    }

}
