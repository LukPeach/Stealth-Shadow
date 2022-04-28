using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibary : MonoBehaviour
{
    public List<Item> itemLibrary = new List<Item>();

    string inventoryString = "";




    // Runs everytime the SaveInventory() is called
    public void TransformDataToString()
    {
        /*foreach (Item item in Inventory.instance.itemList)
        {
            inventoryString = inventoryString + item.ID + ":" + Inventory.instance.quantityList[Inventory.instance.itemList.IndexOf(item)] + "/";
        }*/


    }
}
