using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
	public static SceneTransitionManager Instance;

	[Header("过渡设置")]
	public Image fadeImage;
	public float fadeDuration = 1f;

	[Header("场景特定对象")]
	[SerializeField] private GameObject allText; // SceneTimp场景中要激活的文本对象

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		// 初始场景检测
		CheckCurrentScene();
	}

	public void TransitionToScene(string sceneName)
	{
		StartCoroutine(TransitionCoroutine(sceneName));
	}

	private IEnumerator TransitionCoroutine(string sceneName)
	{
		// 将 allText 设置为 false
		if (allText != null)
		{
			allText.SetActive(false);
		}

		// 淡出到白色
		yield return StartCoroutine(FadeOut());

		// 加载新场景
		SceneManager.LoadScene(sceneName);

		// 不需要等待，因为场景加载会自然中断协程
		// 新的场景加载后会触发OnEnable和OnSceneLoaded
	}

	private IEnumerator FadeOut()
	{
		float timer = 0f;
		fadeImage.color = new Color(1, 1, 1, 0);

		while (timer < fadeDuration)
		{
			timer += Time.deltaTime;
			float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
			fadeImage.color = new Color(1, 1, 1, alpha);
			yield return null;
		}

		fadeImage.color = Color.white;
	}

	private IEnumerator FadeIn()
	{
		float timer = 0f;
		fadeImage.color = Color.white;

		while (timer < fadeDuration)
		{
			timer += Time.deltaTime;
			float alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
			fadeImage.color = new Color(1, 1, 1, alpha);
			yield return null;
		}

		fadeImage.color = new Color(1, 1, 1, 0);
	}

	// 检测当前场景并执行相应操作
	private void CheckCurrentScene()
	{
		string currentSceneName = SceneManager.GetActiveScene().name;

		if (allText != null)
		{
			allText.SetActive(currentSceneName == "SceneTimp");
		}
	}

	// 当场景加载时调用
	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	// 场景加载完成时的回调
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		// 淡入效果
		StartCoroutine(FadeIn());

		// 检测新场景
		CheckCurrentScene();
	}
}

