using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Audio;

namespace CharacterChoice
{
    /// <summary>
    /// �L�����N�^�[�I�����̏���
    /// </summary>
    public class ChooseCharacter : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;
        private GameDataManager myGameManagerData;
        private GameObject gameStartButton;

        private void Start()
        {
            //�@�V�[�����Ɉ������MyGameManager����MyGameManagerData���擾����
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
            //�@�Q�[���X�^�[�g�{�^�����擾����
            gameStartButton = transform.parent.Find("ButtonPanel/GameStart").gameObject;
            //�@�Q�[���X�^�[�g�{�^���𖳌��ɂ���
            gameStartButton.SetActive(false);
        }

        /// <summary>
        /// �{�^�����N���b�N���ꂽ���̏���
        /// </summary>
        public void OnButtonClick()
        {
            OnSelectCharacter(character);
            // �����ɕK�v������΃{�^�����N���b�N���ꂽ�Ƃ��̏�����ǉ�
        }

        /// <summary>
        /// �L�����N�^�[��I���������Ɏ��s���L�����N�^�[�f�[�^��MyGameManagerData�ɃZ�b�g
        /// </summary>
        /// <param name="character"></param>�@
        public void OnSelectCharacter(GameObject character)
        {
            //�@�{�^���̑I����Ԃ��������đI�������{�^���̃n�C���C�g�\�����\�ɂ���ׂɎ��s
            EventSystem.current.SetSelectedGameObject(null);
            //�@MyGameManagerData�ɃL�����N�^�[�f�[�^���Z�b�g����
            myGameManagerData.SetCharacter(character);
            //�@�Q�[���X�^�[�g�{�^����L���ɂ���
            gameStartButton.SetActive(true);
        }
        /// <summary>
        /// �L�����N�^�[��I���������ɔw�i���I���ɂ���
        /// </summary>
        /// <param name="buttonNumber"></param>
        public void SwitchButtonBackground(int buttonNumber)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == buttonNumber - 1)
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(false);
                }
            }
        }
    }
}