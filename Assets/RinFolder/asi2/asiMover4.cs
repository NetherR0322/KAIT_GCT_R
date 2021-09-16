using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class asiMover4 : MonoBehaviourPunCallbacks
{
    //スクリプトをつける場所:各IK
    //カーソルを使わずにマウス位置を取得する方法

    public float touchDist;//掴むことができる距離
    private int id;//このIK(自分)がどの足なのかを識別
    private int myHaveId = -1;
    private GameObject cur;
    private int curHaveId;

    private int curNameI;
    public bool isHave;//このIK(自分)がカーソルに持たれているか

    float dist;//このIK(自分)とカーソルとの距離
    curData data;//カーソルにあるスクリプト1
    GamePlayer data2;//カーソルにあるスクリプト2
    bool catchData;//近くにカーソルがあるか

    //SE関係
    bool isSoundPlay = true;//効果音を鳴らしたかどうか
    public AudioClip[] se;//鳴らす効果音を格納する場所

    private string overId;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("LobbyCamera").gameObject.SetActive(false);
        //どの足にくっついているかをIDで識別可能にする
        #region
        if (this.name == "L1IK") id = 0;
        if (this.name == "L2IK") id = 1;
        if (this.name == "L3IK") id = 2;
        if (this.name == "L4IK") id = 3;
        if (this.name == "R1IK") id = 4;
        if (this.name == "R2IK") id = 5;
        if (this.name == "R3IK") id = 6;
        if (this.name == "R4IK") id = 7;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("overId[" + id + "]:" + overId);

        Vector3 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dist = Distance(this.transform.position, curPos);//マウスとIK(自分)との距離を取得
        //Debug.Log("["+id+"]"+ curPos + " : "+ this.transform.position+" : "+dist);
        catchData = false;
        if (dist <= touchDist)//もしマウスが近くにあったら
        {
            catchData = true;//マウスが近くにいる
            overId = PhotonNetwork.LocalPlayer.UserId;//マウスのIDをこのIK(自分)に代入する
        }

        if (catchData)//この近くにカーソルがあったら
        {
            if (Input.GetMouseButton(0)//マウスをクリックしていて
                && (overId == ""                               //この足が誰にも持たれていない && この足がどのマウスにも持たれていない
                || (overId==PhotonNetwork.LocalPlayer.UserId)))//この足が持たれている         && このマウスが持っている
            {
                isHave = true;//このIK(自分)は誰かに掴まれている
                haveAsiList.asiList[id] = true;//staticに用意してある、どの足が持たれているかを代入する配列に、このIK(自分)が持たれていることを伝える

                isSoundPlay = false;//離したときに効果音がなるようにする

                this.transform.position = (Vector2)curPos;//カーソルの位置にこのIK(自分)を持っていく
                Debug.Log("[" + id + "]座標を移動準備完了。");
                GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, (Vector2)curPos);
            }
        }

        if (!Input.GetMouseButton(0))//近くにあるカーソルがクリックをしていなかったら
        {
            isHave = false;//このIK(自分)は誰かに掴まれていない
            haveAsiList.asiList[id] = false;//staticに用意してある、どの足が持たれているかを代入する配列に、このIK(自分)が持たれていないことを伝える
            overId = "";

            if (!isSoundPlay)//もしまだ効果音を鳴らしていなかったら
            {
                this.GetComponent<AudioSource>().clip = se[Random.Range(0, se.Length)];//SEの中からランダムで一つ選ぶ
                this.GetComponent<AudioSource>().Play();//選んだSEを鳴らす
                isSoundPlay = true;//複数回鳴らさないようにする
            }
        }

        if (isHave) transform.Find("ring").localScale = new Vector2(0.75f, 0.75f);
        if (!isHave) transform.Find("ring").localScale = new Vector2(0.5f, 0.5f);

    }

    float Distance(Vector2 fPos, Vector2 sPos)
    {
        float ans = Mathf.Pow(fPos.x - sPos.x, 2) + Mathf.Pow(fPos.y - sPos.y, 2);
        return ans;
    }

    [PunRPC]
    private void TransformSync(Vector2 pos)
    {
        this.transform.position = pos;//カーソルの位置にこのIK(自分)を持っていく
        Debug.Log("["+id+"]座標を移動させました。");
    }
}
