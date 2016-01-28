using UnityEngine;
using System.Collections;
using MiniJSON;

// 必要な要素を詰め込んでみる
public class QTE_Tap : MonoBehaviour
{
    RayTouch2D _ray_touch;
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

    // 一度だけ生成する為の制御用変数
    private bool _doCreate = false;
    // 一度だけ反応させる為の制御用変数
    private bool _doTouch = false;
    private bool _testBool = false;

    // 生成するオブジェクトの情報
    [SerializeField]
    private GameObject _icon = null;
    private GameObject Icon
    {
        get
        {
            if (_icon != null) { return _icon; }
            _icon = Resources.Load<GameObject>("QTE/TapButton");
            return _icon;
        }
    }

    public Camera targetCamera;
    void Awake()
    {
        _ray_touch = GetComponent<RayTouch2D>();
        if (this.targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    // アイコンの表示-----------------------------------------------
    // 必須：表示するタイミング・ポジション・制限時間
    // 時間内にタップをしていない場合にも戻り値が必要になってしまうので
    // bool型にするのは諦めました。
    private void drawQTE(bool boolian, float time, Vector3 pos, float time_limit)
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

        // 制限時間内にタッチできたかを判定
        if (_timer >= time &&
            _timer <= (time + time_limit))
        {
            // タッチ処理
            if (!_doTouch && _ray_touch.isRayTouch(_icon))
            {
                Debug.Log("タップ成功！！");
                _doTouch = true;
                Destroy(_icon);
                Destroy(this);
                boolian = true;
            }
        }
        // 制限時間内にタッチしなければ
        else if (!_doTouch && _timer > (time + time_limit))
        {
            Debug.Log("タップ失敗！！");
            Destroy(_icon);
            Destroy(this);
            boolian = false;
        }
    }

    private void Update()
    {
        _timer += 1.0f * Time.deltaTime;

        // 何秒後に表示するか, どこに出すか, 何秒表示するか
        drawQTE(_testBool, _time, _pos, _limit);
    }
}

