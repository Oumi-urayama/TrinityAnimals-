using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    /// <summary>
    /// �V�[���J�ڂ𐧌䂷��
    /// </summary>
    public class SceneTransition : MonoBehaviour
    {
       
        private GameDataManager myGameManagerData; //myGameManagerData�X�N���v�g

        private void Start()
        {
            //myGameManagerData���K������
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        /// <summary>
        /// �L�����N�^�[�I���V�[���֑J�ڂ���
        /// </summary>
        /// <param name="stage">�V�[����</param>
        public void GoToCharacterChoiceScene(string stage)
        {
            //�@���̃V�[���f�[�^��MyGameManager�ɕۑ�
            myGameManagerData.SetNextSceneName(stage);

            //�@�L�����N�^�[�I���V�[����
            SceneManager.LoadScene("CharacterChoice");
        }
        /// <summary>
        /// �^�C�g���V�[���֑J�ڂ���
        /// </summary>
        public void BackToTitleScene()
        {
            //�@�L�����N�^�[�I���V�[����
            SceneManager.LoadScene("Title");
        }
        /// <summary>
        ///  MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
        /// </summary>
        public void GoToNextScene()
        {
            //�@MyGameManagerData�ɕۑ�����Ă��鎟�̃V�[���Ɉړ�����
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}
  