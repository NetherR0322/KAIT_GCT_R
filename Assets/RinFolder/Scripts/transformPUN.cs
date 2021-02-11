using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class transformPUN : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 自身側が生成したオブジェクトの場合は
            // クリック中フラグのデータを送信する
            pos = this.transform.position;
            stream.SendNext(pos);
        }
        else
        {
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータからクリック中フラグを更新する
            this.transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
