using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreatePlayer : MonoBehaviour
{
    GameObject PlayerNetWork;
    private PhotonView PhotonView;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.DestroyPlayerObjects(1);
        PhotonNetwork.DestroyPlayerObjects(2);
        PlayerNetWork = GameObject.Find("PlayerNetWork");
        PhotonView = PlayerNetWork.GetComponent<PhotonView>();
        Invoke("createPlayer",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createPlayer()
    {
        PhotonView.RPC("RPC_CreatePlayer", RpcTarget.All);
    }
}
