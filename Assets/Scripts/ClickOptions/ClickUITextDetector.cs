using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickUITextDetector : MonoBehaviour, IPointerClickHandler
{
	private Text text;
	public GameObject textGameObject;
    public bool IsAnswerCorrect { get; private set; }

    void Start()
	{
		text = textGameObject.GetComponent<Text>();
	}

	void Update()
	{

	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Text optionContent = eventData.pointerCurrentRaycast.gameObject.GetComponent<Text>();

		string option= optionContent.text;

		if (optionContent != null)
		{
			GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

			GameObject questionObject = clickedObject.transform.parent?.parent?.gameObject;

			if (questionObject != null)
			{
				string questionName = questionObject.name;

				IsAnswerCorrect = Judege(option, questionName);

				textGameObject.SetActive(true);
				text.text = option;
				Debug.Log("点击的选项所属问题是: " + IsAnswerCorrect);
			}
		}
	}

	private string[] questions = { "QuestionOne", "QuestionTwo", "QuestionThree", "QuestionFour", "QuestionFive" };

	private string[] options = {"A" , "B" , "A" , "C" , "B"};

	public bool Judege(string option , string questionName)
	{
		int count = 0;

		for (int i = 0; i < questions.Length; i++)
		{
			if (questions[i] == questionName)
			{
				count = i;
				break;
			}
		}

		return options[count] == option.Split(' ')[0];
	}
}
