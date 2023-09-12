using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTesting : MonoBehaviour
{
    [System.Serializable]
    public struct AddItem
    {

    }
    [SerializeField] private List<AddItem> addItems;
    private void Update()
    {
        foreach (AddItem item in addItems)
        {

        }
    }
}
