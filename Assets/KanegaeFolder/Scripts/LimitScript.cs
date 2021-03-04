using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class LimitScript : MonoBehaviour
{
    [SerializeField]
    public static float limit = 300.0f;

    public TextMeshProUGUI LimitText;

    bool flag=false;
    void Start()
    {
        limit = 300.0f;
    }

    void Update()
    {
        limit -= Time.deltaTime;

        LimitText.text = limit.ToString("f2") + "sec";

        if (limit <= 0&&flag==false)
        {
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
            flag = true;
        }
    }
}
