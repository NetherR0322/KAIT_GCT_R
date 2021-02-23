using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class asiMover2 : MonoBehaviourPunCallbacks
{
    //スクリプトをつける場所:各IK
    public float touchDist;
    private int id;
    private int myHaveId = -1;
    private GameObject cur;
    private int curHaveId;

    private int curNameI;
    public bool isHave;

    float dist;
    curData data;
    bool catchData;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "L1IK") id = 0;
        if (this.name == "L2IK") id = 1;
        if (this.name == "L3IK") id = 2;
        if (this.name == "L4IK") id = 3;
        if (this.name == "R1IK") id = 4;
        if (this.name == "R2IK") id = 5;
        if (this.name == "R3IK") id = 6;
        if (this.name == "R4IK") id = 7;
    }

    // Update is called once per frame
    void Update()
    {
        //全てのカーソルを取得
        GameObject[] cursors = GameObject.FindGameObjectsWithTag("Cursor");
        for (int i = 0; i < cursors.Length; i++)
        {
            dist = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - cursors[i].transform.position.x, 2) + Mathf.Pow(transform.position.y - cursors[i].transform.position.y, 2));//

            catchData = false;
            if (dist <= touchDist)
            {
                data = cursors[i].GetComponent<curData>();
                catchData = true;
            }
        }
        if (GameObject.Find("-1")) { if (cur.name == "-1") curNameI = -1; }
        if (GameObject.Find("0")) { if (cur.name == "0") curNameI = 0; }
        if (GameObject.Find("1")) { if (cur.name == "1") curNameI = 1; }
        if (GameObject.Find("2")) { if (cur.name == "2") curNameI = 2; }
        if (GameObject.Find("3")) { if (cur.name == "3") curNameI = 3; }
        if (GameObject.Find("4")) { if (cur.name == "4") curNameI = 4; }
        if (GameObject.Find("5")) { if (cur.name == "5") curNameI = 5; }
        if (GameObject.Find("6")) { if (cur.name == "6") curNameI = 6; }
        if (GameObject.Find("7")) { if (cur.name == "7") curNameI = 7; }
        Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得して…
        dist = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - mp.x, 2) + Mathf.Pow(transform.position.y - mp.y, 2));//
        if (catchData)//近くにカーソルがあったら
        {
            if (Input.GetMouseButtonDown(0)//クリックをしていて
                && (haveAsiList.asiList[id] == false && data.haveId == -1)//この足が誰にも持たれていない && 触れているカーソルが何も持っていない
                || (haveAsiList.asiList[id] == true && data.haveId == id)//この足が持たれている && 触れているカーソルが自分を持っている
                )//もし足をつかまれていたら
            {
                isHave = true;
                GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, mp);
                haveAsiList.asiList[id] = true;
                data.haveId = id;
                //haveAsiList.curHaveList[curNameI] = id;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isHave = false;
                haveAsiList.asiList[id] = false;
                data.haveId = -1;
                //haveAsiList.curHaveList[curNameI] = -1;
            }
        }
    }
    [PunRPC]
    private void TransformSync(Vector2 mp)
    {
        this.transform.position = mp;//IKの位置をカーソルの位置に持っていく
    }

}
