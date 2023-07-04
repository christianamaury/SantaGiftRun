using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGPickUp : MonoBehaviour
{
    public static YellowGPickUp Instance {get; set;}

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Saving Gift Counts for the Yellow present;
            GameM.Instance.yellowGiftCounts();

            //Pick Gift Sound..
            AudioManager.Instance.Play("PickUpPresents");

            Destroy(gameObject);
        }
    }
}
