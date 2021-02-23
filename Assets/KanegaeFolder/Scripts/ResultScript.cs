﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreResultText;

    public TextMeshProUGUI RateResultText;

    public TextMeshProUGUI ClearTimeText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreResultText.text = "ResultScore : " + KanegaeGameManager.score;
        RateResultText.text = "RastRate : " + KanegaeGameManager.rate+" / 2";//ここの分母もおねがいします～(;w;)
        ClearTimeText.text = "ClearTime : " + LimitScript.limit.ToString("f2")+"sec";
    }   
}