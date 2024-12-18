using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̑���X�N���v�g�̎q�N���X
/// �l�R�p
/// </summary>
public class CatController : Character
{
    
    [SerializeField]
    private float skillTime = 0; //�X�L���̌��ʎ���
    [SerializeField]
    const float skillTimeReset = 1000f; //�萔
    [SerializeField]
    const float skillCoolTimeReset = 10000f;//�萔

    [SerializeField]
    private float skillMoveSpeed; //�X�L�����̈ړ����x  
    
    [SerializeField]
    private float skillJumpForce; //�X�L�����̃W�����v��
    
    [SerializeField]
     private float normalMoveSpeed; //�ʏ펞�̈ړ����x
  
    [SerializeField]
    private float normalJumpForce; //�ʏ펞�̃W�����v��

/// <summary>
///  �e�N���X��ControlPlayer���\�b�h�I�[�o�[���C�h
/// </summary>
    public override void ControlPlayer()
    {
        //�e�N���X��ControlPlayer�����Ƃ�
        base.ControlPlayer();

        //skillCoolTime�����炷
        skillCoolTime--;

        //["Skill"]���͂�����A����skillCoolTime�������Ԃ��o�߂��Ă��鎞
        if (playerInput.actions["CatSkill"].triggered && Time.time > canJump)
        {
            myFlagManager.OnSkill = true;

            //skillTimen�ɒl��������          
            skillTime = skillTimeReset;

            //skillCoolTime�ɒl��������  
            skillCoolTime = skillCoolTimeReset;
        }

        //skillTime��0���傫���Ƃ�
        if (skillTime > 0)
        {
            //skillTime�����炷
            skillTime--;
            //�e�N���X��sneak��true�ɂ���
            myFlagManager.Sneak = true;
            //movementSpeed��jumpForce��ύX����
            movementSpeed = skillMoveSpeed;
            jumpForce = skillJumpForce;
        }
        //skillTime��0�ȉ��̎�
        else if (skillTime <= 0)
        {
            myFlagManager.OnSkill = false;
            //�e�N���X��sneek��false�ɂ���
            myFlagManager.Sneak = false;
            //movementSpeed��jumpForce��ύX����
            movementSpeed = normalMoveSpeed;
            jumpForce = normalJumpForce;
        }
    }
}
