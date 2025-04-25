using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic _instance;
    
    [SerializeField] private AudioClip musicClip; // 在Inspector中拖入你的背景音乐
    [Range(0, 1)] public float volume = 0.5f;    // 音量调节

    private AudioSource _audioSource;

    private void Awake()
    {
        // 单例模式，防止重复创建
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        // 设置AudioSource
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = musicClip;
        _audioSource.loop = true;
        _audioSource.volume = volume;
        _audioSource.spatialBlend = 0; // 2D音效
        
        // 自动播放
        _audioSource.Play();
    }
}
