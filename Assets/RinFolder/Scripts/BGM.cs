using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        if(!GameObject.Find(obj.name))DontDestroyOnLoad(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
