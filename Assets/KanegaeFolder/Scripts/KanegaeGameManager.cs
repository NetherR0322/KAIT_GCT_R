using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KanegaeGameManager : MonoBehaviour
{
    public GameObject Pose;

    public static int score;

    public static int rate;

    public static bool checkScore = false;

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI RateText;

    public TextMeshProUGUI LengthText;

    private float len = 0.0f;

    Vector2 goal = GameObject.Find("Goal").transform.position;

    GameObject[] gos;

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
        LengthCheck();//距離を測るメソッドです

        LengthText.text = "Length:" + len;//海までの長さ

        ScoreText.text = "Score:"+score;
        RateText.text = "Rate:"+rate+"/2";//分母はステージによって変えてください(;w;)
    }

    private float LengthCheck()
    {

        gos = GameObject.FindGameObjectsWithTag("tako");
        foreach (GameObject go in gos)
        {
            len = goal.y - go.transform.position.y;
        }
        return len;
    }
}
