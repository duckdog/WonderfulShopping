using UnityEngine;
using System.Collections;

public class QTE : MonoBehaviour {

	QTETouch _ray;
	public bool DoTouch{get;set;}
	public float TimeLimit{ get; set;}

	private float _timer;


	// Use this for initialization
	void Start () {

		_timer = 0.0f;
		_ray = GetComponent<QTETouch>();
	}


	// Update is called once per frame
	void Update () {

		//カウントダウン
		_timer += Time.deltaTime;


		if (DoTouch) {

			Debug.Log("タップ成功！！" + Time.time);


			Destroy(this.gameObject);

		}
		//たっちされなかったらそのままお亡くなり.
		if (_timer > TimeLimit)
		{
			Debug.Log("タップ失敗！！");
			Destroy(this.gameObject);

		}

	}
}
