using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{

public int NumberOfBanana { get; private set; }

    public UnityEvent<PlayerInventory> OnBananaCollected;

    public void BananaCollected()
    {
        NumberOfBanana++;
        OnBananaCollected.Invoke(this);
    }
}
