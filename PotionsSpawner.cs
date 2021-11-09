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
        while (potionsCount < 2)
        {
            xPotionsPosition = Random.Range(-14, 14);
            zPotionsPosition = Random.Range(-13, 13);

            randomPotion = Random.Range(0, Potions.Length);
            GameObject randomObject = Potions[randomPotion];

            //..Instantiate the GameObject..
            Instantiate(randomObject, new Vector3(xPotionsPosition, yPotionsPotion, zPotionsPosition), Quaternion.identity);
            yield return new WaitForSeconds(1.95f);

            potionsCount = potionsCount + 1;

            if (potionsCount == 3)
            {
                potionsCount = 0;
            }
        }
    }
}
