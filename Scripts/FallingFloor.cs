using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������̋����𐧌䂷��X�N���v�g
/// </summary>
public class FallingFloor : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float delayTime=0; //��������܂ł̎���

    private FlagManager flagManager;
    
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //Character chara = other.gameObject.GetComponent<Character>(); 
        //�t�@�e�B���R�����g�F���̏�̂P�s���ĉ��̂��߂ɂ���́H�g���Ă��Ȃ��݂��������ǁB�R�����g�A�E�g���Ă������ǕK�v�Ȃ��Ȃ�����Ă��������B

        if (other.gameObject.tag == "Player")
        {
            if (flagManager.Sneak == false)
            {
                Invoke("CancelKinematic", delayTime);
            }
        }
        if (other.gameObject.tag == "Ground" && rb.isKinematic == false)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Kinematic����������
    /// </summary>
    void CancelKinematic()
    {
        rb.isKinematic = false;
    }

}
