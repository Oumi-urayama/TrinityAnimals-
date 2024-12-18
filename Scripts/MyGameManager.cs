using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterChoice
{
    /// <summary>
    /// ゲーム全体を管理するクラス
    /// </summary>
    public class MyGameManager : MonoBehaviour
    {
        //　世界に一つだけのMyGameManager
        private static MyGameManager myGameManager;

        //　ゲーム全体で管理するデータ
        [SerializeField]
        private GameDataManager gameDateManager = null;

    /// <summary>
    /// MyGameManagerを取得するためのメソッド
    /// </summary>
    /// <returns></returns>
        public GameDataManager GetMyGameManagerData()
        {
            return gameDateManager;
        }
    }
}
