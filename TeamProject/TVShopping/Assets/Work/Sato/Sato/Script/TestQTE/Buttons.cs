using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    // ���[�g����p
    public enum route
    {
        A_ROUTE = 0,
        B_ROUTE = 1,
        C_ROUTE = 2,
        D_ROUTE = 3, // ���Ԑ؂�(Default)���[�g�p
        NO_TOUCH = 4 // �I�����\�����ɕԂ����Ӗ��Ȓl
    }

    // �{�^���̕\�����I��p
    public enum button_num
    {
        BUTTON_NUM2 = 2,
        BUTTON_NUM3 = 3
    }

    // �Q�[���̐i�s����
    float _game_time = 0.0f;
    // �{�^���\���̐�������
    [SerializeField]
    float _limit = 0.0f;
    // �Q�[�������b�i�s������{�^����\������̂�
    [SerializeField]
    float _pop_time = 0.0f;
    float _move = -Screen.width / 2;

    // ��ʏ㉺�̗]��(�Ԋu)
    const float Interval = 20.0f;

    // �{�^�����ړ����鑬�x
    [SerializeField]
    float _add_move = 10.0f;

    // �{�^�������\������̂�
    [SerializeField]
    button_num _button_num = button_num.BUTTON_NUM2;

    // �{�^���ɂǂ�ȕ������\�����邩
    [SerializeField]
    List<string> _button_txt = new List<string>();

    // �{�^���̈ړ���~����
    bool _button_stop = false;


    void OnGUI()
    {
        drawButton();
    }

    void Update()
    {
        _game_time += Time.deltaTime;
    }

 
    #region route�^�֐��ɂ����ꍇ
    public route drawButton()
    {
        // �\������I�����̐��ŏ����𕪊�
        switch (_button_num)
        {
            // �I�������Q�̏ꍇ
            case button_num.BUTTON_NUM2:
                // �w�肵�����Ԉȍ~�ɕ\���J�n
                if (_game_time > _pop_time)
                {
                    // ���x�����ʒu�Ŏ~�܂�悤��bool�Ő���
                    if (_move <= Interval && _button_stop == false)
                    {
                        _move += 10.0f;
                    }
                    else
                    {
                        _button_stop = true;
                    }

                    // Rect(GUI�̕\���ʒu���w��), "�\�����镶����"or����t�������e�N�X�`��
                    if (GUI.Button(new Rect(_move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            _button_txt[0]))
                    {
                        Debug.Log("Button1");
                        return route.A_ROUTE;
                    }

                    if (GUI.Button(new Rect(Interval + Screen.width / 2 - _move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            _button_txt[1]))
                    {
                        Debug.Log("Button2");
                        return route.B_ROUTE;
                    }

                    // ��莞�ԑI�����ꂸ�Ɍo�߂������ʊO�Ƀt�F�[h�A�E�g
                    if (_game_time > _pop_time + _limit)
                    {
                        _move -= 20.0f;
                        // ���S�ɉ�ʊO�ɏo���Ƃ����Destroy
                        if (_move <= -Screen.width / 2)
                        {
                            Destroy(this);
                            return route.D_ROUTE;
                        }
                    }
                    return route.NO_TOUCH;
                }
                break;

            // �I�������R�̏ꍇ
            case button_num.BUTTON_NUM3:
                // �w�肵�����Ԉȍ~�ɕ\���J�n
                if (_game_time > _pop_time)
                {
                    // ���x�����ʒu�Ŏ~�܂�悤��bool�Ő���
                    if (_move <= Interval && _button_stop == false)
                    {
                        _move += 10.0f;
                    }
                    else
                    {
                        _button_stop = true;
                    }

                    // Rect(GUI�̕\���ʒu���w��), "�\�����镶����"or����t�������e�N�X�`��
                    if (GUI.Button(new Rect(_move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            "Test Button"))
                    {
                        Debug.Log("Button1");
                        return route.A_ROUTE;
                    }

                    if (GUI.Button(new Rect(Interval + Screen.width / 2 - _move, Interval,
                                            Screen.width / 2 - (Interval * 2),
                                            Screen.height - (Interval * 2)),
                                            "Test Button"))
                    {
                        Debug.Log("Button2");
                        return route.B_ROUTE;
                    }

                    if (GUI.Button(new Rect(Interval + Screen.width / 2 - _move, Interval,
                        Screen.width / 2 - (Interval * 2),
                        Screen.height - (Interval * 2)),
                        "Test Button"))
                    {
                        Debug.Log("Button3");
                        return route.C_ROUTE;
                    }

                    // ��莞�ԑI�����ꂸ�Ɍo�߂������ʊO�Ƀt�F�[�h�A�E�g
                    if (_game_time > _pop_time + _limit)
                    {
                        _move -= 20.0f;
                        // ���S�ɉ�ʊO�ɏo���Ƃ����Destroy
                        if (_move <= -Screen.width / 2)
                        {
                            Destroy(this);
                            return route.D_ROUTE;
                        }
                    }
                    return route.NO_TOUCH;
                }
                break;
        }
        return route.NO_TOUCH;
    }
    #endregion
}
