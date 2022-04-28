using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script tutorial control.
public class TutorialControl : MonoBehaviour
{
    public GameObject tutorialArea;
    public KeyCode keytutorial = KeyCode.I;
    public Text tutorialText;
    private bool checktutoriaArea = true;

    private void Start()
    {
        //set default
        tutorialText.text = "Press I to turn on/off the tutorial";
    }
    private void Update()
    {
        //Takes input from the player and wipes the tutorial on/off.
        if (Input.GetKeyDown(keytutorial) && !checktutoriaArea)
        {
            checktutoriaArea = true;
        }
        else if (Input.GetKeyDown(keytutorial) && checktutoriaArea)
        {
            checktutoriaArea = false;
        }

        CheckPress();
        StartCoroutine(TutorialUpdate());

        //Setactive tutorial.
        if (checktutoriaArea)
            tutorialArea.SetActive(true);
        else
            tutorialArea.SetActive(false);
    }

    //Configure functions in the Tutorial.
    //if function when the player passes the first condition.
    IEnumerator TutorialUpdate()
    {
        if(checkI)
        {
            yield return new WaitForSeconds(2);
            tutorialText.text = "Press Q to turn on/off the Quest";
            checktutoriaArea = true;
            checkI = false;
        }
        else if (checkQ)
        {
            yield return new WaitForSeconds(2);
            tutorialText.text = "Press W A S D to move";
            checktutoriaArea = true;
            checkQ = false;
        }
    }

    private bool checkI;
    private bool checkI2;
    private bool checkQ;
    private bool checkQ2;

    //Check input when player presses
    private void CheckPress()
    {
        if (Input.GetKeyDown(KeyCode.I) && !checkI2)
        {
            checkI = true;
            checkI2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Q) && !checkQ2)
        {
            checkQ = true;
            checkQ2 = true;
        }
    }
}
