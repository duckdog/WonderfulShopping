using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 残りの必要な仕様
// １．表示時間の指定(シナリオ側にboolで生成フラグを管理してもらう事に)
// ２．一定時間後にボタンの削除
// ３．ボタンが押されたあとに、全てのボタンを消去

// ３まで完成したら追加として
// ４．選択肢の残り時間の表示
// ５．効果音の設定

public class Create_Button : MonoBehaviour
{
    private const int ButtonNum2 = 2;

    // 生成する為のフラグ
    private bool _disp_flag = true;

    // 何秒後に消すかを指定
    [SerializeField]
    private float _delete_time = 0;
    private float _timer = 0;

    private bool _doCreate = false;

    // ボタンに表示するテキスト
    [SerializeField]
    private string _button_text1 = null;
    [SerializeField]
    private string _button_text2 = null;

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

    // TIPS:[ボタンの数, 何回呼ぶのか]
    private GameObject[] _buttons = new GameObject[ButtonNum2];

    void Update()
    {
        if (_disp_flag)
        {
            // 指定した時間に、一度だけ生成
            if (!_doCreate)
            {
                for (var b = 0; b < ButtonNum2; b++)
                {
                    _buttons[b] = Create_DuoButton(b);
                }
                _doCreate = true;
            }

            // 時間切れなら削除
            if (_doCreate)
            {
                _timer += Time.deltaTime;
                if (_timer >= _delete_time)
                {
                    for (var b = 0; b < ButtonNum2; b++)
                    {
                        Destroy(_buttons[b]);
                    }
                }
            }
        }
    }

    // ボタン一個分の情報を収納する関数
    // origin...生成するGameObject
    // num   ...生成したボタンの番号(ルート分岐用の数値)
    // text  ...生成したボタンに表示するテキスト
    private GameObject CreateGameObject(GameObject origin, int num, string text)
    {
        var prefab = Instantiate(origin);
        Canvas canvas = GetComponent<Canvas>();

        prefab.name = origin.name + "(" + num + ")";
        prefab.transform.parent = base.gameObject.transform;

        // 受け取ったプレハブの持っているTextにアクセスする
        foreach (Transform child in canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == prefab.name)
            {
                // 名前が一致
                foreach (Transform child2 in child.transform)
                {
                    // 孫要素をたどる
                    if (child2.name == "Text")
                    {
                        // テキストを見つけた
                        Text t = child2.GetComponent<Text>();
                        // テキスト変更
                        t.text = text;
                    }
                }
            }
        }
        return prefab;
    }

    // ボタンの番号に応じたポジションにTranslateして表示
    private GameObject Create_DuoButton(int num)
    {
        switch (num)
        {
            case 0:
                transform.Translate(new Vector3(-(Screen.width / 4), -(Screen.height / 2), 0));
                return CreateGameObject(Button, num, _button_text2);

            case 1:
                transform.Translate(new Vector3(-(Screen.width / 4) * 2, 0, 0));
                return CreateGameObject(Button, num, _button_text1);
        }
        return null;
    }
}