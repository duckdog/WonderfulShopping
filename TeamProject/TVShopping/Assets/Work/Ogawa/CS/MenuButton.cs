using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MenuButton : MonoBehaviour
{
    #region 変数

    #region 売り上げ関連

    //売り上げスコア
    [SerializeField]
    private Text _E_scoreText;
    //代入用
    [SerializeField]
    private int _moneyScore = 0;

    #endregion

    #region 視聴率関連
    //最大1000 = 100.0%計算(端数加算のため)
    //視聴率テキスト
    [SerializeField]
    private Text _A_r_scoreText;
    //代入用
    [SerializeField]
    private int _TVScore = 0;
    //1の位から
    private int _Score_plus = 0;
    //端数用
    private int _Score_index = 0;
    #endregion

    #region ボタン関連

    //メニューへ戻るボタンの設定
    [SerializeField]
    private Button _menuButton;

    //もう一度遊ぶボタンの設定
    [SerializeField]
    private Button _gameButton;

    //ボタンの入力可能ボタン
    [SerializeField]
    private bool _OnButton = false;

    #endregion

    #region パネル移動関連
    //動かしたいパネル
    [SerializeField]
    private GameObject _UI;
    //上記のパネル所持してるキャンバス
    [SerializeField]
    private GameObject _Canvas;

    //落下速度
    private float _down_v = 4.0F;

    //座標ストップ判定
    [SerializeField]
    private bool _Stop = false;

    #endregion

    #region ＳＥ関連
    bool _doPlay_SE;   // ドラムロールが終了したかどうかの判定
    private AudioSource _audioSource;
    public AudioClip _dram_SE;
    #endregion

    #endregion

    //リザルトの演出処理全般
    private IEnumerator ScoreResult()
    {
        yield return null;

        while (true)
        {
            //パネルが上から降りてくる演出
            yield return StartCoroutine(DownResultAnimation());

            //パネルの座標が止まっていたら
            if (_Stop)
            {
                //間隔
                yield return new WaitForSeconds(1);

                //売り上げを表示
                yield return StartCoroutine(GetScore());

                //間隔
                yield return new WaitForSeconds(1);

                //視聴率を表示
                yield return StartCoroutine(GetScorePlus());

                yield return StartCoroutine(DrawButton());
            }
        }
    }

    private void Start()
    {
        //ボタン入力
        _menuButton.onClick.AddListener(MainMenu);
        _gameButton.onClick.AddListener(MainGame);

        //スコア加算
		_TVScore = (int)ScoreManager.Score * 10;
        StartCoroutine(ScoreResult());

        // SE読み込み
        _doPlay_SE = false;
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.loop = false;
        _dram_SE = (AudioClip)Resources.Load("Dram_SE");
    }

    //売り上げ表示
    private IEnumerator GetScore()
    {
        _E_scoreText.text = _moneyScore.ToString() + "$";
        yield return null;
    }

    //視聴率表示
    private IEnumerator GetScorePlus()
    {
        if (!_doPlay_SE)
        {
            _audioSource.PlayOneShot(_dram_SE);
            _doPlay_SE = true;
        }
        //スコア加算が終わっていなければ
        if (_Score_plus != _TVScore / 10)
        {
            for (var i = 0; i < (_TVScore / 10) + 1; i++)
            {



                //スコア加算が終わったら
                if (i == _TVScore / 10)
                {
                    //端数を固定
                    _Score_index = _TVScore % 10;

                    //スコアを加算
                    _Score_plus = i;
                    //テキストに反映
                    _A_r_scoreText.text = _Score_plus.ToString() + "." + _Score_index.ToString() + "％";

                    //ボタン入力を許可
                    _OnButton = true;
                    break;
                }

                //端数をランダムで表示
                _Score_index = Random.Range(0, 9);

                //スコアを加算
                _Score_plus = i;

                //テキストに反映
                _A_r_scoreText.text = _Score_plus.ToString() + "." + _Score_index.ToString() + "％";

                yield return null;
            }
        }
        //スコア加算が終わっていたら
        else
        {
            //ボタン入力を許可
            _OnButton = true;
            yield return null;
        }
    }

    //ボタンの表示
    private IEnumerator DrawButton()
    {
        if (_OnButton)
        {
            _gameButton.gameObject.SetActive(true);
            _menuButton.gameObject.SetActive(true);
            yield return null;
        }
    }

    //ボタン
    private void MainGame()
    {
        //ボタン入力が可能なら
        if (_OnButton) Application.LoadLevel("Sato");
    }
    private void MainMenu()
    {
        //ボタン入力が可能なら
        if (_OnButton) Application.LoadLevel("Nishimaki");
    }

    //リザルトが降りてくる演出
    private IEnumerator DownResultAnimation()
    {
        //パネル座標がキャンバスの位置より上にあれば
        if (_UI.transform.position.y > _Canvas.transform.position.y)
        {
            //パネル座標を下へ
            _UI.transform.Translate(0, -_down_v, 0, Space.World);
            //加速(わざと下に行き過ぎる調整)
            _down_v += (_down_v - 0.5F) / 5;
           
        }
        //下に行き過ぎたら
        if (_UI.transform.position.y < _Canvas.transform.position.y)
        {
            //徐々にパネル座標を戻す
            _down_v = 1;

            //パネル座標を上へ
            _UI.transform.Translate(0, _down_v, 0, Space.World);

            //パネルがキャンバスに当てはまっていなければ
            if (_UI.transform.position.y > _Canvas.transform.position.y
                && _UI.transform.position.y < _Canvas.transform.position.y + 1)
            {
                //停止表明
                _Stop = true;

                //パネル座標をキャンバスに固定
                _UI.transform.position = _Canvas.transform.position;
                //次の演出に移行する
                yield return null;
            }
        }
    }
}
