using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KanegaeGameManager : MonoBehaviour
{
    public GameObject Pose;

    public static int score;

    public static int rate;

    public static bool checkScore = false;

    private float len = 0.0f;

    public Text ScoreText;

    public Text RateText;

    public Text LengthText;

    [SerializeField]
    static public bool OnPose = false;
    void Start()
    {
        score = 0;
        rate = 0;
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
        //LengthCheck();//距離を測るメソッドです

       len = LengthCheck();//距離を測るメソッドです

        LengthText.text = "海までの距離:" + len.ToString("f1")+"m";//海までの長さ
        ScoreText.text = "スコア:"+score;
        RateText.text = "レート:"+rate+"/2";//分母はステージによって変えてください(;w;)
    }

    private float LengthCheck()
    {

        Vector2 oq = GameObject.FindGameObjectWithTag("tako").transform.position;

        Vector2 goal = GameObject.Find("Goals").transform.position;

        len = Vector2.Distance(goal, oq);

        return len;
    }
}
