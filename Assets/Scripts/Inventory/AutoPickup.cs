using UnityEngine;

public class AutoPickup : MonoBehaviour
{
	private InventoryManager inventoryManager;
	private PickupableItem pickupableItem;
	private GameObject Object;
	private bool isPickMove;

	void Start()
	{
		inventoryManager = FindObjectOfType<InventoryManager>();
		if (inventoryManager == null)
		{
			Debug.LogError("没有找到 InventoryManager 实例！");
		}
	}

	void Update()
	{
		if (isPickMove && Input.GetKey(KeyCode.Q))
		{
			Item itemobject = pickupableItem.item;
			int amount = pickupableItem.amount;
			if (inventoryManager.AddItem(itemobject, amount))
			{
				Destroy(Object);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Item"))
		{
			pickupableItem = other.GetComponent<PickupableItem>();
			Object = other.gameObject;
			isPickMove = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Item"))
		{
			Object = null;
			isPickMove = false;
		}
	}
}

