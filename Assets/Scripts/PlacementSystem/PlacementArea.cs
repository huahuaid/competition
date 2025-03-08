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
	private PlaceableObject placeableObject;
	private HashSet<string> enteredItemNames = new HashSet<string>();
	private HashSet<string> predefinedItemNames = new HashSet<string>
	{
		"wheel",
			"Frame"
	};

	void Start()
	{
		inventoryManager = inventory.GetComponent<InventoryManager>();
	}

	void Update()
	{
		HandlePlacement();
		UpdateSpriteVisibility();
	}

	// Handles the logic for placing objects in the placement area.
	private void HandlePlacement()
	{
		if (placeableObject != null && placeableObject.isVisablePut && isCurrentObjectInPlacementArea)
		{
			ProcessItemPlacement();
		}
	}

	// Processes the placement of an item, removing it from the inventory and checking if all required items are placed.
	private void ProcessItemPlacement()
	{
		inventoryManager.RemoveItemByName(itemName);
		enteredItemNames.Add(itemName);
		placeableObject.isVisablePut = false;

		if (enteredItemNames.IsSupersetOf(predefinedItemNames))
		{
			isAllPrefab = true;
			NextScene();
		}
	}

	// Updates the visibility of the sprite based on whether all required items are placed.
	private void UpdateSpriteVisibility()
	{
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
			placeableObject = other.GetComponent<PlaceableObject>();
			itemName = placeableObject.itemName;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Follow"))
		{
			isCurrentObjectInPlacementArea = false;
		}
	}

	// Loads the next scene.
	private void NextScene()
	{
		SceneManager.LoadScene(2);
	}
}
