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
    //スキルの効果時間
    [SerializeField]
    private float skillTime = 0;
    //スキル中の移動速度
    [SerializeField]
    private float skillMoveSpeed;
    //スキル中のジャンプ力
    [SerializeField]
    private float skillJumpForce;
    //通常時の移動速度
    [SerializeField]
    private float nomalMoveSpeed;
    //通常時のジャンプ力
    [SerializeField]
    private float nomalJumpForce;

    //ControllPlayerのオーバーライド
    public override void ControllPlayer()
    {
        //親クラスのControllPlayerをもとに
        base.ControllPlayer();
        //skillCoolTimeを減らす
        skillCoolTime--;

        //["Skill"]入力があり、かつskillCoolTimeよりも時間が経過している時
        if (playerInput.actions["CatSkill"].triggered && Time.time > canJump)
        {
            myFlagManager.OnSkill = true;
            //skillTimenに値を代入する
            const float skillTimeLiset = 1000f;//定数
            skillTime = skillTimeLiset;
            //skillCoolTimeに値を代入する
            const float skillCoolTimeLiset = 10000f;//定数
            skillCoolTime = skillCoolTimeLiset;
        }
        //skillTimeが0より大きいとき
        if (skillTime > 0)
        {
            //skillTimeを減らす
            skillTime--;
            //親クラスのsneekをtrueにする
            myFlagManager.Sneek = true;
            //movementSpeedとjumpForceを変更する
            movementSpeed = skillMoveSpeed;
            jumpForce = skillJumpForce;
        }
        //skillTimeが0以下の時
        else if (skillTime <= 0)
        {
            myFlagManager.OnSkill = false;
            //親クラスのsneekをfalseにする
            myFlagManager.Sneek = false;
            //movementSpeedとjumpForceを変更する
            movementSpeed = nomalMoveSpeed;
            jumpForce = nomalJumpForce;
        }
    }
}
