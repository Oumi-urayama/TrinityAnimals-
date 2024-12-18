using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CharacterChoice;
using UnityEngine.InputSystem;

/// <summary>
/// �Q�[���̏�Ԃ��Ǘ�����
/// </summary>
public class GameManager : MonoBehaviour
{
   
    private GameDataManager myGameManagerData;  //GameManagerData�X�N���v�g�̃C���X�^���X
    
    [SerializeField]
    private GameObject panel; 
    [SerializeField]
    private GameObject gameStart; 
    [SerializeField]
    private GameObject gameClear;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject gamePause;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private GameObject backToTitleButton;

    [SerializeField]
    private FlagManager myFlagManager;

    private Character chara;
    private PlayerInput playerInput;


    //�X�^�[�g���\�b�h
    void Start()
    {
        Time.timeScale = 1;

        //Inactive���\�b�h��1.0����ɓ�����
        Invoke("Inactive", 1.0f);

        //�Q�[���I�u�W�F�N�g���\���ɂ���
  
        gameClear.SetActive(false);
        gameOver.SetActive(false);
        gamePause.SetActive(false);

        //Character��gameOver�EgameClear��false�ɂ���
        myFlagManager.GameOver = false;
        myFlagManager.GameClear = false;

        //�\���p�̃p�l�����\���ɂ���
        panel.SetActive(false);

        //�K�v�ȎQ�Ƃ��K������
        myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();

        myFlagManager = FindObjectOfType<MyFlagManager>().GetFlagManagerDate();

        playerInput=GetComponent<PlayerInput>();
    }

    void Update()
    {
        if(chara == null)
        {
            chara = GameObject.FindWithTag("Player").GetComponent<Character>();
        }
        //Character��gameClear��true�̎�
        if (myFlagManager.GameClear)
        {
            //�e�I�u�W�F�N�g��\������
            gameClear.SetActive(true);
            panel.SetActive(true);

            //RetryButton���K������
            Button rb = retryButton.GetComponent<Button>();
            Button reB = restartButton.GetComponent<Button>();
                     
            //�{�^���𖳌�������
            if(rb != null)
            {
                rb.interactable = false;
            }

            if(reB != null)
            {
                reB.interactable = false;
            }

        }
        //Character��gameOver��true�̎�
        else if (myFlagManager.GameOver)
        {
            Time.timeScale = 0;
            //myGameManagerData��SetNextSceneName���\�b�h��"CharacterChoice"�������ɂ��ē�����
            myGameManagerData.SetNextSceneName("CharacterChoice");

            //�e�I�u�W�F�N�g��\������
            gameOver.SetActive(true);
            panel.SetActive(true);

        }

        //Character��gamePause��true�̎�
        else if (myFlagManager.GamePause)
        {
            Time.timeScale = 0;
            
            //�e�I�u�W�F�N�g��\������
            gamePause.SetActive(true);
            panel.SetActive(true);
        }
    }
    //Inactive���]�b�g
    void Inactive()
    {
        Time.timeScale = 1;
        //GameStart���A�N�e�B�u�ɂ���
        gameStart.SetActive(false);
    }
    //LodeScene���]�b�g(��������)
    public void LodeScene(string scene)
    {
        Time.timeScale = 1;
        //�V�[����ǂݍ���
        SceneManager.LoadScene(scene);
        myFlagManager.GamePause = false;
        myFlagManager.GameOver = false;
        myFlagManager.GameClear = false;
    }

    //Restart���]�b�g
    public void Restart()
    {
        Time.timeScale = 1;
        //Character��gamePause��false�ɂ���
        myFlagManager.GamePause = false;
        //�e�I�u�W�F�N�g�̃A�N�e�B�r�e�B��fales�ɂ���
        gamePause.SetActive(false);
        panel.SetActive(false);
        //ReTryButton���K������
        Button retryButton = this.retryButton.GetComponent<Button>();
        //bt�𖳌�������
        retryButton.interactable = true;
    }

}
