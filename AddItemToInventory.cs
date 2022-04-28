using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script add items to Inventory.
public class AddItemToInventory : MonoBehaviour
{
    public List<Item> itemsToGive = new List<Item>();
    public static int addItemNumber;
    public static bool checkAdditem;
    public static int removeItemNumber;
    public static bool checkRemoveitem;

    public static int itemValue;
    public static int itemCD;
    public static int itemQuest;
    public static int stickQuest;

    public static int quantityItem;

    private int i;
    private int r;

    Inventory addItemInventory;

    private void Start()
    {
        addItemInventory = GetComponent<Inventory>();

        itemValue = 5;
        itemQuest = 1;
    }

    private void Update()
    {
        i = addItemNumber;
        r = removeItemNumber;
        AddItem();
        RemoveItem();
        valueItem();
        ItemCoolDown();
    }
    public void AddItem()
    {
        if (checkAdditem)
        {
            SeneValueAddItem(itemsToGive[i]);
            checkAdditem = false;
        }
    }
    public void RemoveItem()
    {
        if(checkRemoveitem)
        {
            SeneValueRemoveItem(itemsToGive[r] ,quantityItem);
            checkRemoveitem = false;
        }
    }
    public void valueItem()
    {
        FinditemValue(itemsToGive[itemValue]);
        ValueitemQuest(itemsToGive[itemQuest]);
        ValueStickQuest(itemsToGive[stickQuest]);
    }
    public void ItemCoolDown()
    {
        CheckValueCD(itemsToGive[itemCD]);
    }
    public void SeneValueAddItem(Item itemAdded)
    {
        if (itemAdded.Stackable)
        {
            addItemInventory.AddItem(itemAdded, 1);
        }
        else
        {
            addItemInventory.AddItem(itemAdded, 0);
        }
    }
    public void SeneValueRemoveItem(Item itemRemove ,int quantityRemove)
    {
        if (itemRemove.Stackable)
        {
            addItemInventory.RemoveItem(itemRemove, quantityRemove);
        }
        else
        {
            addItemInventory.RemoveItem(itemRemove, 0);
        }
    }
    public void FinditemValue(Item itemValue)
    {
        addItemInventory.ValueItem(itemValue);
    }
    public void CheckValueCD(Item itemInfo)
    {
        addItemInventory.SetActiveCoolDown(itemInfo);
    }
    public void ValueitemQuest(Item valueItemQuest)
    {
        addItemInventory.CheckValueItemQuest(valueItemQuest);
    }
    public void ValueStickQuest(Item valueStickQuest)
    {
        addItemInventory.CheckStick(valueStickQuest);
    }
}
