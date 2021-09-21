using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    public int[] sceneId;
    public AudioClip[] bgm;
    public AudioClip[] se;

    static BGMPlayer Instance = null;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){}

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        BgmChangeTester();
    }

    void ActiveSceneChanged(Scene thisScene, Scene nextScene)
    {
        BgmChangeTester();
    }

    public void BgmChangeTester() {
        //Debug.Log("sceneIndex:" + SceneManager.GetActiveScene().buildIndex);
        for (int i = 0; i < bgm.Length; i++)
        {
            if (sceneId[i] == SceneManager.GetActiveScene().buildIndex)
            {
                audioSource.clip = bgm[i];
                audioSource.Play();
            }
        }
    }
    public static BGMPlayer GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<BGMPlayer>();
        }
        return Instance;
    }
    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(se[index]);
    }
}
