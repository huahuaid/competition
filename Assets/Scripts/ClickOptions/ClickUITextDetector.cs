using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickUITextDetector : MonoBehaviour, IPointerClickHandler
{
	private Text text;
	private QuestionOne q;
	public GameObject textGameObject;
	public bool IsAnswerCorrect { get; private set; }

	void Start()
	{
 q = GetComponentInParent<QuestionOne>();
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

				IsAnswerCorrect = q.Judege(option, questionName);

				Debug.Log("点击的选项所属问题是: " + IsAnswerCorrect);

				textGameObject.SetActive(true);
				text.text = option;
			}
		}
	}
	
}
