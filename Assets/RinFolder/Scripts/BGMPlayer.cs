using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    public int[] sceneId;
    public AudioClip[] bgm;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    // Update is called once per frame
    void Update(){}

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log("sceneIndex:"+SceneManager.GetActiveScene().buildIndex);
        for (int i = 0; i < bgm.Length; i++)
        {
            if (sceneId[i] == SceneManager.GetActiveScene().buildIndex)
            {
                this.GetComponent<AudioSource>().clip = bgm[i];
                this.GetComponent<AudioSource>().Play();
            }
        }
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        Debug.Log("sceneIndex:" + SceneManager.GetActiveScene().buildIndex);
        for (int i = 0; i < bgm.Length; i++)
        {
            if (sceneId[i] == SceneManager.GetActiveScene().buildIndex)
            {
                this.GetComponent<AudioSource>().clip = bgm[i];
                this.GetComponent<AudioSource>().Play();
            }
        }
    }
}
