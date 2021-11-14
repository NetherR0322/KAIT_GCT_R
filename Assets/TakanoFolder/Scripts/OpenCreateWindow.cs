using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenCreateWindow : MonoBehaviour
{
    public GameObject CreateWindow;
    public GameObject returnBotton;
    public GameObject CloseBotton;
    //public GameObject CreateBotton;
    Image img;
    Button btn;
    Image c_img;
    Button c_btn;
    BoxCollider2D c_col;
    BoxCollider2D col;
    ButtonEvent btnE;
    public GameObject refreshButton;
    public GameObject grayOut;

    public Image BgImg, CloseImg, CrImage, SrImage, BaImage;
    public Text text;
    public Button CrButtom, SrButtom;
    public BoxCollider2D CrCol, SrCol, CloseCol;
    private void Start()
    {
        img = CloseBotton.GetComponent<Image>();
        btn = CloseBotton.GetComponent<Button>();
        col = CloseBotton.GetComponent<BoxCollider2D>();
        //c_img = CreateBotton.GetComponent<Image>();
        //c_btn = CreateBotton.GetComponent<Button>();
        //c_col = CreateBotton.GetComponent<BoxCollider2D>();
        //btnE = CloseBotton.GetComponent<ButtonEvent>();
    }
    public void On_click_OpenCWindow()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        CreateWindow.SetActive(true);
        returnBotton.SetActive(false);
        img.enabled = true;
        btn.enabled = true;
        col.enabled = true;
        /*c_img.enabled = true;
        c_btn.enabled = true;
        c_col.enabled = true;*/
        //btnE.enabled = true;
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
        col.enabled = false;
        /*c_img.enabled = false;
        c_btn.enabled = false;
        c_col.enabled = false;
        //btnE.enabled = false;*/
        refreshButton.SetActive(true);
        grayOut.SetActive(false);
    }
    public void On_click_Select()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //CreateRoomLobby.SetActive(false);
        //SearchRoomLobby.SetActive(true);
        //this.gameObject.SetActive(false);
        BgImg.enabled = true;
        CloseImg.enabled = true;
        CrImage.enabled = true;
        SrImage.enabled = true;
        BaImage.enabled = true;
        text.enabled = true;
        CrButtom.enabled = true;
        SrButtom.enabled = true;
        CrCol.enabled = true;
        SrCol.enabled = true;
        CloseCol.enabled = true;
    }
}
