using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private float levelLoadDelay = 1f;

    // Game State
    enum State { Alive, Died, Transcending }
    State gameState = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameState != State.Alive)
        {
            /* 
             * Prevent processing any additional collisions when not alive
             * or when collisions are disabled for debugging
             */
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Level Complete!");
                break;
            default:
                break;
        }
    }
}
