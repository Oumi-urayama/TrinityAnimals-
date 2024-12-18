using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    /// <summary>
    /// ゲームデータを管理するスクリプタブルオブジェクト
    /// </summary>
    [CreateAssetMenu(fileName = "GameDataManager", menuName = "GameDataManager")]
    public class GameDataManager : ScriptableObject
    {
        
        [SerializeField]
        private string nextSceneName;//　次のシーン名
       
        [SerializeField]
        private GameObject character; //　使用するキャラクタープレハブ

       /// <summary>
       /// データ初期化処理をする
       /// </summary>
        private void OnEnable()
        {

            //　タイトルシーンの時だけリセット
            if (SceneManager.GetActiveScene().name == "CharacterChoice")
            {
                nextSceneName = "";
                character = null;
            }
            SceneManager.sceneLoaded += OnSceneLoaded;

        }

/// <summary>
/// 次のシーン名をセットする
/// </summary>
/// <param name="nextSceneName"></param>
        public void SetNextSceneName(string nextSceneName)
        {
            this.nextSceneName = nextSceneName;
        }

/// <summary>
/// 次のシーン名を取得する
/// </summary>
/// <returns></returns>
        public string GetNextSceneName()
        {
            return nextSceneName;
        }

/// <summary>
/// キャラクタープレハブをセットする
/// </summary>
/// <param name="character"></param>
        public void SetCharacter(GameObject character)
        {
            this.character = character;
        }

/// <summary>
/// キャラクタープレハブを取得する
/// </summary>
/// <returns></returns>
        public GameObject GetCharacter()
        {
            return character;
        }

        /// <summary>
        /// シーンがロードされた時の処理
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // シーンがロードされたときの処理
            if (scene.name == "Title")
            {
               OnEnable(); 
               //ファティンコメント：この行は必要ないと思う。OnEnable()は自動で呼ばれるから。一応コメントアウトしてみて、問題がないか確認してください。
            }
        }

/// <summary>
/// シーンがアンロードされた時の処理
/// </summary>
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}