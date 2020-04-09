using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyWindZone : MonoBehaviour
{

    public Vector3 WindForce;

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(WindForce);
    }
}
