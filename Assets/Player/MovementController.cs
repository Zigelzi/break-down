using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Player attributes")]
    [Tooltip("In ms^-2")] [SerializeField] float cubeMovementSpeed = 1000f;
    [Tooltip("In rad/s")] [Range(0.0f, 100f)][SerializeField] float turnSpeed = 20f;
    [Tooltip("In rad/s")] [Range(0.0f, 500f)][SerializeField] float maxSpeed = 100f;
    [SerializeField] bool useAngularVelocity = false;

    private Rigidbody cubeRb;
    private GameState gameState;
    private BoxCollider boxCollider;
    private CapsuleCollider capsuleCollider;

    private float movementThreshhold = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindWithTag("GameController").GetComponent<GameState>();

        cubeRb = GetComponent<Rigidbody>();
        cubeRb.maxAngularVelocity = maxSpeed;
        boxCollider = GetComponent<BoxCollider>();
        capsuleCollider = GetComponent<CapsuleCollider>();
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
        Vector2 playerInput;
        string cubeType = gameObject.tag;

        if (cubeType == "Player_Primary")
        {
            playerInput.x = Input.GetAxisRaw("HorizontalPrimary");
            playerInput.y = Input.GetAxisRaw("VerticalPrimary");
        } else
        {
            playerInput.x = Input.GetAxisRaw("HorizontalSecondary");
            playerInput.y = Input.GetAxisRaw("VerticalSecondary");
        }

        UpdateCollider();
        MoveCube(playerInput.y);
        TurnCube(playerInput.x);
    }

    private void MoveCube(float verticalInput)
    {
        verticalInput = verticalInput * Time.deltaTime;
        Vector3 movementForce = new Vector3(verticalInput * cubeMovementSpeed, 0, 0);
        cubeRb.AddRelativeTorque(movementForce, ForceMode.Impulse);
    }

    private void UpdateCollider()
    {
        if (CollidersExist())
        {
            if (IsMoving())
            {
                capsuleCollider.enabled = true;
                boxCollider.enabled = false;
            } else
            {
                capsuleCollider.enabled = false;
                boxCollider.enabled = true;
            }
        }
        
    }

    private bool IsMoving()
    {
        if (cubeRb.velocity.sqrMagnitude > movementThreshhold)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool CollidersExist()
    {
        if (boxCollider != null && capsuleCollider != null)
        {
            return true;
        } else
        {
            return false;
        }
    }

    

    private void TurnCube(float horzintalInput)
    {
        cubeRb.angularVelocity = Vector3.zero; // Remove unnecessary rotation due physics

        horzintalInput = horzintalInput * Time.deltaTime;
        float rotationAmount = horzintalInput * turnSpeed;
        Vector3 rotationVector = new Vector3(0, rotationAmount, 0);
        cubeRb.transform.Rotate(rotationVector, Space.World);
    }
}
