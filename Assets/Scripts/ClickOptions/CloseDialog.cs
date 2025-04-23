using UnityEngine;
using UnityEngine.UI;

public class CloseDialog : MonoBehaviour
{
	public new GameObject gameObject;

	void Start()
	{
		Button closeButton = GetComponent<Button>();
		if (closeButton != null)
		{
			closeButton.onClick.AddListener(Close);
		}
	}

	private void Close()
	{
		if (gameObject != null)
		{
			gameObject.SetActive(false);
		}
	}
}
