using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoad.Managers
{
    public class SceneLoaderManager : MonoBehaviour
    {
        // ������ ��ȣ�� �����ϴ� ���� (�ٸ� �������� ���� �����ϰ� static)
        public static int selectedIndex = 0;


        public void LoadGateScene()
        {
            SceneManager.LoadScene("GateScene");
        }

        public void LoadMainScene(int buttonNumber)
        {
            selectedIndex = buttonNumber - 1;  // ���ù�ȣ - 1 �� �ε��� ���
            Debug.Log($"Selected index: {selectedIndex}");
            SceneManager.LoadScene("SampleScene");  // MainScene���� �̵�
        }
    }
}

