using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ړ�����u���b�N�̏����𐧌䂷��
/// </summary>
public class MovingBlock : MonoBehaviour
{
    [Header("�ړ��ɂ����鎞��"), SerializeField]
    private float duration = 2f; // �ړ��ɂ����鎞�ԁi�b�j

    [Header("�ړ����鋗��"), SerializeField]
    private float distance = 5f; // �ړ����鋗��

    float speed; // �ړ��̑����i���b�̈ړ������j

    [SerializeField]
    private bool moveX = true; // X���Ɉړ����邩�ǂ���
    [SerializeField]
    private bool moveY = true; // Y���Ɉړ����邩�ǂ���
    [SerializeField]
    private bool moveZ = true; // Z���Ɉړ����邩�ǂ���

    private Vector3 initialPosition;
    private float startTime;

    [SerializeField]
    private bool isPlayerOn = false; // �v���C���[������Ă��邩�ǂ���

    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
        speed = distance / duration;
    }

    void FixedUpdate()
    {
        //�t�@�e�B���R�����g�F�����͂ǂ��������������Ă��邩���������Ă�������

        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / distance;

        Vector3 newPosition = initialPosition;

        if (moveX)
            newPosition.x += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance; 
            //�}�W�b�N�i���o�[�����I�ϐ����E�萔���EOR�R�����g���c���Ă��������B�Ȃ��Q�Ȃ́H
        if (moveY)
            newPosition.y += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
            //�}�W�b�N�i���o�[�����I�ϐ����E�萔���EOR�R�����g���c���Ă��������B�Ȃ��Q�Ȃ́H
        if (moveZ)
            newPosition.z += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
            //�}�W�b�N�i���o�[�����I�ϐ����E�萔���EOR�R�����g���c���Ă��������B�Ȃ��Q�Ȃ́H

        transform.position = newPosition;
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPlayerOn)
            {
                collision.transform.parent = this.gameObject.transform;
            }
        }
    }
    public void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPlayerOn)
            {
                collision.transform.parent = null;
            }
        }
    }

}
