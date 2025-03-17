using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
	public Image dialogueButton;
	public Transform targetTransform;
	public Image image;
	public float yOffset;
	public float xOffset;

	private npcTrigger npcTrigger;

	void Start()
	{
		npcTrigger = gameObject.GetComponent<npcTrigger>();

		if (targetTransform != null && image != null)
		{
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);

			screenPosition.y += yOffset;
			screenPosition.x += xOffset;

			image.rectTransform.position = screenPosition;
		}
	}

	void Update(){
		if (npcTrigger.isTargetNPC && npcTrigger.toggleDialoguePlane == false)
		{
			dialogueButton.gameObject.SetActive(true);
		}
		else
		{
			dialogueButton.gameObject.SetActive(false);
		}
	}
}
