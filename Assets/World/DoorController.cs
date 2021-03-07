using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject doorTriggerGameObject;
    [SerializeField] float openingSpeed = 2f;
    [SerializeField] bool doorAtUpperLimit = false;
    [SerializeField] bool doorAtLowerLimit = false;

    TriggerPlateController doorTrigger;

    // Start is called before the first frame update
    void Start()
    {
        doorTrigger = doorTriggerGameObject.GetComponent<TriggerPlateController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDoorMovement();
    }

    private void HandleDoorMovement()
    {
        if (!IsDoorAtUpperLimit() && doorTrigger.platePushed)
        {
            transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);
        } else if (!IsDoorAtLowerLimit())
        {
            transform.Translate(Vector3.down * openingSpeed * Time.deltaTime);
        }

    }

    private bool IsDoorAtUpperLimit()
    {
        float currentYPosition = transform.position.y;
        float doorHeight = transform.GetChild(0).localScale.y;

        if (currentYPosition >= doorHeight)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool IsDoorAtLowerLimit()
    {
        float currentYPosition = transform.position.y;

        if (currentYPosition <= 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
