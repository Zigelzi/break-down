using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 23, -12);

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = playerPosition + cameraOffset;
    }
}
