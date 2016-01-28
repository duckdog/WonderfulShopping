using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

    [SerializeField]
    GUISkin Skin;

    GUIStyle Style;
    GUIStyleState State;

    public Texture2D Icon1;
    public Texture2D Icon2;
    public Texture2D Catalog;
    public Texture2D Option;

    public Texture2D[] Menu;

    int menu_number;

	// Use this for initialization
	void Start () {
        menu_number = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
 
    }

    void OnGUI()
    {
        
        Style = new GUIStyle();
        State = new GUIStyleState();

        GUI.skin=Skin;

        State.textColor = Color.white;

        Style.fontSize = 30;
        Style.normal = State;

        if (GUI.Button(new Rect(0, 0, Screen.width/4, Screen.height/4), Catalog))
        {
            Application.LoadLevel("Catalog");
        }

        if (GUI.Button(new Rect(Screen.width/2+Screen.width/4, 0, Screen.width/4 , Screen.height/4 ), Option))
        {
            Application.LoadLevel("Option");
        }

        if (GUI.Button(new Rect(0, Screen.height / 2, Screen.width / 6, Screen.height / 7),Icon1))
        {
            menu_number--;
        if (menu_number < 0)
        {
            menu_number = Menu.Length - 1;
        }
            Debug.Log(menu_number);
        }

        if (GUI.Button(new Rect(Screen.width/2+Screen.width/3, Screen.height / 2, Screen.width / 6, Screen.height / 7), Icon2))
        {
            menu_number++;
            if (Menu.Length == menu_number)
            {
                menu_number = 0;
            }
            Debug.Log(menu_number);
        }

        if (GUI.Button(new Rect(Screen.width / 12, Screen.height / 12, Screen.width / 2 + Screen.width / 3, Screen.height / 2 + Screen.height / 2), Menu[menu_number]))
        {
            Application.LoadLevel("Sato");
        }
        
    }
}
