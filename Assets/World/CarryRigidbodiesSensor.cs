using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRigidbodiesSensor : MonoBehaviour
{
    public CarryRigidbodies carrier;

    void Start()
    {
        carrier = transform.parent.GetComponent<CarryRigidbodies>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody carriedRb = other.GetComponent<Rigidbody>();
        if (carriedRb != null && carriedRb != carrier.ownRb)
        {
            carrier.Add(carriedRb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody carriedRb = other.GetComponent<Rigidbody>();
        if (carriedRb != null && carriedRb != carrier.ownRb)
        {
            carrier.Remove(carriedRb);
        }
    }
}
