using UnityEngine;
using System.Collections;

public class Destroy_Object : MonoBehaviour {
    GameObject _obj;

    void Start ()
    {
        _obj = GameObject.Find(gameObject.name);
	}
	
	public void DestroyObject ()
    {
        Destroy(_obj);
	}
}
