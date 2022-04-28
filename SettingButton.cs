using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script page setting.
public class SettingButton : MonoBehaviour
{
    public GameObject graphicsArea;
    public GameObject soundArea;
    public GameObject controlArea;

    public void Graphics()
    {
        graphicsArea.SetActive(true);

        soundArea.SetActive(false);
        controlArea.SetActive(false);
    }
    public void Sound()
    {
        soundArea.SetActive(true);

        graphicsArea.SetActive(false);
        controlArea.SetActive(false);
    }
    public void Control()
    {
        controlArea.SetActive(true);

        graphicsArea.SetActive(false);
        soundArea.SetActive(false);
    }
}
