using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    public Photon.Realtime.Player PhotonPlayer { get; private set; }

    [SerializeField]
    private Text _playerName;
    private Text PlayerName
    {
        get { return _playerName; }
    }
    /*
    [SerializeField]
    private Image _playerColor;
    private Image PlayerColor
    {
        get { return _playerColor; }
    }

    Color SpriteColor;
    bool one_id = false;
    int id;*/
    public void ApplyPhotonPlayer(Photon.Realtime.Player photonPlayer)
    {
        //マスタークラインか判定
        if (photonPlayer.IsMasterClient)
        {
            PhotonPlayer = photonPlayer;
            PlayerName.text = photonPlayer.NickName;
        }
        else
        {
            PhotonPlayer = photonPlayer;
            PlayerName.text = photonPlayer.NickName;
        }
    }
}
