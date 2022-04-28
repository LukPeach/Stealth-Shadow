using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script door control.
public class Doorcontrol : MonoBehaviour
{
    public bool open;
    public bool enter;
    public bool checkEnterdoor;
    public float smooth = 2.0f;
    private Vector3 defaultRot;
    private Vector3 openRot;

    public GameObject[] doorMap;
    public GameObject _f_button;
    public GameObject winGame;

    public GameObject prefebKey;
    public Transform[] keyPoint;

    public GameObject keyIngame;

    public static bool checkQuest;

    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y, defaultRot.z);
    }
    void Update()
    {
        //Take input from player and check enter && keyIngame.
        if (Input.GetKeyDown(KeyCode.F) && enter && keyIngame == null)
        {
            spawnKey();
            AddItemToInventory.itemQuest = 1;
            open = !open;
            checkQuest = true;
        }
        if (open)
        {
            for (int i =0; i < doorMap.Length; i++)
            {
                doorMap[i].transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            }

        }
        HaveKey();
    }

    //Check the players near the door.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            enter = true;
            _f_button.SetActive(true);
        }
    }

    //Check the players out of the door.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            enter = false;
            _f_button.SetActive(false);
        }
    }

    //Function player Interact with door.
    void HaveKey()
    {
        if(Input.GetKey(KeyCode.F) && enter)
        {
            checkEnterdoor = true;
        }
        else if(!enter)
        {
            checkEnterdoor = false;
        }

        //Check if a player has a key.
        if (Inventory.key && checkEnterdoor)
        {
            winGame.SetActive(true);
        }
        else
        {
            winGame.SetActive(false);
        }
    }

    //Function spawnkey.
    void spawnKey()
    {
        int i = Random.Range(0,2);
        GameObject keyObj = Instantiate(prefebKey, keyPoint[i].position, Quaternion.identity);
        keyIngame = keyObj;
    }
}
