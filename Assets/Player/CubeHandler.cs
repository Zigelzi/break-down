using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    // Player Cubes
    [Header("Player prefabs")]
    [Tooltip("Green")] [SerializeField] GameObject largePlayerCube;
    [Tooltip("Red")] [SerializeField] GameObject smallPlayerCubeOne;
    [Tooltip("Blue")] [SerializeField] GameObject smallPlayerCubeTwo;

    [Header("Cube properties")]
    public bool isCombined = true;
    [SerializeField] float xBounceAmout = 100f;
    [SerializeField] float yBounceAmout = 10;

    [SerializeField] Vector3 spawnOffset = new Vector3(2, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleAction();
    }

    private void HandleAction()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 parentGameObjectPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if (isCombined)
            {
                // Add offset to spawn position so cubes don't affect each other
                Vector3 offsetSpawnPosition = parentGameObjectPosition + spawnOffset;
                // Instantiate both cubes
                GameObject newCubeOne = Instantiate(smallPlayerCubeOne, parentGameObjectPosition, Quaternion.identity);
                GameObject newCubeTwo = Instantiate(smallPlayerCubeTwo, offsetSpawnPosition, Quaternion.identity);
                newCubeOne.transform.parent = gameObject.transform;
                newCubeOne.name = "PlayerCubeSmall_One";
                newCubeTwo.transform.parent = gameObject.transform;
                newCubeTwo.name = "PlayerCubeSmall_Two";

                // Destroy large cube
                GameObject largeCube = transform.Find("PlayerCubeLarge").gameObject;
                Destroy(largeCube);

                // Apply small force for bounce effect
                Vector3 bounceForceCubeOne = new Vector3(0, yBounceAmout, 0);
                Rigidbody newCubeOneRb = newCubeTwo.GetComponent<Rigidbody>();
                newCubeOneRb.AddForce(bounceForceCubeOne, ForceMode.Impulse);

                Vector3 bounceForceCubeTwo = new Vector3(xBounceAmout, yBounceAmout, 0);
                Rigidbody newCubeTwoRb = newCubeTwo.GetComponent<Rigidbody>();
                newCubeTwoRb.AddForce(bounceForceCubeTwo, ForceMode.Impulse);

                // Set the combine status to false
                isCombined = false;
            }
            else
            {
                // Instantiate new large cube
                GameObject newLargeCube = Instantiate(largePlayerCube, parentGameObjectPosition, Quaternion.identity);
                newLargeCube.transform.parent = gameObject.transform;
                newLargeCube.name = "PlayerCubeLarge";

                // Destroy small cubes
                GameObject smallCubeOne = transform.Find("PlayerCubeSmall_One").gameObject;
                GameObject smallCubeTwo = transform.Find("PlayerCubeSmall_Two").gameObject;
                Destroy(smallCubeOne);
                Destroy(smallCubeTwo);

                // Apply small force for bounce effect
                Vector3 bounceForce = new Vector3(0, xBounceAmout, 0);
                Rigidbody newLargeCubeRb = newLargeCube.GetComponent<Rigidbody>();
                newLargeCubeRb.AddForce(bounceForce, ForceMode.Impulse);

                // Set the combine status to false
                isCombined = true;
            }
        }
    }
        
}
