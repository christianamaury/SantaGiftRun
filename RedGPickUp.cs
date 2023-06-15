using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGPickUp : MonoBehaviour
{
    public static RedGPickUp Instance {get; set;}

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Saving RedPresent Pickups..
            GameM.Instance.redGiftCounts();

            //Special PickUp Sounds;
            AudioManager.Instance.Play("PickUpPresents");

            Destroy(gameObject);
        }
    }
}
