using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleImageRotator : MonoBehaviour
{
    public GameObject imagePrefab;      // ȸ���� �̹��� ������
    public int imageCount = 20;          // �̹��� ����
    public float radius = 4f;           // ������
    public float rotationSpeed = 20f;   // ȸ�� �ӵ�
    public Transform userTransform;

    private List<GameObject> images = new List<GameObject>();

    void Start()
    {
        // ���� ��ġ
        for (int i = 0; i < imageCount; i++)
        {
            float angle = i * Mathf.PI * 2f / imageCount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            GameObject img = Instantiate(imagePrefab, transform.position + pos, Quaternion.identity, transform);
            images.Add(img);
        }
    }

    void Update()
    {
        // ��ü �� ȸ��
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // �� �̹����� ����� ���� �ٶ󺸵���
        foreach (var img in images)
        {
            // ī�޶� �ٶ󺸵��� ����
            img.transform.LookAt(userTransform);

            // �̹����� ������ ���ϵ��� 180�� ȸ�� �߰� (�ʿ信 ���� X,Y,Z ����)
            img.transform.Rotate(0, 180, 0);
        }

    }
}
