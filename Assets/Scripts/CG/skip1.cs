using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EventTrigger))]
public class skip1 : MonoBehaviour, IPointerClickHandler
{
	[Header("�����")]
	[SerializeField] private VideoPlayer videoPlayer;
	[SerializeField] private RawImage videoDisplay;
	[SerializeField] private Image clickableImage;
	[SerializeField] private Image image2; // ��Ӷ� image2 ������

	[Header("��������")]
	[Range(0.1f, 2f)] public float fadeDuration = 0.5f;
	public bool disableAfterPlay = true;

	private RenderTexture _renderTexture;
	private bool _isPlaying;
	private float _videoLength;

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
		if (!_isPlaying)
		{
			StartVideoPlayback();
		}
		// ����� clickableImage ʱ���� image2 ��͸��������Ϊ��ȫ͸��
		if (image2 != null)
		{
			image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 0);
		}
		ChangeScene("SceneTimp");
	}

	void StartVideoPlayback()
	{
		if (videoPlayer == null || clickableImage == null) return;

		_isPlaying = true;
		StartCoroutine(FadeOutImage());
		StartCoroutine(JumpToLastSecond());
	}

	IEnumerator JumpToLastSecond()
	{
		// ���õ���Ƶ���1��
		float targetTime = Mathf.Max(_videoLength - 1, 0);
		videoPlayer.time = targetTime;

		// ����һ֡ȷ���������
		videoPlayer.Play();
		yield return null; // �ȴ�һ֡
		videoPlayer.Pause();
	}

	IEnumerator FadeOutImage()
	{
		videoDisplay.gameObject.SetActive(true);

		float elapsed = 0f;
		Color startColor = clickableImage.color;
		Color videoStartColor = videoDisplay.color;

		while (elapsed < fadeDuration)
		{
			float progress = elapsed / fadeDuration;
			clickableImage.color = Color.Lerp(startColor, Color.clear, progress);
			videoDisplay.color = Color.Lerp(videoStartColor, Color.white, progress);
			elapsed += Time.deltaTime;
			yield return null;
		}

		clickableImage.color = Color.clear;
		videoDisplay.color = Color.white;

		if (disableAfterPlay) clickableImage.raycastTarget = false;
	}

	void OnVideoPrepared(VideoPlayer source)
	{
		_videoLength = (float)source.length;
		Debug.Log($"��Ƶ׼����� | ʱ��: {_videoLength:F1}s�����1��λ��: {Mathf.Max(_videoLength - 1, 0):F1}s");
	}

	void OnDestroy()
	{
		if (_renderTexture != null)
		{
			_renderTexture.Release();
			Destroy(_renderTexture);
		}
	}

	// ���ù���
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

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}


