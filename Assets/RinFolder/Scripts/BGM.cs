using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find(obj.name))
        {
            GameObject objGO = Instantiate(obj, new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
            objGO.name = obj.name;
            DontDestroyOnLoad(objGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
