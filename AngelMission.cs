using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script in angels to give missions to players.
public class AngelMission : MonoBehaviour
{
    public GameObject _f_Button;
    public KeyCode talkTOangel = KeyCode.F;
    bool checkPlayer;
    public static bool checkKeytoPlayer;

    public static bool checkQuestAngel;
    public static bool checkQuestStick;

    //Check that the player is close
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _f_Button.SetActive(true);
            checkPlayer = true;
        }
    }

    //Check that the player walks out
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _f_Button.SetActive(false);
            checkPlayer = false;
        }
    }
    private void Update()
    {
        //Check that the player is close
        if (checkPlayer == true)
        {
            //Takes input from the player and returns a variable.
            if (Input.GetKeyDown(talkTOangel))
            {
                AddItemToInventory.removeItemNumber = 2;
                AddItemToInventory.quantityItem = 1;
                AddItemToInventory.checkRemoveitem = true;
                AddItemToInventory.stickQuest = 5;
                checkQuestAngel = true;
            }
        }

        //Checks the stick in the player and takes input from the player and returns a variable.
        if (Inventory.stick && Input.GetKeyDown(talkTOangel) && checkPlayer)
        {
            AddItemToInventory.addItemNumber = 1;
            AddItemToInventory.removeItemNumber = 5;
            AddItemToInventory.quantityItem = 10;
            AddItemToInventory.checkAdditem = true;
            checkKeytoPlayer = true;
            checkQuestStick = true;
            Destroy(this.gameObject);
        }
    }
}
