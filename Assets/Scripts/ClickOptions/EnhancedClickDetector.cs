using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EnhancedClickDetector : MonoBehaviour, IPointerClickHandler
{
    
    [Header("UI References")]
    public Text feedbackText;          // ��ʾ��ȷ/������ʾ��Text���
    public GameObject panelToClose;    // ��Ժ���Ҫ�رյ����
    public GameObject panelToOpen;     // ��Ժ���Ҫ�򿪵���壨��ѡ��

    [Header("Colors")]
    public Color correctColor = Color.white;
    public Color wrongColor = new Color(0.56f, 0f, 0f); // #8f0000��RGBֵ

    private QuestionOne questionValidator;

    void Start()
    {
        questionValidator = GetComponentInParent<QuestionOne>();

        // ȷ�������ı���ʼ����
        if (feedbackText != null)
            feedbackText.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Text clickedText = eventData.pointerCurrentRaycast.gameObject?.GetComponent<Text>();
        if (clickedText == null) return;

        // ��ȡѡ���ı�����"A. ѡ������"��
        string selectedOption = clickedText.text;

        // �ؼ��޸ģ���ȡ�������Ƶķ�ʽ
        // ԭ��ʽ��transform.parent?.parent?.gameObject.name
        // �·�ʽ�����������������ȡ����
        Transform questionPanel = transform;
        while (questionPanel != null && !questionPanel.name.StartsWith("Question"))
        {
            questionPanel = questionPanel.parent;
        }
        string questionName = questionPanel?.name ?? "Unknown";

        // ��֤��
        bool isCorrect = questionValidator.Judege(selectedOption, questionName);

        // ������
        HandleAnswerFeedback(isCorrect, selectedOption);
    }

    private void HandleAnswerFeedback(bool isCorrect, string selectedOption)
    {
        if (feedbackText == null) return;

        feedbackText.gameObject.SetActive(true);

        if (isCorrect)
        {
            // ��ȷ����
            feedbackText.text = "�ش���ȷ��";
            feedbackText.color = correctColor;

            if (panelToClose != null)
                panelToClose.SetActive(false);

            if (panelToOpen != null)
                panelToOpen.SetActive(true);

            ErrorDialogManager.isInError = false;
        }
        else
        {
            // ������
            feedbackText.text = "��ѽ����˼��һ��Ŷ��";
            feedbackText.color = wrongColor;
            ErrorDialogManager.isInError = true;
        }
    }

}