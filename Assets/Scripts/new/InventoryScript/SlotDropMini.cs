using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class SlotDropMini : MonoBehaviour, IDropHandler
{
    // 자신에게 드롭된 슬롯이 있을 때 그 슬롯과 자신의 아이템 정보를 바꿈.

    private MiniInventorySlot slot;

    private void Start()
    {
        slot = GetComponent<MiniInventorySlot>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        var temp = this.slot.slotItem;
        if(GameData.droppedObejct != null)
        {
            if (GameData.droppedObejct.GetComponent<InventorySlotsClass>() != null)
            {
                this.slot.slotItem = GameData.droppedObejct.GetComponent<InventorySlotsClass>().slotItem;
                GameData.droppedObejct.GetComponent<InventorySlotsClass>().slotItem = temp;
            }
            else
            {
                this.slot.slotItem = GameData.droppedObejct.GetComponent<MiniInventorySlot>().slotItem;
                GameData.droppedObejct.GetComponent<MiniInventorySlot>().slotItem = temp;
            }
        }
        
        GameData.droppedObejct = null;
    }
}
