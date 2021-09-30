using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GageScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;

    private float count = 0f;

    private float dist = 0f;

    public GameObject GageTako;

    public GameObject Tako;

    public Transform tako;

    public Transform goal;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
      dist = Map(tako.transform.position.y,143,342,-600,270);

        GageTako.transform.localPosition = new Vector3(GageTako.transform.localPosition.x, dist, GageTako.transform.localPosition.z);

       // Debug.Log(dist);
    }

    float Map(float val, float beforemin, float beforemax, float aftermin, float aftermax)
    {
        if (beforemax - beforemin != 0)
        {
            return (val - beforemin) * (aftermax - aftermin) / (beforemax - beforemin) + aftermin;
        }
        else
        {
            return 0;
        }
    }

}

