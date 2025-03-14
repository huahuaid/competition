using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class begin : MonoBehaviour, IPointerClickHandler
{
    [Header("�����")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage videoDisplay;
    [SerializeField] private Image clickableImage;

    [Header("��������")]
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

            // ͬʱ�������ͼƬ��������Ƶ���浭��
            clickableImage.color = Color.Lerp(startColor, Color.clear, progress);
            videoDisplay.color = Color.Lerp(videoStartColor, Color.white, progress);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // ȷ������״̬
        clickableImage.color = Color.clear;
        videoDisplay.color = Color.white;

        // ���õ������
        if (disableAfterPlay) clickableImage.raycastTarget = false;
    }

    void OnVideoPrepared(VideoPlayer source)
    {
        Debug.Log($"��Ƶ׼����� | �ֱ���: {source.width}x{source.height} | ʱ��: {source.length:F1}s");
    }

    void OnDestroy()
    {
        if (_renderTexture != null)
        {
            _renderTexture.Release();
            Destroy(_renderTexture);
        }
    }

    // ���ù��ܣ���ѡ��
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
