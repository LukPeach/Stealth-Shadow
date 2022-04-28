using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attacking players when encountered.
public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverBG;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameOverBG.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOverBG.SetActive(false);
        }
    }
}
