using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;


//0419xzj����
[System.Serializable]
public class DialogueOption
{
    [TextArea(1, 3)]
    public string optionText;
    public UnityEvent onSelect;
}

public class DialogueText : MonoBehaviour
{
    // ԭ���ֶ�
    public Text dialogueText;
    public string[] sentences;
    public GameObject npcDialoguePanel;
    private int index = 0;

    // 0419xzj����ѡ������ֶ�
    [Header("Options Settings")]
    public GameObject optionPanel;
    public Button optionButtonPrefab;
    public DialogueOption[] endOptions;
    public float optionSpacing = 10f;

    void Start()
    {
        optionPanel.SetActive(false);
        ShowFirstSentence();
    }

    void ShowFirstSentence()
    {
        if (sentences.Length > 0)
        {
            dialogueText.text = sentences[0];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = sentences[index];
        }
        else
        {
            if (endOptions.Length > 0)
            {
                ShowOptions();
            }
            else
            {
                CloseAll();
            }
        }
    }

    void ShowOptions()
    {
        // ���������ü��
        if (optionButtonPrefab == null)
        {
            Debug.LogError("OptionButtonPrefab δ��ֵ��");
            return;
        }

        if (optionPanel == null)
        {
            Debug.LogError("OptionPanel δ��ֵ��");
            return;
        }

        if (endOptions.Length == 0)
        {
            Debug.LogWarning("û�������κ�ѡ��");
            CloseAll();
            return;
        }

        // ����������
        VerticalLayoutGroup layout = optionPanel.GetComponent<VerticalLayoutGroup>();
        if (layout == null)
        {
            Debug.LogError("OptionPanel ȱ�� VerticalLayoutGroup �����");
            return;
        }

        foreach (var option in endOptions)
        {
            Button btn = Instantiate(optionButtonPrefab, optionPanel.transform);

            // ��鰴ť�ı����
            Text btnText = btn.GetComponentInChildren<Text>();
            if (btnText == null)
            {
                Debug.LogError("��ťԤ����ȱ�� Text �����");
                Destroy(btn.gameObject);
                continue;
            }

            btnText.text = option.optionText;

            // ��ȫ���¼���
            if (option.onSelect != null)
            {
                btn.onClick.AddListener(() => {
                    option.onSelect.Invoke();
                    CloseAll();
                });
            }
            else
            {
                Debug.LogWarning($"ѡ�� '{option.optionText}' δ���ûص��¼�");
            }
        }

        // ������а�ť
        foreach (Transform child in optionPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // �����°�ť
        foreach (var option in endOptions)
        {
            Button btn = Instantiate(optionButtonPrefab, optionPanel.transform);
            btn.GetComponentInChildren<Text>().text = option.optionText;
            btn.onClick.AddListener(() => {
                option.onSelect?.Invoke();
                CloseAll();
            });
        }

        // ��������
        // ���ֵ���
        var verticalLayout = optionPanel.GetComponent<VerticalLayoutGroup>();
        if (verticalLayout != null)
        {
            verticalLayout.spacing = optionSpacing;
        }
        optionPanel.SetActive(true);

        //optionPanel.GetComponent<VerticalLayoutGroup>().spacing = optionSpacing;
        //optionPanel.SetActive(true);

    }

    public void ResetDialogue()
    {
        index = 0;
        optionPanel.SetActive(false);
        ShowFirstSentence();
        gameObject.SetActive(true);
        npcDialoguePanel?.SetActive(true);
    }

    void CloseAll()
    {
        optionPanel.SetActive(false);
        npcDialoguePanel?.SetActive(false);
        gameObject.SetActive(false);
    }
}