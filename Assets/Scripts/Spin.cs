using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 360f; // 1�ʿ� �ѹ���
    public float spinDuration = 2f; // ȸ�� �ð�

    private float elapsed = 0f;
    private bool spinning = false;

    void Update()
    {
        if (spinning)
        {
            if (elapsed < spinDuration)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;
            }
            else
            {
                spinning = false; // ���߱�
            }
        }
    }

    public void StartSpin()
    {
        spinning = true;
        elapsed = 0f;
    }
}
