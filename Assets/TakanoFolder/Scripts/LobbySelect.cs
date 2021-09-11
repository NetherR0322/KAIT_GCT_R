using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySelect : MonoBehaviour
{
    public GameObject CreateRoomLobby;
    public GameObject SearchRoomLobby;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void On_click_CreateRoomLobby()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        SearchRoomLobby.SetActive(false);
        CreateRoomLobby.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void On_click_SearchRoomLobby()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        CreateRoomLobby.SetActive(false);
        SearchRoomLobby.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
