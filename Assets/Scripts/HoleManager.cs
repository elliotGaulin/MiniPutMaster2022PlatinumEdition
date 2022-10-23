using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPoint;
    public GameObject prototypePlayer;
    void Start()
    {
        GameObject player = Instantiate(prototypePlayer, startPoint.position, startPoint.rotation);
        player.GetComponentInChildren<Ball>().OnBallHit.AddListener(GameManager.instance.ballHit);
    }

    public void HoleOver()
    {
        Debug.Log("Hole Over");
        if(SceneManager.sceneCount == SceneManager.GetActiveScene().buildIndex)
        {
            GameManager.instance.GameOver();
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
