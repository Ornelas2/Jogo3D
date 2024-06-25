using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutDrop : MonoBehaviour
{
    public Rigidbody coconutRigidbody;
    private bool coconutDropped = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        if (other.CompareTag("Player") && !coconutDropped)
        {
            Debug.Log("Player entered the trigger zone. Dropping coconut.");
            coconutRigidbody.isKinematic = false;
            coconutDropped = true;
        }
    }
}
