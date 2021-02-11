using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class transformPUN : MonoBehaviourPunCallbacks, IPunObservable
{
    private int id;
    private Vector2 pos;

    private bool moveCheck;
    private Vector2 nowPos;
    private Vector2 beforePos;
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
        nowPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        beforePos = nowPos;
        nowPos= this.transform.position;
        float dist = Mathf.Sqrt(Mathf.Pow(beforePos.x - nowPos.x, 2) + Mathf.Pow(beforePos.y - nowPos.y, 2));//体から足の先端の距離を代入
        if (dist != 0) { moveCheck = true;} else { moveCheck = false; }
        //Debug.Log(this.name+":"+ moveCheck);
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            debugText.text = "white\n";
            if (moveCheck == true)
            {
                // 自身側が生成したオブジェクトの場合は
                // クリック中フラグのデータを送信する
                pos = this.transform.position;
                stream.SendNext(pos);
            }
        }else{
                // 他プレイヤー側が生成したオブジェクトの場合は
                // 受信したデータからクリック中フラグを更新する
                pos = (Vector2)stream.ReceiveNext();
                //if (this.transform.position.x != pos.x || this.transform.position.y != pos.y)
                //{
                    this.transform.position = pos;
                //}
            }
    }
}
