using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posChange : MonoBehaviour
{
    public GameObject root;
    public GameObject[] asi = new GameObject[256];
    public Vector3[] asiLinePos = new Vector3[256];
    public GameObject top;
    public GameObject boneBase;
    public int boneCount;
    public float delay;
    LineRenderer LR;
    public AnimationCurve defAsi;
    public AnimationCurve upAsi;

    public float maxDist;
    public float denger;

    private asiMover4 asiMover4;

    public Vector2 startPos;

    public GameObject mainObject;

    Vector2 targetPos;
    Vector2 targetPos2;
    float dist;

    public Material LasiMat;
    public Material RasiMat;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3();
        asiMover4 = top.GetComponent<asiMover4>();
        LR = GetComponent<LineRenderer>();
        LR.positionCount = boneCount;
        Vector2 thisPos = this.transform.position;
        for (int i = 0; i < boneCount; i++)
        {
           // if (i == 0) 
                pos = new Vector3(thisPos.x + i * startPos.x, thisPos.y + i * startPos.y, 0);
            Debug.Log(i * startPos.x);
            //if (i != 0) pos = new Vector3(thisPos.x + i * startPos.x, thisPos.y + i * startPos.y, 0) - this.transform.position;
            GameObject asiIns = Instantiate(boneBase, pos, Quaternion.identity, root.transform);
            asiIns.name = "asi-" + i;
            asi[i] = asiIns;
            asiLinePos[i] = asi[i].transform.position;
        }
        top.transform.position = this.transform.position+new Vector3(startPos.x*16,startPos.y*16);// asi[boneCount - 1].transform.position + this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (top.transform.position.x < root.transform.position.x) LR.material = LasiMat;
        if (top.transform.position.x > root.transform.position.x) LR.material = RasiMat;
        targetPos = asi[boneCount - 1].transform.position;
        targetPos2 = root.transform.position;
        dist = Mathf.Sqrt(Mathf.Pow(targetPos2.x - targetPos.x, 2) + Mathf.Pow(targetPos2.y - targetPos.y, 2));//
                                                                                                               //Debug.Log(dist);
        float dengerVal;
        dengerVal = maxDist - denger;
        dengerVal = (dist - denger) / dengerVal;
        LR.endColor = new Color(1 - dengerVal, 1 - dengerVal, 1);
        if (!asiMover4.isHave)
        {
            LR.widthCurve = defAsi;
            asi[boneCount - 1].transform.position= top.transform.position;
        }
        if (asiMover4.isHave)
        {
            LR.widthCurve = upAsi;
        }
        for (int i = 0; i < boneCount; i++)
        {
            Rigidbody2D rb = asi[i].GetComponent<Rigidbody2D>();
            float x;
            float y;
            float x2;
            float y2;
            int l = boneCount;
            Vector3 topPos = top.transform.position;// + this.transform.position;
            Vector3 rootPos = root.transform.position;
            Vector3 asiPos = new Vector3(0, 0, 0);
            //Debug.Log(rootPos);
            x = topPos.x - rootPos.x;
            y = topPos.y - rootPos.y;
            asiPos.x = x / (l - 1) * i;
            asiPos.y = y / (l - 1) * i;
            x2 = asiPos.x - asi[i].transform.position.x;
            y2 = asiPos.y - asi[i].transform.position.y;
            Vector2 pos = asi[i].transform.position;

            //if (asiMover2.isHave) 
            asi[i].transform.position = asiPos;
            //asi[i].transform.position = new Vector3(pos.x + x2, pos.y + y2, 0);
            asi[i].transform.position += rootPos ;
            //targetPos = asi[i].transform.position;
            //dist = Mathf.Sqrt(Mathf.Pow(asiposX - targetPos.x, 2) + Mathf.Pow(asiposY - targetPos.y, 2));//
            float asiDistX = (asiPos.x+rootPos.x)-asiLinePos[i].x;
            float asiDistY = (asiPos.y+rootPos.y)-asiLinePos[i].y;
            asiLinePos[i] = new Vector3(asiLinePos[i].x+(asiDistX / (i * delay))
                                       ,asiLinePos[i].y+(asiDistY / (i * delay)),0);
            //asiLinePos[i] = asiPos;
            //asiLinePos[i].x += 1.0f;
            LR.SetPosition(i, asiLinePos[i]);
            LR.SetPosition(0, rootPos);

        }
        //Debug.Log(asiLinePos[1]);
    }
}
