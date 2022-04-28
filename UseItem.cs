using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script item when player calls.
public class UseItem : MonoBehaviour
{
    public KeyCode useStick = KeyCode.Alpha1;
    public KeyCode useShoe = KeyCode.Alpha2;
    public KeyCode useArcher = KeyCode.Alpha3;

    public GameObject itemStick;
    public GameObject itemShoe;
    public GameObject itemArcher;

    private GameObject stickObj;
    private GameObject shoeObj;
    private GameObject ArcherObj;

    public Transform pickPoint;

    public bool holdStick = false;

    private void Update()
    {
        useItem();

        //Destroy stick on hand when used or stored.
        if (!holdStick && stickObj)
        {
            Destroy(stickObj);
        }
    }

    void useItem()
    {
        //Receives input from the player when pressing the stick active button and checking the stick in hand.
        if (Input.GetKeyDown(useStick) && !holdStick)
        {
            //Check the number of stick in inventory.
            if (Inventory.checkValueItem)
            {
                stickObj = Instantiate(itemStick, pickPoint.position, Quaternion.identity);
                stickObj.transform.parent = pickPoint.transform;
                stickObj.transform.forward = pickPoint.transform.forward;
                Destroy(shoeObj);
                Destroy(ArcherObj);
                holdStick = true;
                Inventory.checkCDCitem = true;
            }
            AddItemToInventory.itemValue = 5;
            AddItemToInventory.itemCD = 5;
        }
        //Receives input from the player when pressing the stick active button and checking the stick in hand.
        else if (Input.GetKeyDown(useStick) && holdStick)
        {
            holdStick = false;
            Inventory.checkCDCitem = false;
        }
        //Check the number of stick in inventory.
        else if (!Inventory.checkValueItem)
        {
            holdStick = false;
        }

        //Receives input from the player when pressing the shoe active button
        if (Input.GetKeyDown(useShoe)) 
        {
            shoeObj = Instantiate(itemShoe, pickPoint.position, Quaternion.identity);
            //shoeObj.transform.parent = pickPoint.transform;
            //shoeObj.transform.forward = pickPoint.transform.forward;
            Destroy(stickObj);
            Destroy(ArcherObj);
            AddItemToInventory.itemCD = 3;
        }

        //Receives input from the player when pressing the archer active button
        if (Input.GetKeyDown(useArcher))
        {
            ArcherObj = Instantiate(itemArcher, pickPoint.position, Quaternion.identity);
            ArcherObj.transform.parent = pickPoint.transform;
            ArcherObj.transform.forward = pickPoint.transform.forward;
            Destroy(stickObj);
            Destroy(shoeObj);
            AddItemToInventory.itemCD = 0;
        }
    }
}
