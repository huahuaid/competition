using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingClickNavigator : MonoBehaviour
{
	[Header("缩放设置")]
	[SerializeField] private float hoverScale = 1.2f;
	[SerializeField] private float normalScale = 1f;
	[SerializeField] private float scaleSpeed = 3f;

	[Header("点击设置")]
	[SerializeField] private string buildingName; // 建筑物名称标识
	[SerializeField] private Color highlightColor = Color.red; // 点击时的高亮颜色
	[SerializeField] private string targetSceneName; // 要切换的目标场景名称

	[Header("完成状态")]
	[SerializeField] GameObject finishCollect;
	[SerializeField] GameObject finishModule;
	[SerializeField] GameObject finishAssembly;
	[SerializeField] GameObject AllText;

	private Vector3 targetScale;
	private SpriteRenderer spriteRenderer;
	private Color originalColor;

	void Start()
	{
		targetScale = Vector3.one * normalScale;
		transform.localScale = targetScale;

		spriteRenderer = GetComponent<SpriteRenderer>();
		if (spriteRenderer != null)
		{
			originalColor = spriteRenderer.color;
		}
	}

	void Update()
	{
		transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
	}

	private void OnMouseEnter()
	{
		targetScale = Vector3.one * hoverScale;
	}

	private void OnMouseExit()
	{
		targetScale = Vector3.one * normalScale;
	}

	private void OnMouseDown()
	{
		Debug.Log("点击了建筑物: " + buildingName);

		// 高亮显示被点击的建筑
		if (spriteRenderer != null)
		{
			StartCoroutine(HighlightAndTransition());
		}
	}

	IEnumerator HighlightAndTransition()
	{
		// 高亮效果
		spriteRenderer.color = highlightColor;
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.color = originalColor;

		// 根据建筑类型激活对应的完成状态
		switch (buildingName)
		{
			case "Collect":
				if (finishCollect != null) finishCollect.SetActive(true);
				break;
			case "Workshop":
				if (finishModule != null) finishModule.SetActive(true);
				break;
			case "WaterTruck":
				if (finishAssembly != null) finishAssembly.SetActive(true);
				break;
		}

		// 如果有目标场景名称，则执行场景过渡
		if (!string.IsNullOrEmpty(targetSceneName))
		{
			// 确保SceneTransitionManager已存在
			if (SceneTransitionManager.Instance != null)
			{
				SceneTransitionManager.Instance.TransitionToScene(targetSceneName);
			}
			else
			{
				Debug.LogWarning("SceneTransitionManager实例未找到，直接加载场景");
				SceneManager.LoadScene(targetSceneName);
			}
		}
	}
}
