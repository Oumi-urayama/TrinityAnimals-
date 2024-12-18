using UnityEngine;

/// <summary>
/// �L�����N�^�[����]�����A�㉺�ɓ�����
/// </summary>
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
    
    [SerializeField]
    private float rotationSpeed = 30f;   // ��]���x�i�x/�b�j

    [SerializeField]
    private float moveSpeed = 1f;        // �㉺�^�����x

    [SerializeField]
    private float moveDistance = 1f;     // �㉺�^���̐U��

    private void Start()
    {
        // �����ʒu�Ɉړ�
        transform.position = initialPosition;
    }
    private void Update()
    {
        // �I�u�W�F�N�g�̎��]
        RotateObject();

        // �I�u�W�F�N�g�̏㉺�^��
        MoveObjectUpDown();
    }

    /// <summary>
    /// �I�u�W�F�N�g����]������
    /// </summary>
    private void RotateObject()
    {
        // �I�u�W�F�N�g����]������
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

/// <summary>
/// �I�u�W�F�N�g���㉺�ɓ�����
/// </summary>
    private void MoveObjectUpDown()
    {
        // �I�u�W�F�N�g���㉺�ɓ�����
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