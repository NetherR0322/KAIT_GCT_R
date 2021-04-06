using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public   GameObject buttonon ;//ボタンが押されている状態のスプライトを格納する為の変数
    public  GameObject buttonoff;//ボタンが押されていない状態のスプライトを格納する為の変数
    //↑ボタンの変数
    public static bool DoorOpen = false;//ドアが開いているか閉じているかの変数
    public  float DistanceValue = 1.5f;//扉が開く幅
    public float speed = 0.003f;//扉が開くスピード
    public  float Distance;//扉が開く幅を格納してコード内部で使用する為の変数
  
    public  GameObject DoorL;//ドアの左側のスプライトを格納する為の変数
    public  GameObject DoorR;//ドアの右側のスプライトを格納する為の変数
    //↑ドアの変数
    [SerializeField]
    private  bool ButtonState = false;//ボタンが押されてるか押されていないかの変数.trueなら押されている、falseなら押されていない
    private  bool ButtonEnabled = true;//ボタンが有効かどうかの変数。こうしないとボタンが永遠に連打され続ける。
    private bool DoorStart = false;//ドアの開閉処理を開始するかどうかの変数。trueで開始する。
    void Start()
    {
        Distance = DistanceValue;
      
    }
   private void Update()//ドアを動かすコードのみ入っている
    {
        if (ButtonState == true && DoorStart == true)//ButtonStateがtrue(ドアが開いてる状態)で且つDoorStartがtrueの場合ドアを閉める処理を実行
        {
            DoorR.transform.Translate(Vector3.right * speed);
            DoorL.transform.Translate(Vector3.right * speed);
            Distance -= speed;//Distanceからspeedを引いて行く
            

            if (Distance <= 0)//Distanceが0以下になった場合ドアを閉める処理を終了
            {
                
                DoorOpen = true;
                Distance = DistanceValue;
                DoorStart = false;

                ButtonState = false;

            }
        }else if (ButtonState == false && DoorStart == true)//ButtonStateがfalse(ドアが閉じている状態)で且つDoorStartがtrueの場合ドアを閉める処理を実行
        {
            DoorR.transform.Translate(Vector3.left * speed);
            DoorL.transform.Translate(Vector3.left * speed);
            Distance -= speed;
          

            if (Distance <= 0)//Distanceが0以下になった場合ドアを開ける処理を終了
            {
               
                DoorOpen = true;
                Distance = DistanceValue;
                DoorStart = false;

                ButtonState = true;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        

            if (ButtonState == true && ButtonEnabled == true)
            {
                buttonoff.gameObject.SetActive(true);
                buttonon.gameObject.SetActive(false);
                ButtonEnabled = false;
                DoorStart = true;
               

            }
            else if (ButtonState == false && ButtonEnabled == true)
            {

                buttonon.gameObject.SetActive(true);
                buttonoff.gameObject.SetActive(false);
                ButtonEnabled = false;
                DoorStart = true;
                //Debug.Log(this.gameObject.name + "と接触しています。");
                
            }

        
    }
    void OnTriggerExit2D(Collider2D col)
    {
       
            if (ButtonEnabled == false)
            {
                ButtonEnabled = true;
            }
        }
    
    }