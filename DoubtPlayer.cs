using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script showing UI when enemy doubt.
public class DoubtPlayer : SeePlayer
{
    public GameObject doubtPlayer;
    public bool checkDoubt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkDoubt = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkDoubt = false;
        }
    }

    private void Update()
    {
        if (checkSeePlayer)
        {
            doubtPlayer.SetActive(false);
        }
        else if(checkDoubt)
        {
            doubtPlayer.SetActive(true);
        }
        else
        {
            doubtPlayer.SetActive(false);
        }
    }
}
