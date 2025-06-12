using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TButtonManager : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI answerText;
    public TextMeshProUGUI helpText;

    private Coroutine errorCoroutine;
    private Coroutine answerCoroutine;
    private Coroutine helpCoroutine;

    public void OnErrorButtonClick()
    {
        if (errorCoroutine != null)
            StopCoroutine(errorCoroutine);

        errorCoroutine = StartCoroutine(ShowAndHideMessage(errorText, "�ڵ��� ������ �˷������!"));
    }

    public void OnAnswerButtonClick()
    {
        if (answerCoroutine != null)
            StopCoroutine(answerCoroutine);

        answerCoroutine = StartCoroutine(ShowAndHideMessage(answerText, "������ ���� �˷������!"));
    }

    public void OnHelpButtonClick()
    {
        if (helpCoroutine != null)
            StopCoroutine(helpCoroutine);

        helpCoroutine = StartCoroutine(ShowAndHideMessage(helpText, "������ Ǯ �� �ִ�\n��Ʈ �� �� �� ����!"));
    }

    private IEnumerator ShowAndHideMessage(TextMeshProUGUI targetText, string message)
    {
        targetText.text = message;
        targetText.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        targetText.gameObject.SetActive(false);
    }


}
