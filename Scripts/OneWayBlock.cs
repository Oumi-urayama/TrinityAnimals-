using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ʍs�̃u���b�N�𐧌䂷��
/// </summary>
public class OneWayBlock : MonoBehaviour
{
    [SerializeField]
    BoxCollider boxCollider;

    #if UNITY_EDITOR
    void Start()
    {
        Debug.Log(boxCollider + "box");
    }
    #endif

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            #if UNITY_EDITOR
            Debug.Log(other.gameObject.tag);
            #endif

            boxCollider.enabled = true;
        }
    }
}
