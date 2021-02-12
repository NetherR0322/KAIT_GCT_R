using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerLayoutGroup : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _playerListngPrefab;
    private GameObject PlayerlistingPrefab
    {
        get { return _playerListngPrefab; }
    }

    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    private List<PlayerListing> PlayerListings
    {
        get { return _playerListings; }
    }

    //現在のMasterClientが終了したときに新しいMasterClientに切り替えたとき
    public override void OnMasterClientSwitched(Photon.Realtime.Player photonPlayer)
    {
        PhotonNetwork.LeaveRoom();
    }

    //LoadBalancingClientがルームに入ったとき
    public override void OnJoinedRoom()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        MainCanvasManager.Instance.CurrentRoomCanvas.transform.SetAsLastSibling();

        Photon.Realtime.Player[] photonPlayer = PhotonNetwork.PlayerList;
        for (int i = 0; i < photonPlayer.Length; i++)
        {
            PlayerJoinedRoom(photonPlayer[i]);
        }
    }

    //プレイヤーがルームに入ったとき
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player photonPlayer)
    {
        PlayerJoinedRoom(photonPlayer);
    }
    //リモートプレイヤーがルームを出たとき
    public override void OnPlayerLeftRoom(Photon.Realtime.Player photonPlayer)
    {
        PlayerleftRoom(photonPlayer);
    }


    private void PlayerJoinedRoom(Photon.Realtime.Player photonPlayer)
    {
        if (photonPlayer == null)
        {
            return;
        }

        PlayerleftRoom(photonPlayer);

        GameObject playerListingObj = Instantiate(PlayerlistingPrefab);
        playerListingObj.transform.SetParent(transform, false);

        PlayerListing playerlisting = playerListingObj.GetComponent<PlayerListing>();
        playerlisting.ApplyPhotonPlayer(photonPlayer);

        PlayerListings.Add(playerlisting);
    }
    private void PlayerleftRoom(Photon.Realtime.Player photonPlayer)
    {
        int index = PlayerListings.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if (index != -1)
        {
            Destroy(PlayerListings[index].gameObject);
            PlayerListings.RemoveAt(index);
        }
    }

    public void OnClick_LaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

}