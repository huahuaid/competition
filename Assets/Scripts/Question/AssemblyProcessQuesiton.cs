using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AssemblyProcessQuestion : MonoBehaviour, IPointerClickHandler
{
	public GameObject[] textGameObjects;
	public string CorrectAnswer;
	public bool isCorrect;

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

		// 比较并返回结果
		return firstCharacter == correctFirstCharacter;
	}
}

