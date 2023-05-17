using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickUp : MonoBehaviour
{
    public static CoinsPickUp Instance {get; set;}

    private void Awake()
    {
        Instance = this; 
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //..Add Coins into the system..
            CurrencySystem.Instance.PickUpCoins();

            //Special sound effect for the pick up..

            //..Destroy this GameObject afterpickUp
            Destroy(gameObject);
        }
    }
}
