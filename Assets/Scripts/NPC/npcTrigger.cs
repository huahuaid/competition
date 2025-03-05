using UnityEngine;
using UnityEngine.UI;

public class npcTrigger : MonoBehaviour
{
	public bool isTargetNPC; 
	public Image mainPlane;
	public bool toggleDialoguePlane;

	void Start()
	{

	}

	void Update()
	{
		Dialogue();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isTargetNPC = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isTargetNPC = false;
		}
	}

	void Dialogue(){
		if (Input.GetKeyDown(KeyCode.E) && isTargetNPC)
		{
			mainPlane.gameObject.SetActive(!toggleDialoguePlane);
			toggleDialoguePlane = !toggleDialoguePlane;
		}
	}
}
