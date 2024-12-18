using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CharacterChoice;
using UnityEngine.InputSystem;

/// <summary>
/// ゲームの状態を管理する
/// </summary>
public class GameManager : MonoBehaviour
{
   
    private GameDataManager myGameManagerData;  //GameManagerDataスクリプトのインスタンス
    
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


    //スタートメソッド
    void Start()
    {
        Time.timeScale = 1;

        //Inactiveメソッドを1.0ｆ後に動かす
        Invoke("Inactive", 1.0f);

        //ゲームオブジェクトを非表示にする
  
        gameClear.SetActive(false);
        gameOver.SetActive(false);
        gamePause.SetActive(false);

        //CharacterのgameOver・gameClearをfalseにする
        myFlagManager.GameOver = false;
        myFlagManager.GameClear = false;

        //表示用のパネルを非表示にする
        panel.SetActive(false);

        //必要な参照を習得する
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
        //CharacterのgameClearがtrueの時
        if (myFlagManager.GameClear)
        {
            //各オブジェクトを表示する
            gameClear.SetActive(true);
            panel.SetActive(true);

            //RetryButtonを習得する
            Button rb = retryButton.GetComponent<Button>();
            Button reB = restartButton.GetComponent<Button>();
                     
            //ボタンを無効化する
            if(rb != null)
            {
                rb.interactable = false;
            }

            if(reB != null)
            {
                reB.interactable = false;
            }

        }
        //CharacterのgameOverがtrueの時
        else if (myFlagManager.GameOver)
        {
            Time.timeScale = 0;
            //myGameManagerDataのSetNextSceneNameメソッドを"CharacterChoice"を引数にして動かす
            myGameManagerData.SetNextSceneName("CharacterChoice");

            //各オブジェクトを表示する
            gameOver.SetActive(true);
            panel.SetActive(true);

        }

        //CharacterのgamePauseがtrueの時
        else if (myFlagManager.GamePause)
        {
            Time.timeScale = 0;
            
            //各オブジェクトを表示する
            gamePause.SetActive(true);
            panel.SetActive(true);
        }
    }
    //Inactiveメゾット
    void Inactive()
    {
        Time.timeScale = 1;
        //GameStartを非アクティブにする
        gameStart.SetActive(false);
    }
    //LodeSceneメゾット(引数あり)
    public void LodeScene(string scene)
    {
        Time.timeScale = 1;
        //シーンを読み込む
        SceneManager.LoadScene(scene);
        myFlagManager.GamePause = false;
        myFlagManager.GameOver = false;
        myFlagManager.GameClear = false;
    }

    //Restartメゾット
    public void Restart()
    {
        Time.timeScale = 1;
        //CharacterのgamePauseをfalseにする
        myFlagManager.GamePause = false;
        //各オブジェクトのアクティビティをfalesにする
        gamePause.SetActive(false);
        panel.SetActive(false);
        //ReTryButtonを習得する
        Button retryButton = this.retryButton.GetComponent<Button>();
        //btを無効化する
        retryButton.interactable = true;
    }

}
