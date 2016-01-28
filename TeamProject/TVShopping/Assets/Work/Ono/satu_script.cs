using UnityEngine;
using System.Collections;

public class satu_script : MonoBehaviour {
  //  private Animator _animator;
  //  public int Speed = 1;
    // private int _speedHash = Animator.StringToHash("Speed");
    bool _isAnimation;

    [SerializeField]
    GameObject america;

    AudioSource touch_oto;
   

       
    void Start ()
    {

        _isAnimation = false;
        touch_oto = america.GetComponent<AudioSource>();
    }
   
    void Update()
    {

        float vector = 0.08f;
        //クリックしたらタップ音が流れてisAnimationがtrueに
        if (Input.GetMouseButtonDown(0))
        {
           _isAnimation = true;
           touch_oto.Play();
        }
        //isAnimationがtrueになったら札束が上がる
        if (_isAnimation == true)
        {
            this.transform.position += new Vector3(0, vector, 0);
        }
        //札束が規定数まであがったらメニュー画面に飛ぶ
        if (transform.position.y > 5)
        {
            Application.LoadLevel("Nishimaki");
            DontDestroyOnLoad(gameObject);
            // DontDestroyOnLoad(this);
        }
        //札束が上がってる時にもう一度クリックしたらメニュー画面に飛ぶ
        if (transform.position.y > -14.5)
        {
            if (Input.GetMouseButtonDown(0))

            {
                Application.LoadLevel("Nishimaki");
            }
        }

        //メニュー画面に飛んだらこのコードで下に下がると…思うのですが…
        //if (_isAnimation == false)
        //{
        //  this.transform.position -= new Vector3(0, vector, 0);

        //}
    }


}
