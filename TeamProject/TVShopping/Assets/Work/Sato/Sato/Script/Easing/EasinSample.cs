using UnityEngine;
using System.Collections;

public class EasinSample : MonoBehaviour {

	Easing easing;

	float x = 0;
	float conter = 0;
	// Use this for initialization
	void Start () {

		//どれかしらにアタッチしてある場合
		easing = GameObject.FindObjectOfType<Easing> ();
		//このスクリプトがアタッチされてるオブジェクトに
		//Easing.csがアタッチされている場合
		//easing = GetComponent<Easing>();


	}
	
	// Update is called once per frame
	void Update () {

		conter += Time.deltaTime;
		//到達時間
		const float limit_time = 5; 
		//目的位置
		const int target_value = 10;
		//X座標が徐々に目的位置に近ずいていく
		//引数　カウンター(※０からカウントしてね☆),何秒でそこまでにいどうするか、目的位置、現在地
		//
		x = (float)easing.InQuad (conter,limit_time,target_value,x);

		//他のイージング
		//加速の仕方がかわります
		//x = (float)easing.OutQuad (conter,limit_time,target_value,x);
		//x = (float)easing.InExp(conter,limit_time,target_value,x);
		//x = (float)easing.OutExp (conter,limit_time,target_value,x);



		Debug.Log (x+":x Value");
	
	}
}
