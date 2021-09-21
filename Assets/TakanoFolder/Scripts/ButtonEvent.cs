using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    Vector2 rt;
    //Vector2 Text_rt;
    Text c_Text;
    GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.gameObject.GetComponent<RectTransform>().sizeDelta;
        child = transform.GetChild(0).gameObject;
        //Text_rt = child.GetComponent<RectTransform>().sizeDelta;
        c_Text = child.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseEnter()
    {
        BGMPlayer.GetInstance().PlaySound(1);
        rt = new Vector2(rt.x * 1.05f, rt.y * 1.05f);
        c_Text.fontSize = 134;
        this.GetComponent<RectTransform>().sizeDelta = rt;

    }
    void OnMouseExit()
    {
        rt = new Vector2(rt.x / 1.05f, rt.y / 1.05f);
        c_Text.fontSize = 128;
        this.GetComponent<RectTransform>().sizeDelta = rt;
    }
    void OnMouseDown()
    {
        rt = new Vector2(rt.x / 1.05f, rt.y / 1.05f);
        c_Text.fontSize = 128;
        this.GetComponent<RectTransform>().sizeDelta = rt;
    }
    void OnMouseUp()
    {
        BGMPlayer.GetInstance().PlaySound(1);
        rt = new Vector2(rt.x * 1.05f, rt.y * 1.05f);
        c_Text.fontSize = 134;
        this.GetComponent<RectTransform>().sizeDelta = rt;
    }
}
