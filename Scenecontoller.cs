using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script scenecontoller
public class Scenecontoller : MonoBehaviour
{
    public void LoadScene()
    {
        if (Gamemanager.Instance._timeScene >= 100)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
    public void Newgame(string scencename)
    {
        SceneManager.LoadScene(scencename);
    }
    public void SkipCutscene1(string scencename)
    {
        SceneManager.LoadScene(scencename);
    }
    public void ExitIngame(string scencename)
    {
        SceneManager.LoadScene(scencename);
    }
    public void Restart(string scencename)
    {
        SceneManager.LoadScene(scencename);
    }
    public void Resume(string scencename)
    {
        SceneManager.LoadScene(scencename);
    }
    public void Setting(string scencename)
    {
        SceneManager.LoadScene(scencename);
    }
}
