using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posChange : MonoBehaviour
{
    public GameObject root;
    public GameObject[] asi = new GameObject[256];
    public GameObject top;
    public GameObject boneBase;
    public int boneCount;
    public float delay;
    LineRenderer LR;
    public AnimationCurve defAsi;
    public AnimationCurve upAsi;

    public float maxDist;
    public float denger;

    private asiMover2 asiMover2;

    Vector2 targetPos;
    Vector2 targetPos2;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3();
        asiMover2 = top.GetComponent<asiMover2>();
        LR = GetComponent<LineRenderer>();
        LR.positionCount = boneCount;
        for (int i = 0; i < boneCount; i++)
        {
            Vector2 thisPos = this.transform.position;
            if (i == 0) pos = new Vector3(thisPos.x, thisPos.y - i * 0.1f, 0);
            if (i != 0) pos = new Vector3(thisPos.x, thisPos.y - i * 0.1f, 0) - this.transform.position;
            GameObject asiIns = Instantiate(boneBase, pos, Quaternion.identity, root.transform);
            asiIns.name = "asi-" + i;
            asi[i] = asiIns;
        }
        top.transform.position = asi[boneCount - 1].transform.position + this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = asi[boneCount - 1].transform.position + this.transform.position;
        targetPos2 = root.transform.position;
        dist = Mathf.Sqrt(Mathf.Pow(targetPos2.x - targetPos.x, 2) + Mathf.Pow(targetPos2.y - targetPos.y, 2));//
                                                                                                               //Debug.Log(dist);
        float dengerVal;
        dengerVal = maxDist - denger;
        dengerVal = (dist - denger) / dengerVal;
        LR.endColor = new Color(1 - dengerVal, 1 - dengerVal, 1);
        if (!asiMover2.isHave)
        {
            LR.widthCurve = defAsi;
            top.transform.position = asi[boneCount - 1].transform.position + this.transform.position;
        }
        if (asiMover2.isHave)
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
            float asiposX;
            float asiposY;
            int l = boneCount;
            x = top.transform.position.x - root.transform.position.x;
            y = top.transform.position.y - root.transform.position.y;
            asiposX = x / (l - 1) * i;
            asiposY = y / (l - 1) * i;
            x2 = asiposX - asi[i].transform.position.x;
            y2 = asiposY - asi[i].transform.position.y;
            Vector2 pos = asi[i].transform.position;

            if (asiMover2.isHave) asi[i].transform.position = new Vector3(pos.x + x2 / (i * delay), pos.y + y2 / (i * delay),0);

            targetPos = asi[i].transform.position;
            dist = Mathf.Sqrt(Mathf.Pow(asiposX - targetPos.x, 2) + Mathf.Pow(asiposY - targetPos.y, 2));//
            if (i == 0) LR.SetPosition(i, asi[i].transform.position);
            if (i != 0) LR.SetPosition(i, asi[i].transform.position + this.transform.position);
        }
    }
}
