using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public GameObject success;
	private int bagWholeWeight = 0;
	private int woodWeight = 0;
	//public Text bagWholeWeightText;
	//public TextMeshPro bagWholeWeightText;
	public Text bagWholeWeightText;
	public Text woodWeightText;

	public PlayerCollision playerCollision;

	//规定背包的总重
	public int presBagWholeWeight = 15;
	//规定要收集的木头重量
	public int presWoodWeight = 10;

	//是否找到足够木头
	private static bool isEnoughWood = false;
	//背包是否满
	private bool isBagFull = false;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(isEnoughWood);
		isSuccess();
		if(isBagFull)
		{
			if (isEnoughWood)
			{
				success.SetActive(true);
				Debug.Log("收集失败");
			}
		}
		if (isEnoughWood)
		{
			success.SetActive(true);
			Debug.Log("收集成功");
		}
	}


	public void AddBagWholeWeight(int points)
	{
		bagWholeWeight += points;
		Debug.Log("Bag Current Weight:"+bagWholeWeight);
		UpdatebagWholeWeightDisplay();
	}

	public void AddWoodWeight(int point)
	{
		woodWeight += point;
		Debug.Log("Wood Weight:"+woodWeight);
		UpdateWoodWeightDisplay();
	}

	public int GetbagWholeWeight() => bagWholeWeight;
	public int GetwoodWeight() => woodWeight;
	public bool GetisEnoughWood() => isEnoughWood;

	void UpdatebagWholeWeightDisplay()
	{
		bagWholeWeightText.text = "当前背包重量:" + bagWholeWeight;

	}
	void UpdateWoodWeightDisplay()
	{
		woodWeightText.text = "木头重量:" + woodWeight;
	}

	public void isSuccess()
	{
		if (bagWholeWeight >= presBagWholeWeight)
		{
			isBagFull = true;
			if (woodWeight >= presWoodWeight)
			{
				isEnoughWood = true;
			}
		}

		if (bagWholeWeight <= presBagWholeWeight)
		{
			if (woodWeight >= presWoodWeight)
			{
				isEnoughWood = true;
			}
		}
	}
}
