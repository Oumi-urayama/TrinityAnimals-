using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フラグ管理スクリプタブルオブジェクトを制御する
/// </summary>
public class MyFlagManager : MonoBehaviour
{
    [SerializeField]
    private FlagManager myFlagManager;

/// <summary>
/// フラグ管理スクリプタブルオブジェクトを取得する
/// </summary>
/// <returns></returns>
    public FlagManager GetFlagManagerDate()
    {
        return myFlagManager;
    }
}
