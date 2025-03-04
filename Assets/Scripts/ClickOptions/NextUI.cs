using UnityEngine;
using UnityEngine.UI;

public class NextUI : MonoBehaviour
{
	public Button targetButton;
	public GameObject planeToClose; 
	public GameObject planeToOpen;
    public ClickUITextDetector clickUITextDetector;

    void Start()
	{
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
            
        }
        else
        {
            Debug.Log("回答错误，无法切换界面。" + clickUITextDetector.IsAnswerCorrect);
        }
    }
}
