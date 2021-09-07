using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KanegaeTitleManager : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            BGMPlayer.GetInstance().PlaySound(0);
            SceneManager.LoadScene(1);
        }
    }
}
