using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameState gameState;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindWithTag("GameController").GetComponent<GameState>();
        levelManager = gameState.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathArea")
        {
            levelManager.RestartGameAfterDelay();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameState.gameState != GameState.State.Alive)
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
                gameState.gameState = GameState.State.Transcending;
                levelManager.LoadNextLevel();
                break;
            default:
                break;
        }
    }
}
