using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Player Cubes
    [Header("Player prefabs")]
    [Tooltip("Green")] [SerializeField] GameObject largePlayerCubePrefab;
    [Tooltip("Red")] [SerializeField] GameObject smallPlayerCubeOnePrefab;
    [Tooltip("Blue")] [SerializeField] GameObject smallPlayerCubeTwoPrefab;

    // Existing cube references
    private GameObject largeCube;
    private GameObject smallCubeOne;
    private GameObject smallCubeTwo;

    [Header("Cube properties")]
    public bool isCombined = true;
    [SerializeField] float xBounceAmout = 100f;
    [SerializeField] float yBounceAmout = 10;

    [SerializeField] Vector3 spawnOffset = new Vector3(2, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        largeCube = transform.Find("PlayerCubeLarge").gameObject;
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
                SpawnSmallCubes(largeCube.transform.position);
                Destroy(largeCube);

                // Apply small force for bounce effect
                BounceCube(smallCubeOne, 0, yBounceAmout);
                BounceCube(smallCubeTwo, xBounceAmout, yBounceAmout);

                // Set the combine status to false
                isCombined = false;
            }
            else
            {
                SpawnLargeCube(smallCubeOne.transform.position);
                Destroy(smallCubeOne);
                Destroy(smallCubeTwo);

                // Apply small force for bounce effect
                BounceCube(largeCube, xBounceAmout, 0);
                
                // Set the combine status to false
                isCombined = true;
            }
        }
    }

    private void SpawnSmallCubes(Vector3 parentGameObjectPosition) {
        // Add offset to spawn position so cubes don't affect each other
        Vector3 offsetSpawnPosition = parentGameObjectPosition + spawnOffset;

        // Instantiate both cubes
        GameObject newCubeOne = Instantiate(smallPlayerCubeOnePrefab, parentGameObjectPosition, Quaternion.identity);
        newCubeOne.transform.parent = gameObject.transform;
        newCubeOne.name = "PlayerCubeSmall_One";
        smallCubeOne = newCubeOne;

        GameObject newCubeTwo = Instantiate(smallPlayerCubeTwoPrefab, offsetSpawnPosition, Quaternion.identity);
        newCubeTwo.transform.parent = gameObject.transform;
        newCubeTwo.name = "PlayerCubeSmall_Two";
        smallCubeTwo = newCubeTwo;
    }

    private void SpawnLargeCube(Vector3 parentGameObjectPosition)
    {
        GameObject newLargeCube = Instantiate(largePlayerCubePrefab, parentGameObjectPosition, Quaternion.identity);
        newLargeCube.transform.parent = gameObject.transform;
        newLargeCube.name = "PlayerCubeLarge";
        largeCube = newLargeCube;
    }

    private void BounceCube(GameObject targetCube, float xBounceAmount, float yBounceAmount)
    {
        Vector3 bounceForce = new Vector3(xBounceAmount, yBounceAmount, 0);
        Rigidbody cubeRb = targetCube.GetComponent<Rigidbody>();
        cubeRb.AddForce(bounceForce, ForceMode.Impulse);
    }

    public Vector3 GetCubePosition()
    {
        if (isCombined)
        {
            // If large cube, keep the Player gameobject at cube position, so that
            // splitting happens in correct place
            Vector3 largeCubePosition = largeCube.transform.position;
            return largeCubePosition;
        }
        else
        {
            // If two cubes, keep the gameobject in between the two cubes
            Vector3 smallCubeOnePosition = smallCubeOne.transform.position;
            Vector3 smallCubeTwoPosition = smallCubeTwo.transform.position;
            Vector3 middlePosition = smallCubeOnePosition - (smallCubeOnePosition - smallCubeTwoPosition) / 2;
            return middlePosition;
        }
    } 
}
