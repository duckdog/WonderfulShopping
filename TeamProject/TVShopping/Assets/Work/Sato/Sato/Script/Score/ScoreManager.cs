using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreManager : MonoBehaviour {


	public static float Score;
    //視聴率

    private float _tv_rating;
    public float ScoreValue
     {
        get { return _tv_rating; }

     }

    //スコア追加（視聴率アップ）
    public void ScoreValueUp(float add_value = 1.0f) {

		_tv_rating += add_value;
		Score = _tv_rating;
    }


    

	// Use this for initialization
	void Start () {
	
        _tv_rating = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
