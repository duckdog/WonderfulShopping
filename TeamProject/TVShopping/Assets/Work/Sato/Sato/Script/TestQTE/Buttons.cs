using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    // ルート分岐用
    public enum route
    {
        A_ROUTE = 0,
        B_ROUTE = 1,
        C_ROUTE = 2,
        D_ROUTE = 3, // 時間切れ(Default)ルート用
        NO_TOUCH = 4 // 選択肢表示中に返す無意味な値
    }

    // ボタンの表示数選択用
    public enum button_num
    {
        BUTTON_NUM2 = 2,
        BUTTON_NUM3 = 3
    }

    // ゲームの進行時間
    float _game_time = 0.0f;
    // ボタン表示の制限時間
    [SerializeField]
    float _limit = 0.0f;
    // ゲームが何秒進行したらボタンを表示するのか
    [SerializeField]
    float _pop_time = 0.0f;
    float _move = -Screen.width / 2;

    // 画面上下の余白(間隔)
    const float Interval = 20.0f;

    // ボタンが移動する速度
    [SerializeField]
    float _add_move = 10.0f;

    // ボタンを何個表示するのか
    [SerializeField]
    button_num _button_num = button_num.BUTTON_NUM2;

    // ボタンにどんな文字列を表示するか
    [SerializeField]
    List<string> _button_txt = new List<string>();

    // ボタンの移動停止判定
    bool _button_stop = false;


    void OnGUI()
    {
        drawButton();
    }

    void Update()
    {
        _game_time += Time.deltaTime;
    }

 
    #region route型関数にした場合
    public route drawButton()
    {
        // 表示する選択肢の数で処理を分岐
        switch (_button_num)
        {
            // 選択肢が２個の場合
            case button_num.BUTTON_NUM2:
                // 指定した時間以降に表示開始
                if (_game_time > _pop_time)
                {
                    // 丁度いい位置で止まるようにboolで制御
                    if (_move <= Interval && _button_stop == false)
                    {
                        _move += 10.0f;
                    }
                    else
                    {
                        _button_stop = true;
                    }

                    // Rect(GUIの表示位置を指定), "表示する文字列"or張り付けたいテクスチャ
                    if (GUI.Button(new Rect(_move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            _button_txt[0]))
                    {
                        Debug.Log("Button1");
                        return route.A_ROUTE;
                    }

                    if (GUI.Button(new Rect(Interval + Screen.width / 2 - _move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            _button_txt[1]))
                    {
                        Debug.Log("Button2");
                        return route.B_ROUTE;
                    }

                    // 一定時間選択されずに経過したら画面外にフェーhアウト
                    if (_game_time > _pop_time + _limit)
                    {
                        _move -= 20.0f;
                        // 完全に画面外に出たところでDestroy
                        if (_move <= -Screen.width / 2)
                        {
                            Destroy(this);
                            return route.D_ROUTE;
                        }
                    }
                    return route.NO_TOUCH;
                }
                break;

            // 選択肢が３個の場合
            case button_num.BUTTON_NUM3:
                // 指定した時間以降に表示開始
                if (_game_time > _pop_time)
                {
                    // 丁度いい位置で止まるようにboolで制御
                    if (_move <= Interval && _button_stop == false)
                    {
                        _move += 10.0f;
                    }
                    else
                    {
                        _button_stop = true;
                    }

                    // Rect(GUIの表示位置を指定), "表示する文字列"or張り付けたいテクスチャ
                    if (GUI.Button(new Rect(_move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            "Test Button"))
                    {
                        Debug.Log("Button1");
                        return route.A_ROUTE;
                    }

                    if (GUI.Button(new Rect(Interval + Screen.width / 2 - _move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            "Test Button"))
                    {
                        Debug.Log("Button2");
                        return route.B_ROUTE;
                    }

                    if (GUI.Button(new Rect(Interval + Screen.width / 2 - _move, Interval,
                        Screen.width / 2 - (Interval * 2),
                        Screen.height - (Interval * 2)),
                        "Test Button"))
                    {
                        Debug.Log("Button3");
                        return route.C_ROUTE;
                    }

                    // 一定時間選択されずに経過したら画面外にフェードアウト
                    if (_game_time > _pop_time + _limit)
                    {
                        _move -= 20.0f;
                        // 完全に画面外に出たところでDestroy
                        if (_move <= -Screen.width / 2)
                        {
                            Destroy(this);
                            return route.D_ROUTE;
                        }
                    }
                    return route.NO_TOUCH;
                }
                break;
        }
        return route.NO_TOUCH;
    }
    #endregion
}
