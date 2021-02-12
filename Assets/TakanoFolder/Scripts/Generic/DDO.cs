using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDO : MonoBehaviour
{
    private void Awake()
    {
            //シーン遷移しても消えない設定
            DontDestroyOnLoad(this);
    }
}
