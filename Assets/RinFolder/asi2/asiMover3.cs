using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class asiMover3 : MonoBehaviourPunCallbacks, IPunObservable
{
    //スクリプトをつける場所:各IK
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

    // Start is called before the first frame update
    void Start()
    {
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
        GameObject[] cursors = GameObject.FindGameObjectsWithTag("Cursor");//カーソルをすべて取得

        for (int i = 0; i < cursors.Length; i++)//全てのカーソルと比較する
        {
            dist = Distance(this.transform.position, cursors[i].transform.position);//カーソルとIK(自分)との距離を取得
            catchData = false;
            if (dist <= touchDist)//もしカーソルが近くにあったら
            {
                data = cursors[i].GetComponent<curData>();//カーソルについているcurDataのスクリプトを入れる
                data2 = cursors[i].GetComponent<GamePlayer>();//カーソルについているGamePlayerのスクリプトを入れる
                catchData = true;//カーソルが近くにいる
            }
        }

        if (catchData)//この近くにカーソルがあったら
        {
            if (data2.isClicked//近くにあるカーソルがクリックをしていて
                && ((!haveAsiList.asiList[id] && data.haveId == -1)//この足が誰にも持たれていない && 近くにあるカーソルが何も持っていない
                || (haveAsiList.asiList[id] && data.haveId == id)))//この足が持たれている         && 近くにあるカーソルが自分を持っている
            {
                isHave = true;//このIK(自分)は誰かに掴まれている
                haveAsiList.asiList[id] = true;//staticに用意してある、どの足が持たれているかを代入する配列に、このIK(自分)が持たれていることを伝える
                data.haveId = id;//カーソル側に、このIK(自分)を持っていることを伝える

                isSoundPlay = false;//離したときに効果音がなるようにする

                //transform.Find("ring").localScale = new Vector2(0.75f, 0.75f);//近くにカーソルがある&&クリックされているときにリングを大きくする

                Vector2 mp = data.thisPos;//カーソルの位置を取得
                Vector2 beforeMp = data.beforePos;//前回のカーソルの位置を取得
                this.transform.position = mp;//カーソルの位置にこのIK(自分)を持っていく
                //if (Mathf.Abs(Distance(mp,beforeMp))>4.0f)
                {
                    transform.Find("ring").localScale = new Vector2(0.75f, 0.75f);//通信しているときにリングを大きくする
                    //GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, mp);//座標を伝える
                    //if (PhotonNetwork.IsMasterClient) GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, this.transform.position);//ホストはその他にこのIK(自分)の座標を伝える
                    //if (!PhotonNetwork.IsMasterClient) GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.Others, this.transform.position);//その他はホストにこのIK(自分)も座標を伝える
                //}
                //else {
                //    transform.Find("ring").localScale = new Vector2(0.5f, 0.5f);//通信していないときにリングを小さくする
                }
            }
        }

        if (!data2.isClicked)//近くにあるカーソルがクリックをしていなかったら
        {
            isHave = false;//このIK(自分)は誰かに掴まれていない
            haveAsiList.asiList[id] = false;//staticに用意してある、どの足が持たれているかを代入する配列に、このIK(自分)が持たれていないことを伝える
            data.haveId = -1;//カーソル側に、何も持っていないことを伝える

           //transform.Find("ring").localScale = new Vector2(0.5f, 0.5f);//近くにカーソルがないときにリングを小さくする

            if (!isSoundPlay)//もしまだ効果音を鳴らしていなかったら
            {
                this.GetComponent<AudioSource>().clip = se[Random.Range(0, se.Length)];//SEの中からランダムで一つ選ぶ
                this.GetComponent<AudioSource>().Play();//選んだSEを鳴らす
                isSoundPlay = true;//複数回鳴らさないようにする
            }
        }
    }

    float Distance(Vector2 fPos, Vector2 sPos) {
        float ans = Mathf.Pow(fPos.x - sPos.x, 2) + Mathf.Pow(fPos.y-sPos.y,2);
        return ans;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (catchData&& data2.isClicked)
        {
            // 自身側が生成したオブジェクトの場合は
            // 色相値と移動中フラグのデータを送信する
            stream.SendNext(this.transform.position);
        }
        else
        {
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータから色相値と移動中フラグを更新する
            this.transform.position = (Vector2)stream.ReceiveNext();
        }
    }

    /*
    private void TransformSync(Vector2 pos)
    {
        this.transform.position = pos;//カーソルの位置にこのIK(自分)を持っていく
    }
    */
}
