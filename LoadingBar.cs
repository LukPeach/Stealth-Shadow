using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : UI
{
    void Update()
    {
        TimeLoading();
        LoadScene();
    }
}
