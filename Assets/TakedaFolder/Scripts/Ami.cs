using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ami : MonoBehaviour
{
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 11f);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "tako"&&flag==false)
        {
            Destroy(this);
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive); //シーン切り替え
            flag = true;
        }
    }
}
