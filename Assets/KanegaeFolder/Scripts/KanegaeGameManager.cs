using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KanegaeGameManager : MonoBehaviour
{
    public GameObject Pose;

    public GameObject Clock_hari;

    public GameObject Gage_tako;

    public static int score;

    //public static int rate;

    public float Move_Gage;

    public float Move_Gage02;

    public static bool checkScore = false;

    public float lim_hari = LimitScript.limit / 360f;

    private float len = 0.0f;

    private float len_N;

  //  private bool check_Movement = true;

    public Text ScoreText;

    //public Text RateText;

    public Text LengthText;

    [SerializeField]
    static public bool OnPose = false;
    void Start()
    {
        score = 0;
        //rate = 0;
       // Move_Gage = 0.0f;
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
        len_N = len;
        LengthText.text = "海までの距離:" + len.ToString("f1")+"m";//海までの長さ
        ScoreText.text = "スコア:"+score;
        //分母はステージによって変えてください(;w;
        lim_hari += Time.deltaTime;
      
        Clock_hari.transform.rotation = Quaternion.Euler(0,0,-(lim_hari));
    }

   

    private float LengthCheck()
    {

        Vector2 oq = GameObject.FindGameObjectWithTag("tako").transform.position;

        Vector2 goal = GameObject.Find("Goals").transform.position;

        len = Vector2.Distance(goal, oq);

        return len;
    }
}
