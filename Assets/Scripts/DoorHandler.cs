using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] GameObject doorTriggerGameObject;
    [SerializeField] float openingSpeed = 2f;
    [SerializeField] bool moveDown = false;

    private float startYPosition;
    TriggerPlateHandler doorTrigger;

    // Start is called before the first frame update
    void Start()
    {
        startYPosition = transform.position.y;
        doorTrigger = doorTriggerGameObject.GetComponent<TriggerPlateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDoor();
    }

    private void MoveDoor()
    {
        float doorHeight = transform.GetChild(0).localScale.y;
        float currentYPosition = transform.position.y;

        float positionDifference = startYPosition - currentYPosition;
        if (positionDifference > doorHeight)
        {
            moveDown = false;
        } else if (positionDifference <= 0)
        {
            moveDown = true;
        }
        if (moveDown && doorTrigger.platePushed)
        {
            transform.Translate(Vector3.down * openingSpeed * Time.deltaTime);
        } else if (!moveDown && !doorTrigger.platePushed)
        {
            transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);
        }
        
        
    }
}
