using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaiScript : MonoBehaviour
{
    GameObject[] tagObjects;

    public GameObject Kai_UI;

    public static int rate;

    public static int M_rate = 0;

    public Text Ratetext;

    // Start is called before the first frame update
    void Start()
    {
        Check("Kai");
        M_rate = tagObjects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Check("Kai");

        Ratetext.text = rate + "/" + M_rate;

        if (tagObjects.Length <= 0)
        {
            Kai_UI.gameObject.SetActive(false);
            Ratetext.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        GameObject[] Kais = GameObject.FindGameObjectsWithTag(tagname);

        if (tagObjects.Length == 0)
        {
            // Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
       
    }
}
