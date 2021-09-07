using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void open(GameObject go)
    {
        BGMPlayer.GetInstance().PlaySound(0);
        go.SetActive(true);
    }
    public void close(GameObject go)
    {
        BGMPlayer.GetInstance().PlaySound(0);
        go.SetActive(false);
    }
}
