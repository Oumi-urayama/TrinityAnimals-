using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    [CreateAssetMenu(fileName = "GameDataManager", menuName = "GameDataManager")]
    public class GameDataManager : ScriptableObject
    {
        //　次のシーン名
        [SerializeField]
        private string nextSceneName;
        //　使用するキャラクタープレハブ
        [SerializeField]
        private GameObject character;
        //　データの初期化
        
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

        public void SetNextSceneName(string nextSceneName)
        {
            this.nextSceneName = nextSceneName;
        }

        public string GetNextSceneName()
        {
            return nextSceneName;
        }

        public void SetCharacter(GameObject character)
        {
            this.character = character;
        }

        public GameObject GetCharacter()
        {
            return character;
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // シーンがロードされたときの処理
            if (scene.name == "Title")
            {
               OnEnable();
            }
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}