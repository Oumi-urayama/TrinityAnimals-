using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// プレイヤーの操作スクリプトの子クラス
/// イヌ用
/// </summary>

public class DogController : Character
{
    //プレイヤーのベクトルリセット用の値
    [SerializeField]
    private float playerVelocityReset = 0f;
    //リセット用の変数
    [SerializeField]
    private float resetTime = 1f;
    //スキル時のジャンプ力
    [SerializeField]
    float skilljumpforce = 10f;
    //スキル時の推進力
    [SerializeField]
    float skillForwardForce = 50f;
    Vector3 skillplayerVelocity;

    //毎フレームごとに
    private void FixedUpdate()
    {
        //skillCoolTimeを減らす
        skillCoolTime--;
        //playerVelocityResetを増やす
        playerVelocityReset++;
    }

    //ControllPlayerのオーバーライド
    public override void ControllPlayer()
    {
        //親クラスのControllPlayerをもとに
        base.ControllPlayer();
        //["Skill"]入力があり、かつskillCoolTimeよりも時間が経過している時
        if (playerInput.actions["Skill"].triggered && skillCoolTime <= 0f)
        {
            myFlagManager.OnSkill = true;
            //playerVelocityResetを0にする
            playerVelocityReset = 0f;
            //上方向
            playerVelocity = new Vector3(0f, skilljumpforce, 0f);
            //前方向
            Vector3 forwardForce = transform.forward * skillForwardForce;
            //canJumpnにその時の時間とtimeBeforeNextJumpを足した値を入れる
            canJump = Time.time + timeBeforeNextJump;
            //ジャンプアニメーションを動かす
            anim.SetTrigger("jump");
            //playerVelocityに新しい値を入れる
            playerVelocity = new Vector3(playerVelocity.x + forwardForce.x, playerVelocity.y + forwardForce.y, playerVelocity.z + forwardForce.z);
            //skillCoolTimeにcoolTimeをいれる
            skillCoolTime = coolTime;
        }
        //playerVelocityResetがresetTimeになったとき
        if (playerVelocityReset >= resetTime)
        {
            myFlagManager.OnSkill = false;
            //playerVelocityを0にする
            playerVelocity.x = 0f;
            playerVelocity.z = 0f;
            playerVelocityReset = 0;
        }
    }
}
