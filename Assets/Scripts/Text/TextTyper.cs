
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTyper : MonoBehaviour
{
	public float typingSpeed = 0.1f;  // 每个字符的显示时间
	public string fullText = ""; // 完整文本
	private string currentText = "";   // 当前显示的文本
	private Text textComponent;

	void Start()
	{
		textComponent = GetComponent<Text>();
		StartCoroutine(TypeText());
	}

	private IEnumerator TypeText()
	{
		foreach (char letter in fullText.ToCharArray())
		{
			currentText += letter;  // 添加下一个字符
			textComponent.text = currentText;  // 更新UI Text
			yield return new WaitForSeconds(typingSpeed);  // 等待一段时间
		}
	}
}

