using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{

    /// <summary>
    /// �Q�[���X�^�[�g�{�^���̏����𐧌䂷��
    /// </summary>
    public class GameStartButton : MonoBehaviour
    {
        private SceneTransition sceneTransition;

        private void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
        }

    /// <summary>
    /// �Q�[���X�^�[�g�{�^�����N���b�N���ꂽ���̏���
    /// </summary>
        public void OnGameStart()
        {
            //MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
            sceneTransition.GameStart();
        }

    }
}