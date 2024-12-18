using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="flagManager")]
public class FlagManager : ScriptableObject
{
    //ゲームオーバーフラグ
    [SerializeField]
    private bool gameOver = false;
    //ゲームクリアフラグ
    [SerializeField]
    private bool gameClear = false;
    //ゲームポーズフラグ
    [SerializeField]
    private bool gamePause = false;
    //スニークフラグ(ネコのスキルに使用)
    [SerializeField]
    private bool sneek = false;

    [SerializeField]
    private bool onSkill = false;

    public bool GameOver { get => gameOver; set => gameOver = value; }
    public bool GameClear { get => gameClear; set => gameClear = value; }
    public bool GamePause { get => gamePause; set => gamePause = value; }
    public bool Sneek { get => sneek; set => sneek = value; }
    public bool OnSkill { get => onSkill; set => onSkill = value; }
}
