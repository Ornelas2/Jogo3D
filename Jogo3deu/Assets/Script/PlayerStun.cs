using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour
{
    private float stunDuration = 3.0f;
    private bool isStunned = false;
    private float stunTimer = 0.0f;

    void Update()
    {
        if (isStunned)
        {
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunDuration)
            {
                isStunned = false;
                Debug.Log("Player unstunned.");
                stunTimer = 0.0f;
            }
        }
    }

    public void Stun()
    {
        isStunned = true;
        stunTimer = 0.0f;
        Debug.Log("Player is stunned for " + stunDuration + " seconds.");
    }

    public bool IsStunned()
    {
        return isStunned;
    }
}