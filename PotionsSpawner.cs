using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsSpawner : MonoBehaviour
{
    public static PotionsSpawner Instance {get; set;}

    public int randomPotion;
    public int potionsCount;
    public GameObject [] Potions;

    //..Vectors
    public int xPotionsPosition;
    public int zPotionsPosition;
    public float yPotionsPotion = 0.352f;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnPotions());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RespawnPotions()
    {
        //..Previous sly 
        while (potionsCount < 1)
        {
            xPotionsPosition = Random.Range(-14, 14);
            zPotionsPosition = Random.Range(-13, 13);

            randomPotion = Random.Range(0, Potions.Length);
            GameObject randomObject = Potions[randomPotion];

            //..Instantiate the GameObject..
            Instantiate(randomObject, new Vector3(xPotionsPosition, yPotionsPotion, zPotionsPosition), Quaternion.identity);
            yield return new WaitForSeconds(14.86f);

            potionsCount = potionsCount + 1;

            if (potionsCount == 1)
            {
                potionsCount = 0;
            }
        }
    }
}
