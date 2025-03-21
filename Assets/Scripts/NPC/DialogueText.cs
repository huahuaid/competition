using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public Text dialogueText; // 引用 Unity 的 Text 控件
    public string[] sentences; // 存储对话的数组
    public GameObject npcDialoguePanel; // 引用 NPCDialogue 控件的 GameObject
    private int index = 0; // 当前对话的索引

    void Start()
    {
        // 初始化显示第一句话
        if (sentences.Length > 0)
        {
            dialogueText.text = sentences[index];
        }
    }

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        // 如果还有下一句话
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = sentences[index];
        }
        else
        {
            // 对话结束，隐藏文本框和 NPCDialogue 控件
            if (npcDialoguePanel != null)
            {
                npcDialoguePanel.SetActive(false); // 隐藏 NPCDialogue 控件
            }
            gameObject.SetActive(false); // 隐藏 DialogueManager 所在的 GameObject
        }
    }
}
