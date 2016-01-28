using UnityEngine;
using System.Collections;

public class QTETouch : MonoBehaviour
{

	//引数のobjとRayを判定 
	public bool isRayTouch(GameObject obj)
	{
	    if (Input.touchCount > 0)
		{
			Touch _touch = Input.GetTouch(0);
			Vector3 _screen_point = Camera.main.WorldToScreenPoint(obj.transform.position);
			Vector3 _new_vector = Camera.main.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, _screen_point.z));

			Vector2 _tap_pos = new Vector2(_new_vector.x, _new_vector.y);
			Collider2D collition2d = Physics2D.OverlapPoint(_tap_pos);

			// 画面を触りながら指を動かすだけで反応しないように
			// 触った瞬間にのみ判定
			if (_touch.phase == TouchPhase.Began)
			{

				Debug.DrawRay (_tap_pos, -Vector2.up, Color.blue, 3.0f, false);

				if (collition2d)
				{

					RaycastHit2D hitObject = Physics2D.Raycast(_tap_pos, -Vector2.up);

					Debug.DrawRay(_tap_pos,-Vector2.up,Color.blue,3.0f,false);

					Debug.Log("通過テスト２");
					if (hitObject)
					{
						Debug.Log("通過テスト３");
						Debug.Log("hit object is " + hitObject.collider.gameObject.name);
						return false;
					}
				}
			}
			else if (_touch.phase == TouchPhase.Ended)
			{
				return false;
			}
		}
		return false;
	}

	void Update(){


		if (Input.touchCount > 0) {

			Touch _touch = Input.GetTouch (0);
			Vector3 _screen_point = Camera.main.WorldToScreenPoint(Vector3.zero);
			Vector3 _new_vector = 
				Camera.main.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y,_screen_point.z));
			Vector2 _tap_pos = new Vector2 (_new_vector.x, _new_vector.y);
			Collider2D collition2d = Physics2D.OverlapPoint (_tap_pos);

			// 画面を触りながら指を動かすだけで反応しないように
			// 触った瞬間にのみ判定
			if (_touch.phase == TouchPhase.Began) {

				Debug.DrawRay (_tap_pos, -Vector2.up, Color.blue, 3.0f, false);
			
				if (collition2d) {

					RaycastHit2D hitObject = Physics2D.Raycast (_tap_pos, -Vector2.up);
					if(hitObject.collider.gameObject.GetComponent<QTETap> () != null)
					hitObject.collider.gameObject.GetComponent<QTETap> ().DoTouch = true;
				}
			}
		}


	}



}






