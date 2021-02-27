using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [Header("Player attributes")]
    [Tooltip("In ms^-2")] [SerializeField] float movementSpeed = 10f;
    [SerializeField] float horizontalMovement;
    [SerializeField] float verticalMovement;
    [SerializeField] Vector3 movementVector;

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

        float horizontalInput = rawHorizontalInput * movementSpeed * Time.deltaTime;
        float verticalInput = rawVerticalInput * movementSpeed * Time.deltaTime;

        MovePlayer(horizontalInput, verticalInput);
    }

    private void MovePlayer(float horizontalInput, float verticalInput)
    {
        // TODO: Fix movement being on global axis, not on local axis
        Vector3 turnForce = new Vector3(verticalInput, 0, -horizontalInput);
        Vector3 movementForce = new Vector3(0, 0, verticalInput);
        playerRb.AddForce(movementForce, ForceMode.Impulse);
        playerRb.AddTorque(turnForce, ForceMode.Impulse);
    }
}
