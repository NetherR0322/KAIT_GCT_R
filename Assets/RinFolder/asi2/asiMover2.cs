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
    GamePlayer data2;
    bool catchData;

    //SE
    bool isSoundPlay=true;
    public AudioClip[] se;

    //追加====
    private int punTimer;//@
    private int n;

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
        punTimer++;//@
        if (punTimer > 29) punTimer = 0;//@
        //全てのカーソルを取得
        GameObject[] cursors = GameObject.FindGameObjectsWithTag("Cursor");
        for (int i = 0; i < cursors.Length; i++)
        {
            dist = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - cursors[i].transform.position.x, 2) + Mathf.Pow(transform.position.y - cursors[i].transform.position.y, 2));//

            catchData = false;
            if (dist <= touchDist)
            {
                data = cursors[i].GetComponent<curData>();
                data2 = cursors[i].GetComponent<GamePlayer>();
                catchData = true;
            }
        }
        //Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得して…
        Vector3 mp = data.thisPos;
        Vector3 beforeMp = data.beforePos;
        beforeMp.z = 0.0f;
        //dist = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - mp.x, 2) + Mathf.Pow(transform.position.y - mp.y, 2));//
        if (catchData)//近くにカーソルがあったら
        {
            if (data2.isClicked//クリックをしていて
                && (haveAsiList.asiList[id] == false && data.haveId == -1)//この足が誰にも持たれていない && 触れているカーソルが何も持っていない
                || (haveAsiList.asiList[id] == true && data.haveId == id)//この足が持たれている && 触れているカーソルが自分を持っている
                )//もし足をつかまれていたら
            {
                isSoundPlay = false;
                isHave = true;
                //if (mp != beforeMp) GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, mp);//-@
                if (mp != beforeMp && punTimer == 0)
                {
                    GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, mp);//@
                    Debug.Log("id : "+id+"|| 通信("+n+"回目)");
                    n++;
                }
                this.transform.position = mp;//IKの位置をカーソルの位置に持っていく//@
                haveAsiList.asiList[id] = true;
                data.haveId = id;
                //haveAsiList.curHaveList[curNameI] = id;
            }
            if (!data2.isClicked)
            {
                if (!isSoundPlay) {
                    this.GetComponent<AudioSource>().clip = se[Random.Range(0,se.Length)];
                    Debug.Log("random:"+Random.Range(0, se.Length));
                    this.GetComponent<AudioSource>().Play();
                    isSoundPlay = true;
                }
                isHave = false;
                haveAsiList.asiList[id] = false;
                data.haveId = -1;
                //haveAsiList.curHaveList[curNameI] = -1;
            }
        }
    }
    [PunRPC]
    private void TransformSync(Vector3 mp)
    {
        //this.transform.position = mp;//IKの位置をカーソルの位置に持っていく//-@
        Debug.Log("asiMover2>PUN通信の実行(mp:" + data.thisPos + ",beforeMp:" + data.beforePos + ")") ;
    }

}
