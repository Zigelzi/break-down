using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private LevelManager levelManager;

    // Game State
    public enum State { Alive, Died, Transcending }
    public State gameState = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
