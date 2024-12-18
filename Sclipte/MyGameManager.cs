using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterChoice
{
    public class MyGameManager : MonoBehaviour
    {
        //　世界に一つだけのMyGameManager
        private static MyGameManager myGameManager;

        //　ゲーム全体で管理するデータ
        [SerializeField]
        private GameDataManager gameDateManager = null;

        public GameDataManager GetMyGameManagerData()
        {
            return gameDateManager;
        }
    }
}
