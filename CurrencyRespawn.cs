using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyRespawn : MonoBehaviour
{
    public static CurrencyRespawn Instance {get; set;}

    public int currencyCount;
    public GameObject Currency;

    //Vectors Points..
    public int xCurrencyPosition;
    public int zCurrencyPosition;
    public float yCurrencyPosition = 0.12f;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CurrencyRespawner());
    }

    IEnumerator CurrencyRespawner()
    {
        while (currencyCount < 2)
        {
            xCurrencyPosition = Random.Range(-14, 14);
            zCurrencyPosition = Random.Range(-13, 13);

            //..Instantiate the GameObject
            Instantiate(Currency, new Vector3(xCurrencyPosition, yCurrencyPosition, zCurrencyPosition), Quaternion.identity);
            yield return new WaitForSeconds(2.97f);

            currencyCount = currencyCount + 1;

            if(currencyCount == 2)
            {
                currencyCount = 0;
            }
        }
    }
}
