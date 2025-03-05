using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
	public static bool isCurrentObjectInPlacementArea;
	public static bool isVisablePut;
	public SpriteRenderer spriteRenderer;
	public static string itemName;

	void Update()
	{
		if (isCurrentObjectInPlacementArea && Input.GetMouseButtonDown(0))
		{
			isVisablePut = true;
			spriteRenderer.sprite = null;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Area"))
		{
			isCurrentObjectInPlacementArea = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Area"))
		{
			isCurrentObjectInPlacementArea = false;
		}
	}
}
