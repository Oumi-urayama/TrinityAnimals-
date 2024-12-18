using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelectController : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;

    private FlagManager myFlagManager;
    void Start()
    {
            EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
