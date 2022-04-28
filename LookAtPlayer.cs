using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script checks if the player is within enemy field of view.
//Pass a variable to an EnemyMove script.
public class LookAtPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EnemyMove lookplayer = GetComponentInParent(typeof(EnemyMove)) as EnemyMove;
        if (other.gameObject.tag == "Player")
        {
            lookplayer.lookPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        EnemyMove lookplayer = GetComponentInParent(typeof(EnemyMove)) as EnemyMove;
        if (other.gameObject.tag == "Player")
        {
            lookplayer.lookPlayer = false;
        }
    }
}
