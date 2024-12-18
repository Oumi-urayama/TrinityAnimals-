using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{

    /// <summary>
    /// ゲームスタートボタンの処理を制御する
    /// </summary>
    public class GameStartButton : MonoBehaviour
    {
        private SceneTransition sceneTransition;

        private void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
        }

    /// <summary>
    /// ゲームスタートボタンがクリックされた時の処理
    /// </summary>
        public void OnGameStart()
        {
            //MyGameManagerDataに保存されている次のシーンに移動する
            sceneTransition.GameStart();
        }

    }
}