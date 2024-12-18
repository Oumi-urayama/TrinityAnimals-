using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの操作スクリプトの子クラス
/// ニワトリ用
/// </summary>
public class ChickenController : Character
{
    //スキルのジャンプクールタイム
    [SerializeField]
    private float skillNextJump;


    //ControllPlayerのオーバーライド
    public override void ControllPlayer()
    {
        //親クラスのControllPlayerをもとに
        base.ControllPlayer();
        ////skillCoolTimeを減らす
        
        //["Skill"]入力があり、かつskillCoolTimeよりも時間が経過している時
        if (playerInput.actions["Skill"].triggered && Time.time > skillCoolTime)
        {
            myFlagManager.OnSkill = true;
            //playerVelocityにy軸にjumpForceを入れたベクトルを格納する
            playerVelocity = new Vector3(0f, jumpForce, 0f);
            //ジャンプさせる
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //ジャンプアニメーションを動かす
            anim.SetTrigger("jump");
            //canJumpnにその時の時間とskillNextJumpを足した値を入れる
            canJump = Time.time + skillNextJump;
            //skillCoolTimeにcoolTimeの値を代入する
            skillCoolTime = coolTime;
        }

    }
}
