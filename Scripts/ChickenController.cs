using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̑���X�N���v�g�̎q�N���X
/// �j���g���p
/// </summary>
public class ChickenController : Character
{
    
    [SerializeField]
    private float skillNextJump; //�X�L���̃W�����v�N�[���^�C��

/// <summary>
/// �e�N���X��ControllPlayer���\�b�h�I�[�o�[���C�h
/// </summary>
    public override void ControlPlayer()
    {
        //�e�N���X��ControllPlayer�����Ƃ�
        base.ControlPlayer();

        ////skillCoolTime�����炷
        //�t�@�e�B���R�����g�FskillCoolTime--�@�͕K�v�Ȃ��́H

        //["Skill"]���͂�����A����skillCoolTime�������Ԃ��o�߂��Ă��鎞
        if (playerInput.actions["Skill"].triggered && Time.time > skillCoolTime)
        {
            myFlagManager.OnSkill = true;

            //playerVelocity��y����jumpForce����ꂽ�x�N�g�����i�[����
            playerVelocity = new Vector3(0f, jumpForce, 0f);

            //�W�����v������
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //�W�����v�A�j���[�V�����𓮂���
            anim.SetTrigger("jump");

            //canJump�ɂ��̎��̎��Ԃ�skillNextJump�𑫂����l������
            canJump = Time.time + skillNextJump;
            
            //skillCoolTime��coolTime�̒l��������
            skillCoolTime = coolTime;
        }

    }
}
