using UnityEngine.UI;
using UnityEngine;
using System;

public class Introduce : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text displayText; // 显示文本的UI Text组件
    [SerializeField] private Button actionButton; // 控制按钮
    [SerializeField] private Image displayImage; // 新增的图片组件

    [Header("Text Settings")]
    [SerializeField] private string[] textSequence; // 文本数组
    private int currentIndex = 0; // 当前显示的文本索引

    private static bool textEnd;

    // 当显示完所有文本时触发的事件
    public event Action OnSequenceCompleted;

    private void Start()
    {
        // 初始化时隐藏图片
        if (displayImage != null)
        {
            displayImage.gameObject.SetActive(false);
        }

        if (textSequence.Length > 0)
        {
            displayText.text = textSequence[0]; // 显示第一个文本
        }

        UpdateButtonText();
        actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (currentIndex < textSequence.Length - 1)
        {
            // 如果还有文本，显示下一个
            currentIndex++;
            displayText.text = textSequence[currentIndex];
            UpdateButtonText();

            // 当显示到第二个文本时显示图片
            if (currentIndex == 1 && displayImage != null)
            {
                displayImage.gameObject.SetActive(true);
            }
        }
        else
        {
            // 点击"开始"时触发
            textEnd = OnStartClicked(); // 调用方法

            // 隐藏图片当流程结束时（可选）
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
            actionButton.GetComponentInChildren<Text>().text = "继续";
        }
        else
        {
            actionButton.GetComponentInChildren<Text>().text = "开始";
        }
    }

    // 外部调用的方法，当点击"开始"时返回true
    public bool OnStartClicked()
    {
        Debug.Log("true");
        return true;
    }
}