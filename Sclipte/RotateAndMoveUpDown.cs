using UnityEngine;

public class RotateAndMoveUpDown : MonoBehaviour
{
    [SerializeField]
    private GameObject chara3D;
    [SerializeField]
    private float scale = 1.5f;
    [SerializeField]
    private int buttonNumber;
    [SerializeField]
    private Vector3 initialPosition = new Vector3(0f, 0f, 0f);
    public float rotationSpeed = 30f;   // 回転速度（度/秒）
    public float moveSpeed = 1f;        // 上下運動速度
    public float moveDistance = 1f;     // 上下運動の振幅

    private void Start()
    {
        // 初期位置に移動
        transform.position = initialPosition;
    }
    private void Update()
    {
        // オブジェクトの自転
        RotateObject();

        // オブジェクトの上下運動
        MoveObjectUpDown();
    }

    private void RotateObject()
    {
        // オブジェクトを回転させる
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void MoveObjectUpDown()
    {
        // オブジェクトを上下に動かす
        float newYPosition = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(transform.position.x, newYPosition+initialPosition.y, transform.position.z);
    }
    public void SwitchButtonBackground(int buttonNumber)
    {
        Vector3 initialScale = chara3D.transform.localScale;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == buttonNumber - 1)
            {
                transform.GetChild(i).Find("Background").gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).Find("Background").gameObject.SetActive(false);
            }
        }
    }
}