﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class ShellfishScript : MonoBehaviourPunCallbacks
{

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たりました");
        if (collision.gameObject.tag == "tako")
        {
            

            
            KanegaeGameManager.checkScore = true;
            
            KanegaeGameManager.score += 10;
            KanegaeGameManager.rate += 1;
            Debug.Log("Rate:" + KanegaeGameManager.rate);
            Debug.Log("Score:" + KanegaeGameManager.score);
            Debug.Log("trueにしました");
            Destroy(this.gameObject);
            KanegaeGameManager.checkScore = false;

            Debug.Log("falseにしました");

        }
    }
}
