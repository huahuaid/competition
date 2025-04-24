using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    [Header("�����")]
    [SerializeField] private VideoPlayer videoPlayer;  // �󶨵���Ƶ������
    [SerializeField] private AudioSource backgroundMusic; // �������ֲ�����

    [Header("��������")]
    [SerializeField] private string targetSceneName = "SceneTimp"; // Ŀ�곡������

    public void OnClickStartButton()
    {
        // ֹͣ���������������������֣�
        //StopAllAudio();
        OnClickStartButtonSimple();
        // ֹͣ��Ƶ����
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.targetTexture.Release();
        }

        // �����³�������ѡ��
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }

    void StopAllAudio()
    {
        // ֹͣ������ƵԴ
        foreach (var audioSource in FindObjectsOfType<AudioSource>())
        {
            audioSource.Stop();
        }

        // ����ȫ����Ƶ
        AudioListener.volume = 0;
    }

    // ���÷������������Ҫ�л�������ʹ������汾
    public void OnClickStartButtonSimple()
    {
        // ֹͣ��������
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        // ֹͣ��Ƶ����
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.targetTexture.Release();
        }
    }
}
