using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���̏�Ԃ��Ǘ�����X�N���v�^�u���I�u�W�F�N�g
/// </summary>
[CreateAssetMenu(fileName ="flagManager")]
public class FlagManager : ScriptableObject
{
    
    [SerializeField]
    private bool gameOver = false; //�Q�[���I�[�o�[�t���O
   
    [SerializeField]
    private bool gameClear = false; //�Q�[���N���A�t���O
   
    [SerializeField]
    private bool gamePause = false; //�Q�[���|�[�Y�t���O
   
    [SerializeField]
    private bool sneak = false; //�X�j�[�N�t���O(�l�R�̃X�L���Ɏg�p)

    [SerializeField]
    private bool onSkill = false; //�X�L���g�p���t���O

    public bool GameOver { get => gameOver; set => gameOver = value; }
    public bool GameClear { get => gameClear; set => gameClear = value; }
    public bool GamePause { get => gamePause; set => gamePause = value; }
    public bool Sneak { get => sneak; set => sneak = value; }
    public bool OnSkill { get => onSkill; set => onSkill = value; }
}
