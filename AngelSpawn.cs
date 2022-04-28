using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script the spawn point of the angel according to the key position.
public class AngelSpawn : MonoBehaviour
{
    public GameObject prefebAngel;
    public Transform angelSPPoint;
    public GameObject KeyIngame;

    public GameObject angelSpawn;

    public static bool checkQuestbrokenKey;

    private void Start()
    {
        KeyIngame = FindObjectOfType<GameObject>();
    }
    private void Update()
    {
        AngelSpawngame();
    }

    //Angels spawn when players collect keys.
    void AngelSpawngame()
    {
        if(KeyIngame == null && angelSpawn == null && !AngelMission.checkKeytoPlayer)
        {
            GameObject angelObj = Instantiate(prefebAngel, angelSPPoint.position, Quaternion.identity);
            angelSpawn = angelObj;
            checkQuestbrokenKey = true;
        }
    }
}
