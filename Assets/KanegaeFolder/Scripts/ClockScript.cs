using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{

    public GameObject Clock_hari;

    public float lim_hari = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lim_hari = LimitScript.limit;

        lim_hari += Time.deltaTime;

        Clock_hari.transform.rotation = Quaternion.Euler(0, 0, lim_hari);
    }
}
