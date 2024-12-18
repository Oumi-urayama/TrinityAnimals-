using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [Header("移動にかかる時間"), SerializeField]
    public float duration = 2f; // 移動にかかる時間（秒）

    [Header("移動する距離"), SerializeField]
    public float distance = 5f; // 移動する距離

    float speed; // 移動の速さ（毎秒の移動距離）

    [SerializeField]
    public bool moveX = true; // X軸に移動するかどうか
    [SerializeField]
    public bool moveY = true; // Y軸に移動するかどうか
    [SerializeField]
    public bool moveZ = true; // Z軸に移動するかどうか

    private Vector3 initialPosition;
    private float startTime;

    [SerializeField]
    private bool isPlayerOn = false;

    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
        speed = distance / duration;
    }

    void FixedUpdate()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / distance;

        Vector3 newPosition = initialPosition;

        if (moveX)
            newPosition.x += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
        if (moveY)
            newPosition.y += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;
        if (moveZ)
            newPosition.z += Mathf.PingPong(fractionOfJourney, 1f) * distance * 2f - distance;

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
