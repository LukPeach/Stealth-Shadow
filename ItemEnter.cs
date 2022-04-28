using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script sends values when the player collects an item.
public class ItemEnter : MonoBehaviour
{
    public GameObject _f_Button;
    public KeyCode pickItem = KeyCode.F;
    public int itemNember;
    bool checkPlayer;
    //ItemSpawn sp;

    //Checks when a player is near and shows UI.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _f_Button.SetActive(true);
            checkPlayer = true;
        }
    }

    //Checks when a player walks out and stops showing UI.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _f_Button.SetActive(false);
            checkPlayer = false;
        }
    }
    private void Start()
    {
        //sp = GameObject.Find("SpawnItem").GetComponent<ItemSpawn>();
    }
    private void Update()
    {
        //Checks when a player is near.
        if (checkPlayer == true)
        {
            //Receives input from the player when collecting an item.
            if (Input.GetKeyDown(pickItem))
            {
                AddItemToInventory.addItemNumber = itemNember;
                AddItemToInventory.checkAdditem = true;
                Destroy(gameObject);
            }
        }
    }
}
