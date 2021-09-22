using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenCreateWindow : MonoBehaviour
{
    public GameObject CreateWindow;
    public GameObject returnBotton;
    public GameObject CloseBotton;
    Image img;
    Button btn;
    public GameObject refreshButton;
    public GameObject grayOut;
    private void Start()
    {
        img = CloseBotton.GetComponent<Image>();
        btn = CloseBotton.GetComponent<Button>();
    }
    public void On_click_OpenCWindow()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        CreateWindow.SetActive(true);
        returnBotton.SetActive(false);
        img.enabled = true;
        btn.enabled = true;
        refreshButton.SetActive(false);
        grayOut.SetActive(true);
    }
    public void On_click_CloseCWindow()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        CreateWindow.SetActive(false);
        returnBotton.SetActive(true);
        img.enabled = false;
        btn.enabled = false;
        refreshButton.SetActive(true);
        grayOut.SetActive(false);
    }
}
