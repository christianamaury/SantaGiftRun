using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices Instance {get; set;}

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //TestingSingleton();
    }

    private void TestingSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderboard(int score)
    {
        Leaderboards.highScore.SubmitScore(score);

    }
}
