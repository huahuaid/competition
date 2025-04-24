using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int bagWholeWeight = 0;
    private int woodWeight = 0;
    //public Text bagWholeWeightText;
    //public TextMeshPro bagWholeWeightText;
    public TMP_Text bagWholeWeightText;
    public TMP_Text woodWeightText;

    public PlayerCollision playerCollision;

    //�涨����������
    public int presBagWholeWeight = 15;
    //�涨Ҫ�ռ���ľͷ����
    public int presWoodWeight = 10;

    //�Ƿ��ҵ��㹻ľͷ
    private static bool isEnoughWood = false;
    //�����Ƿ���
    private bool isBagFull = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isSuccess();
        if(isBagFull)
        {
            if (isEnoughWood)
            {
                Debug.Log("�ռ��ɹ�");
            }
            else
            {
                Debug.Log("�ռ�ʧ��");
            }
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
        bagWholeWeightText.text = "Bag Current Weight:" + bagWholeWeight;
        
    }
    void UpdateWoodWeightDisplay()
    {
        woodWeightText.text = "Wood Weight:" + woodWeight;
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
    }
}
