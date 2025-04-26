using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public GameObject success;

	//��Ϸ����
	public Spawner spawner;
	public MovingObject movingObject;

	private int bagWholeWeight = 0;
	private int woodWeight = 0;
	private bool[] workpieces = { false, false, false, false, false };

	public Text bagWholeWeightText;
	public Text woodWeightText;

	public PlayerCollision playerCollision;

	//�涨����������
	public int presBagWholeWeight = 15;
	//�涨Ҫ�ռ���ľͷ����
	public int presWoodWeight = 10;

	//�Ƿ��ҵ��㹻ľͷ
	private static bool isEnoughWood = false;
	//�����Ƿ���
	private bool isBagFull = false;

    //�¼����������ڽ�����Ϸ
    public event Action OnThresholdReached;

    // ����������������
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

                Debug.Log("�ռ�ʧ��");
				OnThresholdReached?.Invoke();
				//���¿�ʼ
				//restart();
			}
		}
		if (isEnoughWood)
		{
            //spawner.StopSpawning();
            //movingObject.SetMovementFalse();
            //success.SetActive(true);

            Debug.Log("�ռ��ɹ�");
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
		bagWholeWeightText.text = "��ǰ��������:" + bagWholeWeight;

	}
	void UpdateWoodWeightDisplay()
	{
		woodWeightText.text = "ľͷ����:" + woodWeight;
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
