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
        //GetComponent addItemInventory.
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

    //Function add item.
    //Send item values to SeneValueAddItem.
    public void AddItem()
    {
        if (checkAdditem)
        {
            SeneValueAddItem(itemsToGive[i]);
            checkAdditem = false;
        }
    }

    //Function remove item.
    //Send item values to SeneValueRemoveItem.
    public void RemoveItem()
    {
        if(checkRemoveitem)
        {
            SeneValueRemoveItem(itemsToGive[r] ,quantityItem);
            checkRemoveitem = false;
        }
    }

    //Function check value item.
    //Pass a variable to function.
    public void valueItem()
    {
        FinditemValue(itemsToGive[itemValue]);
        ValueitemQuest(itemsToGive[itemQuest]);
        ValueStickQuest(itemsToGive[stickQuest]);
    }

    //Function check the item hold.
    public void ItemCoolDown()
    {
        CheckValueCD(itemsToGive[itemCD]);
    }

    //Function to send item values to inventory.
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

    //Function sends the value of remove item to inventory.
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

    //Function to check the number of items in the inventory.
    public void FinditemValue(Item itemValue)
    {
        addItemInventory.ValueItem(itemValue);
    }

    //Function to check item hold.
    public void CheckValueCD(Item itemInfo)
    {
        addItemInventory.SetActiveCoolDown(itemInfo);
    }

    //Function check quest items in the inventory.
    public void ValueitemQuest(Item valueItemQuest)
    {
        addItemInventory.CheckValueItemQuest(valueItemQuest);
    }

    //Function check stick quest items in the inventory.
    public void ValueStickQuest(Item valueStickQuest)
    {
        addItemInventory.CheckStick(valueStickQuest);
    }
}
