using UnityEngine;

public class AutoPickup : MonoBehaviour
{
	InventoryManager inventoryManager = new InventoryManager();

	void Start()
	{

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
					Debug.Log($"拾取物品: {itemobject.itemName}, 数量: {amount}");
				}
				Destroy(other.gameObject);
			}
		}
	}
}
