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

        ScoreText.text = "Score:"+score;
        RateText.text = "Rate:"+rate+"/2";//分母はステージによって変えてください(;w;)
    }
}
