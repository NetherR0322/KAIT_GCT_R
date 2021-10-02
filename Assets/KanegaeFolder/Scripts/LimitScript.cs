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
    public static float limit = 270.0f;

    

    //public TextMeshProUGUI LimitText;
    public Text LimitText;

    public static bool flag = false;

    public static float M_limit = 270.0f;

    public static bool countCheck = true;
    void Start()
    {
        M_limit = 270.0f;
        limit = 270.0f;
        countCheck = true;
        flag = false;
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
            //Cursor.visible = true;
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
            flag = true;
            
        }

    }

}
