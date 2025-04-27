using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public GameObject success;
	public GameObject error;

	// 游戏结束
	public Spawner spawner;
	public MovingObject movingObject;

	private int bagWholeWeight = 0;
	private int woodWeight = 0;
	private int bambooWeight = 0; // 竹子收集量

	public Text bagWholeWeightText;
	public Text woodWeightText;
	public Text bambooWeightText; // 竹子UI显示

	public PlayerCollision playerCollision;

	// 规定背包的总重
	private int presBagWholeWeight = 70;
	// 规定要收集的木头重量
	private int presWoodWeight = 50;
	// 规定要收集的竹子数量
	private int presBambooCount = 8;

	// 状态标志
	private static bool isEnoughWood = false;
	private static bool isEnoughBamboo = false; // 是否收集足够竹子
	private bool isBagFull = false;

	// 事件声明，用于结束游戏
	public event Action OnThresholdReached;

	// 公共访问属性
	public bool IsBagFull => isBagFull;
	public bool IsEnoughWood => isEnoughWood;
	public bool IsEnoughBamboo => isEnoughBamboo;

	private ClickSoundPlayer clickSoundPlayer;

	void Start()
	{
		clickSoundPlayer = FindObjectOfType<ClickSoundPlayer>();
	}

	void Update()
	{
		Debug.Log($"Wood: {woodWeight}/{presWoodWeight}, Bamboo: {bambooWeight}/{presBambooCount}, Bag: {bagWholeWeight}/{presBagWholeWeight}");
		isSuccess();

		if (isBagFull)
		{
			if (!isEnoughWood || !isEnoughBamboo)
			{
				error.SetActive(true);
				Debug.Log("收集失败");
				OnThresholdReached?.Invoke();
			}
		}

		if (isEnoughWood && isEnoughBamboo)
		{
			success.SetActive(true);
			Debug.Log("收集成功");
			OnThresholdReached?.Invoke();
		}
	}

	public void AddBagWholeWeight(int points)
	{
		bagWholeWeight += points;
		UpdatebagWholeWeightDisplay();
		clickSoundPlayer?.PlayClickSound();
	}

	public void AddWoodWeight(int point)
	{
		woodWeight += point;
		UpdateWoodWeightDisplay();
		clickSoundPlayer?.PlayClickSound();
	}

	public void AddBambooWeight(int point)
	{
		bambooWeight += point;
		UpdateBambooWeightDisplay();
		clickSoundPlayer?.PlayClickSound();
	}

	void UpdatebagWholeWeightDisplay()
	{
		bagWholeWeightText.text = "当前背包重量: " + bagWholeWeight+"/"+presBagWholeWeight;
	}

	void UpdateWoodWeightDisplay()
	{
		woodWeightText.text = ": " + woodWeight+"/"+presWoodWeight;
	}

	void UpdateBambooWeightDisplay()
	{
		bambooWeightText.text = ": " + bambooWeight+"/"+presBambooCount;
	}

	public void isSuccess()
	{
		// 检查背包是否满
		isBagFull = bagWholeWeight >= presBagWholeWeight;

		// 检查木头是否足够
		isEnoughWood = woodWeight >= presWoodWeight;

		// 检查竹子是否足够
		isEnoughBamboo = bambooWeight >= presBambooCount;
	}

	// 获取当前收集量
	public int GetbagWholeWeight() => bagWholeWeight;
	public int GetwoodWeight() => woodWeight;
	public int GetBambooWeight() => bambooWeight;
	public bool GetisEnoughWood() => isEnoughWood;
	public bool GetisEnoughBamboo() => isEnoughBamboo;
}
