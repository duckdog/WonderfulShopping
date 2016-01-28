using UnityEngine;
using System.Collections;

public class LightCreate : MonoBehaviour
{
    // このフラグで演出を呼び出す
    public bool _doPlay_LightDrop;

    private const int _MAX = 10;


    // 【照明】の情報を呼び出し
    [SerializeField]
    private GameObject _light = null;
    private GameObject[] _lights = new GameObject[_MAX];


    // 照明落下演出に必要な音の準備
    // キャンバスに【AudioSource】をアタッチする必要がある
    private AudioSource _audioSource;   // 音を鳴らす箱を用意
    public AudioClip _drop_SE;          // 照明の外れる音
    public AudioClip _scream_SE;        // 悲鳴
    private bool _doScream;             // 悲鳴SE起動フラグ
    public AudioClip _break_SE;         // 落下してガラスが割れる音
    private bool _doBreak;              // ガラスSE起動フラグ

    // 生成フラグ
    private bool _doCreate;

    // 演出中にＳＥを鳴らす為のタイマー
    private float _SE_timer;


    // 照明の生成を行う
    private GameObject CreateLight(GameObject origin, int num)
    {
        _lights[num] = Instantiate(origin);
        _lights[num].transform.position = new Vector3(Random.Range(5.0f, -5.0f), Random.Range(10.0f, 20.0f), 0);
        _lights[num].transform.parent = base.gameObject.transform;
        _lights[num].name = origin.name + "(" + num + ")";
        return _lights[num];
    }


    void Start()
    {
        _light = (GameObject)Resources.Load("LightDrop/LightPrefab");
        for (int i = 0; i < _MAX; i++)
        {
            _lights[i] = _light;
        }

        _drop_SE = (AudioClip)Resources.Load("LightDrop/Drop_SE");
        _scream_SE = (AudioClip)Resources.Load("LightDrop/Scream_SE");
        _break_SE = (AudioClip)Resources.Load("LightDrop/Break_SE");

        _doPlay_LightDrop = false;
        _doCreate = false;
        _SE_timer = 0;

        // 音を鳴らす箱がアタッチされているか確認、使用。
        _audioSource = GameObject.FindObjectOfType<AudioSource>();
        // ループ防止
        _audioSource.loop = false;
        _doScream = false;
        _doBreak = false;
    }


    void Update()
    {
        // 演出のフラグをオンにし…
        if (_doPlay_LightDrop)
        {
            // タイマースタート
            _SE_timer += Time.deltaTime;

            // 一度も生成していなければ…
            if (!_doCreate)
            {
                // 生成と同時に照明の外れる音を流す
                _audioSource.PlayOneShot(_drop_SE);

                // 照明を10個生成
                for (int i = 0; i < _MAX; i++)
                {
                    CreateLight(_light, i);
                }
                _doCreate = true;
            }

            // １秒後に悲鳴SE
            if (_SE_timer >= 1.0f)
            {
                if (!_doScream)
                {
                    _audioSource.PlayOneShot(_scream_SE);
                    _doScream = true;
                }
            }

            // ２秒後に割れSE
            if (_SE_timer >= 2.0f)
            {
                if (!_doBreak)
                {
                    _audioSource.PlayOneShot(_break_SE);
                    _doBreak = true;
                }
            }
        }
    }
}
