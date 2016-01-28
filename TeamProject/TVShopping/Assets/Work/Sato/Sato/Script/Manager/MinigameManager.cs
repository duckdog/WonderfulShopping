using UnityEngine;
using System.Collections;

public class MinigameManager : MonoBehaviour {


	[SerializeField]
	private GameObject[] _minigame;
	[SerializeField]
	private float[] _time_limit;

	public bool doStartMiniGame{ get; set;}
	public int RuningMiniGameNumber{ get; set;}

	public bool do_start = false;
	GameMainManager _game_main_reference;
	float _timer; 
	bool _is_count;
	// Use this for initialization
	void Start () {

		doStartMiniGame = false;
		_is_count = false;
		RuningMiniGameNumber = 0;
		_timer = 0;
		_game_main_reference = GameObject.FindObjectOfType<GameMainManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//test
		doStartMiniGame = do_start;
		//minigame実行
		if (doStartMiniGame) {
		
			_game_main_reference.doStopGame = true;
			_is_count = true;
			//ミニゲームを生成.
			Instantiate (_minigame[RuningMiniGameNumber]);
			_timer = _time_limit[RuningMiniGameNumber];
			doStartMiniGame = false;
			//test
			do_start = false;
		}

		//かうんと
		if (_is_count) {
		
		
			_timer -= Time.deltaTime;
			//時間切れで
			if (_timer < 0) {

				_game_main_reference.doStopGame = false;
				_is_count = false;
				//次のゲーム番号へ更新しておく
				RuningMiniGameNumber++;
				//
				GameObject[] obj = GameObject.FindGameObjectsWithTag("MiniGameObject");

				//ミニゲームのオブジェクトを消去
				foreach (GameObject minigameobj in obj) {

					Destroy (minigameobj);
				}

			}
		
		}

	}
}
