using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 23, -12);
    CubeController cubeController;

    void Start()
    {
        cubeController = GetComponentInParent<CubeController>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 cubePosition = cubeController.GetCubePosition();

        // Remove the bouncing from player movement
        Vector3 stabilisedCubePosition = new Vector3(cubePosition.x, 0, cubePosition.z);
        transform.position = stabilisedCubePosition + cameraOffset;
    }
}
