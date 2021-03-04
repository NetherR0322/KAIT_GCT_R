using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ami : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 11f);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "tako")
        {
            Destroy(this);
            SceneManager.LoadScene("GameOverScene"); //シーン切り替え
        }
    }
}
