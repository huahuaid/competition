using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlacementArea : MonoBehaviour
{
	private bool isCurrentObjectInPlacementArea;
	public SpriteRenderer spriteRenderer;

	public GameObject inventory;
	private InventoryManager inventoryManager;

	public static bool isAllPrefab;
	private string itemName;
	private HashSet<string> enteredItemNames = new HashSet<string>();
	private HashSet<string> predefinedItemNames = new HashSet<string>
	{
		"wheel",
	};

	void Start()
	{
		inventoryManager = inventory.GetComponent<InventoryManager>();
	}

	void Update()
	{
		if (PlaceableObject.isVisablePut && isCurrentObjectInPlacementArea)
		{

			inventoryManager.RemoveItemByName(PlaceableObject.itemName);

			enteredItemNames.Add(itemName);

			if (enteredItemNames.IsSupersetOf(predefinedItemNames))
			{
				isAllPrefab = true;
				NextSence();
			}
		}
		if (isAllPrefab)
		{
			Color color = spriteRenderer.color;
			color.a = 1f;
			spriteRenderer.color = color;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Follow"))
		{
			isCurrentObjectInPlacementArea = true;

			itemName = PlaceableObject.itemName;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Follow"))
		{
			isCurrentObjectInPlacementArea = false;
		}
	}

	void NextSence(){
		SceneManager.LoadScene(2);
	}
}
