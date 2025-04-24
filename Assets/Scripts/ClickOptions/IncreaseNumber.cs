using UnityEngine;
using UnityEngine.UI;

public class IncreaseNumber : MonoBehaviour
{
	public Button yourButton; // 需要在 Inspector 中拖入的按钮
	public Text numberText; // 需要在 Inspector 中拖入的 Text 组件
	private int currentNumber = 0; // 当前数字

	void Start()
	{
		// 添加按钮点击事件
		if (yourButton != null)
		{
			yourButton.onClick.AddListener(OnButtonClick);
		}
		// 初始化文本显示
		UpdateNumberText();
	}

	// 按钮点击时调用的方法
	void OnButtonClick()
	{
		// 增加数字
		currentNumber++;
		UpdateNumberText();
	}

	// 更新文本显示
	void UpdateNumberText()
	{
		if (numberText != null)
		{
			numberText.text = "数量:"+currentNumber.ToString();
		}
	}
}

