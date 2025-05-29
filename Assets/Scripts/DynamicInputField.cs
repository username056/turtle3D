using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class DynamicInputField : MonoBehaviour
{
    [Tooltip("Input Field�� �ִ� �� ���̱��� �þ�ϴ�.")]
    public float MaxHeight = 300f;

    TMP_InputField _input;
    LayoutElement _layout;

    void Awake()
    {
        _input = GetComponent<TMP_InputField>();

        // LayoutElement �ڵ� �߰�
        _layout = GetComponent<LayoutElement>();
        if (_layout == null)
            _layout = gameObject.AddComponent<LayoutElement>();

        // �ؽ�Ʈ�� �ٲ� ������ ȣ��
        _input.onValueChanged.AddListener(OnTextChanged);
        OnTextChanged(_input.text);
    }

    void OnTextChanged(string text)
    {
        // textComponent�� �䱸�ϴ� ����
        float preferred = _input.textComponent.preferredHeight;
        // �е�(�� + �Ʒ�) ������ 20 ���ϱ�
        float target = preferred + 20f;
        // �ִ� ���� ����
        _layout.preferredHeight = Mathf.Min(target, MaxHeight);
    }
}
