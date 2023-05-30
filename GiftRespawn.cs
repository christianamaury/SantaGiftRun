using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftRespawn : MonoBehaviour
{
    public static GiftRespawn Instance {get; set;}

    public GameObject[] Gifts;
    private int countGifts;

    //Respawn Vector Positions where the gift should be respawning;
    private int xGiftPosition;
    private int zGiftPosition;
    private float yGiftPosition = 0.352f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnGifts());
    }

    IEnumerator RespawnGifts()
    {
       //Check for the countGifts amount, if less Than 10 Game Objects in the Scene.,.
       while(countGifts < 10)
        {
            xGiftPosition = Random.Range(-14, 14);
            zGiftPosition = Random.Range(-13, 13);

            int randomGift = Random.Range(0, Gifts.Length);
            GameObject randomGiftObject = Gifts[randomGift];

            //Instantiate game Object on the following Vectors;
            Instantiate(randomGiftObject, new Vector3(xGiftPosition, yGiftPosition, zGiftPosition), Quaternion.identity);
            yield return new WaitForSeconds(0.80f);
            countGifts = countGifts + 1;

            if(countGifts == 10)
            {
                countGifts = 0;
            }
        }

       
    }
}
