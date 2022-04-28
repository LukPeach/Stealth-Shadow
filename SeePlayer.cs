using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script showing UI when an enemy encounters a player.
public class SeePlayer : MonoBehaviour
{
    public GameObject seePlayer;
    public bool _seePlayer;
    public static bool checkSeePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _seePlayer = true;
            checkSeePlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _seePlayer = false;
            checkSeePlayer = false;
        }
    }

    private void Update()
    {
        if (_seePlayer)
        {
            seePlayer.SetActive(true);
        }
        else
        {
            seePlayer.SetActive(false);
        }
    }
}
