using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �t���O�Ǘ��X�N���v�^�u���I�u�W�F�N�g�𐧌䂷��
/// </summary>
public class MyFlagManager : MonoBehaviour
{
    [SerializeField]
    private FlagManager myFlagManager;

/// <summary>
/// �t���O�Ǘ��X�N���v�^�u���I�u�W�F�N�g���擾����
/// </summary>
/// <returns></returns>
    public FlagManager GetFlagManagerDate()
    {
        return myFlagManager;
    }
}
