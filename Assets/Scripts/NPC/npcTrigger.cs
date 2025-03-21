
using UnityEngine;
using UnityEngine.UI;

public class npcTrigger : MonoBehaviour
{
	public bool isTargetNPC; 
	public bool isDialogue;
	public Image mainPlane;
	public bool toggleDialoguePlane;

	private RectTransform mainPlaneRectTransform;
	public GameObject playerObject = null;
	public Animator animator;

	void Start()
	{
		mainPlaneRectTransform = mainPlane.GetComponent<RectTransform>();
	}

	void Update()
	{
		Dialogue();
		if (isTargetNPC)
		{
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			screenPosition.y += 250;
			mainPlaneRectTransform.position = screenPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerObject = other.gameObject;
			isTargetNPC = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isDialogue = false;
			isTargetNPC = false;
			toggleDialoguePlane = false;
			playerObject = null;
			mainPlane.gameObject.SetActive(false);
		}
	}

	void Dialogue()
	{
		if (Input.GetKeyDown(KeyCode.E) && isTargetNPC)
		{
			isDialogue = true;
			toggleDialoguePlane = !toggleDialoguePlane;
			mainPlane.gameObject.SetActive(toggleDialoguePlane);
		}
	}
}

