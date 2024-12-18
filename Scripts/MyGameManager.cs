using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterChoice
{
    /// <summary>
    /// �Q�[���S�̂��Ǘ�����N���X
    /// </summary>
    public class MyGameManager : MonoBehaviour
    {
        //�@���E�Ɉ������MyGameManager
        private static MyGameManager myGameManager;

        //�@�Q�[���S�̂ŊǗ�����f�[�^
        [SerializeField]
        private GameDataManager gameDateManager = null;

    /// <summary>
    /// MyGameManager���擾���邽�߂̃��\�b�h
    /// </summary>
    /// <returns></returns>
        public GameDataManager GetMyGameManagerData()
        {
            return gameDateManager;
        }
    }
}
