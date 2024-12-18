using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの操作スクリプトの子クラス
/// ネコ用
/// </summary>
public class CatController : Character
{
    
    [SerializeField]
    private float skillTime = 0; //スキルの効果時間
    [SerializeField]
    const float skillTimeReset = 1000f; //定数
    [SerializeField]
    const float skillCoolTimeReset = 10000f;//定数

    [SerializeField]
    private float skillMoveSpeed; //スキル中の移動速度  
    
    [SerializeField]
    private float skillJumpForce; //スキル中のジャンプ力
    
    [SerializeField]
     private float normalMoveSpeed; //通常時の移動速度
  
    [SerializeField]
    private float normalJumpForce; //通常時のジャンプ力

/// <summary>
///  親クラスのControlPlayerメソッドオーバーライド
/// </summary>
    public override void ControlPlayer()
    {
        //親クラスのControlPlayerをもとに
        base.ControlPlayer();

        //skillCoolTimeを減らす
        skillCoolTime--;

        //["Skill"]入力があり、かつskillCoolTimeよりも時間が経過している時
        if (playerInput.actions["CatSkill"].triggered && Time.time > canJump)
        {
            myFlagManager.OnSkill = true;

            //skillTimenに値を代入する          
            skillTime = skillTimeReset;

            //skillCoolTimeに値を代入する  
            skillCoolTime = skillCoolTimeReset;
        }

        //skillTimeが0より大きいとき
        if (skillTime > 0)
        {
            //skillTimeを減らす
            skillTime--;
            //親クラスのsneakをtrueにする
            myFlagManager.Sneak = true;
            //movementSpeedとjumpForceを変更する
            movementSpeed = skillMoveSpeed;
            jumpForce = skillJumpForce;
        }
        //skillTimeが0以下の時
        else if (skillTime <= 0)
        {
            myFlagManager.OnSkill = false;
            //親クラスのsneekをfalseにする
            myFlagManager.Sneak = false;
            //movementSpeedとjumpForceを変更する
            movementSpeed = normalMoveSpeed;
            jumpForce = normalJumpForce;
        }
    }
}
