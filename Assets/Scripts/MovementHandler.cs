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
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        float rawHorizontalInput = Input.GetAxis("Horizontal");
        float rawVerticalInput = Input.GetAxis("Vertical");

        float horizontalInput = rawHorizontalInput * Time.deltaTime;
        float verticalInput = rawVerticalInput * Time.deltaTime;

        MovePlayer(verticalInput);
        TurnPlayer(horizontalInput);
    }

    private void MovePlayer(float verticalInput)
    {
        Vector3 movementForce = new Vector3(0, 0, verticalInput * movementSpeed);
        playerRb.AddRelativeForce(movementForce, ForceMode.Impulse);
    }

    private void TurnPlayer(float horzintalInput)
    {
        playerRb.angularVelocity = Vector3.zero; // Remove unnecessary rotation due physics

        float rotationAmount = horzintalInput * turnSpeed;
        Vector3 rotationVector = new Vector3(0, rotationAmount, 0);
        gameObject.transform.Rotate(rotationVector);
    }
}
