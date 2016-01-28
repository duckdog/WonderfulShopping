using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QTEUI : MonoBehaviour {

	[SerializeField]
	Image _image;


	// Use this for initialization
	void Start () {

		//
		_image = GetComponent<Image>();


	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0)) 
		{
		
			Debug.Log ("mouse" + Input.mousePosition);
			
		
		}

		//test 左移動
		_image.rectTransform.position -= new Vector3 (0.1f,0,0);
	}
}
