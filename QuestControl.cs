using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script quest control.
public class QuestControl : MonoBehaviour
{
    public GameObject questArea;
    public KeyCode keyquest = KeyCode.Q;
    public Text questText;
    private bool checkquestArea = true;

    private void Start()
    {
        //set default
        questText.text = "Go to the door to go down help jumpee";
    }
    private void Update()
    {
        //Takes input from the player and wipes the quest on/off.
        if (Input.GetKeyDown(keyquest) && !checkquestArea)
        {
            checkquestArea = true;
        }
        else if(Input.GetKeyDown(keyquest) && checkquestArea)
        {
            checkquestArea = false;
        }
        else

            QuestUpdate();

        //Setactive quest.
        if (checkquestArea)
            questArea.SetActive(true);
        else
            questArea.SetActive(false);
    }

    //Configure functions in the Quest.
    //if function when the player passes the first condition.
    void QuestUpdate()
    {
        if(Doorcontrol.checkQuest)
        {
            questText.text = "''Can't open the door'' Go find the key to open the door";
            checkquestArea = true;
            Doorcontrol.checkQuest = false;
        }
        else if (AngelSpawn.checkQuestbrokenKey)
        {
            questText.text = "Eh! this broken key. Try talking to that light";
            checkquestArea = true;
            AngelSpawn.checkQuestbrokenKey = false;
        }
        else if(AngelMission.checkQuestAngel)
        {
            questText.text = "I need 10 sticks to repair this key";
            checkquestArea = true;
            AngelMission.checkQuestAngel = false;
        }
        else if(AngelMission.checkQuestStick)
        {
            questText.text = "got the key use it to open the door";
            checkquestArea = true;
            AngelMission.checkQuestStick = false;
        }    
    }
}
