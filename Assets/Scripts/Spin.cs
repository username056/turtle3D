using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 360f;
    public float spinDuration = 2f;

    private float elapsed = 0f;
    private bool spinning = false;
    private AudioClip spinClip;
    private AudioSource audioSource;

    private void Start()
    {
        // Resources���� AudioClip �ε�
        spinClip = Resources.Load<AudioClip>("Audio/SoundEffect/SpinSound");
        if (spinClip == null)
        {
            Debug.LogError("SpinSound ������� ã�� �� �����ϴ�. ��θ� Ȯ���ϼ���!");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = spinClip;
        audioSource.loop = false;  // Loop�� �ڵ�� ó��
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (spinning)
        {
            if (elapsed < spinDuration)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;

                // Clip ������ ��� (�ݺ�)
                if (!audioSource.isPlaying && spinClip != null)
                {
                    audioSource.Play();
                }
            }
            else
            {
                spinning = false;
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }

    public void StartSpin()
    {
        spinning = true;
        elapsed = 0f;

        audioSource.pitch = 3.0f;
    }
}
