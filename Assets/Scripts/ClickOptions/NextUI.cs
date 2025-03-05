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
			text.text = "�ش���ȷ��";
		}
		
		if (!clickUITextDetector.IsAnswerCorrect)
		{
			Color textColor;
			if (ColorUtility.TryParseHtmlString("#8f0000", out textColor)) // ʹ�ú�ɫ
			{
				text.color = textColor;
			}

			textGameObject.SetActive(true);
			text.text = "�ش����������";
		}

	}
}
