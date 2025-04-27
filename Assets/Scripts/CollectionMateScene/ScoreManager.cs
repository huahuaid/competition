using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public GameObject success;
	public GameObject error;

	// ��Ϸ����
	public Spawner spawner;
	public MovingObject movingObject;

	private int bagWholeWeight = 0;
	private int woodWeight = 0;
	private int bambooWeight = 0; // �����ռ���

	public Text bagWholeWeightText;
	public Text woodWeightText;
	public Text bambooWeightText; // ����UI��ʾ

	public PlayerCollision playerCollision;

	// �涨����������
	private int presBagWholeWeight = 70;
	// �涨Ҫ�ռ���ľͷ����
	private int presWoodWeight = 50;
	// �涨Ҫ�ռ�����������
	private int presBambooCount = 8;

	// ״̬��־
	private static bool isEnoughWood = false;
	private static bool isEnoughBamboo = false; // �Ƿ��ռ��㹻����
	private bool isBagFull = false;

	// �¼����������ڽ�����Ϸ
	public event Action OnThresholdReached;

	// ������������
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
				Debug.Log("�ռ�ʧ��");
				OnThresholdReached?.Invoke();
			}
		}

		if (isEnoughWood && isEnoughBamboo)
		{
			success.SetActive(true);
			Debug.Log("�ռ��ɹ�");
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
		bagWholeWeightText.text = "��ǰ��������: " + bagWholeWeight+"/"+presBagWholeWeight;
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
		// ��鱳���Ƿ���
		isBagFull = bagWholeWeight >= presBagWholeWeight;

		// ���ľͷ�Ƿ��㹻
		isEnoughWood = woodWeight >= presWoodWeight;

		// ��������Ƿ��㹻
		isEnoughBamboo = bambooWeight >= presBambooCount;
	}

	// ��ȡ��ǰ�ռ���
	public int GetbagWholeWeight() => bagWholeWeight;
	public int GetwoodWeight() => woodWeight;
	public int GetBambooWeight() => bambooWeight;
	public bool GetisEnoughWood() => isEnoughWood;
	public bool GetisEnoughBamboo() => isEnoughBamboo;
}
