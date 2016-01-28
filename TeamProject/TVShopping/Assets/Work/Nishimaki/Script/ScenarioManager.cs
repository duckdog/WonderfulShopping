using UnityEngine;
using System.Collections;

public class ScenarioManager : MonoBehaviour {

    [SerializeField]
    TextAsset Scenario1;

    [SerializeField]
    TextAsset Scenario1_1;

    [SerializeField]
    TextAsset Scenario1_2;

    public GUISkin s_Skin;
    public string scene;

    GUIStyle Style;
    GUIStyleState State;
    string[] text;
    int text_number;
    public float[] timer;

    int gameroot=0;

	// Use this for initialization
	void Start () {
        Style = new GUIStyle();
        State = new GUIStyleState();
        text = Scenario1.text.Split('/');
        text_number = 0;

        if (gameroot==1) { 
            text = Scenario1_1.text.Split('/');
            text_number=0;
        }
        if (gameroot==2) {
            text = Scenario1_2.text.Split('/');
            text_number = 0;
        }

        StartCoroutine(WaitTimeAndGo());
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    text_number++;

        //}else
        //for (int i = 0; i < Input.touchCount; i++)
        //{

        //    Touch touch = Input.GetTouch(i);

        //    if (touch.phase == TouchPhase.Began)
        //    {
            //}
        //}

        if (text.Length-1 == text_number)
        {
            Application.LoadLevel(scene);
        }

	}

    IEnumerator WaitTimeAndGo()
    {
        for (int i = 0; i < timer.Length;i++ )
        {
            Debug.Log(timer);
            yield return new WaitForSeconds(timer[i]);
            text_number++;
        }
    }

    void OnGUI()
    {

        GUI.skin = s_Skin;

        Style.fontSize = Screen.height/22;
        Style.normal = State;

        State.textColor = Color.black;

        GUI.Label(new Rect(Screen.width/25, Screen.height / 2 + Screen.height / 4, 0, Screen.height / 10), text[text_number], Style);

    }
}
