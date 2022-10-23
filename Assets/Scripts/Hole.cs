using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Hole : MonoBehaviour
{
    //public delegate void HoleEventHandler();
    //public event HoleEventHandler OnBallEnterHole;

    public UnityEvent OnBallEnterHole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnBallEnterHole?.Invoke();
        }
    }
}
