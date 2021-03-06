using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    private LevelManager levelManager;

    // Game State
    public enum State { Alive, Died, Transcending }
    public State gameState = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = gameManager.GetComponent<LevelManager>();
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
                gameState = State.Transcending;
                levelManager.LoadNextLevel();
                break;
            default:
                break;
        }
    }
}
