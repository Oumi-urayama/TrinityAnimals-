using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SelectCharacter
{
    /// <summary>
    /// ゲーム開始時の処理を制御する
    /// </summary>
    public class GameStart : MonoBehaviour
    {
        private GameDataManager myGameManagerData; //GameManagerDataスクリプトのインスタンス
        GameObject spawn;

        [SerializeField]
        private float rotation = 90f;

        void Start()
        {
            spawn = GameObject.Find("spawnBlock");
            Vector3 Spone= spawn.transform.position;
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
            Instantiate(myGameManagerData.GetCharacter(), Spone, Quaternion.Euler(0, rotation, 0));
        }
    }
}