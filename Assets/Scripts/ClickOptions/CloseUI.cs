using UnityEngine;
using UnityEngine.UI;

public class CloseUI : MonoBehaviour
{
	public Canvas canvas;
	public Button targetButton;

	void Start()
	{
		if (targetButton != null)
		{
			targetButton.onClick.AddListener(OnButtonClicked);
		}
	}

	void OnButtonClicked()
	{
		canvas.enabled = false;
	}
}
