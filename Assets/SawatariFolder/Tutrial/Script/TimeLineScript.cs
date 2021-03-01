using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineScript : MonoBehaviour
{
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayNumber()
    {

        text.text = Random.Range(0, 100).ToString();

    }
}