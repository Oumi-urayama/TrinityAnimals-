using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの状態を管理するスクリプタブルオブジェクト
/// </summary>
[CreateAssetMenu(fileName ="flagManager")]
public class FlagManager : ScriptableObject
{
    
    [SerializeField]
    private bool gameOver = false; //ゲームオーバーフラグ
   
    [SerializeField]
    private bool gameClear = false; //ゲームクリアフラグ
   
    [SerializeField]
    private bool gamePause = false; //ゲームポーズフラグ
   
    [SerializeField]
    private bool sneak = false; //スニークフラグ(ネコのスキルに使用)

    [SerializeField]
    private bool onSkill = false; //スキル使用中フラグ

    public bool GameOver { get => gameOver; set => gameOver = value; }
    public bool GameClear { get => gameClear; set => gameClear = value; }
    public bool GamePause { get => gamePause; set => gamePause = value; }
    public bool Sneak { get => sneak; set => sneak = value; }
    public bool OnSkill { get => onSkill; set => onSkill = value; }
}
