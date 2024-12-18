using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 落下床の挙動を制御するスクリプト
/// </summary>
public class FallingFloor : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float delayTime=0; //落下するまでの時間

    private FlagManager flagManager;
    
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //Character chara = other.gameObject.GetComponent<Character>(); 
        //ファティンコメント：この上の１行って何のためにあるの？使っていないみたいだけど。コメントアウトしておくけど必要ないなら消してください。

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
    /// Kinematicを解除する
    /// </summary>
    void CancelKinematic()
    {
        rb.isKinematic = false;
    }

}
