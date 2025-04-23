using UnityEngine.UI;
using UnityEngine;
using System;

public class Introduce : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text displayText; // ��ʾ�ı���UI Text���
    [SerializeField] private Button actionButton; // ���ư�ť
    [SerializeField] private Image displayImage; // ������ͼƬ���

    [Header("Text Settings")]
    [SerializeField] private string[] textSequence; // �ı�����
    private int currentIndex = 0; // ��ǰ��ʾ���ı�����

    private static bool textEnd;

    // ����ʾ�������ı�ʱ�������¼�
    public event Action OnSequenceCompleted;

    private void Start()
    {
        // ��ʼ��ʱ����ͼƬ
        if (displayImage != null)
        {
            displayImage.gameObject.SetActive(false);
        }

        if (textSequence.Length > 0)
        {
            displayText.text = textSequence[0]; // ��ʾ��һ���ı�
        }

        UpdateButtonText();
        actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (currentIndex < textSequence.Length - 1)
        {
            // ��������ı�����ʾ��һ��
            currentIndex++;
            displayText.text = textSequence[currentIndex];
            UpdateButtonText();

            // ����ʾ���ڶ����ı�ʱ��ʾͼƬ
            if (currentIndex == 1 && displayImage != null)
            {
                displayImage.gameObject.SetActive(true);
            }
        }
        else
        {
            // ���"��ʼ"ʱ����
            textEnd = OnStartClicked(); // ���÷���

            // ����ͼƬ�����̽���ʱ����ѡ��
            if (displayImage != null)
            {
                displayImage.gameObject.SetActive(false);
            }
        }
    }

    private void UpdateButtonText()
    {
        if (currentIndex < textSequence.Length - 1)
        {
            actionButton.GetComponentInChildren<Text>().text = "����";
        }
        else
        {
            actionButton.GetComponentInChildren<Text>().text = "��ʼ";
        }
    }

    // �ⲿ���õķ����������"��ʼ"ʱ����true
    public bool OnStartClicked()
    {
        Debug.Log("true");
        return true;
    }
}