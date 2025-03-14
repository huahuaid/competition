using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(EventTrigger))]
public class showskip : MonoBehaviour, IPointerClickHandler
{
    [Header("视频组件")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage videoDisplay;

    [Header("状态提示图")]
    [SerializeField] private Image statusImage;

    [Range(0.1f, 1f)] public float fadeDuration = 0.5f;

    private bool _isPlaying;
    private Coroutine _statusFadeRoutine;

    void Start()
    {
        InitializeComponents();
        SetupVideoPlayer();
    }

    void InitializeComponents()
    {
        // 初始化透明度，不设置激活状态
        if (statusImage != null)
        {
            statusImage.color = new Color(1, 1, 1, 0);
        }
    }

    void SetupVideoPlayer()
    {
        if (videoPlayer == null) return;

        videoPlayer.playOnAwake = false;
        videoPlayer.started += OnVideoStarted;
        videoPlayer.loopPointReached += OnVideoEnded;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isPlaying) StartVideoPlayback();
    }

    void StartVideoPlayback()
    {
        if (videoPlayer == null) return;

        // 检查视频是否已准备好
        if (!videoPlayer.isPrepared)
        {
            Debug.LogWarning("视频尚未准备完成");
            return;
        }

        _isPlaying = true;
        videoPlayer.Play();
    }

    void OnVideoStarted(VideoPlayer source)
    {
        ShowStatusImage(true); // 视频播放时显示图片
        Debug.Log("视频开始播放");
    }

    void OnVideoEnded(VideoPlayer source)
    {
        _isPlaying = false;
        ShowStatusImage(false); // 视频播放结束时隐藏图片
        Debug.Log("视频播放结束");
    }

    void ShowStatusImage(bool show)
    {
        if (statusImage == null)
        {
            Debug.LogError("状态图片未分配！");
            return;
        }

        if (_statusFadeRoutine != null)
        {
            StopCoroutine(_statusFadeRoutine);
        }

        _statusFadeRoutine = StartCoroutine(FadeStatusImage(show));
    }

    IEnumerator FadeStatusImage(bool show)
    {
        float targetAlpha = show ? 1f : 0f;
        float startAlpha = statusImage.color.a;

        // 确保对象激活状态
        if (show && !statusImage.gameObject.activeSelf)
        {
            statusImage.gameObject.SetActive(true);
        }

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);
            statusImage.color = new Color(1, 1, 1, newAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        statusImage.color = new Color(1, 1, 1, targetAlpha);

        if (!show)
        {
            statusImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // 检查视频是否正在播放
        if (_isPlaying && !videoPlayer.isPlaying)
        {
            OnVideoEnded(videoPlayer);
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.started -= OnVideoStarted;
            videoPlayer.loopPointReached -= OnVideoEnded;
        }
    }
}