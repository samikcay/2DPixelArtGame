using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // List of items
    public List<PassiveItem> passiveItems = new();

    // Keeps track of which ScriptableObject corresponds to which instantiated GameObject
    private Dictionary<PassiveItem, GameObject> activeItemObjects = new();

    private void Start()
    {
        
    }

    public void EquipThisItem(PassiveItem pI)
    {
        if (activeItemObjects.ContainsKey(pI))
        {
            return;
        }
        GameObject itemObject = Instantiate(pI.itemPrefab, transform);

        passiveItems.Add(pI);
        activeItemObjects.Add(pI, itemObject);
        Debug.Log($"{pI.itemName} is equipped.");
    }

    public void UnequipThisItem(PassiveItem pI)
    {
        if (activeItemObjects.TryGetValue(pI, out GameObject itemObject))
        {
            Destroy(itemObject);
            passiveItems.Remove(pI);
            activeItemObjects.Remove(pI);
            Debug.Log($"{pI.itemName} is unequipped.");
        }
    }
}
