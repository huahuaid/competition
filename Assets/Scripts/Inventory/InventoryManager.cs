using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager Instance;

	[Header("Inventory Settings")]
	[SerializeField] private int maxSlots = 12;
	private List<ItemStack> inventory = new List<ItemStack>();

	[System.Serializable]
	public class ItemStack
	{
		public Item item;
		public int amount;

		public ItemStack(Item item, int amount)
		{
			this.item = item;
			this.amount = amount;
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		InitializeInventory();
	}

	private void InitializeInventory()
	{
		for (int i = 0; i < maxSlots; i++)
		{
			inventory.Add(new ItemStack(null, 0));
		}
	}

	public bool AddItem(Item item, int amount = 1)
	{
		if (item == null || amount <= 0)
		{
			return false;
		}

		if (item.isStackable)
		{
			for (int i = 0; i < inventory.Count; i++)
			{
				if (inventory[i].item == item && inventory[i].amount < item.maxStack)
				{
					int spaceAvailable = item.maxStack - inventory[i].amount;
					int amountToAdd = Mathf.Min(spaceAvailable, amount);
					inventory[i].amount += amountToAdd;
					amount -= amountToAdd;
					if (amount <= 0) return true;
				}
			}
		}

		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].item == null)
			{
				inventory[i].item = item;
				inventory[i].amount = Mathf.Min(amount, item.maxStack);
				amount -= inventory[i].amount;

				if (amount <= 0) return true;
			}
		}

		return false; 
	}

	public bool RemoveItemByName(string itemName)
	{
		if (string.IsNullOrEmpty(itemName))
		{
			return false;
		}

		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].item != null && inventory[i].item.itemName == itemName)
			{
				inventory[i] = new ItemStack(null, 0);
				Debug.Log($"成功删除物品: {itemName}");
				return true;
			}
		}

		return false;
	}

	public ItemStack FindItemById(int itemId)
	{
		foreach (var stack in inventory)
		{
			if (stack.item != null && stack.item.id == itemId)
			{
				return stack;
			}
		}
		return null;
	}

	public ItemStack FindItemByName(string itemName)
	{
		foreach (var stack in inventory)
		{
			if (stack.item != null && stack.item.itemName == itemName)
			{
				return stack;
			}
		}
		return null;
	}

	public List<Item> AllItem(){
		List<Item> list = new List<Item>();
		foreach ( var stack in inventory){
			if (stack.item != null)
			{
				list.Add(stack.item);
			}
		}
		return list;
	}

	public void PrintInventory()
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].item != null)
			{
				Debug.Log($"槽位 {i}: {inventory[i].item.itemName} x {inventory[i].amount}");
			}
			else
			{
				Debug.Log($"槽位 {i}: 空");
			}
		}
	}
}
