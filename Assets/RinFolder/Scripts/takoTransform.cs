using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class takoTransform : MonoBehaviourPunCallbacks
{
    Vector3 nowPos;
    Vector3 beforePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        beforePos = nowPos;
        nowPos = this.transform.position;
        //if(LobbyNetwork.id==1)
        if(nowPos!=beforePos)GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All,nowPos);

    }
    [PunRPC]
    private void TransformSync(Vector3 pos)
    {
        this.transform.position = pos;//IKの位置をカーソルの位置に持っていく
        Debug.Log("takoTransform>PUN通信の実行");
    }
}
