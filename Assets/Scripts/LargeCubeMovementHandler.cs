using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCubeMovementHandler : MonoBehaviour
{
    [Header("Player attributes")]
    [Tooltip("In ms^-2")] [SerializeField] float cubeMovementSpeed = 1000f;
    [SerializeField] float turnSpeed = 20f;

    [SerializeField] private GameObject largeCube;
    [SerializeField] private Rigidbody largeCubeRb;

    private PlayerManager playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponent<PlayerManager>();
        largeCube = transform.Find("PlayerCubeLarge").gameObject;
        largeCubeRb = largeCube.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.gameState == PlayerManager.State.Alive && largeCube != null)
        {
            HandleInput();
        }
        
    }

    private void HandleInput()
    {
        float rawHorizontalInput = Input.GetAxis("HorizontalPrimary"); ;
        float rawVerticalInput = Input.GetAxis("VerticalPrimary");

        float horizontalInput = rawHorizontalInput * Time.deltaTime;
        float verticalInput = rawVerticalInput * Time.deltaTime;

        MoveCube(verticalInput);
        TurnPlayer(horizontalInput);
    }

    private void MoveCube(float verticalInput)
    {
        Vector3 movementForce = new Vector3(verticalInput * cubeMovementSpeed, 0, 0);
        largeCubeRb.AddRelativeTorque(movementForce, ForceMode.Impulse);
    }

    private void TurnPlayer(float horzintalInput)
    {
        largeCubeRb.angularVelocity = Vector3.zero; // Remove unnecessary rotation due physics

        float rotationAmount = horzintalInput * turnSpeed;
        Vector3 rotationVector = new Vector3(0, rotationAmount, 0);
        largeCube.transform.Rotate(rotationVector, Space.World);
    }
}
