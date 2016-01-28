using UnityEngine;
using System.Collections;

public class SampleAnimation : MonoBehaviour {

	//
	//自分でつくってね!おのさん！
	//

	float _time;
	float _speed = 1.0f;
	// Use this for initialization
	void Start () {
		float _time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		_time += 0.001f;

		transform.Rotate (0,Mathf.Sin(_time * 180/3.14f),0);
	}
}
