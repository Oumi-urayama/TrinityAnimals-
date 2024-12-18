using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CharacterChoice;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //myGameManagerDataスクリプトのインスタンス
    private GameDataManager myGameManagerData;
    //各ゲームオブジェクトを格納する変数
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject GameStart;
    [SerializeField]
    private GameObject GameClear;
    [SerializeField]
    private GameObject GameOver;
    [SerializeField]
    private GameObject GamePause;
    [SerializeField]
    private GameObject ReStart;
    [SerializeField]
    private GameObject ReTryButton;
    [SerializeField]
    private GameObject BackToTitle;

    [SerializeField]
    private FlagManager myFlagManager;

    private Character chara;
    private PlayerInput playerInput;


    //スタートメゾット
    void Start()
    {
        Time.timeScale = 1;
        //Inactiveメゾットを1.0ｆ後に動かす
        Invoke("Inactive", 1.0f);
        //ゲームオブジェクトのアクティビティをfalseにする
        GameClear.SetActive(false);
        GameOver.SetActive(false);
        GamePause.SetActive(false);
        //CharacterのgameOver・gameClearをfalseにする
        myFlagManager.GameOver = false;
        myFlagManager.GameClear = false;
        //ゲームオブジェクトのアクティビティをfalseにする
        panel.SetActive(false);
        //myGameManagerDataを習得する
        myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        myFlagManager = FindObjectOfType<MyFlagManager>().GetFlagManagerDate();
        //chara=GameObject.FindWithTag("Player").GetComponent<Character>();
        playerInput=GetComponent<PlayerInput>();
    }

    // 毎フレームごとに動かす
    void Update()
    {
        if(chara == null)
        {
            chara = GameObject.FindWithTag("Player").GetComponent<Character>();
        }
        //CharacterのgameClearがtrueの時
        if (myFlagManager.GameClear)
        {
            //各オブジェクトのアクティビティをtrueにする
            GameClear.SetActive(true);
            panel.SetActive(true);
            //ReTryButtonを習得する
            Button bt = ReTryButton.GetComponent<Button>();
            Button Bt = ReStart.GetComponent<Button>();
            //btを無効化する
            bt.interactable = false;
            Bt.interactable = false;
        }
        //CharacterのgameOverがtrueの時
        else if (myFlagManager.GameOver)
        {
            Time.timeScale = 0;
            //myGameManagerDataのSetNextSceneNameメゾットを"CharacterChoice"を引数にして動かす
            myGameManagerData.SetNextSceneName("CharacterChoice");
            //各オブジェクトのアクティビティをtrueにする
            GameOver.SetActive(true);
            panel.SetActive(true);

        }
        //CharacterのgamePauseがtrueの時
        else if (myFlagManager.GamePause)
        {
            Time.timeScale = 0;
            //各オブジェクトのアクティビティをtrueにする
            GamePause.SetActive(true);
            panel.SetActive(true);
        }
    }
    //Inactiveメゾット
    void Inactive()
    {
        Time.timeScale = 1;
        //GameStartを非アクティブにする
        GameStart.SetActive(false);
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
        GamePause.SetActive(false);
        panel.SetActive(false);
        //ReTryButtonを習得する
        Button retryButton = ReTryButton.GetComponent<Button>();
        //btを無効化する
        retryButton.interactable = true;
    }

}
