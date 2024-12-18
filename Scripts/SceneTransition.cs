using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    /// <summary>
    /// シーン遷移を制御する
    /// </summary>
    public class SceneTransition : MonoBehaviour
    {
       
        private GameDataManager myGameManagerData; //myGameManagerDataスクリプト

        private void Start()
        {
            //myGameManagerDataを習得する
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        /// <summary>
        /// キャラクター選択シーンへ遷移する
        /// </summary>
        /// <param name="stage">シーン名</param>
        public void GoToCharacterChoiceScene(string stage)
        {
            //　次のシーンデータをMyGameManagerに保存
            myGameManagerData.SetNextSceneName(stage);

            //　キャラクター選択シーンへ
            SceneManager.LoadScene("CharacterChoice");
        }
        /// <summary>
        /// タイトルシーンへ遷移する
        /// </summary>
        public void BackToTitleScene()
        {
            //　キャラクター選択シーンへ
            SceneManager.LoadScene("Title");
        }
        /// <summary>
        ///  MyGameManagerDataに保存されている次のシーンに移動する
        /// </summary>
        public void GoToNextScene()
        {
            //　MyGameManagerDataに保存されている次のシーンに移動する
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}
  