using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateHandler : MonoBehaviour
{
    public bool platePushed = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platePushed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platePushed = false;
        }
    }
}
