using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EnhancedClickDetector : MonoBehaviour, IPointerClickHandler
{
    
    [Header("UI References")]
    public Text feedbackText;          // 显示正确/错误提示的Text组件
    public GameObject panelToClose;    // 答对后需要关闭的面板
    public GameObject panelToOpen;     // 答对后需要打开的面板（可选）

    [Header("Colors")]
    public Color correctColor = Color.white;
    public Color wrongColor = new Color(0.56f, 0f, 0f); // #8f0000的RGB值

    private QuestionOne questionValidator;

    void Start()
    {
        questionValidator = GetComponentInParent<QuestionOne>();

        // 确保反馈文本初始隐藏
        if (feedbackText != null)
            feedbackText.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Text clickedText = eventData.pointerCurrentRaycast.gameObject?.GetComponent<Text>();
        if (clickedText == null) return;

        // 获取选项文本（如"A. 选项内容"）
        string selectedOption = clickedText.text;

        // 关键修改：获取问题名称的方式
        // 原方式：transform.parent?.parent?.gameObject.name
        // 新方式：从最外层问题面板获取名称
        Transform questionPanel = transform;
        while (questionPanel != null && !questionPanel.name.StartsWith("Question"))
        {
            questionPanel = questionPanel.parent;
        }
        string questionName = questionPanel?.name ?? "Unknown";

        // 验证答案
        bool isCorrect = questionValidator.Judege(selectedOption, questionName);

        // 处理结果
        HandleAnswerFeedback(isCorrect, selectedOption);
    }

    private void HandleAnswerFeedback(bool isCorrect, string selectedOption)
    {
        if (feedbackText == null) return;

        feedbackText.gameObject.SetActive(true);

        if (isCorrect)
        {
            // 正确处理
            feedbackText.text = "回答正确！";
            feedbackText.color = correctColor;

            if (panelToClose != null)
                panelToClose.SetActive(false);

            if (panelToOpen != null)
                panelToOpen.SetActive(true);

            ErrorDialogManager.isInError = false;
        }
        else
        {
            // 错误处理
            feedbackText.text = "哎呀！再思考一下哦。";
            feedbackText.color = wrongColor;
            ErrorDialogManager.isInError = true;
        }
    }

}