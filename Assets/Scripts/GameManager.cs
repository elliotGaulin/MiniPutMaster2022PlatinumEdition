using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class used for managing scores and the game's progression
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ballHit()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
