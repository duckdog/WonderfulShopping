using UnityEngine;
using System.IO;
using MiniJSON;
using System.Collections.Generic;
using System.Collections;


public class SaveJson : MonoBehaviour {

	//unity editor only ../Assets/
	//パス名

    const string JsonPath = "/Work/Sato/Resources";
    string FileName = "/sample.json";



	//アニメーション情報
	public struct TransitionInfo
	{
		public float _TransitionTime { get; private set; }
		public int _Animation { get; private set; }
		public int _State { get; private set; }


		//コンストラクタ
		public TransitionInfo(float time,CharacterAnimator.Animation animation,CharacterAnimator.State state)
		{
			this._TransitionTime = time;
			this._Animation = (int)animation;
			this._State = (int)state;

		}

	}
	private List<TransitionInfo> _transition_index = new List<TransitionInfo>();

	//アニメーションセーブ
	public void AddAnimation(List<TransitionInfo> info){
	
		_transition_index = info;

	
	}

	//アニメーションセーブ
	public void SavedAnimation(GameMainManager.Root rootinfo = GameMainManager.Root.Main){
	
		//書き込み.////////
		//既存チェッカー
		var _strage_path = (Application.dataPath + JsonPath);
		if (!Directory.Exists(_strage_path))
		{
			//なかったら作る。
			Directory.CreateDirectory(_strage_path);

		}


		FileName = ("/" + rootinfo.ToString() + ".json");
		Debug.Log("dede" + FileName);
		var json_text =  File.ReadAllText(Application.dataPath + JsonPath + FileName);
		var json_test = Json.Deserialize(json_text) as Dictionary<string,object>;
		//ルート指定があった場合その場所に保存
		List<object> info;
		/*		if (rootinfo != GameMainManager.Root.Main)
		{
			info = json_test [rootinfo.ToString()] as List<object>;
		} 
		else*/
		{
			info = json_test ["info"] as List<object>;
		}

		for (int i = 0; i < _transition_index.Count - 1; i++) {
			var save_date = info[i] as Dictionary<string, object>;
			save_date ["animation"] = (double)_transition_index[i]._Animation;
			save_date ["state"] = (double)_transition_index[i]._State;
			save_date ["time"] = (double)_transition_index[i]._TransitionTime;
		}
		File.WriteAllText(Application.dataPath + JsonPath + FileName, Json.Serialize(json_test));
	
	}

	//
	public List<TransitionInfo> LoadAnimation(GameMainManager.Root rootinfo = GameMainManager.Root.Main)
	{
		//戻り値を設定
		List<TransitionInfo> date = new List<TransitionInfo> ();

		// Json FileNameを列挙体から取得
		string info;
		/*		if (rootinfo != GameMainManager.Root.Main) {
			info = rootinfo.ToString ();
		} 
		else {
				
			info = rootinfo.ToString();
		
		}*/

		TextAsset textAsset = Resources.Load(rootinfo.ToString()) as TextAsset;
		string jsonText = textAsset.text;
		JsonNode json = JsonNode.Parse(jsonText);


		for (int i = 0; i < 20; i++) {



			long animation = json["info"][i]["animation"].Get<long> ();
			long state  = json["info"][i]["state"].Get<long> ();
			double time = json["info"][i]["time"].Get<double> ();

			if (time == -1)
				break;
		
			//情報追加
			date.Add (new TransitionInfo((float)time,
				(CharacterAnimator.Animation)animation,
				(CharacterAnimator.State)state));


		}

		return date;

	
	}





    // Use this for initialization
    void Start () {

        //書き込み.////////
        //既存チェッカー
		/*	    var _strage_path = (Application.dataPath + JsonPath);
        if (!Directory.Exists(_strage_path))
        {
            //なかったら作る。
            Directory.CreateDirectory(_strage_path);

        }
        var json_text =  File.ReadAllText(Application.dataPath + JsonPath + FileName);
        var json_test = Json.Deserialize(json_text) as Dictionary<string,object>;
        var parameter_test = json_test["info"] as List<object>;
        var param_test = parameter_test[0] as Dictionary<string, object>;
        param_test["state"] = (long)50;
        File.WriteAllText(Application.dataPath + JsonPath + FileName, Json.Serialize(json_test));

*/

        ////////////////////////////////////////////////////
/*
        TextAsset textAsset = Resources.Load("sample") as TextAsset;
        string jsonText = textAsset.text;
        JsonNode json = JsonNode.Parse(jsonText);

        string test = json["info"]["data"][1]["test"].Get<string>();
        

        Debug.Log(test);
        */
	}



	// Update is called once per frame
	void Update () {
	
	}
}
