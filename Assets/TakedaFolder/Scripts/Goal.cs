using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.Translate(0,-0.10f*Time.deltaTime, 0);

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "tako")
        {
            GameObject tako = GameObject.Find("tako");
            SceneManager.LoadScene("End"); //シーン切り替え
        }
    }
}
