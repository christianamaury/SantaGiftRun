using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGPickUp : MonoBehaviour
{
    public static GreenGPickUp Instance {get; set;}

    private void Awake()
    {
        Instance = this; 
    }
 
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //..Saving Green Pickup Count
            GameM.Instance.greenGiftCounts();

            //..Sound Effect for it
            AudioManager.Instance.Play("PickUpPresents");

            //..Destroying game object
            Destroy(gameObject);
        }
    }
}
