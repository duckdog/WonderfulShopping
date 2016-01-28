using UnityEngine;
using System.Collections;

// 方向指定用列挙体
public enum direction
{
    UP = 0,
    DOWN = 1,
    LEFT = 2,
    RIGHT = 3,
    DEFAULT = 4
};

public class SwipeSystem : MonoBehaviour
{
    // スワイプ判定の最低距離
    private float _minSwipeDestX = 5;
    private float _minSwipeDestY = 5;
    // スワイプした距離
    private float _swipeDistX;
    private float _swipeDistY;
    // スワイプした方向
    float _SignValueX;
    float _SignValueY;
    // タッチ開始位置
    private Vector2 _startPos;
    // タッチ終了位置
    private Vector2 _endPos;

    public direction isSwipe(GameObject obj)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            var ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                switch (touch.phase)
                {
                    // タッチ開始
                    case TouchPhase.Began:
                        // タッチした場所にオブジェクトがあればポジションを取得
                        if (hit.collider == obj.GetComponent<Collider>())
                        {
                            Debug.Log("タッチ開始！！");
                            _startPos = touch.position;
                        }
                        break;

                    // タッチ終了
                    case TouchPhase.Ended:
                        Debug.Log("タッチ終了！！");
                        _endPos = new Vector2(touch.position.x, touch.position.y);

                        // 横方向のスワイプ
                        _swipeDistX = (new Vector3(_endPos.x, 0, 0) - new Vector3(_startPos.x, 0, 0)).magnitude;
                        //Debug.Log("X" + _swipeDistX.ToString());

                        if (_swipeDistX > _minSwipeDestX)
                        {
                            _SignValueX = Mathf.Sign(_endPos.x - _startPos.x);
                            // 右方向にスワイプした時
                            if (_SignValueX > 0)
                            {
                                Debug.Log("RIGHT SWIPE!!");
                                return direction.RIGHT;
                            }
                            // 左方向にスワイプした時
                            else if (_SignValueX < 0)
                            {
                                Debug.Log("LEFT SWIPE!!");
                                return direction.LEFT;
                            }
                        }

                        // 縦方向のスワイプ
                        _swipeDistY = (new Vector3(0, _endPos.y, 0) - new Vector3(0, _startPos.y, 0)).magnitude;
                        //Debug.Log("Y" + _swipeDistY.ToString());

                        if (_swipeDistY > _minSwipeDestY)
                        {
                            _SignValueY = Mathf.Sign(_endPos.y - _startPos.y);
                            // 上方向にスワイプした時
                            if (_SignValueY > 0)
                            {
                                Debug.Log("UP SWIPE!!");
                                return direction.UP;
                            }
                            else if (_SignValueY < 0)
                            {
                                Debug.Log("DOWN SWIPE!!");
                                return direction.DOWN;
                            }
                        }
                        break;
                }
            }
            else
            {
                return direction.DEFAULT;
            }
        }
        return direction.DEFAULT;
    }
}

