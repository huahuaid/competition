using System.Collections;
using UnityEngine;

public class BuildingClickNavigator : MonoBehaviour
{
	[Header("缩放设置")]
	[SerializeField] private float hoverScale = 1.2f;
	[SerializeField] private float normalScale = 1f;
	[SerializeField] private float scaleSpeed = 3f;

	[Header("点击设置")]
	[SerializeField] private string buildingName; // 建筑物名称标识
	[SerializeField] private Color highlightColor = Color.red; // 点击时的高亮颜色

	private Vector3 targetScale;
	private SpriteRenderer spriteRenderer;
	private Color originalColor;

	void Start()
	{
		targetScale = Vector3.one * normalScale;
		transform.localScale = targetScale;

		// 获取SpriteRenderer组件并保存原始颜色
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

	// 鼠标点击时调用
	private void OnMouseDown()
	{
		// 输出点击的建筑物名称
		Debug.Log("点击了建筑物: " + buildingName);

		// 高亮显示被点击的建筑
		if (spriteRenderer != null)
		{
			StartCoroutine(HighlightBuilding());
		}

		// 这里可以添加更多点击后的逻辑
		// 例如触发事件、打开UI面板等
	}

	// 高亮建筑物的协程
	IEnumerator HighlightBuilding()
	{
		spriteRenderer.color = highlightColor;
		yield return new WaitForSeconds(0.5f); // 高亮持续时间
		spriteRenderer.color = originalColor;
	}
}
