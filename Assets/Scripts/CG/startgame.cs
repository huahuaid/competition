using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    [Header("组件绑定")]
    [SerializeField] private VideoPlayer videoPlayer;  // 绑定的视频播放器
    [SerializeField] private AudioSource backgroundMusic; // 背景音乐播放器

    [Header("场景设置")]
    [SerializeField] private string targetSceneName = "SceneTimp"; // 目标场景名称

    public void OnClickStartButton()
    {
        // 停止所有声音（包括背景音乐）
        //StopAllAudio();
        OnClickStartButtonSimple();
        // 停止视频播放
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.targetTexture.Release();
        }

        // 加载新场景（可选）
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }

    void StopAllAudio()
    {
        // 停止所有音频源
        foreach (var audioSource in FindObjectsOfType<AudioSource>())
        {
            audioSource.Stop();
        }

        // 静音全局音频
        AudioListener.volume = 0;
    }

    // 备用方案：如果不需要切换场景，使用这个版本
    public void OnClickStartButtonSimple()
    {
        // 停止背景音乐
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        // 停止视频播放
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.targetTexture.Release();
        }
    }
}
