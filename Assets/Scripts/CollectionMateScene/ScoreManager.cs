using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public GameObject success;

	//游戏结束
	public Spawner spawner;
	public MovingObject movingObject;

	private int bagWholeWeight = 0;
	private int woodWeight = 0;
	private bool[] workpieces = { false, false, false, false, false };

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

    //事件声明，用于结束游戏
    public event Action OnThresholdReached;

    // 新增公共访问属性
    public bool IsBagFull => isBagFull;
    public bool IsEnoughWood => isEnoughWood;

    // Start is called before the first frame update
    void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("isEnoughWood" + isEnoughWood);
		Debug.Log("isBagFull" + isBagFull);
		isSuccess();
		if(isBagFull)
		{
			if (!isEnoughWood)
			{
                //spawner.StopSpawning();
				//movingObject.SetMovementFalse();
                //success.SetActive(true);

                Debug.Log("收集失败");
				OnThresholdReached?.Invoke();
				//重新开始
				//restart();
			}
		}
		if (isEnoughWood)
		{
            //spawner.StopSpawning();
            //movingObject.SetMovementFalse();
            //success.SetActive(true);

            Debug.Log("收集成功");
            OnThresholdReached?.Invoke();
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
				if (workpieces.All(b => b))
				{
                    isEnoughWood = true;
                }
			}
		}

		if (bagWholeWeight <= presBagWholeWeight)
		{
			if (woodWeight >= presWoodWeight)
			{
                if (workpieces.All(b => b))
                {
                    isEnoughWood = true;
                }
            }
		}
	}

	public void CollectWorkPieces(int index)
	{
		workpieces[index] = true;
	}
}
