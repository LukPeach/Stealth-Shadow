using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script inventory.
public class Inventory : MonoBehaviour
{
    public GameObject inventoryArea;
    private bool checkinventoryArea;
    public KeyCode openinventoryArea = KeyCode.B;

    public static bool checkValueItem;

    [Space]
    public List<Item> itemList = new List<Item>();
    public List<int> quantityList = new List<int>();
    List<InventorySlot> slotList = new List<InventorySlot>();

    public Image itemCDImage;
    public Text Quantity;
    public GameObject coolItem;
    public GameObject textG;
    public static bool checkCDCitem;

    public void Start()
    {
        foreach (InventorySlot child in inventoryArea.GetComponentsInChildren<InventorySlot>())
        {
            slotList.Add(child);
        }
    }
    private void Update()
    {
        ShowInventory();
    }

    //Function to get item information and the number of entries into the inventory.
    public void AddItem(Item itemAdded, int quantityAdded)
    {
        //Check if Stackable.
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {
                quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;
            }
            else
            {

                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(quantityAdded);
                }
                else { }

            }

        }
        else
        {
            for (int i = 0; i <= quantityAdded; i++)
            {
                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(1);
                }
                else { }

            }

        }
        UpdateInventoryUI();
    }

    //Function to remove items from inventory.
    public void RemoveItem(Item itemRemoved, int quantityRemoved)
    {
        //Check if Stackable.
        if (itemRemoved.Stackable)
        {
            if (itemList.Contains(itemRemoved))
            {
                quantityList[itemList.IndexOf(itemRemoved)] = quantityList[itemList.IndexOf(itemRemoved)] - quantityRemoved;

                if (quantityList[itemList.IndexOf(itemRemoved)] <= 0)
                {
                    quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                    itemList.RemoveAt(itemList.IndexOf(itemRemoved));
                }
            }

        }
        else
        {


            for (int i = 0; i < quantityRemoved; i++)
            {
                quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                itemList.RemoveAt(itemList.IndexOf(itemRemoved));

            }
        }
        UpdateInventoryUI();
    }

    //Function to check the number of items when the player calls.
    public void ValueItem(Item valueItem)
    {
        if (itemList.IndexOf(valueItem) >= 0)
        {
            checkValueItem = true;
        }
        else
        {
            checkValueItem = false;
            checkCDCitem = false;
        }

        UpdateInventoryUI();
    }

    public static bool brokenKey;
    public static bool key;
    public static bool angelSpawn;
    public static bool stick;

    private bool checkKeyvalue;

    //Function to check the number of items used for quests.
    public void CheckValueItemQuest(Item valueItemQuest)
    {
        if (itemList.IndexOf(valueItemQuest) >= 0)
        {
            brokenKey = true;
            angelSpawn = true;
        }
        else
        {
            brokenKey = false;
            angelSpawn = false;
        }

        if(checkKeyvalue)
        {
            key = true;
        }
        else
        {
            key = false;
        }
        UpdateInventoryUI();
    }

    //Function to check the number of stick used for quests
    public void CheckStick(Item valueStickQuest)
    {
        if(itemList.IndexOf(valueStickQuest) >=0)
        {
            if (quantityList[itemList.IndexOf(valueStickQuest)] >= 10)
            {
                stick = true;
                checkKeyvalue = true;
            }
            else
            {
                stick = false;
            }
        }
        UpdateInventoryUI();
    }

    //Function inventory update to slots.
    public void UpdateInventoryUI()
    {
        int ind = 0;

        foreach (InventorySlot slot in slotList)
        {

            if (itemList.Count != 0)
            {
                if (ind < itemList.Count)
                {
                    slot.UpdateSlot(itemList[ind], quantityList[ind]);
                    ind = ind + 1;
                }
                else
                {
                    slot.UpdateSlot(null, 0);
                }
            }
            else
            {
                slot.UpdateSlot(null, 0);
            }

        }
    }

    //Function to display the UI of the item you hold.
    public void SetActiveCoolDown(Item _itemInfo)
    {
        if (!checkCDCitem)
        {
            coolItem.SetActive(false);
        }
        else if(itemList.IndexOf(_itemInfo) >=0)
        {
            coolItem.SetActive(true);

            if (quantityList[itemList.IndexOf(_itemInfo)] <=1)
            {
                textG.SetActive(false);
            }
            else
            {
                textG.SetActive(true);
                Quantity.text = quantityList[itemList.IndexOf(_itemInfo)].ToString();
            }
            itemCDImage.sprite = _itemInfo.itemIcon;
        }
    }

    //Inventory window display function.
    private void ShowInventory()
    {
        inventoryArea.SetActive(checkinventoryArea);

        //Receives input from the player and checks that the inventory is closed.
        if (Input.GetKeyDown(openinventoryArea) && !checkinventoryArea)
            checkinventoryArea = true;

        //Receives input from the player and checks if the inventory is open.
        else if (Input.GetKeyDown(openinventoryArea) && checkinventoryArea)
            checkinventoryArea = false;

    }
}
