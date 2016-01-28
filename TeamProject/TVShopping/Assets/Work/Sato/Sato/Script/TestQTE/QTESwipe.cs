using UnityEngine;
using System.Collections;
using MiniJSON;
/*
// 必要な要素を詰め込んでみる
public class QTESwipe : MonoBehaviour
{
    SwipeSystem2D _ray_swipe;
    // 時間経過用
    float _timer;
    // いつ？
    [SerializeField]
    float _time;
    // どこに？
    [SerializeField]
    Vector3 _pos;
    // 何秒間？
    [SerializeField]
    float _limit;
    // どの方向に？
    [SerializeField]
    direction _direction;

    // 一度だけ生成する為の制御用変数
    private bool _doCreate = false;
    // 一度だけ反応させる為の制御用変数
    private bool _doSwipe = false;
    private bool _testBool = false;

    // 生成するオブジェクトの情報
    [SerializeField]
    private GameObject _icon = null;
    public GameObject Icon
    {
        get
        {
            if (_icon != null) { return _icon; }
            _icon = Resources.Load<GameObject>("QTE/SwipeButton");
            return _icon;
        }
    }

    public Camera targetCamera;
    void Awake()
    {
        _ray_swipe = GetComponent<SwipeSystem2D>();
        if (this.targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    // アイコンの表示----------------------------------------------------------------------------------
    // 必須：表示するタイミング・ポジション・制限時間
    // 追加：スワイプする方向の指定
    // 時間内にスワイプをしていない場合にも戻り値が必要になってしまうので
    // bool型にするのは諦めました。
    public void drawQTE(bool boolian, float time, Vector3 pos, float time_limit, direction dire)
    {       
        // 常にカメラの方向に正面を向ける(ビルボード)
        this.transform.LookAt(this.targetCamera.transform.position);

        // 指定した時間に表示
        if (_timer >= time && !_doCreate)
        {
            _icon = Instantiate(Icon);
            _icon.transform.Translate(pos);
            _doCreate = true;
        }

        // 制限時間内にスワイプできたかを判定
        if (_timer >= time &&
            _timer <= (time + time_limit))
        {
            // スワイプ処理
            if (!_doSwipe && (dire ==_ray_swipe.isSwipe(_icon)))
            {
                Debug.Log("スワイプ成功！！");
                _doSwipe = true;
                Destroy(_icon);
                Destroy(this);
                boolian = true;
            }
        }
        // 制限時間内にタッチしなければ
        else if (!_doSwipe && _timer > (time + time_limit))
        {
            Debug.Log("スワイプ失敗！！");
            Destroy(_icon);
            Destroy(this);
            boolian = false;
        }
    }

    // 実装例
    void Update()
    {
        _timer += 1.0f * Time.deltaTime;

        // true/falseを返したいbool型変数を入れて下さい。
        // 何秒後に表示するか, どこに出すか, 何秒表示するか
        drawQTE(_testBool, _time, _pos, _limit, _direction);
    }
}

*/