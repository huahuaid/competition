using UnityEngine;

public class Prompt : MonoBehaviour
{
	[Header("offer")]
	public float yoffset;

	public GameObject PromptSign;
	private bool isPromptVisible;

	void Start()
	{
		PromptSign.SetActive(isPromptVisible);
	}

	void Update()
	{
		if (isPromptVisible)
		{
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			PromptSign.transform.position = new Vector3(screenPosition.x, screenPosition.y + yoffset, screenPosition.z);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isPromptVisible = true;
			PromptSign.SetActive(isPromptVisible);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isPromptVisible = false;
			PromptSign.SetActive(isPromptVisible);
		}
	}
}

