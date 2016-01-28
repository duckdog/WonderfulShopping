using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _fade_sprite;
    Color _sprite_color;
    private float _alfa_value;

    Easing _easing;
    float _fade_count;
    [SerializeField]
    private float _fade_time;
    [SerializeField]
    public bool doFadeIn { get; set; }
    public bool doFadeOut { get; set; }
    // Use this for initialization
    void Start()
    {
        _easing = GameObject.FindObjectOfType<Easing>();
        _fade_sprite = GetComponent<SpriteRenderer>();
		doFadeIn = false;
        doFadeOut = false;
        _fade_count = 0.0f;
        _alfa_value = 0;
        _sprite_color = Color.white;
        _fade_sprite.color = _sprite_color;
       
    }

    void Update()
    {
        

        //フェードイン、またはアウト
        if (doFadeIn||doFadeOut)
        {
           

            //animation更新
            _fade_count += Time.deltaTime;

            if (doFadeIn)
            {
                //In アルファ値を１から0
                _alfa_value = (float)_easing.InExp(_fade_count, _fade_time, 0, 1);
              
            }
            else
            {
                //Out アルファ値を０から１
                _alfa_value = (float)_easing.InExp(_fade_count, _fade_time,1, 0);
            }

            //色を変更.
            _sprite_color = new Color(_sprite_color.r, _sprite_color.b, _sprite_color.g,
                                       _alfa_value);


            _fade_sprite.color = _sprite_color;

            //アニメーション終了後、フラグを折る
            if (_fade_count >= _fade_time)
            {
                doFadeIn = false;
                doFadeOut = false;
                _fade_count = 0;
            }
        }
      


    }


    float FadeValue(float fade_time)
    {

        return (float)_easing.InOutQuart(_fade_count, fade_time, 255, 0);

    }





}
