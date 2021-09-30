using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    /*public TextMeshProUGUI ScoreResultText;

    public TextMeshProUGUI RateResultText;

    public TextMeshProUGUI ClearTimeText;*/
    public Text ScoreResultText;

    public Text RateResultText;

    public Text ClearTimeText;

    void Start()
    {
        ScoreResultText.text = "スコア:" + KanegaeGameManager.score;
        RateResultText.text = "レート:" + KaiScript.rate + "/" + KaiScript.M_rate;//ここの分母もおねがいします～(;w;)
        ClearTimeText.text = "クリアタイム:" + LimitScript.limit.ToString("f0") + "秒";
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
