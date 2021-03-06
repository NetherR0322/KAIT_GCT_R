using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    float time = 0;

    bool flag;
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
            GameObject tako = GameObject.Find("tako");
            Cursor.visible = true;
            SceneManager.LoadSceneAsync("ResultScene", LoadSceneMode.Additive);
            flag = true;
            LimitScript.countCheck = false;
        }
    }
}
