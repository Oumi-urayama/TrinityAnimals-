using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFlagManager : MonoBehaviour
{
    [SerializeField]
    private FlagManager myFlagManager;

    public FlagManager GetFlagManagerDate()
    {
        return myFlagManager;
    }
}
