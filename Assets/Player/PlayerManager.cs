using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameStateHandler gameManager;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameStateHandler>();
        levelManager = gameManager.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider trigger)
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameManager.gameState != GameStateHandler.State.Alive)
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
                gameManager.gameState = GameStateHandler.State.Transcending;
                levelManager.LoadNextLevel();
                break;
            default:
                break;
        }
    }
}
