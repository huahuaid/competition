// PickupableItem.cs
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
	public new GameObject gameObject;
	public Item item;
	public int amount = 1;

	private InventoryManager inventoryManager;

	void Start(){
		inventoryManager = InventoryManager.Instance;
		if (AssemblyProcessor.isAllPrefab)
		{
			gameObject.SetActive(false);
		}
	}

	void Update(){
	}
}
