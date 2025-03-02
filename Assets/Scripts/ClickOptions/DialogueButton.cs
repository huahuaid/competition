using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
	public Transform targetTransform;
	public Image image;
	public float yOffset = 300f;

	void Start()
	{
		if (targetTransform != null && image != null)
		{
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);

			screenPosition.y += yOffset;

			image.rectTransform.position = screenPosition;
		}
	}

	
}
