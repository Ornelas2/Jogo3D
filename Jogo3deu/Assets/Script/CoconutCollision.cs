using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Coconut collided with: " + collision.collider.name);
        if (collision.collider.CompareTag("Player"))
        {
            PlayerStun playerStun = collision.collider.GetComponent<PlayerStun>();
            if (playerStun != null)
            {
                Debug.Log("Player stunned");
                playerStun.Stun();
            }

            // Optionally, destroy the coconut or disable it after hitting the player
            Destroy(gameObject);
        }
    }
}
