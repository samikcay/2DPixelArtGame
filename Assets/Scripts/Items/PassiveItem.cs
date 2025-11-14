using UnityEngine;

[CreateAssetMenu(fileName = "New Passive Item", menuName = "Items/Passive Item")]
public class PassiveItem : ScriptableObject
{
    [Header("Eþya Bilgileri")]
    public string itemName;
    public string description;
    public int itemLevel = 1;
    public Sprite icon;

    [Header("Eþya objesi")]
    public GameObject itemPrefab;

}
