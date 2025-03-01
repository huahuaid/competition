using UnityEngine;
using UnityEngine.UI;

public class NextUI : MonoBehaviour
{
	public Button targetButton;
	public GameObject planeToClose; 
	public GameObject planeToOpen; 

	void Start()
	{
		if (targetButton != null)
		{
			targetButton.onClick.AddListener(OnButtonClicked);
		}
	}

	void OnButtonClicked()
	{
		planeToClose.SetActive(false);
		planeToOpen.SetActive(true);
	}
}
