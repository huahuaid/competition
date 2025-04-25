using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IncreaseNumber : MonoBehaviour, IPointerClickHandler
{
	public static float AllMaterial = 10;
	public Button yourButton; // 需要在 Inspector 中拖入的按钮
	public Text numberText;   // 需要在 Inspector 中拖入的 Text 组件

	public static int waterwheelAxle = 0;          // 水车中轴
	public static int mainRib = 0;                 // 主辐条
	public static int link = 0;                    // 连杆
	public static int horizontalCrossbar = 0;      // 横杠
	public static int paddle = 0;                  // 刮板
	public static int waterwheelSupport = 0;       // 水车支架
	public static int inclinedBambooTube = 0;      // 斜装竹筒
	public static int waterChute = 0;              // 水舰（导水槽）
	public int current = 0;                         // 当前数字

	// 定义选择的变量
	public int selectedIndex = 0; // 在 Inspector 中选择变量的索引

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

	// 实现右键点击的处理
	public void OnPointerClick(PointerEventData eventData)
	{
		// 检查是否是右键点击
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if (current > 0) // 确保当前数字大于0
			{
				current--;
				AllMaterial++;

				// 根据选择的变量更新静态值
				switch (selectedIndex)
				{
					case 0:
						waterwheelAxle--;
						break;
					case 1:
						mainRib--;
						break;
					case 2:
						link--;
						break;
					case 3:
						horizontalCrossbar--;
						break;
					case 4:
						paddle--;
						break;
					case 5:
						waterwheelSupport--;
						break;
					case 6:
						inclinedBambooTube--;
						break;
					case 7:
						waterChute--;
						break;
					default:
						Debug.LogError("选择的索引超出范围！");
						break;
				}

				UpdateNumberText(); 
			}
		}
	}

	// 按钮点击时调用的方法
	void OnButtonClick()
	{
		// 更新当前数字
		current++;
		// 将 current 的值赋给选择的变量
		switch (selectedIndex)
		{
			case 0:
				waterwheelAxle++;
				break;
			case 1:
				mainRib++;
				break;
			case 2:
				link++;
				break;
			case 3:
				horizontalCrossbar++;
				break;
			case 4:
				paddle++;
				break;
			case 5:
				waterwheelSupport++;
				break;
			case 6:
				inclinedBambooTube++;
				break;
			case 7:
				waterChute++;
				break;
			default:
				Debug.LogError("选择的索引超出范围！");
				break;
		}

		AllMaterial--; // 减少总材料数量
		UpdateNumberText(); // 更新文本显示
	}

	// 更新文本显示
	void UpdateNumberText()
	{
		if (numberText != null)
		{
			numberText.text = current.ToString(); // 显示当前数字
		}
	}
}

