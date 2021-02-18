using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LimitScript : MonoBehaviour
{
    [SerializeField]
    public static float limit = 60.0f;

    public TextMeshProUGUI LimitText;

    void Start()
    {

    }

    void Update()
    {
        limit -= Time.deltaTime;

        LimitText.text = limit.ToString("f2") + "sec";

        if (limit <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
