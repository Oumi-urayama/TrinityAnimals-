using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの操作を制御する
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 2.0f; // マウス感度

    [SerializeField]
    float rotationLimit = 90.0f; // 上下の回転制限

    void Update()
    {
        // マウスの入力を取得
        float mouseX = Input.GetAxis("Mouse X"); //ファティンコメント：NewInputSystemに統一する
        float mouseY = Input.GetAxis("Mouse Y"); //ファティンコメント：NewInputSystemに統一する

        // カメラの回転を計算（プレイヤーの向きに依存しない）
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity);

        // カメラの上下の回転を制限
        float xRotation = transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Clamp(xRotation, -rotationLimit, rotationLimit), transform.rotation.eulerAngles.y, 0f));
    }
}
