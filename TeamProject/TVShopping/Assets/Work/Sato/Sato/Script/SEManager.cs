
// SEならします　
// 同じところから一度に二つは鳴らせません.出したい場合は要改造。
// 左と右で、違う音は出せます。
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SEManager : MonoBehaviour {

	//(GameObject.FindObjectOfType<SEManager>()).CenterPlay(SEManager.SE.Binta);

	//
	[SerializeField]
	AudioSource _Left;
	[SerializeField]
	AudioSource _Right;
	[SerializeField]
	AudioSource _Center;

	//SEのパターン　ファイル名と同じ
	public enum SE
	{
		NoSound = 0,
		Crash_Grass = 1,
		Binta = 2,
		Clap_Scream = 3,
		Sexy = 4,
		Rough_0 = 5,
		Rough_1 = 6,


		Last,
	}
	Dictionary<SE,AudioClip> _se_patern = new Dictionary<SE, AudioClip>();

	void Awake()
	{


		//番兵から、限界値を取得.
		int SE_Limit = (int)SE.Last;

		for (int i = 1; i < SE_Limit; i++) {
		
			//列挙型をキーにAudioClipを記憶
			SE key = (SE)i;
			_se_patern.Add (key, Resources.Load<AudioClip> ("SE/" + key.ToString ()));
			Debug.Log ("SE/" + key.ToString ());
		}


	}

	//基本はこいつで鳴らします
	public void CenterPlay(SE patern = SE.NoSound)
	{
		//音を取得,再生
		if (patern != SE.NoSound) {
			_Center.clip = _se_patern [patern];
			_Center.Play ();
		}
	}
	public void LeftPlay(SE patern)
	{
		//音を取得,再生
		_Left.clip = _se_patern [patern];
		_Left.Play ();
	}
	public void RightPlay(SE patern)
	{
		//音を取得,再生
		_Right.clip = _se_patern [patern];
		_Right.Play ();
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
