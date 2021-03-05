using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // コレ重要

public class BGMPlayer : MonoBehaviour
{
    public AudioClip[] bgm;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            this.GetComponent<AudioSource>().clip = bgm[SceneManager.GetActiveScene().buildIndex];
            this.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
