using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class Goal : MonoBehaviourPunCallbacks
{
    float time = 0;

    public static bool flag=false;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;   
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "tako"&&flag==false)
        {
        }
    }

    [PunRPC]
    private void IsHit()
    {
        GameObject tako = GameObject.Find("tako");
        //Cursor.visible = true;
        FadeManager.Instance.LoadLevel("ResultScene", 2f);
        flag = true;
        LimitScript.countCheck = false;
    }
}
