using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {


 

    private float nextTime;
    public float interval = 1.0f;   // 点滅周期




    // Use this for initialization
    void Start () {

        nextTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
           // Application.LoadLevel("Nishimaki");
        }


        if (Time.time > nextTime)
        {
           // renderer.enabled = !renderer.enabled;

            nextTime += interval;
        }


    }
}
