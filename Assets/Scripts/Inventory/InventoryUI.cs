using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	private void Start()
	{
		PrintAllItems();
	}

	private void PrintAllItems()
	{
		List<Item> allItems = InventoryManager.Instance.AllItem();

		Debug.Log("背包中的所有物品：");
		foreach (var item in allItems)
		{
			Debug.Log($"物品: {item.itemName}");
		}
	}
}
