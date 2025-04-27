
using UnityEngine;
using UnityEngine.UI;

public class AllMaterialManager : MonoBehaviour
{
    public GameObject backCanvas;
    public GameObject errorCanvas;
    public Text text;
	public Text BambooText;
	public Button checkButton; // 按钮引用

	// 静态变量来判断是否达标
	public static bool isMaterialsSufficient = false;

	// 设定每种材料的达标数量
	private int requiredWaterwheelAxle = 1;          // 水车中轴达标数量
	private int requiredMainRib = 8;                // 主辐条达标数量
	private int requiredLink = 16;                     // 连杆达标数量
	private int requiredHorizontalCrossbar = 8;      // 横杠达标数量
	private int requiredPaddle = 8;                   // 刮板达标数量
	private int requiredWaterwheelSupport = 1;       // 水车支架达标数量
	private int requiredInclinedBambooTube = 8;      // 斜装竹筒达标数量
	private int requiredWaterChute = 1;               // 水舰（导水槽）达标数量

	void Start()
	{
		checkButton.onClick.AddListener(CheckMaterials);
	}

	void Update()
	{
		text.text = ": " + IncreaseNumber.AllMaterial;
		BambooText.text = ": "+IncreaseNumber.AllMaterialBamboo;
	}

	void CheckMaterials()
	{
		// 打印 IncreaseNumber 的静态值
		Debug.Log("水车中轴: " + IncreaseNumber.waterwheelAxle);
		Debug.Log("主辐条: " + IncreaseNumber.mainRib);
		Debug.Log("连杆: " + IncreaseNumber.link);
		Debug.Log("横杠: " + IncreaseNumber.horizontalCrossbar);
		Debug.Log("刮板: " + IncreaseNumber.paddle);
		Debug.Log("水车支架: " + IncreaseNumber.waterwheelSupport);
		Debug.Log("斜装竹筒: " + IncreaseNumber.inclinedBambooTube);
		Debug.Log("水舰: " + IncreaseNumber.waterChute);
		Debug.Log("总材料: " + IncreaseNumber.AllMaterial);

		isMaterialsSufficient = (IncreaseNumber.waterwheelAxle == requiredWaterwheelAxle &&
				IncreaseNumber.mainRib == requiredMainRib &&
				IncreaseNumber.link == requiredLink &&
				IncreaseNumber.horizontalCrossbar == requiredHorizontalCrossbar &&
				IncreaseNumber.paddle == requiredPaddle &&
				IncreaseNumber.waterwheelSupport == requiredWaterwheelSupport &&
				IncreaseNumber.inclinedBambooTube == requiredInclinedBambooTube &&
				IncreaseNumber.waterChute == requiredWaterChute);

		if (isMaterialsSufficient)
		{
			backCanvas.SetActive(true);
		}
		else
		{
			errorCanvas.SetActive(true);
		}
	}
}

