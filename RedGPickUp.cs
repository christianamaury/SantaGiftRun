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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //..Saving RedPresent Pickups
            GameM.Instance.redGiftCounts();

            //..Special Sound, Pickup
            AudioManager.Instance.Play("PickUpPresents");

            Destroy(gameObject);
        }
    }
}
