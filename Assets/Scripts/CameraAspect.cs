using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    void Awake()
    {
        Camera.main.aspect = Screen.width / Screen.height;
    }
}