using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script made UI turn towards the camera.
public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        this.transform.LookAt(Camera.main.transform.position);
        this.transform.Rotate(new Vector3(0, 180, 0));
    }
}
