using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void GoMapChoose()
    {
        SceneManager.LoadScene("MapChooseScene");
    }

    public void ReturnGame()
    {
        GameObject Pose = GameObject.Find("Canvas");
        KanegaeGameManager.OnPose = false;
        Pose.SetActive(false);
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("TakoTitleScene");
    }

    public void GoGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}


