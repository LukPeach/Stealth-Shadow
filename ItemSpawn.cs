using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script on the item spawn point in the map.
public class ItemSpawn : MonoBehaviour
{
    public GameObject prefebStick;
    public Transform[] stickPoint;
    public GameObject[] stickIngame;

    private void Start()
    {
        SpawnItem();
    }
    private void Update()
    {
        StartCoroutine(WaitReSpawn());
    }

    //Function to set spawn point and number of items.
    void SpawnItem()
    {
        for(int i = 0; i < stickPoint.Length; i++)
        {
            GameObject stickObj = Instantiate(prefebStick, stickPoint[i].position, Quaternion.identity);
            stickIngame[i] = stickObj;
            stickIngame[i].transform.position = stickPoint[i].transform.position;
        }
    }

    //Function to respawn items when players collect.
    public IEnumerator WaitReSpawn()
    {
        for (int i = 0; i < stickPoint.Length; i++)
        {
            if (stickIngame[i] == null)
            {
                stickIngame[i] = prefebStick.gameObject;
                yield return new WaitForSeconds(20);
                GameObject stickObj = Instantiate(prefebStick, stickPoint[i].position, Quaternion.identity);
                stickIngame[i] = stickObj;

            }
        }
    }
}

