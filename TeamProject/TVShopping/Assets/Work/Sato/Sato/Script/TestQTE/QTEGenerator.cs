using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QTEGenerator : MonoBehaviour {

	private float _timer = 0.0f;

	public enum Type{

		Tap,
		UpSwipe,
		DownSwipe,
		LeftSwipe,
		RightSwipe,

		Last
	}

	QTETouch _ray_touch;
	[SerializeField]
	private GameObject Icon;

	//QTE情報

	public struct QTEStatus{

		public int _type;
		public float _instantiate_time;
		public float _time_limit;
		public Vector2 _pos;
	

		public QTEStatus(Type type,float instantiate_time,float time_limit,Vector2 pos){

			_type = (int)type;
			_instantiate_time = instantiate_time;
			_time_limit = time_limit;
			_pos = pos;

		}	

	}
	//
	public List<QTEStatus> _qte_infos;


	//生成
	public void Create(QTEStatus status){
		//生成
		var _icon = Instantiate(Icon);
		//位置情報と、制限時間を与えす
		_icon.name = Random.Range (0, 100).ToString ();
		_icon.transform.position = status._pos;
		_icon.GetComponent<QTETap>().Type = (Type)status._type;
		_icon.GetComponent<QTETap>().TimeLimit = status._time_limit;
	
	}


	void Start (){
	
		//test
		_qte_infos = new List<QTEStatus> ();
		_qte_infos.Add(new QTEStatus(Type.Tap,8.0f,2.0f,new Vector2(5,3) ));
		_qte_infos.Add(new QTEStatus(Type.LeftSwipe,11.0f,2.0f,new Vector2(-5,3) ));
		_qte_infos.Add(new QTEStatus(Type.Tap,20.0f,2.0f,new Vector2(5,3) ));
		_qte_infos.Add(new QTEStatus(Type.Tap,29.0f,2.0f,new Vector2(-5,3) ));
		_qte_infos.Add(new QTEStatus(Type.Tap,32.0f,2.0f,new Vector2(5,3) ));

		_qte_infos.Add(new QTEStatus(Type.Tap,35.0f,2.0f,new Vector2(-5,3) ));
		_qte_infos.Add(new QTEStatus(Type.Tap,44.0f,2.0f,new Vector2(5,3) ));
		_qte_infos.Add(new QTEStatus(Type.Tap,47.0f,2.0f,new Vector2(-5,3) ));
		_qte_infos.Add(new QTEStatus(Type.Tap,41.0f,2.0f,new Vector2(5,3) ));
		_qte_infos.Add(new QTEStatus(Type.Tap,68.0f,2.0f,new Vector2(-5,3) ));




	}


	void Update (){
	
		_timer += Time.deltaTime;

		foreach (QTEStatus info in _qte_infos)
		{
		
			//生成時間になっている物があったら
			if (_timer >= info._instantiate_time) {
				Debug.Log ("生成");
				//生成
				Create (info);
			
				//二度生成しないように、情報を消去
				_qte_infos.Remove (info);
			}
		}
	
	}
}







