
using UnityEngine;
using UnityEngine.UI;

public class ActivateAndFade : MonoBehaviour
{
    public GameObject objectToActivate; // 需要在 Inspector 中拖入的激活对象
	public Button triggerButton; // 需要在 Inspector 中拖入的按钮

	private void Start()
	{
		// 添加按钮点击事件
		if (triggerButton != null)
		{
			triggerButton.onClick.AddListener(OnButtonClick);
		}
	}

	// 按钮点击时调用的方法
	private void OnButtonClick()
	{
		// 激活指定的 GameObject
		if (objectToActivate != null)
		{
			objectToActivate.SetActive(true);
		}
	}
}

