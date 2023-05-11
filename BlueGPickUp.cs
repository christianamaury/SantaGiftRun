using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGPickUp : MonoBehaviour
{
    public static BlueGPickUp Instance {get; set;}

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //..Saving Gift Count
            GameM.Instance.blueGiftCounts();

            //..Special sound, Pick up
            AudioManager.Instance.Play("PickUpPresents");

            //Destroying object from the scene..
            Destroy(gameObject);
        }
    }
}
