using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : Scenecontoller
{
    public void TimeLoading()
    {
        //Slide the game loading page.
        Gamemanager.Instance._timeScene = GetComponent<Slider>().value = 0f + Time.timeSinceLevelLoad / Gamemanager.Instance._timeLoad;
    }
}
