using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class takoTransform : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        if(LobbyNetwork.id==1)GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All,pos);

    }
    [PunRPC]
    private void TransformSync(Vector3 pos)
    {
        this.transform.position = pos;//IKの位置をカーソルの位置に持っていく

    }
}
