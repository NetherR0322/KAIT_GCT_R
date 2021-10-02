using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class ShellfishScript : MonoBehaviourPunCallbacks
{
    GameObject[] tagObjects;

    void Start()
    {
        KaiScript.rate = 0;

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

            Check("Kai");

            //KanegaeGameManager.score += 10;
            KaiScript.rate += 1;
           
            Debug.Log("Rate:" + KaiScript.rate);
            Debug.Log("Score:" + KanegaeGameManager.score);
            Debug.Log("trueにしました");

            

            Destroy(this.gameObject);
            KanegaeGameManager.checkScore = false;

            Debug.Log("falseにしました");
            
        }

    }

    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        if (tagObjects.Length == 0)
        {
            // Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }

        foreach(GameObject Kai in tagObjects)
        {
        }

            
    }

}
