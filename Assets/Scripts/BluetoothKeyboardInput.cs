using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_InputField))]
public class BluetoothKeyboardInput : MonoBehaviour, IUpdateSelectedHandler
{
    TMP_InputField inputField;

    void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        // IME ���� �Է��� ��� ���
        inputField.onValidateInput += (s, i, c) => c;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (!inputField.isFocused) return;
        var kb = Keyboard.current;
        if (kb == null) return;

        // �������������� �� �鿩���� ��������������
        if (kb.tabKey.wasPressedThisFrame)
        {
            InsertAtCaret("\t");
            return;
        }

        // �������������� Ctrl + C ���� ��������������
        if ((kb.leftCtrlKey.isPressed || kb.rightCtrlKey.isPressed) && kb.cKey.wasPressedThisFrame)
        {
            CopySelectionToClipboard();
            return;
        }
        // �������������� Ctrl + V �ٿ��ֱ� ��������������
        if ((kb.leftCtrlKey.isPressed || kb.rightCtrlKey.isPressed) && kb.vKey.wasPressedThisFrame)
        {
            PasteFromClipboard();
            return;
        }
        // (������: Shift��Caps, ȭ��ǥ���齺���̽������� ���� ���� ó��)
    }

    void CopySelectionToClipboard()
    {
        // Ŀ�� ��ġ�� ���� ��ġ ���ϱ�
        int pos = inputField.stringPosition;
        int sel = inputField.selectionAnchorPosition;
        int start = Mathf.Min(pos, sel);
        int end = Mathf.Max(pos, sel);
        int length = end - start;
        if (length > 0)
        {
            string selectedText = inputField.text.Substring(start, length);
            GUIUtility.systemCopyBuffer = selectedText;
        }
    }

    void PasteFromClipboard()
    {
        string clip = GUIUtility.systemCopyBuffer;
        if (!string.IsNullOrEmpty(clip))
            InsertAtCaret(clip);
    }

    void InsertAtCaret(string str)
    {
        int pos = inputField.stringPosition;
        string txt = inputField.text ?? "";
        txt = txt.Insert(pos, str);
        inputField.text = txt;
        // Ŀ�� ��ġ ������Ʈ
        inputField.stringPosition = pos + str.Length;
        inputField.caretPosition = inputField.stringPosition;
    }
}