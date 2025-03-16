using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class begin : MonoBehaviour, IPointerClickHandler
{
    [Header("组件绑定")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage videoDisplay;
    [SerializeField] private Image clickableImage;

    [Header("过渡设置")]
    [Range(0.1f, 2f)] public float fadeDuration = 0.5f;
    public bool disableAfterPlay = true;

    private RenderTexture _renderTexture;
    private bool _isPlaying;

    void Start()
    {
        InitializeVideoSystem();
        CreateRenderTexture();
        SetupVideoPlayer();
    }

    void InitializeVideoSystem()
    {
        if (videoDisplay != null)
        {
            videoDisplay.color = new Color(1, 1, 1, 0);
            videoDisplay.gameObject.SetActive(false);
        }
    }

    void CreateRenderTexture()
    {
        _renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        if (videoDisplay != null) videoDisplay.texture = _renderTexture;
    }

    void SetupVideoPlayer()
    {
        if (videoPlayer == null) return;

        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = _renderTexture;
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isPlaying) StartVideoPlayback();
    }

    void StartVideoPlayback()
    {
        if (videoPlayer == null || clickableImage == null) return;

        _isPlaying = true;
        StartCoroutine(FadeOutImage());
        videoPlayer.Play();
    }

    System.Collections.IEnumerator FadeOutImage()
    {
        videoDisplay.gameObject.SetActive(true);

        float elapsed = 0f;
        Color startColor = clickableImage.color;
        Color videoStartColor = videoDisplay.color;

        while (elapsed < fadeDuration)
        {
            float progress = elapsed / fadeDuration;

            // 同时处理封面图片淡出和视频画面淡入
            clickableImage.color = Color.Lerp(startColor, Color.clear, progress);
            videoDisplay.color = Color.Lerp(videoStartColor, Color.white, progress);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 确保最终状态
        clickableImage.color = Color.clear;
        videoDisplay.color = Color.white;

        // 禁用点击功能
        if (disableAfterPlay) clickableImage.raycastTarget = false;
    }

    void OnVideoPrepared(VideoPlayer source)
    {
        Debug.Log($"视频准备完成 | 分辨率: {source.width}x{source.height} | 时长: {source.length:F1}s");
    }

    void OnDestroy()
    {
        if (_renderTexture != null)
        {
            _renderTexture.Release();
            Destroy(_renderTexture);
        }
    }

    // 重置功能（可选）
    public void ResetState()
    {
        StopAllCoroutines();
        _isPlaying = false;
        clickableImage.color = Color.white;
        clickableImage.raycastTarget = true;
        videoDisplay.color = Color.clear;
        videoDisplay.gameObject.SetActive(false);
        videoPlayer.Stop();
    }
}
