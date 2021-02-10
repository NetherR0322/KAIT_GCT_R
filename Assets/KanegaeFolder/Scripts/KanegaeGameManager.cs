using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanegaeGameManager : MonoBehaviour
{
    public GameObject Pose;
    [SerializeField]
    static public bool OnPose = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OnPose == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPose = true;
                Pose.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPose = false;
                Pose.SetActive(false);
            }
        }
    }
}
