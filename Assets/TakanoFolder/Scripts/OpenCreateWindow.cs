using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCreateWindow : MonoBehaviour
{
    public GameObject CreateWindow;
    public GameObject returnBotton;
    public GameObject refreshButton;
    public GameObject grayOut;

    public void On_click_OpenCWindow()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        CreateWindow.SetActive(true);
        returnBotton.SetActive(false);
        refreshButton.SetActive(false);
        grayOut.SetActive(true);
    }
    public void On_click_CloseCWindow()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        CreateWindow.SetActive(false);
        returnBotton.SetActive(true);
        refreshButton.SetActive(true);
        grayOut.SetActive(false);
    }
}
