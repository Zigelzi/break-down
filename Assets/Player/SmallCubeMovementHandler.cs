using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCubeMovementHandler : MonoBehaviour
{
    [Header("Player attributes")]
    [Tooltip("In ms^-2")] [SerializeField] float cubeMovementSpeed = 2000f;
    private GameObject smallCubeOne;
    private GameObject smallCubeTwo;

    private PlayerManager playerState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool IsPrimaryObject(GameObject cube)
    {
        if (cube.tag == "Player_Primary")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
