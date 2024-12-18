using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Audio;

namespace CharacterChoice
{
    /// <summary>
    /// キャラクター選択時の処理
    /// </summary>
    public class ChooseCharacter : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;
        private GameDataManager myGameManagerData;
        private GameObject gameStartButton;

        private void Start()
        {
            //　シーン内に一つだけのMyGameManagerからMyGameManagerDataを取得する
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
            //　ゲームスタートボタンを取得する
            gameStartButton = transform.parent.Find("ButtonPanel/GameStart").gameObject;
            //　ゲームスタートボタンを無効にする
            gameStartButton.SetActive(false);
        }

        /// <summary>
        /// ボタンがクリックされた時の処理
        /// </summary>
        public void OnButtonClick()
        {
            OnSelectCharacter(character);
            // ここに必要があればボタンがクリックされたときの処理を追加
        }

        /// <summary>
        /// キャラクターを選択した時に実行しキャラクターデータをMyGameManagerDataにセット
        /// </summary>
        /// <param name="character"></param>　
        public void OnSelectCharacter(GameObject character)
        {
            //　ボタンの選択状態を解除して選択したボタンのハイライト表示を可能にする為に実行
            EventSystem.current.SetSelectedGameObject(null);
            //　MyGameManagerDataにキャラクターデータをセットする
            myGameManagerData.SetCharacter(character);
            //　ゲームスタートボタンを有効にする
            gameStartButton.SetActive(true);
        }
        /// <summary>
        /// キャラクターを選択した時に背景をオンにする
        /// </summary>
        /// <param name="buttonNumber"></param>
        public void SwitchButtonBackground(int buttonNumber)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == buttonNumber - 1)
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(false);
                }
            }
        }
    }
}