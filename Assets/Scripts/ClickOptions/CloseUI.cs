using UnityEngine;
using UnityEngine.UI;

public class CloseUI : MonoBehaviour
{
	public Image BackGround;
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
		BackGround.gameObject.SetActive(false);
	}
}
