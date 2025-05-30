using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneAnimation : MonoBehaviour
{
    public CanvasGroup titleImageGroup;
    public Transform titleImageObject;  // ȸ�� ���
    public CanvasGroup photoImageGroup;
    public Transform photoImageObject;  // ȸ�� ���
    public GameObject startButton;

    private void Start()
    {
        // �ʱ� ����
        titleImageGroup.alpha = 0f;
        photoImageGroup.alpha = 0f;
        startButton.SetActive(false);

        StartCoroutine(PlayAnimationSequence());
    }

    IEnumerator PlayAnimationSequence()
    {
        // 1. VR ���� �� 3�� ���
        yield return new WaitForSeconds(3f);

        // 2. Title Image ����
        yield return StartCoroutine(FadeIn(titleImageGroup, 1f));

        // 3. 2�� ��� �� ȸ��
        yield return new WaitForSeconds(2f);
        titleImageObject.GetComponent<Spin>().StartSpin();

        // 4. 
        yield return StartCoroutine(FadeOut(titleImageGroup, 2f));
        photoImageObject.GetComponent<Spin>().StartSpin();
        yield return StartCoroutine(FadeIn(photoImageGroup, 1f));
        startButton.SetActive(true);
    }

    IEnumerator FadeIn(CanvasGroup cg, float duration)
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }
        cg.alpha = 1;
    }

    IEnumerator FadeOut(CanvasGroup cg, float duration)
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1, 0, t / duration);
            yield return null;
        }
        cg.alpha = 0;
    }

    IEnumerator RotateObject(Transform obj, float angle, float duration)
    {
        float t = 0;
        Quaternion startRotation = obj.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, angle);

        while (t < duration)
        {
            t += Time.deltaTime;
            obj.rotation = Quaternion.Slerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        obj.rotation = endRotation;
    }
}
