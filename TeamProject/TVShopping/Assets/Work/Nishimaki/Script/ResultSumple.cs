using UnityEngine;
using System.Collections;

public class ResultSumple : MonoBehaviour {

    [SerializeField]
    GUISkin Skin;

    GUIStyle Style;
    GUIStyleState State;

    int program_rating,program_money;

	// Use this for initialization
	void Start () {
        program_rating = 80;//GetComponent<視聴率の値の入ったスクリプト>().視聴率の値;
        program_money = 10000000;//GetComponent<金額の値の入ったスクリプト>().金額の値;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        Style = new GUIStyle();
        State = new GUIStyleState();

        GUI.skin = Skin;

        State.textColor = Color.red;

        Style.fontSize = Screen.width/20;
        Style.normal = State;

        if (GUI.Button(new Rect(Screen.width / 2 + Screen.width / 6, Screen.height / 2 + Screen.height / 6, Screen.width / 3, Screen.height / 4), "もう一度遊ぶ"))
        {
            Application.LoadLevel("Sato");
        }
        if (GUI.Button(new Rect(0, Screen.height / 2 + Screen.height / 6, Screen.width / 3, Screen.height / 4 ), "メニューに戻る"))
        {
            Application.LoadLevel("Nishimaki");
        }

        GUI.Label(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 3, Screen.width / 2, Screen.height / 8), "視聴率 " + program_rating + " %", Style);

        GUI.Label(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 2, Screen.width / 2, Screen.height / 8), "金額 " + program_money + " ＄", Style);
    }
}
