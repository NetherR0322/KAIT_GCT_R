using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCreateWindow : MonoBehaviour
{
    public GameObject CreateWindow;

    public void On_click_OpenCWindow()
    {
        CreateWindow.SetActive(true);
    }
    public void On_click_CloseCWindow()
    {
        CreateWindow.SetActive(false);
    }
}
