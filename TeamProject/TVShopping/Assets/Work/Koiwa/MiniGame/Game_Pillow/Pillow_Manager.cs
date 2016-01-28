using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pillow_Manager : MonoBehaviour
{
    TouchSystem _touch_system;
    ScoreManager _score_manager;

    // 時間制限
    [SerializeField]
    private float _time_limit;
    // 経過時間
    private float _game_timer = 0.0f;
    // タップした回数(スコア)
    private int _score = 0;

    // UIに表示するテキスト
    public Text _score_text;
    public Text _time_text;

    #region 観客の表示(１人分)
    [SerializeField]
    private Vector3 _gallery_pos;
    private bool _doCreate_gallery = false;

    // 観客が【枕を投げた状態】か【構えた状態】かを識別
    private bool _doThrow_pillow = false;

    // 【キャラクターを読み込み】
    [SerializeField]
    private GameObject _gallery = null;
    private GameObject Gallery
    {
        get
        {
            if (_gallery != null) { return _gallery; }
            _gallery = Resources.Load<GameObject>("MiniGameObj/Throw_Ready");
            return _gallery;
        }
    }
    // 観客の生成
    void DrawGallery()
    {
        // 指定したポジションに、一度だけ生成する
        if (!_doCreate_gallery)
        {
            _gallery = Instantiate(Gallery);
            _gallery.transform.Translate(_gallery_pos);
            _doCreate_gallery = true;
        }
    }
    #endregion
    #region キャラクターの読み込み
    [SerializeField]
    private Vector3 _target_pos;
    private bool _doCreate = false;
    [SerializeField]
    private GameObject _character = null;
    private GameObject Character
    {
        get
        {
            if (_character != null) { return _character; }
            _character = Resources.Load<GameObject>("MiniGameObj/Character");
            return _character;
        }
    }
    // 中央のキャラクターの生成・表示
    void DrawTarget()
    {
        // 指定したポジションに、一度だけ生成する
        if (!_doCreate)
        {
            _character = Instantiate(Character);
            _character.transform.Translate(_target_pos);
            _doCreate = true;
        }
    }
    #endregion
    #region 枕の生成
    private int _create_count = 0;
    private int _max_count = 100;
    [SerializeField]
    private GameObject _pillow = null;
    private GameObject Pillow
    {
        get
        {
            if (_pillow != null) { return _pillow; }
            _pillow = Resources.Load<GameObject>("MiniGameObj/Pillow");
            return _pillow;
        }
    }
    #endregion

    void Awake()
    {
        _touch_system = GetComponent<TouchSystem>();
        _score_manager = GetComponent<ScoreManager>();
        _score_text.GetComponent<Text>();
        _time_text.GetComponent<Text>();

        _score_text.text = "ぶつけた個数：" + _score + "個";
        _time_text.text = "残り：" + _time_limit + "秒";
    }

    void TapReaction()
    {
        if (_touch_system.isTouch())
        {
            _create_count++;
            _score++;
            if (_create_count < _max_count)
            {
                Instantiate(this._pillow);
            }
            Debug.Log("SCORE = " + _score);
        }
    }

    void Update()
    {
        _game_timer += Time.deltaTime;
        _score_text.text = "ぶつけた個数：" + _score + "個";

        DrawGallery();
        DrawTarget();

        // 制限時間内ならタップでスコアを稼ぐ
        if (_game_timer < _time_limit)
        {
            TapReaction();
            // 枕を消す処理が出来ず
            //if (_pillow.transform.position.z > 20)
            //{
            //    Destroy(this._pillow);
            //}
            _time_text.text = "残り：" + Mathf.Floor(_time_limit - _game_timer) + "秒";

        }
        // 制限時間を越えたらスコアを渡す
        else if (_game_timer > _time_limit)
        {
            _score_manager.ScoreValueUp(_score);
            _time_text.text = "終了！！";
        }
    }
}
