using UnityEngine;
using System.Collections;

public class OperationSystem : MonoBehaviour
{
    void Update()
    {
        isTouch();
    }


    // タッチ判定(画面全体)
    void isTouch()
    {
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("return true");
            }
            else
            {
                //Debug.Log("return false");
            }
        }
        else
        {
            //Debug.Log("return false");
        }
    }


    // ダブルタップ


    // スワイプ


    // ホールド
}
