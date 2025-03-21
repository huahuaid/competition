using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public Text dialogueText; // ���� Unity �� Text �ؼ�
    public string[] sentences; // �洢�Ի�������
    public GameObject npcDialoguePanel; // ���� NPCDialogue �ؼ��� GameObject
    private int index = 0; // ��ǰ�Ի�������

    void Start()
    {
        // ��ʼ����ʾ��һ�仰
        if (sentences.Length > 0)
        {
            dialogueText.text = sentences[index];
        }
    }

    void Update()
    {
        // ��������
        if (Input.GetMouseButtonDown(0))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        // ���������һ�仰
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = sentences[index];
        }
        else
        {
            // �Ի������������ı���� NPCDialogue �ؼ�
            if (npcDialoguePanel != null)
            {
                npcDialoguePanel.SetActive(false); // ���� NPCDialogue �ؼ�
            }
            gameObject.SetActive(false); // ���� DialogueManager ���ڵ� GameObject
        }
    }
}
