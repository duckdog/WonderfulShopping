using UnityEngine;
using System.Collections;

public class QTETap : MonoBehaviour {

	//RayTouch _ray;
	[SerializeField]
	private Sprite[] _qte_sprites = new Sprite[(int)QTEGenerator.Type.Last];
	public QTEGenerator.Type Type{ get; set;}  

	public direction Direction{ get;set;}
	public bool DoTouch{get;set;}
	public bool DoSwipe{get;set;}
	public float TimeLimit{ get; set;}
	private float _timer;

	// Use this for initialization
	void Start () {

		_timer = 0.0f;

		if (Type == QTEGenerator.Type.UpSwipe)
			Direction = direction.UP;
		else if (Type == QTEGenerator.Type.DownSwipe)
			Direction = direction.DOWN;
		else if (Type == QTEGenerator.Type.LeftSwipe)
			Direction = direction.LEFT;
		else if (Type == QTEGenerator.Type.RightSwipe)
			Direction = direction.RIGHT;
		else
			Direction = direction.DEFAULT;

		gameObject.GetComponent<SpriteRenderer> ().sprite = _qte_sprites [(int)Type];
	}


	// Update is called once per frame
	void Update () {

		//カウントダウン
		_timer += Time.deltaTime;


		
		if (DoTouch && Direction == direction.DEFAULT) {
		
			Debug.Log ("タップ成功！！" + Time.time);

			GameObject.FindObjectOfType<ScoreManager> ().ScoreValueUp ();
			Destroy (this.gameObject);	
		
	     }
		if (DoSwipe) {
		
			Debug.Log ("スワイプ成功！！" + Direction);

			GameObject.FindObjectOfType<ScoreManager> ().ScoreValueUp ();

			Destroy (this.gameObject);

		}

		//たっちされなかったらそのままお亡くなり.
		if (_timer > TimeLimit)
		{
			Debug.Log("タップ失敗！！");
			Destroy(this.gameObject);

		}
			
	}
	

}

