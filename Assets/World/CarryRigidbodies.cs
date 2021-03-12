using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRigidbodies : MonoBehaviour
{
    public List<Rigidbody> carriedRbs = new List<Rigidbody>();
    public Rigidbody ownRb;

    [SerializeField] bool useSensor = false;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        ownRb = GetComponent<Rigidbody>();

        if (useSensor)
        {
            foreach (CarryRigidbodiesSensor sensor in GetComponentsInChildren<CarryRigidbodiesSensor>())
            {
                sensor.carrier = this;
            }
        }
        
    }

    void LateUpdate()
    {
        MoveCarriedRigidbodies();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If using sensor, check for it's collision instead of the objects own collider
        if (useSensor) return;

        Rigidbody collidedRb = collision.collider.GetComponent<Rigidbody>();

        // Check that the other component has RigidBody component
        if (collidedRb != null)
        {
            Add(collidedRb);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If using sensor, check for it's collision instead of the objects own collider
        if (useSensor) return;

        Rigidbody collidedRb = collision.collider.GetComponent<Rigidbody>();

        // Check that the other component has RigidBody component
        if (collidedRb != null)
        {
            Remove(collidedRb);
        }
    }

    public void Add(Rigidbody rigidBody)
    {
        if (!carriedRbs.Contains(rigidBody))
        {
            carriedRbs.Add(rigidBody);
        }
    }

    public void Remove(Rigidbody rigidBody)
    {
        if (carriedRbs.Contains(rigidBody))
        {
            carriedRbs.Remove(rigidBody);
        }
    }

    private void MoveCarriedRigidbodies()
    {
        if (carriedRbs.Count > 0)
        {
            foreach (Rigidbody rb in carriedRbs)
            {
                Vector3 velocity = transform.position - lastPosition;
                rb.transform.Translate(velocity, transform);
                Debug.Log(velocity);
            }
        }

        lastPosition = transform.position;
    }


}
