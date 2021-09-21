using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveLobbySelect : MonoBehaviour
{
    public GameObject LobbySelect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick_LobbySelect()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        LobbySelect.SetActive(true);
    }
}
