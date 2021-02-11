﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asiMover : MonoBehaviour
{
    //スクリプトをつける場所:各IK
    //Event Triggerにそれぞれ入れる
    //Pointer DownにtouchDown
    //Pointer UpにtouchUp
    //private bool isHave;//プレイヤーに足をつかまれている状態か
    public GameObject dPos;//IKが遠くに行き過ぎたときの初期位置(足先にからのGOをつけておく)
    public float touchDist;
    private int id;
    private int myHaveId=-1;
    private GameObject cur;
    private int curHaveId;

    private int curNameI;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "L1") id = 0;
        if (this.name == "L2") id = 1;
        if (this.name == "L3") id = 2;
        if (this.name == "L4") id = 3;
        if (this.name == "R1") id = 4;
        if (this.name == "R2") id = 5;
        if (this.name == "R3") id = 6;
        if (this.name == "R4") id = 7;
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("-1")) { if (cur.name == "-1") curNameI = -1; }
        if (GameObject.Find("0")) { if (cur.name == "0") curNameI = 0; }
        if (GameObject.Find("1")) { if (cur.name == "1") curNameI = 1; }
        if (GameObject.Find("2")) { if (cur.name == "2") curNameI = 2; }
        if (GameObject.Find("3")) { if (cur.name == "3") curNameI = 3; }
        if (GameObject.Find("4")) { if (cur.name == "4") curNameI = 4; }
        if (GameObject.Find("5")) { if (cur.name == "5") curNameI = 5; }
        if (GameObject.Find("6")) { if (cur.name == "6") curNameI = 6; }
        if (GameObject.Find("7")) { if (cur.name == "7") curNameI = 7; }
        //debugText.text = "update\n";
        //debugText.text = (haveAsiList.curHaveList[(int.Parse(cur.name))]).ToString("0");
        //Debug.Log(haveAsiList.curHaveList[(int.Parse(cur.name))]);
        //curScript = cur.GetComponent<GamePlayer>();
        Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得して…
        float dist = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - mp.x, 2) + Mathf.Pow(transform.position.y - mp.y, 2));//
        /*debugText.text += "dist:"+(dist <= touchDist)+"\n";
        debugText.text += "click:" + Input.GetMouseButton(0) + "\n";
        debugText.text += "====\n";
        debugText.text += "list:" + haveAsiList.asiList[id] + "\n";
        debugText.text += "curList:" + haveAsiList.curHaveList[curNameI] + "\n";
        */
        if (dist <= touchDist && Input.GetMouseButton(0) && (haveAsiList.asiList[id] == false&&haveAsiList.curHaveList[curNameI] == -1)||(haveAsiList.asiList[id] == true && haveAsiList.curHaveList[curNameI] == id))//もし足をつかまれていたら
        {
            this.transform.position = mp;//IKの位置をカーソルの位置に持っていく
            haveAsiList.asiList[id] = true;
            //curScript.curHaveId = id;
            haveAsiList.curHaveList[curNameI] =id;
            //debugText.text += "moveNow("+id+")";
        }
        if (Input.GetMouseButtonUp(0)) {
            this.transform.position = dPos.transform.position;//遠くに行き過ぎたIKを戻す
            haveAsiList.asiList[id] = false;
            //curScript.curHaveId = -1;
            haveAsiList.curHaveList[curNameI] = -1;
        }
   }
    void OnTriggerStay2D(Collider2D col) {
            cur = col.gameObject;
            //curScript = cur.GetComponent<GamePlayer>();
            //if(curScript.rin_curHaveId==-1) curScript.rin_curHaveId = id;
            //haveAsiList.asiList[id] = true;
            //curHaveId = curScript.rin_curHaveId;
    }
    /*void OnTriggerExit2D(Collider2D col)
    {
        cur = col.gameObject;
        curScript = cur.GetComponent<cursor>();
        //curHaveId = curScript.rin_curHaveId;
        curScript.rin_curHaveId = -1;
        haveAsiList.asiList[id] = false;
    }*/
    /*
    public void touchDown() {//足をクリック
        isHave = true;
        Debug.Log("Down");
    }
    public void touchUp(){//足を離す
        isHave = false;
        this.transform.position = dPos.transform.position;//遠くに行き過ぎたIKを戻す
        Debug.Log("Up");
    }
    */
}
