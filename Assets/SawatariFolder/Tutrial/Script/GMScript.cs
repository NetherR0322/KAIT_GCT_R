using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{

    // Start is called before the first frame update
    public static int gamestate;
    public static bool Movetutrial;
    public static bool Jumptutrial;
    public static bool Mizututrial;
    void Start()
    {
        gamestate = 0;
        Movetutrial = true;
        Jumptutrial = false;
        Mizututrial = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Movetutrial==true&&gamestate == 0) { 
        
        
        }

    }
}
