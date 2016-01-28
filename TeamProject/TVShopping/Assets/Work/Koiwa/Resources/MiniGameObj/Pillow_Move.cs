using UnityEngine;
using System.Collections;

public class Pillow_Move : MonoBehaviour {
    // 計算が上手く使えないので保留
    //[SerializeField]
    //Vector3 TargetPosition;
    //[SerializeField]
    //Vector3 GalleryPosition;
    //private float _speed;
    //private float _need_frame;
    //private Vector3 _target_toPillow;

    //// ターゲットと観客の位置からX軸とY軸の移動量を計算して保存
    //// (ターゲットのZ座標 - 観客のZ座標)/_speed で何フレームでZ軸の数値が一致するかを計算。
    //// 必要フレーム数でX座標とY座標をターゲットの位置に到達するよう
    //// Vector3((ターゲットX座標 - 観客X座標)/必要フレーム,
    ////         (ターゲットX座標 - 観客X座標)/必要フレーム,
    ////         _speed);　とする。
    //void Start()
    //{
    //    _need_frame = (TargetPosition.z - GalleryPosition.z) / _speed;
    //    _target_toPillow = new Vector3((TargetPosition.x - GalleryPosition.x) / _need_frame,
    //                                   (TargetPosition.y - GalleryPosition.y) / _need_frame,
    //                                    _speed);
    //}

	void Update ()
    {
        //transform.position += _target_toPillow;
        transform.position += new Vector3(-0.01f, 0.0f, 0.2f);
	}
}
