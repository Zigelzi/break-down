using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementAmount;
    [SerializeField] [Range(0, 10)] float cyclePeriod = 2f;
    const float tau = Mathf.PI * 2; // Radians - Number of radians in full turn around circle

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        float sinWave = CreateSinWave();
        float movementFactor = CreateMovementFactor(sinWave);

        Vector3 offSet = movementAmount * movementFactor;
        transform.position = startingPosition + offSet;
    }

    private float CreateMovementFactor(float sinWave)
    {
        /* Adjust the movement factor to Range(0, 1) to represent
         * 0 % movement and 100 % movement Sin wave varies between Range(-1, 1)
         * so move it to Range(0, 2).
         * Then divide it by 2 so it is at Range (0, 1)
        */
        float movementFactor = (sinWave + 1f) / 2f;
        return movementFactor;
    }

    private float CreateSinWave()
    {
        float cycles = Time.time / cyclePeriod;
        float rawSinWave = Mathf.Sin(cycles * tau);
        return rawSinWave;
    }
}
