using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    public class SceneTransition : MonoBehaviour
    {
        //myGameManagerDataスクリプトのインスタンス
        private GameDataManager myGameManagerData;

        //スタートメゾット
        private void Start()
        {
            //myGameManagerDataを習得する
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        //各種メゾット
        public void GoToOtherScene(string stage)
        {
            //　次のシーンデータをMyGameManagerに保存
            myGameManagerData.SetNextSceneName(stage);
            //　キャラクター選択シーンへ
            SceneManager.LoadScene("CharacterChoice");
        }
        public void BackToTitleScene()
        {
            //　キャラクター選択シーンへ
            SceneManager.LoadScene("Title");
        }
        public void GameStart()
        {
            //　MyGameManagerDataに保存されている次のシーンに移動する
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}
  