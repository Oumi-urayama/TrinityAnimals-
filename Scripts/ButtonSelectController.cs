using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// シーン始まったら、最初のボタンを選択状態にする
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
