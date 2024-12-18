using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�����̑���𐧌䂷��
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 2.0f; // �}�E�X���x

    [SerializeField]
    float rotationLimit = 90.0f; // �㉺�̉�]����

    void Update()
    {
        // �}�E�X�̓��͂��擾
        float mouseX = Input.GetAxis("Mouse X"); //�t�@�e�B���R�����g�FNewInputSystem�ɓ��ꂷ��
        float mouseY = Input.GetAxis("Mouse Y"); //�t�@�e�B���R�����g�FNewInputSystem�ɓ��ꂷ��

        // �J�����̉�]���v�Z�i�v���C���[�̌����Ɉˑ����Ȃ��j
        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity);

        // �J�����̏㉺�̉�]�𐧌�
        float xRotation = transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Clamp(xRotation, -rotationLimit, rotationLimit), transform.rotation.eulerAngles.y, 0f));
    }
}
