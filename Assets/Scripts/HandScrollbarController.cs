using UnityEngine;
using UnityEngine.UI;

public class HandScrollbarController : MonoBehaviour
{
    public Scrollbar scrollbar;

    private Transform fingerTransform;
    private bool isTouching = false;

    private float minY, maxY;

    void Start()
    {
        // �ڵ鿡 Collider�� ������ �߰�
        if (!scrollbar.handleRect.GetComponent<Collider>())
        {
            BoxCollider col = scrollbar.handleRect.gameObject.AddComponent<BoxCollider>();
            col.isTrigger = true;
        }

        // Scrollbar ��ü ������ Collider�� ���ٸ� ����
        if (!GetComponent<Collider>())
        {
            BoxCollider col = gameObject.AddComponent<BoxCollider>();
            col.isTrigger = true;
        }

        // ���� ���� ���
        var bounds = GetComponent<Collider>().bounds;
        minY = bounds.min.y;
        maxY = bounds.max.y;
    }

    void Update()
    {
        if (isTouching && fingerTransform != null)
        {
            float fy = fingerTransform.position.y;
            float t = Mathf.InverseLerp(minY, maxY, fy);
            scrollbar.value = Mathf.Clamp01(t);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            fingerTransform = other.transform;
            isTouching = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isTouching = false;
            fingerTransform = null;
        }
    }
}
