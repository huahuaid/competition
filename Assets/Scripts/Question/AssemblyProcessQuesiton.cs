using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AssemblyProcessQuestion : MonoBehaviour, IPointerClickHandler
{
	public GameObject[] textGameObjects;
	public GameObject[] AllError;  // 假设每个 GameObject 代表一个错误
	public GameObject[] AllCorrect; // 假设每个 GameObject 代表一个正确答案
	public string CorrectAnswer;
	public bool isCorrect;

	private int lastErrorIndex = -1; // 跟踪上一个错误的索引
	private int lastCorrectIndex = -1; // 跟踪上一个正确的索引

	void Start()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

		Text clickedText = clickedObject.GetComponent<Text>();
		if (clickedText != null)
		{
			string selectedText = clickedText.text;

			if (selectedText.Length > 0)
			{
				char firstCharacter = selectedText[0]; 
				isCorrect = CompareFirstCharacter(firstCharacter);
				Debug.Log(isCorrect);
			}
		}
	}

	private bool CompareFirstCharacter(char firstCharacter)
	{
		// 获取正确答案的第一个字符
		char correctFirstCharacter = CorrectAnswer.Length > 0 ? CorrectAnswer[0] : '\0';
		Debug.Log(firstCharacter);

		if (firstCharacter != correctFirstCharacter)
		{
			ErrorSelect(firstCharacter);
		}
		else
		{
			CorrectSelect(firstCharacter);
		}

		// 比较并返回结果
		return firstCharacter == correctFirstCharacter;
	}

	private void ErrorSelect(char selected)
	{
		// 将字符转换为索引（A=0, B=1, C=2, D=3）
		int index = selected - 'A'; // 'A' 的 ASCII 码是 65

		if (index >= 0 && index < AllError.Length)
		{
			// 如果有上一个错误，先将其关闭
			if (lastErrorIndex != -1 && lastErrorIndex < AllError.Length)
			{
				AllError[lastErrorIndex].SetActive(false); // 关闭上一个错误对象
			}

			// 激活当前选择的错误对象
			AllError[index].SetActive(true);
			lastErrorIndex = index; // 更新上一个错误索引
		}
	}

	private void CorrectSelect(char selected)
	{
		// 将字符转换为索引（A=0, B=1, C=2, D=3）
		int index = selected - 'A'; // 'A' 的 ASCII 码是 65

		if (index >= 0 && index < AllCorrect.Length)
		{
			// 如果有上一个正确，先将其关闭
			if (lastCorrectIndex != -1 && lastCorrectIndex < AllCorrect.Length)
			{
				AllCorrect[lastCorrectIndex].SetActive(false); // 关闭上一个正确对象
			}

			// 激活当前选择的正确对象
			AllCorrect[index].SetActive(true);
			lastCorrectIndex = index; // 更新上一个正确索引
		}
	}
}
