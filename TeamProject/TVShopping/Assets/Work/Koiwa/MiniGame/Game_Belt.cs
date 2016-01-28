using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game_Belt : MonoBehaviour
{
    RayTouch2D _ray_touch;
    ScoreManager _score_manager;
    #region 変数宣言
    // 時間制限
    [SerializeField]
    private float _time_limit;
    // 経過時間
    private float _game_timer = 0.0f;
    // 体脂肪率
    private float _body_fat_per = 30.0f;
    // タップした回数(スコア)
    private int _score = 0;
    // 「体脂肪率」の表示
    public Text _score_text;
    public Text _time_text;

    // ベルト
    [SerializeField]
    private Vector3 _belt_pos;
    private bool _doCreate_belt = false;

    [SerializeField]
    private GameObject _belt = null;
    private GameObject Belt
    {
        get
        {
            if(_belt != null) { return _belt; }
            _belt = Resources.Load<GameObject>("MiniGameObj/Belt");
            return _belt;
        }
    }

    // ベルトを巻くキャラクター
    [SerializeField]
    private Vector3 _char_pos;
    private bool _doCreate_char = false;

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

    // タップアイコン
    [SerializeField]
    private Vector3 _icon_pos;
    private bool _doCreate_icon = false;

    [SerializeField]
    private GameObject _icon = null;
    private GameObject Icon
    {
        get
        {
            if (_icon != null) { return _icon; }
            _icon = Resources.Load<GameObject>("MiniGameObj/TapButton");
            return _icon;
        }
    }

    public Camera targetCamera;
    #endregion

    void Awake()
    {
        _ray_touch = GetComponent<RayTouch2D>();
        _score_manager = GetComponent<ScoreManager>();
        if (this.targetCamera == null)
        {
            targetCamera = Camera.main;
        }
        _score_text.GetComponent<Text>();
        _time_text.GetComponent<Text>();

        _score_text.text = "体脂肪率：" + _body_fat_per + "％";
        _time_text.text = "残り：" + _time_limit + "秒";
    }

    // キャラクター表示
    void drawChar()
    {
        // 一度だけ生成する
        if (!_doCreate_char)
        {
            _character = Instantiate(Character);
            _character.transform.Translate(_char_pos);
            _doCreate_char = true;
        }
    }

    // ベルトの表示
    void drawBelt()
    {
        // 一度だけ生成する
        if (!_doCreate_belt)
        {
            _belt = Instantiate(Belt);
            _belt.transform.Translate(_belt_pos);
            _doCreate_belt = true;
        }
    }

    // タップアイコンを置いて、そこをタップしたら反応する処理
    void drawTapButton()
    {
        // 一度だけ生成する
        if (!_doCreate_icon)
        {
            _icon = Instantiate(Icon);
            _icon.transform.Translate(_icon_pos);
            _doCreate_icon = true;
        }
    }

    // タップしたらベルトが震える処理(タップ回数の加算)
    // 体脂肪率の表示と、タップしたら体脂肪率が減少する処理
    void TapReaction()
    {
        if (_ray_touch.isRayTouch(_icon))
        {
            _score++;
            _body_fat_per -= 0.2f;
            Debug.Log("SCORE = " + _score);
        }
        else
        {
            _belt.transform.Translate(new Vector3(0, 0));
        }
    }

    void drawText()
    {
      //  text.text = "体脂肪率：" + _body_fat_per;
    }

    // ミニゲーム処理を入れる
    void Update()
    {
        _game_timer += Time.deltaTime;
        _score_text.text = "体脂肪率：" + _body_fat_per + "％";

        drawChar();
        drawBelt();
        drawTapButton();
        drawText();
        _belt.transform.Translate(new Vector3(0,
            Mathf.Sin(_belt_pos.y + _game_timer * 40) / 100,
            Mathf.Cos(_belt_pos.z + _game_timer * 40) / 100));
        if (_game_timer < _time_limit)
        {
            // 制限時間内ならタップでスコアを稼ぐ
            TapReaction();
            _time_text.text = "残り：" + Mathf.Floor(_time_limit - _game_timer) + "秒";
        }
        else if (_game_timer > _time_limit)
        {
            // 制限時間を越えたらスコアを渡す
            _score_manager.ScoreValueUp(_score);
            _time_text.text = "終了！！";
        }
    }
}
