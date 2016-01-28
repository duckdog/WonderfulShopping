//
//ゲームが急に始まらないよう、撮影開始カウントをいれます.
//
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class StartCount : MonoBehaviour {

	[SerializeField]
	string[] _count_text = new string[5];
	[SerializeField]
	Image _brack_panel;
	[SerializeField]
	Image _message_panel;
	[SerializeField]
	Text _text;

	ScenarioSetter _scenario_ref;
	FadeInOut _title_logo_ref;
	CameraAnimator _camera_animator_ref;
	ChangeCamera _camera;
	// Use this for initialization
	void Awake () {



		_count_text [0] = "「本番５秒前！！」";
		_count_text [1] = "「4」";
		_count_text [2] = "「3」";
		_count_text [3] = "「2」";
		_count_text [4] = "「1...」";

		_title_logo_ref = GameObject.FindObjectOfType<FadeInOut> ();
		_camera = GameObject.FindObjectOfType<ChangeCamera> ();
		_message_panel.enabled = false;
	
	}
	void Start()
	{


		StartCoroutine (StartCountAnimation());


	}

	public IEnumerator StartCountAnimation()
	{
		float time = -1;
		float alpfa = 1;
		_scenario_ref = GameObject.FindObjectOfType<ScenarioSetter> ();
		_camera_animator_ref = GameObject.FindObjectOfType<CameraAnimator> ();

		//カウントはじめます！！
		for (int i = 0; i < _count_text.Length; i++) {

			while (time <= 1) {

				time += Time.deltaTime;
				//一秒ごとにテキストを更新
				_text.text = _count_text [i];
				alpfa = Easing.StaticInQuad (time,1,0,1);
				_text.color = new Color (1,1,1,alpfa);
				yield return null;

			}
			//カウンタをリセット
			alpfa = 1;
			time = 0;
		}

		//つかったオブジェクトを見えないようにします

		_text.text = "";
		_brack_panel.enabled = false;
		//カメラ右上からどーん！からのたいとるロゴ表示
		StartCoroutine (_camera_animator_ref.R_HighFromCameraToTaget(3.0f,_camera.CurrentCamera));
		_title_logo_ref.doFadeIn = true;
		//カメラアニメーションが終わるのをまって....

		while(time <= 3.0f){
			time += Time.deltaTime;
			yield return null;
		}
			
		//シナリオ開始！
		_message_panel.enabled = true;

		_scenario_ref.SetRoute = ScenarioSetter.Route.Main;

		Destroy (this.gameObject);
		yield return null;
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
