using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Player attributes")]
    [Tooltip("In ms^-2")] [SerializeField] float cubeMovementSpeed = 1000f;
    [SerializeField] float turnSpeed = 20f;
    [Tooltip("In rad/s")] [Range(0.0f, 500f)][SerializeField] float maxSpeed = 100f; 

    private Rigidbody cubeRb;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindWithTag("GameController").GetComponent<GameState>();

        cubeRb = GetComponent<Rigidbody>();
        cubeRb.maxAngularVelocity = maxSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.gameState == GameState.State.Alive)
        {
            HandleInput();
        }
        
    }

    private void HandleInput()
    {
        float rawHorizontalInput;
        float rawVerticalInput;

        string cubeType = gameObject.tag;

        if (cubeType == "Player_Primary")
        {
            rawHorizontalInput = Input.GetAxisRaw("HorizontalPrimary");
            rawVerticalInput = Input.GetAxisRaw("VerticalPrimary");
        } else
        {
            rawHorizontalInput = Input.GetAxisRaw("HorizontalSecondary");
            rawVerticalInput = Input.GetAxisRaw("VerticalSecondary");
        }

        float horizontalInput = rawHorizontalInput * Time.deltaTime;
        float verticalInput = rawVerticalInput * Time.deltaTime;

        MoveCube(verticalInput);
        TurnPlayer(horizontalInput);
    }

    private void MoveCube(float verticalInput)
    {
        Vector3 movementForce = new Vector3(verticalInput * cubeMovementSpeed, 0, 0);
        cubeRb.AddRelativeTorque(movementForce, ForceMode.Impulse);
    }

    private void TurnPlayer(float horzintalInput)
    {
        cubeRb.angularVelocity = Vector3.zero; // Remove unnecessary rotation due physics

        float rotationAmount = horzintalInput * turnSpeed;
        Vector3 rotationVector = new Vector3(0, rotationAmount, 0);
        cubeRb.transform.Rotate(rotationVector, Space.World);
    }
}
