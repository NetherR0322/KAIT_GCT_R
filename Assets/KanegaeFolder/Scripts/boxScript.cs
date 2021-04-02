using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    [SerializeField]
    public GameObject Box;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tako") 
        {
            Destroy(Box);
           
            GameObject obj = (GameObject)Resources.Load("box_break");
            
            Instantiate(obj, new Vector2(-4.0f, 0.0f), Quaternion.identity);//座標のところに木箱の座標をお願いします

            //Resourceから取ってるんですけどResourceフォルダがわからないので後々お願いします
            //ふつうにうえからかさねてデストロイでもありかも...?
        }
    }
}
