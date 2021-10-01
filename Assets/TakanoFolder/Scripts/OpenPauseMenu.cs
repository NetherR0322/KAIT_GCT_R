using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenPauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject pauseBotton;
    public GameObject grayOut;

    GameObject child;
    public GameObject CloseBotton;
    Image img;
    Button btn;
    Text text;
    BoxCollider2D col;
    Image pause_img;
    Button pause_btn;
    BoxCollider2D pause_col;
    bool one = false;
    private void Start()
    {
        img = CloseBotton.GetComponent<Image>();
        btn = CloseBotton.GetComponent<Button>();
        col = CloseBotton.GetComponent<BoxCollider2D>();
        child = CloseBotton.transform.GetChild(0).gameObject;
        text = child.GetComponent<Text>();

        pause_img = pauseBotton.GetComponent<Image>();
        pause_btn = pauseBotton.GetComponent<Button>();
        pause_col = pauseBotton.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (LimitScript.flag&&!one)
        {
            pause_img.enabled = false;
            pause_btn.enabled = false;
            pause_col.enabled = false;
            img.enabled = false;
            btn.enabled = false;
            col.enabled = false;
            text.enabled = false;
            PauseMenu.SetActive(false);
            grayOut.SetActive(false);
        }
        if (Goal.flag&&!one)
        {
            pause_img.enabled = false;
            pause_btn.enabled = false;
            pause_col.enabled = false;
            img.enabled = false;
            btn.enabled = false;
            col.enabled = false;
            text.enabled = false;
            PauseMenu.SetActive(false);
            grayOut.SetActive(false);
        }
    }
    public void On_click_OpenPmenu()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        img.enabled = true;
        btn.enabled = true;
        col.enabled = true;
        text.enabled = true;
        PauseMenu.SetActive(true);
        //pauseBotton.SetActive(false);
        pause_img.enabled = false;
        pause_btn.enabled = false;
        pause_col.enabled = false;
        grayOut.SetActive(true);
    }
    public void On_click_CloseCPmenu()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        img.enabled = false;
        btn.enabled = false;
        col.enabled = false;
        text.enabled = false;
        PauseMenu.SetActive(false);
        //pauseBotton.SetActive(true);
        pause_img.enabled = true;
        pause_btn.enabled = true;
        pause_col.enabled = true;
        grayOut.SetActive(false);
    }
}
