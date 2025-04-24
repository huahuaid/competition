using UnityEngine;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour
{
	public GameObject Object; 
	public Button button; 

	void Start()
	{
		if (button != null)
		{
			button.onClick.AddListener(OnButtonClick);
		}
	}

	void Update()
	{
	}

	void OnButtonClick()
	{
		if (Object != null)
		{
			Object.SetActive(!Object.activeSelf);
		}
	}
}

