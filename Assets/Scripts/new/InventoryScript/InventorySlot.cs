using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    // ���� �������� ������ ����� ǥ���ϰ�
    // Ŭ���ϸ� �ش� ������ 3D ������Ʈ �����ϴ� ��.

    [SerializeField] UnityEngine.UI.Image slotImage;
    public TextMeshProUGUI text;

    private Item abc;

    public Item slotItem
    {
        get
        {
            return abc;
        }
        set
        {
            abc = value;
            if(abc != null)
            {
                slotImage.sprite = abc.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    private void Update()
    {
        if(abc != null)
        {
            if (abc.amount >= 2)
                text.text = slotItem.amount.ToString();
            else
                text.text = null;
        }
        else
        {
            text.text = null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(abc != null)
        {
            if(GameData.objectShowed != null)
            {
                Destroy(GameData.objectShowed);
            }
            GameData.objectShowed = Instantiate<GameObject>(slotItem.itemGameObject, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}