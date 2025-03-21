using UnityEngine;

public class DialogueButton : MonoBehaviour
{
	public Transform targetTransform;
	public GameObject targetObject ;
	public float yOffset;
	public float xOffset;

	private npcTrigger npcTrigger;

	void Start()
	{
		npcTrigger = gameObject.GetComponent<npcTrigger>();
	}

	void Update(){
		if (targetTransform != null)
		{
			Vector3 screenPosition = targetTransform.position;  
			screenPosition.y += yOffset;  
			screenPosition.x += xOffset;  
			targetObject.transform.position = screenPosition;
		}

		if (npcTrigger.isTargetNPC && npcTrigger.toggleDialoguePlane == false)
		{
			targetObject.SetActive(true);
		}
		else
		{
			targetObject.SetActive(false);
		}
	}
}
