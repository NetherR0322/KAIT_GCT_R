using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KanegaeGameManager : MonoBehaviour
{
    public GameObject Pose;

    public static int score;

    public static bool checkScore = false;

    public TextMeshProUGUI ScoreText;

    [SerializeField]
    static public bool OnPose = false;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkScore == true)
        {
           // Debug.Log("trueになったのでスコア足します");
            //score += 10;
            Debug.Log("Score:" + score);
        }
       

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
    }
}
