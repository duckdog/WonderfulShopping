using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    private float _move = 0.0f;

    [SerializeField]
    private GameObject _button = null;
    public GameObject Button
    {
        get
        {
            if (_button != null) { return _button; }
            _button = Resources.Load<GameObject>("UI/Button");
            return _button;
        }
    }

    private const int Button_Num2 = 2;
    //private const int Button_Num3 = 3;
    private readonly GameObject[] _button_double = new GameObject[Button_Num2];
    //private readonly GameObject[] _button_triple = new GameObject[Button_Num3];

    void Start()
    {
        for (var i = 0; i < Button_Num2; i++)
        {
            _button_double[i] = CreateButton(i);
        }
    }

    private GameObject CreateGameObject(GameObject origin, int num)
    {
        var gameObject = Instantiate(origin);
        gameObject.name = origin.name + "(" + num + ")";
        switch (num)
        {
            case 0:
                gameObject.transform.Translate(-15, 0, 0);
                break;
            case 1:
                gameObject.transform.Translate(15, 0, 0);
                break;
        }
        gameObject.transform.parent = base.gameObject.transform;
        return gameObject;
    }

    private GameObject CreateButton(int num)
    {
        return CreateGameObject(Button, num);
    }

    private void MoveButton(GameObject obj1, GameObject obj2)
    {
        if (_move <= 0.6f)
        {
            _move += 0.01f;
            obj1.transform.Translate(_move, 0, 0);
            obj2.transform.Translate(-_move, 0, 0);
        }
    }

    private void TouchButton(GameObject Button1, GameObject Button2)
    {
        // Button1をタッチしたら
        if (Input.GetMouseButtonDown(0) &&
            Button1)
        {
            Button1.transform.Translate(0, _move, 0);
            Button2.transform.Translate(0, -_move, 0);
        }
        // Button2をタッチしたら
        else if (Input.GetMouseButtonDown(0) && Button2)
        {
            Button1.transform.Translate(0, -_move, 0);
            Button2.transform.Translate(0, _move, 0);
        }
    }

    void Update()
    {
        MoveButton(_button_double[0], _button_double[1]);
        //TouchButton(_button_double[0], _button_double[1]);
    }
}
