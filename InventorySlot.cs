using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Script Slot Item.
public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Inventory removeItem;

    Item item;

    public Image itemImage;
    public Text quantity;

    public Rigidbody GameOBJprefabs;
    public Transform shootPoint;

    private void Start()
    {
        removeItem = GetComponent<Inventory>();
    }

    //Function to get item and amount to enter the inventory
    public void UpdateSlot(Item itemInSlot, int quantityInSlot)
    {
        item = itemInSlot;

        if (itemInSlot != null && quantityInSlot != 0)
        {
            itemImage.enabled = true;

            itemImage.sprite = itemInSlot.itemIcon;

            if (quantityInSlot > 1)
            {
                quantity.enabled = true;
                quantity.text = quantityInSlot.ToString();
            }
            else
            {
                quantity.enabled = false;

            }

        }
        else
        {
            itemImage.enabled = false;
            quantity.enabled = false;
        }
    }

    //Function to display the item information that the mouse pointed.
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<ItemInfoUpdate>().UpdateInfoPanel(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInParent<ItemInfoUpdate>().ClosePanel();
    }

    /*public void PickItem()
    {
        if (item != null)
        {
            Rigidbody obj = Instantiate(GameOBJprefabs, shootPoint.position, Quaternion.identity);
        }
    }

    public void RemoveItem()
    {
        removeItem.RemoveItem(removeItem.itemList[removeItem.itemList.IndexOf(item)], 1);
    }*/
}
