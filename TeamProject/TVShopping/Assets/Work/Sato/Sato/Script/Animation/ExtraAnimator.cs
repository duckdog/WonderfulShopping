using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ExtraAnimator : MonoBehaviour {

	public enum Animation{
	
		ScreenOpen = 1,
		ScreenClose = 2,
		BrunchButtonGenerate = 3,
		BobChangeFat = 4,
		DropLight = 5,
		GotoResult = 6,
        JustWaitScreenDelete = 7,
		NULL = -1,
	}
	Animation _animation;
	LightCreate _light_create;
	BruchButtonTextSetter _brunch_button;
	ChangeFatBob _changebob_animation;
	Dictionary<Animation,bool> _animation_dic;
	public Animation SetExtraAnimation{

		get{return _animation;}
		set
		{
			_animation = value;

		}


	}

	ScreenAnimator _screen_animation;
	// Use this for initialization
	void Awake () {

		_screen_animation = GameObject.FindObjectOfType<ScreenAnimator> ();
		_brunch_button = GameObject.FindObjectOfType<BruchButtonTextSetter>();
		_changebob_animation = GameObject.FindObjectOfType<ChangeFatBob> ();
		_light_create = GameObject.FindObjectOfType<LightCreate> ();
	}

	//受けっとたアニメーションのフラグを立てる。※立てるだけなので、終了判定などは一切しておりません。
	public void PlayingExtraAnimation(ExtraAnimator.Animation animation)
	{
	

		switch (animation) 
		{
		case Animation.ScreenOpen:

			_screen_animation._open_screen_animation = true;

			break;

		case Animation.ScreenClose:

			_screen_animation._close_screen_animation = true;

			break;
		case Animation.BrunchButtonGenerate:

			//_brunch_button.FlagManage (BrunchButtonGenerator());
			StartCoroutine (BrunchButtonGenerator());
			Debug.Log ("分岐！！！");

			break;
		case Animation.BobChangeFat:

			_changebob_animation.DoAnimation ();

			break;
		case Animation.DropLight:

			_light_create._doPlay_LightDrop = true;
			break;
		case Animation.GotoResult:
			StartCoroutine (GotoResult());
			break;
       case Animation.JustWaitScreenDelete:
                var flyfaceAnimation = FindObjectOfType<FlyingFace>();
                StartCoroutine(flyfaceAnimation.WaitScreenDelete());
            break;


        }

	}


	IEnumerator BrunchButtonGenerator()
	{
		CVManager ref_cv = GameObject.FindObjectOfType<CVManager>();

		while (ref_cv._isPlay == true) {

			yield return null;
		}
		//ボタン出現
		_brunch_button.FlagManage ();
		yield return null;
	}
	IEnumerator GotoResult()
	{
		CVManager ref_cv = GameObject.FindObjectOfType<CVManager>();
		while (ref_cv._isPlay == true) {
			yield return null;
		}


		Application.LoadLevel ("USA");
		yield return null;
	}
}
