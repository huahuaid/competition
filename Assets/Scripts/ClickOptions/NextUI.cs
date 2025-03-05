using UnityEngine;
using UnityEngine.UI;

public class NextUI : MonoBehaviour
{
	private Text text;
	public GameObject textGameObject;
	public Button targetButton;
	public GameObject planeToClose; 
	public GameObject planeToOpen;
	public ClickUITextDetector clickUITextDetector;

	void Start()
	{
		text = textGameObject.GetComponent<Text>();
		if (targetButton != null)
		{
			targetButton.onClick.AddListener(OnButtonClicked);
		}
	}

	void OnButtonClicked()
	{
		if (clickUITextDetector != null && clickUITextDetector.IsAnswerCorrect)
		{
			planeToClose.SetActive(false);
			if(planeToOpen != null)
			{
				planeToOpen.SetActive(true);
			}

			text.color = Color.white;
			textGameObject.SetActive(true);
			text.text = "回答正确！";
		}
		
		if (!clickUITextDetector.IsAnswerCorrect)
		{
			Color textColor;
			if (ColorUtility.TryParseHtmlString("#8f0000", out textColor)) // 使用红色
			{
				text.color = textColor;
			}

			textGameObject.SetActive(true);
			text.text = "回答错了再想想";
		}

	}
}
