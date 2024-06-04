using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private TextMeshProUGUI BananaText;
    // Start is called before the first frame update
    void Start()
    {
        BananaText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateBananaText(PlayerInventory playerInventory)
    {
        BananaText.text = playerInventory.NumberOfBanana.ToString();
    }

}
