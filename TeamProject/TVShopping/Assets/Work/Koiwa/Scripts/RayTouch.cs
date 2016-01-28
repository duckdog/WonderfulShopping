using UnityEngine;
using System.Collections;

// 親オブジェクトの当たり判定
public class RayTouch : MonoBehaviour
{
    public bool isRayTouch(GameObject obj)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            var ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == obj.GetComponent<Collider>()) {
                    // タッチした瞬間にtrueを返す(タッチを認識)
                    if (touch.phase == TouchPhase.Began)
                    {
                        //Debug.Log("True!!");
                        return true;
                    }
                    // タッチを継続していてもtrueを返す
                    else if (touch.phase == TouchPhase.Stationary)
                    {
                        //Debug.Log("Stationary!!");
                        return true;
                    }
                    // タッチを離した瞬間にfalseを返す
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        //Debug.Log("False!!");
                        return false;
                    }
                }
            }
        }
        return false;
    }
}
