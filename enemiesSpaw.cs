using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpaw : MonoBehaviour
{
    public static enemiesSpaw Instance {get; set;}

    //Enemies reference..
    public GameObject enemies;
    //..References of the Spawner Points
    public Transform[] spawnPoints;

    //Wait timer.., 3.2 - 4.2 , 5.2, 10.4, 14.4f
    public float spawnTime = 17.2f;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //If player lifes is less than 0, don't respawn any enemies
        if(StaminaBar.Instance.maxHealth <= 0)
        {
            return;
        }
        //..Random spawn location in the Game
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Spawning enemy to desire random location.. 
        Instantiate(enemies, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
