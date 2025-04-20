using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;


//0419xzj新增
[System.Serializable]
public class DialogueOption
{
    [TextArea(1, 3)]
    public string optionText;
    public UnityEvent onSelect;
}

public class DialogueText : MonoBehaviour
{
    // 原有字段
    public Text dialogueText;
    public string[] sentences;
    public GameObject npcDialoguePanel;
    private int index = 0;

    // 0419xzj新增选项相关字段
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
        // 新增空引用检查
        if (optionButtonPrefab == null)
        {
            Debug.LogError("OptionButtonPrefab 未赋值！");
            return;
        }

        if (optionPanel == null)
        {
            Debug.LogError("OptionPanel 未赋值！");
            return;
        }

        if (endOptions.Length == 0)
        {
            Debug.LogWarning("没有配置任何选项");
            CloseAll();
            return;
        }

        // 新增组件检查
        VerticalLayoutGroup layout = optionPanel.GetComponent<VerticalLayoutGroup>();
        if (layout == null)
        {
            Debug.LogError("OptionPanel 缺少 VerticalLayoutGroup 组件！");
            return;
        }

        foreach (var option in endOptions)
        {
            Button btn = Instantiate(optionButtonPrefab, optionPanel.transform);

            // 检查按钮文本组件
            Text btnText = btn.GetComponentInChildren<Text>();
            if (btnText == null)
            {
                Debug.LogError("按钮预制体缺少 Text 组件！");
                Destroy(btn.gameObject);
                continue;
            }

            btnText.text = option.optionText;

            // 安全的事件绑定
            if (option.onSelect != null)
            {
                btn.onClick.AddListener(() => {
                    option.onSelect.Invoke();
                    CloseAll();
                });
            }
            else
            {
                Debug.LogWarning($"选项 '{option.optionText}' 未设置回调事件");
            }
        }

        // 清空现有按钮
        foreach (Transform child in optionPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // 生成新按钮
        foreach (var option in endOptions)
        {
            Button btn = Instantiate(optionButtonPrefab, optionPanel.transform);
            btn.GetComponentInChildren<Text>().text = option.optionText;
            btn.onClick.AddListener(() => {
                option.onSelect?.Invoke();
                CloseAll();
            });
        }

        // 调整布局
        // 布局调整
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