using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activeSceneChanger : MonoBehaviour
{
    public string sceneName;
    BGMPlayer script;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(scene);
        script = GameObject.Find("BGMPlayer").GetComponent<BGMPlayer>();
        script.BgmChangeTester();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
