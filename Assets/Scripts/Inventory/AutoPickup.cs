using UnityEngine;

public class AutoPickup : MonoBehaviour
{
	public GameObject Inventory;
	private InventoryManager inventoryManager;

	void Start()
	{
		inventoryManager = Inventory.GetComponent<InventoryManager>(); 
	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Item"))
		{
			PickupableItem pickupableItem = other.GetComponent<PickupableItem>();
			if (pickupableItem != null)
			{
				Item itemobject = pickupableItem.item;
				int amount = pickupableItem.amount;
				if (inventoryManager.AddItem(itemobject,amount))
				{
					Debug.Log(pickupableItem.item.itemName);
					Destroy(other.gameObject);
				}
			}
		}
	}
}
