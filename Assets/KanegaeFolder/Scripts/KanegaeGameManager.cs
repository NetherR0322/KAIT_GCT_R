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

    public static int rate;

    public float Move_Gage;

    public float Move_Gage02;

    public static bool checkScore = false;


    private float len_N;

  //  private bool check_Movement = true;

    public Text ScoreText;

    public Text RateText;

    /*public TextMeshProUGUI LengthText;

    private float len = 0.0f;

    Vector2 goal = GameObject.Find("Goal").transform.position;

    GameObject[] gos;*/

    [SerializeField]
    static public bool OnPose = false;
    void Start()
    {
        score = 0;
        rate = 0;
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


        ScoreText.text = "スコア:"+score;
        RateText.text =rate+"/3";//分母はステージによって変えてください(;w;
        lim_hari += Time.deltaTime;
        if (len_N < len)
        {
            Gage_tako.gameObject.transform.Translate(0, len, 0);
        }
        Clock_hari.transform.rotation = Quaternion.Euler(0,0,-(lim_hari));
    }

    {

        gos = GameObject.FindGameObjectsWithTag("tako");
        foreach (GameObject go in gos)
        {
            len = goal.y - go.transform.position.y;
        }
        return len;
    }*/
}
