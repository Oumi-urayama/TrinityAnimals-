using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// �V�[���n�܂�����A�ŏ��̃{�^����I����Ԃɂ���
/// </summary>
public class ButtonSelectController : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;

    void Start()
    {
            EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
