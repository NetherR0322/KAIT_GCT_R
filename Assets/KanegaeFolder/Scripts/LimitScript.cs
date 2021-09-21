using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class LimitScript : MonoBehaviour
{
    [SerializeField]
    public static float limit = 700.0f;

    //public TextMeshProUGUI LimitText;
    public Text LimitText;

    bool flag = false;

    public static bool countCheck = true;
    void Start()
    {
        limit = 360.0f;
        countCheck = true;
    }

    void Update()
    {
        if (countCheck == true)
        {
            limit -= Time.deltaTime;

            LimitText.text = "残り" + limit.ToString("f0") + "秒";
        }

        if (limit <= 0 && flag == false)
        {
            Cursor.visible = true;
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
            flag = true;
            
        }

    }

}
