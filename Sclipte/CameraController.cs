using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f; // マウス感度

    void Update()
    {
        // マウスの入力を取得
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // カメラの回転を計算（プレイヤーの向きに依存しない）
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity);

        // カメラの上下の回転を制限
        float xRotation = transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Clamp(xRotation, -90f, 90f), transform.rotation.eulerAngles.y, 0f));
    }
}
