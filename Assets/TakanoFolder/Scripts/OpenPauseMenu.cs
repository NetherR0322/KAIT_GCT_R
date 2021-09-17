using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject pauseBotton;
    public GameObject grayOut;

    public void On_click_OpenPmenu()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        PauseMenu.SetActive(true);
        pauseBotton.SetActive(false);
        grayOut.SetActive(true);
    }
    public void On_click_CloseCPmenu()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        PauseMenu.SetActive(false);
        pauseBotton.SetActive(true);
        grayOut.SetActive(false);
    }
}
