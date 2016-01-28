using UnityEngine;
using System.Collections;

/*public class SwipeSystem2D : MonoBehaviour
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
	RaycastHit2D _hitObject;


	public void isSwipe()
    {
		if (Input.touchCount > 0) {
			//タッチ位置取得、カメラから
			Touch _touch = Input.GetTouch (0);
			Vector3 _screen_point = Camera.main.WorldToScreenPoint (Vector3.zero);
			Vector3 _new_vector = Camera.main.ScreenToWorldPoint (new Vector3 (_touch.position.x, _touch.position.y, _screen_point.z));

			Vector2 _tap_pos = new Vector2 (_new_vector.x, _new_vector.y);
			Collider2D collition2d = Physics2D.OverlapPoint (_tap_pos);

			switch (_touch.phase) {
			// タッチ開始
			case TouchPhase.Began:
				if (collition2d) {

					_hitObject = Physics2D.Raycast (_tap_pos, -Vector2.up);

					// タッチした場所にオブジェクトがあればポジションを取得
					if (_hitObject) {
						Debug.Log ("タッチ開始！！");
						_startPos = _touch.position;
					}
				}
			
				break;

			// タッチ終了
			case TouchPhase.Ended:

				Debug.Log ("タッチ終了！！");

				_endPos = new Vector2 (_touch.position.x, _touch.position.y);

                    // 横方向のスワイプ
				_swipeDistX = (new Vector3 (_endPos.x, 0, 0) - new Vector3 (_startPos.x, 0, 0)).magnitude;
                    //Debug.Log("X" + _swipeDistX.ToString());

				if (_swipeDistX > _minSwipeDestX) {
					_SignValueX = Mathf.Sign (_endPos.x - _startPos.x);
					// 右方向にスワイプした時
					if (_SignValueX > 0) {
						Debug.Log ("RIGHT SWIPE!!");
						if (_hitObject.collider.gameObject.GetComponent<QTETap> () != null) {
							if (_hitObject.collider.gameObject.GetComponent<QTETap> ().Direction == direction.RIGHT) {

								_hitObject.collider.gameObject.GetComponent<QTETap> ().DoSwipe = true;

							}
						}
					
					}    // 左方向にスワイプした時
                     else if (_SignValueX < 0) {
						Debug.Log ("LEFT SWIPE!!");
						if (_hitObject.collider.gameObject.GetComponent<QTETap> () != null) {
							if (_hitObject.collider.gameObject.GetComponent<QTETap> ().Direction == direction.LEFT) {

								_hitObject.collider.gameObject.GetComponent<QTETap> ().DoSwipe = true;

							}
						}
					
					}
				}
                // 縦方向のスワイプ
				_swipeDistY = (new Vector3 (0, _endPos.y, 0) - new Vector3 (0, _startPos.y, 0)).magnitude;
                    //Debug.Log("Y" + _swipeDistY.ToString());
				if (_swipeDistY > _minSwipeDestY) {
					_SignValueY = Mathf.Sign (_endPos.y - _startPos.y);

					// 上方向にスワイプした時
					if (_SignValueY > 0) {
						if (_hitObject.collider.gameObject.GetComponent<QTETap> () != null) {
							if (_hitObject.collider.gameObject.GetComponent<QTETap> ().Direction == direction.UP) {

								_hitObject.collider.gameObject.GetComponent<QTETap> ().DoSwipe = true;
							}
						}
					} else if (_SignValueY < 0) {
						if (_hitObject.collider.gameObject.GetComponent<QTETap> () != null) {
							if (_hitObject.collider.gameObject.GetComponent<QTETap> ().Direction == direction.DOWN) {

								_hitObject.collider.gameObject.GetComponent<QTETap> ().DoSwipe = true;

							}
						}
					}
				}
				break;
			}
		}
        
    }




	void Update(){
		isSwipe ();
	}




}

*/