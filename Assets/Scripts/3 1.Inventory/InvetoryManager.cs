using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject itemUIPrefab;
    public RectTransform inventoryPanel;
    public RectTransform dragLayer;

    public ScriptTooltip tooltip;

    private SlotManagerScript _draggingItem = null;
    public SlotManagerScript dragItem
    {
        get => _draggingItem;
        set => _draggingItem = value;
    }

    private InventorySlotsClass _selectedSlot = null;
    public InventorySlotsClass selectedSlot
    {
        get => _selectedSlot;
        set => _selectedSlot = value;
    }
    
    [SerializeField] private List<InventorySlotsClass> itemSlots = new List<InventorySlotsClass>();

    private void Start()
    {
        for(var i = 0;  i < itemSlots.Count; i++)
        {
            itemSlots[i].Init(this);
        }

        SetItem("Item2");
        SetItem("Item1");
    }

    public void SetItem(string itemName)
    {
        foreach (var itemSlot in itemSlots)
        {
            if (itemSlot.item == null)
            {
                GameObject tempItemUI = Instantiate(itemUIPrefab, itemSlot.transform);
                SlotManagerScript temp = tempItemUI.GetComponent<SlotManagerScript>();
                Item tempItemData = Resources.Load<Item>("Items/" + itemName);
                temp.Init(tempItemData, this, itemSlot);
                break;
            }
        }
    }
}
