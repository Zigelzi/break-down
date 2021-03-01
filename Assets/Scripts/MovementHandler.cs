using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [Header("Player attributes")]
    [Tooltip("In ms^-2")] [SerializeField] float movementSpeed = 10f;
    [SerializeField] float turnSpeed = 20f;

    [Header("Player components")]
    private Rigidbody playerRb;
    private PlayerManager playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerState = transform.parent.gameObject.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.gameState == PlayerManager.State.Alive)
        {
            HandleInput();
        }
        
    }

    private void HandleInput()
    {
        float rawHorizontalInput;
        float rawVerticalInput;

        // Check which axis should be used for movement
        // Primary is the large or small one, secondary is small two
        if (IsPrimaryObject())
        {
            rawHorizontalInput = Input.GetAxis("HorizontalPrimary");
            rawVerticalInput = Input.GetAxis("VerticalPrimary");
        } else
        {
            rawHorizontalInput = Input.GetAxis("HorizontalSecondary");
            rawVerticalInput = Input.GetAxis("VerticalSecondary");
        }
        

        float horizontalInput = rawHorizontalInput * Time.deltaTime;
        float verticalInput = rawVerticalInput * Time.deltaTime;

        MovePlayer(verticalInput);
        TurnPlayer(horizontalInput);
    }

    private void MovePlayer(float verticalInput)
    {
        Vector3 movementForce = new Vector3(verticalInput * movementSpeed, 0, 0);
        playerRb.AddRelativeTorque(movementForce, ForceMode.Impulse);
    }

    private void TurnPlayer(float horzintalInput)
    {
        playerRb.angularVelocity = Vector3.zero; // Remove unnecessary rotation due physics

        float rotationAmount = horzintalInput * turnSpeed;
        Vector3 rotationVector = new Vector3(0, rotationAmount, 0);
        gameObject.transform.Rotate(rotationVector, Space.World);
    }

    private bool IsPrimaryObject()
    {
        if (tag == "Player_Primary")
        {
            return true;
        } else
        {
            return false;
        }
    }
}
