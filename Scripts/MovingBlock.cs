using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動するブロックの処理を制御する
/// </summary>
public class MovingBlock : MonoBehaviour
{
    [Header("移動にかかる時間"), SerializeField]
    private float duration = 2f; // 移動にかかる時間（秒）

    [Header("移動する距離"), SerializeField]
    private float distance = 5f; // 移動する距離

    float speed; // 移動の速さ（毎秒の移動距離）

    [SerializeField]
    private bool moveX = true; // X軸に移動するかどうか
    [SerializeField]
    private bool moveY = true; // Y軸に移動するかどうか
    [SerializeField]
    private bool moveZ = true; // Z軸に移動するかどうか

    private Vector3 initialPosition;
    private float startTime;

    [SerializeField]
    private bool isPlayerOn = false; // プレイヤーが乗っているかどうか

    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
        speed = distance / duration;
    }

    void FixedUpdate()
    {
        //ファティンコメント：ここはどういう処理をしているか説明書いてください

        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / distance;

        Vector3 newPosition = initialPosition;

        if (moveX)
            newPosition.x += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance; 
            //マジックナンバー発見！変数化・定数化・ORコメントを残してください。なぜ２なの？
        if (moveY)
            newPosition.y += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
            //マジックナンバー発見！変数化・定数化・ORコメントを残してください。なぜ２なの？
        if (moveZ)
            newPosition.z += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
            //マジックナンバー発見！変数化・定数化・ORコメントを残してください。なぜ２なの？

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
