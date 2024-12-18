using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterChoice
{
    /// <summary>
    /// �Q�[���f�[�^���Ǘ�����X�N���v�^�u���I�u�W�F�N�g
    /// </summary>
    [CreateAssetMenu(fileName = "GameDataManager", menuName = "GameDataManager")]
    public class GameDataManager : ScriptableObject
    {
        
        [SerializeField]
        private string nextSceneName;//�@���̃V�[����
       
        [SerializeField]
        private GameObject character; //�@�g�p����L�����N�^�[�v���n�u

       /// <summary>
       /// �f�[�^����������������
       /// </summary>
        private void OnEnable()
        {

            //�@�^�C�g���V�[���̎��������Z�b�g
            if (SceneManager.GetActiveScene().name == "CharacterChoice")
            {
                nextSceneName = "";
                character = null;
            }
            SceneManager.sceneLoaded += OnSceneLoaded;

        }

/// <summary>
/// ���̃V�[�������Z�b�g����
/// </summary>
/// <param name="nextSceneName"></param>
        public void SetNextSceneName(string nextSceneName)
        {
            this.nextSceneName = nextSceneName;
        }

/// <summary>
/// ���̃V�[�������擾����
/// </summary>
/// <returns></returns>
        public string GetNextSceneName()
        {
            return nextSceneName;
        }

/// <summary>
/// �L�����N�^�[�v���n�u���Z�b�g����
/// </summary>
/// <param name="character"></param>
        public void SetCharacter(GameObject character)
        {
            this.character = character;
        }

/// <summary>
/// �L�����N�^�[�v���n�u���擾����
/// </summary>
/// <returns></returns>
        public GameObject GetCharacter()
        {
            return character;
        }

        /// <summary>
        /// �V�[�������[�h���ꂽ���̏���
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // �V�[�������[�h���ꂽ�Ƃ��̏���
            if (scene.name == "Title")
            {
               OnEnable(); 
               //�t�@�e�B���R�����g�F���̍s�͕K�v�Ȃ��Ǝv���BOnEnable()�͎����ŌĂ΂�邩��B�ꉞ�R�����g�A�E�g���Ă݂āA��肪�Ȃ����m�F���Ă��������B
            }
        }

/// <summary>
/// �V�[�����A�����[�h���ꂽ���̏���
/// </summary>
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}