using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RTransformView : MonoBehaviourPunCallbacks
{
    private int punTimer;
    private int n;
    public string name;
    private Vector3 beforePos;
    private Vector3 nowPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        punTimer++;//@
        if (punTimer > 29) punTimer = 0;

        beforePos=nowPos;
        nowPos=this.transform.position;
        if (beforePos!=nowPos && punTimer == 0)
        {
            if (PhotonNetwork.IsMasterClient)GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, this.transform.position);//@
            Debug.Log(name + "|| 通信(" + n + "回目)");
            n++;
        }
    }

    [PunRPC]
    private void TransformSync(Vector3 mp)
    {
    }
}
